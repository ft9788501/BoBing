using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public abstract class BoBingAward
    {
        public abstract string Name { get; }
        public abstract int Price { get; }
        public abstract string Description { get; }
    }
    public class BoBingAward1 : BoBingAward
    {
        public override string Name => "一秀";
        public override int Price { get; }
        public override string Description { get; }

        public BoBingAward1(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
    public class BoBingAward2 : BoBingAward
    {
        public override string Name => "二举";
        public override int Price { get; }
        public override string Description { get; }

        public BoBingAward2(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
    public class BoBingAward3 : BoBingAward
    {
        public override string Name => "三红";
        public override int Price { get; }
        public override string Description { get; }

        public BoBingAward3(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
    public class BoBingAward4 : BoBingAward
    {
        public override string Name => "四进";
        public override int Price { get; }
        public override string Description { get; }

        public BoBingAward4(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
    public class BoBingAward5 : BoBingAward
    {
        public override string Name => "对堂";
        public override int Price { get; }
        public override string Description { get; }

        public BoBingAward5(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
    public class BoBingAward6 : BoBingAward
    {
        public override string Name => "状元";
        public override int Price { get; }
        public override string Description { get; }

        public BoBingAward6(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
}
