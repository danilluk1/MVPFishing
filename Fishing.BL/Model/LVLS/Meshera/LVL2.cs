using Fishing.BL.Model.Fishes;
using Fishing.BL.Resources.Images;
using System.Collections.Generic;

namespace Fishing.BL.Model.LVLS.Meshera
{
    public class LVL2 : LVL
    {
        public LVL2() : base(Images.MesheraLVL2, 38, 16, 240, 345)
        {
        }

        public override void AddFishes()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i < 250)
                {
                    Fishes.Add(new Pike(180, 359, 0.8, new HashSet<Lure>() { Lure.jig4, Lure.jelezo1, Lure.vob2 }));
                }
                if (i >= 250 && i < 500)
                {
                    Fishes.Add(new Chub(180, 359, 0.3, new HashSet<Lure>() { Lure.vert1, Lure.vert2, Lure.vob3 }));
                }
                if (i >= 500 && i <= 750)
                {
                    Fishes.Add(new Perch(180, 350, 0.8, new HashSet<Lure>() { Lure.vert1, Lure.vert2 }));
                }
                if (i > 750 && i <= 1000)
                {
                    Fishes.Add(new Asp(180, 350, 0.3, new HashSet<Lure>() { Lure.vert1, Lure.vert2, Lure.vob3 }));
                }
            }
        }

        public override void SetDeep()
        {
            for (int x = 0; x < Widgth; x++)
            {
                Deeparr[x, 0].Tag = 350;
                Deeparr[x, 1].Tag = 330;
                Deeparr[x, 2].Tag = 290;
                Deeparr[x, 3].Tag = 290;
                Deeparr[x, 4].Tag = 290;
                Deeparr[x, 5].Tag = 290;
                Deeparr[x, 6].Tag = 270;
                Deeparr[x, 7].Tag = 270;
                Deeparr[x, 8].Tag = 270;
                Deeparr[x, 9].Tag = 240;
                Deeparr[x, 10].Tag = 220;
                Deeparr[x, 11].Tag = 240;
                Deeparr[x, 12].Tag = 170;
                Deeparr[x, 13].Tag = 140;
                Deeparr[x, 14].Tag = 140;
                Deeparr[x, 15].Tag = 120;
            }
        }
    }
}