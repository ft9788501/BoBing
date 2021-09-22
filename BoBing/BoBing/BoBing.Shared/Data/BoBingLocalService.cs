using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingLocalService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _localParticipantName;

        public string LocalParticipantName
        {
            get => _localParticipantName;
            set
            {
                _localParticipantName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocalParticipantName)));
            }
        }

        public BoBingPrizesPool PrizesPool { get; set; }

        public void RefreshPrizesPool()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PrizesPool)));
        }
    }
}
