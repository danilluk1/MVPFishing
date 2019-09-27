using Fishing;
using Fishing.View.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class AssemblyPresenter : Presenter
    {
        private readonly IAddAssembly view;
        public event EventHandler CloseForm;
        public AssemblyPresenter(IAddAssembly view)
        {
            this.view = view;
            view.AddAssemblyClick += View_AddAssemblyClick;
        }

        private void View_AddAssemblyClick(object sender, EventArgs e)
        {
            string name = view.AssemblyName;
            Player.getPlayer().Assemblies.Add(new Assembly(name));
            CloseForm?.Invoke(this, EventArgs.Empty);
        }
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
