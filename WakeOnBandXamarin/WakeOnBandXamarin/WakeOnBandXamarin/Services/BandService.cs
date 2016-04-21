using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Band.Portable;
using Microsoft.Band.Portable.Tiles;
using Microsoft.Band.Portable.Tiles.Pages;
using Microsoft.Band.Portable.Tiles.Pages.Data;
using WakeOnBandXamarin.Core.Interfaces;

namespace WakeOnBandXamarin.Core.Services
{
    internal class BandService : IBand
    {
        /// <summary>
        /// Which type of band is currently connected
        /// </summary>
        private enum BandType
        {
            MicrosoftBand1,
            MicrosoftBand2
        }

        #region Const

        private const short DeviceNameId = 1;
        private const short DeviceMacId = 2;
        private const short WakeButtonId = 3;

        /// <summary>
        /// Id for this applications Band tile
        /// </summary>
        private static readonly Guid TileId = new Guid("ee9a055e-4648-4d8c-815d-9df25acd3d80");

        #endregion Const

        #region Members

        private BandClient _bandClient;
        private BandTileManager _tileManager;
        private string _hardwareVersion;

        #endregion Members

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
                    _tileManager = _bandClient.TileManager;
                }
            }

            return _bandClient.IsConnected;
        }

        async Task<bool> IBand.AddTile(string tileName, Stream imageStream)
        {
            if (await DoesTileExist())
            {
                return false;
            }

            // Get the number of tiles we can add if we have no capacity, return
            var capacity = await _tileManager.GetRemainingTileCapacityAsync();
            if (capacity == 0)
            {
                return false;
            }

            // create a new tile
            var tile = new BandTile(TileId)
            {
                Icon = await BandImage.FromStreamAsync(imageStream),
                Name = tileName,
                SmallIcon = await BandImage.FromStreamAsync(imageStream)
            };

            var bandType = await GetBandType();
            tile.PageLayouts.Add(GetPageLayout(bandType));

            // add the tile
            return await _tileManager.AddTileAsync(tile);
        }

        async Task<bool> IBand.RemoveTile()
        {
            var tileExists = await DoesTileExist();
            if (!await DoesTileExist())
            {
                return false;
            }

            // remove the tile
            await _tileManager.RemoveTileAsync(TileId);

            return true;
        }

        async Task IBand.UpdatePages(string deviceName, string deviceMac, Guid pageId)
        {
            // declare the data for the page
            var pageData = new PageData
            {
                PageId = pageId,
                // not quite sure what this is?
                PageLayoutIndex = 0,
                Data =
                {
                    new TextBlockData
                    {
                        ElementId = DeviceNameId,
                        Text = deviceName
                    },
                    new TextBlockData
                    {
                        ElementId = DeviceMacId,
                        Text = deviceMac
                    },
                    new TextButtonData
                    {
                        ElementId = WakeButtonId,
                        Text = "Wake"
                    }
                }
            };

            // apply the data to the tile
            await _tileManager.SetTilePageDataAsync(TileId, pageData);
        }

        async Task IBand.ClearBandPages()
        {
            await _tileManager.RemoveTilePagesAsync(TileId);
        }

        async Task IBand.Close()
        {
            if (_bandClient != null && _bandClient.IsConnected)
            {
                await _bandClient.DisconnectAsync();
            }
        }

        async private Task<bool> DoesTileExist()
        {
            // Get the current set of tiles if we currently have the tile, return false
            var tiles = await _tileManager.GetTilesAsync();
            return tiles.Any(c => c.Id == TileId);
        }

        async private Task<BandType> GetBandType()
        {
            if (string.IsNullOrEmpty(_hardwareVersion))
            {
                _hardwareVersion = await _bandClient.GetHardwareVersionAsync();
            }

            return int.Parse(_hardwareVersion) <= 19 ? BandType.MicrosoftBand1 : BandType.MicrosoftBand2;
        }

        private PageLayout GetPageLayout(BandType bandType)
        {
            PageRect layoutRect;
            if (bandType == BandType.MicrosoftBand1)
            {
                layoutRect = new PageRect(0, 0, 245, 135);
            }
            else
            {
                layoutRect = new PageRect(0, 0, 258, 135);
            }

            var scrollPanel = new ScrollFlowPanel
            {
                Rect = layoutRect,
                Elements =
                    {
                        new TextBlock
                        {
                            ElementId = DeviceNameId,
                            Rect = new PageRect(0, 0, 230, 30),
                            ColorSource = ElementColorSource.BandHighlight,
                            Font = TextBlockFont.Small
                        },
                        new TextBlock
                        {
                            ElementId = DeviceMacId,
                            Rect = new PageRect(0, 0, 230, 30),
                            Font = TextBlockFont.Small
                        },
                        new TextButton
                        {
                            ElementId = WakeButtonId,
                            Rect = new PageRect(0, 0, 230, 40),
                            Margins = new Margins(0, 20, 0, 5),
                            HorizontalAlignment = HorizontalAlignment.Center
                        }
                    }
            };

            return new PageLayout(scrollPanel);
        }

        #endregion Methods
    }
}