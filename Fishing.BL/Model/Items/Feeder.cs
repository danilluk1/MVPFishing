﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Items
{
    [Serializable]
    public class Feeder : Road
    {
        public Feeder(string name, int wear, int power, int price, Bitmap pic) : base(name, wear, power, price, pic)
        {
        }
    }
}
