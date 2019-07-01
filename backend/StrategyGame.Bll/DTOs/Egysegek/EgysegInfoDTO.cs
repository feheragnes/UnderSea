
using StrategyGame.Model.Enums;

namespace StrategyGame.Bll.DTOs.Egysegek
{
    public class EgysegInfoDTO
    {
        public EgysegInfoDTO()
        {

        }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Ar { get; set; }
        public long Zsold { get; set; }
        public long Ellatas { get; set; }
        public long Mennyiseg { get; set; }
        public EgysegTipus Tipus { get; set; }
    }
}
