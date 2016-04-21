using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class WolTargetsViewModel : MvxViewModel
    {
        #region Members

        private ObservableCollection<WolTargetModel> _wolTargets;

        #endregion Members

        #region Constructor

        public WolTargetsViewModel(IWolTargetProvider targetProvider)
        {
            _wolTargets = new ObservableCollection<WolTargetModel>(targetProvider.WolTargets);

            // Debug
            //_wolTargets.Add(new WolTargetModel("Test Name", "FF:FF:FF:FF:FF:FF"));
            //_wolTargets.Add(new WolTargetModel("Second Test Name", "FF:FF:FF:FF:FF:F0"));
        }

        #endregion Constructor

        #region Properties

        public ObservableCollection<WolTargetModel> WolTargets
        {
            get
            {
                return _wolTargets;
            }
        }

        #endregion Properties
    }
}