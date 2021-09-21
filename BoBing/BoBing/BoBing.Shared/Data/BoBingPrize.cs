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
        public string Name { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// 创建奖品
        /// </summary>
        /// <param name="award1Count">一秀</param>
        /// <param name="award2Count">二举</param>
        /// <param name="award3Count">四进</param>
        /// <param name="award4Count">三红</param>
        /// <param name="award5Count">对堂</param>
        /// <param name="award6Count">状元</param>
        public static Dictionary<BoBingAward, BoBingPrize[]> CreatePrizes(
            int award1Count,
            int award2Count,
            int award3Count,
            int award4Count,
            int award5Count,
            int award6Count)
        {
            Dictionary<BoBingAward, BoBingPrize[]> boBingPrizes = new();
            boBingPrizes.Add(new BoBingAward1(), Enumerable.Range(0, award1Count).Select(i => new BoBingPrize()).ToArray());
            boBingPrizes.Add(new BoBingAward2(), Enumerable.Range(0, award2Count).Select(i => new BoBingPrize()).ToArray());
            boBingPrizes.Add(new BoBingAward3(), Enumerable.Range(0, award3Count).Select(i => new BoBingPrize()).ToArray());
            boBingPrizes.Add(new BoBingAward4(), Enumerable.Range(0, award4Count).Select(i => new BoBingPrize()).ToArray());
            boBingPrizes.Add(new BoBingAward5(), Enumerable.Range(0, award5Count).Select(i => new BoBingPrize()).ToArray());
            boBingPrizes.Add(new BoBingAward6(), Enumerable.Range(0, award6Count).Select(i => new BoBingPrize()).ToArray());
            return boBingPrizes;
        }
    }
}
