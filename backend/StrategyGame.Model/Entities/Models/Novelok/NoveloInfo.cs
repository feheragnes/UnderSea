using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Novelok
{
    public class NoveloInfo
    {
        public Guid Id { get; set; }
        public NoveloTipus Tipus { get; set; }
        public long Ertek { get; set; }
    }
}
