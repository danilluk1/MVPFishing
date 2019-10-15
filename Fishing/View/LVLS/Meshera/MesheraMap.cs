using Fishing.BL.Model.LVLS.Meshera;
using Fishing.BL.View;
using Fishing.View.DeepField;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing
{
    public partial class MesheraMap : Form, IMap
    {
        public MesheraMap()
        {
            InitializeComponent();
        }

        public Image BackImage { get => BackgroundImage; set => BackgroundImage = value; }

        public void Down()
        {
            this.Close();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lvl1Box_Click(object sender, EventArgs e)
        {
            Create(new LVL1());
        }
        public void Create(LVL lvl)
        {
            UI.gui = new UI(lvl);
            GameForm ozero = new GameForm();
            ozero.BackgroundImage = lvl.Image;
            DeepField field = new DeepField(lvl);
            ozero.Show();
            UI.gui.Show();
            this.Close();
        }

        private void Lvl2Box_Click(object sender, EventArgs e)
        {
            Create(new LVL2());
        }
    }

}
