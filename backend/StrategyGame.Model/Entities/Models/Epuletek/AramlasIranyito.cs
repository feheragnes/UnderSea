using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public class AramlasIranyito : Epulet
    {
        public AramlasIranyito() :base()
        {
            Ar = 1000;
            Nepesseg = 50;
            Korall = 200;
            SzuksegesKorok = 5;
        }
      
        public long Nepesseg { get; set; }


        public long Korall { get; set; }

    }
}
