using StrategyGame.Model.Enums;

namespace StrategyGame.Bll.DTOs
{
    public class SeregInfoDTO
    {
        public SeregInfoDTO()
        {

        }
        public SeregInfoDTO(long m, EgysegTipus tipus)
        {
            Mennyiseg = m;
            Tipus = tipus;

            if (tipus == EgysegTipus.CsataCsiko)
            {
                Ar = 50;
                Tamadas = 2;
                Vedekezes = 6;
            }
            if (tipus == EgysegTipus.RohamFoka)
            {
                Ar = 50;
                Tamadas = 6;
                Vedekezes = 2;
            }
            if (tipus == EgysegTipus.LezerCapa)
            {
                Ar = 100;
                Tamadas = 5;
                Vedekezes = 5;
            }
        }

        public EgysegTipus Tipus { get; set; }
        public long Mennyiseg { get; set; }
        public long Ar { get; set; }
        public long Tamadas { get; set; }
        public long Vedekezes { get; set; }
        public long Szint { get; set; }
        public long CsatakSzama { get; set; }

    }
}
