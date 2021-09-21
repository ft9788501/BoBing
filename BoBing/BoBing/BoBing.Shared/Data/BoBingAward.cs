using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    /// <summary>
    /// 奖项
    /// </summary>
    public abstract class BoBingAward
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public static BoBingAward CheckAwards(int[] dices)
        {
            //444411
            if (dices.GroupBy(d => d).Count() == 2 &&
                dices.GroupBy(d => d).Any(g => g.Key == 4 && g.AsEnumerable() is IEnumerable<int> group && group.Count() == 4) &&
                dices.GroupBy(d => d).Any(g => g.Key == 1))
            {
                return new BoBingAward6();
            }
            //xxxxxx
            if (dices.GroupBy(d => d).Count() == 1)
            {
                return new BoBingAward6();
            }
            //xxxxxa
            if (dices.GroupBy(d => d).Any(g => g.AsEnumerable() is IEnumerable<int> group && group.Count() == 5))
            {
                return new BoBingAward6();
            }
            //4444ab
            if (dices.Count(d => d == 4) == 4)
            {
                return new BoBingAward6();
            }
            //123456
            if (dices.Distinct().Count() == 6)
            {
                return new BoBingAward5();
            }
            //444abc
            if (dices.Count(d => d == 4) == 3)
            {
                return new BoBingAward4();
            }
            //xxxxab
            if (dices.GroupBy(d => d).Any(g => g.AsEnumerable() is IEnumerable<int> group && group.Count() == 4))
            {
                return new BoBingAward3();
            }
            //44abcd
            if (dices.Count(d => d == 4) == 2)
            {
                return new BoBingAward2();
            }
            //4abcde
            if (dices.Count(d => d == 4) == 1)
            {
                return new BoBingAward1();
            }
            return new BoBingAward0();
        }
    }
    public class BoBingAward0 : BoBingAward
    {
        public override string Name => "黑";
        public override string Description { get; }
    }
    public class BoBingAward1 : BoBingAward
    {
        public override string Name => "一秀";
        public override string Description { get; }
    }
    public class BoBingAward2 : BoBingAward
    {
        public override string Name => "二举";
        public override string Description { get; }
    }
    public class BoBingAward3 : BoBingAward
    {
        public override string Name => "三红";
        public override string Description { get; }
    }
    public class BoBingAward4 : BoBingAward
    {
        public override string Name => "四进";
        public override string Description { get; }
    }
    public class BoBingAward5 : BoBingAward
    {
        public override string Name => "对堂";
        public override string Description { get; }
    }
    public class BoBingAward6 : BoBingAward
    {
        public override string Name => "状元";
        public override string Description { get; }
    }
}
