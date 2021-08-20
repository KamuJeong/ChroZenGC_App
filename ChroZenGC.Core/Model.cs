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
            Configuration.PropertyModified += ConfigurationPropertyModified;
            Oven.PropertyModified += OvenPropertyModified;
            Inlets[0].PropertyModified += FrontInletPropertyModified;
            Inlets[1].PropertyModified += CenternletPropertyModified;
            Inlets[2].PropertyModified += RearInletPropertyModified;
            Detectors[0].PropertyModified += FrontDetectorPropertyModified;
            Detectors[1].PropertyModified += CenterDetectorPropertyModified;
            Detectors[2].PropertyModified += RearDetectorPropertyModified;
            Signals[0].PropertyModified += Signal1PropertyModified;
            Signals[1].PropertyModified += Signal2PropertyModified;
            Signals[2].PropertyModified += Signal3PropertyModified;
            Valve.PropertyModified += ValvePropertyModified;
            AuxTemp.PropertyModified += AuxTempPropertyModified;
            AuxUPC[0].PropertyModified += AuxUPC1PropertyModified;
            AuxUPC[1].PropertyModified += AuxUPC2PropertyModified;
            AuxUPC[2].PropertyModified += AuxUPC3PropertyModified;
            Special.PropertyModified += SpecialPropertyModified;
        }

        private async void ConfigurationPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Configuration, 0, e);

        private async void SpecialPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Special, 0, e);

        private async void AuxUPC3PropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(AuxUPC[2], 2, e);

        private async void AuxUPC2PropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(AuxUPC[1], 1, e);

        private async void AuxUPC1PropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(AuxUPC[0], 0, e);

        private async void AuxTempPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(AuxTemp, 0, e);

        private async void ValvePropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Valve, 0, e);

        private async void Signal3PropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Signals[2], 2, e);

        private async void Signal2PropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Signals[1], 1, e);

        private async void Signal1PropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Signals[0], 0, e);

        private async void RearDetectorPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Detectors[2], 2, e);
 
        private async void CenterDetectorPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Detectors[1], 1, e);

        private async void FrontDetectorPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Detectors[0], 0, e);

        private async void RearInletPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Inlets[2], 2, e);

        private async void CenternletPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Inlets[1], 1, e);

        private async void FrontInletPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Inlets[0], 0, e);

        private async void OvenPropertyModified(object sender, PropertyChangedEventArgs e) => await DelayedSend(Oven, 0, e);

        private async Task DelayedSend<T>(PacketWrapper<T> wrapper, int index, PropertyChangedEventArgs e) where T : struct
        {
            if (e.PropertyName != "Binary" && !string.IsNullOrEmpty(e.PropertyName))
            {
                ++wrapper.SequenceOfModification;
                await Task.Delay(250);

                if (--wrapper.SequenceOfModification == 0)
                {
                    await Send<T>(wrapper, index);
                }
                else
                {
                    Debug.WriteLine("Skip send {0}", wrapper.GetType().Name);
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

                    case SignalSetupWrapper.PacketCode:
                        Assemble(Signals[header.Index], buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case ValveSetupWrapper.PacketCode:
                        Assemble(Valve, buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case AuxTempSetupWrapper.PacketCode:
                        Assemble(AuxTemp, buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case AuxUPCSetupWrapper.PacketCode:
                        Assemble(AuxUPC[header.Index], buffer, header.SlotOffset, header.SlotSize);
                        break;

                    case SpecialSetupWrapper.PacketCode:
                        Assemble(Special, buffer, header.SlotOffset, header.SlotSize);
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

        public ObservableCollection<SignalSetupWrapper> Signals { get; } = new ObservableCollection<SignalSetupWrapper>
        {
            new SignalSetupWrapper() { PortNo = 0 },
            new SignalSetupWrapper() { PortNo = 1 },
            new SignalSetupWrapper() { PortNo = 2 },
        };

        public ValveSetupWrapper Valve { get; } = new ValveSetupWrapper();

        public AuxTempSetupWrapper AuxTemp { get; } = new AuxTempSetupWrapper();

        public ObservableCollection<AuxUPCSetupWrapper> AuxUPC { get; } = new ObservableCollection<AuxUPCSetupWrapper>
        {
            new AuxUPCSetupWrapper() { PortNo = 0 },
            new AuxUPCSetupWrapper() { PortNo = 1 },
            new AuxUPCSetupWrapper() { PortNo = 2 },
        };

        public SpecialSetupWrapper Special { get; } = new SpecialSetupWrapper();
    }
}
