using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Egysegek
{
    public class EgysegInfo
    {
        public Guid Id { get; set; }
        public EgysegTipus Tipus { get; set; }
        public long Ar { get; set; }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Zsold { get; set; }
        public long Ellatas { get; set; }
    }
}
