using Fishing.BL.Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Drawer
{
    class Drawer
    {
        private Graphics graphic;

        private Player player = Player.GetPlayer();
        private SolidBrush sbrush = new SolidBrush(Color.White);

        public Rectangle FirstNormalRoad;
        public Rectangle FirstBrokenRoad;

        public Rectangle SecondNormalRoad;
        public Rectangle SecondBrokenRoad;

        public Rectangle ThirdNormalRoad;
        public Rectangle ThirdBrokenRoad;

        Rectangle Netting;
        public Rectangle RTrigon;

        public Drawer(Graphics g)
        {
            graphic = g;
        }

        public void DrawPoints()
        {
            if (player.FirstRoad != null)
            {
                graphic.DrawEllipse(new Pen(sbrush), player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
                graphic.FillEllipse(sbrush, player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
            }

            if (player.SecondRoad != null)
            {
                graphic.DrawEllipse(new Pen(sbrush), player.SecondRoad.CurPoint.X, player.SecondRoad.CurPoint.Y, 4, 4);
                graphic.FillEllipse(sbrush, player.SecondRoad.CurPoint.X, player.SecondRoad.CurPoint.Y, 4, 4);
            }
            if (player.ThirdRoad != null)
            {
                graphic.DrawEllipse(new Pen(sbrush), player.ThirdRoad.CurPoint.X, player.ThirdRoad.CurPoint.Y, 4, 4);
                graphic.FillEllipse(sbrush, player.ThirdRoad.CurPoint.X, player.ThirdRoad.CurPoint.Y, 4, 4);
            }
        }

        public void DrawNetting()
        {
            graphic.DrawImage(Pictures.netting, Netting);
        }
        public void DrawTrigon()
        {
            if (player.EquipedRoad != null)
            {
                graphic.DrawImage(Pictures.trigon, RTrigon);
            }
        }

        public void DrawRoads()
        {
            if (player.FirstRoad != null && !player.FirstRoad.IsFishAttack)
            {
                graphic.DrawImage(Pictures.road, FirstNormalRoad);
            }
            else if(player.FirstRoad != null && player.FirstRoad.IsFishAttack)
            {
                graphic.DrawImage(Pictures.izgRoad, FirstBrokenRoad);
            }
            if (player.SecondRoad != null && !player.SecondRoad.IsFishAttack)
            {
                graphic.DrawImage(Pictures.road, SecondNormalRoad);
            }
            else if (player.SecondRoad != null && player.SecondRoad.IsFishAttack)
            {
                graphic.DrawImage(Pictures.izgRoad, SecondBrokenRoad);
            }
            if (player.ThirdRoad != null && !player.ThirdRoad.IsFishAttack)
            {
                graphic.DrawImage(Pictures.road, ThirdNormalRoad);
            }
            else if (player.ThirdRoad != null && player.ThirdRoad.IsFishAttack)
            {
                graphic.DrawImage(Pictures.izgRoad, ThirdBrokenRoad);
            }
        }
        public void UpdateRectangles()
        {
            try
            {

                if (player.FirstRoad != null)
                {
                    FirstNormalRoad = new Rectangle(player.FirstRoad.CurPoint.X,
                                                    player.FirstRoad.RoadY,
                                                    Pictures.road.Width,
                                                    257);

                    FirstBrokenRoad = new Rectangle(player.FirstRoad.RoadX - 10,
                                                    player.FirstRoad.RoadY,
                                                    Pictures.izgRoad.Width,
                                                    257);
                }

                if (player.SecondRoad != null)
                {
                    SecondNormalRoad = new Rectangle(player.SecondRoad.CurPoint.X,
                                                     player.SecondRoad.RoadY,
                                                     Pictures.road.Width,
                                                     257);
                    SecondBrokenRoad = new Rectangle(player.SecondRoad.RoadX - 10,
                                                     player.SecondRoad.RoadY,
                                                     Pictures.izgRoad.Width,
                                                     257);
                }
                if (player.ThirdRoad != null)
                {
                    ThirdNormalRoad = new Rectangle(player.ThirdRoad.CurPoint.X,
                                                    player.ThirdRoad.RoadY,
                                                    Pictures.road.Width,
                                                    257);
                    ThirdBrokenRoad = new Rectangle(player.ThirdRoad.RoadX - 10,
                                                    player.ThirdRoad.RoadY,
                                                    Pictures.izgRoad.Width,
                                                    257);
                }
                if (player.EquipedRoad != null)
                {
                    Netting = new Rectangle(player.EquipedRoad.CurPoint.X,
                                            -300,
                                            60,
                                            200);
                }
                if (player.EquipedRoad != null)
                {
                    RTrigon = new Rectangle(player.EquipedRoad.RoadX + 12,
                                            585,
                                            18,
                                            18);
                }
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
