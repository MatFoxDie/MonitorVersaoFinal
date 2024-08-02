using MonitorVersaoFinal.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace PainelNoticias
{

    public class clsClimaTempo
    {
        private const string apiKey = "35254ed2";

        public Clima ConsultarClima(string cidade)
        {
            if (string.IsNullOrEmpty(cidade))
            {
                Console.WriteLine("Insira uma cidade");
                ResetarLabels();
                return null;
            }

            string url = $"https://api.hgbrasil.com/weather?key={apiKey}&city_name={cidade}";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    JObject jsonData = JObject.Parse(json);

                    int temperatura = jsonData.SelectToken("results.temp").ToObject<int>();
                    string descricaoClima = jsonData.SelectToken("results.description").ToString();
                    string cidadeNome = jsonData.SelectToken("results.city_name").ToString();
                    string clima = jsonData.SelectToken("results.condition_slug").ToString();

                    // Por padrão, a API quando consulta uma cidade inválida, ela traz a cidade São Paulo
                    // A lógica aqui é para bloquear essa entrada padrão, e trazer um alerta avisando sobre
                    if (cidadeNome == "São Paulo" && !cidade.ToLower().Equals("são paulo"))
                    {
                        Console.WriteLine("Cidade não encontrada. Insira uma cidade válida.");
                        ResetarLabels();
                        return null;
                    }

                    Clima returnClima = new Clima
                    {
                        Temperatura = temperatura,
                        DescricaoClima = descricaoClima,
                        CidadeNome = cidadeNome,
                        Image = FormatarImagem(clima)
                    };

                    return returnClima;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar o clima: {ex.Message}");
                return null;
            }
        }

        private void AtualizarLabels(int temperatura, string descricaoClima, string cidadeNome)
        {
            Console.WriteLine($"Temperatura: {temperatura} °C");
            Console.WriteLine($"Clima: {descricaoClima}");
            Console.WriteLine($"Cidade: {cidadeNome}");
        }

        private Image FormatarImagem(string clima)
        {
            // Alterar o caminho da pasta ao qual vai ser atribuída as imagens 
            string resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Clima\\");

            string imagePath = Path.Combine(resourcesPath, $"{clima}.png");

            if (!File.Exists(imagePath))
            {
                string[] files = Directory.GetFiles(resourcesPath);
                Console.WriteLine($"Imagem para o clima '{clima}' não encontrada. Arquivos disponíveis: {string.Join(", ", files)}");
                return null;
            }

            try
            {
                Image img = Image.FromFile(imagePath);
                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar a imagem: {ex.Message}");
                return null;
            }

        }

        private void ResetarLabels()
        {
            // Reseta as informações exibidas
            Console.WriteLine("Informações de clima resetadas.");
        }
    }

}
