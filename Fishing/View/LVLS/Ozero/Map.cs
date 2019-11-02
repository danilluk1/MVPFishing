using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS.Ozero;
using Fishing.BL.Resources.Images;
using Fishing.BL.View;
using Fishing.Presenter;
using Fishing.View.DeepField;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing
{
    public partial class Map : Form, IMap
    {
        public static GameForm ozero;

        public Map()
        {
            InitializeComponent();
            BackgroundImage = Game.GetGame().CurrentWater.MapImage;
            foreach (var p in Game.GetGame().CurrentWater.Locs)
            {
                MessageBox.Show("");
                PictureBox box = new PictureBox()
                {
                    Left = p.Left,
                    Top = p.Top,
                    Width = p.Width,
                    Height = p.Height,
                    BackgroundImage = Images.blackkrug,
                    BackColor = Color.Transparent,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = p.LocName,
                    BorderStyle = BorderStyle.None,

                };
                Controls.Add(box);
            }
        }

        public Image BackImage { get => BackgroundImage; set => BackgroundImage = value; }

        public void Open()
        {
            this.Show();
        }

        public void Down()
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lvl1Box_Click(object sender, EventArgs e)
        {
            Create(new LVL1());
        }

        private void Lvl2Box_Click(object sender, EventArgs e)
        {
            Create(new LVL2());
        }

        private void Lvl3Box_Click(object sender, EventArgs e)
        {
            Create(new LVL3());
        }

        public void Create(LVL lvl)
        {
            UI.gui = new UI(lvl);
            Game.GetGame().View = new GameForm();
            var presenter = new LVLPresenter(Game.GetGame().View, UI.gui, lvl);
            var field = new DeepField(lvl);
            UI.gui.Show();
            this.Close();
        }

        private void lvl4Box_Click(object sender, EventArgs e)
        {
            Create(new LVL4());
        }
    }
}