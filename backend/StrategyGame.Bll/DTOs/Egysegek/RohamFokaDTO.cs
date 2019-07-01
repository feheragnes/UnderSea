using StrategyGame.Bll.ServiceInterfaces;

namespace StrategyGame.Bll.DTOs.Egysegek
{
    internal class RohamFokaDTO : EgysegDTO, IEgyseg
    {
        public long Ertek { get; set; } = 5;
    }
}
