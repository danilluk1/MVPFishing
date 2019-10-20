using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.View;
using Fishing.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Presenter
{
    public class StatisticPresenter : BasePresenter
    {
        private readonly IStatistic view;

        public StatisticPresenter(IStatistic view)
        {
            this.view = view;
            view.Presenter = this;
            view.Open();
            view.LoadForm += View_Load;
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        private void View_Load(object sender, EventArgs e)
        {
           
        }
    }
}
