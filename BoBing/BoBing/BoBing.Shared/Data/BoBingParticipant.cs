using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingParticipant
    {
        private readonly BoBingRoom _room;
        private readonly List<BoBingPrize> _boBingPrizes = new();

        public string Name { get; }

        public IEnumerable<BoBingPrize> Prizes => _boBingPrizes;

        public BoBingParticipant(BoBingRoom room, string name)
        {
            _room = room;
            Name = name;
        }

        public void AddPrize(BoBingPrize boBingPrize)
        {
            _boBingPrizes.Add(boBingPrize);
        }
    }
}
