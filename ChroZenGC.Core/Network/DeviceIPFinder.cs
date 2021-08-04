using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChroZenGC.Core.Network
{
    public class DeviceIPFinder : INotifyPropertyChanged
    {
        public ObservableCollection<string> Results { get; } = new ObservableCollection<string>();

        private Socket receiver = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public event PropertyChangedEventHandler PropertyChanged;

        public string MulticastAddress { get; set; } = "224.0.0.88";

        public void Start(NetworkInterfaceType type = 0)
        {
            Results.Clear();

            var localIP = LocalNetworks.GetAllLocalIPv4(type).FirstOrDefault();
            if (localIP != null)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localEP = new IPEndPoint(localIP, 0);
                socket.Bind(localEP);

                MulticastOption mcastOption = new MulticastOption(IPAddress.Parse(MulticastAddress), localIP);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mcastOption);

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(MulticastAddress), 4242);
                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = InformationWrapper.PacketCode,
                    Index = 0,
                    SlotOffset = 0,
                    SlotSize = 0
                };

                WaitAsync();

                socket.SendTo(header.ToBytes(), remoteEP);

                socket.Close();
            }

        }

        private async void WaitAsync()
        {
            await Task.Factory.StartNew(c => ReceiveAndParse(c), SynchronizationContext.Current, TaskCreationOptions.LongRunning);

            Stop();
        }

        private void ReceiveAndParse(object context)
        {
            SynchronizationContext synchronizationContext = context as SynchronizationContext;


            byte[] buffer = new byte[1024];

            EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            try
            {
                if (receiver.ReceiveFrom(buffer, ref remoteEP) == new InformationWrapper().Binary.Length)
                {
                    if (synchronizationContext != null)
                    {
                        synchronizationContext.Post(new SendOrPostCallback(registIPAddress), buffer.ToArray());
                    }
                    else
                    {
                        registIPAddress(buffer);
                    }
                }
            }
            catch
            {

            }
        }

        private void registIPAddress(object o)
        {
            byte[] buffer = (byte[])o;

            InformationWrapper inform = new InformationWrapper();
            inform.Binary = buffer;

            Results.Add(inform.IPAddress);
        }


        public void Stop()
        {
            if(receiver.IsBound)
            {
                receiver.Close();
            }
        }

    }    
}
