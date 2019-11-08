using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Items
{
    public class Float : Road
    {
        public Float(string name, int wear, int power, int price, Bitmap pic) : base(name, wear, power, price, pic)
        {
        }
    }
}
