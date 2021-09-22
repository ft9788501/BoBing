using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingRoom
    {
        private static readonly Random random = new();

        public event EventHandler<int[]> DicesChanged;
        public event EventHandler<BoBingParticipant> ParticipantTurnChanged;

        private readonly List<BoBingParticipant> _boBingParticipants = new();
        private int participantTurnIndex = -1;
        private readonly BoBingPrizesPool _prizesPool;

        public string RoomName { get; }
        public string Password { get; }
        public BoBingRules Rules { get; }
        public IEnumerable<BoBingParticipant> Participants => _boBingParticipants;
        public BoBingParticipant ParticipantTurn { get; private set; }
        public int[] Dices { get; private set; } = Array.Empty<int>();
        public BoBingPrizesPool PrizesPool => _prizesPool;

        public BoBingRoom(BoBingRules rules, string roomName, string password)
        {
            _prizesPool = new BoBingPrizesPool(rules.PrizesPoolOption);
            Rules = rules;
            RoomName = roomName;
            Password = password;
        }

        public void RefreshDices()
        {
            Dices = Enumerable.Range(0, 6).Select(x => random.Next(0, 6)).ToArray();
            DicesChanged?.Invoke(this, Dices);
            var award = Rules.CheckAwardType(Dices);
            var prize = PrizesPool.PickPrize(award);
            ParticipantTurn.AddPrize(prize);
            MoveToNextParticipant();
        }

        public void MoveToNextParticipant()
        {
            ParticipantTurn = _boBingParticipants[participantTurnIndex = ++participantTurnIndex % _boBingParticipants.Count];
            ParticipantTurnChanged?.Invoke(this, ParticipantTurn);
        }

        public BoBingParticipant Join(string participantName)
        {
            var participant = new BoBingParticipant(this, participantName);
            _boBingParticipants.Add(participant);
            if (_boBingParticipants.Count == 1)
            {
                MoveToNextParticipant();
            }
            return participant;
        }
    }
}
