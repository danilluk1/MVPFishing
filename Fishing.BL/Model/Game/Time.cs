using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Game
{
    [Serializable]
    public struct Time
    {
        public int Hours { get; set; }
        public PartsOfDay Part { get; set; }
        public DayOfWeek Day { get; set; }

        public override string ToString()
        {
            return Day + ", " + Part + ", " + Hours + ":00";
        }
    }
}
