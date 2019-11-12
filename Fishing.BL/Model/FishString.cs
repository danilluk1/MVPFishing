using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Fishes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fishing.BL.Model {

    public class FishString //Name:Size% MinDeep-MaxDeep [Lure1, Lure2]
    {
        private static string pattern = @".+";
        private string LoadStr;

        public FishString(string loadStr) {
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

            var namem = regex.Match(LoadStr);
            var name = namem.Value;

            regex = new Regex(@"\d+");

            var matches = regex.Matches(LoadStr);
            var coef = Convert.ToSingle(matches[0].Value) / 100;
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
                fish = new Pike(minDeep, maxDeep, coef, baits);
                break;

                case "Арктич. Голец":
                fish = new ArcticChar(minDeep, maxDeep, coef, baits);
                break;

                case "Жерех":
                fish = new Asp(minDeep, maxDeep, coef, baits);
                break;

                case "Лещ":
                fish = new Bream(minDeep, maxDeep, coef, baits);
                break;

                case "Налим":
                fish = new Burbot(minDeep, maxDeep, coef, baits);
                break;

                case "Голавль":
                fish = new Chub(minDeep, maxDeep, coef, baits);
                break;

                case "Карась Зол":
                fish = new GoldCarp(minDeep, maxDeep, coef, baits);
                break;

                case "Карась Сер":
                fish = new SilverCarp(minDeep, maxDeep, coef, baits);
                break;

                case "Хариус":
                fish = new Grayling(minDeep, maxDeep, coef, baits);
                break;

                case "Окунь":
                fish = new Perch(minDeep, maxDeep, coef, baits);
                break;

                case "Горбуша":
                fish = new PinkSalmon(minDeep, maxDeep, coef, baits);
                break;

                case "Плотва":
                fish = new Roach(minDeep, maxDeep, coef, baits);
                break;

                case "Рыбец":
                fish = new Rybets(minDeep, maxDeep, coef, baits);
                break;

                case "Сёмга":
                fish = new Salmon(minDeep, maxDeep, coef, baits);
                break;

                case "Подлещик":
                fish = new Scavenger(minDeep, maxDeep, coef, baits);
                break;

                case "Змееголов":
                fish = new SnakeHead(minDeep, maxDeep, coef, baits);
                break;

                case "Линь":
                fish = new Tench(minDeep, maxDeep, coef, baits);
                break;
            }
            return fish;
        }
    }
}