using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class WolTargetsViewModel : MvxViewModel
    {
        #region Members

        private string _foo = "Hello Foo";

        #endregion Members

        #region Properties

        public string Foo
        {
            get { return _foo; }
            set { _foo = value; RaisePropertyChanged(() => Foo); }
        }

        #endregion Properties
    }
}