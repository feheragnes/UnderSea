using StrategyGame.Model.Entities.Models.Epuletek;
using System;

namespace StrategyGame.Model.Entities.Models.Termelok
{
    public abstract class AbstractTermelo
    {
        public Guid Id { get; set; }
        public Epulet Epulet { get; set; }
        public Guid EpuletId { get; set; }
    }
}
