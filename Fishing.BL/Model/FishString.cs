using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Fishes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fishing.BL.Model {
    /// <summary>
    /// Name:Size% MinDeep-MaxDeep [Lurei, Lurei+1, i+2]
    /// </summary>
    /// 
    public class FishString
    {
        private readonly string LoadStr;

        public FishString(string loadStr)
        {
            string pattern = @".+:\d+\s\d+-\d+\s\[.+\]";
            if (Regex.IsMatch(loadStr, pattern)) {
                LoadStr = loadStr;
            }
            else {
                throw new ArgumentException("Wrong format!");
            }
        }

        public Fish GetFishByStr() {
            Fish fish = null;
            var regex = new Regex(@".*(?=:)");

            var fishName = regex.Match(LoadStr);
            var name = fishName.Value;

            regex = new Regex(@"\d+");

            var matches = regex.Matches(LoadStr);
            var sizeCf = Convert.ToSingle(matches[0].Value) / 100;
            var minDeep = Convert.ToInt32(matches[1].Value);
            var maxDeep = Convert.ToInt32(matches[2].Value);

            regex = new Regex(@"(?<=\[).*(?=\])");

            var match = regex.Match(LoadStr);
            var luresList = match.Value;

            var lures = luresList.Split(',');

            HashSet<FishBait> baits = new HashSet<FishBait>();

            foreach (var s in lures) {
                baits.Add(FishBait.GetFishBaitByName(s));
            }
            switch (name) {
                case "Щука":
                fish = new Pike(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Арктич. Голец":
                fish = new ArcticChar(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Жерех":
                fish = new Asp(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Лещ":
                fish = new Bream(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Налим":
                fish = new Burbot(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Голавль":
                fish = new Chub(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Карась Зол":
                fish = new GoldCarp(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Карась Сер":
                fish = new SilverCarp(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Хариус":
                fish = new Grayling(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Окунь":
                fish = new Perch(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Горбуша":
                fish = new PinkSalmon(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Плотва":
                fish = new Roach(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Рыбец":
                fish = new Rybets(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Сёмга":
                fish = new Salmon(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Подлещик":
                fish = new Scavenger(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Змееголов":
                fish = new SnakeHead(minDeep, maxDeep, sizeCf, baits);
                break;

                case "Линь":
                fish = new Tench(minDeep, maxDeep, sizeCf, baits);
                break;
            }
            return fish;
        }
    }
}