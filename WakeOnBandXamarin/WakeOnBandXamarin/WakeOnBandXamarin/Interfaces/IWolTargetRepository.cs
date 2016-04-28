using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Interfaces
{
    /// <summary>
    /// Store and provide the known Wol targets
    /// </summary>
    public interface IWolTargetRepository
    {
        /// <summary>
        /// Gets the current collection of WolTargetModels
        /// </summary>
        Task<ObservableCollection<WolTargetModel>> GetWolTargets();

        /// <summary>
        /// Save the current collection of WolTargetModels into the device
        /// </summary>
        void SaveWolTargetModels();
    }
}