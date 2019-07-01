
using StrategyGame.Model.Enums;

namespace StrategyGame.Bll.DTOs
{
    public class FejlesztesInfoDTO
    {
        public FejlesztesInfoDTO() { }
        public FejlesztesInfoDTO(FejlesztesTipus t, bool k, long ak)
        {
            Tipus = t;
            Kifejlesztve = k;
            AktualisKor = ak;
        }
        public FejlesztesTipus Tipus { get; set; }

        public bool Kifejlesztve { get; set; }

        public long AktualisKor { get; set; }
    }
}
