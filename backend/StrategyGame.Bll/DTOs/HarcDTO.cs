using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Bll.DTOs.Egysegek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class HarcDTO
    {
        public List<EgysegDTO> TamadoCsapat { get; set; }
        public List<EgysegDTO> VedekezoCsapat { get; set; }
        public HarcEredmenyTipus HarcEredmeny { get; set; }

        public void CalculateEredmeny()
        {
            long tamadoEro = 0, vedekezoEro = 0;

            TamadoCsapat.ForEach(x =>
            {
              //  x.
            });
        }
    }
}
