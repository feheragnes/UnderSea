using StrategyGame.Bll.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs.Egysegek
{
    class RohamFokaDTO : EgysegDTO, IEgyseg
    {
        public long Ertek { get; set; } = 5;
    }
}
