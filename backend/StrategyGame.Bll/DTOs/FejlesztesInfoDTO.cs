using StrategyGame.Bll.DTOs.DTOEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class FejlesztesInfoDTO
    {
        public FejlesztesInfoDTO(FejlesztesTipus t, bool k)
        {
            Tipus = t;
            Kifejlesztve = k;
        }
        public FejlesztesTipus Tipus { get; set; }

        public bool Kifejlesztve { get; set; }

        public long Ar { get; set; }
    }
}
