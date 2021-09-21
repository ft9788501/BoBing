using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingParticipant
    {
        private List<BoBingPrize> _boBingPrizes = new List<BoBingPrize>();

        public virtual string Name { get;  }

        public virtual IEnumerable<BoBingPrize> Prizes => _boBingPrizes;

        public BoBingParticipant(string name)
        {
            Name = name;
        }

        public virtual void AddPrize(BoBingPrize boBingPrize)
        {
            _boBingPrizes.Add(boBingPrize);
        }
    }
}
