using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Egysegek
{
    public abstract class Egyseg
    {

        public Egyseg(long t, long v, long ar, long zsold, long ellatas)
        {
            Tamadas = t;
            Vedekezes = v;
            Ar = ar;
            Zsold = zsold;
            Ellatas = ellatas;
        }
        public Guid Id { get; set; }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Ar { get; set; }
        public long Zsold { get; set; }
        public long Ellatas { get; set; }
    }

 
}
