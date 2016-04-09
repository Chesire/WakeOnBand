using System;
using System.IO;
using System.Threading.Tasks;

namespace WakeOnBandXamarin.Interfaces
{
    /// <summary>
    /// Provides an interface to interact with the Microsoft Band
    /// </summary>
    public interface IBand
    {
        /// <summary>
        /// Checks if a band client is currently connected
        /// If one is not it will automatically connect to it and return the result
        /// </summary>
        /// <returns>True is connected</returns>
        Task<bool> IsBandClientConnected();

        /// <summary>
        /// Tries to add the application tile to the Band
        /// </summary>
        /// <returns>True if successful</returns>
        Task<bool> AddTile(string tileName, Stream imageStream);

        /// <summary>
        /// Tries to remove the application tile from the Band
        /// </summary>
        /// <returns>True if successful</returns>
        Task<bool> RemoveTile();

        /// <summary>
        /// Update the page content
        /// </summary>
        /// <param name="deviceName">The friendly name for the device</param>
        /// <param name="deviceMac">The mac address for the device</param>
        /// <param name="pageId">The ID to put the data on</param>
        /// <returns></returns>
        Task UpdatePages(string deviceName, string deviceMac, Guid pageId);

        /// <summary>
        /// Clear the data from the pages
        /// </summary>
        /// <returns></returns>
        Task ClearBandPages();

        /// <summary>
        /// Closes the band client
        /// </summary>
        Task Close();
    }
}