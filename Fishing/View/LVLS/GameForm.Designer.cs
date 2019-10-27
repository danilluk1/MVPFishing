namespace Fishing
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.baitTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTimerTick = new System.Windows.Forms.Timer(this.components);
            this.fishMovestimer = new System.Windows.Forms.Timer(this.components);
            this.GatheringTimer = new System.Windows.Forms.Timer(this.components);
            this.soundPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.decrementSatiety = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // baitTimer
            // 
            this.baitTimer.Interval = 500;
            this.baitTimer.Tick += new System.EventHandler(this.BaitTimer_Tick);
            // 
            // mainTimerTick
            // 
            this.mainTimerTick.Enabled = true;
            this.mainTimerTick.Interval = 15;
            this.mainTimerTick.Tick += new System.EventHandler(this.MainTaskstimer_Tick);
            // 
            // fishMovestimer
            // 
            this.fishMovestimer.Enabled = true;
            this.fishMovestimer.Interval = 1200;
            this.fishMovestimer.Tick += new System.EventHandler(this.FishMovestimer_Tick);
            // 
            // GatheringTimer
            // 
            this.GatheringTimer.Interval = 1500;
            this.GatheringTimer.Tick += new System.EventHandler(this.GatheringTimer_Tick);
            // 
            // soundPlayerTimer
            // 
            this.soundPlayerTimer.Enabled = true;
            this.soundPlayerTimer.Interval = 30000;
            this.soundPlayerTimer.Tick += new System.EventHandler(this.SoundPlayerTimer_Tick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 15;
            // 
            // decrementSatiety
            // 
            this.decrementSatiety.Enabled = true;
            this.decrementSatiety.Interval = 30000;
            this.decrementSatiety.Tick += new System.EventHandler(this.DecrementSatiety_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fishing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OzeroForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OzeroForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OzeroForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OzeroForm_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OzeroForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        protected internal System.Windows.Forms.Timer mainTimerTick;
        protected internal System.Windows.Forms.Timer fishMovestimer;
        protected internal System.Windows.Forms.Timer baitTimer;
        protected internal System.Windows.Forms.Timer GatheringTimer;
        private System.Windows.Forms.Timer soundPlayerTimer;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer decrementSatiety;
    }
}

