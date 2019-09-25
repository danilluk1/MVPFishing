using Fishing.Presenter;
using Fishing.View.LVLS.Ozero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fishing
{
    public partial class OzeroForm : Form, ILVL
    {
        static LVL2 lvl2;
        LVLPresenter presenter;
        public OzeroForm()
        {
            InitializeComponent();
            presenter = new LVLPresenter(this, GUI.gui);
            presenter.StartBaitTimer += Presenter_StartBaitTimer;
            presenter.StopGatheringTimer += Presenter_StopGatheringTimer;
            
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);

            UpdateStyles();
            lvl2 = new LVL2();
            lvl2.SetDeep();
            lvl2.addFishes();
        }

        private void Presenter_StopGatheringTimer(object sender, EventArgs e)
        {
            GatheringTimer.Stop();
        }

        private void Presenter_StartBaitTimer(object sender, EventArgs e)
        {
            baitTimer.Start();
        }

        public Point CurPoint { get => PointToClient(Cursor.Position); set => throw new ArgumentException(); }

        public event EventHandler MouseLeftClick;
        public event EventHandler CountGathering;
        public event EventHandler CountFishMoves;
        public event PaintEventHandler RepaintScreen;
        public event KeyEventHandler KeyDOWN;
        public event KeyEventHandler KeyUP;
        public event EventHandler MainTimerTick;

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
            lvl2.getFish();
        }
    }
}
