using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game
{
    public class GameRoad
    {
        public GameRoad(Assembly ass)
        {
            Assembly = ass;
            baitTimer.Tick += BaitTimer_Tick;
            countFishMovesTimer.Tick += CountFishMovesTimer_Tick;
            gatheringTimer.Tick += GatheringTimer_Tick;
        }

        private void GatheringTimer_Tick(object sender, EventArgs e)
        {
            if (IsFishAttack)
            {
                IsFishAttack = false;
                Player.GetPlayer().Statistic.GatheringCount++;

                Image = Roads.road;
                FLineIncValue = 0;
                RoadIncValue = 0;

                gatheringTimer.Stop();
            }
        }

        private void CountFishMovesTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Random fishMovingX = new Random();
                Random fishMovingY = new Random();
                if (IsFishAttack)
                {
                    Fish.Power.X = fishMovingX.Next(-Fish.Power.X, Math.Abs(Fish.Power.X) + 1);
                    Fish.Power.Y = fishMovingY.Next(-Math.Abs(Fish.Power.Y), 2);
                }
            }
            catch (NullReferenceException) { }
        }

        private void BaitTimer_Tick(object sender, EventArgs e)
        {
            var (isFish, gathering) = CurLVL.GetFish(this);
            if (isFish)
            {
                if (Fish.Weight <= Assembly.Road.Power * 0.2)
                {
                    Image = Roads.izg1;
                }
                else if (Fish.Weight <= Assembly.Road.Power * 0.25)
                {
                    Image = Roads.izg2;
                }
                else if (Fish.Weight <= Assembly.Road.Power * 0.3)
                {
                    Image = Roads.izg3;
                }
                else if (Fish.Weight <= Assembly.Road.Power * 0.4)
                {
                    Image = Roads.izg4;
                }
                else if (Fish.Weight >= Assembly.Road.Power * 0.4)
                {
                    Image = Roads.izg5;
                }
                countFishMovesTimer.Start();
                if (gathering)
                {
                    gatheringTimer.Start();
                }
            }
        }

        public Timer baitTimer = new Timer()
        { 
            Interval = 5000,
        };
        public Timer countFishMovesTimer = new Timer()
        {
            Interval = 1500,
        };
        public Timer gatheringTimer = new Timer()
        {
            Interval = 1500,
        };

        public LVL CurLVL { get; set; }
        public Image Image { get; set; }
        public Assembly Assembly { get; set; }
        public Fish Fish { get; set; }

        public int RoadX = 100;
        public int RoadY = 350;

        public bool IsBaitMoving;
        public bool IsBaitInWater;
        public bool IsJigging;
        public bool IsFishAttack;

        public Point LastCastPoint;
        public Point CurPoint;

        public int CurrentDeep;
        public int RoadIncValue;
        public int FLineIncValue;
        public void StartBaitTimer()
        {
            if (IsBaitInWater)
            {
                baitTimer.Start();
            }
        }
    }
}
