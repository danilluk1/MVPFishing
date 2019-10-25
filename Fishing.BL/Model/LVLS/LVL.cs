using Fishing.BL.Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        public void GetFish()
        {
            Random randomGathering = new Random();
            Random randomFish = new Random();
            if (Player.GetPlayer().Assembly.Lure is Lure)
            {
                if (Player.GetPlayer().CurPoint.Y > Deeparr[0, 0].Location.Y && Player.GetPlayer().CurPoint.Y < 800 && !Player.GetPlayer().isFishAttack)
                {
                    Player.GetPlayer().CFish = Fishes[randomFish.Next(1, 994)];
                    if (IsFishAttackAbble(Player.GetPlayer().CFish))
                    {
                        Player.GetPlayer().isFishAttack = true;
                        double roadCoef = (double)Player.GetPlayer().CFish.Weight / (double)Player.GetPlayer().Assembly.Proad.Power;
                        double flineCoef = (double)Player.GetPlayer().CFish.Weight / (double)Player.GetPlayer().Assembly.FLine.Power;
                        Player.GetPlayer().RoadIncValue = Convert.ToInt32(roadCoef * 100);
                        Player.GetPlayer().FLineIncValue = Convert.ToInt32(flineCoef * 100);
                        StopBaitTimer?.Invoke(this, EventArgs.Empty);
                        int Gathering = randomGathering.Next(1, 100);
                        if (Gathering <= 5)
                        {
                            GatheringisTrue?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }

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
            catch (InvalidOperationException)
            {
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