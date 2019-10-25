using Fishing.BL.Model.Lures;
using System;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    public sealed class TrophyFishEvent : BaseEvent
    {
        private static Lure lure;

        public TrophyFishEvent(Fish f, Lure l) : base("Трофей! " + Player.GetPlayer().NickName + " поймал " + f.ToString(), SelectIndex())
        {
            lure = l;
        }

        private static int SelectIndex()
        {
            if (lure is Wobbler)
            {
                return 4;
            }
            if (lure is Shaker)
            {
                return 2;
            }
            if (lure is Pinwheel)
            {
                return 3;
            }
            if (lure is Jig)
            {
                return 6;
            }
            return 1;
        }
    }
}