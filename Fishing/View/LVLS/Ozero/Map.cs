using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS.Ozero;
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
        }

        public Image BackImage { get => BackgroundImage; set => BackgroundImage = value; }

        public void Open()
        {
            Map map = new Map();
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
            LVLPresenter presenter = new LVLPresenter(Game.GetGame().View, UI.gui, lvl);
            DeepField field = new DeepField(lvl);
            UI.gui.Show();
            this.Close();
        }
    }
}