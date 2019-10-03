using Fishing.View;
using Fishing.View.Menu;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class MenuPresenter : Presenter
    {
        private readonly IMenu view;
        public MenuPresenter(IMenu view)
        {
            
            this.view = view;
            view.InventoryButtonClick += View_InventoryButtonClick;
            view.SettingsButtonClick += View_SettingsButtonClick;
            view.ShopButtonClick += View_ShopButtonClick;
            view.ExitButtonClick += View_ExitButtonClick;
            view.MapButtonClick += View_MapButtonClick;
            view.MenuLoad += Menu_Load;
            BaseController.GetController().Initiallize();
        }

        private void View_MapButtonClick(object sender, EventArgs e)
        {
        }

        private void View_ExitButtonClick(object sender, EventArgs e)
        {
            BaseController.GetController().SavePlayer();
            Application.Exit();
        }

        private void View_ShopButtonClick(object sender, EventArgs e)
        {
        }

        private void View_SettingsButtonClick(object sender, EventArgs e)
        {
        }

        private void View_InventoryButtonClick(object sender, EventArgs e)
        {
        }

        public void Load()
        {          
        }

        public void Close()
        {
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            view.lowerLValue += "Игрок: " + Player.GetPlayer().NickName + "                              " + Player.GetPlayer().Money;
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
            Player.GetPlayer().LureInv.Add(Lure.vob1);
            Player.GetPlayer().LureInv.Add(Lure.vob3);
            Player.GetPlayer().LureInv.Add(Lure.vob2);
            Player.GetPlayer().LureInv.Add(Lure.vob4);
            Player.GetPlayer().LureInv.Add(Lure.vert1);
            Player.GetPlayer().LureInv.Add(Lure.jelezo1);
            Player.GetPlayer().LureInv.Add(Lure.jelezo2);
            Player.GetPlayer().LureInv.Add(Lure.jig1);
        }

    }
}
