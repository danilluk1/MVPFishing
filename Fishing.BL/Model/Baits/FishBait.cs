using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public abstract class FishBait : Item
    {
        public static List<FishBait> FishBaits = new List<FishBait>();
        public FishBait(string name, int price, Bitmap pict) : base(name, price, pict)
        {
        }

        public static FishBait GetFishBaitByName(string name)
        {
            return FishBaits.Find(b => b.Name == name);
        }
    }
}
