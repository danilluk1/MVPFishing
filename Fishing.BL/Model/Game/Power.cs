using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Game
{
    [Serializable]
    public struct Power
    {
        public int X;
        public int Y;

        public static Power SetPower(int x, int y)
        {
            Power power = new Power();
            power.X = x;
            power.Y = y;

            return power;            
        }
    }
}
