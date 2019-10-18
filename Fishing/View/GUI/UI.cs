using Fishing.BL.Model.Game;
using Fishing.BL.Model.MapFactory;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Sounds;
using Fishing.BL.View;
using Fishing.Presenter;
using Fishing.View.FoodInventory;
using Fishing.View.GUI;
using Fishing.View.LureSelector;
using Fishing.View.Statistic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing
{
    public partial class UI : Form, IGUI, IGUIPresenter, ISounder
    {
        GUIPresenter presenter;
        readonly SounderPresenter sound;
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
            try
            {
                BaitsPicture.Image = Player.GetPlayer().Assembly.Lure.Pict;
                roadBox.Image = Player.GetPlayer().Assembly.Proad.Pict;
                reelBox.Image = Player.GetPlayer().Assembly.Reel.Pict;
                flineBox.Image = Player.GetPlayer().Assembly.FLine.Pict;
            }
            catch (NullReferenceException) { }
            MoneyLValue = Player.GetPlayer().Money;
            Game.GetGame().HoursInc += GUI_HoursInc;
            timeLabel.Text = Game.GetGame().Time.ToString();
        }

        private void GUI_HoursInc(object sender, EventArgs e)
        {
            timeLabel.Text = Game.GetGame().Time.ToString();
        }

        public int SpeedValue { get => SpeedBar.Value; set => throw new NotImplementedException(); }
        public Bitmap BaitPicture { get => (Bitmap)BaitsPicture.BackgroundImage; set => BaitsPicture.BackgroundImage = value; }
        public int DeepValue { get => Convert.ToInt32(DeepLabel.Text); set => DeepLabel.Text = value.ToString(); }
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

        public event EventHandler SettingsButtonClick;
        public event PaintEventHandler SounderPaint;
        public event EventHandler EventBarClick;
        public event EventHandler MapButtonClick;
        public event EventHandler InventoryButtonClick;
        public event EventHandler MenuButtonClick;
        public event EventHandler FPondClick;
        public event EventHandler BaitPicClick;
        public event EventHandler RefreshSounder;

        private void MapLabel_Click(object sender, EventArgs e)
        {
            MFactory f = new MFactory(Game.GetGame().CurrentWater);
            Game.GetGame().View.Down();
            f.CreateMap();
        }
        private void MenuLabel_Click(object sender, EventArgs e)
        {
            UI.gui.Close();
            Game.GetGame().View.Down();
            MenuPresenter presenter = new MenuPresenter(new Menu());
        }

        private void SettingLabel_Click(object sender, EventArgs e)
        {
            SettingsButtonClick?.Invoke(this, e);
        }

        private void FpondBox_Click(object sender, EventArgs e)
        {
            fishesForm form = new fishesForm();
            form.Show();
        }

        private void BaitsPicture_Click(object sender, EventArgs e)
        {
            if (Player.GetPlayer().Assembly != null)
            {
                LureSelector selector = new LureSelector();
                selector.Show();
            }
        }
        private void EatingBar_Click(object sender, EventArgs e)
        {
            FoodPresenter presenter = new FoodPresenter(new FoodInventory());
        }


        private void SounderPanel_Paint(object sender, PaintEventArgs e)
        {
            SounderPaint?.Invoke(this, e);
        }

        private void SounderUpdater_Tick(object sender, EventArgs e)
        {
            SounderPanel.Refresh();
        }    
        private void InventoryBox_Click(object sender, EventArgs e)
        {
            InventoryPresenter presenter = new InventoryPresenter(new Inventory(), gui);
        }

        private void StatsBox_Click(object sender, EventArgs e)
        {
            StatisticPresenter presenter = new StatisticPresenter(new StatisticForm());
        }
        public void AddEventToBox(BaseEvent ev)
        {

            ListViewItem lvi = new ListViewItem();
            lvi.Text = ev.Text;
            lvi.ImageIndex = ev.Index;
            if(ev is TrophyFishEvent)
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

        private void eatingBar_Load(object sender, EventArgs e)
        {

        }
    }
}
