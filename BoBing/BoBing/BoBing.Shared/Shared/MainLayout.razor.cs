using BoBing.Shared.Data;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoBing.Shared.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool IsOpen { get; set; }
        [Inject]
        private BoBingLocalParticipant LocalParticipant { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            LocalParticipant.PropertyChanged -= LocalParticipant_PropertyChanged;
            LocalParticipant.PropertyChanged += LocalParticipant_PropertyChanged;
            await base.OnInitializedAsync();
        }

        private void LocalParticipant_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}
