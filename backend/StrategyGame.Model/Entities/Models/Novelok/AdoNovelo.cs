using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Novelok
{
    public class AdoNovelo : AbstractNovelo
    {
        public Guid id { get; set; }
        public int Ertek { get; set; }
    }
}
