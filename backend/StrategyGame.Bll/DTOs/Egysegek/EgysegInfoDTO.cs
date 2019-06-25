using StrategyGame.Bll.DTOs.DTOEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs.Egysegek
{
    class EgysegInfoDTO
    {
        public EgysegInfoDTO()
        {

        }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Ar { get; set; }
        public long Zsold { get; set; }
        public long Ellatas { get; set; }
        public long Mennyiseg { get; set; }
        public EgysegTipus Tipus { get; set; }
    }
}
