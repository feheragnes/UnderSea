using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public abstract class Egyseg
    {
        [Key]
        public int EgysegId { get; set; }
        public int Tamadas { get; set; }
        public int Vedekezes { get; set; }
        public int Ar { get; set; }
        public int Zsold { get; set; }
        public int Ellatas { get; set; }
    }

    public class RohamFoka : Egyseg
    {

    }

    public class CsataCsiko : Egyseg
    {

    }

    public class LezerCapa : Egyseg
    {

    }
}
