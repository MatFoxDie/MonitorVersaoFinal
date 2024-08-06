using MonitorVersaoFinal.Forms;
using MonitorVersaoFinal.Interfaces;
using MonitorVersaoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorVersaoFinal
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

            IXmlReaderService xmlReaderService = new XmlReaderService();
            IComboBoxService comboBoxService = new ComboBoxService();

            Application.Run(new frmConfigPainel(xmlReaderService, comboBoxService));

        }
    }
}
