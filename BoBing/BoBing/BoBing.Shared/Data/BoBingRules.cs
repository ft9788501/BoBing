using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingRules
    {
        private readonly Dictionary<BoBingAwardType, Queue<BoBingPrize>> _boBingPrizes = new();

        public Dictionary<BoBingAwardType, Queue<BoBingPrize>> BoBingPrizes => _boBingPrizes;

        public BoBingRules(Dictionary<BoBingAwardType, Queue<BoBingPrize>> boBingPrizes)
        {
            _boBingPrizes = boBingPrizes;
        }
    }
}
