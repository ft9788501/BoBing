using BoBing.Shared.Data;
using BoBing.Shared.Hubs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
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
        private BoBingParticipant _localParticipant;
        private BoBingRoom _boBingRoom;

        [Inject]
        private NavigationManager Navigation { get; set; }
        [Inject]
        private BoBingRoomsService BoBingRoomsService { get; set; }
        [Inject]
        private IJSRuntime JS { get; set; }

        private async Task ThrowingDice()
        {
            _boBingRoom.RefreshDices();
            await JS.InvokeVoidAsync("dice", _boBingRoom.Dices.ToArray(), true);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                var dices = _boBingRoom.Dices.ToArray();
                await JS.InvokeVoidAsync("dice", dices, false);
                _boBingRoom.DicesChanged += (s, e) =>
                {
                    JS.InvokeVoidAsync("dice", e, true);
                };
            }
        }

        protected override void OnParametersSet()
        {
            //http://xxxxxxxxx/room?name=xxxx&pwd=xxx&participant=xxxx
            var query = QueryHelpers.ParseQuery(Navigation.ToAbsoluteUri(Navigation.Uri).Query);
            if (query.TryGetValue("name", out var roomName))
            {
                if (BoBingRoomsService.TryGetRoom(roomName, out BoBingRoom boBingRoom))
                {
                    query.TryGetValue("pwd", out var roomPassword);
                    if (string.IsNullOrEmpty(boBingRoom.Password) || boBingRoom.Password == roomPassword)
                    {
                        _boBingRoom = boBingRoom;
                    }
                    else
                    {
                        //TODO show alert password error
                        return;
                    }
                }
                else
                {
                    _boBingRoom = BoBingRoomsService.CreateRoom(new BoBingRules(BoBingPrize.CreatePrizes(32, 16, 8, 4, 2, 1)), roomName, null);
                }
                if (query.TryGetValue("participant", out var participantName))
                {
                    _localParticipant = _boBingRoom.Participants.FirstOrDefault(p => p.Name == participantName);
                    if (_localParticipant == null)
                    {
                        _localParticipant = new BoBingParticipant(participantName);
                        _boBingRoom.Join(_localParticipant);
                    }
                }
            }
            else
            {
                //TODO show alert url params error
            }
            base.OnParametersSet();
        }
    }
}
