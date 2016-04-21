using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            _wolTargets = targetProvider.WolTargets;
            // Debug
            _wolTargets.Add(new WolTargetModel("Test Name", "FF:FF:FF:FF:FF:FF"));
            _wolTargets.Add(new WolTargetModel("Second Test Name", "FF:FF:FF:FF:FF:F0"));

            Task.Delay(5000).ContinueWith((t) =>
            {
                // this doesn't seem to auto update the view
                _wolTargets.Add(new WolTargetModel("NEW ONE", "AA:AA:AA:AA:AA:AA"));
            });
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

        public MvxCommand<WolTargetModel> WolModelSelected
        {
            get
            {
                return new MvxCommand<WolTargetModel>((wolModel) =>
                {
                    var s = "test";
                });
            }
        }

        #endregion Properties
    }
}