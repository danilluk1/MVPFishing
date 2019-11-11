using Fishing.Presenter;
using System;
using System.Windows.Forms;

namespace Fishing.View.Assembly {
    public partial class AddAssembly : Form, IAddAssembly {
        public AddAssembly() {
            InitializeComponent();
        }

        public string AssemblyName { get => nameBox.Text; set => AssemblyName = nameBox.Text; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler AddAssemblyClick;

        private void Add_Click(object sender, EventArgs e) {
            AddAssemblyClick?.Invoke(this, EventArgs.Empty);
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            this.Close();
        }
    }
}