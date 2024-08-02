using PainelNoticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelNoticias.Interfaces
{
    public interface INewsService
    {
        Task<List<NewsItem>> GetNewsItemsAsync(string feedUrl, string tema);
    }
}
