using Fishing.BL.Model.Fishes;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.LVLS.Ozero
{
    public class LVL3 : LVL
    {
        public LVL3() : base(Images.lvl3)
        {
            Widgth = 51;
            Height = 20;
            LabelStartY = 350;
        }       
        public override void AddFishes()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i < 150)
                {
                    Fishes.Add(new Pike(100, 700, 0.5, new HashSet<Lure>() { Lure.jig4, Lure.vob2 }));
                }
                if (i >= 150 && i < 350)
                {
                    Fishes.Add(new Perch(100, 600, 0.8, new HashSet<Lure>() { Lure.vert1, Lure.vert2 }));
                }
                if(i >= 350 && i < 500)
                {
                    Fishes.Add(new Burbot(500, 700, 1, new HashSet<Lure>(){ Lure.jig2, Lure.jig3, Lure.vob6 }));
                }
                if (i >= 500 && i <= 1000)
                {
                    Fishes.Add(new Zander(500, 700, 1, new HashSet<Lure>() { Lure.jig1, Lure.vob5, Lure.vob6 }));
                }
            }
        }

        public override void SetDeep()
        {
            for (int x = 0; x < Widgth; x++)
            {
                Deeparr[x, 0].Tag = 400;
                Deeparr[x, 1].Tag = 400;
                Deeparr[x, 2].Tag = 400;
                Deeparr[x, 3].Tag = 420;
                Deeparr[x, 4].Tag = 460;
                Deeparr[x, 5].Tag = 500;
                Deeparr[x, 6].Tag = 550;
                Deeparr[x, 7].Tag = 700;
                Deeparr[x, 8].Tag = 700;
                Deeparr[x, 9].Tag = 700;
                Deeparr[x, 10].Tag = 700;
                Deeparr[x, 11].Tag = 650;
                Deeparr[x, 12].Tag = 600;
                Deeparr[x, 13].Tag = 550;
                Deeparr[x, 14].Tag = 500;
                Deeparr[x, 14].Tag = 500;
                Deeparr[x, 15].Tag = 500;
                Deeparr[x, 16].Tag = 560;
                Deeparr[x, 17].Tag = 590;
                Deeparr[x, 18].Tag = 600;
                Deeparr[x, 19].Tag = 600;

            }
        }
    }
}
