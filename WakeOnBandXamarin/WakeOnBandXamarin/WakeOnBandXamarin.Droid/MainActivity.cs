using Android.App;
using Android.Widget;
using Android.OS;
using WakeOnBandXamarin.Interfaces;
using WakeOnBandXamarin.Services;

namespace WakeOnBandXamarin.Droid
{
	[Activity (Label = "WakeOnBandXamarin.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
            FindViewById<Button>(Resource.Id.addButton).Click += async delegate {
                IBand band = new BandService();
                await band.IsBandClientConnected();
                await band.AddTile(Assets.Open("bandTestIcon.png"));
            };
            FindViewById<Button>(Resource.Id.removeButton).Click += async delegate {
                IBand band = new BandService();
                await band.IsBandClientConnected();
                await band.RemoveTile();
            };
        }
	}
}


