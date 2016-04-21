using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WakeOnBandXamarin.Core.ViewModels;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
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
            spec.SetIndicator("1");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child1));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator("2");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child2));
            TabHost.AddTab(spec);
        }
    }
}