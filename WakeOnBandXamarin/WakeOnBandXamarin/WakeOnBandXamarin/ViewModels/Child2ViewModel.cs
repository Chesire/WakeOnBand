using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class Child2ViewModel : MvxViewModel
    {
        public string Bar
        {
            get { return _bar; }
            set { _bar = value; RaisePropertyChanged(() => Bar); }
        }

        private string _bar = "Hello Bar";
    }
}