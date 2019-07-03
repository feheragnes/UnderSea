using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class FelfedezesDTO
    {
         public OrszagDTO TamadoOrszag { get; set; }
        public OrszagDTO VedekezoOrszag { get; set; }
        public List<FelfedezoDTO> Felfedezos { get; set; }
        public List<SeregInfoDTO> VedekezoCsapat { get; set; }
        public FelfedezesEredmenyTipus FelfedezesEredmeny { get; set; }
        public long VedekezoGyongy { get; set; }
        public long VedekezoKorall { get; set; }
    }
}
