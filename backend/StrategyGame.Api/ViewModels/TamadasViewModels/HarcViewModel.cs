using StrategyGame.Api.ViewModels.EgysegViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class HarcViewModel
    {
        public string TamadoOrszag { get; set; }
        public string VedekezoOrszag { get; set; }
        public List<SeregInfoViewModel> TamadoCsapat { get; set; }
        public List<SeregInfoViewModel> VedekezoCsapat { get; set; }

        public string HarcEredmeny { get; set; } 
    }
}
