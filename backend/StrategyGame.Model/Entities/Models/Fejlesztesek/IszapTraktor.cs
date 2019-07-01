using StrategyGame.Model.Entities.Models.Novelok;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class IszapTraktor : Fejlesztes
    {
        public IszapTraktor() : base()
        {
            Novelo.Add(new KorallNovelo(10));
        }
    }
}
