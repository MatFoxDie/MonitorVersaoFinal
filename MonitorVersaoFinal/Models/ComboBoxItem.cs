using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorVersaoFinal.Models
{
    public class ComboBoxItem
    {
        public string DisplayValue { get; set; }
        public string HiddenValue { get; set; }

        public ComboBoxItem(string displayValue, string hiddenValue)
        {
            DisplayValue = displayValue;
            HiddenValue = hiddenValue;
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}
