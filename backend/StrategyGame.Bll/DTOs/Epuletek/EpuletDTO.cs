using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    class EpuletDTO
    {
        public Guid Id { get; set; }

        public long Ar { get; set; }

        public long SzuksegesKorok { get; set; }

        public long AktualisKor { get; set; }

        public bool Felepult { get; set; }
    }
}
