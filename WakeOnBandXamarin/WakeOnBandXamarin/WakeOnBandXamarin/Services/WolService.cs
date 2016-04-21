using System.Collections.Generic;
using Sockets.Plugin;
using WakeOnBandXamarin.Core.Interfaces;

namespace WakeOnBandXamarin.Core.Services
{
    internal class WolService : IWol
    {
        #region Const

        private const int Port = 9;

        /// <summary>
        /// We want to broadcast to network
        /// </summary>
        private const string DefaultAddress = "255.255.255.255";

        #endregion Const

        #region Methods

        void IWol.Wake(string macAddress)
        {
            if (string.IsNullOrEmpty(macAddress))
                return;

            if (macAddress.Contains(":") || macAddress.Contains("-"))
                macAddress = macAddress.Replace(":", "").Replace("-", "");

            byte[] dataBytes = GetMagicBytes(macAddress);
            Send(dataBytes, DefaultAddress, Port);
        }

        private void Send(byte[] data, string address, int port)
        {
            UdpSocketClient udpClient = new UdpSocketClient();
            udpClient.SendToAsync(data, address, port);
        }

        private byte[] GetMagicBytes(string macAddress)
        {
            var bytes = new List<byte>()
            {
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
            };

            var macAddressBytes = ParseHexString(macAddress);
            for (var i = 0; i < 16; i++)
                bytes.AddRange(macAddressBytes);

            return bytes.ToArray();
        }

        private byte[] ParseHexString(string input)
        {
            var bytes = new byte[input.Length / 2];
            for (int i = 0, j = 0; i < input.Length / 2; i++, j++)
            {
                bytes[j] = (byte)int.Parse(input.Substring(i, i + 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return bytes;
        }

        #endregion Methods
    }
}