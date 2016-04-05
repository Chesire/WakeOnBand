using System;
using WakeOnBandXamarin.Interfaces;

namespace WakeOnBandXamarin.Services
{
    /// <summary>
    /// 
    /// </summary>
    class BandService : IBand
    {
        /// <summary>
        /// Which type of band is currently connected
        /// </summary>
        private enum BandType
        {
            Band1,
            Band2
        }

        /// <summary>
        /// Id for this applications Band tile
        /// </summary>
        private static readonly Guid TileId = new Guid("ee9a055e-4648-4d8c-815d-9df25acd3d80");

        
    }
}
