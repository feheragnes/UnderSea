using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    public abstract class EpuletDTO : IEpulet
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

        public abstract Task<OrszagDTO> SetTermeles(OrszagDTO orszag);
    }
}
