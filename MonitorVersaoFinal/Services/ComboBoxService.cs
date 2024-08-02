using MonitorVersaoFinal.Interfaces;
using MonitorVersaoFinal.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorVersaoFinal.Services
{
    public class ComboBoxService : IComboBoxService
    {
        public void PopulateComboBoxFontes(ComboBox combo, List<RssSource> rssSources)
        {
            combo.Items.Clear();
            foreach (var rssSource in rssSources)
            {
                combo.Items.Add(new ComboBoxItem(rssSource.Name, null));
            }
        }

        public void PopulateComboBoxTemas(ComboBox combo, TextBox text, RssSource rssSource, Button btnCor)
        {
            combo.Items.Clear();
            if (rssSource.RssSourceItem != null)
            {
                foreach (var tema in rssSource.RssSourceItem)
                {
                    combo.Items.Add(new ComboBoxItem(tema.Category, tema.Url));
                }
            }
            if (combo.SelectedItem is ComboBoxItem selectedItem)
            {
                var selectedTema = rssSource.RssSourceItem.FirstOrDefault(i => i.Category == selectedItem.DisplayValue);
                if (selectedTema != null)
                {
                    text.Text = selectedItem.HiddenValue;
                    text.ReadOnly = true;
                    btnCor.BackColor = ColorTranslator.FromHtml(selectedTema.Color);
                }
            }
        }

        public void AlterarValorURL(ComboBox combo, TextBox text, RssSource rssSource, Button btnCor)
        {
            if (combo.SelectedItem is ComboBoxItem selectedItem)
            {
                var selectedTema = rssSource.RssSourceItem.FirstOrDefault(i => i.Category == selectedItem.DisplayValue);
                if (selectedTema != null)
                {
                    text.Text = selectedItem.HiddenValue;
                    text.ReadOnly = true;
                    btnCor.BackColor = ColorTranslator.FromHtml(selectedTema.Color);
                }
            }
        }
        public void AlterarEstadoAtivo(CheckBox checkBox, RssSource rssSource)
        {
            checkBox.Checked = rssSource.IsActive;
        }

        public void AlterarEstadoAtivo(CheckBox checkBox, RssSourceItem rssSourceItem)
        {
            checkBox.Checked = rssSourceItem.IsActive;
        }

    }
}
