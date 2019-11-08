using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.Lures;
using Fishing.BL.Resources.Images;
using Fishing.View.Menu;
using Saver.BL.Controller;
using System;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class MenuPresenter : BasePresenter
    {
        private readonly IMenu view;

        public MenuPresenter(IMenu view)
        {
            this.view = view;
            view.Presenter = this;
            view.ExitButtonClick += View_ExitButtonClick;
            view.MenuLoad += Menu_Load;
            BaseController.GetController().Initiallize();
        }

        private void View_ExitButtonClick(object sender, EventArgs e)
        {
            BaseController.GetController().SavePlayer();
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            view.LowerLValue = Player.GetPlayer().NickName;

            Item.Reels.Add(new Reel("Hydra", 100, 6, 30, 100000, Images.Hydra));
            Item.Reels.Add(new Reel("SYBERIA_LT_2", 100, 4, 60, 200000, Images.Syberia_LT_2));
            Item.Reels.Add(new Reel("Quest_Reel", 100, 2, 60, 400000, Images.Quest_Reel));
            Item.Reels.Add(new Reel("SYBERIA 4", 100, 5, 80, 600000, Images.Syberia_HD_4));
            Item.Reels.Add(new Reel("Zymix", 100, 7, 90, 400000, Images.Zymix));
            Item.Reels.Add(new Reel("Syberia 1", 100, 4, 40, 300000, Images.Syberia_HD_1));
            Item.Reels.Add(new Reel("TBR 4000", 100, 1, 50, 450000, Images.TBR_4000));

            Item.FLines.Add(new FLine("Indiana 4000", 4000, 500, Images.indiana));
            Item.FLines.Add(new FLine("Quest_fishers 90000", 90000, 200000, Images.Quest_Fishers));
            Item.FLines.Add(new FLine("Colorado 30000", 30000, 100000, Images.Colorado));
            Item.FLines.Add(new FLine("Atlantic", 1000000, 1000000, Images.Atlantic));

            Item.Roads.Add(new Spinning("Titanium", 100, 40000, 300000, Images.Titanium));
            Item.Roads.Add(new Spinning("Achilles", 100, 5000, 3000, Images.Achilles_233));
            Item.Roads.Add(new Feeder("Yellow super Carp", 100, 100000, 600000, Images.Yellow_SuperCarp));
            Item.Roads.Add(new Spinning("Hearty Rose Jigging", 100, 95000, 700000, Images.SuperFisher_950));
            Item.Roads.Add(new Feeder("Vesta 276", 100, 7000, 15000, Images.Vesta_276));

            Item.Hooks.Add(new FeederHook("Фидер 1", 20, 800, HooksImg.Fider));
            Item.Hooks.Add(new FeederHook("Фидер 2", 10, 1800, HooksImg.Fider_2));
            Item.Hooks.Add(new FeederHook("Фидер 3", 5, 2800, HooksImg.Fider_3));
            Item.Hooks.Add(new FloatsHook("Bait Holder", 25, 800, HooksImg.BaitHolder));
            Item.Hooks.Add(new FloatsHook("Barracuda", 20, 1500, HooksImg.Barracuda));
            Item.Hooks.Add(new FloatsHook("Takara 2002", 12, 2500, HooksImg.Takara_2002));
            Item.Hooks.Add(new FloatsHook("Worm_X_Strong", 7, 5000, HooksImg.Worm_X_Strong));

            FishBait.FishBaits.Add(new Bait("Сыр", 30, 500, Images.cheeze));
            FishBait.FishBaits.Add(new Bait("Червь", 30, 50, Images.worm));
            FishBait.FishBaits.Add(new Bait("Опарыш", 30, 150, Images.oparysh));
            FishBait.FishBaits.Add(new Bait("Живец", 30, 150, Images.zhivec));
            FishBait.FishBaits.Add(new Bait("Икра", 30, 1000, Images.ikra));
            FishBait.FishBaits.Add(new Bait("Кукуруза", 30, 250, Images.corn));
            FishBait.FishBaits.Add(new Wobbler("Составник", Size.Large, DeepType.Flying, 3000, Images.Vob_3015));
            FishBait.FishBaits.Add(new Wobbler("Составник", Size.Large, DeepType.Flying, 3000, Images.Vob_3015));
            FishBait.FishBaits.Add(new Wobbler("Воблер 2", Size.XL, DeepType.Flying, 3000, Images.Vob_3002));
            FishBait.FishBaits.Add(new Wobbler("Воблер 3", Size.Small, DeepType.Top, 3000, Images.Vob_3003));
            FishBait.FishBaits.Add(new Wobbler("Воблер 4", Size.Large, DeepType.Deep, 3000, Images.Vob_3001));
            FishBait.FishBaits.Add(new Wobbler("Воблер 1 Дип", Size.Large, DeepType.Deep, 3000, Images.Deep_112));
            FishBait.FishBaits.Add(new Wobbler("Воблер 2 Дип", Size.Large, DeepType.Deep, 3000, Images.Deep_115));
            FishBait.FishBaits.Add(new Pinwheel("Вертушка 1", Size.Small, DeepType.Deep, 500, Images.Circl_5103));
            FishBait.FishBaits.Add(new Pinwheel("Вертушка 2", Size.Small, DeepType.Deep, 500, Images.Circl_5113));
            FishBait.FishBaits.Add(new Shaker("Колебалка 1", Size.XL, DeepType.Deep, 500, Images.Vib_6000));
            FishBait.FishBaits.Add(new Shaker("Колебалка 2", Size.Large, DeepType.Deep, 500, Images.Vib_6012));
            FishBait.FishBaits.Add(new Jig("Виброхвост 1", Size.Small, DeepType.Jig, 500, Images.Tvis_103));
            FishBait.FishBaits.Add(new Jig("Виброхвост 2", Size.Small, DeepType.Jig, 500, Images.Tvis_105));
            FishBait.FishBaits.Add(new Jig("Виброхвост 3", Size.Large, DeepType.Jig, 500, Images.Tvis_104));
            FishBait.FishBaits.Add(new Jig("Виброхвост 4", Size.XL, DeepType.Jig, 500, Images.Tvis_119));

            Food.Foods.Add(new Food("Хлеб", 50, 10, Images.hleb));
            Food.Foods.Add(new Food("Икра", 1500, 30, Images.ikra));
            Food.Foods.Add(new Food("Икра Чёрная", 5000, 70, Images.black));
            Food.Foods.Add(new Food("Сыр", 1000, 50, Images.black));
            Food.Foods.Add(new Food("Печенье", 500, 25, Images.black));
            Food.Foods.Add(new Food("Скумбрия", 700, 35, Images.black));
            Food.Foods.Add(new Food("Рыбные консервы", 700, 35, Images.fishkonc));
            Food.Foods.Add(new Food("Бананы", 250, 5, Images.banany));
            Food.Foods.Add(new Food("Апельсины", 500, 20, Images.apelsin));
        }

        public override void Run()
        {
            view.Open();
        }

        public override void End()
        {
            view.Down();
        }
    }
}