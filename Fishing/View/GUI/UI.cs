using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.Presenter;
using Fishing.View.FoodInventory;
using Fishing.View.GUI;
using Fishing.View.LureSelector;
using Fishing.View.LureSelector.Presenter;
using Fishing.View.Statistic;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fishing
{
    public partial class UI : Form, IGUIPresenter, ISounder
    {
        private GUIPresenter presenter;
        private readonly SounderPresenter sound;
        public static UI gui;
        private SoundPlayer sp = new SoundPlayer();

        public UI(LVL lvl)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                                                                            ControlStyles.UserPaint, true);
            eatingBar.Value = Player.GetPlayer().Satiety;
            presenter = new GUIPresenter(this);
            sound = new SounderPresenter(this, lvl);

            MoneyLValue = Player.GetPlayer().Money;
            timeLabel.Text = Game.GetGame().Time.ToString();

            Game.GetGame().HoursInc += GUI_HoursInc;
            Player.GetPlayer().EventHistoryUpdated += ShowLastEvent;
            Player.GetPlayer().SatietyUpdated += SatietyUpdated;
        }

        private void SatietyUpdated(int obj)
        {
            eatingBar.Increment(obj);
        }

        private void ShowLastEvent()
        {
            AddEventToBox(Player.GetPlayer().EventHistory.Peek());
        }
        private void GUI_HoursInc(object sender, EventArgs e)
        {
            timeLabel.Text = Game.GetGame().Time.ToString();
        }

        public Bitmap BaitPicture { get => (Bitmap)BaitsPicture.BackgroundImage; set => BaitsPicture.BackgroundImage = value; }
        public string DeepValue { get => DeepLabel.Text; set => DeepLabel.Text = value; }
        public int RoadBarValue { get => ReelBar.Value; set => ReelBar.Value = value; }
        public int FLineBarValue { get => FLineBar.Value; set => FLineBar.Value = value; }
        public int EventBoxItemsCount { get => eventsView.Items.Count; set => throw new NotImplementedException(); }
        public int MoneyLValue { get => Convert.ToInt32(MoneyLabel.Text); set => MoneyLabel.Text = value.ToString(); }
        public int LureDeepValue { get => Convert.ToInt32(LureDeep.Text); set => LureDeep.Text = value.ToString(); }
        public string WiringType { get => WiringTypeLabel.Text; set => WiringTypeLabel.Text = value; }
        public int EatingBarValue { get => eatingBar.Value; set => eatingBar.Value = value; }
        public Image RoadPicture { get => roadBox.BackgroundImage; set => roadBox.BackgroundImage = value; }
        public Image ReelPicture { get => reelBox.BackgroundImage; set => reelBox.BackgroundImage = value; }
        public Image FLinePicture { get => flineBox.BackgroundImage; set => flineBox.BackgroundImage = value; }
        public Image HookPicture { get => hookBox.BackgroundImage; set => hookBox.BackgroundImage = value; }
        public BasePresenter Presenter { private get; set; }

        public event PaintEventHandler SounderPaint;

        public event EventHandler RefreshSounder;

        private void MapLabel_Click(object sender, EventArgs e)
        {
            Game.GetGame().View.Down();
            Map map = new Map();
            map.Show();
        }

        private void MenuLabel_Click(object sender, EventArgs e)
        {
            UI.gui.Close();
            Game.GetGame().View.Down();
        }

        private void SettingLabel_Click(object sender, EventArgs e)
        {
            SettingsForm f = new SettingsForm();
            f.Show();
        }

        private void FpondBox_Click(object sender, EventArgs e)
        {
            fishesForm form = new fishesForm();
            form.Show();
        }

        private void BaitsPicture_Click(object sender, EventArgs e)
        {
            if (Player.GetPlayer().EquipedRoad.Assembly != null && !Player.GetPlayer().EquipedRoad.IsBaitInWater)
            {
                if (Player.GetPlayer().EquipedRoad.Assembly.FishBait is Lure)
                {
                    var presenter = new SelectorPresenter<Lure>(new LureSelector<Lure>(Player.GetPlayer().LureInv), this);
                }
                if (Player.GetPlayer().EquipedRoad.Assembly.FishBait is Bait)
                {
                    var presenter = new SelectorPresenter<Bait>(new LureSelector<Bait>(Player.GetPlayer().BaitInv), this);
                }
            }
        }

        private void EatingBar_Click(object sender, EventArgs e)
        {
            var presenter = new FoodPresenter(new FoodInventory());
            presenter.Run();
        }
        private void InventoryBox_Click(object sender, EventArgs e)
        {
            var presenter = new InventoryPresenter(new Inventory(), gui);
            presenter.Run();
        }
        private void StatsBox_Click(object sender, EventArgs e)
        {
            var presenter = new StatisticPresenter(new StatisticForm());
            presenter.Run();
        }

        private void SounderPanel_Paint(object sender, PaintEventArgs e)
        {
            SounderPaint?.Invoke(this, e);
        }

        private void SounderUpdater_Tick(object sender, EventArgs e)
        {
            SounderPanel.Refresh();
        }
        public void AddEventToBox(BaseEvent ev)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = ev.Text;
            lvi.ImageIndex = ev.Index;
            if (ev is TrophyFishEvent)
            {
                lvi.ForeColor = Color.White;
                lvi.BackColor = Color.Navy;
            }
            eventsView.Items.Add(lvi);
        }

        public void ClearEvents()
        {
            eventsView.Items.Clear();
        }

        public void IncrementRoadBarValue(int value)
        {
            ReelBar.Increment(value);
        }

        public void IncrementFLineBarValue(int value)
        {
            FLineBar.Increment(value);
        }

        public void CheckNeedsAndClearEventBox()
        {
            if (EventBoxItemsCount >= 5)
            {
                ClearEvents();
            }
        }

        public void AddRoadToGUI(GameRoad road)
        {
            BaitPicture = null;
            RoadPicture = null;
            ReelPicture = null;
            FLinePicture = null;
            HookPicture = null;
            BaitPicture = road.Assembly.FishBait.Pict;
            FLinePicture = road.Assembly.FLine.Pict;
            RoadPicture = road.Assembly.Road.Pict;
            ReelPicture = road.Assembly.Reel.Pict;
            if (road.Assembly.Road is Feeder)
            {
                HookPicture = road.Assembly.Hook.Pict;
            }
        }

        public void Open()
        {
            this.Show();
        }

        public void Down()
        {
            this.Show();
        }
    }
}