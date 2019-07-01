using StrategyGame.Model.Entities.Models.Novelok;

namespace StrategyGame.Model.Entities.Models.Fejlesztesek
{
    public class Alkimia : Fejlesztes
    {
        public Alkimia() : base()
        {
            Novelo.Add(new AdoNovelo(30));
        }
    }
}
