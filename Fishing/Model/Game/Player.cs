using Fishing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing
{
    [Serializable]
    sealed class Player
    {
        private static Player player;
        public Assembly Assembly { get; set; }
        private BindingList<Fish> Fishlist { get; set; }
        private BindingList<Assembly> Assemblies;
        private BindingList<Road> RoadInv;
        private BindingList<Reel> ReelInv;
        private BindingList<FLine> FLineInv;
        public BindingList<Lure> LureInv;
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

        public Road Road = Road.Titanium;
        public Reel Reel = Reel.SYBERIA_4;
        public FLine Fline = FLine.Quest_Fishers;
        public Lure Lure { get; set; } = Lure.jelezo4;
        public string NickName { get; set; } = "Рыболов";

        private Player()
        {
            Fishlist = new BindingList<Fish>();
            Assemblies = new BindingList<Assembly>();
            RoadInv = new BindingList<Road>();
            ReelInv = new BindingList<Reel>();
            LureInv = new BindingList<Lure>();
            FLineInv = new BindingList<FLine>();
            Assemblies.Add(new Assembly("Сборка 1",Road.Titanium, Reel.Quest_Reel, FLine.Quest_Fishers, Lure.vob1));
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
            return Fishlist[index];
        }

        public void SellFish(Fish f)
        {
            Fishlist.Remove(f);
            player.Money += (int)f.Price * f.Weight;
        }


        public void AddAssembly(Assembly ass)
        {
            Assemblies.Add(ass);
        }

        public void RemoveAssembly(Assembly ass)
        {
            Assemblies.Remove(ass);
        }

        public  BindingList<Assembly> GetAssemblies()
        {
            return Assemblies;
        }

        public void AddRoad(Road r)
        {
            RoadInv.Add(r);
        }

        public BindingList<Road> GetRoads()
        {
            return RoadInv;
        }

        public void RemoveRoad(Road r)
        {
            RoadInv.Remove(r);
        }

        public void AddFLine(FLine f)
        {
            FLineInv.Add(f);
        }

        public BindingList<FLine> GetFLines()
        {
            return FLineInv;
        }

        public void RemoveFLine(FLine f)
        {
            FLineInv.Remove(f);
        }
        public void AddReel(Reel r)
        {
            ReelInv.Add(r);
        }

        public BindingList<Reel> GetReels()
        {
            return ReelInv;
        }

        public void RemoveReel(Reel r)
        {
            ReelInv.Remove(r);
        }
        public void AddLure(Lure l)
        {
            LureInv.Add(l);
        }

        public BindingList<Lure> GetLures()
        {
            return LureInv;
        }

        public void RemoveLure(Lure l)
        {
            LureInv.Remove(l);
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
