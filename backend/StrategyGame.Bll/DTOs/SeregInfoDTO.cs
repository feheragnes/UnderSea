﻿using StrategyGame.Bll.DTOs.DTOEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class SeregInfoDTO
    {
        public SeregInfoDTO(long m, int ar, EgysegTipus t)
        {
            Mennyiseg = m;
            Ar = ar;
            Tipus = t;
        }
        public EgysegTipus Tipus { get; set; }
        public long Mennyiseg { get; set; }
        public int Ar { get; set; }
       
    }
}