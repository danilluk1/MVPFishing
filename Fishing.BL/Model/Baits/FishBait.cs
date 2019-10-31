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
        public FishBait(string name, int price, Bitmap pict) : base(name, price, pict)
        {
        }
    }
}
