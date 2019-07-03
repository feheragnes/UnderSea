using StrategyGame.Bll.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs.Egysegek
{
    public class FelfedezoDTO : EgysegDTO, IEgyseg
    {
        public long Ertek { get; set; } = 5;
        public long KemkedesiKepesseg{ get; set; } = 5;
    }
}
