using Fishing.BL;

namespace Fishing
{
    partial class fishesForm
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
            this.FishList = new System.Windows.Forms.ListBox();
            this.FishImage = new System.Windows.Forms.PictureBox();
            this.SellButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.fishDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FishImage)).BeginInit();
            this.SuspendLayout();
            // 
            // FishList
            // 
            this.FishList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.FishList.FormattingEnabled = true;
            this.FishList.Location = new System.Drawing.Point(13, 52);
            this.FishList.Name = "FishList";
            this.FishList.Size = new System.Drawing.Size(276, 420);
            this.FishList.TabIndex = 0;
            this.FishList.SelectedIndexChanged += new System.EventHandler(this.FishList_SelectedIndexChanged);
            // 
            // FishImage
            // 
            this.FishImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.FishImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FishImage.Location = new System.Drawing.Point(305, 52);
            this.FishImage.Name = "FishImage";
            this.FishImage.Size = new System.Drawing.Size(405, 209);
            this.FishImage.TabIndex = 1;
            this.FishImage.TabStop = false;
            // 
            // SellButton
            // 
            this.SellButton.BackgroundImage = Images.layer2;
            this.SellButton.Location = new System.Drawing.Point(305, 497);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(157, 36);
            this.SellButton.TabIndex = 2;
            this.SellButton.Text = "Продать";
            this.SellButton.UseVisualStyleBackColor = true;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = Images.layer2;
            this.CloseButton.Location = new System.Drawing.Point(581, 497);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(140, 36);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // fishDescription
            // 
            this.fishDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.fishDescription.Location = new System.Drawing.Point(305, 268);
            this.fishDescription.Name = "fishDescription";
            this.fishDescription.Size = new System.Drawing.Size(405, 204);
            this.fishDescription.TabIndex = 4;
            this.fishDescription.Text = "";
            // 
            // fishesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Images.layer2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(733, 545);
            this.Controls.Add(this.fishDescription);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SellButton);
            this.Controls.Add(this.FishImage);
            this.Controls.Add(this.FishList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fishesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fishesForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FishesForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FishesForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FishImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox FishImage;
        public System.Windows.Forms.ListBox FishList;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.RichTextBox fishDescription;
    }
}