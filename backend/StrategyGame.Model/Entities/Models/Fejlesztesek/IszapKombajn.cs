using StrategyGame.Model.Entities.Models.Novelok;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class IszapKombajn : Fejlesztes
    {
        public IszapKombajn() : base()
        {
            Novelo.Add(new KorallNovelo(15));
        }
    }
}
