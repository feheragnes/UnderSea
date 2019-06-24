using StrategyGame.Bll.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTOs.Epuletek
{
    public class AramlasIranyitoDTO : EpuletDTO, ITermelo, INepesseg
    {
        public long Nepesseg { get; set; }
        public long Korall { get; set; }

        public async Task<long> GetNepesseg()
        {
            return Nepesseg;
        }

        public Task NextTurn()
        {
            throw new NotImplementedException();
        }

        public async Task<OrszagDTO> SetTermeles(OrszagDTO orszag)
        {
                orszag.KorallTermeles += Korall;
                orszag.GyongyTermeles += Nepesseg * 50;
            return orszag;
        }
    }
}
