using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Fishes;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.LVLS.Ozero
{
    public class LVL4 : LVL
    {
        public LVL4() : base(Images.lvl4, 50, 25, 0, 200)
        {
        }

        public override void AddFishes()
        {
            for (int i = 0; i < 1000; i++)
            {
                if(i < 50)
                {
                    Fishes.Add(new Pike(100, 250, 0.05, new HashSet<FishBait>() { Bait.livebait, Lure.jig4, Lure.jelezo1, Lure.vob2 }));
                }
                if (i >= 50 && i < 100)
                {
                    Fishes.Add(new Zander(250, 400, 0.02, new HashSet<FishBait>() { Bait.livebait, Lure.jig1, Lure.vob5, Lure.vob6 }));
                }
                if(i > 100 && i < 200)
                {
                    Fishes.Add(new WildCarp(300, 400, 0.2, new HashSet<FishBait>() { Bait.corn }));
                }
                if (i >= 200 && i < 350)
                {
                    Fishes.Add(new GoldCarp(250, 400, 0.2, new HashSet<FishBait>() { Bait.worm, Bait.corn, Bait.barley }));
                }
                if (i >= 350 && i < 450)
                {
                    Fishes.Add(new Tench(350, 400, 0.1, new HashSet<FishBait>() { Bait.cheese, Bait.caviar }));
                }
                if (i >= 450 && i < 550)
                {
                    Fishes.Add(new Scavenger(350, 400, 0.3, new HashSet<FishBait>() { Bait.barley, Bait.cheese}));
                }
                if (i >= 550 && i < 750)
                {
                    Fishes.Add(new Bream(350, 400, 0.2, new HashSet<FishBait>() { Bait.corn, Bait.cheese }));
                }
                if (i >= 750 && i <= 1000)
                {
                    Fishes.Add(new SilverCarp(250, 400, 0.2, new HashSet<FishBait>() { Bait.worm, Bait.corn, Bait.barley }));
                }
            }
        }

        public override void SetDeep()
        {
            for (int x = 0; x < Widgth; x++)
            {
                Deeparr[x, 0].Tag = 120;
                Deeparr[x, 1].Tag = 150;
                Deeparr[x, 2].Tag = 200;
                Deeparr[x, 3].Tag = 250;
                Deeparr[x, 4].Tag = 350;
                Deeparr[x, 5].Tag = 400;
                Deeparr[x, 6].Tag = 400;
                Deeparr[x, 7].Tag = 400;
                Deeparr[x, 8].Tag = 400;
                Deeparr[x, 9].Tag = 400;
                Deeparr[x, 10].Tag = 250;
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
                Deeparr[x, 21].Tag = 100;
                Deeparr[x, 22].Tag = 100;
                Deeparr[x, 23].Tag = 100;
                Deeparr[x, 24].Tag = 100;
            }
        }
    }
}
