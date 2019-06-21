using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    class AramlasIranyitoDTO : EpuletDTO, IEpulet
    {
        public long Nepesseg { get; set; }
        public long Korall { get; set; }

        public async override Task<long> GetNepesseg()
        {
            return Nepesseg;
        }

        public Task NextTurn()
        {
            throw new NotImplementedException();
        }

        public async override Task<OrszagDTO> SetTermeles(OrszagDTO orszag)
        {
            if (Felepult == true)
            {
                orszag.KorallTermeles += Korall;
                orszag.GyongyTermeles += Nepesseg * 50;
            }
            return orszag;
        }
    }
}
