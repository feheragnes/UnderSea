using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public class Fejlesztes
    {
        [Key]
        public int FejlesztesId { get; set; }
        public int Korok { get; set; }

    }

    public class IszapTraktor : Fejlesztes
    {
        public int Korall { get; set; }
    }
    public class IszapKombajn : Fejlesztes
    {
        public int Korall { get; set; }
    }
    public class KorallFal : Fejlesztes
    {
        public int Vedelem { get; set; }

    }
    public class SzonarAgyu : Fejlesztes
    {
        public int Tamadas { get; set; }
    }
    public class VizalattiHarcmuveszet : Fejlesztes
    {
        public int Tamadas { get; set; }
        public int Vedekezes { get; set; }
    }
    public class Alkimia : Fejlesztes
    {
        public int Ado { get; set; }
    }
}
