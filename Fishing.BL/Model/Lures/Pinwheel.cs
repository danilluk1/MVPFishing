using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Lures
{
    [Serializable]
    public sealed class Pinwheel : Lure
    {
        public Pinwheel(string name, Size s, DeepType type, int price, Bitmap pic) : base(name, s, type, price, pic)
        {
        }
    }
}
