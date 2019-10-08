using Fishing.BL.Model.Eating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.View.Shop
{
    public interface IShop
    {
        event EventHandler FLineSelectedIndexChanged;
        event EventHandler RoadSelectedIndexChanged;
        event EventHandler ReelSelectedIndexChanged;
        event EventHandler ProductSelectedIndexChanged;

        event EventHandler FLineDoubleClick;
        event EventHandler RoadDoubleClick;
        event EventHandler ReelDoubleClick;
        event EventHandler ProductDoubleClick;

        event EventHandler CloseButtonClick;

        Road Road_P { get; set; }
        Reel Reel_P { get; set; }
        FLine FLine_P { get; set; }
        BaseFood Food_P { get; set; }
        string MoneyL { get; set; }
        string LowerL { get; set; }

    }
}
