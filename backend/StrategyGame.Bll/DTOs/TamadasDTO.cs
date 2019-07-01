using System.Collections.Generic;

namespace StrategyGame.Bll.DTOs
{
    public class TamadasDTO
    {
        public IList<string> EllensegesOrszagok { get; set; }

        public IList<SeregInfoDTO> OtthoniEgysegek { get; set; }
    }
}
