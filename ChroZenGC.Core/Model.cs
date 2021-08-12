using ChroZenGC.Core.Network;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
            Detectors[0].PropertyModified += FrontDetectorPropertyModified;
            Detectors[1].PropertyModified += CenterDetectorPropertyModified;
            Detectors[2].PropertyModified += RearDetectorPropertyModified;
        }

        private async void RearDetectorPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Detectors[2].SequenceOfModification;
                await Task.Delay(250);

                if (--Detectors[2].SequenceOfModification == 0)
                {
                    await Send(Detectors[2], 2);
                }
                else
                {
                    Debug.WriteLine("Skip send Detector 2");
                }
            }
        }

        private async void CenterDetectorPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Detectors[1].SequenceOfModification;
                await Task.Delay(250);

                if (--Detectors[1].SequenceOfModification == 0)
                {
                    await Send(Detectors[1], 1);
                }
                else
                {
                    Debug.WriteLine("Skip send Detector 1");
                }
            }
        }

        private async void FrontDetectorPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Detectors[0].SequenceOfModification;
                await Task.Delay(250);

                if (--Detectors[0].SequenceOfModification == 0)
                {
                    await Send(Detectors[0], 0);
                }
                else
                {
                    Debug.WriteLine("Skip send Detector 0");
                }
            }
        }

        private async void RearInletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Inlets[2].SequenceOfModification;
                await Task.Delay(250);

                if (--Inlets[2].SequenceOfModification == 0)
                {
                    await Send(Inlets[2], 2);
                }
                else
                {
                    Debug.WriteLine("Skip send inlet 2");
                }
            }
        }

        private async void CenternletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Inlets[1].SequenceOfModification;
                await Task.Delay(250);

                if (--Inlets[1].SequenceOfModification == 0)
                {
                    await Send(Inlets[1], 1);
                }
                else
                {
                    Debug.WriteLine("Skip send inlet 1");
                }
            }
        }

        private async void FrontInletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Inlets[0].SequenceOfModification;
                await Task.Delay(250);

                if (--Inlets[0].SequenceOfModification == 0)
                {
                    await Send(Inlets[0], 0);
                }
                else
                {
                    Debug.WriteLine("Skip send inlet 0");
                }
            }
        }

        private async void OvenPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++Oven.SequenceOfModification;
                await Task.Delay(250);

                if (--Oven.SequenceOfModification == 0)
                {
                    await Send(Oven);
                }
                else
                {
                    Debug.WriteLine("Skip send Oven");
                }
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

                    case DetectorSetupWrapper.PacketCode:
                        Assemble(Detectors[header.Index], buffer, header.SlotOffset, header.SlotSize);
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
