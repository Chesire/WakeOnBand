namespace WakeOnBandXamarin.Core.Interfaces
{
    /// <summary>
    /// Provides functionality to wake on lan
    /// </summary>
    public interface IWol
    {
        /// <summary>
        /// Wake up <paramref name="macAddress"/> over lan
        /// </summary>
        /// <param name="macAddress"></param>
        void Wake(string macAddress);
    }
}