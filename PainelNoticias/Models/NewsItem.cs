using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelNoticias.Models
{
    public class NewsItem
    {
        public string Fonte { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public string Tema { get; set; }
        public string Cor { get; set; }
        public string Link { get; set; }
    }
}