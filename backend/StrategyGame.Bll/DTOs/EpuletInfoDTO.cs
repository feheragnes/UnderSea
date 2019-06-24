using StrategyGame.Bll.DTOs.DTOEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class EpuletInfoDTO
    {
        public EpuletInfoDTO(EpuletTipus t, long ar, long m)
        {
            Tipus = t;
            Ar = ar;
            Mennyiseg = m;
        }

        public EpuletTipus Tipus { get; set; }
        public long Ar { get; set; }
        public long Mennyiseg { get; set; }
    }
}
