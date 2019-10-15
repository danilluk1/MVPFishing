using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.View
{
    public interface IView
    {
        void Open();
        void Down();
        Fishing.Presenter.BasePresenter Presenter { set; }
    }
}
