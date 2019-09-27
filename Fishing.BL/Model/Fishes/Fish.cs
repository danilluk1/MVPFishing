using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public abstract class Fish
    {
        protected static Random randWigth = new Random();
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }
        public int TrophyWeight { get; set; }
        public HashSet<LureType> Lures { get; set; }
        public string Description { get; set; }
        

        public Fish(string name, int weight, int power, double price, int trophyWeight, HashSet<LureType> lures, string description)
        {
            this.Name = name;
            this.Weight = weight;
            this.Power = power;
            this.Price = price;
            this.TrophyWeight = trophyWeight;
            this.Lures = lures;
            this.Description = description;
        }

        public bool isTrophy()
        {
            bool res = Weight < TrophyWeight ? false : true;
            return res;
        }
        public override string ToString()
        {
            if (Weight / 1000 > 0)
            {
                return Name + " масса " + Weight / 1000 + "кг " + Weight % 1000 + "г";
            }
            else
            {
                return Name + " масса " + Weight + "г";
            }
        }
    }
}
