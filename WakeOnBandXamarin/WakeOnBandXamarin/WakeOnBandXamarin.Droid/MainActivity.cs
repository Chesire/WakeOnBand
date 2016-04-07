using Android.App;
using Android.Widget;
using Android.OS;
using WakeOnBandXamarin.Interfaces;
using WakeOnBandXamarin.Services;

namespace WakeOnBandXamarin.Droid
{
    [Activity(Label = "WakeOnBandXamarin.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            FindViewById<Button>(Resource.Id.addButton).Click += async delegate
            {
                /*
                IBand band = new BandService();
                await band.IsBandClientConnected();
                await band.AddTile(GetString(Resource.String.app_name), Assets.Open("bandTestIcon.png"));
                await band.UpdatePages("Name", "FF:FF:FF:FF:FF:FF", new System.Guid("ee9a055e-4648-4d8c-815d-9df25acd3d81"));
                */
                IWol wol = new WolService();
                wol.Wake("AA-BB-CC-DD:EE:FF");
            };
            FindViewById<Button>(Resource.Id.removeButton).Click += async delegate
            {
                IBand band = new BandService();
                await band.IsBandClientConnected();
                await band.RemoveTile();
            };
        }
    }
}


