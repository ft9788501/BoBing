using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingPrizesPool
    {
        public event EventHandler<Dictionary<BoBingAwardType, Queue<BoBingPrize>>> PrizesChanged;

        private readonly Dictionary<BoBingAwardType, Queue<BoBingPrize>> _boBingPrizes = new();

        public Dictionary<BoBingAwardType, Queue<BoBingPrize>> Prizes => _boBingPrizes;

        public BoBingPrizesPool(BoBingPrizesPoolOption boBingPrizesPoolOption)
        {
            _boBingPrizes.Add(BoBingAwardType.Award1, new Queue<BoBingPrize>(Enumerable.Range(0, boBingPrizesPoolOption.Award1Count).Select(i => new BoBingPrize(BoBingAwardType.Award1, "", 0))));
            _boBingPrizes.Add(BoBingAwardType.Award2, new Queue<BoBingPrize>(Enumerable.Range(0, boBingPrizesPoolOption.Award2Count).Select(i => new BoBingPrize(BoBingAwardType.Award2, "", 0))));
            _boBingPrizes.Add(BoBingAwardType.Award3, new Queue<BoBingPrize>(Enumerable.Range(0, boBingPrizesPoolOption.Award3Count).Select(i => new BoBingPrize(BoBingAwardType.Award3, "", 0))));
            _boBingPrizes.Add(BoBingAwardType.Award4, new Queue<BoBingPrize>(Enumerable.Range(0, boBingPrizesPoolOption.Award4Count).Select(i => new BoBingPrize(BoBingAwardType.Award4, "", 0))));
            _boBingPrizes.Add(BoBingAwardType.Award5, new Queue<BoBingPrize>(Enumerable.Range(0, boBingPrizesPoolOption.Award5Count).Select(i => new BoBingPrize(BoBingAwardType.Award5, "", 0))));
            _boBingPrizes.Add(BoBingAwardType.Award6, new Queue<BoBingPrize>(Enumerable.Range(0, boBingPrizesPoolOption.Award6Count).Select(i => new BoBingPrize(BoBingAwardType.Award6, "", 0))));
        }

        public BoBingPrize PickPrize(BoBingAwardType awardType)
        {
            if (_boBingPrizes == null)
            {
                return null;
            }
            if (_boBingPrizes.TryGetValue(awardType, out Queue<BoBingPrize> prizes) && prizes.TryDequeue(out BoBingPrize prize))
            {
                PrizesChanged?.Invoke(this, Prizes);
                return prize;
            }
            return null;
        }

        public int GetPrizesRemainingCount(BoBingAwardType awardType)
        {
            if (_boBingPrizes == null)
            {
                return 0;
            }
            if (_boBingPrizes.TryGetValue(awardType, out Queue<BoBingPrize> prizes))
            {
                return prizes.Count;
            }
            return 0;
        }
    }
}
