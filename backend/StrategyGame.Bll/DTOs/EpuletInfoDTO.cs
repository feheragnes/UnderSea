using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class EpuletInfoDTO
    {

        public EpuletInfoDTO(string t, long ar, long m)
        {
            Tipus = t;
            Ar = ar;
            Mennyiseg = m;
        }

        public string Tipus { get; set; }
        public long Ar { get; set; }
        public long Mennyiseg { get; set; }
    }
}
