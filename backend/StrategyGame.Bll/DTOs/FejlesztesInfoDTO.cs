using StrategyGame.Bll.DTOs.DTOEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class FejlesztesInfoDTO
    {
        public FejlesztesInfoDTO() { }
        public FejlesztesInfoDTO(FejlesztesTipus t, bool k, long ak)
        {
            Tipus = t;
            Kifejlesztve = k;
            AktualisKor = ak;
        }
        public FejlesztesTipus Tipus { get; set; }

        public bool Kifejlesztve { get; set; }

        public long AktualisKor { get; set; }
    }
}
