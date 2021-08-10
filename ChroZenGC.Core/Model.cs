using ChroZenGC.Core.Network;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChroZenGC.Core
{
    public class Model
    {
        internal INetworkManager networkManager;

        public Model()
        {
            Oven.PropertyModified += OvenPropertyModified;
            Inlets[0].PropertyModified += FrontInletPropertyModified;
            Inlets[1].PropertyModified += CenternletPropertyModified;
            Inlets[2].PropertyModified += RearInletPropertyModified;

        }

        private async void RearInletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" || !string.IsNullOrEmpty(e.PropertyName))
            {
                await Send(Inlets[2], 2);
            }
        }

        private async void CenternletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" || !string.IsNullOrEmpty(e.PropertyName))
            {
                await Send(Inlets[1], 1);
            }
        }

        private async void FrontInletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" || !string.IsNullOrEmpty(e.PropertyName))
            {
                await Send(Inlets[0], 0);
            }
        }

        private async void OvenPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != "Binary" || !string.IsNullOrEmpty(e.PropertyName))
            {
                await Send(Oven);
            }
        }

        internal void Parse(in byte[] buffer)
        {
            var header = buffer.ConverTo<Header>();

            if (header.Length > 24)
            {
                switch (header.Code)
                {
                    case InformationWrapper.PacketCode:
                        Assemble(Information, buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case ConfigurationWrapper.PacketCode:
                        Assemble(Configuration, buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case StateWrapper.PacketCode:
                        Assemble(State, buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case OvenWrapper.PacketCode:
                        Assemble(Oven, buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case InletSetupWrapper.PacketCode:
                        Assemble(Inlets[header.Index], buffer, header.SlotOffset, header.SlotSize);
                        break;
                }
            }
        }

        private void Assemble<T>(PacketWrapper<T> wrapper, byte[] src, int offset, int size) where T : struct
        {
            byte[] assemble = wrapper.Binary;

            if (assemble.Length < offset + size || src.Length < offset + size + 24)
                throw new ArgumentOutOfRangeException();

            Array.Copy(src, offset + 24, assemble, offset, size);

            wrapper.Binary = assemble;
        }

        public async Task Request<T>(PacketWrapper<T> wrapper, int index = 0) where T : struct
        {
            if (networkManager != null)
            {
                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = wrapper.Code,
                    Index = index,
                    SlotOffset = 0,
                    SlotSize = wrapper.Binary.Length
                };

                await networkManager.SendAsync(header.ToBytes());
            }
        }

        public async Task Send<T>(PacketWrapper<T> wrapper, int index = 0) where T : struct
        {
            if (networkManager != null)
            {
                var arr = wrapper.Binary;
                Header header = new Header
                {
                    Length = 24 + arr.Length,
                    Id = 0,
                    Code = wrapper.Code,
                    Index = index,
                    SlotOffset = 0,
                    SlotSize = arr.Length,
                };

                await networkManager.SendAsync(wrapper.ToBytes(ref header));
            }
        }

        public async Task SendOK<T>(PacketWrapper<T> wrapper, int index = 0) where T : struct
        {
            if (networkManager != null)
            {
                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = wrapper.Code,
                    Index = index,
                    SlotOffset = 0,
                    SlotSize = 0
                };

                await networkManager.SendAsync(header.ToBytes());
            }
        }

        public InformationWrapper Information { get; } = new InformationWrapper();

        public ConfigurationWrapper Configuration { get; } = new ConfigurationWrapper();

        public StateWrapper State { get; } = new StateWrapper();

        public OvenWrapper Oven { get; } = new OvenWrapper();

        public ObservableCollection<InletSetupWrapper> Inlets { get; } = new ObservableCollection<InletSetupWrapper>
        {
            new InletSetupWrapper() { PortNo = 0 },
            new InletSetupWrapper() { PortNo = 1, CarrierGas = Packets.GasTypes.H2 },
            new InletSetupWrapper() { PortNo = 2, CarrierGas = Packets.GasTypes.Ar }
        };

        public ObservableCollection<DetectorSetupWrapper> Detectors { get; } = new ObservableCollection<DetectorSetupWrapper>
        {
            new DetectorSetupWrapper() { PortNo = 0 },
            new DetectorSetupWrapper() { PortNo = 1 },
            new DetectorSetupWrapper() { PortNo = 2 },
        };

    }
}
