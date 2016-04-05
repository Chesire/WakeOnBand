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
        Task<bool> AddTile(Stream imageStream);

        /// <summary>
        /// Tries to remove the application tile from the Band
        /// </summary>
        /// <returns>True if successful</returns>
        Task<bool> RemoveTile();
    }
}
