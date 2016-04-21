using System.Collections.Generic;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Interfaces
{
    /// <summary>
    /// Store and provide the known Wol targets
    /// </summary>
    public interface IWolTargetProvider
    {
        /// <summary>
        /// Gets the current list of WolTargetModels
        /// </summary>
        IList<WolTargetModel> WolTargets { get; }
    }
}