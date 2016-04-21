using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity(Label = "Child1View")]
    public class Child1View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child1View);
        }
    }
}