using System;
using System.Collections.Generic;
using Fishing.BL.Resources.Messages;


namespace Fishing
{
    [Serializable]
    public class Salmon : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
          Size.XL,
          Size.Large,
        };
        private readonly static int power = 7;
        private readonly static string name = "Сёмга";
        private readonly static int price = 6;
        private readonly static int trophyWeight = 25000;
        private readonly static string description = Messages.SALMON_DESCRIPTION;
        public Salmon() : base(name, randWigth.Next(500, 30000), power, price, trophyWeight, lures, description)
        {

        }
    }
}
