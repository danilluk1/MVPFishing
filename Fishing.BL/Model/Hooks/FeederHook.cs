using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Hooks
{
    [Serializable]
    public class FeederHook : BaseHook
    {
        public FeederHook(string name, int gathch, int price, Bitmap bit) : base(name, gathch, price, bit)
        {
        }
    }
}
