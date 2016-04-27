using System.Collections.ObjectModel;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Providers
{
    internal class WolTargetProvider : IWolTargetProvider
    {
        #region Members

        private ObservableCollection<WolTargetModel> _wolTargets;

        #endregion Members

        #region Properties

        ObservableCollection<WolTargetModel> IWolTargetProvider.WolTargets
        {
            get
            {
                if (_wolTargets == null)
                    _wolTargets = new ObservableCollection<WolTargetModel>();

                return _wolTargets;
            }
        }

        #endregion Properties
    }
}