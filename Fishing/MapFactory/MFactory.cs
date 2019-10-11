using Fishing.BL.Model.Waters;
using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.MapFactory
{
    class MFactory
    {
        Water water;
        public MFactory( Water w)
        {
            water = w;
        }

        public void CreateMap()
        {
            if (water is Meshera)
            {
                MesheraMap map = new MesheraMap();
                map.Show();
            }
            if (water is Ozero)
            {
                Map map = new Map();
                map.Show();
            }
        }
    }
}
