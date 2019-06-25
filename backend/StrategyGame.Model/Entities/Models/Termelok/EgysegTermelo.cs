using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Termelok
{
    public class EgysegTermelo : AbstractTermelo
    {
        public Guid id { get; set; }

        public long Ertek { get; set; }
    }
}
