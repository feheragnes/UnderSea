using StrategyGame.Model.Entities.Models.Novelok;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class KorallFal : Fejlesztes
    {
        public KorallFal() : base()
        {
            Novelo.Add(new VedekezesNovelo(20));
        }
    }
}
