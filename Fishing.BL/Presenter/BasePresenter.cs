using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public abstract class BasePresenter
    {
        public abstract void Load();
        public abstract void Close();
    }
}
