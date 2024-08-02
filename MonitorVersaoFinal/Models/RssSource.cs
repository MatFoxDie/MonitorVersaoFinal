using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorVersaoFinal.Models
{
    public class RssSource
    {
        public string Name { get; set; }
        public List<RssSourceItem> RssSourceItem { get; set; }
        public bool IsActive { get; set; }
        public string LogoPath { get; set; }
    }
}
