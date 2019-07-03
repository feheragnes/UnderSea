using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Egysegek
{
    public class Felfedezo : Egyseg
    {
        public long KemkedesiKepesseg { get; set; }
        public bool Felfedezett { get; set; }

        public Felfedezo() : base()
        {

        }
    }
}
