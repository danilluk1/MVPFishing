using Fishing.View.GUI;
using Fishing.View.Inventory;
using System;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class InventoryPresenter : BasePresenter
    {
        private IInventory view;
        private IGUIPresenter gui;
        private int index = 1;

        public InventoryPresenter(IInventory view)
        {
            this.view = view;
            view.Presenter = this;

            view.AssNumbText = index.ToString();

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
            view.AssemblyDoubleClick += View_AssemblyDoubleClick;
            view.MakeOutClick += View_MakeOutClick;
            view.SRoadButttonClick += View_SRoadButttonClick;
            view.FRoadButttonClick += View_FRoadButttonClick;
            view.TRoadButttonClick += View_TRoadButttonClick;

            view.Open();
        }

        private void View_TRoadButttonClick(object sender, EventArgs e)
        {
            index = 3;
            view.AssNumbText = index.ToString();
        }

        private void View_FRoadButttonClick(object sender, EventArgs e)
        {
            index = 1;
            view.AssNumbText = index.ToString();
        }

        private void View_SRoadButttonClick(object sender, EventArgs e)
        {
            index = 2;
            view.AssNumbText = index.ToString();
        }

        public InventoryPresenter(IInventory view, IGUIPresenter gui)
        {
            this.view = view;
            this.gui = gui;
            view.Presenter = this;

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
            view.AssemblyDoubleClick += View_AssemblyDoubleClick;
            view.MakeOutClick += View_MakeOutClick;
            view.SRoadButttonClick += View_SRoadButttonClick;
            view.FRoadButttonClick += View_FRoadButttonClick;
            view.TRoadButttonClick += View_TRoadButttonClick;

            view.Open();
        }

        private void View_MakeOutClick(object sender, EventArgs e)
        {
            try
            {
                if (Player.GetPlayer().EquipedRoad.Assembly.FLine != null)
                    Player.GetPlayer().FLineInv.Add(view.Assembly_P.FLine);
                if (Player.GetPlayer().EquipedRoad.Assembly.Proad != null)
                    Player.GetPlayer().RoadInv.Add(view.Assembly_P.Proad);
                if (Player.GetPlayer().EquipedRoad.Assembly.Lure != null)
                    Player.GetPlayer().LureInv.Add(view.Assembly_P.Lure);
                if (Player.GetPlayer().EquipedRoad.Assembly.Reel != null)
                    Player.GetPlayer().ReelInv.Add(view.Assembly_P.Reel);

                Player.GetPlayer().Assemblies.Remove(view.Assembly_P);
            }
            catch (NullReferenceException) { }
        }

        private void View_AssemblyDoubleClick(object sender, EventArgs e)
        {
            view.ShowAssembly(view.Assembly_P);
            try
            {

                    Player.GetPlayer().SetGameRoad(view.Assembly_P, index);
                    Player.GetPlayer().SetEquipedRoad(index);
                    view.Assembly_P.IsEquiped = true;
                    gui.BaitPicture = view.Assembly_P.Lure.Pict;
                    gui.RoadPicture = view.Assembly_P.Proad.Pict;
                    gui.ReelPicture = view.Assembly_P.Reel.Pict;
                    gui.FLinePicture = view.Assembly_P.FLine.Pict;
            }
            catch (NullReferenceException) { }
        }

        private void View_FetchButtonClick(object sender, EventArgs e)
        {
            if (view.FLine_P != null && view.Road_P != null && view.Reel_P != null && view.Lure_P != null)
            {
                view.Assembly_P.Proad = view.Road_P;
                Player.GetPlayer().RoadInv.Remove(view.Road_P);

                view.Assembly_P.Reel = view.Reel_P;
                Player.GetPlayer().ReelInv.Remove(view.Reel_P);

                view.Assembly_P.Lure = view.Lure_P;
                Player.GetPlayer().LureInv.Remove(view.Lure_P);

                view.Assembly_P.FLine = view.FLine_P;
                Player.GetPlayer().FLineInv.Remove(view.FLine_P);
            }
        }

        private void View_CloseButtonClick(object sender, EventArgs e)
        {
            view.Down();
        }

        private void View_FLineSelectedIndexChanged(object sender, EventArgs e)
        {
            view.AddItemToRightView(view.FLine_P);
        }

        private void View_FLineDoubleClick(object sender, EventArgs e)
        {
            view.FLineText = view.FLine_P.Name;
        }

        private void View_RoadSelectedIndexChanged(object sender, EventArgs e)
        {
            view.AddItemToRightView(view.Road_P);
        }

        private void View_RoadDoubleClick(object sender, EventArgs e)
        {
            view.RoadText = view.Road_P.Name;
        }

        private void View_ReelSelectedIndexChanged(object sender, EventArgs e)
        {
            view.AddItemToRightView(view.Reel_P);
        }

        private void View_ReelDoubleClick(object sender, EventArgs e)
        {
            view.ReelText = view.Reel_P.Name;
        }

        private void View_LureSelectedIndexChanged(object sender, EventArgs e)
        {
            view.AddItemToRightView(view.Lure_P);
        }

        private void View_LureDoubleClick(object sender, EventArgs e)
        {
            view.LureText = view.Lure_P.Name;
        }
    }
}