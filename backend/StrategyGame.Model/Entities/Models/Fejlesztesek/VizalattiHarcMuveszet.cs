using StrategyGame.Model.Entities.Models.Novelok;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class VizalattiHarcmuveszet : Fejlesztes
    {
        public VizalattiHarcmuveszet() : base()
        {
            Novelo.Add(new TamadasNovelo(10));
            Novelo.Add(new VedekezesNovelo(10));
        }
    }
}
