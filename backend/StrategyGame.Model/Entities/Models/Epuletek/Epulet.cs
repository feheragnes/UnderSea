﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public abstract class Epulet 
    {
        public Epulet()
        {
            AktualisKor = 0;
            Felepult = false;
        }
        public Guid Id { get; set; }

        public long Ar { get; set; }
             
        public long SzuksegesKorok { get; set; }

        public long AktualisKor { get; set; }

        public bool Felepult { get; set; }
        public Orszag Orszag { get; set; }

        //public Guid? OrszagId { get; set; }

    }
   
 }