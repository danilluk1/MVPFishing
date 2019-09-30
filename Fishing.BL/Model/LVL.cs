using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Fishing.BL;

namespace Fishing
{
    public abstract class LVL
    {    
        public static LVL2 lvl2 = new LVL2();
        public static Label[,] Deeparr = new Label[51, 18];
        protected List<Fish> fishes = new List<Fish>(1000);
        public abstract void addFishes();

        public abstract void getFish();

        public abstract void SetDeep();

        public static bool IsFishAttackAbble(Fish fish)
        {
            try
            {
                var bait = fish.Lures.Single(b => b == Player.getPlayer().Assembly.Lure.Type);
                bool ba = bait.ToString() == null ? false : true;
                return ba;
            }
            catch (InvalidOperationException){ return false; }
        }
    }
}
