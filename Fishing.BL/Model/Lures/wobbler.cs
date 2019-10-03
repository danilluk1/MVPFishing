using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public sealed class Wobbler : Lure
    {
        public Wobbler(string name, Size s, DeepType type, int price, Bitmap pic) : base (name, s, type, price, pic)
        {
        }
    }
}
