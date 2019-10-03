using Fishing.BL;

namespace Fishing
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.DeepLabel = new System.Windows.Forms.Label();
            this.TextDeepLabel = new System.Windows.Forms.Label();
            this.SounderUpdater = new System.Windows.Forms.Timer(this.components);
            this.SounderPanel = new System.Windows.Forms.Panel();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.FpondBox = new System.Windows.Forms.PictureBox();
            this.LowerPanel = new System.Windows.Forms.Panel();
            this.LeskaLabel = new System.Windows.Forms.Label();
            this.ReelBar = new System.Windows.Forms.ProgressBar();
            this.RoadLabel = new System.Windows.Forms.Label();
            this.FLineBar = new System.Windows.Forms.ProgressBar();
            this.BaitsPicture = new System.Windows.Forms.PictureBox();
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.InventoryLabel = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.SettingLabel = new System.Windows.Forms.Label();
            this.MapLabel = new System.Windows.Forms.Label();
            this.StatisticLabel = new System.Windows.Forms.Label();
            this.eventsList = new System.Windows.Forms.ImageList(this.components);
            this.sounderBack = new System.Windows.Forms.Panel();
            this.eventsView = new System.Windows.Forms.ListView();
            this.SounderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpondBox)).BeginInit();
            this.LowerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaitsPicture)).BeginInit();
            this.UpperPanel.SuspendLayout();
            this.sounderBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeepLabel
            // 
            this.DeepLabel.AutoSize = true;
            this.DeepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeepLabel.ForeColor = System.Drawing.Color.Red;
            this.DeepLabel.Location = new System.Drawing.Point(135, 99);
            this.DeepLabel.Name = "DeepLabel";
            this.DeepLabel.Size = new System.Drawing.Size(19, 20);
            this.DeepLabel.TabIndex = 18;
            this.DeepLabel.Text = "0";
            // 
            // TextDeepLabel
            // 
            this.TextDeepLabel.AutoSize = true;
            this.TextDeepLabel.Location = new System.Drawing.Point(78, 104);
            this.TextDeepLabel.Name = "TextDeepLabel";
            this.TextDeepLabel.Size = new System.Drawing.Size(51, 13);
            this.TextDeepLabel.TabIndex = 21;
            this.TextDeepLabel.Text = "Глубина:";
            // 
            // SounderUpdater
            // 
            this.SounderUpdater.Enabled = true;
            this.SounderUpdater.Interval = 10;
            this.SounderUpdater.Tick += new System.EventHandler(this.SounderUpdater_Tick);
            // 
            // SounderPanel
            // 
            this.SounderPanel.BackColor = System.Drawing.Color.Wheat;
            this.SounderPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SounderPanel.Controls.Add(this.TextDeepLabel);
            this.SounderPanel.Controls.Add(this.DeepLabel);
            this.SounderPanel.Location = new System.Drawing.Point(5, 3);
            this.SounderPanel.Name = "SounderPanel";
            this.SounderPanel.Size = new System.Drawing.Size(171, 120);
            this.SounderPanel.TabIndex = 22;
            this.SounderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SounderPanel_Paint);
            // 
            // SpeedBar
            // 
            this.SpeedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.SpeedBar.Cursor = System.Windows.Forms.Cursors.Cross;
            this.SpeedBar.LargeChange = 1;
            this.SpeedBar.Location = new System.Drawing.Point(0, 280);
            this.SpeedBar.Minimum = 1;
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SpeedBar.Size = new System.Drawing.Size(45, 240);
            this.SpeedBar.TabIndex = 22;
            this.SpeedBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.SpeedBar.Value = 1;
            // 
            // FpondBox
            // 
            this.FpondBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FpondBox.BackgroundImage")));
            this.FpondBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FpondBox.Location = new System.Drawing.Point(934, 151);
            this.FpondBox.Name = "FpondBox";
            this.FpondBox.Size = new System.Drawing.Size(99, 96);
            this.FpondBox.TabIndex = 23;
            this.FpondBox.TabStop = false;
            this.FpondBox.Click += new System.EventHandler(this.FpondBox_Click);
            // 
            // LowerPanel
            // 
            this.LowerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LowerPanel.BackgroundImage")));
            this.LowerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LowerPanel.Controls.Add(this.LeskaLabel);
            this.LowerPanel.Controls.Add(this.ReelBar);
            this.LowerPanel.Controls.Add(this.RoadLabel);
            this.LowerPanel.Controls.Add(this.FLineBar);
            this.LowerPanel.Controls.Add(this.BaitsPicture);
            this.LowerPanel.Location = new System.Drawing.Point(0, 619);
            this.LowerPanel.Name = "LowerPanel";
            this.LowerPanel.Size = new System.Drawing.Size(415, 97);
            this.LowerPanel.TabIndex = 20;
            // 
            // LeskaLabel
            // 
            this.LeskaLabel.AutoSize = true;
            this.LeskaLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.LeskaLabel.Location = new System.Drawing.Point(269, 56);
            this.LeskaLabel.Name = "LeskaLabel";
            this.LeskaLabel.Size = new System.Drawing.Size(39, 13);
            this.LeskaLabel.TabIndex = 17;
            this.LeskaLabel.Text = "Леска";
            // 
            // ReelBar
            // 
            this.ReelBar.Location = new System.Drawing.Point(12, 27);
            this.ReelBar.MarqueeAnimationSpeed = 1;
            this.ReelBar.Name = "ReelBar";
            this.ReelBar.Size = new System.Drawing.Size(239, 23);
            this.ReelBar.Step = 1;
            this.ReelBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ReelBar.TabIndex = 14;
            // 
            // RoadLabel
            // 
            this.RoadLabel.AutoSize = true;
            this.RoadLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.RoadLabel.Location = new System.Drawing.Point(269, 37);
            this.RoadLabel.Name = "RoadLabel";
            this.RoadLabel.Size = new System.Drawing.Size(44, 13);
            this.RoadLabel.TabIndex = 16;
            this.RoadLabel.Text = "Удочка";
            // 
            // FLineBar
            // 
            this.FLineBar.Location = new System.Drawing.Point(12, 56);
            this.FLineBar.MarqueeAnimationSpeed = 1;
            this.FLineBar.Name = "FLineBar";
            this.FLineBar.Size = new System.Drawing.Size(239, 23);
            this.FLineBar.Step = 1;
            this.FLineBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.FLineBar.TabIndex = 15;
            // 
            // BaitsPicture
            // 
            this.BaitsPicture.BackColor = System.Drawing.Color.Transparent;
            this.BaitsPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BaitsPicture.Location = new System.Drawing.Point(319, 15);
            this.BaitsPicture.Name = "BaitsPicture";
            this.BaitsPicture.Size = new System.Drawing.Size(74, 64);
            this.BaitsPicture.TabIndex = 19;
            this.BaitsPicture.TabStop = false;
            this.BaitsPicture.Click += new System.EventHandler(this.BaitsPicture_Click);
            // 
            // UpperPanel
            // 
            this.UpperPanel.BackColor = System.Drawing.Color.Transparent;
            this.UpperPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpperPanel.BackgroundImage")));
            this.UpperPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpperPanel.Controls.Add(this.MenuLabel);
            this.UpperPanel.Controls.Add(this.InventoryLabel);
            this.UpperPanel.Controls.Add(this.MoneyLabel);
            this.UpperPanel.Controls.Add(this.SettingLabel);
            this.UpperPanel.Controls.Add(this.MapLabel);
            this.UpperPanel.Location = new System.Drawing.Point(0, 0);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(536, 41);
            this.UpperPanel.TabIndex = 11;
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.BackColor = System.Drawing.Color.Transparent;
            this.MenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuLabel.Location = new System.Drawing.Point(229, 9);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(74, 25);
            this.MenuLabel.TabIndex = 15;
            this.MenuLabel.Text = "Меню";
            this.MenuLabel.Click += new System.EventHandler(this.MenuLabel_Click);
            // 
            // InventoryLabel
            // 
            this.InventoryLabel.AutoSize = true;
            this.InventoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.InventoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InventoryLabel.Location = new System.Drawing.Point(95, 9);
            this.InventoryLabel.Name = "InventoryLabel";
            this.InventoryLabel.Size = new System.Drawing.Size(128, 25);
            this.InventoryLabel.TabIndex = 14;
            this.InventoryLabel.Text = "Инвентарь";
            this.InventoryLabel.Click += new System.EventHandler(this.InventoryLabel_Click);
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoneyLabel.Location = new System.Drawing.Point(457, 18);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(0, 13);
            this.MoneyLabel.TabIndex = 13;
            // 
            // SettingLabel
            // 
            this.SettingLabel.AutoSize = true;
            this.SettingLabel.BackColor = System.Drawing.Color.Transparent;
            this.SettingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingLabel.Location = new System.Drawing.Point(309, 9);
            this.SettingLabel.Name = "SettingLabel";
            this.SettingLabel.Size = new System.Drawing.Size(128, 25);
            this.SettingLabel.TabIndex = 12;
            this.SettingLabel.Text = "Настройки";
            this.SettingLabel.Click += new System.EventHandler(this.SettingLabel_Click);
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.BackColor = System.Drawing.Color.Transparent;
            this.MapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapLabel.Location = new System.Drawing.Point(12, 9);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(77, 25);
            this.MapLabel.TabIndex = 11;
            this.MapLabel.Text = "Карта";
            this.MapLabel.Click += new System.EventHandler(this.MapLabel_Click);
            // 
            // StatisticLabel
            // 
            this.StatisticLabel.AutoSize = true;
            this.StatisticLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatisticLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticLabel.Location = new System.Drawing.Point(700, 124);
            this.StatisticLabel.Name = "StatisticLabel";
            this.StatisticLabel.Size = new System.Drawing.Size(137, 25);
            this.StatisticLabel.TabIndex = 16;
            this.StatisticLabel.Text = "Статистика";
            this.StatisticLabel.Click += new System.EventHandler(this.StatisticLabel_Click);
            // 
            // eventsList
            // 
            this.eventsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("eventsList.ImageStream")));
            this.eventsList.TransparentColor = System.Drawing.Color.Transparent;
            this.eventsList.Images.SetKeyName(0, "break.png");
            this.eventsList.Images.SetKeyName(1, "hvastun.png");
            this.eventsList.Images.SetKeyName(2, "spoon.png");
            this.eventsList.Images.SetKeyName(3, "vert.png");
            this.eventsList.Images.SetKeyName(4, "deepvobler.png");
            this.eventsList.Images.SetKeyName(5, "sriv.png");
            // 
            // sounderBack
            // 
            this.sounderBack.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.sounderBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sounderBack.Controls.Add(this.SounderPanel);
            this.sounderBack.Location = new System.Drawing.Point(854, 0);
            this.sounderBack.Name = "sounderBack";
            this.sounderBack.Size = new System.Drawing.Size(179, 126);
            this.sounderBack.TabIndex = 24;
            // 
            // eventsView
            // 
            this.eventsView.BackColor = System.Drawing.Color.Wheat;
            this.eventsView.Location = new System.Drawing.Point(542, 0);
            this.eventsView.Name = "eventsView";
            this.eventsView.Scrollable = false;
            this.eventsView.Size = new System.Drawing.Size(311, 126);
            this.eventsView.SmallImageList = this.eventsList;
            this.eventsView.StateImageList = this.eventsList;
            this.eventsView.TabIndex = 23;
            this.eventsView.UseCompatibleStateImageBehavior = false;
            this.eventsView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1033, 716);
            this.ControlBox = false;
            this.Controls.Add(this.eventsView);
            this.Controls.Add(this.sounderBack);
            this.Controls.Add(this.StatisticLabel);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.FpondBox);
            this.Controls.Add(this.LowerPanel);
            this.Controls.Add(this.UpperPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baits";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.SounderPanel.ResumeLayout(false);
            this.SounderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpondBox)).EndInit();
            this.LowerPanel.ResumeLayout(false);
            this.LowerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaitsPicture)).EndInit();
            this.UpperPanel.ResumeLayout(false);
            this.UpperPanel.PerformLayout();
            this.sounderBack.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel UpperPanel;
        protected internal System.Windows.Forms.Label InventoryLabel;
        protected internal System.Windows.Forms.Label MoneyLabel;
        protected internal System.Windows.Forms.Label MapLabel;
        protected internal System.Windows.Forms.ProgressBar ReelBar;
        protected internal System.Windows.Forms.ProgressBar FLineBar;
        protected internal System.Windows.Forms.Label LeskaLabel;
        protected internal System.Windows.Forms.Label MenuLabel;
        protected internal System.Windows.Forms.PictureBox BaitsPicture;
        private System.Windows.Forms.Panel LowerPanel;
        protected internal System.Windows.Forms.Label RoadLabel;
        protected internal System.Windows.Forms.Label DeepLabel;
        protected internal System.Windows.Forms.TrackBar SpeedBar;
        protected internal System.Windows.Forms.Timer SounderUpdater;
        protected internal System.Windows.Forms.Panel SounderPanel;
        protected internal System.Windows.Forms.Label SettingLabel;
        protected internal System.Windows.Forms.Label TextDeepLabel;
        protected internal System.Windows.Forms.PictureBox FpondBox;
        protected internal System.Windows.Forms.Label StatisticLabel;
        private System.Windows.Forms.ImageList eventsList;
        private System.Windows.Forms.Panel sounderBack;
        private System.Windows.Forms.ListView eventsView;
    }
}