using Fishing.BL.Model.Fishes;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.LVLS.Ozero
{
    public class LVL1 : LVL
    {
        public LVL1() : base(Images.lvl1)
        {
            Widgth = 51;
            Height = 21;
            LabelStartY = 330;

        }
        public override void AddFishes()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i < 350)
                {
                    Fishes.Add(new Pike(0, 200, 0.4, new HashSet<Lure>() { Lure.jig4, Lure.jelezo1, Lure.vob2 }));
                }
                if (i > 350 && i < 750)
                {
                    Fishes.Add(new Perch(0, 200, 0.3, new HashSet<Lure>() { Lure.vert1, Lure.vert2 }));
                }
                if (i > 750 && i < 1000)
                {
                    Fishes.Add(new SnakeHead(0, 200, 1.5, new HashSet<Lure>() { Lure.jig4 }));
                }
            }
        }

        public override void SetDeep()
        {
            for (int x = 0; x < 51; x++)
            {
                Deeparr[x, 0].Tag = 120;
                Deeparr[x, 1].Tag = 100;
                Deeparr[x, 2].Tag = 100;
                Deeparr[x, 3].Tag = 130;
                Deeparr[x, 4].Tag = 140;
                Deeparr[x, 5].Tag = 180;
                Deeparr[x, 6].Tag = 180;
                Deeparr[x, 7].Tag = 180;
                Deeparr[x, 8].Tag = 180;
                Deeparr[x, 9].Tag = 180;
                Deeparr[x, 10].Tag = 150;
                Deeparr[x, 11].Tag = 140;
                Deeparr[x, 12].Tag = 130;
                Deeparr[x, 13].Tag = 130;
                Deeparr[x, 14].Tag = 140;
                Deeparr[x, 15].Tag = 120;
                Deeparr[x, 16].Tag = 110;
                Deeparr[x, 17].Tag = 100;
                Deeparr[x, 18].Tag = 100;
                Deeparr[x, 19].Tag = 100;
                Deeparr[x, 20].Tag = 100;
            }
        }
    }
}
