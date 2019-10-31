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
            var res = CurLVL.GetFish(this);
            if (res.isFish)
            {
                countFishMovesTimer.Start();
                if (res.gathering)
                {
                    
                }
                baitTimer.Stop();
            }
        }

        private Timer baitTimer = new Timer()
        { 
            Interval = 500,
        };
        private Timer countFishMovesTimer = new Timer()
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

        public void IncRoadCurPoint(int x, int y)
        {
            CurPoint.X += x;
            CurPoint.Y += y;
        }
        public void StartBaitTimer()
        {
            if (IsBaitInWater)
            {
                baitTimer.Start();
            }
        }
    }
}
