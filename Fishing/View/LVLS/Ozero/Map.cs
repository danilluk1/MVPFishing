using Fishing.BL;
using Fishing.BL.Model;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing
{
    public partial class Ozero : Form
    {
        public static OzeroForm ozero;
        public Ozero()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            GUI.gui = new GUI(LVL1.GetLVL());
            ozero = new OzeroForm(LVL1.GetLVL());
            ozero.BackgroundImage = LVL1.GetLVL().Image;
            this.Close();
            ozero.Show();
            GUI.gui.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

            GUI.gui = new GUI(LVL2.GetLVL());
            ozero = new OzeroForm(LVL2.GetLVL());
            ozero.BackgroundImage = LVL2.GetLVL().Image;
            this.Close();
            ozero.Show();
            GUI.gui.Show();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            GUI.gui = new GUI(LVL3.GetLVL());
            ozero = new OzeroForm(LVL3.GetLVL());
            ozero.BackgroundImage = LVL3.GetLVL().Image;
            this.Close();
            ozero.Show();
            GUI.gui.Show();
        }

        private void Ozero_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
