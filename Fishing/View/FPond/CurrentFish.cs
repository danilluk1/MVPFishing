using Fishing.View;
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
    public partial class CurrentFish : Form
    {
        public CurrentFish()
        {
            InitializeComponent();
        }

        private void CurrentFish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Player.getPlayer().addFish(Player.getPlayer().CFish);
                this.Close();
            }
            if(e.KeyCode == Keys.F)
            {
                if (PriceButton.Text.Length > 0)
                {
                    Player.getPlayer().SellFish(Player.getPlayer().CFish);
                    GUI.gui.MoneyLabel.Text = Player.getPlayer().Money.ToString();
                    MessageBox.Show("Продано");
                    this.Close();
                }
            }

        }

        private void PriceButton_Click(object sender, EventArgs e)
        {

        }
    }
}
