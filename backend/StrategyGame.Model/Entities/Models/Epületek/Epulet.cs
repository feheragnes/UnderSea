using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models
{
    public abstract class Epulet
    {
       
        public Guid Id { get; set; }

        public long Ar { get; set; }
             
        public long Korok { get; set; }
   
    }
   
 }