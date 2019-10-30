using Fishing.BL;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.MapButton = new System.Windows.Forms.Button();
            this.ShopButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SettingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.InventoryButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapButton
            // 
            this.MapButton.BackColor = System.Drawing.Color.Transparent;
            this.MapButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MapButton.BackgroundImage")));
            this.MapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapButton.Location = new System.Drawing.Point(517, 31);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(120, 120);
            this.MapButton.TabIndex = 0;
            this.MapButton.UseVisualStyleBackColor = false;
            this.MapButton.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // ShopButton
            // 
            this.ShopButton.BackColor = System.Drawing.Color.Transparent;
            this.ShopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShopButton.BackgroundImage")));
            this.ShopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShopButton.Location = new System.Drawing.Point(47, 82);
            this.ShopButton.Name = "ShopButton";
            this.ShopButton.Size = new System.Drawing.Size(257, 69);
            this.ShopButton.TabIndex = 1;
            this.ShopButton.UseVisualStyleBackColor = false;
            this.ShopButton.Click += new System.EventHandler(this.ShopButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(542, 418);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(105, 34);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Выход";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SettingButton
            // 
            this.SettingButton.Location = new System.Drawing.Point(380, 418);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(105, 34);
            this.SettingButton.TabIndex = 3;
            this.SettingButton.Text = "Настройки";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 5;
            // 
            // InventoryButton
            // 
            this.InventoryButton.Location = new System.Drawing.Point(63, 332);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(241, 37);
            this.InventoryButton.TabIndex = 6;
            this.InventoryButton.Text = "Инвентарь";
            this.InventoryButton.UseVisualStyleBackColor = true;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(380, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 62);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(680, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ShopButton);
            this.Controls.Add(this.MapButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Button MapButton;
        protected internal System.Windows.Forms.Button ShopButton;
        protected internal System.Windows.Forms.Button CloseButton;
        protected internal System.Windows.Forms.Button InventoryButton;
        protected internal System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.Button button1;
    }
}