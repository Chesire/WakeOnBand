using Android.App;
using MvvmCross.Droid.Views;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity(Label = "MainView", MainLauncher = true)]
    public class MainView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Main);
        }
    }
}