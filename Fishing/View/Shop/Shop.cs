using Fishing.Presenter;
using Fishing.View.Shop;
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
    public partial class Shop : Form, IShop
    {
        ShopPresenter presenter;
        public Shop()
        {
            InitializeComponent();
            presenter = new ShopPresenter(this);
        }
        public void addItemtoRightView(Item i)
        {
            try
            {
                if (Item.selectItemType(i) is Road)
                {
                    Road r = (Road)i;
                    this.itemBox.Image = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = r.Type.ToString();
                    this.label1.Text = " ";
                }
                if (Item.selectItemType(i) is Reel)
                {
                    Reel r = (Reel)i;
                    this.itemBox.Image = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = " ";
                    this.label1.Text = " ";
                }
                if (Item.selectItemType(i) is FLine)
                {
                    FLine r = (FLine)i;
                    this.itemBox.Image = r.Pict;
                    this.nameBox.Text = r.Name;
                    this.powerBox.Text = r.Power.ToString();
                    this.priceBox.Text = r.Price.ToString();
                    this.typeBox.Text = " ";
                    this.label1.Text = " ";
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

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

        public string MoneyL { get => moneyBox.Text; set => moneyBox.Text = value; }

        public event EventHandler FLineSelectedIndexChanged;
        public event EventHandler RoadSelectedIndexChanged;
        public event EventHandler ReelSelectedIndexChanged;
        public event EventHandler FLineDoubleClick;
        public event EventHandler RoadDoubleClick;
        public event EventHandler ReelDoubleClick;
        public event EventHandler CloseButtonClick;

        private void RoadsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RoadSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            addItemtoRightView(Road_P);
        }
        private void FLineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FLineSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            addItemtoRightView(FLine_P);
        }

        private void ReelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReelSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
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

        private void Shop_Load(object sender, EventArgs e)
        {
            RoadsList.DataSource = Item.RoadShop;
            ReelsList.DataSource = Item.ReelShop;
            FLineList.DataSource = Item.LeskaShop;
            moneyBox.Text = Player.GetPlayer().Money.ToString();
        }
    }
}
