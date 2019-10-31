using Fishing.BL.Model.Baits;
using Fishing.BL.Resources.Images;
using System.Collections.Generic;

namespace Fishing.BL.Model.LVLS.Ozero
{
    public class LVL2 : LVL
    {
        public LVL2() : base(Images.ozerolvl2, 50, 19, 0, 300)
        {
        }

        public override void AddFishes()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i < 250)
                {
                    Fishes.Add(new Pike(100, 400, 1, new HashSet<FishBait>() { Lure.jig4, Lure.jelezo1, Lure.vob2 }));
                }
                if (i >= 250 && i < 450)
                {
                    Fishes.Add(new Perch(100, 600, 1, new HashSet<FishBait>() { Lure.vert1, Lure.vert2 }));
                }
                if (i >= 450 && i < 600)
                {
                    Fishes.Add(new ArcticChar(350, 600, 1, new HashSet<FishBait>() { Lure.jelezo2, Lure.vert1, Lure.vert2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
                if (i >= 600 && i < 700)
                {
                    Fishes.Add(new Trout(350, 600, 1, new HashSet<FishBait>() { Lure.jelezo2, Lure.vert1, Lure.vert2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
                if (i >= 700 && i < 800)
                {
                    Fishes.Add(new PinkSalmon(350, 600, 0.5, new HashSet<FishBait>() { Lure.jelezo2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
                if (i >= 800 && i < 900)
                {
                    Fishes.Add(new Grayling(350, 600, 0.7, new HashSet<FishBait>() { Lure.vert1, Lure.vert2 }));
                }
                if (i >= 900 && i <= 1000)
                {
                    Fishes.Add(new Salmon(350, 600, 0.3, new HashSet<FishBait>() { Lure.jelezo2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
            }
        }

        public override void SetDeep()
        {
            for (int x = 0; x < Widgth; x++)
            {
                Deeparr[x, 0].Tag = 340;
                Deeparr[x, 1].Tag = 340;
                Deeparr[x, 2].Tag = 360;
                Deeparr[x, 3].Tag = 380;
                Deeparr[x, 4].Tag = 450;
                Deeparr[x, 5].Tag = 500;
                Deeparr[x, 6].Tag = 550;
                Deeparr[x, 7].Tag = 600;
                Deeparr[x, 8].Tag = 600;
                Deeparr[x, 9].Tag = 540;
                Deeparr[x, 10].Tag = 470;
                Deeparr[x, 11].Tag = 440;
                Deeparr[x, 12].Tag = 370;
                Deeparr[x, 13].Tag = 320;
                Deeparr[x, 14].Tag = 300;
                Deeparr[x, 15].Tag = 250;
                Deeparr[x, 16].Tag = 200;
                Deeparr[x, 17].Tag = 200;
                Deeparr[x, 18].Tag = 220;
            }
        }
    }
}