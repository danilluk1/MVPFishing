﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fishing.Presenter;
using Fishing.View.Assembly;
using Fishing.View.GUI;
using Fishing.View.Inventory;
using Fishing.View.LureSelector;

namespace Fishing.Presenter
{
    class InventoryPresenter : Presenter
    {

        IInventory view;
        IGUIPresenter gui;
        public InventoryPresenter(IInventory view, IGUIPresenter gui)
        {
            if(Player.getPlayer().Assemblies.Count == 0)
            {
                AddAssembly add = new AddAssembly();
                add.Show();
            }
            this.gui = gui;
            this.view = view;
            view.LureDoubleClick += View_LureDoubleClick;
            view.LureSelectedIndexChanged += View_LureSelectedIndexChanged;
            view.ReelDoubleClick += View_ReelDoubleClick;
            view.ReelSelectedIndexChanged += View_ReelSelectedIndexChanged;
            view.RoadDoubleClick += View_RoadDoubleClick;
            view.RoadSelectedIndexChanged += View_RoadSelectedIndexChanged;
            view.FLineDoubleClick += View_FLineDoubleClick;
            view.FLineSelectedIndexChanged += View_FLineSelectedIndexChanged;
            view.CloseButtonClick += View_CloseButtonClick;
            view.FetchButtonClick += View_FetchButtonClick;
            view.AddButtonClick += View_AddButtonClick;
            view.AssemblyDoubleClick += View_AssemblyDoubleClick;
            view.MakeOutClick += View_MakeOutClick;
            view.BaitPicClick += View_BaitPicClick;
        }

        private void View_BaitPicClick(object sender, EventArgs e)
        {
            LureSelector selector = new LureSelector();
            selector.Show();
        }

        private void View_MakeOutClick(object sender, EventArgs e)
        {
            if (Player.getPlayer().Fline != null)
                Player.getPlayer().FLineInv.Add(view.Assembly_P.FLine);
            if (Player.getPlayer().Road != null)
                Player.getPlayer().RoadInv.Add(view.Assembly_P.Proad);
            if (Player.getPlayer().Lure != null)
                Player.getPlayer().LureInv.Add(Player.getPlayer().Lure);
            if (Player.getPlayer().Reel != null)
                Player.getPlayer().ReelInv.Add(Player.getPlayer().Reel);

            Player.getPlayer().Assemblies.Remove(view.Assembly_P);
        }

        private void View_AssemblyDoubleClick(object sender, EventArgs e)
        {
            view.showAssembly(view.Assembly_P);
            Player.getPlayer().setAssembly(view.Assembly_P);
            try
            {
                gui.BaitPicture = view.Assembly_P.Lure.Pict;
            }
            catch (NullReferenceException) { }
        }

        private void View_AddButtonClick(object sender, EventArgs e)
        {
            AddAssembly add = new AddAssembly();
            add.Show();
        }

        private void View_FetchButtonClick(object sender, EventArgs e)
        {
            if(view.FLine_P != null && view.Road_P != null && view.Reel_P != null && view.Lure_P != null)
            {
                view.Assembly_P.Proad = view.Road_P;
                Player.getPlayer().RoadInv.Remove(view.Road_P);

                view.Assembly_P.Reel = view.Reel_P;
                Player.getPlayer().ReelInv.Remove(view.Reel_P);

                view.Assembly_P.Lure = view.Lure_P;
                Player.getPlayer().LureInv.Remove(view.Lure_P);

                view.Assembly_P.FLine = view.FLine_P;
                Player.getPlayer().FLineInv.Remove(view.FLine_P);
            }
            else
            {
                MessageBox.Show("Выберите все элементы");
            }
        }

        private void View_CloseButtonClick(object sender, EventArgs e)
        {
            (sender as Inventory).Close();
        }

        private void View_FLineSelectedIndexChanged(object sender, EventArgs e)
        {
            view.addItemToRightView(view.FLine_P);
        }

        private void View_FLineDoubleClick(object sender, EventArgs e)
        {
            view.FLineText = view.FLine_P.Name;
        }

        private void View_RoadSelectedIndexChanged(object sender, EventArgs e)
        {
            view.addItemToRightView(view.Road_P);
        }

        private void View_RoadDoubleClick(object sender, EventArgs e)
        {
            view.RoadText = view.Road_P.Name;
        }

        private void View_ReelSelectedIndexChanged(object sender, EventArgs e)
        {
            view.addItemToRightView(view.Reel_P);
        }

        private void View_ReelDoubleClick(object sender, EventArgs e)
        {
            view.ReelText = view.Reel_P.Name;
        }

        private void View_LureSelectedIndexChanged(object sender, EventArgs e)
        {
            view.addItemToRightView(view.Lure_P);
        }

        private void View_LureDoubleClick(object sender, EventArgs e)
        {
            view.LureText = view.Lure_P.Name;
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
