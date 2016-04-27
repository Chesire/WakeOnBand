using System.Collections.ObjectModel;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Interfaces
{
    /// <summary>
    /// Store and provide the known Wol targets
    /// </summary>
    public interface IWolTargetProvider
    {
        /// <summary>
        /// Gets the current collection of WolTargetModels
        /// </summary>
        ObservableCollection<WolTargetModel> WolTargets { get; }
    }
}