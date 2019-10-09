using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.View.LureSelector.View
{
    public interface ISelector
    {
        Lure Lure { get; set; }
        Image Picture { get; set; }
        string DeepBoxText { get; set; }
        string SizeBoxText { get; set; }

        event EventHandler LureListIndexChanged;
        event EventHandler LureListDoubleClick;
    }
}
