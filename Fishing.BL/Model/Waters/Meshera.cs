using Fishing.BL.Resources.Images;
using System;

namespace Fishing.BL.Model.Waters
{
    [Serializable]
    public class Meshera : Water
    {
        private static Meshera water;

        private Meshera() : base("Мещёра", Images.MesheraMap, 1200, 1600)
        {
        }

        public static Meshera GetWater()
        {
            if (water == null)
            {
                water = new Meshera();
            }
            return water;
        }
    }
}