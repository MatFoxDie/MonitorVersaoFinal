using MonitorVersaoFinal.Interfaces;
using MonitorVersaoFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MonitorVersaoFinal.Forms
{
    public partial class frmConfigPainel : Form
    {
        private readonly IXmlReaderService _xmlService;
        private readonly IComboBoxService _comboBoxService;
        private int IndiceFonte;
        private int IndiceTema;

        public frmConfigPainel(IXmlReaderService xmlService, IComboBoxService comboBoxService)
        {
            InitializeComponent();
            _xmlService = xmlService;
            _comboBoxService = comboBoxService;
            this.FormClosed += Form_FormClosed;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            _xmlService.LoadRssSources("rssFeeds.xml");
            _comboBoxService.PopulateComboBoxFontes(cbFontesRss, _xmlService.RssSources);
            DesativarTodosBotoesCombo(2);

            // Carregar configurações
            timerNoticia.Value = DateTime.Today.AddSeconds(_xmlService.RssConfiguracoes.TempoNoticia);
            timerAtualizarMoedas.Value = DateTime.Today.AddSeconds(_xmlService.RssConfiguracoes.TempoMoeda);
            timerAtualizarPainel.Value = DateTime.Today.AddSeconds(_xmlService.RssConfiguracoes.TempoPainel);
            timerAtualizarClima.Value = DateTime.Today.AddSeconds(_xmlService.RssConfiguracoes.TempoClima);
            checkBox1.Checked = _xmlService.RssConfiguracoes.Anuncio == 1;

            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            // Define a posição do formulário
            this.Location = new Point(x, y);
        }

        private void cbFontesRss_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndiceFonte = cbFontesRss.SelectedIndex;
            ValidacaoComboTemas();
            if (IndiceFonte != -1)
            {
                var selectedSource = _xmlService.RssSources[IndiceFonte];
                if (!string.IsNullOrEmpty(selectedSource.LogoPath))
                {
                    pbLogo.ImageLocation = selectedSource.LogoPath;
                }
                else
                {
                    pbLogo.Image = null;
                }
            }

        }

        private void ValidacaoComboTemas()
        {
            if (cbFontesRss.SelectedIndex == -1)
            {
                cbTemas.Items.Clear();
                txtUrl.Text = "";
                cbTemas.Enabled = false;
                return;
            }
            else
            {
                AtivarTodosBotoesCombo(2);
                cbTemas.Items.Clear();
                cbTemas.Enabled = true;
                btnCor.BackColor = SystemColors.Control;
                _comboBoxService.PopulateComboBoxTemas(cbTemas, txtUrl, _xmlService.RssSources[IndiceFonte], btnCor);
                _comboBoxService.AlterarEstadoAtivo(chkAtivoFonte, _xmlService.RssSources[IndiceFonte]); // Atualizar estado ativo da fonte
            }
        }

        private void cbTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndiceTema = cbTemas.SelectedIndex;

            _comboBoxService.AlterarValorURL(cbTemas, txtUrl, _xmlService.RssSources[IndiceFonte], btnCor);
            if (cbTemas.SelectedIndex != -1)
            {
                _comboBoxService.AlterarEstadoAtivo(chkAtivoTema, _xmlService.RssSources[IndiceFonte].RssSourceItem[IndiceTema]); // Atualizar estado ativo do tema
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se há fontes RSS carregadas
            if (_xmlService.RssSources == null || !_xmlService.RssSources.Any())
            {
                MessageBox.Show("Não há fontes RSS para salvar.");
                return;
            }

            try
            {
                _xmlService.SaveRssSources(_xmlService.RssSources);
                MessageBox.Show("RSS feeds salvos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os feeds RSS: {ex.Message}");
            }
        }

        private void btnCadastrarFontes_Click(object sender, EventArgs e)
        {
            SumirTodosBotoesCombo(3);
            btnCadastrarFontes.Enabled = false;
            cbFontesRss.Items.Clear();
            cbFontesRss.Text = "Digite a nova fonte a ser cadastrada...";
            cbTemas.Enabled = false;
            cbFontesRss.DropDownStyle = ComboBoxStyle.DropDown;

            AparecerTodosBotoesConfirmacao(1);
        }


        private void btnEditarFontes_Click(object sender, EventArgs e)
        {
            if (cbFontesRss.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma fonte para editar.");
                return;
            }
            IndiceFonte = cbFontesRss.SelectedIndex;
            SumirTodosBotoesCombo(3);
            chkAtivoFonte.Enabled = true;
            btnEditarFontes.Enabled = false;
            cbFontesRss.DropDownStyle = ComboBoxStyle.DropDown;
            cbFontesRss.Focus();
            cbFontesRss.SelectAll();
            cbTemas.Enabled = false;

            AparecerTodosBotoesConfirmacao(1);
        }

        private void btnDeletarFontes_Click(object sender, EventArgs e)
        {
            // Verifica se há uma fonte selecionada
            if (cbFontesRss.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione uma fonte para deletar.");
                return;
            }

            // Confirmação de exclusão
            var confirmResult = MessageBox.Show("Tem certeza que deseja deletar esta fonte?",
                                                "Confirmar Deleção",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            // Remove a fonte selecionada
            _xmlService.RssSources.RemoveAt(cbFontesRss.SelectedIndex);

            // Atualiza a ComboBox e a interface
            _comboBoxService.PopulateComboBoxFontes(cbFontesRss, _xmlService.RssSources);
            cbFontesRss.Text = "";
            cbTemas.Items.Clear();
            txtUrl.Text = "";

            MessageBox.Show("Fonte deletada com sucesso!");
        }


        private void btnConfirmarFonte_Click(object sender, EventArgs e)
        {
            if (btnCadastrarFontes.Enabled == false)
            {
                if (cbFontesRss.Text.Equals("Digite a nova fonte a ser cadastrada..."))
                {
                    MessageBox.Show("Digite uma fonte válida!");
                    return;
                }
                else
                {
                    _xmlService.RssSources.Add(new Models.RssSource { Name = cbFontesRss.Text });
                    _comboBoxService.PopulateComboBoxFontes(cbFontesRss, _xmlService.RssSources);
                    MessageBox.Show("Fonte cadastrada com sucesso!");
                    cbFontesRss.DropDownStyle = ComboBoxStyle.DropDownList;
                    chkAtivoFonte.Enabled = false;
                    cbTemas.Enabled = true;
                    AtivarTodosBotoesCombo(3);
                    AparecerTodosBotoesCombo(3);
                    SumirTodosBotoesConfirmacao(3);
                }
            }
            if (btnEditarFontes.Enabled == false)
            {
                var selectedSource = _xmlService.RssSources[IndiceFonte];
                selectedSource.Name = cbFontesRss.Text;

                _comboBoxService.PopulateComboBoxFontes(cbFontesRss, _xmlService.RssSources);
                MessageBox.Show("Fonte editada com sucesso!");
                cbFontesRss.DropDownStyle = ComboBoxStyle.DropDownList;
                chkAtivoFonte.Enabled = false;
                cbTemas.Enabled = true;
                AtivarTodosBotoesCombo(3);
                AparecerTodosBotoesCombo(3);
                SumirTodosBotoesConfirmacao(3);
            }
        }

        private void btnCancelarFonte_Click(object sender, EventArgs e)
        {
            AtivarTodosBotoesCombo(3);
            AparecerTodosBotoesCombo(3);
            SumirTodosBotoesConfirmacao(3);
            cbTemas.Enabled = true;
            chkAtivoFonte.Enabled = false;
            cbFontesRss.Text = "";
            cbFontesRss.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFontesRss.Items.Clear();
            cbTemas.Items.Clear();
            cbTemas.Text = "";
            txtUrl.Text = "";
            txtUrl.ReadOnly = true;
            txtUrl.BackColor = Color.Wheat;

            ValidacaoComboTemas();

            _comboBoxService.PopulateComboBoxFontes(cbFontesRss, _xmlService.RssSources);

        }

        private void btnCadastrarTemas_Click(object sender, EventArgs e)
        {
            if (cbFontesRss.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma fonte antes de adicionar um tema.");
                return;
            }

            SumirTodosBotoesCombo(3);
            btnCadastrarTemas.Enabled = false;
            cbTemas.Items.Clear();
            chkAtivoTema.Enabled = true;
            cbTemas.Text = "Digite o novo tema a ser cadastrado...";
            txtUrl.Text = "Digite a URL do tema";
            txtUrl.ReadOnly = false;
            txtUrl.BackColor = Color.White;

            AparecerTodosBotoesConfirmacao(2);
            cbTemas.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void btnConfirmarTema_Click(object sender, EventArgs e)
        {
            if (IndiceTema == -1 && btnEditarTemas.Enabled == false)
            {
                MessageBox.Show("Selecione um tema para editar.");
                return;
            }

            if (cbTemas.Text.Equals("Digite o novo tema a ser cadastrado...") || string.IsNullOrWhiteSpace(cbTemas.Text))
            {
                MessageBox.Show("Digite um tema válido!");
                return;
            }
            else
            {

                var selectedSource = _xmlService.RssSources[IndiceFonte];
                var selectedColor = ColorTranslator.ToHtml(btnCor.BackColor);

                if (btnCadastrarTemas.Enabled == false)
                {
                    
                    var newRssSourceItem = new RssSourceItem
                    {
                        Category = cbTemas.Text,
                        Url = txtUrl.Text,
                        Color = selectedColor
                    };

                    selectedSource.RssSourceItem.Add(newRssSourceItem);

                    txtUrl.ReadOnly = true;
                    txtUrl.BackColor = Color.Wheat;
                    
                    MessageBox.Show("Tema cadastrado com sucesso!");
                }
                else if (btnEditarTemas.Enabled == false)
                {
                    var selectedItem = selectedSource.RssSourceItem[IndiceTema];
                    selectedItem.Url = txtUrl.Text;
                    selectedItem.Color = selectedColor;
                    selectedItem.Category = cbTemas.Text;

                    txtUrl.ReadOnly = true;
                    txtUrl.BackColor = Color.Wheat;
                    MessageBox.Show("Tema editado com sucesso!");
                }

                
                _comboBoxService.PopulateComboBoxTemas(cbTemas, txtUrl, selectedSource, btnCor);

                AtivarTodosBotoesCombo(3);
                AparecerTodosBotoesCombo(3);
                SumirTodosBotoesConfirmacao(3);
                cbFontesRss.Enabled = true;
                chkAtivoTema.Enabled = false;
                btnCor.Enabled = false;
                cbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void btnEditarTemas_Click(object sender, EventArgs e)
        {
           
            // Verifica se há uma fonte selecionada
            if (cbFontesRss.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma fonte antes de editar um tema.");
                return;
            }
            IndiceTema = cbTemas.SelectedIndex;

            // Desativa os botões de ação e ativa os botões de confirmação
            SumirTodosBotoesCombo(3);
            btnEditarTemas.Enabled = false;
            AparecerTodosBotoesConfirmacao(2);

            // Permite a edição do texto do ComboBox de temas
            cbTemas.DropDownStyle = ComboBoxStyle.DropDown;
            chkAtivoTema.Enabled = true;
            txtUrl.Enabled = true;
            txtUrl.BackColor = Color.White;
            //Permite a edição da txtUrl
            txtUrl.ReadOnly = false;
            cbFontesRss.Enabled = false;
            cbTemas.Focus();
            cbTemas.SelectAll();
        }

        private void btnDeletarTemas_Click(object sender, EventArgs e)
        {
          
            // Verifica se há um tema selecionado
            if (cbTemas.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um tema para deletar.");
                return;
            }

            // Pede confirmação ao usuário
            var confirmResult = MessageBox.Show("Tem certeza que deseja deletar este tema?",
                                                 "Confirmação",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Recupera a fonte RSS selecionada
                var selectedSource = _xmlService.RssSources[cbFontesRss.SelectedIndex];

                // Remove o item de tema selecionado
                selectedSource.RssSourceItem.RemoveAt(cbTemas.SelectedIndex);

                // Atualiza o ComboBox de temas com os novos dados
                _comboBoxService.PopulateComboBoxTemas(cbTemas, txtUrl, selectedSource, btnCor);

                MessageBox.Show("Tema deletado com sucesso!");
            }
        }

        private void btnCancelarTema_Click(object sender, EventArgs e)
        {
            AtivarTodosBotoesCombo(3);
            AparecerTodosBotoesCombo(3);
            SumirTodosBotoesConfirmacao(3);
            cbFontesRss.Items.Clear();
            cbFontesRss.Text = "";
            cbFontesRss.Enabled = true;
            cbTemas.Items.Clear();
            cbTemas.Text = "";
            btnCor.Enabled = false;
            chkAtivoFonte.Enabled = false;
            chkAtivoTema.Enabled = false;
            cbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            txtUrl.Text = "";
            txtUrl.ReadOnly = true;
            txtUrl.BackColor = Color.Wheat;
            btnCor.BackColor = SystemColors.Control;
            _comboBoxService.PopulateComboBoxFontes(cbFontesRss, _xmlService.RssSources);
            cbFontesRss.SelectedIndex = IndiceFonte;
        }


        private void btnCor_Click(object sender, EventArgs e)
        {
            //Abre o colorpicker do windows para o usuario selecionar uma cor, dependendo se ele selecionar preenche o fundo do botão com a cor selecionada

            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnCor.BackColor = colorDialog.Color;
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void LimparCombos()
        {
            cbFontesRss.Items.Clear();
            cbTemas.Items.Clear();
        }
        private void SetButtonEnabledState(List<Button> buttons, bool state)
        {
            foreach (var button in buttons)
            {
                button.Enabled = state;
            }
        }

        private void SetButtonVisibility(List<Button> buttons, bool visibility)
        {
            foreach (var button in buttons)
            {
                button.Visible = visibility;
            }
        }

        private void AtivarTodosBotoesCombo(int opcao = 0)
        {
            var allButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes, btnCadastrarTemas, btnEditarTemas, btnDeletarTemas };
            var fonteButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes };
            var temaButtons = new List<Button> { btnCadastrarTemas, btnEditarTemas, btnDeletarTemas };

            if (opcao == 1)
            {
                SetButtonEnabledState(fonteButtons, true);
            }
            else if (opcao == 2)
            {
                SetButtonEnabledState(temaButtons, true);
                txtUrl.Text = "";
            }
            else
            {
                SetButtonEnabledState(allButtons, true);
            }
        }

        private void DesativarTodosBotoesCombo(int opcao = 0)
        {
            var allButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes, btnCadastrarTemas, btnEditarTemas, btnDeletarTemas, btnCor };
            var fonteButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes };
            var temaButtons = new List<Button> { btnCadastrarTemas, btnEditarTemas, btnDeletarTemas, btnCor };

            if (opcao == 1)
            {
                SetButtonEnabledState(fonteButtons, false);
            }
            else if (opcao == 2)
            {
                SetButtonEnabledState(temaButtons, false);
            }
            else
            {
                SetButtonEnabledState(allButtons, false);
            }
        }

        private void AparecerTodosBotoesCombo(int opcao = 0)
        {
            var allButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes, btnCadastrarTemas, btnEditarTemas, btnDeletarTemas };
            var fonteButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes };
            var temaButtons = new List<Button> { btnCadastrarTemas, btnEditarTemas, btnDeletarTemas };

            if (opcao == 1)
            {
                SetButtonVisibility(fonteButtons, true);
            }
            else if (opcao == 2)
            {
                SetButtonVisibility(temaButtons, true);
            }
            else
            {
                SetButtonVisibility(allButtons, true);
            }
        }

        private void SumirTodosBotoesCombo(int opcao = 0)
        {
            var allButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes, btnCadastrarTemas, btnEditarTemas, btnDeletarTemas, btnConfirmarFonte, btnCancelarFonte, btnCancelarTema, btnConfirmarTema };
            var fonteButtons = new List<Button> { btnCadastrarFontes, btnEditarFontes, btnDeletarFontes };
            var temaButtons = new List<Button> { btnCadastrarTemas, btnEditarTemas, btnDeletarTemas };

            if (opcao == 1)
            {
                SetButtonVisibility(fonteButtons, false);
            }
            else if (opcao == 2)
            {
                SetButtonVisibility(temaButtons, false);
            }
            else
            {
                SetButtonVisibility(allButtons, false);
            }
        }

        private void AparecerTodosBotoesConfirmacao(int opcao)
        {
            var fonteButtons = new List<Button> { btnConfirmarFonte, btnCancelarFonte };
            var temaButtons = new List<Button> { btnConfirmarTema, btnCancelarTema, btnCor };

            if (opcao == 1)
            {
                SetButtonVisibility(fonteButtons, true);
            }
            else if (opcao == 2)
            {
                SetButtonVisibility(temaButtons, true);
                SetButtonEnabledState(new List<Button> { btnCor }, true);
            }
            else
            {
                SetButtonVisibility(fonteButtons.Concat(temaButtons).ToList(), true);
            }
        }

        private void SumirTodosBotoesConfirmacao(int opcao)
        {
            var fonteButtons = new List<Button> { btnConfirmarFonte, btnCancelarFonte };
            var temaButtons = new List<Button> { btnConfirmarTema, btnCancelarTema };

            if (opcao == 1)
            {
                SetButtonVisibility(fonteButtons, false);
            }
            else if (opcao == 2)
            {
                SetButtonVisibility(temaButtons, false);
            }
            else
            {
                SetButtonVisibility(fonteButtons.Concat(temaButtons).ToList(), false);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkAtivoFonte_CheckedChanged(object sender, EventArgs e)
        {
            if (IndiceFonte == -1)
            {
                return;
            }

            _xmlService.RssSources[cbFontesRss.SelectedIndex].IsActive = chkAtivoFonte.Checked;
        }

        private void chkAtivoTema_CheckedChanged(object sender, EventArgs e)
        {
            if (IndiceTema == -1)
            {
                return;
            }
            try
            {
                var selectedSource = _xmlService.RssSources[cbFontesRss.SelectedIndex];
                var selectedTema = selectedSource.RssSourceItem[cbTemas.SelectedIndex];
                selectedTema.IsActive = chkAtivoTema.Checked;
            }catch
            {
            }
           
            
           
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedSource = _xmlService.RssSources[IndiceFonte];
                selectedSource.LogoPath = openFileDialog.FileName;
                pbLogo.ImageLocation = selectedSource.LogoPath;
            }
        }

        private void btnSalvarConfig_Click(object sender, EventArgs e)
        {
            // Validação para TempoNoticia
            if ((int)timerNoticia.Value.TimeOfDay.TotalSeconds < 30)
            {
                MessageBox.Show("O tempo para notícia não pode ser menor que 30 segundos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação para TempoMoeda
            if ((int)timerAtualizarMoedas.Value.TimeOfDay.TotalSeconds < 30)
            {
                MessageBox.Show("O tempo para atualização de moedas não pode ser menor que 30 segundos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação para TempoPainel
            if ((int)timerAtualizarPainel.Value.TimeOfDay.TotalSeconds < 30)
            {
                MessageBox.Show("O tempo para atualização do painel não pode ser menor que 30 segundos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Se todas as validações passarem, salva as configurações
            _xmlService.RssConfiguracoes.TempoNoticia = (int)timerNoticia.Value.TimeOfDay.TotalSeconds;
            _xmlService.RssConfiguracoes.TempoMoeda = (int)timerAtualizarMoedas.Value.TimeOfDay.TotalSeconds;
            _xmlService.RssConfiguracoes.TempoPainel = (int)timerAtualizarPainel.Value.TimeOfDay.TotalSeconds;
            _xmlService.RssConfiguracoes.Anuncio = checkBox1.Checked ? 1 : 0;

            try
            {
                _xmlService.SaveRssSources(_xmlService.RssSources);
                MessageBox.Show("Configurações salvas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        public event Action FormClosedEvent;

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Dispara o evento quando o formulário é fechado
            FormClosedEvent?.Invoke();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _xmlService.RssConfiguracoes.Anuncio = checkBox1.Checked ? 1 : 0;
        }
    }
}
