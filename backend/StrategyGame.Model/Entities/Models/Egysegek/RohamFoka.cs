using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Egysegek
{
    public class RohamFoka : Egyseg
    {
        public RohamFoka() : base()
        {
            Ar = 50;
            Tamadas = 6;
            Vedekezes = 2;
            Zsold = 1;
            Ellatas = 1;
        }
    }
}
