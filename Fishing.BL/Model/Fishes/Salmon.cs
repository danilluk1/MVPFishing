using System;
using System.Collections.Generic;
using System.Drawing;
using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
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
        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };
        private readonly static int power = 7;
        private readonly static string name = "Сёмга";
        private readonly static int price = 6;
        private readonly static int trophyWeight = 25000;
        private readonly static string description = Messages.SALMON_DESCRIPTION;
        private readonly static Bitmap bit = Images.semga;
        public Salmon(int minD, int maxD, double maxSizeCoef, HashSet<Lure> lu) : base(name, randWigth.Next(500, 30000), power, price, trophyWeight, lures, activParts, description,bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}
