using StrategyGame.Model.Entities.Models.Termelok;
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
            Nepesseg = new NepessegTermelo();
            Korall = new KorallTermelo();
            Nepesseg.Ertek= 50;
            Korall.Ertek = 200;
            SzuksegesKorok = 5;
        }
      
        public  NepessegTermelo Nepesseg { get; set; }


        public KorallTermelo Korall { get; set; }

    }
}
