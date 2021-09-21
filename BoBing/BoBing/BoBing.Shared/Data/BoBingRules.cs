using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingRules
    {
        private readonly Dictionary<BoBingAward, BoBingPrize[]> _boBingPrizes = new();

        public Dictionary<BoBingAward, BoBingPrize[]> BoBingPrizes => _boBingPrizes;

        public BoBingRules(Dictionary<BoBingAward, BoBingPrize[]> boBingPrizes)
        {
            _boBingPrizes = boBingPrizes;
        }
    }
}
