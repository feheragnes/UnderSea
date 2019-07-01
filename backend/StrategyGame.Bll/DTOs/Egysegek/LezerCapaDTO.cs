using StrategyGame.Bll.ServiceInterfaces;

namespace StrategyGame.Bll.DTOs.Egysegek
{
    internal class LezerCapaDTO : EgysegDTO, IEgyseg
    {
        public long Ertek { get; set; } = 10;
    }
}
