using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.View;
using System;

namespace Fishing.View.Shop
{
    public interface IShop : IView
    {
        event EventHandler FLineDoubleClick;

        event EventHandler RoadDoubleClick;

        event EventHandler ReelDoubleClick;

        event EventHandler ProductDoubleClick;

        event EventHandler LureDoubleClick;

        event EventHandler CloseButtonClick;

        event EventHandler BaitDoubleClick;

        Road Road_P { get; set; }
        Reel Reel_P { get; set; }
        FLine FLine_P { get; set; }
        BaseFood Food_P { get; set; }
        Lure Lure_P { get; set; }
        Bait Bait_P { get; set; }
        string MoneyL { get; set; }
        string LowerL { get; set; }
    }
}