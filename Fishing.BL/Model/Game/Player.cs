using Fishing.BL;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Fishing
{
    [Serializable]
    public sealed class Player
    {
        private const int SATIETY_MAX_VALUE = 100;
        private const int SATIETY_MIN_VALUE = 100;
        private static Player player;

        public Assembly Assembly { get; set; }
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

        public bool IsBaitMoving = false;
        public bool IsJigging = false;
        public Point LastCastPoint;
        public int RoadX = 0;
        public int RoadY = 395;
        public bool isFishAttack = false;
        public int CurrentDeep;
        public Point CurPoint;
        public int RoadIncValue;
        public int FLineIncValue;
        public Netting Netting = new Netting();

        private Player()
        {

        }
        public static Player GetPlayer()                           
        {
            if(player == null)
            {
                player = new Player();
            }

            return player;              
        }

        public bool IsPlayerAbleToFishing()
        {
            if(Assembly != null && Netting != null && Satiety > 0 && Assembly.Lure != null)
            {
                return true;
            }
            return false;
        }

        public void SetAssembly(Assembly ass)
        {
            Assembly = ass ?? null;
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
                Fishlist.Remove(f);
                if (!f.isTrophy())
                {
                    player.Money += (int)f.Price * f.Weight;
                }
                else
                {
                    player.Money += (int)f.Price * 3 * f.Weight;
                }
                BaseController.GetController().SavePlayer();
            }
        }

        public void CheckXBorders()
        {
            if (player.CurPoint.X > 1045) player.CurPoint.X = 1043;
            if (player.CurPoint.X < 0) player.CurPoint.X = 1;
        }

        public bool IsFishAbleToGoIntoFpond()
        {
            if(player.Netting.Y == 550 && player.isFishAttack && player.CurPoint.Y > 430)
            {
                return true;
            }

            return false;
        }

        public void AddNewMessage(BaseEvent ev)
        {
            player.EventHistory.Push(ev);
        }

        public void BrokeRoad()
        {
            Pictures.road = Pictures.brokenRoad;
            player.isFishAttack = false;
            player.Assembly.Proad = null;
            player.CurPoint.Y = 800;
            player.Statistic.BrokensRoadsCount++;
        }

        public void TornFLine()
        {
            player.isFishAttack = false;
            player.CurPoint.Y = 800;
            player.Statistic.TornsFLinesCount++;
            player.Assembly.Lure = null;
            player.Statistic.GatheringCount++;
            player.AddNewMessage(new GatheringEvent());
        }

        public void DecSatiety(int value)
        {
            if(Satiety - value <= SATIETY_MIN_VALUE)
            {
                Satiety -= value;
            }
        }

        public bool Eat(BaseFood food)
        {
            if (Satiety + food.Productivity <= SATIETY_MAX_VALUE && food != null)
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
    }
}
