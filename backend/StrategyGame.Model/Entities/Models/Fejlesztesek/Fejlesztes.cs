using StrategyGame.Model.Entities.Models.Novelok;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public abstract class Fejlesztes
    {
        public Guid Id { get; set; }
        public long SzuksegesKorok { get; set; }
        public long AktualisKor { get; set; }
        public bool Kifejlesztve { get; set; }
        public Orszag Orszag { get; set; }

        public virtual IList<AbstractNovelo> Novelo { get; set; } = new List<AbstractNovelo>();

        public Fejlesztes()
        {
            SzuksegesKorok = 15;
            AktualisKor = 0;
            Kifejlesztve = false;
        }
    }
}

    
