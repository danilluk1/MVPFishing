using Fishing.BL;
using Fishing.BL.Model.Game;
using Saver.BL.Controller;
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
        public int CurrentDeep;
        public Point CurPoint;
        public int IncValue;
        public Netting Netting = new Netting();
        public int Money { get; set; } = 10000000;

        public int WindingSpeed;
        public Fish CFish { get; set; }
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
            Assembly = ass != null ? ass : null;
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
                BaseController.GetController().SavePlayer();
            }
        }

        public void CheckXBorders()
        {
            if (player.CurPoint.X > 1049) player.CurPoint.X = 1048;
            if (player.CurPoint.X < 0) player.CurPoint.X = 1;
        }

        public bool IsFishAbleToGoIntoFpond()
        {
            if(player.Netting.Y == 550 && player.isFishAttack && player.CurPoint.Y > 600)
            {
                return true;
            }

            return false;
        }

        public void AddNewMessage(MessageType type)
        {
            string text = string.Empty;
            switch (type)
            {
                case MessageType.FLineIsTorn:
                    text = player.NickName + " порвал леску";
                    break;
                case MessageType.NewFish:
                    text = player.NickName + " поймал " + Player.getPlayer().CFish.ToString();
                    break;
                case MessageType.NewTrophyFish:
                    text = "Трофей! " + Player.getPlayer().NickName + " поймал " + Player.getPlayer().CFish.ToString();
                    break;
                case MessageType.RoadIsBroken:
                    text = player.NickName + " сломал удочку";
                    break;
                case MessageType.Gathering:
                    text = player.NickName + " сход =(";
                    break;
            }
            player.EventHistory.Push(new UserEvent(text, type));
        }

        public void BrokeRoad()
        {
            Pictures.road = Pictures.brokenRoad;
            player.isFishAttack = false;
            player.Assembly.Proad = null;
            player.CurPoint.Y = 0;
        }

        public void TornFLine()
        {
            player.isFishAttack = false;
            player.CurPoint.Y = 0;
            player.Assembly.Lure = null;
        }
    }
}
