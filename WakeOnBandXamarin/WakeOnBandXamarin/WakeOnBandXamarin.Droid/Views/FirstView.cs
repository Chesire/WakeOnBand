using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WakeOnBandXamarin.Core.ViewModels;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity(Label = "@string/FriendlyApplicationName")]
    public class FirstView : MvxTabActivity
    {
        protected FirstViewModel FirstViewModel
        {
            get { return ViewModel as FirstViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            TabHost.TabSpec spec;
            spec = TabHost.NewTabSpec("child1");
            spec.SetIndicator(GetString(Resource.String.WakeOnLanTitle));
            spec.SetContent(this.CreateIntentFor(FirstViewModel.WolTargetsViewModel));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator(GetString(Resource.String.BandTargetsTitle));
            spec.SetContent(this.CreateIntentFor(FirstViewModel.BandTargetsViewModel));
            TabHost.AddTab(spec);
        }
    }
}