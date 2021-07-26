using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChroZenGC.Core.Network
{
    public interface INetworkManager
    {
        string Name { get; }
        string Host { get; set; }
        string Port { get; set; }

        Task ConnectAsync();
        bool IsConnected { get; }   
        void Close();

        Task SendAsync(byte[] buffer);
    }
}
