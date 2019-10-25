using Fishing.BL.Model.Waters;

namespace Fishing.BL.Model.MapFactory
{
    internal class MFactory
    {
        private Water water;

        public MFactory(Water w)
        {
            water = w;
        }

        public void CreateMap()
        {
            if (water is Meshera)
            {
                MesheraMap map = new MesheraMap();
                map.Show();
            }
            if (water is Ozero)
            {
                Map map = new Map();
                map.Show();
            }
        }
    }
}