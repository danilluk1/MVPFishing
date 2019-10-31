using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    class Bait : Item
    {
        public int Count;

        public Bait(string name, int count, int price, Bitmap pic) : base(name, price, pic)
        {
            Count = count;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
