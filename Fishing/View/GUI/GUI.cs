using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Sounds;
using Fishing.BL.View;
using Fishing.Presenter;
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
    public partial class GUI : Form, IGUI, IGUIPresenter, ISounder
    {
        GUIPresenter presenter;
        readonly SounderPresenter sound;
        public static GUI gui;
        private SoundPlayer sp = new SoundPlayer();

        public GUI(LVL lvl)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                                                                            ControlStyles.UserPaint, true);
            presenter = new GUIPresenter(this);
            sound = new SounderPresenter(this, lvl);
            try
            {
                BaitsPicture.Image = Player.GetPlayer().Assembly.Lure.Pict;
            }
            catch (NullReferenceException) { }
            MoneyLValue = Player.GetPlayer().Money;

        }

        public int SpeedValue { get => SpeedBar.Value; set => throw new NotImplementedException(); }
        public Bitmap BaitPicture { get => (Bitmap)BaitsPicture.Image; set => BaitsPicture.Image = value; }
        public int DeepValue { get => Convert.ToInt32(DeepLabel.Text); set => DeepLabel.Text = value.ToString(); }
        public int RoadBarValue { get => ReelBar.Value; set => ReelBar.Value = value; }
        public int FLineBarValue { get => FLineBar.Value; set => FLineBar.Value = value; }
        public int EventBoxItemsCount { get => eventsView.Items.Count; set => throw new NotImplementedException(); }
        public int MoneyLValue { get => Convert.ToInt32(MoneyLabel.Text); set => MoneyLabel.Text = value.ToString(); }
        public int LureDeepValue { get => Convert.ToInt32(LureDeep.Text); set => LureDeep.Text = value.ToString(); }
        public string WiringType { get => WiringTypeLabel.Text; set => WiringTypeLabel.Text = value; }

        public event EventHandler MapButtonClick;
        public event EventHandler InventoryButtonClick;
        public event EventHandler MenuButtonClick;
        public event EventHandler SettingsButtonClick;
        public event EventHandler FPondClick;
        public event EventHandler BaitPicClick;
        public event PaintEventHandler SounderPaint;
        public event EventHandler RefreshSounder;

        private void MapLabel_Click(object sender, EventArgs e)
        {
            Ozero map = new Ozero();
            map.Show();
            Ozero.ozero.Close();
            sp.Stream = SoundsRes.open_items;
            sp.Play();
        }
        private void MenuLabel_Click(object sender, EventArgs e)
        {
            GUI.gui.Close();
            Ozero.ozero.Close();
            Menu menu = new Menu();
            menu.Show();
            sp.Stream = SoundsRes.open_items;
            sp.Play();
        }

        private void SettingLabel_Click(object sender, EventArgs e)
        {
            SettingsButtonClick?.Invoke(this, e);
        }

        private void FpondBox_Click(object sender, EventArgs e)
        {
            fishesForm form = new fishesForm();
            form.Show();
            sp.Stream = SoundsRes.open_items;
            sp.Play();
        }

        private void BaitsPicture_Click(object sender, EventArgs e)
        {
            LureSelector selector = new LureSelector();
            selector.Show();
            sp.Stream = SoundsRes.open_items;
            sp.Play();
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
            Inventory inventory = new Inventory();
            inventory.Show();
            sp.Stream = SoundsRes.open_items;
            sp.Play();
        }

        private void StatsBox_Click(object sender, EventArgs e)
        {
            StatisticForm form = new StatisticForm();
            form.Show();
            sp.Stream = SoundsRes.open_corf;
            sp.Play();
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
            if (EventBoxItemsCount > 5)
            {
                ClearEvents();
            }
        }

        public void AddLabels(Label[,] l)
        {
            for (int x = 0; x < 51; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                    Controls.Add(l[x, y]);
                }
            }
        }
    }
}
