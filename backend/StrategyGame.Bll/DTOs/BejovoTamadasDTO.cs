using System.Collections.Generic;

namespace StrategyGame.Bll.DTOs
{
    public class BejovoTamadasDTO
    {
        public string CelpontNev { get; set; }
        public string TamadoNev { get; set; }

        public List<SeregInfoDTO> TamadoEgysegek { get; set; }
    }
}
