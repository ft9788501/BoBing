using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Hubs
{
    public class BoBingHub : Hub
    {
        public const string HubUrl = "/bobing";

        public async Task BoBing()
        {
            await Clients.All.SendAsync(nameof(BoBing));
        }

        public async Task RefreshDices(IEnumerable<int> dices)
        {
            await Clients.All.SendAsync(nameof(RefreshDices), dices);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
