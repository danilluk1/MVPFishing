using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    public class LVL2 : LVL
    {
        private static LVL2 lvl;
        
        private LVL2() : base(Images.ozerolvl2)
        {
            Widgth = 51;
            Height = 21;
            LabelStartY = 330;
        }
        public static LVL2 GetLVL()
        {
            if (lvl == null)
            {
                lvl = new LVL2();
            }

            return lvl;
        }
        public override void AddFishes()
        {          
            for(int i = 0; i < 1000; i++)
            {
                if(i < 250)
                {
                    Fishes.Add(new Pike(100, 400, 1, new HashSet<Lure>() { Lure.jig4, Lure.jelezo1, Lure.vob2 }));
                }
                if (i > 250 && i < 450)
                {
                    Fishes.Add(new Perch(100, 600, 1, new HashSet<Lure>() {Lure.vert1, Lure.vert2 }));
                }
                if (i > 450 && i < 600)
                {
                    Fishes.Add(new ArcticChar(350, 600, 1, new HashSet<Lure>() {Lure.jelezo2, Lure.vert1, Lure.vert2, Lure.vob5, Lure.vob6 , Lure.vob1}));
                }
                if(i > 600 && i < 700)
                {
                    Fishes.Add(new Trout(350, 600, 1, new HashSet<Lure>() { Lure.jelezo2, Lure.vert1, Lure.vert2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
                if (i > 700 && i < 800)
                {
                    Fishes.Add(new PinkSalmon(350, 600, 0.5, new HashSet<Lure>() { Lure.jelezo2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
                if (i > 800 && i < 900)
                {
                    Fishes.Add(new Grayling(350, 600, 0.7, new HashSet<Lure>() { Lure.vert1, Lure.vert2 }));
                }
                if (i > 900 && i < 1000)
                {
                    Fishes.Add(new Salmon(350, 600, 0.3, new HashSet<Lure>() { Lure.jelezo2, Lure.vob5, Lure.vob6, Lure.vob1 }));
                }
            }
        }


        public override void GetFish()
        {
           Random randomGathering = new Random();
           Random randomFish = new Random();
                if((Player.GetPlayer().Assembly.Lure is Lure) && Player.GetPlayer().CurrentDeep > 350 )

                if (Player.GetPlayer().CurPoint.Y > lvl.Deeparr[0, 0].Location.Y && Player.GetPlayer().CurPoint.Y < 800 && !Player.GetPlayer().isFishAttack)
                {
                    Player.GetPlayer().CFish = Fishes[randomFish.Next(1, 994)];
                    if (IsFishAttackAbble(Player.GetPlayer().CFish) && Player.GetPlayer().IsBaitMoving)
                    {
                        Player.GetPlayer().isFishAttack = true;
                        Player.GetPlayer().IncValue = Player.GetPlayer().CFish.Weight * 20 / (Player.GetPlayer().Assembly.Proad.Power);
                        StopBaitTimer?.Invoke(this, EventArgs.Empty);
                        int Gathering = randomGathering.Next(1, 100);
                        if (Gathering <= 5)
                        {
                            GatheringisTrue?.Invoke(this, EventArgs.Empty);
                        }
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
                Deeparr[x, 19].Tag = 230;
                Deeparr[x, 20].Tag = 240;
            }
        }

    }
}
