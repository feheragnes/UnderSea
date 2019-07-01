using StrategyGame.Model.Enums;
using System.Collections.Generic;

namespace StrategyGame.Bll.DTOs
{
    public class HarcDTO
    {
        public OrszagDTO TamadoOrszag { get; set; }
        public OrszagDTO VedezoOrszag { get; set; }
        public List<SeregInfoDTO> TamadoCsapat { get; set; }
        public List<SeregInfoDTO> VedekezoCsapat { get; set; }
        public HarcEredmenyTipus HarcEredmeny { get; set; }

    }
}
