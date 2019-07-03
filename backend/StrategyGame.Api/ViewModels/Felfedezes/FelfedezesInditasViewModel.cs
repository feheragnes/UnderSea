using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Api.ViewModels.Felfedezes
{
    public class FelfedezesInditasViewModel
    {
        public string Orszag { get; set; }
        public List<KikuldottFelfedezoInfoViewModel> TamadoFelfedezok { get; set; }

    }
}
