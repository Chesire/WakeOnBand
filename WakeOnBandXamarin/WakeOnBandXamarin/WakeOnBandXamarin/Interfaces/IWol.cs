using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnBandXamarin.Interfaces
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
