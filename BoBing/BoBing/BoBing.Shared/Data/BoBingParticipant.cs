using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingParticipant
    {
        public string Name { get; set; }

        public IEnumerable<BoBingAward> Awards { get; }
    }
}
