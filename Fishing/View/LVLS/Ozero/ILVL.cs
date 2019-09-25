using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.View.LVLS.Ozero
{
    interface ILVL
    {
        Point CurPoint { get; set; }
        event EventHandler MouseLeftClick;
        event PaintEventHandler RepaintScreen;
        event EventHandler CountGathering;
        event EventHandler CountFishMoves;
        event KeyEventHandler KeyDOWN;
        event KeyEventHandler KeyUP;
        event EventHandler MainTimerTick;


    }
}
