using Fishing.BL.Model.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fishing
{
    [Serializable]
    public sealed class Player
    {
        public const string LURES_DIR = "config/lures.dat";
        public const string FISHLIST_DIR = "config/fishlist.dat";
        public const string ROADS_DIR = "config/roads.dat";
        public const string REELS_DIR = "config/reels.dat";
        public const string FLINES_DIR = "config/flines.dat";
        public const string ASSEMBLIES_DIR = "config/assemblies.dat";
        public const string MONEY_DIR = "config/money.dat";
        public const string NAME_DIR = "config/name.dat";
        public const string EVENTHSTR_DIR = "config/history.dat";

        private static Player player;
        public Assembly Assembly { get; set; }
        public BindingList<Fish> Fishlist { get; set; }
        public BindingList<Assembly> Assemblies { get; set; }
        public BindingList<Road> RoadInv { get; set; }
        public BindingList<Reel> ReelInv { get; set; }
        public BindingList<FLine> FLineInv { get; set; }
        public BindingList<Lure> LureInv { get; set; }

        public Stack<UserEvent> EventHistory { get; set; }
        public bool IsBaitMoving = false;
        public Point LastCastPoint;
        public int RoadX = 0;
        public int RoadY = 470;
        public bool isFishAttack = false;
        public int NettingY;
        public int CurrentDeep;
        public Point CurPoint; 
        public int Money { get; set; } = 10000000;
        public int RoadPower { get; set; }
        public int LeskaPower { get; set; }
        public int ReelPower { get; set; }

        public int WindingSpeed;
        public Fish CFish { get; set; }

        public Road Road { get; set; }
        public Reel Reel { get; set; }
        public FLine Fline { get; set; }
        public Lure Lure { get; set; }
        public string NickName { get; set; } = "Рыболов";

        private Player()
        {
        }
        public static Player getPlayer()                           
        {
            if(player == null)
            {
                player = new Player();
            }

            return player;              
        }


        public void setAssembly(Assembly ass)
        {
            this.Road = ass.Proad;
            this.Reel = ass.Reel;
            this.Fline = ass.FLine;
            this.Lure = ass.Lure;
            this.Assembly = ass;
        }

        public void addFish(Fish f)
        {
            if (f != null)
            {
                Fishlist.Add(f);
            }
        }

        public BindingList<Fish> GetFishList()
        {
            return Fishlist;
        }

        public Fish GetFishByIndex(int index)
        {
            try
            {
                return Fishlist[index];
            }
            catch (ArgumentOutOfRangeException) { }

            return null;
        }

        public void SellFish(Fish f)
        {
            if (f != null)
            {
                Fishlist.Remove(f);
                if (!f.isTrophy())
                {
                    player.Money += (int)f.Price * f.Weight;
                }
                else
                {
                    player.Money += (int)f.Price * 3 * f.Weight;
                }
                //player.SavePlayer();
            }
        }

        public void Initiallize()
        {
            getPlayer().LureInv = getPlayer().Load<BindingList<Lure>>(LURES_DIR) ?? new BindingList<Lure>();
            getPlayer().RoadInv = getPlayer().Load<BindingList<Road>>(ROADS_DIR) ?? new BindingList<Road>();
            getPlayer().FLineInv = getPlayer().Load<BindingList<FLine>>(FLINES_DIR) ?? new BindingList<FLine>();
            getPlayer().ReelInv = getPlayer().Load<BindingList<Reel>>(REELS_DIR) ?? new BindingList<Reel>();
            getPlayer().Assemblies = getPlayer().Load<BindingList<Assembly>>(ASSEMBLIES_DIR) ?? new BindingList<Assembly>();
            getPlayer().Fishlist = getPlayer().Load<BindingList<Fish>>(FISHLIST_DIR) ?? new BindingList<Fish>();
            getPlayer().NickName = getPlayer().Load<string>(NAME_DIR) ?? "Рыболов";
            getPlayer().Money = Convert.ToInt32(getPlayer().Load<string>(MONEY_DIR) ?? "1000000");
            getPlayer().EventHistory = getPlayer().Load<Stack<UserEvent>>(EVENTHSTR_DIR) ?? new Stack<UserEvent>();
        }

        public void SavePlayer()
        {
            getPlayer().Save(LURES_DIR, getPlayer().LureInv);
            getPlayer().Save(ROADS_DIR, getPlayer().RoadInv);
            getPlayer().Save(REELS_DIR, getPlayer().ReelInv);
            getPlayer().Save(FLINES_DIR, getPlayer().FLineInv);
            getPlayer().Save(ASSEMBLIES_DIR, getPlayer().Assemblies);
            getPlayer().Save(FISHLIST_DIR, getPlayer().Fishlist);
            getPlayer().Save(MONEY_DIR, getPlayer().Money.ToString());
            getPlayer().Save(NAME_DIR, getPlayer().NickName);
            getPlayer().Save(EVENTHSTR_DIR, getPlayer().EventHistory);


        }

        public void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

    }
}
