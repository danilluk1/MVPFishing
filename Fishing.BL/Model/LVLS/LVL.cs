using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fishing
{
    public abstract class LVL
    {
        private readonly Player player = Player.GetPlayer();
        public Image Image { get; set; }
        public int Widgth;
        public int Height;
        public int LabelStartY;
        public int LabelStartX;
        public string Name { get; set; }

        public Label[,] Deeparr;
        protected List<Fish> Fishes = new List<Fish>(1000);

        public abstract void AddFishes();

        public (bool isFish, bool gathering) GetFish(GameRoad road)
        {
            try
            {
                Shuffle(Fishes);
                Random randRoad = new Random();
                Random randomGathering = new Random();
                Random randomFish = new Random();
                if (road.Assembly.FishBait != null)
                {
                    if (!road.IsFishAttack)
                    {
                        road.Fish = Fishes[randomFish.Next(1, 1000)];
                        if (IsFishAttackAbble(road.Fish, road))
                        {
                            road.IsFishAttack = true;
                            double roadCoef = road.Fish.Weight / (double)road.Assembly.Road.Power;
                            double flineCoef = road.Fish.Weight / (double)road.Assembly.FLine.Power;

                            road.RoadIncValue = Convert.ToInt32(roadCoef * 100);
                            road.FLineIncValue = Convert.ToInt32(flineCoef * 100);

                            int Gathering = randomGathering.Next(1, 100);
                            if (road.Assembly.Road is Spinning)
                            {
                                if (Gathering <= 5)
                                {
                                    return (true, true);
                                }
                            }
                            if (road.Assembly.Road is Feeder)
                            {
                                if (Gathering <= road.Assembly.Hook.GatheringChance)
                                {
                                    return (true, true);
                                }
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

        public static bool IsFishAttackAbble(Fish fish, GameRoad road)
        {
            try
            {
                bool ba = false;
                bool pa = false;
                if (fish.MinDeep <= road.CurrentDeep && fish.MaxDeep >= road.CurrentDeep)
                {
                    var part = fish.ActivityParts.First(p => p == Game.GetGame().Time.Part);
                    var l = fish.WorkingLures.First(b => b.Name.Equals(road.Assembly.FishBait.Name));
                    ba = l == null ? false : true;
                    pa = part.ToString() == null ? false : true;
                }
                return ba && pa;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}