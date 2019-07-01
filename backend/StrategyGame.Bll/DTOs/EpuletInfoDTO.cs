
using StrategyGame.Model.Enums;

namespace StrategyGame.Bll.DTOs
{
    public class EpuletInfoDTO
    {

        public EpuletInfoDTO() { }
        public EpuletInfoDTO(EpuletTipus t, long ar, long m)
        {
            Tipus = t;
            Ar = ar;
            Mennyiseg = m;
        }

        public EpuletTipus Tipus { get; set; }
        public long Ar { get; set; }
        public long Mennyiseg { get; set; }
    }
}
