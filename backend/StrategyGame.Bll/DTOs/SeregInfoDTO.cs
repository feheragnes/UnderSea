using StrategyGame.Model.Enums;

namespace StrategyGame.Bll.DTOs
{
    public class SeregInfoDTO
    {
        public SeregInfoDTO()
        {

        }

        public EgysegTipus Tipus { get; set; }
        public long Mennyiseg { get; set; }
        public long Ar { get; set; }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Szint { get; set; }
    }
}
