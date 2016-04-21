using MvvmCross.Core.ViewModels;

namespace WakeOnBandXamarin.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public FirstViewModel()
        {
            Child1 = new Child1ViewModel();
            Child2 = new Child2ViewModel();
        }

        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }

        public Child1ViewModel Child1
        {
            get { return _child1; }
            set { _child1 = value; RaisePropertyChanged(() => Child1); }
        }

        public Child2ViewModel Child2
        {
            get { return _child2; }
            set { _child2 = value; RaisePropertyChanged(() => Child2); }
        }
        private string _hello = "Hello MvvmCross";

        private Child1ViewModel _child1;
        private Child2ViewModel _child2;
    }
}