using StrategyGame.Api.ViewModels.EgysegViewModels;
using System.Collections.Generic;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class HarcViewModel
    {
        public string VedekezoOrszag { get; set; }
        public List<SeregInfoViewModel> TamadoCsapat { get; set; }
        public string HarcEredmeny { get; set; }
    }
}
