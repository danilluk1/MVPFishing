using System;
using System.Drawing;

namespace Fishing.BL.Model.Drawer {

    internal class Drawer {
        private Graphics graphic;

        private Player player = Player.GetPlayer();
        private SolidBrush sbrush = new SolidBrush(Color.White);

        public Rectangle FirstNormalRoad;
        public Rectangle FirstBrokenRoad;

        public Rectangle SecondNormalRoad;
        public Rectangle SecondBrokenRoad;

        public Rectangle ThirdNormalRoad;
        public Rectangle ThirdBrokenRoad;

        private Rectangle Netting;
        public Rectangle RTrigon;

        public Drawer(Graphics g) {
            graphic = g;
        }

        public void DrawPoints() {
            if (player.FirstRoad != null) {
                if (player.FirstRoad == player.EquipedRoad) {
                    sbrush.Color = Color.Red;
                }
                else {
                    sbrush.Color = Color.White;
                }
                graphic.DrawEllipse(new Pen(Color.White), player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
                graphic.FillEllipse(sbrush, player.FirstRoad.CurPoint.X, player.FirstRoad.CurPoint.Y, 4, 4);
            }

            if (player.SecondRoad != null) {
                if (player.SecondRoad == player.EquipedRoad) {
                    sbrush.Color = Color.Red;
                }
                else {
                    sbrush.Color = Color.White;
                }
                graphic.DrawEllipse(new Pen(Color.White), player.SecondRoad.CurPoint.X, player.SecondRoad.CurPoint.Y, 4, 4);
                graphic.FillEllipse(sbrush, player.SecondRoad.CurPoint.X, player.SecondRoad.CurPoint.Y, 4, 4);
            }
            if (player.ThirdRoad != null) {
                if (player.ThirdRoad == player.EquipedRoad) {
                    sbrush.Color = Color.Red;
                }
                else {
                    sbrush.Color = Color.White;
                }
                graphic.DrawEllipse(new Pen(Color.White), player.ThirdRoad.CurPoint.X, player.ThirdRoad.CurPoint.Y, 4, 4);
                graphic.FillEllipse(sbrush, player.ThirdRoad.CurPoint.X, player.ThirdRoad.CurPoint.Y, 4, 4);
            }
        }

        public void DrawNetting() {
            graphic.DrawImage(Pictures.netting, Netting);
        }

        public void DrawTrigon() {
            if (player.EquipedRoad != null) {
                graphic.DrawImage(Pictures.trigon, RTrigon);
            }
        }

        public void DrawRoads() {
            try {
                if (player.FirstRoad != null && !player.FirstRoad.IsFishAttack) {
                    graphic.DrawImage(player.FirstRoad.Image, FirstNormalRoad);
                }
                else if (player.FirstRoad != null && player.FirstRoad.IsFishAttack) {
                    graphic.DrawImage(player.FirstRoad.Image, FirstBrokenRoad);
                }
                if (player.SecondRoad != null && !player.SecondRoad.IsFishAttack) {
                    graphic.DrawImage(player.SecondRoad.Image, SecondNormalRoad);
                }
                else if (player.SecondRoad != null && player.SecondRoad.IsFishAttack) {
                    graphic.DrawImage(player.SecondRoad.Image, SecondBrokenRoad);
                }
                if (player.ThirdRoad != null && !player.ThirdRoad.IsFishAttack) {
                    graphic.DrawImage(player.ThirdRoad.Image, ThirdNormalRoad);
                }
                else if (player.ThirdRoad != null && player.ThirdRoad.IsFishAttack) {
                    graphic.DrawImage(player.ThirdRoad.Image, ThirdBrokenRoad);
                }
            }
            catch (ArgumentNullException) { }
        }

        public void UpdateRectangles() {
            try {
                if (player.FirstRoad != null) {
                    FirstNormalRoad = new Rectangle(player.FirstRoad.RoadX,
                                                    player.FirstRoad.RoadY,
                                                    player.FirstRoad.Image.Width,
                                                    257);

                    FirstBrokenRoad = new Rectangle(player.FirstRoad.RoadX - 10,
                                                    player.FirstRoad.RoadY,
                                                    player.FirstRoad.Image.Width,
                                                    257);
                }

                if (player.SecondRoad != null) {
                    SecondNormalRoad = new Rectangle(player.SecondRoad.RoadX,
                                                     player.SecondRoad.RoadY,
                                                     player.SecondRoad.Image.Width,
                                                     257);
                    SecondBrokenRoad = new Rectangle(player.SecondRoad.RoadX - 10,
                                                     player.SecondRoad.RoadY,
                                                     player.SecondRoad.Image.Width,
                                                     257);
                }
                if (player.ThirdRoad != null) {
                    ThirdNormalRoad = new Rectangle(player.ThirdRoad.RoadX,
                                                    player.ThirdRoad.RoadY,
                                                    player.ThirdRoad.Image.Width,
                                                    257);
                    ThirdBrokenRoad = new Rectangle(player.ThirdRoad.RoadX - 10,
                                                    player.ThirdRoad.RoadY,
                                                    player.ThirdRoad.Image.Width,
                                                    257);
                }
                if (player.EquipedRoad != null) {
                    Netting = new Rectangle(player.EquipedRoad.CurPoint.X,
                                            -300,
                                            60,
                                            200);
                }
                if (player.EquipedRoad != null) {
                    RTrigon = new Rectangle(player.EquipedRoad.RoadX + 12,
                                            585,
                                            18,
                                            18);
                }
            }
            catch (NullReferenceException) {
            }
        }
    }
}