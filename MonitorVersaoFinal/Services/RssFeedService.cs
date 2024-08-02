using MonitorVersaoFinal.Interfaces;
using MonitorVersaoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonitorVersaoFinal.Services
{
    public class RssFeedService : IRssFeedService
    {
        private readonly HttpClient _httpClient;

        public RssFeedService()
        {
            _httpClient = new HttpClient();
        }

        public async void FetchRssFeeds(List<RssSource> sources)
        {
            foreach (var source in sources)
            {
                foreach (var feed in source.RssSourceItem)
                {
                    try
                    {

                       string content = await _httpClient.GetStringAsync(feed.Url);
                        // Processar o conteúdo do feed RSS
                        Console.WriteLine($"Categoria: {feed.Category}, URL: {feed.Url}");
                        Console.WriteLine(content);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao buscar feed RSS: {ex.Message}");
                    }
                }
  
            }
        }
    }
}

