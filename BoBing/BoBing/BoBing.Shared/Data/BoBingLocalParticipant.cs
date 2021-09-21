using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingLocalParticipant : BoBingParticipant, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BoBingParticipant _participant;

        public override string Name => _participant?.Name;

        public override IEnumerable<BoBingPrize> Prizes => _participant?.Prizes ?? Array.Empty<BoBingPrize>();

        public BoBingLocalParticipant() : base(string.Empty)
        {
        }

        public override void AddPrize(BoBingPrize boBingPrize)
        {
            _participant.AddPrize(boBingPrize);
        }

        public bool Is(BoBingParticipant participant)
        {
            return _participant == participant;
        }

        public void SetParticipant(BoBingParticipant participant)
        {
            _participant = participant;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }
}
