using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.View.FPond
{
    public interface IFPond
    {
        event EventHandler SelectedIndexChanged;
        event EventHandler SellButtonClick;
        Image RightImage { get; set; }
        int SelectedIndex { get; set; }
        string DescriptionText { get; set; }
    }
}
