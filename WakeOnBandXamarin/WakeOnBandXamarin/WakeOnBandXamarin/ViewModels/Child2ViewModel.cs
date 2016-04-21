using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class Child2ViewModel : MvxViewModel
    {
        #region Members

        private string _bar = "Hello Bar";

        #endregion Members

        #region Properties

        public string Bar
        {
            get { return _bar; }
            set { _bar = value; RaisePropertyChanged(() => Bar); }
        }

        #endregion Properties
    }
}