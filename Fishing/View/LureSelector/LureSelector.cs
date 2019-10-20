using Fishing.Presenter;
using Fishing.View.LureSelector.Presenter;
using Fishing.View.LureSelector.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.LureSelector
{
    public partial class LureSelector : Form, ISelector
    {
        public LureSelector()
        {
            InitializeComponent();       
        }

        public Lure Lure { get => Player.GetPlayer().LureInv[lureList.SelectedIndex]; set => throw new NotImplementedException(); }
        public Image Picture { get => lureImage.BackgroundImage; set => lureImage.BackgroundImage = Lure.Pict; }
        public string DeepBoxText { get => deepBox.Text; set => deepBox.Text = value; }
        public string SizeBoxText { get => sizeBox.Text; set => sizeBox.Text = value; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler LureListIndexChanged;
        public event EventHandler LureListDoubleClick;


        private void LureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LureListIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LureSelector_Load(object sender, EventArgs e)
        {
            lureList.DataSource = Player.GetPlayer().LureInv;
        }

        private void LureList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LureListDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        public void Open()
        {
            if (this != null)
            {
                this.Show();
            }
        }

        public void Down()
        {
            if (this != null)
            {
                this.Close();
            }
        }
    }
}
