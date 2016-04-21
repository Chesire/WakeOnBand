using System.Collections.Generic;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Providers
{
    internal class WolTargetProvider : IWolTargetProvider
    {
        #region Members

        private IList<WolTargetModel> _wolTargets;

        #endregion Members

        #region Properties

        IList<WolTargetModel> IWolTargetProvider.WolTargets
        {
            get
            {
                if (_wolTargets == null)
                    _wolTargets = new List<WolTargetModel>();

                return _wolTargets;
            }
        }

        #endregion Properties
    }
}