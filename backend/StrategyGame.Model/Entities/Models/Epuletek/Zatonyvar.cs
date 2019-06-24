using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public class ZatonyVar : Epulet
    {
        public ZatonyVar(): base()
        {
            Ar = 1000;
            SzuksegesKorok = 5;
            Szallas = 200;
        }
        public long Szallas { get; set; }

    }
}
