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
    public class DeviceInterface : INotifyPropertyChanged
    {
        public string SerialNumber { get; set; }
        public string IPAddress { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class DeviceIPFinder : INotifyPropertyChanged
    {
        public ObservableCollection<DeviceInterface> Results { get; } = new ObservableCollection<DeviceInterface>();

        private List<UdpClient> udpClinets = new List<UdpClient>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string MulticastAddress { get; } = "224.0.0.88";
        public int MulticastPort { get; } = 4041;


        public void Start()
        {
            Results.Clear();
            Stop();

            foreach (var localIP in LocalNetworks.GetAllLocalIPv4(0))
            {
                UdpClient udpClient = new UdpClient(AddressFamily.InterNetwork);
                udpClient.JoinMulticastGroup(IPAddress.Parse(MulticastAddress), 1);
                udpClinets.Add(udpClient);

                Ping(udpClient);
            }
        }

        private void Ping(UdpClient udpClient)
        {
            Task.Run(() =>
            {
                var context = SynchronizationContext.Current;

                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = InformationWrapper.PacketCode,
                    Index = 0,
                    SlotOffset = 0,
                    SlotSize = 0
                };

                udpClient.Send(header.ToBytes(), 24, MulticastAddress, MulticastPort);

                try
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(MulticastAddress), 4241);
                    byte[] buffer = udpClient.Receive(ref endPoint);
                    if (buffer.Length >= new InformationWrapper().Binary.Length)
                    {
                        if (context != null)
                        {
                            context.Post(new SendOrPostCallback(registIPAddress), buffer.ToArray());
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
            });
        }

        private void registIPAddress(object o)
        {
            byte[] buffer = (byte[])o;

            InformationWrapper inform = new InformationWrapper();
            inform.Binary = buffer;

            if(Results.All(r => !string.Equals(r.IPAddress, inform.IPAddress) || !string.Equals(r.SerialNumber, inform.InstInfo.InstSerialNo)))
            {
                Results.Add(new DeviceInterface { IPAddress = inform.IPAddress, SerialNumber = inform.InstInfo.InstSerialNo });
            }
        }


        public void Stop()
        {
            foreach (var udp in udpClinets)
            {
                try 
                {
                    udp.Close();
                
                }
                catch
                {

                }
            }

            udpClinets.Clear();
        }
    }
}
