using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    /// <summary>
    /// 奖品
    /// </summary>
    public class BoBingPrize
    {
        public BoBingAwardType AwardType { get; }
        public string Name { get; }
        public int Price { get; }

        public BoBingPrize(BoBingAwardType awardType, string name, int price)
        {
            AwardType = awardType;
            Name = name;
            Price = price;
        }

        /// <summary>
        /// 创建奖品
        /// </summary>
        /// <param name="award1Count">一秀</param>
        /// <param name="award2Count">二举</param>
        /// <param name="award3Count">四进</param>
        /// <param name="award4Count">三红</param>
        /// <param name="award5Count">对堂</param>
        /// <param name="award6Count">状元</param>
        public static Dictionary<BoBingAwardType, Queue<BoBingPrize>> CreatePrizes(
            int award1Count,
            int award2Count,
            int award3Count,
            int award4Count,
            int award5Count,
            int award6Count)
        {
            Dictionary<BoBingAwardType, Queue<BoBingPrize>> boBingPrizes = new();
            boBingPrizes.Add(BoBingAwardType.Award1, new Queue<BoBingPrize>(Enumerable.Range(0, award1Count).Select(i => new BoBingPrize(BoBingAwardType.Award1, "", 0))));
            boBingPrizes.Add(BoBingAwardType.Award2, new Queue<BoBingPrize>(Enumerable.Range(0, award2Count).Select(i => new BoBingPrize(BoBingAwardType.Award2, "", 0))));
            boBingPrizes.Add(BoBingAwardType.Award3, new Queue<BoBingPrize>(Enumerable.Range(0, award3Count).Select(i => new BoBingPrize(BoBingAwardType.Award3, "", 0))));
            boBingPrizes.Add(BoBingAwardType.Award4, new Queue<BoBingPrize>(Enumerable.Range(0, award4Count).Select(i => new BoBingPrize(BoBingAwardType.Award4, "", 0))));
            boBingPrizes.Add(BoBingAwardType.Award5, new Queue<BoBingPrize>(Enumerable.Range(0, award5Count).Select(i => new BoBingPrize(BoBingAwardType.Award5, "", 0))));
            boBingPrizes.Add(BoBingAwardType.Award6, new Queue<BoBingPrize>(Enumerable.Range(0, award6Count).Select(i => new BoBingPrize(BoBingAwardType.Award6, "", 0))));
            return boBingPrizes;
        }
    }
}
