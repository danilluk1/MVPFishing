namespace Fishing.View.LureSelector
{
    partial class LureSelector
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
            this.lureList = new System.Windows.Forms.ListBox();
            this.lureImage = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lureList
            // 
            this.lureList.FormattingEnabled = true;
            this.lureList.Location = new System.Drawing.Point(2, 2);
            this.lureList.Name = "lureList";
            this.lureList.Size = new System.Drawing.Size(150, 173);
            this.lureList.TabIndex = 0;
            this.lureList.SelectedIndexChanged += new System.EventHandler(this.LureList_SelectedIndexChanged);
            this.lureList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LureList_MouseDoubleClick);
            // 
            // lureImage
            // 
            this.lureImage.Location = new System.Drawing.Point(159, 2);
            this.lureImage.Name = "lureImage";
            this.lureImage.Size = new System.Drawing.Size(122, 88);
            this.lureImage.TabIndex = 1;
            this.lureImage.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(159, 97);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(122, 20);
            this.nameBox.TabIndex = 2;
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(159, 124);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(122, 20);
            this.typeBox.TabIndex = 3;
            // 
            // LureSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 181);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.lureImage);
            this.Controls.Add(this.lureList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LureSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LureSelector";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.LureSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lureList;
        private System.Windows.Forms.PictureBox lureImage;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox typeBox;
    }
}