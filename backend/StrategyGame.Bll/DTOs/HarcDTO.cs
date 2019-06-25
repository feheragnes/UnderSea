using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Bll.DTOs.Egysegek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class HarcDTO
    {
        public List<SeregInfoDTO> TamadoCsapat { get; set; }
        public List<SeregInfoDTO> VedekezoCsapat { get; set; }
        public HarcEredmenyTipus HarcEredmeny { get; set; }

        public void CalculateEredmeny()
        {
            long tamadoEro = 0, vedekezoEro = 0;

            TamadoCsapat.ForEach(x =>
            {
                tamadoEro += (x.Tamadas * x.Mennyiseg);
            });

            VedekezoCsapat.ForEach(x =>
            {
                vedekezoEro += (x.Tamadas * x.Mennyiseg);
            });
        }
    }
}
