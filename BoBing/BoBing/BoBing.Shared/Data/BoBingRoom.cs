using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingRoom
    {
        public BoBingRules Rules { get; }
        public string Name { get; }
        public string Password { get; }
        public IEnumerable<BoBingParticipant> Participants { get; }

        public BoBingRoom(BoBingRules rules, string name, string password)
        {
            Rules = rules;
            Name = name;
            Password = password;
        }
    }
}
