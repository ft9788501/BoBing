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
        private readonly Dictionary<BoBingAwardType, Queue<BoBingPrize>> _boBingPrizes;
        private int participantTurnIndex = -1;

        public BoBingRules Rules { get; }
        public string Name { get; }
        public string Password { get; }
        public IEnumerable<BoBingParticipant> Participants => _boBingParticipants;
        public BoBingParticipant ParticipantTurn { get; private set; }
        public int[] Dices { get; private set; } = Array.Empty<int>();

        public BoBingRoom(BoBingRules rules, string name, string password)
        {
            _boBingPrizes = rules.BoBingPrizes;
            Rules = rules;
            Name = name;
            Password = password;
        }

        public int GetPrizesRemaining(BoBingAwardType awardType)
        {
            if (_boBingPrizes.TryGetValue(awardType, out Queue<BoBingPrize> prizes))
            {
                return prizes.Count;
            }
            return 0;
        }

        public void RefreshDices()
        {
            Dices = Enumerable.Range(0, 6).Select(x => random.Next(0, 6)).ToArray();
            DicesChanged?.Invoke(this, Dices);
            var award = CheckAwardType(Dices);
            var prize = PickPrize(award);
            ParticipantTurn.AddPrize(prize);
        }

        public void MoveToNextParticipant()
        {
            participantTurnIndex = ++participantTurnIndex % _boBingParticipants.Count;
            ParticipantTurn = _boBingParticipants[participantTurnIndex];
            ParticipantTurnChanged?.Invoke(this, ParticipantTurn);
        }

        public void Join(BoBingParticipant boBingParticipant)
        {
            _boBingParticipants.Add(boBingParticipant);
            if (_boBingParticipants.Count == 1)
            {
                MoveToNextParticipant();
            }
        }

        private BoBingPrize PickPrize(BoBingAwardType awardType)
        {
            if (_boBingPrizes.TryGetValue(awardType, out Queue<BoBingPrize> prizes) && prizes.TryDequeue(out BoBingPrize prize))
            {
                return prize;
            }
            return null;
        }

        private BoBingAwardType CheckAwardType(int[] dices)
        {
            dices = dices.Select(d => d + 1).ToArray();
            //444411
            if (dices.GroupBy(d => d).Count() == 2 &&
                dices.GroupBy(d => d).Any(g => g.Key == 4 && g.AsEnumerable() is IEnumerable<int> group && group.Count() == 4) &&
                dices.GroupBy(d => d).Any(g => g.Key == 1))
            {
                return BoBingAwardType.Award6;
            }
            //444444
            if (dices.Count(d => d == 4) == 6)
            {
                return BoBingAwardType.Award6;
            }
            //111111
            if (dices.Count(d => d == 1) == 6)
            {
                return BoBingAwardType.Award6;
            }
            //666666
            if (dices.Count(d => d == 1) == 6)
            {
                return BoBingAwardType.Award6;
            }
            //xxxxxx
            if (dices.GroupBy(d => d).Count() == 1)
            {
                return BoBingAwardType.Award6;
            }
            //44444a
            if (dices.GroupBy(d => d).Any(g => g.Key == 4 && g.AsEnumerable() is IEnumerable<int> group && group.Count() == 5))
            {
                return BoBingAwardType.Award6;
            }
            //xxxxxa
            if (dices.GroupBy(d => d).Any(g => g.AsEnumerable() is IEnumerable<int> group && group.Count() == 5))
            {
                return BoBingAwardType.Award6;
            }
            //4444ab
            if (dices.Count(d => d == 4) == 4)
            {
                return BoBingAwardType.Award6;
            }
            //123456
            if (dices.Distinct().Count() == 6)
            {
                return BoBingAwardType.Award5;
            }
            //444abc
            if (dices.Count(d => d == 4) == 3)
            {
                return BoBingAwardType.Award4;
            }
            //xxxxab
            if (dices.GroupBy(d => d).Any(g => g.AsEnumerable() is IEnumerable<int> group && group.Count() == 4))
            {
                return BoBingAwardType.Award3;
            }
            //44abcd
            if (dices.Count(d => d == 4) == 2)
            {
                return BoBingAwardType.Award2;
            }
            //4abcde
            if (dices.Count(d => d == 4) == 1)
            {
                return BoBingAwardType.Award1;
            }
            return BoBingAwardType.None;
        }
    }
}
