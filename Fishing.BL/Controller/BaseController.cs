using Fishing;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Model.Waters;
using Fishing.BL.Resources.Paths;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Saver.BL.Controller
{
    internal class BaseController
    {
        private static BaseController controller;
        private IDataSaver saver = new SerializeDataSaver();

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
            Player.GetPlayer().LureInv = saver.Load<BindingList<Lure>>(ConfigPaths.LURES_DIR) ?? new BindingList<Lure>();
            Player.GetPlayer().RoadInv = saver.Load<BindingList<Road>>(ConfigPaths.ROADS_DIR) ?? new BindingList<Road>();
            Player.GetPlayer().FLineInv = saver.Load<BindingList<FLine>>(ConfigPaths.FLINES_DIR) ?? new BindingList<FLine>();
            Player.GetPlayer().ReelInv = saver.Load<BindingList<Reel>>(ConfigPaths.REELS_DIR) ?? new BindingList<Reel>();
            Player.GetPlayer().Assemblies = saver.Load<BindingList<Assembly>>(ConfigPaths.ASSEMBLIES_DIR) ?? new BindingList<Assembly>();
            Player.GetPlayer().Fishlist = saver.Load<BindingList<Fish>>(ConfigPaths.FISHLIST_DIR) ?? new BindingList<Fish>();
            Player.GetPlayer().NickName = saver.Load<string>(ConfigPaths.NAME_DIR) ?? "Рыболов";
            Player.GetPlayer().Money = Convert.ToInt32(saver.Load<string>(ConfigPaths.MONEY_DIR) ?? "1000000");
            Player.GetPlayer().EventHistory = saver.Load<Stack<BaseEvent>>(ConfigPaths.EVENTHSTR_DIR) ?? new Stack<BaseEvent>();
            Player.GetPlayer().Statistic = saver.Load<Statistic>(ConfigPaths.STATS_DIR) ?? new Statistic();
            Player.GetPlayer().Satiety = Convert.ToInt32(saver.Load<string>(ConfigPaths.SATIETY_DIR) ?? "100");
            Player.GetPlayer().FoodInv = saver.Load<BindingList<BaseFood>>(ConfigPaths.FOODS_DIR) ?? new BindingList<BaseFood>();
            Game.GetGame().Time = saver.Load<Time>(ConfigPaths.TIME_DIR);
            Game.GetGame().CurrentWater = saver.Load<Water>(ConfigPaths.WATER_DIR);
        }

        public void SavePlayer()
        {
            saver.Save(ConfigPaths.LURES_DIR, Player.GetPlayer().LureInv);
            saver.Save(ConfigPaths.ROADS_DIR, Player.GetPlayer().RoadInv);
            saver.Save(ConfigPaths.REELS_DIR, Player.GetPlayer().ReelInv);
            saver.Save(ConfigPaths.FLINES_DIR, Player.GetPlayer().FLineInv);
            saver.Save(ConfigPaths.ASSEMBLIES_DIR, Player.GetPlayer().Assemblies);
            saver.Save(ConfigPaths.FISHLIST_DIR, Player.GetPlayer().Fishlist);
            saver.Save(ConfigPaths.MONEY_DIR, Player.GetPlayer().Money.ToString());
            saver.Save(ConfigPaths.NAME_DIR, Player.GetPlayer().NickName);
            saver.Save(ConfigPaths.EVENTHSTR_DIR, Player.GetPlayer().EventHistory);
            saver.Save(ConfigPaths.STATS_DIR, Player.GetPlayer().Statistic);
            saver.Save(ConfigPaths.FOODS_DIR, Player.GetPlayer().FoodInv);
            saver.Save(ConfigPaths.SATIETY_DIR, Player.GetPlayer().Satiety.ToString());
            saver.Save(ConfigPaths.TIME_DIR, Game.GetGame().Time);
            saver.Save(ConfigPaths.WATER_DIR, Game.GetGame().CurrentWater);
        }
    }
}