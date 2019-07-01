using System;
using System.Collections.Generic;

namespace StrategyGame.Bll.DTOs
{
    public class OrszagDTO
    {
        public Guid Id { get; set; }

        public string Nev { get; set; }

        public long Gyongy { get; set; }

        public long Korall { get; set; }
        public long Helyezes { get; set; }
        public long KorallTermeles { get; set; }
        public long GyongyTermeles { get; set; }
        public long EpuloAramlasIranyito { get; set; }
        public long EpuloZatonyVar { get; set; }
        public long VedekezoBonusz { get; set; }
        public long TamadoBonusz { get; set; }
        public IList<SeregInfoDTO> SeregInfoDTOs { get; set; }
        public IList<EpuletInfoDTO> EpuletInfoDTOs { get; set; }


    }
}
