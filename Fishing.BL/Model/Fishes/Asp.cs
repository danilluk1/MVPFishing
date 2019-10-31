using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing.BL.Model.Fishes
{
    [Serializable]
    public class Asp : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
            Size.Small,
            Size.Large,
        };

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Day
        };

        private readonly static string name = "Жерех";
        private readonly static int price = 4;
        private readonly static int trophyWeight = 7000;
        private readonly static string description = Messages.ASP_DESCRIPTION;
        private readonly static Bitmap bit = Images.zhereh;

        public Asp(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randWigth.Next(200, Convert.ToInt32(7000 * maxSizeCoef)), Power.SetPower(4, 2), price, trophyWeight, lures, activParts, description, bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}