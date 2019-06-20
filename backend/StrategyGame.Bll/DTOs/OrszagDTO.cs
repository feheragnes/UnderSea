using StrategyGame.Bll.DTOs.Fejlesztesek;
using StrategyGame.Bll.DTOs.Epuletek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class OrszagDTO
    {

        public Guid Id { get; set; }

        public long Gyongy { get; set; }

        public long Korall { get; set; }

        public IList<EpuletDTO> Epulets { get; set; } = new List<EpuletDTO>();

        public IList<CsapatDTO> OtthoniCsapats { get; set; } = new List<CsapatDTO>();
        public IList<CsapatDTO> TamadoCsapats { get; set; } = new List<CsapatDTO>();

        public IList<FejlesztesDTO> Fejleszteses { get; set; } = new List<FejlesztesDTO>();
    }
}
