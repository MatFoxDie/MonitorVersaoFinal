using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using PainelNoticias.Interfaces;
using PainelNoticias.Models;

namespace PainelNoticias.Services
{
    public class NewsService : INewsService
    {
        public async Task<List<NewsItem>> GetNewsItemsAsync(string feedUrl, string tema)
        {
            var newsItems = new List<NewsItem>();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(feedUrl);
                    response = RemoveDateTags(response);
                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        Console.WriteLine("Received response from feed URL.");

                        using (var stringReader = new StringReader(response))
                        using (var reader = XmlReader.Create(stringReader))
                        {
                            if (reader != null && !reader.EOF)
                            {
                                var feed = SyndicationFeed.Load(reader);
                                if (feed != null)
                                {
                                    Console.WriteLine("Feed loaded successfully.");
                                    newsItems = feed.Items.Select(item => new NewsItem
                                    {
                                        Title = item.Title.Text,
                                        Link = item.Links.FirstOrDefault()?.Uri.ToString(),
                                        PublishDate = ParseDateTime(item.PublishDate.ToString()),
                                        Description = GetDescription(item),
                                        ImageUrl = GetImageUrl(item),
                                        Tema = tema,
                                        Cor = GetAccentColor(feed) // Garantir que a cor está sendo atribuída
                                    }).ToList();
                                }
                                else
                                {
                                    Console.WriteLine("Failed to load feed.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Reader is null or at the end of the file.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Received empty or whitespace response from feed URL.");
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine($"Erro ao acessar o feed RSS: {httpRequestException.Message}");
            }
            catch (XmlException xmlException)
            {
                Console.WriteLine($"Erro ao processar o feed RSS: {xmlException.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            return newsItems;
        }

        private string RemoveDateTags(string rssContent)
        {
            try
            {
                var xdoc = XDocument.Parse(rssContent);

                // Remove a tag <lastBuildDate>
                var lastBuildDateElement = xdoc.Descendants("lastBuildDate").FirstOrDefault();
                lastBuildDateElement?.Remove();

                // Remove todas as tags <pubDate>
                var pubDateElements = xdoc.Descendants("pubDate").ToList();
                foreach (var pubDateElement in pubDateElements)
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

            if (!string.IsNullOrEmpty(enclosureUrl))
            {
                return enclosureUrl;
            }

            var mediaContentUrl = item.ElementExtensions
                .Where(x => x.OuterName == "media:content")
                .Select(x => x.GetObject<XElement>().Attribute("url")?.Value)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(mediaContentUrl))
            {
                return mediaContentUrl;
            }

            var description = item.Summary?.Text;
            if (!string.IsNullOrEmpty(description))
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(description);
                var imgNode = doc.DocumentNode.SelectSingleNode("//img");
                if (imgNode != null)
                {
                    var imgSrc = imgNode.GetAttributeValue("src", string.Empty);
                    if (imgSrc.EndsWith(".jpg") || imgSrc.EndsWith(".jpeg") || imgSrc.EndsWith(".png"))
                    {
                        return imgSrc;
                    }
                }
            }

            var customImageUrl = item.ElementExtensions
                .Where(x => x.OuterName == "imagem-destaque")
                .Select(x => x.GetObject<XElement>().Value)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(customImageUrl))
            {
                return customImageUrl;
            }

            //Verifica o item.links para caso do rss noticias ao minuto

            // Verifica os links do item para imagens
            foreach (var link in item.Links)
            {
                var linkUri = link.Uri.ToString();
                if (linkUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    linkUri.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    linkUri.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    return linkUri;
                }
            }

            return item.ElementExtensions
            .Where(ext => ext.OuterName == "enclosure" && ext.OuterNamespace == "")
            .Select(ext => ext.GetObject<XmlElement>().GetAttribute("url"))
            .FirstOrDefault() ?? string.Empty;

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
