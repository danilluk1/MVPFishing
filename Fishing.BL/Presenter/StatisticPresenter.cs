using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Presenter
{
    public class StatisticPresenter
    {
        private readonly IStatistic view;

        public StatisticPresenter(IStatistic view)
        {
            this.view = view;
            view.LoadForm += View_Load;
        }

        private void View_Load(object sender, EventArgs e)
        {
            view.NameLText = Player.GetPlayer().NickName;
            view.MoneyLText = Player.GetPlayer().Money.ToString();
            view.GatheringLText = Player.GetPlayer().Statistic.GatheringCount.ToString();
            view.TakeFishesLText = Player.GetPlayer().Statistic.TakenFishesCount.ToString();
            view.TornFLineLText = Player.GetPlayer().Statistic.TornsFLinesCount.ToString();
            view.BrokenRoadsLText = Player.GetPlayer().Statistic.BrokensRoadsCount.ToString();

            foreach(BaseEvent ev in Player.GetPlayer().EventHistory)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ev.Text;
                lvi.ImageIndex = ev.Index;
                if(ev is TrophyFishEvent)
                {
                    lvi.ForeColor = System.Drawing.Color.White;
                    lvi.BackColor = System.Drawing.Color.Navy;
                }
                view.addEventToView(lvi);
            }

        }
    }
}
