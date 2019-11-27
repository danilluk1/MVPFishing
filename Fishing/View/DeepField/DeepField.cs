using Fishing.BL.View;
using Fishing.Presenter;
using System;
using System.Windows.Forms;
using Fishing.BL.Presenter;

namespace Fishing.View.DeepField {

    public partial class DeepField : Form, IDeepField {
        public DeepField(LVL lvl) {
            InitializeComponent();
            for (var y = 0; y < lvl.Height; y++) {
                for (var x = 0; x < lvl.Widgth; x++) {
                    Controls.Add(lvl.DeepArray[x, y]);
                }
            }
        }

        public BasePresenter Presenter { get; set; }

        public void Down() {
            Close();
        }

        public void Open() {
            Show();
        }
    }
}