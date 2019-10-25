using Fishing.BL.Resources.Images;
using System;

namespace Fishing.BL.Model.Waters
{
    [Serializable]
    public class Ozero : Water
    {
        private static Ozero water;

        public static Ozero GetWater()
        {
            if (water == null)
            {
                water = new Ozero();
            }
            return water;
        }

        private Ozero() : base("Озеро", Images.ozero1f, 0, 0)
        {
        }
    }
}