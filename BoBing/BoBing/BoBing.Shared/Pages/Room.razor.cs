using BoBing.Shared.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoBing.Shared.Pages
{
    public partial class Room
    {
        private static readonly Random random = new Random();

        private BoBingRoom BoBingRoom { get; set; }
        [Inject]
        NavigationManager Navigation { get; set; }
        [Inject]
        BoBingRoomsService BoBingRoomsService { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }

        private async Task StartDice()
        {
            var diceArr = Enumerable.Range(0, 6).Select(x => random.Next(0, 6)).ToArray();
            await JS.InvokeVoidAsync("dice", diceArr);
        }

        protected override void OnParametersSet()
        {
            //http://xxxxxxxxx/room?room_id=xxxx&pwd=xxx
            var query = QueryHelpers.ParseQuery(Navigation.ToAbsoluteUri(Navigation.Uri).Query);
            if (query.TryGetValue("name", out var roomName))
            {
                if (BoBingRoomsService.TryGetRoom(roomName, out BoBingRoom boBingRoom))
                {
                    query.TryGetValue("pwd", out var roomPassword);
                    if (string.IsNullOrEmpty(boBingRoom.Password) || boBingRoom.Password == roomPassword)
                    {
                        BoBingRoom = boBingRoom;
                    }
                    else
                    {
                        //TODO show alert password error
                    }
                }
                else
                {
                    BoBingRoom = BoBingRoomsService.CreateRoom(new BoBingRules(), roomName, null);
                }
            }
            else
            {
                //TODO show alert url params error
            }
        }
    }
}
