using Fishing.BL;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    partial class MesheraMap
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
            ((System.ComponentModel.ISupportInitialize)(this.lvl1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2Box)).BeginInit();
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
            this.lvl1Box.Location = new System.Drawing.Point(134, 301);
            this.lvl1Box.Name = "lvl1Box";
            this.lvl1Box.Size = new System.Drawing.Size(22, 27);
            this.lvl1Box.TabIndex = 4;
            this.lvl1Box.TabStop = false;
            this.lvl1Box.Click += new System.EventHandler(this.Lvl1Box_Click);
            // 
            // lvl2Box
            // 
            this.lvl2Box.BackColor = System.Drawing.Color.Transparent;
            this.lvl2Box.BackgroundImage = global::Fishing.Properties.Resources.blackkrug;
            this.lvl2Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvl2Box.Location = new System.Drawing.Point(607, 551);
            this.lvl2Box.Name = "lvl2Box";
            this.lvl2Box.Size = new System.Drawing.Size(22, 27);
            this.lvl2Box.TabIndex = 5;
            this.lvl2Box.TabStop = false;
            this.lvl2Box.Click += new System.EventHandler(this.Lvl2Box_Click);
            // 
            // MesheraMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.MesheraMap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 768);
            this.Controls.Add(this.lvl2Box);
            this.Controls.Add(this.lvl1Box);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MesheraMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ozero";
            ((System.ComponentModel.ISupportInitialize)(this.lvl1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox lvl1Box;
        private System.Windows.Forms.PictureBox lvl2Box;
    }
}