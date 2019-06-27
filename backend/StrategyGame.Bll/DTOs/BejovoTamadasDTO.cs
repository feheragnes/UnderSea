using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class BejovoTamadasDTO
    {
        public string CelpontNev { get; set; }
        public string TamadoNev { get; set; }

        public List<SeregInfoDTO> TamadoEgysegek { get; set; }
    }
}
