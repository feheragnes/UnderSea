using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class BejovoFelfedezesDTO
    {
        public string CelpontNev { get; set; }
        public string TulajdonosNev { get; set; }

        public List<SeregInfoDTO> TamadoFelfedezok { get; set; }
    }
}
