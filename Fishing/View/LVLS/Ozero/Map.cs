using Fishing.BL;
using Fishing.BL.Model;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.LVLS.Ozero;
using Fishing.BL.Model.Waters;
using Fishing.BL.Resources.Images;
using Fishing.BL.View;
using Fishing.View.DeepField;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
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
            GameForm ozero = new GameForm(lvl);
            ozero.BackgroundImage = lvl.Image;
            DeepField field = new DeepField(lvl);
            ozero.Show();
            UI.gui.Show();
            this.Close();
        }
    }

}
