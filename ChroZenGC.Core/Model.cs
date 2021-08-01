using ChroZenGC.Core.Network;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChroZenGC.Core
{
    public class Model
    {
        internal INetworkManager networkManager;

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
                        Assemble(Inlet[header.Index], buffer, header.SlotOffset, header.SlotSize);
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

        public async Task Request<T>(PacketWrapper<T> wrapper) where T : struct
        {
            if (networkManager != null)
            {
                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = wrapper.Code,
                    Index = 0,
                    SlotOffset = 0,
                    SlotSize = wrapper.Binary.Length
                };

                await networkManager.SendAsync(header.ToBytes());
            }
        }

        public async Task Send<T>(PacketWrapper<T> wrapper) where T : struct
        {
            if (networkManager != null)
            {
                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = wrapper.Code,
                    Index = 0,
                    SlotOffset = 0,
                    SlotSize = wrapper.Binary.Length
                };

                await networkManager.SendAsync(wrapper.ToBytes(ref header));
            }
        }

        public async Task SendOK<T>(PacketWrapper<T> wrapper) where T : struct
        {
            if (networkManager != null)
            {
                Header header = new Header
                {
                    Length = 24,
                    Id = 0,
                    Code = wrapper.Code,
                    Index = 0,
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

        public ObservableCollection<InletSetupWrapper> Inlet { get; } = new ObservableCollection<InletSetupWrapper>
        {
            new InletSetupWrapper() { PortNo = 0 },
            new InletSetupWrapper() { PortNo = 1 },
            new InletSetupWrapper() { PortNo = 2 }
        };



    }
}
