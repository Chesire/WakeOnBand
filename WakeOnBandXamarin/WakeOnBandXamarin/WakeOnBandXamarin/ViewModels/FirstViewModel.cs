using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        #region Members

        private WolTargetsViewModel _wolTargetsViewModel;
        private BandTargetsViewModel _bandTargetsViewModel;

        #endregion Members

        #region Constructor

        public FirstViewModel(WolTargetsViewModel wolTargetsViewModel, BandTargetsViewModel bandTargetsViewModel)
        {
            WolTargetsViewModel = wolTargetsViewModel;
            BandTargetsViewModel = bandTargetsViewModel;
        }

        #endregion Constructor

        #region Properties

        public WolTargetsViewModel WolTargetsViewModel
        {
            get { return _wolTargetsViewModel; }
            set { _wolTargetsViewModel = value; RaisePropertyChanged(() => WolTargetsViewModel); }
        }

        public BandTargetsViewModel BandTargetsViewModel
        {
            get { return _bandTargetsViewModel; }
            set { _bandTargetsViewModel = value; RaisePropertyChanged(() => BandTargetsViewModel); }
        }

        #endregion Properties
    }
}