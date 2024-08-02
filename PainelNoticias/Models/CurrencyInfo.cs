using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelNoticias.Models
{
    public class CurrencyInfo
    {
        public string code { get; set; }
        public double ask { get; set; }
        public DateTime create_date { get; set; }
    }
}
