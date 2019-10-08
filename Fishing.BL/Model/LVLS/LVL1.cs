using Fishing.BL.Model.Fishes;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model
{
    public class LVL1 : LVL
    {
        private static LVL1 lvl;
        private LVL1() : base(Images.lvl1)
        {
            Widgth = 51;
            Height = 18;
            LabelStartY = 330;
        }
        public static LVL1 GetLVL()
        {
            if (lvl == null)
            {
                lvl = new LVL1();
            }

            return lvl;
        }
        public override void AddFishes()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i < 350)
                {
                    Fishes.Add(new Pike());
                }
                if (i > 350 && i < 750)
                {
                    Fishes.Add(new Perch());
                }
                if (i > 750 && i < 1000)
                {
                    Fishes.Add(new SnakeHead());
                }
            }
        }

        public override void GetFish()
        {
            Random randomGathering = new Random();
            Random randomFish = new Random();
            if (Player.GetPlayer().Assembly.Lure is Lure)
            {
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
        }

        public override void SetDeep()
        {
            for (int x = 0; x < 51; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                }
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
                Deeparr[x, 14].Tag = 100;
                Deeparr[x, 15].Tag = 100;
                Deeparr[x, 16].Tag = 100;
                Deeparr[x, 17].Tag = 100;

            }
        }
    }
}
