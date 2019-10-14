using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Fishing.BL;
using Fishing.BL.Model.Game;

namespace Fishing
{
    public abstract class LVL
    {
        public Bitmap Image { get; set; }
        public EventHandler StopBaitTimer;
        public EventHandler GatheringisTrue;
        public int Widgth = 100;
        public int Height = 25;
        public int LabelStartY = 350;
        public int LabelStartX = 0;
        public int MinDeep;
        public int MaxDeep;

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
                bool ba = false;
                bool pa = false;
                if (fish.MinDeep <= Player.GetPlayer().CurrentDeep && fish.MaxDeep >= Player.GetPlayer().CurrentDeep)
                {
                    var part = fish.ActivityParts.Single(p => p == Game.GetGame().Time.Part);
                    var l = fish.WorkingLures.First(b => b.Name.Equals(Player.GetPlayer().Assembly.Lure.Name));
                    ba = l.Name == null ? false : true;
                    pa = part.ToString() == null ? false : true;
                }
                return ba && pa;
            }
            catch (InvalidOperationException){              
                return false;
            }
        }
        public void AddDeep()
        {
            for (int x = 0; x < Widgth; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this.Deeparr[x, y] = new Label()
                    {
                        Left = LabelStartX + 5 + x * 20,
                        Top = LabelStartY + y * 15,
                        Height = 15,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Width = 20,
                        Visible = true,
                        Font = new Font("Arial", 6, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                }
            }
        }
    }
}
