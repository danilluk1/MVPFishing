using Fishing.BL.View;
using Fishing.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.FoodInventory
{
    public partial class FoodInventory : Form, IFoodInventory
    {
        public FoodInventory()
        {
            InitializeComponent();
            foodsBox.DataSource = Player.GetPlayer().FoodInv;
        }

        public int SelectedIndex { get => foodsBox.SelectedIndex; set => throw new NotImplementedException(); }
        public Image FoodImage { get => FoodBox.BackgroundImage; set => FoodBox.BackgroundImage = value; }
        public string FoodProductivityTextBox { get => foodProductBox.Text; set => foodProductBox.Text = "Восполняет: %" + value; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler ListSelectedIndexChanged;

        public event EventHandler ListDoubleClick;

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
            Down();
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