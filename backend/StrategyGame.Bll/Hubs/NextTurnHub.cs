using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Hubs
{
    public class NextTurnHub : Hub
    {
        public async Task NotifyNewTurn()
        {
            await Clients.All.SendAsync("Új kör!");
        }
    }
}
