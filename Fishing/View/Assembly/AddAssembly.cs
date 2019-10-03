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

namespace Fishing.View.Assembly
{
    public partial class AddAssembly : Form, IAddAssembly
    {
        AssemblyPresenter presenter;
        public AddAssembly()
        {
            InitializeComponent();
            presenter = new AssemblyPresenter(this);
            presenter.CloseForm += Presenter_CloseForm;
        }
        public string AssemblyName { get => nameBox.Text; set => AssemblyName = nameBox.Text; }

        public event EventHandler AddAssemblyClick;

        private void Presenter_CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (AddAssemblyClick != null)
                AddAssemblyClick(this, EventArgs.Empty);
        }
    }
}
