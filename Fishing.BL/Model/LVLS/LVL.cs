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
        public EventHandler StopBaitTimer;
        public EventHandler GatheringisTrue;

        public Label[,] Deeparr = new Label[51, 18];
        protected List<Fish> Fishes = new List<Fish>(1000);
        public abstract void AddFishes();

        public abstract void GetFish();

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
        public void AddDeep()
        {
            for (int x = 0; x < 51; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                    this.Deeparr[x, y] = new Label()
                    {
                        Left = 5 + x * 20,
                        Top = 350 + y * 20,
                        Height = 20,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = 20,
                        Visible = false,
                    };
                }
            }
        }
    }
}
