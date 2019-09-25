namespace Fishing
{
    partial class OzeroForm
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
            this.mainTaskstimer = new System.Windows.Forms.Timer(this.components);
            this.fishMovestimer = new System.Windows.Forms.Timer(this.components);
            this.GatheringTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // baitTimer
            // 
            this.baitTimer.Interval = 500;
            this.baitTimer.Tick += new System.EventHandler(this.BaitTimer_Tick);
            // 
            // mainTaskstimer
            // 
            this.mainTaskstimer.Enabled = true;
            this.mainTaskstimer.Interval = 25;
            this.mainTaskstimer.Tick += new System.EventHandler(this.MainTaskstimer_Tick);
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
            // OzeroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1033, 716);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OzeroForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fishing";
            this.Load += new System.EventHandler(this.OzeroForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OzeroForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OzeroForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OzeroForm_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OzeroForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        protected internal System.Windows.Forms.Timer mainTaskstimer;
        protected internal System.Windows.Forms.Timer fishMovestimer;
        protected internal System.Windows.Forms.Timer baitTimer;
        protected internal System.Windows.Forms.Timer GatheringTimer;
    }
}

