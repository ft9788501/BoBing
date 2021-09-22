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
    }
}
