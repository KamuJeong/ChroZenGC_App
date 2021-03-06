using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChroZenGC.Core.Network
{
    public class TCPManager : INetworkManager, INotifyPropertyChanged
    {
        private Model Model { get; }

        public TCPManager(Model model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Model = model;
            Model.networkManager = this;
        }

        public string Name { get; set; } = "TCP";

        public string Host { get; set; }

        public string Port { get; set; } = "4242";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private TcpClient tcpClient;

        private NetworkStream NetworkStream;

        public bool IsConnected => tcpClient != null && tcpClient.Connected;

        public async Task ConnectAsync()
        {
            if (!IsConnected)
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(Host, int.Parse(Port));
                NetworkStream = tcpClient.GetStream();
            }
        }


        public async Task WaitAsync()
        {
            if (IsConnected)
                await Task.Factory.StartNew(c => ReceiveAndParse(c), SynchronizationContext.Current, TaskCreationOptions.LongRunning);

            Close();
        }

        public void Close()
        {
            try
            {
                NetworkStream?.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            try 
            {
                tcpClient?.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                tcpClient = null;
                NetworkStream = null;

            }
            Model.networkManager = null;
        }

        private void ReceiveAndParse(object context)
        {
            SynchronizationContext synchronizationContext = context as SynchronizationContext;

            int pos = 0;
            byte[] buffer = new byte[4096];

            try
            {
                while (NetworkStream != null)
                {
                    int rlen = NetworkStream.Read(buffer, pos, Math.Min(4096, buffer.Length - pos));
                    if (rlen <= 0)
                        break;

                    pos += rlen;

                    if (pos < 24) continue;

                    var header = buffer.ConverTo<Header>();

                    if (header.Length >= 1024 || header.Code < 0x67000 || header.Code > 0x68000)
                    {
                        --pos;
                        Array.Copy(buffer, 1, buffer, 0, pos);
                        continue;
                    }

                    if (pos < header.Length)
                        continue;

                    if (synchronizationContext != null)
                    {
                        synchronizationContext.Post(new SendOrPostCallback(o => Model.Parse(o as byte[])),
                                                            buffer.Take((int)header.Length).ToArray());
                    }
                    else
                    {
                        Model.Parse(buffer.Take((int)header.Length).ToArray());
                    }

                    if (pos > header.Length)
                    {
                        pos -= (int)header.Length;
                        Array.Copy(buffer, header.Length, buffer, 0, pos);
                    }
                    else
                    {
                        pos = 0;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public async Task SendAsync(byte[] buffer)
        {
            if (IsConnected)
            {
                await NetworkStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
