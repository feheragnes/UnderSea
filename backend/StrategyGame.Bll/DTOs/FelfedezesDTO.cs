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
        public string VedekezoOrszag { get; set; }
        public List<SeregInfoDTO> Felfedezos { get; set; }
        public long VedekezoEro { get; set; }
        public FelfedezesEredmenyTipus FelfedezesEredmeny { get; set; }
        public long VedekezoGyongy { get; set; }
        public long VedekezoKorall { get; set; }
        public DateTime Idopont { get; set; }
    }
}
