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

        public event EventHandler<IEnumerable<int>> DicesChanged;

        private readonly List<BoBingParticipant> _boBingParticipants = new();
        private readonly Dictionary<BoBingAward, BoBingPrize[]> _boBingPrizes;

        public BoBingRules Rules { get; }
        public string Name { get; }
        public string Password { get; }
        public IEnumerable<BoBingParticipant> Participants => _boBingParticipants;
        public BoBingParticipant ParticipantTurn { get; }
        public IEnumerable<int> Dices { get; private set; } = Array.Empty<int>();

        public BoBingRoom(BoBingRules rules, string name, string password)
        {
            _boBingPrizes = rules.BoBingPrizes;
            Rules = rules;
            Name = name;
            Password = password;
        }

        public void RefreshDices()
        {
            Dices = Enumerable.Range(0, 6).Select(x => random.Next(0, 6)).ToArray();
            DicesChanged?.Invoke(this, Dices);
        }

        public void Join(BoBingParticipant boBingParticipant)
        {
            _boBingParticipants.Add(boBingParticipant);
        }
    }
}
