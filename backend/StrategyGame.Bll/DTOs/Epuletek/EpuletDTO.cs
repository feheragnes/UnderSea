using System;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    public abstract class EpuletDTO
    {
        public Guid Id { get; set; }

        public long Ar { get; set; }

        public long SzuksegesKorok { get; set; }

        public long AktualisKor { get; set; }

        public bool Felepult { get; set; }

        public Task NextTurn()
        {
            throw new NotImplementedException();
        }

    }
}
