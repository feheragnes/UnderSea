using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.FejlesztesViewModels
{
    public class FejlesztesInfoViewModel
    {
        public string Tipus { get; set; }

        public bool Kifejlesztve { get; set; }

        public long AktualisKor { get; set; }
    }
}
