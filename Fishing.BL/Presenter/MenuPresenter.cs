using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Hooks;
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
            Item.RoadShop.Add(Road.Titanium);
            Item.RoadShop.Add(Road.Achilles);
            Item.RoadShop.Add(Road.YSuperCarp);
            Item.RoadShop.Add(Road.SuperFisher);
            Item.ReelShop.Add(Reel.Hydra);
            Item.ReelShop.Add(Reel.SYBERIA_LT_2);
            Item.ReelShop.Add(Reel.Quest_Reel);
            Item.LeskaShop.Add(FLine.Quest_Fishers);
            Item.LeskaShop.Add(FLine.Colorado);
            Item.LeskaShop.Add(FLine.Indiana1500);
            Item.LeskaShop.Add(FLine.Atlantic);
            Item.ReelShop.Add(Reel.SYBERIA_4);
            Item.ReelShop.Add(Reel.Zymix);
            Item.ReelShop.Add(Reel.Syberia_1);
            Item.ReelShop.Add(Reel.TBR_4000);     
            Item.RoadShop.Add(Road.Vesta276);
            Item.HooksShop.Add(FeederHook.feeder1);
            Item.HooksShop.Add(FeederHook.feeder2);
            Item.HooksShop.Add(FeederHook.feeder3);
            Item.HooksShop.Add(FloatsHook.baitHolder);
            Item.HooksShop.Add(FloatsHook.barakuda);
            Item.HooksShop.Add(FloatsHook.takara);
            Item.HooksShop.Add(FloatsHook.wormStrong);

            FishBait.FishBaits.Add(new Bait("Сыр", 30, 500, Images.cheeze));
            FishBait.FishBaits.Add(new Bait("Червь", 30, 50, Images.worm));
            FishBait.FishBaits.Add(new Bait("Опарыш", 30, 150, Images.worm));
            FishBait.FishBaits.Add(new Bait("Опарыш", 30, 150, Images.zhivec));
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