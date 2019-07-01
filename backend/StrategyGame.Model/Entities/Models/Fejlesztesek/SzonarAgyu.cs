using StrategyGame.Model.Entities.Models.Novelok;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class SzonarAgyu : Fejlesztes
    {
        public SzonarAgyu() : base()
        {
            Novelo.Add(new TamadasNovelo(20));
        }
    }
}
