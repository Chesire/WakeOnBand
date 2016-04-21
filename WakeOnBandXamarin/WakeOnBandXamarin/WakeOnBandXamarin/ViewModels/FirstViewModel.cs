using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        #region Members

        private WolTargetsViewModel _wolTargetsViewModel;
        private Child2ViewModel _child2;

        #endregion Members

        #region Constructor

        public FirstViewModel(WolTargetsViewModel wolTargetsViewModel)
        {
            WolTargetsViewModel = wolTargetsViewModel;
            Child2 = new Child2ViewModel();
        }

        #endregion Constructor

        #region Properties

        public WolTargetsViewModel WolTargetsViewModel
        {
            get { return _wolTargetsViewModel; }
            set { _wolTargetsViewModel = value; RaisePropertyChanged(() => WolTargetsViewModel); }
        }

        public Child2ViewModel Child2
        {
            get { return _child2; }
            set { _child2 = value; RaisePropertyChanged(() => Child2); }
        }

        #endregion Properties
    }
}