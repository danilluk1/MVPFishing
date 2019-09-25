using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public sealed class Iron : Lure
    {
        public Iron(string name, LureType type, int count, int price, Bitmap pic) : base(name, type, count, price, pic)
        {
        }
    }
}
