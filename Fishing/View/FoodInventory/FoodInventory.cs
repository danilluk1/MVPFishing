using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.View.FoodInventory
{
    public partial class FoodInventory : Form, IFoodInventory
    {
        private readonly FoodPresenter presenter;
        public FoodInventory()
        {
            InitializeComponent();
            foodsBox.DataSource = Player.GetPlayer().FoodInv;
            presenter = new FoodPresenter(this);
        }

        public int SelectedIndex { get => foodsBox.SelectedIndex; set => throw new NotImplementedException(); }
        public Image FoodImage { get => FoodBox.BackgroundImage; set => FoodBox.BackgroundImage = value; }
        public string FoodProductivityTextBox { get => foodProductBox.Text; set => foodProductBox.Text = "Восполняет: %" + value; }

        public event EventHandler ListSelectedIndexChanged;
        public event EventHandler ListDoubleClick;

        private void FoodInventory_Load(object sender, EventArgs e)
        {

        }

        private void FoodsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FoodsBox_DoubleClick(object sender, EventArgs e)
        {
            ListDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
