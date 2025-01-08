using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PainelNoticias.Services
{
    public class GoogleApiService
    {
        public static async Task ExecuteMethod()
        {
            string apiKey = "AIzaSyB7DElpXeJdgXNg1lCtBNvLM7tSPdZ-pG8"; // Substitua pela sua chave de API
            string searchEngineId = "10e4426251f154e46"; // ID do mecanismo de busca fornecido
            string query = "gato imagem"; // Palavra para buscar a imagem

            string imageUrl = await GetImageFromGoogle(apiKey, searchEngineId, query);

            if (!string.IsNullOrEmpty(imageUrl))
            {
                Console.WriteLine($"Imagem encontrada: {imageUrl}");
            }
            else
            {
                Console.WriteLine("Nenhuma imagem encontrada.");
            }
        }

        static async Task<string> GetImageFromGoogle(string apiKey, string searchEngineId, string query)
        {
            string url = $"https://www.googleapis.com/customsearch/v1?q={query}&cx={searchEngineId}&key={apiKey}&searchType=image&exactTerms={query}&hq={query}&sort=relevance";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);

                    // Retorna a primeira imagem relevante
                    var imageLink = json["items"]?[0]?["link"]?.ToString();
                    return imageLink;
                }
            }

            return null;
        }
    }
}
