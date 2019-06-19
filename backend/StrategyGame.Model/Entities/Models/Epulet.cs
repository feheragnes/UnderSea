using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public abstract class Epulet
    {
        [Key]
        public int EpuletId { get; set; }

        public int Ar { get; set; }
             
        public int Korok { get; set; }
   
    }


    public class AramlasIranyito : Epulet
    {
        public int Nepesseg { get; set; }

        public int Korall { get; set; }
    }
        
    public class ZatonyVar : Epulet
    {
        public int Szallas { get; set; }
    }
 }