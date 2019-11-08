using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Lures;
using Fishing.BL.Model.Items;
using Fishing.Presenter;
using Fishing.View.Assembly;
using Fishing.View.Inventory;
using Fishing.View.LureSelector;
using Fishing.View.LureSelector.Presenter;
using System;
using System.Windows.Forms;

namespace Fishing
{
    public partial class Inventory : Form, IInventory
    {
        public Inventory()
        {
            InitializeComponent();
            if (Player.GetPlayer().Assemblies.Count == 0)
            {
                AddAssembly add = new AddAssembly();
                add.Show();
            }
            if(Player.GetPlayer().FirstRoad != null)
            {
                fRoadButton.Enabled = true;
            }
            if (Player.GetPlayer().SecondRoad != null)
            {
                sRoadButton.Enabled = true;
            }
            if (Player.GetPlayer().ThirdRoad != null)
            {
                tRoadButton.Enabled = true;
            }
            FLineList.DataSource = Player.GetPlayer().FLineInv;
            ReelsList.DataSource = Player.GetPlayer().ReelInv;
            baitsBox.DataSource = Player.GetPlayer().BaitInv;
            hooksBox.DataSource = Player.GetPlayer().HooksInv;
            foreach (Road r in Player.GetPlayer().RoadInv)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = r.Name;
                if (r is Spinning)
                {
                    lvi.ImageIndex = roadsList.Images.IndexOfKey("shop_but02.png");
                }
                if(r is Float)
                {
                    lvi.ImageIndex = roadsList.Images.IndexOfKey("shop_but01.png");
                }
                if (r is Feeder)
                {
                    lvi.ImageIndex = roadsList.Images.IndexOfKey("rm_but01.png");
                }
                roadsView.Items.Add(lvi);
            }
            foreach (Lure l in Player.GetPlayer().LureInv)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = l.Name;
                if (l is Shaker)
                {
                    lvi.ImageIndex = lureList.Images.IndexOfKey("spoon.png");
                }
                if (l is Pinwheel)
                {
                    lvi.ImageIndex = lureList.Images.IndexOfKey("vert.png");
                }
                if (l is Wobbler)
                {
                    lvi.ImageIndex = lureList.Images.IndexOfKey("vob.png");
                }
                if (l is Jig)
                {
                    lvi.ImageIndex = lureList.Images.IndexOfKey("vibro.png");
                }
                luresView.Items.Add(lvi);
            }
            assembliesBox.DataSource = Player.GetPlayer().Assemblies;
        }
        public Road Road_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().RoadInv[roadsView.SelectedIndices[0]];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        public Reel Reel_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().ReelInv[ReelsList.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        public FLine FLine_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().FLineInv[FLineList.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        public Lure Lure_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().LureInv[luresView.SelectedIndices[0]];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        public Assembly Assembly_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().Assemblies[assembliesBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }
        public Bait Bait_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().BaitInv[baitsBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }
        public BaseHook Hook_P
        {
            get
            {
                try
                {
                    return Player.GetPlayer().HooksInv[hooksBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }

        public string RoadText { get => roadTextBox.Text; set => roadTextBox.Text = value; }
        public string ReelText { get => reelTextBox.Text; set => reelTextBox.Text = value; }
        public string FLineText { get => flineTextBox.Text; set => flineTextBox.Text = value; }
        public string LureText { get => lureTextBox.Text; set => lureTextBox.Text = value; }
        public BasePresenter Presenter { private get; set; }
        public string AssNumbText { get => assNumberLabel.Text; set => assNumberLabel.Text = value; }
        public int RoadWearValue { get => roadWearBar.Value; set => roadWearBar.Value = value; }
        public int ReelWearMax { get => reelWearBar.Maximum; set => reelWearBar.Maximum = value; }
        public int ReelWearValue { get => reelWearBar.Value; set => reelWearBar.Value = value; }

        public event EventHandler FLineSelectedIndexChanged;

        public event EventHandler RoadSelectedIndexChanged;

        public event EventHandler ReelSelectedIndexChanged;

        public event EventHandler LureSelectedIndexChanged;

        public event EventHandler FLineDoubleClick;

        public event EventHandler RoadDoubleClick;

        public event EventHandler ReelDoubleClick;

        public event EventHandler LureDoubleClick;

        public event EventHandler CloseButtonClick;

        public event EventHandler FetchButtonClick;

        public event EventHandler AssemblyDoubleClick;

        public event EventHandler MakeOutClick;

        public event EventHandler BaitDoubleClick;
        public event EventHandler BaitSelectedIndexChanged;
        public event EventHandler HookDoubleClick;
        public event EventHandler HookSelectedIndex;
        public event EventHandler RoadButtonsClick;

        private void RoadButtons_Click(object sender, EventArgs e)
        {
            RoadButtonsClick?.Invoke(sender, e);
        }

        private void RoadsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoadSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FLineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FLineSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ReelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReelSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LuresList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LureSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void AssembliesBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AssemblyDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void LuresList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LureDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void ReelsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ReelDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void FLineList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FLineDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void FetchButton_Click(object sender, EventArgs e)
        {
            FetchButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void MakeOutButton_Click(object sender, EventArgs e)
        {
            MakeOutClick?.Invoke(this, EventArgs.Empty);
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var addPresenter = new AssemblyPresenter(new AddAssembly());
            addPresenter.Run();
        }
        private void BaitBox_Click(object sender, EventArgs e)
        {
            if (Player.GetPlayer().EquipedRoad.Assembly != null && !Player.GetPlayer().EquipedRoad.IsBaitInWater)
            {
                if (Player.GetPlayer().EquipedRoad.Assembly.FishBait is Lure)
                {
                    var presenter = new SelectorPresenter<Lure>(new LureSelector<Lure>(Player.GetPlayer().LureInv), UI.gui);
                }
                if (Player.GetPlayer().EquipedRoad.Assembly.FishBait is Bait)
                {
                    var presenter = new SelectorPresenter<Bait>(new LureSelector<Bait>(Player.GetPlayer().BaitInv), UI.gui);
                }
            }
        }

        private void roadsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoadSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void roadsView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RoadDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void luresView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LureSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void luresView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LureDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void baitsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaitSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void baitsBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BaitDoubleClick?.Invoke(this, e);
        }

        private void hooksBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HookSelectedIndex?.Invoke(this, EventArgs.Empty);
        }

        private void hooksBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HookDoubleClick?.Invoke(this, e);
        }

        public void AddItemToRightView(Item item)
        {
            try
            {
                if (Item.SelectItemType(item) is Road)
                {
                    Road r = (Road)item;
                    this.pictureBox5.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.typeBox.Text = r.GetType().ToString();
                }
                if (Item.SelectItemType(item) is Reel)
                {
                    Reel r = (Reel)item;
                    this.pictureBox5.Image = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.typeBox.Text = " ";
                }
                if (Item.SelectItemType(item) is FLine)
                {
                    FLine r = (FLine)item;
                    this.pictureBox5.Image = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.typeBox.Text = " ";
                }
                if (Item.SelectItemType(item) is Lure)
                {
                    Lure r = (Lure)item;
                    this.pictureBox5.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = " ";
                    this.typeBox.Text = " ";
                }
                if (Item.SelectItemType(item) is Bait)
                {
                    Bait r = (Bait)item;
                    this.pictureBox5.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Count.ToString();
                    this.typeBox.Text = " ";
                }
                if (Item.SelectItemType(item) is BaseHook)
                {
                    BaseHook r = (BaseHook)item;
                    this.pictureBox5.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.GatheringChance.ToString();
                    this.typeBox.Text = " ";
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }
        public void ShowAssembly(Assembly ass)
        {
            if (ass != null)
            {
                try
                {
                    if (ass.Road is Spinning)
                    {
                        assemblyType.Text = "Спиннинг";
                    }
                    if (ass.Road is Feeder)
                    {
                        assemblyType.Text = "Фидер";
                    }
                    if (ass.Road is Float)
                    {
                        assemblyType.Text = "Поплавок";
                    }
                    RoadBox.BackgroundImage = ass.Road.Pict;
                    ReelBox.BackgroundImage = ass.Reel.Pict;
                    BaitBox.BackgroundImage = ass.FishBait.Pict;
                    FLineBox.BackgroundImage = ass.FLine.Pict;
                    RoadText = ass.Road.Name;
                    ReelText = ass.Reel.Name;
                    LureText = ass.FishBait.Name;
                    FLineText = ass.FLine.Name;
                }
                catch (ArgumentOutOfRangeException) { }
                catch (NullReferenceException) { }
            }
        }
        public void SetButtonDisabled(int index)
        {
            switch (index)
            {
                case 1:
                    fRoadButton.Enabled = true;
                    break;
                case 2:
                    sRoadButton.Enabled = true;
                    break;
                case 3:
                    tRoadButton.Enabled = true;
                    break;
            }
        }
        public void Open()
        {
            this.Show();
        }

        public void Down()
        {
            this.Close();
        }
    }
}