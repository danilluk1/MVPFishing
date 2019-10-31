using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Items
{
    [Serializable]
    class Spinning : Road
    {
        public Spinning(string name, ROAD_TYPE type, int power, int price, Bitmap pic) : base(name, type, power, price, pic)
        {
        }
    }
}
