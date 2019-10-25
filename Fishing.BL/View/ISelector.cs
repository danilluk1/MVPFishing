using Fishing.BL.View;
using System;
using System.Drawing;

namespace Fishing.View.LureSelector.View
{
    public interface ISelector : IView
    {
        Lure Lure { get; set; }
        Image Picture { get; set; }
        string DeepBoxText { get; set; }
        string SizeBoxText { get; set; }

        event EventHandler LureListIndexChanged;

        event EventHandler LureListDoubleClick;
    }
}