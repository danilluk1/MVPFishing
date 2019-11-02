using Fishing.BL;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    partial class Map
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
            this.button1 = new System.Windows.Forms.Button();
            this.lvl1Box = new System.Windows.Forms.PictureBox();
            this.lvl2Box = new System.Windows.Forms.PictureBox();
            this.lvl3Box = new System.Windows.Forms.PictureBox();
            this.lvl4Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lvl1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl3Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl4Box)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(835, 742);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lvl1Box
            // 
            this.lvl1Box.BackColor = System.Drawing.Color.Transparent;
            this.lvl1Box.BackgroundImage = global::Fishing.Properties.Resources.blackkrug;
            this.lvl1Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvl1Box.Location = new System.Drawing.Point(813, 401);
            this.lvl1Box.Name = "lvl1Box";
            this.lvl1Box.Size = new System.Drawing.Size(22, 27);
            this.lvl1Box.TabIndex = 5;
            this.lvl1Box.TabStop = false;
            this.lvl1Box.Click += new System.EventHandler(this.Lvl1Box_Click);
            // 
            // lvl2Box
            // 
            this.lvl2Box.BackColor = System.Drawing.Color.Transparent;
            this.lvl2Box.BackgroundImage = global::Fishing.Properties.Resources.blackkrug;
            this.lvl2Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvl2Box.Location = new System.Drawing.Point(412, 357);
            this.lvl2Box.Name = "lvl2Box";
            this.lvl2Box.Size = new System.Drawing.Size(22, 27);
            this.lvl2Box.TabIndex = 6;
            this.lvl2Box.TabStop = false;
            this.lvl2Box.Click += new System.EventHandler(this.Lvl2Box_Click);
            // 
            // lvl3Box
            // 
            this.lvl3Box.BackColor = System.Drawing.Color.Transparent;
            this.lvl3Box.BackgroundImage = global::Fishing.Properties.Resources.blackkrug;
            this.lvl3Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvl3Box.Location = new System.Drawing.Point(121, 440);
            this.lvl3Box.Name = "lvl3Box";
            this.lvl3Box.Size = new System.Drawing.Size(22, 27);
            this.lvl3Box.TabIndex = 7;
            this.lvl3Box.TabStop = false;
            this.lvl3Box.Click += new System.EventHandler(this.Lvl3Box_Click);
            // 
            // lvl4Box
            // 
            this.lvl4Box.BackColor = System.Drawing.Color.Transparent;
            this.lvl4Box.BackgroundImage = global::Fishing.Properties.Resources.blackkrug;
            this.lvl4Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvl4Box.Location = new System.Drawing.Point(496, 569);
            this.lvl4Box.Name = "lvl4Box";
            this.lvl4Box.Size = new System.Drawing.Size(22, 27);
            this.lvl4Box.TabIndex = 8;
            this.lvl4Box.TabStop = false;
            this.lvl4Box.Click += new System.EventHandler(this.lvl4Box_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.ozero1f;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 768);
            this.Controls.Add(this.lvl4Box);
            this.Controls.Add(this.lvl3Box);
            this.Controls.Add(this.lvl2Box);
            this.Controls.Add(this.lvl1Box);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ozero";
            ((System.ComponentModel.ISupportInitialize)(this.lvl1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl3Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl4Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox lvl1Box;
        private System.Windows.Forms.PictureBox lvl2Box;
        private System.Windows.Forms.PictureBox lvl3Box;
        private System.Windows.Forms.PictureBox lvl4Box;
    }
}