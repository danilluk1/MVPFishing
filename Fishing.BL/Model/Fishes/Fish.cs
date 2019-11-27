using Fishing.BL.Model;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public abstract class Fish {
        protected internal static Random randomWeight = new Random();
        public string Name { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public int TrophyWeight { get; set; }
        public HashSet<PartsOfDay> ActivityParts { get; set; }
        public HashSet<FishBait> WorkingLures { get; set; }
        public string Description { get; set; }
        public Bitmap Bitmap { get; set; }
        public int MaxDeep { get; set; }
        public int MinDeep { get; set; }
        public double MaxSizeCoef { get; set; }

        public Power Power;


        protected Fish(string name, int weight, Power power, double price, int trophyWeight, HashSet<PartsOfDay> activeParts, string description, Bitmap bit) {
            this.Name = name;
            this.Weight = weight;
            this.Power = power;
            this.Price = price;
            this.TrophyWeight = trophyWeight;
            this.Description = description;
            this.Bitmap = bit;
            this.ActivityParts = activeParts;
        }

        public bool IsTrophy() {
            bool res = Weight < TrophyWeight ? false : true;
            return res;
        }

        public override string ToString() {
            if (Weight / 1000 > 0) {
                return Name + " " + Weight / 1000 + "кг " + Weight % 1000 + "г";
            }
            else {
                return Name + " " + Weight + "г";
            }
        }

        public static explicit operator Fish(FishString fs) {
            return fs.GetFishByStr();
        }
    }
}