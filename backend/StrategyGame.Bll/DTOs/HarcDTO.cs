using StrategyGame.Bll.DTOs.DTOEnums;
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Model.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
