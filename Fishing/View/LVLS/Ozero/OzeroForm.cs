using Fishing.BL.Model.Game;
using Fishing.Presenter;
using Fishing.View.LVLS.Ozero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Fishing.BL.Resources.Sounds;

namespace Fishing
{
    public partial class OzeroForm : Form, ILVL
    {
        LVLPresenter presenter;
        public OzeroForm(LVL curLVL)
        {
            InitializeComponent();
            presenter = new LVLPresenter(this, GUI.gui, curLVL);
            presenter.StartBaitTimer += Presenter_StartBaitTimer;
            presenter.StopBaitTimer += Presenter_StopBaitTimer;
            presenter.StopGatheringTimer += Presenter_StopGatheringTimer;
            presenter.RefreshForm += Presenter_RefreshForm;
            presenter.CreateCurrentFishF += Presenter_CreateCurrentFishF;
            
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);

            UpdateStyles();
        }
        public Point CurPoint { get => PointToClient(Cursor.Position); set => throw new ArgumentException(); }

        public event EventHandler MouseLeftClick;
        public event EventHandler CountGathering;
        public event EventHandler CountFishMoves;
        public event PaintEventHandler RepaintScreen;
        public event KeyEventHandler KeyDOWN;
        public event KeyEventHandler KeyUP;
        public event EventHandler MainTimerTick;
        public event EventHandler BaitTimerTick;
        public event EventHandler FormClose;

        private void Presenter_CreateCurrentFishF(object sender, EventArgs e)
        {
            CurrentFish cf = new CurrentFish();
        }

        private void Presenter_StopBaitTimer(object sender, EventArgs e)
        {
            baitTimer.Stop();
        }

        private void Presenter_RefreshForm(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Presenter_StopGatheringTimer(object sender, EventArgs e)
        {
            GatheringTimer.Stop();
        }

        private void Presenter_StartBaitTimer(object sender, EventArgs e)
        {
            baitTimer.Start();
        }

        private void OzeroForm_Load(object sender, EventArgs e)
        {
        }

        private void OzeroForm_MouseClick(object sender, MouseEventArgs e)
        {
            MouseLeftClick?.Invoke(this, EventArgs.Empty);

        }

        private void OzeroForm_Paint(object sender, PaintEventArgs e)
        {
            RepaintScreen?.Invoke(this, e);
        }

        private void MainTaskstimer_Tick(object sender, EventArgs e)
        {
            MainTimerTick?.Invoke(this, e);
        }

        private void GatheringTimer_Tick(object sender, EventArgs e)
        {
            CountGathering?.Invoke(this, EventArgs.Empty);
        }

        private void FishMovestimer_Tick(object sender, EventArgs e)
        {
            CountFishMoves?.Invoke(this, EventArgs.Empty);
        }

        private void OzeroForm_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDOWN?.Invoke(this, e);
        }

        private void OzeroForm_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUP?.Invoke(this, e);
        }

        private void BaitTimer_Tick(object sender, EventArgs e)
        {
            BaitTimerTick?.Invoke(this, e);
        }

        private void OzeroForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClose?.Invoke(this, EventArgs.Empty);
            GUI.gui.Close();
        }

        private void SoundPlayerTimer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            string name = "day" + r.Next(1, 9).ToString();
            SoundPlayer player = new SoundPlayer(SoundsRes.ResourceManager.GetStream(name));
            player.Play();
        }
    }
}
