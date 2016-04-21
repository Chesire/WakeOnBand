using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity(Label = "Child2View")]
    public class Child2View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child2View);
        }
    }
}