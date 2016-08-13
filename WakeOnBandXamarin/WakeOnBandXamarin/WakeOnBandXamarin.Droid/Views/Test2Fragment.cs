using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using WakeOnBandXamarin.Core.ViewModels;

namespace WakeOnBandXamarin.Droid
{
    [MvxFragmentAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Register("wakeonbandxamarin.droid.Test2Fragment")]
    public class Test2Fragment : MvxFragment<Test2ViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MySettingsView, container, false);
        }
    }
}