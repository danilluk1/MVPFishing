using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing
{
    [Serializable]
    public sealed class Player
    {
        private const int SATIETY_MAX_VALUE = 100;
        private const int SATIETY_MIN_VALUE = 100;

        private static Player player;

        public GameRoad FirstRoad { get; set; } = null;
        public GameRoad SecondRoad { get; set; } = null;
        public GameRoad ThirdRoad { get; set; } = null;
        public GameRoad EquipedRoad { get; set; }
        public BindingList<Fish> Fishlist { get; set; }
        public BindingList<Assembly> Assemblies { get; set; }
        public BindingList<Road> RoadInv { get; set; }
        public BindingList<Reel> ReelInv { get; set; }
        public BindingList<FLine> FLineInv { get; set; }
        public BindingList<Lure> LureInv { get; set; }
        public BindingList<BaseFood> FoodInv { get; set; }
        public Stack<BaseEvent> EventHistory { get; set; }
        public int Satiety { get; set; } = 100;
        public Statistic Statistic { get; set; } = new Statistic();
        public int Money { get; set; } = 10000000;
        public int WindingSpeed { get; set; }
        public Fish CFish { get; set; }
        public string NickName { get; set; } = "Рыболов";

        public Netting Netting { get; set; } = new Netting();

        private Player()
        {
        }

        public static Player GetPlayer()
        {
            if (player == null)
            {
                player = new Player();
            }

            return player;
        }

        public bool IsPlayerAbleToFishing()
        {
            if(EquipedRoad.Assembly != null)
            {
                if(EquipedRoad.Assembly.Lure != null)
                {
                    if(Satiety > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void SetAssembly(Assembly ass, int index)
        {
            if (ass.IsAssemblyFull())
            {
                switch (index)
                {
                    case 1:
                        FirstRoad = new GameRoad(ass)
                        {
                            RoadX = 100,
                            RoadY = 350
                        };
                        break;
                    case 2:
                        SecondRoad = new GameRoad(ass)
                        {
                            RoadX = 200,
                            RoadY = 350
                        };
                        break;
                    case 3:
                        ThirdRoad = new GameRoad(ass)
                        {
                            RoadX = 300,
                            RoadY = 350
                        };
                        break;
                }
            }
            else
            {
                MessageBox.Show("Сборка не собрана");
            }
        }
        public void AddFish(Fish f)
        {
            if (f != null)
            {
                Fishlist.Add(f);
            }
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
                if (!f.isTrophy())
                {
                    player.Money += (int)f.Price * f.Weight;
                }
                else
                {
                    player.Money += (int)f.Price * 3 * f.Weight;
                }
                Fishlist.Remove(f);
                BaseController.GetController().SavePlayer();
            }
        }

        public void BrokeRoad()
        {
            Pictures.road = Pictures.brokenRoad;
            player.EquipedRoad.IsBaitInWater = false;
            player.EquipedRoad.IsFishAttack = false;
            player.EquipedRoad.Assembly.Proad = null;
            player.EquipedRoad.CurPoint = Point.Empty;
            player.Statistic.BrokensRoadsCount++;
        }

        public void TornFLine()
        {
            player.EquipedRoad.IsFishAttack = false;
            player.EquipedRoad.Assembly.Lure = null;
            player.EquipedRoad.IsBaitMoving = false;
            player.EquipedRoad.CurPoint = Point.Empty;
            player.Statistic.TornsFLinesCount++;
            player.Statistic.GatheringCount++;
        }

        public void DecSatiety(int value)
        {
            if (value >= 0)
            {
                if (Satiety - value <= SATIETY_MIN_VALUE)
                {
                    Satiety -= value;
                }
            }
        }

        public bool Eat(BaseFood food)
        {
            if (food != null)
            {
                if (Satiety + food.Productivity <= SATIETY_MAX_VALUE)
                {
                    Satiety += food.Productivity;
                    FoodInv.Remove(food);
                    return true;
                }
                else
                {
                    MessageBox.Show("Игрок не достаточно голоден, чтобы съесть это");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}