using MonitorVersaoFinal.Forms;
using MonitorVersaoFinal.Interfaces;
using MonitorVersaoFinal.Services;
using PainelNoticias.Interfaces;
using PainelNoticias.Models;
using PainelNoticias.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Resources.ResXFileRef;
using Newtonsoft.Json;
using MonitorVersaoFinal.Models;
using System.Text.RegularExpressions;
using System.Globalization;


namespace PainelNoticias
{
    public partial class PainelNoticias : Form
    {
        private readonly INewsService _newsService;
        private List<NewsItem> _newsItems;
        private int _currentNewsIndex;
        private Timer _newsTimer;
        private Timer _moedaTimer;
        private Timer _painelTimer;
        private Timer _climaTimer;
        private int _tempoAtualizacaoNoticias;
        private int _tempoAtualizacaoMoeda;
        private int _tempoAtualizacaoPainel;
        private int _tempoAtualizacaoClima;
        private CircularProgressBar _progressBar;

        public PainelNoticias(INewsService newsService)
        {
            InitializeComponent();
            _newsService = newsService;
            _newsItems = new List<NewsItem>();
            _currentNewsIndex = 0;
            _newsTimer = new Timer();
            _newsTimer.Tick += NewsTimer_Tick;
            // Inicialize os timers de moeda e painel
            _moedaTimer = new Timer();
            _moedaTimer.Tick += MoedaTimer_Tick;

            _painelTimer = new Timer();
            _painelTimer.Tick += PainelTimer_Tick;

            _climaTimer = new Timer();
            _climaTimer.Tick += ClimaTimer_Tick;

            // Inicialize a barra de progresso circular
            _progressBar = new CircularProgressBar
            {
                Width = 100,
                Height = 100,
                BackColor = Color.Transparent
            };
            pnQrCode.Controls.Add(_progressBar);
            _progressBar.BringToFront();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            if (_tempoAtualizacaoMoeda.Equals(0))
                _moedaTimer.Interval = 30000;
            else
                _moedaTimer.Interval = _tempoAtualizacaoMoeda;
            _moedaTimer.Start();

            if (_tempoAtualizacaoPainel.Equals(0))
                _painelTimer.Interval = 30000;
            else
                _painelTimer.Interval = _tempoAtualizacaoPainel;

            _painelTimer.Start();


            if (_tempoAtualizacaoClima.Equals(0))
                _climaTimer.Interval = 1800000;
            else
                _climaTimer.Interval = _tempoAtualizacaoClima;
            _climaTimer.Start();

            ClimaTimer_Tick(sender, e);

            RoundButton(btnTema);

            await LoadConfiguracoesAsync();
            await LoadNewsAsync();
            DisplayCurrentNews();
            if (_tempoAtualizacaoNoticias.Equals(0))
                _newsTimer.Interval = 30000;
            else
                _newsTimer.Interval = _tempoAtualizacaoNoticias;
            _newsTimer.Start();

           

        }
        private async Task LoadConfiguracoesAsync()
        {
            var xmlService = new XmlReaderService();
            xmlService.LoadRssSources("rssFeeds.xml");
            _tempoAtualizacaoNoticias = xmlService.RssConfiguracoes.TempoNoticia * 1000;
            _tempoAtualizacaoMoeda = xmlService.RssConfiguracoes.TempoMoeda * 1000; 
            _tempoAtualizacaoPainel = xmlService.RssConfiguracoes.TempoPainel * 1000;
            _tempoAtualizacaoClima = xmlService.RssConfiguracoes.TempoClima * 1000;

        }

        private async Task LoadNewsAsync()
        {
            _newsItems.Clear();
            var rssFeeds = GetRssFeedsFromXml();
            foreach (var feed in rssFeeds)
            {
                foreach (var kvp in feed)
                {
                    var newsItems = await _newsService.GetNewsItemsAsync(kvp.Value.Url, kvp.Key);
                    foreach (var newsItem in newsItems)
                    {
                        newsItem.Fonte = kvp.Value.Fonte; // Defina a fonte no item de notícia
                        newsItem.Cor = kvp.Value.Color; // Defina a cor do tema no item de notícia
                    }
                    _newsItems.AddRange(newsItems.Take(5)); // Limita a 5 notícias por feed
                }
            }
        }


        private async void DisplayCurrentNews()
        {
           if (_newsItems.Count == 0) return;

            var currentNews = _newsItems[_currentNewsIndex];
            btnTema.Text = currentNews.Tema;
            lblTitulo.Text = currentNews.Title;

            // Aplique a cor lida do XML
            btnTema.BackColor = ColorTranslator.FromHtml(currentNews.Cor);
            pnlBarra.BackColor = ColorTranslator.FromHtml(currentNews.Cor);


            try
            {
                var image = await LoadImageFromUrlAsync(currentNews.ImageUrl);
                if (image != null)
                {
                    pnlPrincipal.BackgroundImage = image;
                }
                else
                {
                    pnlPrincipal.BackgroundImage = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\"), "news_back.jpg"));
                }
            }
            catch (Exception)
            {
                pnlPrincipal.BackgroundImage = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\"), "news_back.jpg"));
            }

            VerificaFonteLogo(currentNews.Fonte);

            Image imageQr = GerarQRCode(pnQrCode.Width, pnQrCode.Height, currentNews.Link);
            //verifica se a imagem foi gerada
            if (imageQr != null)
            {
                pnQrCode.Visible = true;
                pnQrCode.BackgroundImage = imageQr;
                _progressBar.Start();
            }
            else
            {
                pnQrCode.Visible = false;
            }
        }

        public void VerificaFonteLogo(string fonte)
        {
            //Método que irá verificar a fonte e irá trocar a logo exibida
            if (fonte.Equals("G1"))
            {
                //Caminho da logo do G1 Resources/Painel/Logos/g1.png
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "G1.png"));
            }
            //Outras fontes: R7, Gazeta, Agencia, RadioAgencia, NoticiasMinuto
            else if (fonte.Equals("R7"))
            {
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "R7.png"));
            }
            else if (fonte.Equals("Gazeta"))
            {
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "Gazeta.png"));
            }
            else if (fonte.Equals("Agencia"))
            {
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "Agencia.png"));
            }
            else if (fonte.Equals("RadioAgencia"))
            {
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "RadioAgencia.png"));
            }
            else if (fonte.Equals("NoticiasMinuto"))
            {
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "NoticiasAoMinuto.png"));
            }
            else
            {
                pbLogo.Image = Image.FromFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Painel\\Logos\\"), "Logo.png"));
            }


        }

        private async Task<Image> LoadImageFromUrlAsync(string imageUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(imageUrl);
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return Image.FromStream(stream);
                    }
                }
                return null;
            }
        }
        public Bitmap GerarQRCode(int width, int height, string text)
        {
            try
            {
                var bw = new ZXing.BarcodeWriter();
                var encOptions = new ZXing.Common.EncodingOptions()
                {
                    Width = width,
                    Height = height,
                    Margin = 0 // Define a margem como zero
                };
                bw.Options = encOptions;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                var resultado = new Bitmap(bw.Write(text));
                return resultado;
            }
            catch
            {
                return null;
            }
        }


        private async void NewsTimer_Tick(object sender, EventArgs e)
        {
            _currentNewsIndex++;
            
            if (_currentNewsIndex >= _newsItems.Count)
            {
                _currentNewsIndex = 0;
                await LoadNewsAsync();
            }
            DisplayCurrentNews();
        }
        private void MoedaTimer_Tick(object sender, EventArgs e)
        {
            ConsultaCambio();
        }

        private void PainelTimer_Tick(object sender, EventArgs e)
        {
            AtualizarPainel();
        }
        private void ClimaTimer_Tick(object sender, EventArgs e)
        {
            clsClimaTempo climaTempo = new clsClimaTempo();
            Clima clima = climaTempo.ConsultarClima("São Paulo");
            lblDescricaoClima.Text = clima.DescricaoClima;
            lblTemperaturaCidade.Text = "SP, " + clima.Temperatura + "°C";
            pictureBox1.Image = clima.Image;
        }

        private void AtualizarPainel()
        {
            string strHorario = DateTime.Now.ToString("HH:mm - dd/MM");
            lbMoedaEsquerda.Text = strHorario;
        }

        private List<Dictionary<string, RssFeedInfo>> GetRssFeedsFromXml()
        {
            var rssFeeds = new List<Dictionary<string, RssFeedInfo>>();
            var xdoc = XDocument.Load("rssFeeds.xml");
            foreach (var feed in xdoc.Descendants("feed"))
            {
                foreach (var provider in feed.Elements())
                {
                    // Verifica se o feed está ativo
                    var feedIsActiveElement = provider.Element("isActive");
                    bool isFeedActive = feedIsActiveElement != null && bool.TryParse(feedIsActiveElement.Value, out var feedIsActive) && feedIsActive;
                    if (!isFeedActive) continue; // Pula feeds inativos

                    foreach (var theme in provider.Elements())
                    {
                        // Ignora o elemento <logoPath>
                        if (theme.Name.LocalName == "logoPath")
                            continue;

                        // Verifica se o tema está ativo
                        var themeIsActiveElement = theme.Element("isActive");
                        bool isThemeActive = themeIsActiveElement != null && bool.TryParse(themeIsActiveElement.Value, out var themeIsActive) && themeIsActive;
                        if (!isThemeActive) continue; // Pula temas inativos

                        var fonte = provider.Name.LocalName;
                        var url = theme.Element("url")?.Value;
                        var cor = theme.Element("color")?.Value ?? "RED"; // Default color

                        if (!IsvalidColor(cor))
                            cor = "RED";


                        if (!string.IsNullOrEmpty(url))
                        {
                            var feedInfo = new RssFeedInfo { Fonte = fonte, Url = url, Color = cor };
                            rssFeeds.Add(new Dictionary<string, RssFeedInfo> { { theme.Name.LocalName, feedInfo } });
                        }
                        
                    }
                }
            }
            return rssFeeds;
        }

        public bool IsvalidColor(string colorString)
        {
            // Remove the hash if it exists
            if (colorString.StartsWith("#"))
            {
                colorString = colorString.Substring(1);
            }

            // Try to convert the string to a known color
            try
            {
                ColorConverter converter = new ColorConverter();
                converter.ConvertFromString(colorString);
                return true;
            }
            catch
            {
                // The string is not a known color
            }

            // Try to parse the string as a hex color
            try
            {
                int argb = Int32.Parse(colorString, NumberStyles.HexNumber);
                Color color = Color.FromArgb(argb);
                return true;
            }
            catch
            {
                // The string is not a valid hex color
            }

            return false;
        }


        public void ConsultaCambio()
        {
            string strMoeda = "";
            string strUltimaAtualizacao = "Última cotação" + Environment.NewLine;

                try
                {
                    var exc = new JsonAwesomeApi();

                    WebRequest request = WebRequest.Create("https://economia.awesomeapi.com.br/json/last/USD-BRL,EUR-BRL");
                    WebResponse response = request.GetResponse();

                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        exc = JsonConvert.DeserializeObject<JsonAwesomeApi>(json);
                    }

                    if (string.IsNullOrEmpty(exc.usdbrl.code))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        strMoeda += $"Dólar: {Math.Round(exc.usdbrl.ask, 3)} | ";
                        strMoeda += $"Euro: {Math.Round(exc.eurbrl.ask, 3)}";
                        strUltimaAtualizacao += exc.usdbrl.create_date.ToString("dd/MM") + " às " + exc.usdbrl.create_date.ToString("HH:mm");
                    }

                    strUltimaAtualizacao = strUltimaAtualizacao.Replace("@", "h");

                    lbMoedaCentro.Text = strMoeda;
                }
                catch (Exception exBacen)
                {
                    lbMoedaCentro.Text = "Não foram encontrados registros na fonte atual";
                }
            
            }

            #region "Front-End"

            private void RoundButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            GraphicsPath Raduis = new GraphicsPath();
            Raduis.StartFigure();
            Raduis.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
            Raduis.AddLine(10, 0, btn.Width - 20, 0);
            Raduis.AddArc(new Rectangle(btn.Width - 20, 0, 20, 20), -90, 90);
            Raduis.AddLine(btn.Width, 20, btn.Width, btn.Height - 10);
            Raduis.AddArc(new Rectangle(btn.Width - 25, btn.Height - 25, 25, 25), 0, 90);
            Raduis.AddLine(btn.Width - 10, btn.Width, 20, btn.Height);
            Raduis.AddArc(new Rectangle(0, btn.Height - 20, 20, 20), 90, 90);
            Raduis.CloseFigure();
            btn.Region = new Region(Raduis);
        }
        private void RoundPanel(Panel pnl)
        {
            GraphicsPath Raduis = new GraphicsPath();
            Raduis.StartFigure();
            Raduis.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
            Raduis.AddLine(10, 0, pnl.Width - 20, 0);
            Raduis.AddArc(new Rectangle(pnl.Width - 20, 0, 20, 20), -90, 90);
            Raduis.AddLine(pnl.Width, 20, pnl.Width, pnl.Height - 10);
            Raduis.AddArc(new Rectangle(pnl.Width - 25, pnl.Height - 25, 25, 25), 0, 90);
            Raduis.AddLine(pnl.Width - 10, pnl.Width, 20, pnl.Height);
            Raduis.AddArc(new Rectangle(0, pnl.Height - 20, 20, 20), 90, 90);
            Raduis.CloseFigure();
            pnl.Region = new Region(Raduis);
        }

        private void PainelNoticias_Resize(object sender, EventArgs e)
        {
            float factorTitle = (float)this.Width / 57;
            float titleFontSize = Math.Max(15, factorTitle);
            lblTitulo.Font = new Font(lblTitulo.Font.FontFamily, titleFontSize, lblTitulo.Font.Style);

            float factorTopic = (float)this.Width / 62;
            float topicFontSize = Math.Max(15, factorTopic);
            btnTema.Height = (int)(factorTopic * 2);
            btnTema.Width = (int)(factorTopic * 10);
            RoundButton(btnTema);
            btnTema.Font = new Font(btnTema.Font.FontFamily, topicFontSize, btnTema.Font.Style);
            btnTema.ForeColor = Color.White;

            RoundPanel(pnlBarra);

            float factorEsquerda = (float)this.Width / 72;
            float EsquerdaFontSize = Math.Max(25, factorEsquerda);
            lbMoedaEsquerda.Font = new Font(lbMoedaEsquerda.Font.FontFamily, EsquerdaFontSize, lbMoedaEsquerda.Font.Style);

            float factorCentro = (float)this.Width / 82;
            float CentroFontSize = Math.Max(20, factorCentro);
            lbMoedaCentro.Font = new Font(lbMoedaCentro.Font.FontFamily, CentroFontSize, lbMoedaCentro.Font.Style);

        }
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            frmConfig configForm = new frmConfig(new XmlReaderService(), new ComboBoxService());

            // Define o evento que será executado quando o Form2 for fechado
            configForm.FormClosedEvent += ReniciarNoticias;

            configForm.ShowDialog();
        }
        private void ReniciarNoticias()
        {
            _currentNewsIndex = 0;
            _newsItems.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Deseja sair da aplicação?
            if (MessageBox.Show("Deseja sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void spotifyIcon_Click(object sender, EventArgs e)
        {
            Spotify.frmTokenGenerator spotify = new Spotify.frmTokenGenerator();
            spotify.Show();
        }
    }
}
