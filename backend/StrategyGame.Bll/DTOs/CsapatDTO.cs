using StrategyGame.Bll.DTOs.Egysegek;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    class CsapatDTO
    {

        public Guid Id { get; set; }
        public OrszagDTO Celpont { get; set; }
        public OrszagDTO Tulajdonos { get; set; }
        public AllapotDTO Allapot { get; set; }
        public IList<EgysegDTO> Egysegs { get; set; } = new List<EgysegDTO>();
    }
}
