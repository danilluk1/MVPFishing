using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fishing;
using Fishing.BL.View;

namespace Fishing.View.LVLS.Ozero
{
    public interface ILVL
    {
        Point CurPoint { get; set; }
        event EventHandler MouseLeftClick;
        event PaintEventHandler RepaintScreen;
        event EventHandler CountGathering;
        event EventHandler CountFishMoves;
        event KeyEventHandler KeyDOWN;
        event KeyEventHandler KeyUP;
        event EventHandler MainTimerTick;
        event EventHandler BaitTimerTick;
        event EventHandler FormClose;
        event EventHandler DecSacietyTimerTick;
    }
}
