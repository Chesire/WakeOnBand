using System;
using Microsoft.Band.Portable;
using WakeOnBandXamarin.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Band.Portable.Tiles;
using System.IO;

namespace WakeOnBandXamarin.Services
{
    public class BandService : IBand
    {
        /// <summary>
        /// Which type of band is currently connected
        /// </summary>
        private enum BandType
        {
            Band1,
            Band2
        }

        #region Const
        /// <summary>
        /// Id for this applications Band tile
        /// </summary>
        private static readonly Guid TileId = new Guid("ee9a055e-4648-4d8c-815d-9df25acd3d80");
        #endregion

        #region Members
        private BandClient _bandClient;
        #endregion

        #region Methods
        async Task<bool> IBand.IsBandClientConnected()
        {
            if (_bandClient == null)
            {
                var bandClientManager = BandClientManager.Instance;
                var pairedBands = await bandClientManager.GetPairedBandsAsync();

                if (pairedBands.Count() == 0)
                {
                    return false;
                }
                else
                {
                    var bandInfo = pairedBands.FirstOrDefault();
                    _bandClient = await bandClientManager.ConnectAsync(bandInfo);
                }
            }

            return true;
        }

        async Task<bool> IBand.AddTile(Stream imageStream)
        {
            if(await DoesTileExist())
            {
                return false;
            }

            var tileManager = _bandClient.TileManager;
            
            // Get the number of tiles we can add
            // if we have no capacity, return 
            var capacity = await tileManager.GetRemainingTileCapacityAsync();
            if (capacity == 0)
            {
                return false;
            }
            
            // create a new tile
            var tile = new BandTile(TileId)
            {
                Icon = await BandImage.FromStreamAsync(imageStream),
                Name = "Tile Name",
                SmallIcon = await BandImage.FromStreamAsync(imageStream)
            };

            // add the tile
            await tileManager.AddTileAsync(tile);

            return true;
        }

        async Task<bool> IBand.RemoveTile()
        {
            var tileExists = await DoesTileExist();
            if (!await DoesTileExist())
            {
                return false;
            }

            var tileManager = _bandClient.TileManager;

            // remove the tile
            await tileManager.RemoveTileAsync(TileId);

            return true;
        }

        async private Task<bool> DoesTileExist()
        {
            var tileManager = _bandClient.TileManager;

            // Get the current set of tiles
            // if we currently have the tile, return false
            var tiles = await tileManager.GetTilesAsync();
            return tiles.Any(c => c.Id == TileId);
        }
        #endregion
    }
}
