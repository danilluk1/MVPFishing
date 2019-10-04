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
        public Bitmap Image { get; set; }
        public EventHandler StopBaitTimer;
        public EventHandler GatheringisTrue;
        public int Widgth = 51;
        public int Height = 18;
        public int LabelStartY = 350;

        public LVL(Bitmap img)
        {
            Image = img;
            Deeparr = new Label[Widgth, Height];
        }

        public Label[,] Deeparr;
        protected List<Fish> Fishes = new List<Fish>(1000);
        public abstract void AddFishes();

        public abstract void GetFish();

        public abstract void SetDeep();

        public static bool IsFishAttackAbble(Fish fish)
        {
            try
            {
                var bait = fish.Lures.Single(b => b == Player.GetPlayer().Assembly.Lure.Size);
                bool ba = bait.ToString() == null ? false : true;
                return ba;
            }
            catch (InvalidOperationException){ return false; }
        }
        public void AddDeep()
        {
            for (int x = 0; x < Widgth; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this.Deeparr[x, y] = new Label()
                    {
                        Left = 5 + x * 20,
                        Top = LabelStartY + y * 20,
                        Height = 20,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = 20,
                        Visible = true,
                        Text = "1"
                    };
                }
            }
        }
    }
}
