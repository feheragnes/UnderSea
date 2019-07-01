using System.Threading.Tasks;

namespace StrategyGame.Bll.ServiceInterfaces
{
    public interface IEndTurnService
    {
        Task DoFejleszteses();
        Task SetOrszagScores();
        Task NextTurn();
    }
}
