using Fishing.View.GUI;
using Fishing.View.LureSelector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class GUIPresenter : BasePresenter
    {
        IGUI view;
        public GUIPresenter(IGUI view)
        {
            this.view = view;           
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}
