using Android.App;
using Android.Content;
using Microsoft.Band.Tiles;

namespace WakeOnBandXamarin.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { TileEvent.ActionTileButtonPressed })]
    public class TileReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            TileButtonEvent eventData = intent.Extras.Get(TileEvent.TileEventData) as TileButtonEvent;
            if (eventData == null)
                return;

            // load which wol device to wake up

            //throw new NotImplementedException();
            /*
            TileButtonEvent eventData = (TileButtonEvent)intent.getExtras().get("TILE_EVENT_DATA");
            if (eventData != null && eventData.getPageID() != null)
            {
                boolean loadedModels;
                WolDataService wolData = WolDataService.getInstance();
                try
                {
                    wolData.loadWolModels(context);
                    loadedModels = true;
                }
                catch (Exception e)
                {
                    loadedModels = false;
                }

                if (loadedModels)
                {
                    new WakeTask(eventData.getPageID()).execute();
                }
            }*/
        }
    }
}