using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assesment4
{
    public static class Extensions
    {
        public static RadioButton SelectedRadioButton(this GroupBox g)
        {
            return g.Controls.OfType<RadioButton>().Where(rb => rb.Checked).FirstOrDefault();
        }
    }
}
