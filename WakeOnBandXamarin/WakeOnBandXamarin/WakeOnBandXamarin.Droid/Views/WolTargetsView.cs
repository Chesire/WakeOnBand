using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity(Label = "WolTargetsView")]
    public class WolTargetsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.WolTargetsView);
        }
    }
}