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
        public int Widgth;
        public int Height;
        public int LabelStartY;
        public int LabelStartX;
        public int MinDeep;
        public int MaxDeep;

        public LVL(Bitmap img, int w, int h, int labelX, int labelY)
        {
            Image = img;
            Widgth = w;
            Height = h;
            LabelStartY = labelY;
            LabelStartX = labelX;
            Deeparr = new Label[w, h];
        }

        public Label[,] Deeparr;
        protected List<Fish> Fishes = new List<Fish>(1000);

        public abstract void AddFishes();

        public (bool isFish, bool gathering) GetFish()
        {
            try
            {
                Random randomGathering = new Random();
                Random randomFish = new Random();
                if (Player.GetPlayer().EquipedRoad.Assembly.Lure is Lure)
                {
                    if (Player.GetPlayer().EquipedRoad.CurPoint.Y > Deeparr[0, 0].Location.Y && Player.GetPlayer().EquipedRoad.CurPoint.Y < 800 && !Player.GetPlayer().EquipedRoad.IsFishAttack)
                    {
                        Player.GetPlayer().EquipedRoad.Fish = Fishes[randomFish.Next(1, 994)];
                        if (IsFishAttackAbble(Player.GetPlayer().EquipedRoad.Fish))
                        {
                            Player.GetPlayer().EquipedRoad.IsFishAttack = true;
                            double roadCoef = Player.GetPlayer().EquipedRoad.Fish.Weight / (double)Player.GetPlayer().EquipedRoad.Assembly.Proad.Power;
                            double flineCoef = Player.GetPlayer().EquipedRoad.Fish.Weight / (double)Player.GetPlayer().EquipedRoad.Assembly.FLine.Power;
                            Player.GetPlayer().EquipedRoad.RoadIncValue = Convert.ToInt32(roadCoef * 100);
                            Player.GetPlayer().EquipedRoad.FLineIncValue = Convert.ToInt32(flineCoef * 100);
                            int Gathering = randomGathering.Next(1, 100);
                            if (Gathering <= 5)
                            {
                                return (true, true);
                            }
                            return (true, false);
                        }
                    }
                }
            }
            catch (NullReferenceException) { }

            return (false, false);
        }

        public abstract void SetDeep();

        public static bool IsFishAttackAbble(Fish fish)
        {
            try
            {
                bool ba = false;
                bool pa = false;
                if (fish.MinDeep <= Player.GetPlayer().EquipedRoad.CurrentDeep && fish.MaxDeep >= Player.GetPlayer().EquipedRoad.CurrentDeep)
                {
                    var part = fish.ActivityParts.Single(p => p == Game.GetGame().Time.Part);
                    var l = fish.WorkingLures.First(b => b.Name.Equals(Player.GetPlayer().EquipedRoad.Assembly.Lure.Name));
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