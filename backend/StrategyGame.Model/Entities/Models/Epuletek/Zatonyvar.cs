using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public class ZatonyVar : Epulet
    {
        public ZatonyVar(long ar, long szuksKorok, long szallas) : base(ar, szuksKorok)
        {
            Szallas = szallas;
        }
        public long Szallas { get; set; }

    }
}
