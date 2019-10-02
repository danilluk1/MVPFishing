using Fishing;
using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Paths;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Saver.BL.Controller
{
    class BaseController
    {
        private static BaseController controller;
        IDataSaver saver = new SerializeDataSaver();

        private BaseController()
        {

        }

        public static BaseController GetController()
        {
            if (controller == null)
            {
                controller = new BaseController();
            }

            return controller;
        }

        public void Initiallize()
        {
            Player.getPlayer().LureInv = saver.Load<BindingList<Lure>>(ConfigPaths.LURES_DIR) ?? new BindingList<Lure>();
            Player.getPlayer().RoadInv = saver.Load<BindingList<Road>>(ConfigPaths.ROADS_DIR) ?? new BindingList<Road>();
            Player.getPlayer().FLineInv = saver.Load<BindingList<FLine>>(ConfigPaths.FLINES_DIR) ?? new BindingList<FLine>();
            Player.getPlayer().ReelInv = saver.Load<BindingList<Reel>>(ConfigPaths.REELS_DIR) ?? new BindingList<Reel>();
            Player.getPlayer().Assemblies = saver.Load<BindingList<Assembly>>(ConfigPaths.ASSEMBLIES_DIR) ?? new BindingList<Assembly>();
            Player.getPlayer().Fishlist = saver.Load<BindingList<Fish>>(ConfigPaths.FISHLIST_DIR) ?? new BindingList<Fish>();
            Player.getPlayer().NickName = saver.Load<string>(ConfigPaths.NAME_DIR) ?? "Рыболов";
            Player.getPlayer().Money = Convert.ToInt32(saver.Load<string>(ConfigPaths.MONEY_DIR) ?? "1000000");
            Player.getPlayer().EventHistory = saver.Load<Stack<UserEvent>>(ConfigPaths.EVENTHSTR_DIR) ?? new Stack<UserEvent>();
        }

        public void SavePlayer()
        {
            saver.Save(ConfigPaths.LURES_DIR, Player.getPlayer().LureInv);
            saver.Save(ConfigPaths.ROADS_DIR, Player.getPlayer().RoadInv);
            saver.Save(ConfigPaths.REELS_DIR, Player.getPlayer().ReelInv);
            saver.Save(ConfigPaths.FLINES_DIR, Player.getPlayer().FLineInv);
            saver.Save(ConfigPaths.ASSEMBLIES_DIR, Player.getPlayer().Assemblies);
            saver.Save(ConfigPaths.FISHLIST_DIR, Player.getPlayer().Fishlist);
            saver.Save(ConfigPaths.MONEY_DIR, Player.getPlayer().Money.ToString());
            saver.Save(ConfigPaths.NAME_DIR, Player.getPlayer().NickName);
            saver.Save(ConfigPaths.EVENTHSTR_DIR, Player.getPlayer().EventHistory);
        }
    }
}
