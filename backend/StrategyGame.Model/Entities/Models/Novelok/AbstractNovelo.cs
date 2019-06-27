using StrategyGame.Model.Entities.Models.Fejlesztesek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities.Models.Novelok
{
    public abstract class AbstractNovelo
    {
        public AbstractNovelo(long ertek)
        {
            Ertek = ertek;
        }
        public Guid Id { get; set; }
        public long Ertek { get; set; }
        public Fejlesztes Fejlesztes { get; set; }
        public Guid FejlesztesId { get; set; }
    }
}
