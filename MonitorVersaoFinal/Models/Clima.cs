using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorVersaoFinal.Models
{
    public class Clima
    { 
        public int Temperatura { get; set; }
        public string DescricaoClima { get; set; }
        public string CidadeNome { get; set; }
        public Image Image { get; set; }
    }
}
