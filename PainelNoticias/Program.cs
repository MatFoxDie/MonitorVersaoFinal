using PainelNoticias.Interfaces;
using PainelNoticias.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainelNoticias
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            INewsService newsService = new NewsService();

            Application.Run(new PainelNoticias(newsService));
        }
    }
}
