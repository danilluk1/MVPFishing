using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.Presenter;
using Fishing.View.Shop;
using System;
using System.Windows.Forms;

namespace Fishing
{
    public partial class Shop : Form, IShop
    {
        public Shop()
        {
            InitializeComponent();
            RoadsList.DataSource = Item.RoadShop;
            ReelsList.DataSource = Item.ReelShop;
            FLineList.DataSource = Item.LeskaShop;
            foodsBox.DataSource = BaseFood.FoodShop;
            lureBox.DataSource = Item.LureShop;
            baitsList.DataSource = Item.BaitsShop;
            moneyBox.Text = Player.GetPlayer().Money.ToString();
        }

        public string MoneyL { get => moneyBox.Text; set => moneyBox.Text = value; }
        public string LowerL { get => label1.Text; set => label1.Text = value; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler FLineDoubleClick;

        public event EventHandler RoadDoubleClick;

        public event EventHandler ReelDoubleClick;

        public event EventHandler CloseButtonClick;

        public event EventHandler ProductDoubleClick;

        public event EventHandler LureDoubleClick;
        public event EventHandler BaitDoubleClick;

        public Road Road_P
        {
            get
            {
                try
                {
                    return Item.RoadShop[RoadsList.SelectedIndex];
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
                    return Item.ReelShop[ReelsList.SelectedIndex];
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
                    return Item.LeskaShop[FLineList.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        public BaseFood Food_P
        {
            get
            {
                try
                {
                    return BaseFood.FoodShop[foodsBox.SelectedIndex];
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
                    return Item.LureShop[lureBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        public Bait Bait_P
        {
            get
            {
                try
                {
                    return Item.BaitsShop[baitsList.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set
            {
            }
        }

        private void RoadsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            addItemtoRightView(Road_P);
        }

        private void FLineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addItemtoRightView(FLine_P);
        }

        private void ReelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addItemtoRightView(Reel_P);
        }

        private void FLineList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FLineDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void ReelsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ReelDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoadsList_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            RoadDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void FoodsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addItemtoRightView(Food_P);
        }

        private void FoodsBox_DoubleClick(object sender, EventArgs e)
        {
            ProductDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        public void Open()
        {
            this.Show();
        }

        public void Down()
        {
            this.Close();
        }

        public void addItemtoRightView(Item i)
        {
            try
            {
                if (Item.SelectItemType(i) is Road)
                {
                    Road r = (Road)i;
                    this.itemBox.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = r.Type.ToString();
                    this.label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Reel)
                {
                    Reel r = (Reel)i;
                    this.itemBox.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = " ";
                    this.label1.Text = " ";
                }
                if (Item.SelectItemType(i) is FLine)
                {
                    FLine r = (FLine)i;
                    this.itemBox.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = " ";
                    this.label1.Text = " ";
                }
                if (Item.SelectItemType(i) is BaseFood)
                {
                    BaseFood r = (BaseFood)i;
                    this.itemBox.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Productivity.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = " ";
                    this.label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Lure)
                {
                    Lure r = (Lure)i;
                    this.itemBox.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.DeepType.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = r.Size.ToString();
                    this.label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Bait)
                {
                    Bait r = (Bait)i;
                    this.itemBox.BackgroundImage = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = "Кол-во: 30";
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = " ";
                    this.label1.Text = " ";
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void lureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addItemtoRightView(Lure_P);
        }

        private void lureBox_DoubleClick(object sender, EventArgs e)
        {
            LureDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void baitsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addItemtoRightView(Bait_P);
        }

        private void baitsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BaitDoubleClick?.Invoke(this, e);
        }
    }
}