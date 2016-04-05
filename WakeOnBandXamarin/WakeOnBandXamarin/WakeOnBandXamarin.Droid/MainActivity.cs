using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WakeOnBandXamarin.Interfaces;
using WakeOnBandXamarin.Services;
using Java.IO;

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
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += async delegate {
                IBand band = new BandService();
                await band.IsBandClientConnected();
                await band.AddTile(Assets.Open("bandTestIcon.png"));
                //await band.RemoveTile();
            };
		}
	}
}


