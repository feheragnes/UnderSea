using StrategyGame.Model.Entities.Models.Termelok;

namespace StrategyGame.Model.Entities.Models.Epuletek
{
    public class ZatonyVar : Epulet
    {
        public ZatonyVar() : base()
        {
            Ar = 1000;
            Szallas = new EgysegTermelo();
            Szallas.Ertek = 200;
            SzuksegesKorok = 5;
        }

        public EgysegTermelo Szallas { get; set; }
    }
}
