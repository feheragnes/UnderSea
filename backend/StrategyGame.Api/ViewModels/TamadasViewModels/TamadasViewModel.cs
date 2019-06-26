using StrategyGame.Api.ViewModels.EgysegViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.TamadasViewModels
{
    public class TamadasViewModel
    {
        public IList<string> Orszag { get; set; }
        public IList<TamadoSeregInfoViewModel> Sereg { get; set; }
    }
}
