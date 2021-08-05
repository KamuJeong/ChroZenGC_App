using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ChroZenGC.Core.Network
{
    public static class LocalNetworks
    {
        public static List<IPAddress> GetAllLocalIPv4(NetworkInterfaceType type = 0)
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                           .Where(x => (type == 0 || x.NetworkInterfaceType == type) 
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Loopback 
                                    && x.OperationalStatus == OperationalStatus.Up)
                           .SelectMany(x => x.GetIPProperties().UnicastAddresses)
                           .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
                           .Select(x => x.Address)
                           .ToList();
        }
    }
}
