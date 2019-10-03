using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Game
{
    [Serializable]
    public class Statistic
    {
        public int GatheringCount { get; set; }
        public int BrokensRoadsCount { get; set; }
        public int TornsFLinesCount { get; set; }
        public int TakenFishesCount { get; set; }

        public Statistic()
        {

        }

    }
}
