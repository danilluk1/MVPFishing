using Fishing.View.LureSelector.Presenter;
using Fishing.View.LureSelector.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.LureSelector
{
    public partial class LureSelector : Form, ISelector
    {
        readonly SelectorPresenter presenter;
        public LureSelector()
        {
            InitializeComponent();
            presenter = new SelectorPresenter(this, Fishing.GUI.gui);           
        }

        public Lure Lure { get => Player.GetPlayer().LureInv[lureList.SelectedIndex]; set => throw new NotImplementedException(); }
        public Image Picture { get => lureImage.Image; set => lureImage.Image = Lure.Pict; }
        public string NameBoxText { get => nameBox.Text; set => nameBox.Text = value; }
        public string TypeBoxText { get => typeBox.Text; set => typeBox.Text = value; }

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
            Player.GetPlayer().Assembly.Lure = Lure;
            Player.GetPlayer().SetAssembly(Player.GetPlayer().Assembly);
            this.Close();
            Fishing.GUI.gui.BaitPicture = Player.GetPlayer().Assembly.Lure.Pict;
        }
    }
}
