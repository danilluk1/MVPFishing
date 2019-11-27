using Fishing;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Model.Waters;
using Fishing.BL.Resources.Paths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Saver.BL.Controller {

    internal class BaseController {
        private static BaseController _controller;
        private readonly IDataSaver _saver = new SerializeDataSaver();

        private BaseController() {
        }

        public static BaseController GetController()
        {
            return _controller ?? (_controller = new BaseController());
        }

        public void Initiallize() {
            Player.GetPlayer().LureInv = _saver.Load<BindingList<Lure>>(ConfigPaths.LURES_DIR) ?? new BindingList<Lure>();
            Player.GetPlayer().RoadInv = _saver.Load<BindingList<Road>>(ConfigPaths.ROADS_DIR) ?? new BindingList<Road>();
            Player.GetPlayer().FLineInv = _saver.Load<BindingList<FLine>>(ConfigPaths.FLINES_DIR) ?? new BindingList<FLine>();
            Player.GetPlayer().ReelInv = _saver.Load<BindingList<Reel>>(ConfigPaths.REELS_DIR) ?? new BindingList<Reel>();
            Player.GetPlayer().Assemblies = _saver.Load<BindingList<Assembly>>(ConfigPaths.ASSEMBLIES_DIR) ?? new BindingList<Assembly>();
            Player.GetPlayer().Fishlist = _saver.Load<BindingList<Fish>>(ConfigPaths.FISHLIST_DIR) ?? new BindingList<Fish>();
            Player.GetPlayer().NickName = _saver.Load<string>(ConfigPaths.NAME_DIR) ?? "Рыболов";
            Player.GetPlayer().Money = Convert.ToInt32(_saver.Load<string>(ConfigPaths.MONEY_DIR) ?? "1000000");
            Player.GetPlayer().EventHistory = _saver.Load<Stack<BaseEvent>>(ConfigPaths.EVENTHSTR_DIR) ?? new Stack<BaseEvent>();
            Player.GetPlayer().Statistic = _saver.Load<Statistic>(ConfigPaths.STATS_DIR) ?? new Statistic();
            Player.GetPlayer().Satiety = Convert.ToInt32(_saver.Load<string>(ConfigPaths.SATIETY_DIR) ?? "100");
            Player.GetPlayer().FoodInv = _saver.Load<BindingList<Food>>(ConfigPaths.FOODS_DIR) ?? new BindingList<Food>();
            Player.GetPlayer().BaitInv = _saver.Load<BindingList<Bait>>(ConfigPaths.BAIT_DIR) ?? new BindingList<Bait>();
            Player.GetPlayer().HooksInv = _saver.Load<BindingList<BaseHook>>(ConfigPaths.HOOKS_DIR) ?? new BindingList<BaseHook>();
            Game.GetGame().Time = _saver.Load<Time>(ConfigPaths.TIME_DIR);
            var dir = new DirectoryInfo(@"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters");
            foreach (var item in dir.GetDirectories()) {
                Game.GetGame().Waters.Add(item.ToString());
            }
            string wName = _saver.Load<string>(ConfigPaths.WATER_DIR) ?? "Тобол";
            WaterImplementation wr = new WaterImplementation();
            wr.GetLVL(wName);
            Game.GetGame().CurrentWater = wr;
        }

        public void SavePlayer() {
            _saver.Save(ConfigPaths.LURES_DIR, Player.GetPlayer().LureInv);
            _saver.Save(ConfigPaths.ROADS_DIR, Player.GetPlayer().RoadInv);
            _saver.Save(ConfigPaths.REELS_DIR, Player.GetPlayer().ReelInv);
            _saver.Save(ConfigPaths.FLINES_DIR, Player.GetPlayer().FLineInv);
            _saver.Save(ConfigPaths.ASSEMBLIES_DIR, Player.GetPlayer().Assemblies);
            _saver.Save(ConfigPaths.FISHLIST_DIR, Player.GetPlayer().Fishlist);
            _saver.Save(ConfigPaths.MONEY_DIR, Player.GetPlayer().Money.ToString());
            _saver.Save(ConfigPaths.NAME_DIR, Player.GetPlayer().NickName);
            _saver.Save(ConfigPaths.EVENTHSTR_DIR, Player.GetPlayer().EventHistory);
            _saver.Save(ConfigPaths.STATS_DIR, Player.GetPlayer().Statistic);
            _saver.Save(ConfigPaths.FOODS_DIR, Player.GetPlayer().FoodInv);
            _saver.Save(ConfigPaths.SATIETY_DIR, Player.GetPlayer().Satiety.ToString());
            _saver.Save(ConfigPaths.TIME_DIR, Game.GetGame().Time);
            MessageBox.Show(Game.GetGame().CurrentWater.Name);
            _saver.Save(ConfigPaths.WATER_DIR, Game.GetGame().CurrentWater.Name);
            _saver.Save(ConfigPaths.BAIT_DIR, Player.GetPlayer().BaitInv);
            _saver.Save(ConfigPaths.HOOKS_DIR, Player.GetPlayer().HooksInv);
        }
    }
}