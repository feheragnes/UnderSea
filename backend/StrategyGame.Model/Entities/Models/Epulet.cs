using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public abstract class Epulet
    {
        [Key]
        int EpuletId { get; set; }

        int Ar { get; set; }
             
        int Korok { get; set; }
   
    }


    public class Aramlasiranyito : Epulet
    {
        int Nepesseg { get; set; }

        int Korall { get; set; }
    }
        
    public class Zatonyvar : Epulet
    {
        int Szallas { get; set; }
    }
 }