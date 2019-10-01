using Fishing.BL;
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
            GUI.gui = new GUI();
            ozero = new OzeroForm();
            this.Close();
            ozero.Show();
            ozero.BackgroundImage = Images.ozero1;
            GUI.gui.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

            GUI.gui = new GUI();
            ozero = new OzeroForm();
            this.Close();
            ozero.Show();
            ozero.BackgroundImage = Images.ozerolvl2;
            GUI.gui.Show();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
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
