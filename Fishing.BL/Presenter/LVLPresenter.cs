using Fishing.BL.Model.Drawer;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using Fishing.BL.Resources.Sounds;
using Fishing.View.GUI;
using Fishing.View.LVLS.Ozero;
using Saver.BL.Controller;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fishing.Presenter {

    public class LVLPresenter : BasePresenter {
        private const int NO_WATER_AREA = 570;

        private readonly IGameForm view;
        private readonly IGUIPresenter gui;

        private Player player;
        private SoundPlayer sp;

        public LVLRealisation CurLVL { get; set; }

        private Drawer drawer;

        public LVLPresenter(IGameForm view, IGUIPresenter v, LVLRealisation curLVL) {
            this.CurLVL = curLVL;
            curLVL.AddFishes();
            curLVL.SetDeep();
            this.view = view;
            this.gui = v;
            view.LVLPresenter = this;
            view.BackImage = CurLVL.Image;
            player = Player.GetPlayer();
            sp = new SoundPlayer();

            view.RepaintScreen += View_RepaintScreen;
            view.FormMouseClick += View_MouseLeftClick;
            view.KeyDOWN += View_KeyDOWN;
            view.KeyUP += View_KeyUP;
            view.MainTimerTick += View_MainTimerTick;
            view.FormClose += View_FormClose;
            view.DecSacietyTimerTick += View_DecSacietyTimerTick;
        }

        private void View_DecSacietyTimerTick(object sender, EventArgs e) {
            player.DecSatiety(5);
            gui.EatingBarValue = player.Satiety;
        }

        private void View_FormClose(object sender, EventArgs e) {
            BaseController.GetController().SavePlayer();
            this.End();
        }

        private void View_MainTimerTick(object sender, EventArgs e) {
            try {
                SetSounderCoord(player.EquipedRoad.CurPoint);
                if (player.EquipedRoad.IsFishAttack) {
                    gui.LureDeepValue = player.EquipedRoad.CurrentDeep;
                    AutoDecBarValues();
                    if (gui.FLineBarValue > 990) {
                        player.AddEventToHistory(new FLineTornEvent());
                        player.TornFLine();

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;

                        sp.Stream = SoundsRes.leskaobr;
                        sp.Play();
                    }
                    if (gui.RoadBarValue > 990) {
                        player.BrokeRoad();
                        player.AddEventToHistory(new RoadBrokenEvent());

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;
                    }
                }
                if (player.FirstRoad != null && player.FirstRoad.IsFishAttack) {
                    player.FirstRoad.CurPoint.Y += player.FirstRoad.Fish.Power.Y;
                    player.FirstRoad.CurPoint.X += player.FirstRoad.Fish.Power.X;
                    CheckBorders(player.FirstRoad.CurPoint, player.FirstRoad);
                }
                if (player.SecondRoad != null && player.SecondRoad.IsFishAttack) {
                    player.SecondRoad.CurPoint.Y += player.SecondRoad.Fish.Power.Y;
                    player.SecondRoad.CurPoint.X += player.SecondRoad.Fish.Power.X;
                    CheckBorders(player.SecondRoad.CurPoint, player.SecondRoad);
                }
                if (player.ThirdRoad != null && player.ThirdRoad.IsFishAttack) {
                    player.ThirdRoad.CurPoint.Y += player.ThirdRoad.Fish.Power.Y;
                    player.ThirdRoad.CurPoint.X += player.ThirdRoad.Fish.Power.X;
                    CheckBorders(player.ThirdRoad.CurPoint, player.ThirdRoad);
                }
                if (player.EquipedRoad.CurPoint.Y >= NO_WATER_AREA) {
                    player.EquipedRoad.IsBaitInWater = false;
                }
                view.UpdateForm();
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.G:
                    player.EquipedRoad.CurrentDeep = Convert.ToInt32(gui.DeepValue);
                    player.EquipedRoad.IsBaitMoving = true;
                    if (player.EquipedRoad.IsFishAttack) {
                        player.EquipedRoad.Image = player.EquipedRoad.GImage;
                        player.WindingSpeed = player.EquipedRoad.Assembly.Reel.Power;
                    }
                    else {
                        Player.GetPlayer().WindingSpeed = 1;
                    }
                    DoWiring();
                    IncFLineBarValues();
                    break;

                    case Keys.H:
                    if (player.EquipedRoad.IsFishAttack) {
                        player.EquipedRoad.Image = player.EquipedRoad.HImage;
                        player.WindingSpeed = 2;
                        player.EquipedRoad.CurPoint.Y += player.WindingSpeed;
                        IncRoadBarValues();
                    }
                    break;

                    case Keys.Space:
                    if (IsFishAbleToGoIntoFpond()) {
                        player.EquipedRoad.Image = Roads.road;
                        player.EquipedRoad.FLineIncValue = 0;
                        player.EquipedRoad.RoadIncValue = 0;

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;

                        gui.CheckNeedsAndClearEventBox();
                        player.Netting.ShowNetting();
                        if (!player.EquipedRoad.Fish.isTrophy()) {
                            player.AddEventToHistory(new FishEvent(player.EquipedRoad.Fish,
                                                                    player.EquipedRoad.Assembly.FishBait));
                        }
                        else {
                            player.AddEventToHistory(new TrophyFishEvent(player.EquipedRoad.Fish,
                                                                    player.EquipedRoad.Assembly.FishBait));
                        }
                        view.CreateCurrentFish(player.EquipedRoad.Fish);
                        player.Statistic.TakenFishesCount++;

                    }
                    break;

                    case Keys.T:
                    if (player.EquipedRoad.IsFishAttack == false) {
                        MakeCast(player.EquipedRoad.LastCastPoint);
                    }
                    break;

                    case Keys.D1:
                    player.SetEquipedRoad(1);
                    gui.AddRoadToGUI(player.EquipedRoad);
                    break;

                    case Keys.D2:
                    player.SetEquipedRoad(2);
                    gui.AddRoadToGUI(player.EquipedRoad);
                    break;

                    case Keys.D3:
                    player.SetEquipedRoad(3);
                    gui.AddRoadToGUI(player.EquipedRoad);
                    break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyUP(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.G:
                    if (player.EquipedRoad.IsFishAttack) {
                        player.EquipedRoad.Image = player.EquipedRoad.GImage;
                    }
                    player.EquipedRoad.IsBaitMoving = false;
                    player.EquipedRoad.RoadY -= 7;
                    break;

                    case Keys.H:
                    if (player.EquipedRoad.IsFishAttack) {
                        player.EquipedRoad.Image = player.EquipedRoad.GImage;
                    }
                    break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_MouseLeftClick(object sender, MouseEventArgs e) {
            var tup = IsPointIntersecWithRoadRect(view.CurPoint);
            if (tup.IsIntersec) {
                player.SetEquipedRoad(tup.Road);
                gui.AddRoadToGUI(player.EquipedRoad);
            }
            if (!tup.IsIntersec && !player.EquipedRoad.IsFishAttack) {
                MakeCast(view.CurPoint);
            }
            if (e.Button == MouseButtons.Right) {               
                if (tup.IsIntersec) {
                    player.EquipedRoad = null;
                }
            }
        }

        private void View_RepaintScreen(object sender, PaintEventArgs e) {
            try {
                drawer = new Drawer(e.Graphics);
                drawer.UpdateRectangles();
                drawer.DrawRoads();
                drawer.DrawPoints();
                if (player.EquipedRoad != null) {
                    drawer.DrawTrigon();
                }
                if (IsFishAbleToGoIntoFpond()) {
                    drawer.DrawNetting();
                }
            }
            catch (NullReferenceException) { }
        }

        private void MakeCast(Point point) {
            if (player.IsPlayerAbleToFishing()) {
                player.EquipedRoad.CurLVL = CurLVL;
                SetSounderCoord(point);

                if (!player.EquipedRoad.IsFishAttack) {
                    CheckBorders(point, player.EquipedRoad);
                    player.EquipedRoad.IsBaitInWater = true;
                    player.EquipedRoad.IsBaitMoving = false;
                    player.EquipedRoad.StartBaitTimer();
                    player.EquipedRoad.RoadX = player.EquipedRoad.CurPoint.X;
                    player.EquipedRoad.LastCastPoint = point;

                    sp.Stream = SoundsRes.zabr;
                    sp.Play();
                }
                if (!player.EquipedRoad.IsFishAttack) {
                    player.EquipedRoad.RoadY = 350;
                    try {
                        if (player.EquipedRoad.Assembly.FishBait == null) {
                            player.EquipedRoad.CurPoint.Y = 0;
                            MessageBox.Show(Messages.NO_LURE_EQUIPED);
                        }
                    }
                    catch (NullReferenceException) {
                        player.EquipedRoad.CurPoint.Y = 0;
                    }
                }
            }
            else {
                MessageBox.Show("Игрок не готов к рыбалке");
            }
        }

        private void DoWiring() {
            if (player.EquipedRoad.RoadY != 357) {
                player.EquipedRoad.RoadY += 7;
            }
            player.WindingSpeed = player.EquipedRoad.IsFishAttack ? player.EquipedRoad.Assembly.Reel.Power : 1;
            player.EquipedRoad.CurPoint.Y += Player.GetPlayer().WindingSpeed;
        }

        private void AutoDecBarValues() {
            if (gui.FLineBarValue > 0) {
                gui.IncrementFLineBarValue(-3);
            }
            if (gui.RoadBarValue > 0) {
                gui.IncrementRoadBarValue(-3);
            }
        }

        private void SetSounderCoord(Point point) {
            for (int y = 0; y < CurLVL.Height; y++) {
                for (int x = 0; x < CurLVL.Widgth; x++) {
                    Rectangle r = new Rectangle(CurLVL.Deeparr[x, y].Location, new System.Drawing.Size(40, 23));
                    if (r.IntersectsWith(new Rectangle(point, new System.Drawing.Size(1, 1)))) {
                        Sounder.GetSounder().Column = y;
                        Sounder.GetSounder().Row = x;
                        player.EquipedRoad.CurrentDeep = Convert.ToInt32(CurLVL.Deeparr[x, y].Text);
                        gui.LureDeepValue = player.EquipedRoad.CurrentDeep;
                    }
                }
            }
        }

        private void IncFLineBarValues() {
            if (gui.RoadBarValue > 0) {
                gui.IncrementRoadBarValue(-(player.EquipedRoad.RoadIncValue));
            }
            if (gui.FLineBarValue < 1000) {
                gui.IncrementFLineBarValue(player.EquipedRoad.FLineIncValue);
            }
        }

        private void IncRoadBarValues() {
            if (gui.RoadBarValue < 1000) {
                gui.IncrementRoadBarValue(player.EquipedRoad.RoadIncValue);
            }
            if (gui.FLineBarValue > 0) {
                gui.IncrementFLineBarValue(-(player.EquipedRoad.FLineIncValue));
            }
        }

        private (bool IsIntersec, GameRoad Road) IsPointIntersecWithRoadRect(Point p) {
            System.Drawing.Size size = new System.Drawing.Size(1, 1);
            if (drawer.FirstNormalRoad.IntersectsWith(new Rectangle(p, size)) || drawer.FirstBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (player.EquipedRoad != player.FirstRoad) {
                    gui.AddRoadToGUI(player.EquipedRoad);
                }
                return (true, player.FirstRoad);
            }
            if (drawer.SecondNormalRoad.IntersectsWith(new Rectangle(p, size)) || drawer.SecondBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (player.EquipedRoad != player.SecondRoad) {
                    gui.AddRoadToGUI(player.EquipedRoad);
                }
                return (true, player.SecondRoad);
            }
            if (drawer.ThirdNormalRoad.IntersectsWith(new Rectangle(p, size)) || drawer.ThirdBrokenRoad.IntersectsWith(new Rectangle(p, size))) {
                if (player.EquipedRoad != player.ThirdRoad) {
                    gui.AddRoadToGUI(player.EquipedRoad);
                }
                return (true, player.ThirdRoad);
            }

            return (false, null);
        }

        private void CheckBorders(Point point, GameRoad road) {
            if (point.Y >= CurLVL.Deeparr[0, 0].Location.Y) {
                road.CurPoint.Y = point.Y;
            }
            else {
                road.CurPoint.Y = CurLVL.Deeparr[0, 0].Location.Y + 3;
            }
            if (point.X >= CurLVL.Deeparr[0, 0].Location.X) {
                road.CurPoint.X = point.X;
            }
            if (point.X >= CurLVL.Deeparr[CurLVL.Widgth - 1, 0].Location.X) {
                road.CurPoint.X = CurLVL.Deeparr[CurLVL.Widgth - 1, 0].Location.X;
            }
        }

        private bool IsFishAbleToGoIntoFpond() {
            if (player.EquipedRoad.IsFishAttack && player.EquipedRoad.CurPoint.Y >= NO_WATER_AREA) {
                return true;
            }

            return false;
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}