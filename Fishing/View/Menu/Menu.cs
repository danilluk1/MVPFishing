using Fishing.Presenter;
using Fishing.View;
using Fishing.View.Menu;
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
    public partial class Menu : Form, IMenu
    {
        public Menu()
        {
            InitializeComponent();
            presenter = new MenuPresenter(this);
            GUI.gui = new GUI();
        }
        MenuPresenter presenter;

        public string NickNameL { get => label2.Text; set => label2.Text = value; }

        public event EventHandler SettingsButtonClick;
        public event EventHandler InventoryButtonClick;
        public event EventHandler ShopButtonClick;
        public event EventHandler ExitButtonClick;
        public event EventHandler MapButtonClick;

        private void SettingButton_Click(object sender, EventArgs e)
        {
            SettingsButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            MapButtonClick?.Invoke(this, EventArgs.Empty);

        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            InventoryButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ExitButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Player.getPlayer().LureInv = Player.getPlayer().Load<BindingList<Lure>>("user.dat");
            label2.Text += "Игрок: " + Player.getPlayer().NickName + "                              " + Player.getPlayer().Money;
            Item.RoadShop.Add(Road.Titanium);
            Item.RoadShop.Add(Road.Achilles);
            Item.RoadShop.Add(Road.YSuperCarp);
            Item.RoadShop.Add(Road.SuperFisher);
            Item.ReelShop.Add(Reel.Hydra);
            Item.ReelShop.Add(Reel.SYBERIA_LT_2);
            Item.ReelShop.Add(Reel.Quest_Reel);
            Item.LeskaShop.Add(FLine.Quest_Fishers);
            Item.LeskaShop.Add(FLine.Colorado);
            Item.LeskaShop.Add(FLine.Indiana1500);
            Item.LeskaShop.Add(FLine.Atlantic);
            Item.ReelShop.Add(Reel.SYBERIA_4);
            Item.ReelShop.Add(Reel.Zymix);
            Item.ReelShop.Add(Reel.Syberia_1);
            Item.ReelShop.Add(Reel.TBR_4000);
        }
    }
}
