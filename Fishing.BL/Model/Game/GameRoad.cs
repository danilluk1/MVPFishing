using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Game
{
    public class GameRoad
    {
        public GameRoad(Assembly ass)
        {
            Assembly = ass;
        }
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

        public override string ToString()
        {
            return Fish.ToString();
        }
    }
}
