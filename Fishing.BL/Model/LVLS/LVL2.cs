using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    public class LVL2 : LVL
    {
        private static LVL2 lvl2;

        private LVL2()
        {

        }
        public static LVL2 getLVL()
        {
            if (lvl2 == null)
            {
                lvl2 = new LVL2();
            }

            return lvl2;
        }
        public override void AddFishes()
        {          
            for(int i = 0; i < 1000; i++)
            {
                if(i < 250)
                {
                    Fishes.Add(new Pike());
                }
                if (i > 250 && i < 450)
                {
                    Fishes.Add(new Perch());
                }
                if (i > 450 && i < 600)
                {
                    Fishes.Add(new ArcticChar());
                }
                if(i > 600 && i < 700)
                {
                    Fishes.Add(new Trout());
                }
                if (i > 700 && i < 800)
                {
                    Fishes.Add(new PinkSalmon());
                }
                if (i > 800 && i < 900)
                {
                    Fishes.Add(new Grayling());
                }
                if (i > 900 && i < 1000)
                {
                    Fishes.Add(new Salmon());
                }
            }
        }


        public override void GetFish()
        {
           Random randomGathering = new Random();
           Random randomFish = new Random();
                if((Player.getPlayer().Assembly.Lure is Wobbler || Player.getPlayer().Assembly.Lure is Iron) && Player.getPlayer().CurrentDeep > 350 )

                if (Player.getPlayer().CurPoint.Y > 400 && Player.getPlayer().CurPoint.Y < 800 && !Player.getPlayer().isFishAttack)
                {
                    Player.getPlayer().CFish = Fishes[randomFish.Next(1, 994)];
                    if (IsFishAttackAbble(Player.getPlayer().CFish) && Player.getPlayer().IsBaitMoving)
                    {
                        Player.getPlayer().isFishAttack = true;
                        Player.getPlayer().IncValue = Player.getPlayer().CFish.Weight * 20 / (Player.getPlayer().Assembly.Proad.Power);
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
            for (int x = 0; x < 51; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                }
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
                Deeparr[x, 14].Tag = 250;
                Deeparr[x, 15].Tag = 200;
                Deeparr[x, 16].Tag = 150;
                Deeparr[x, 17].Tag = 150;

            }
        }

    }
}
