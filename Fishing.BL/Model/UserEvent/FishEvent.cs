using Fishing.BL.Model.Lures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    class FishEvent : BaseEvent
    {
        public FishEvent(Fish f, Lure l) : base(Player.GetPlayer().NickName + " поймал " + f.ToString(), SelectIndex(l))
        {
        }

        static int SelectIndex(Lure l)
        {
            if (l is Wobbler)
            {
                return 4;
            }
            if (l is Shaker)
            {
                return 2;
            }
            if (l is Pinwheel)
            {
                return 3;
            }
            if (l is Jig)
            {
                return 6;
            }
            return 1;
        }
    }
}
