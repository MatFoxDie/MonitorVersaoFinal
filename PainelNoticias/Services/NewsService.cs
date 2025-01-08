using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using PainelNoticias.Interfaces;
using PainelNoticias.Models;
using static System.Windows.Forms.LinkLabel;

namespace PainelNoticias.Services
{
    public class NewsService : INewsService
    {
        private const int MaxRetryAttempts = 3;
        private const int RequestTimeoutSeconds = 5;

        public async Task<List<NewsItem>> GetNewsItemsAsync(string feedUrl, string tema)
        {
            var newsItems = new List<NewsItem>();
            var success = false;
            int retryCount = 0;

            while (!success && retryCount < MaxRetryAttempts)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                        client.Timeout = TimeSpan.FromSeconds(RequestTimeoutSeconds);
                        var response = await client.GetStringAsync(feedUrl);
                        response = RemoveDateTags(response);

                        if (!string.IsNullOrWhiteSpace(response))
                        {
                            Console.WriteLine("Received response from feed URL.");
                            newsItems = ParseRssFeed(response, tema);
                            success = true;
                        }
                    }
                }
                catch (HttpRequestException httpRequestException)
                {
                    Console.WriteLine($"Erro ao acessar o feed RSS: {httpRequestException.Message}");
                    retryCount++;
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Tempo limite da requisição expirado. Tentando novamente...");
                    retryCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                    retryCount++;
                }
            }

            if (!success)
            {
                Console.WriteLine($"Falha ao carregar o feed '{feedUrl}' após {MaxRetryAttempts} tentativas. Pulando para o próximo...");
            }

            return newsItems;
        }

        private List<NewsItem> ParseRssFeed(string response, string tema)
        {
            var items = new List<NewsItem>();
            try
            {
                using (var stringReader = new StringReader(response))
                using (var reader = XmlReader.Create(stringReader))
                {
                    var feed = SyndicationFeed.Load(reader);
                    if (feed != null)
                    {
                        items = feed.Items.Select(item => new NewsItem
                        {
                            Title = item.Title.Text,
                            Link = item.Links.FirstOrDefault()?.Uri.ToString(),
                            PublishDate = ParseDateTime(item.PublishDate.ToString()),
                            Description = GetDescription(item),
                            ImageUrl = GetImageUrl(item),
                            Tema = tema,
                            Cor = GetAccentColor(feed)
                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar o RSS: {ex.Message}");
            }
            return items;
        }

        private string RemoveDateTags(string rssContent)
        {
            try
            {
                var xdoc = XDocument.Parse(rssContent);
                xdoc.Descendants("lastBuildDate").FirstOrDefault()?.Remove();
                foreach (var pubDateElement in xdoc.Descendants("pubDate").ToList())
                {
                    pubDateElement.Remove();
                }
                return xdoc.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover as tags de data: {ex.Message}");
                return rssContent;
            }
        }

        private string GetDescription(SyndicationItem item)
        {
            return item.Summary?.Text ?? string.Empty;
        }

        private DateTime ParseDateTime(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var dateTime))
            {
                return dateTime;
            }
            return DateTime.MinValue;
        }

        private string GetImageUrl(SyndicationItem item)
        {
            var enclosureUrl = item.ElementExtensions
                .Where(x => x.OuterName == "enclosure")
                .Select(x => x.GetObject<XElement>().Attribute("url")?.Value)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(enclosureUrl)) return enclosureUrl;

            var mediaContentUrl = item.ElementExtensions
                .Where(x => x.OuterName == "media:content")
                .Select(x => x.GetObject<XElement>().Attribute("url")?.Value)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(mediaContentUrl))
                return mediaContentUrl;

            // Terceira tentativa: extrair imagem do item.Summary.Text
            if (!string.IsNullOrEmpty(item.Summary?.Text))
            {
                var summaryImageUrl = ExtractImageFromHtml(item.Summary.Text);
                if (!string.IsNullOrEmpty(summaryImageUrl))
                    return summaryImageUrl;
            }

            // Quarta tentativa: extrair imagem do <content:encoded>
            var contentEncoded = item.ElementExtensions
                .FirstOrDefault(x => x.OuterName == "content:encoded")
                ?.GetObject<string>();

            if (!string.IsNullOrEmpty(contentEncoded))
            {
                var contentImageUrl = ExtractImageFromHtml(contentEncoded);
                if (!string.IsNullOrEmpty(contentImageUrl))
                    return contentImageUrl;
            }

            return string.Empty;
        }

        // Método auxiliar para extrair a URL da imagem a partir de HTML
        private string ExtractImageFromHtml(string htmlContent)
        {
            try
            {
                var regex = new Regex("<img[^>]+src=[\"'](?<url>.+?)[\"'][^>]*>", RegexOptions.IgnoreCase);
                var match = regex.Match(htmlContent);
                if (match.Success)
                {
                    return match.Groups["url"].Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao extrair a imagem do HTML: {ex.Message}");
            }
            return string.Empty;
        }

        private string GetAccentColor(SyndicationFeed feed)
        {
            return feed.ElementExtensions
                .Where(ext => ext.OuterName == "accentColor" && ext.OuterNamespace == "http://webfeeds.org/rss/1.0")
                .Select(ext => ext.GetObject<XmlElement>().InnerText)
                .FirstOrDefault() ?? string.Empty;
        }
    }
}
