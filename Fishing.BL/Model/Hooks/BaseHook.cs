using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Hooks
{
    [Serializable]
    public abstract class BaseHook : Item
    {
        public int GatheringChance { get; }
        public BaseHook(string name,int gathch, int price, Bitmap bit) : base(name, price, bit)
        {
            GatheringChance = gathch;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
