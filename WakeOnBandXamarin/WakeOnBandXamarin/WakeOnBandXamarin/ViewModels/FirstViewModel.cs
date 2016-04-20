using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }
        private string _hello = "Hello MvvmCross";
    }
}