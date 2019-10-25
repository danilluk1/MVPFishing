using System;
using System.Drawing;

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