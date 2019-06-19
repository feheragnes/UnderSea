using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Fejlesztesek
{
    public abstract class FejlesztesDTO
    {
        public Guid Id { get; set; }
        public long Noveles { get; set; }
        public long Korok { get; set; }
    }
}
