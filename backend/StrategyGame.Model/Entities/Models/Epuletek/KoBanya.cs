using StrategyGame.Model.Entities.Models.Termelok;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public class KoBanya : Epulet
    { 
        public KoBanya()
        {
            Ar = 1000;
            KoTermeles = new KoTermelo();
            KoTermeles.Ertek = 25;
            SzuksegesKorok = 5;
        }

        public KoTermelo KoTermeles { get; set; }
    }
}
