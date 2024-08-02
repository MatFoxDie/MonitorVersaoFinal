using MonitorVersaoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorVersaoFinal.Interfaces
{
    public interface IComboBoxService
    {
        void PopulateComboBoxFontes(ComboBox combo, List<RssSource> rssSources);
        void PopulateComboBoxTemas(ComboBox combo, TextBox text, RssSource rssSource, Button btnCor);
        void AlterarValorURL(ComboBox combo, TextBox text, RssSource rssSource, Button btnCor);
        void AlterarEstadoAtivo(CheckBox checkBox, RssSource rssSource);
        void AlterarEstadoAtivo(CheckBox checkBox, RssSourceItem rssSourceItem); 
    }
}

