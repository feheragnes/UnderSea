
using StrategyGame.Bll.DTOs.Egysegek;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class CsapatDTO
    {
        public Guid Id { get; set; }
        public OrszagDTO Celpont { get; set; }
        public OrszagDTO Tulajdonos { get; set; }
        public HarcEredmenyTipus Kimenetel { get; set; }
        public IList<EgysegDTO> Egysegs { get; set; } = new List<EgysegDTO>();
        public IList<SeregInfoDTO> TamadoEgysegs { get; set; } = new List<SeregInfoDTO>();
        public IList<SeregInfoDTO> VedekezoEgysegs { get; set; } = new List<SeregInfoDTO>();
        public long TamadoEro => Convert.ToInt64(
            Convert.ToDouble(
                (TamadoEgysegs as List<SeregInfoDTO>)
                .Sum(x => x.Tamadas * x.Mennyiseg))
            * (Convert.ToDouble(Tulajdonos.TamadoBonusz) / 100.0) + 1);
        public long VedekezoEro => Convert.ToInt64(
            Convert.ToDouble(
                (VedekezoEgysegs as List<SeregInfoDTO>)
                .Sum(x => x.Vedekezes * x.Mennyiseg))
            * (Convert.ToDouble(Celpont.VedekezoBonusz) / 100.0) + 1);

    }
}
