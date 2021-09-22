using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingRules
    {
        public BoBingPrizesPoolOption PrizesPoolOption { get; }

        public BoBingRules(BoBingPrizesPoolOption prizesPoolOption)
        {
            PrizesPoolOption = prizesPoolOption;
        }

        public BoBingAwardType CheckAwardType(int[] dices)
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
