using MonitorVersaoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorVersaoFinal.Interfaces
{
    public interface IXmlReaderService
    {
        RssConfiguracoes RssConfiguracoes { get; set; }
        List<RssSource> RssSources { get; set; }
        void LoadRssSources(string filePath);
        void SaveRssSources(List<RssSource> RssSources);
        void GenerateDefaultConfigFile(string filePath);


    }
}
