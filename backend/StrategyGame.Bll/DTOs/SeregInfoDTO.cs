using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class SeregInfoDTO
    {

        public SeregInfoDTO(long m, int ar, string t)
        {
            Mennyiseg = m;
            Ar = ar;
            Tipus = t;
        }
        public long Mennyiseg { get; set; }
        public int Ar { get; set; }
        public string Tipus { get; set; }
    }
}
