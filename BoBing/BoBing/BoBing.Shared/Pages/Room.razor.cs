﻿using BoBing.Shared.Data;
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
        private BoBingRoom _boBingRoom;
        private BoBingParticipant _localParticipant;
        private bool isThrowing = false;

        [Inject]
        private NavigationManager Navigation { get; set; }
        [Inject]
        private BoBingRoomsService BoBingRoomsService { get; set; }
        [Inject]
        private BoBingLocalService BoBingLocalService { get; set; }
        [Inject]
        private IJSRuntime JS { get; set; }
        private bool ThrowingDiceable => (_localParticipant == _boBingRoom.ParticipantTurn) && !isThrowing;
        private string ThrowButtonText
        {
            get
            {
                if (ThrowingDiceable || isThrowing)
                {
                    return isThrowing ? "等待结果..." : "请投骰子";
                }
                else
                {
                    return $"等待 {_boBingRoom.ParticipantTurn?.Name} 投骰子...";
                }
            }
        }

        private async Task ThrowingDice()
        {
            if (!ThrowingDiceable)
            {
                return;
            }
            _boBingRoom.RefreshDices();
            isThrowing = true;
            StateHasChanged();
            await JS.InvokeVoidAsync("dice", _boBingRoom.Dices, true);
            await Task.Delay(1500);
            isThrowing = false;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                var dices = _boBingRoom.Dices;
                await JS.InvokeVoidAsync("dice", dices, false);
                _boBingRoom.DicesChanged += async (s, e) =>
                {
                    await JS.InvokeVoidAsync("dice", e, true);
                };
                _boBingRoom.ParticipantTurnChanged += (s, e) =>
                {
                    InvokeAsync(() =>
                    {
                        StateHasChanged();
                    });
                };
                _boBingRoom.PrizesPool.PrizesChanged += (s,e) =>
                {
                    BoBingLocalService.RefreshPrizesPool();
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
                    _boBingRoom = BoBingRoomsService.CreateRoom(new BoBingRules(new BoBingPrizesPoolOption(32, 16, 8, 4, 2, 1)), roomName, null);
                }
                BoBingLocalService.PrizesPool = _boBingRoom.PrizesPool;
                if (query.TryGetValue("participant", out var participantName))
                {
                    BoBingLocalService.LocalParticipantName = participantName;
                    _localParticipant = _boBingRoom.Participants.FirstOrDefault(p => p.Name == participantName);
                    if (_localParticipant == null)
                    {
                        _localParticipant = _boBingRoom.Join(participantName);
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
