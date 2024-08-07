using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MonitorVersaoFinal.Interfaces;
using MonitorVersaoFinal.Models;
using MonitorVersaoFinal.Properties;

namespace MonitorVersaoFinal.Services
{
    public class XmlReaderService : IXmlReaderService
    {
        public List<RssSource> RssSources { get; set; } = new List<RssSource>();
        public RssConfiguracoes RssConfiguracoes { get; set; } = new RssConfiguracoes();


        public void LoadRssSources(string filePath)
        {

            if (!System.IO.File.Exists(filePath))
            {
                GenerateDefaultConfigFile(filePath);
            }

            XDocument xdoc = XDocument.Load(filePath);
            var sources = new List<RssSource>();

            foreach (var item in xdoc.Descendants("feed"))
            {
                var feedElement = item.Elements().First();
                var source = new RssSource
                {
                    Name = feedElement.Name.LocalName,
                    IsActive = bool.Parse(feedElement.Element("isActive")?.Value ?? "true"),
                    LogoPath = feedElement.Element("logoPath")?.Value,
                    RssSourceItem = feedElement.Elements().Where(e => e.Name != "isActive" && e.Name != "logoPath")
                                        .Select(e => new RssSourceItem
                                        {
                                            Category = e.Name.LocalName,
                                            Url = e.Element("url")?.Value ?? "NULL",
                                            Color = e.Element("color")?.Value ?? "RED",
                                            IsActive = bool.Parse(e.Element("isActive")?.Value ?? "true")
                                        }).ToList()
                };
                sources.Add(source);
            }

            var configuracoesElement = xdoc.Descendants("Configuracoes").FirstOrDefault();
            if (configuracoesElement != null)
            {
                RssConfiguracoes = new RssConfiguracoes
                {
                    TempoNoticia = int.Parse(configuracoesElement.Element("tempoNoticia")?.Value ?? "30"),
                    TempoMoeda = int.Parse(configuracoesElement.Element("tempoMoeda")?.Value ?? "30"),
                    TempoPainel = int.Parse(configuracoesElement.Element("tempoPainel")?.Value ?? "30"),
                    TempoClima = int.Parse(configuracoesElement.Element("tempoClima")?.Value ?? "1800"),
                    Anuncio = int.Parse(configuracoesElement.Element("anuncio")?.Value ?? "0")

                };
            }

            RssSources = sources;
        }

        public void SaveRssSources(List<RssSource> RssSources)
        {
            var xdoc = new XDocument(
                new XElement("rssFeeds",
                    RssSources.Select(s => new XElement("feed",
                        new XElement(s.Name,
                            new XElement("isActive", s.IsActive),
                            new XElement("logoPath", s.LogoPath),
                            s.RssSourceItem.Select(f => new XElement(f.Category,
                                new XElement("url", f.Url),
                                new XElement("color", f.Color),
                                new XElement("isActive", f.IsActive)))))),
                    new XElement("Configuracoes",
                        new XElement("tempoNoticia", RssConfiguracoes.TempoNoticia),
                        new XElement("tempoMoeda", RssConfiguracoes.TempoMoeda),
                        new XElement("tempoPainel", RssConfiguracoes.TempoPainel),
                        new XElement("tempoClima", RssConfiguracoes.TempoClima),
                        new XElement("anuncio", RssConfiguracoes.Anuncio)))
                    
                );
                    

            xdoc.Save(Settings.XmlFilePath);
        }
        public void GenerateDefaultConfigFile(string filepath)
        {
            var defaultConfig = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("rssFeeds",
                new XElement("feed",
                    new XElement("G1",
                        new XElement("isActive", "true"),
                        new XElement("logoPath", ""),
                        new XElement("Noticias",
                            new XElement("url", "http://pox.globo.com/rss/g1/"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Economia",
                            new XElement("url", "http://pox.globo.com/rss/g1/economia/"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Ciencia",
                            new XElement("url", "http://pox.globo.com/rss/g1/ciencia-e-saude/"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Politica",
                            new XElement("url", "http://pox.globo.com/rss/g1/politica/"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        )
                    )
                ),
                new XElement("feed",
                    new XElement("R7",
                        new XElement("isActive", "true"),
                        new XElement("logoPath", ""),
                        new XElement("Noticias",
                            new XElement("url", "https://noticias.r7.com/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Politica",
                            new XElement("url", "https://noticias.r7.com/politica/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Educacao",
                            new XElement("url", "https://noticias.r7.com/educacao/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Economia",
                            new XElement("url", "https://noticias.r7.com/economia/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Ciencia",
                            new XElement("url", "https://noticias.r7.com/tecnologia-e-ciencia/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Esportes",
                            new XElement("url", "https://esportes.r7.com/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        )
                    )
                ),
                new XElement("feed",
                    new XElement("Gazeta",
                        new XElement("isActive", "true"),
                        new XElement("logoPath", ""),
                        new XElement("Economia",
                            new XElement("url", "https://www.gazetadopovo.com.br/feed/rss/economia.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Educacao",
                            new XElement("url", "https://www.gazetadopovo.com.br/feed/rss/educacao.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Politica",
                            new XElement("url", "https://www.gazetadopovo.com.br/feed/rss/republica.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        )
                    )
                ),
                new XElement("feed",
                    new XElement("Agencia",
                        new XElement("isActive", "true"),
                        new XElement("logoPath", ""),
                        new XElement("Noticias",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/rss/ultimasnoticias/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Educacao",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/rss/educacao/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Economia",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/rss/economia/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Esportes",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/rss/esportes/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Politica",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/rss/politica/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        )
                    )
                ),
                new XElement("feed",
                    new XElement("RadioAgencia",
                        new XElement("isActive", "true"),
                        new XElement("logoPath", ""),
                        new XElement("Noticias",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/radioagencia-nacional/rss/ultimasnoticias/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Educacao",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/radioagencia-nacional/rss/educacao/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Economia",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/radioagencia-nacional/rss/economia/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Ciencia",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/radioagencia-nacional/rss/pesquisa-e-inovacao/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Esportes",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/radioagencia-nacional/rss/esportes/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Politica",
                            new XElement("url", "https://agenciabrasil.ebc.com.br/radioagencia-nacional/rss/politica/feed.xml"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        )
                    )
                ),
                new XElement("feed",
                    new XElement("NoticiasMinuto",
                        new XElement("isActive", "true"),
                        new XElement("logoPath", ""),
                        new XElement("Noticias",
                            new XElement("url", "https://www.noticiasaominuto.com.br/rss/ultima-hora"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Politica",
                            new XElement("url", "https://www.noticiasaominuto.com.br/rss/politica"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Economia",
                            new XElement("url", "https://www.noticiasaominuto.com.br/rss/economia"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Ciencia",
                            new XElement("url", "https://www.noticiasaominuto.com.br/rss/tech"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        ),
                        new XElement("Esportes",
                            new XElement("url", "https://www.noticiasaominuto.com.br/rss/esporte"),
                            new XElement("color", "RED"),
                            new XElement("isActive", "true")
                        )
                    )
                ),
                new XElement("Configuracoes",
                    new XElement("tempoNoticia", "30"),
                    new XElement("tempoMoeda", "30"),
                    new XElement("tempoPainel", "30"),
                    new XElement("tempoClima", "0"),
                    new XElement("anuncio", "0")
                )
            )
        );
        
            defaultConfig.Save("rssFeeds.xml");

        }
    }
}
