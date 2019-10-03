using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Presenter
{
    public class CurrentFishPresenter
    {
        readonly ICurrentFishF view;

        public CurrentFishPresenter(ICurrentFishF view)
        {
            this.view = view;
        }

    }
}
