using Fishing.BL.View;
using System;

namespace Fishing.View.Inventory
{
    public interface IInventory : IView
    {
        event EventHandler FLineSelectedIndexChanged;

        event EventHandler RoadSelectedIndexChanged;

        event EventHandler ReelSelectedIndexChanged;

        event EventHandler LureSelectedIndexChanged;

        event EventHandler FLineDoubleClick;

        event EventHandler RoadDoubleClick;

        event EventHandler ReelDoubleClick;

        event EventHandler LureDoubleClick;

        event EventHandler AssemblyDoubleClick;

        event EventHandler CloseButtonClick;

        event EventHandler FetchButtonClick;

        event EventHandler AddButtonClick;

        event EventHandler MakeOutClick;

        event EventHandler BaitPicClick;

        Road Road_P { get; set; }
        Reel Reel_P { get; set; }
        FLine FLine_P { get; set; }
        Lure Lure_P { get; set; }
        Fishing.Assembly Assembly_P { get; set; }

        string RoadText { get; set; }
        string ReelText { get; set; }
        string FLineText { get; set; }
        string LureText { get; set; }

        void addItemToRightView(Item item);

        void showAssembly(Fishing.Assembly ass);
    }
}