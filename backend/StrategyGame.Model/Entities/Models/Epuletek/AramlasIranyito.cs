using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public class AramlasIranyito : Epulet
    {

        public AramlasIranyito(long ar, long szuksKorok, long nep, long korall) : base(ar, szuksKorok)
        {
            Nepesseg = nep;
            Korall = korall;
        }
        public long Nepesseg { get; set; }


        public long Korall { get; set; }

    }
}
