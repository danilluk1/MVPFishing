using Fishing.BL.Resources.Sounds;
using Fishing.Presenter;
using Fishing.View.LVLS.Ozero;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fishing
{
    public partial class GameForm : Form, IGameForm
    {
        public GameForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        public Point CurPoint { get => PointToClient(Cursor.Position); set => throw new ArgumentException(); }
        public BasePresenter Presenter { private get; set; }
        public Image BackImage { get => BackgroundImage; set => BackgroundImage = value; }
        public LVLPresenter LVLPresenter { private get; set; }

        public event EventHandler MouseClick;

        public event EventHandler CountGathering;

        public event EventHandler CountFishMoves;

        public event PaintEventHandler RepaintScreen;

        public event KeyEventHandler KeyDOWN;

        public event KeyEventHandler KeyUP;

        public event EventHandler MainTimerTick;

        public event EventHandler BaitTimerTick;

        public event EventHandler FormClose;

        public event EventHandler DecSacietyTimerTick;
        
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
            UI.gui.Close();
        }

        private void DecrementSatiety_Tick(object sender, EventArgs e)
        {
            DecSacietyTimerTick?.Invoke(this, EventArgs.Empty);
        }

        private void SoundPlayerTimer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            string name = "day" + r.Next(1, 9).ToString();
            SoundPlayer player = new SoundPlayer(SoundsRes.ResourceManager.GetStream(name));
            player.Play();
        }
        
        public void UpdateForm()
        {
            this.Refresh();
        }
        public void StopBaitTimer()
        {
            baitTimer.Stop();
        }

        public void StartBaitTimer()
        {
            baitTimer.Start();
        }

        public void StartGatheringTimer()
        {
            GatheringTimer.Start();
        }

        public void StopGatheringTimer()
        {
            GatheringTimer.Stop();
        }

        public void CreateCurrentFish(Fish fish)
        {
            var f = new CurrentFish(fish);
            f.Show();
        }
        public void Open()
        {
            this.Show();
        }
        public void Down()
        {
            this.Close();
        }

        public void StopMainTimer()
        {
            mainTimerTick.Stop();
        }

        public void StartMainTimer()
        {
            mainTimerTick.Start();
        }

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClick?.Invoke(this, e);
        }

        public void StartFishMovesTimer()
        {
            fishMovestimer.Start();
        }

        public void StopFishMovesTimer()
        {
            fishMovestimer.Stop();
        }
    }
}