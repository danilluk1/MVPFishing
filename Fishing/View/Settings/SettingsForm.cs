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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (nameBox.Text != null)
            {
                Player.GetPlayer().NickName = nameBox.Text;
                MessageBox.Show("Успешно");
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {          
            this.Close();
        }
    }
}
