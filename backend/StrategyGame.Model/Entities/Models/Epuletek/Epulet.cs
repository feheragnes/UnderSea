using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public abstract class Epulet
    {
       
        public Guid Id { get; set; }

        public long Ar { get; set; }
             
        public long SzuksegesKorok { get; set; }

        public long AktualisKor { get; set; }

        public bool Felepult { get; set; }
   
    }
   
 }