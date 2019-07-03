using StrategyGame.Api.ViewModels.EgysegViewModels;
using StrategyGame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.Felfedezes
{
    public class FelfedezesEredmenyViewModel
    {
        public string Orszag { get; set; }
        public long Korall { get; set; }
        public long Gyongy { get; set; }
        public long VedekezoEro { get; set; }

        public FelfedezesEredmenyTipus Eredmeny { get; set; }
    }
}
