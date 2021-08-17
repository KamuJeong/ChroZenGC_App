using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _ValveConfigWrapper : StructureWrapper<_ValveConfig>
    {
        public _ValveConfigWrapper(INotifyPropertyChanged parent, ReferenceProvider<_ValveConfig> func)
            : base(parent, func)
        {
            Provider.btType1 = new ValveTypes[8];
            Provider.btType2 = new ActuatorTypes[8];
            Provider.btPort = new byte[8];
            Provider.fLoop1 = new float[8];
            Provider.fLoop2 = new float[8];
            Provider.btInlet = new ValveConnection[8];
            Provider.btMultiType = new ValveTypes[2];
            Provider.btMultiPort = new byte[2];
            Provider.btMultiInlet = new ValveConnection[2];
            Provider.fMultiLoop = new float[2];

            ValveType = new ArrayWrapper<ValveTypes>(this, () => Provider.btType1);
            ActuatorType = new ArrayWrapper<ActuatorTypes>(this, () => Provider.btType2);
            PortNumber = new ArrayWrapper<byte>(this, () => Provider.btPort);
            LoopVolume1 = new ArrayWrapper<float>(this, () => Provider.fLoop1);
            LoopVolume2 = new ArrayWrapper<float>(this, () => Provider.fLoop2);
            Connection = new ArrayWrapper<ValveConnection>(this, () => Provider.btInlet);

            MultiValveType = new ArrayWrapper<ValveTypes>(this, () => Provider.btMultiType);
            MultiValvePortNumber = new ArrayWrapper<byte>(this, () => Provider.btMultiPort);
            MultiValveConnection = new ArrayWrapper<ValveConnection>(this, () => Provider.btMultiInlet);
            MultiValveVolume = new ArrayWrapper<float>(this, () => Provider.fMultiLoop);
        }

        public int MultiValveCount
        {
            get => Provider.btMultiCount;
            set => Provider.btMultiCount = (byte)value;
        }

        public int ValveCount
        {
            get => Provider.btValveCount;
            set => Provider.btValveCount = (byte)value;
        }

        public ArrayWrapper<ValveTypes> ValveType { get; }

        public ArrayWrapper<ActuatorTypes> ActuatorType { get; }

        public ArrayWrapper<byte> PortNumber { get; }

        public ArrayWrapper<float> LoopVolume1 { get; }

        public ArrayWrapper<float> LoopVolume2 { get; }

        public ArrayWrapper<ValveConnection> Connection { get; }

        public ArrayWrapper<ValveTypes> MultiValveType { get; }

        public ArrayWrapper<byte> MultiValvePortNumber { get; }

        public ArrayWrapper<ValveConnection> MultiValveConnection { get; }

        public ArrayWrapper<float> MultiValveVolume { get; }
    }

    public class ConfigurationWrapper : PacketWrapper<Configuration>
    {
        public const uint PacketCode = 0x67110;
        public override uint Code => PacketCode;


        public _ValveConfigWrapper ValveConfig { get; }

        public ConfigurationWrapper()
        {
            Packet.btInlet = new InletTypes[3] { InletTypes.Capillary, InletTypes.Packed, InletTypes.OnColumn };
            Packet.btDet = new DetectorTypes[3] { DetectorTypes.PDD, DetectorTypes.µTCD, DetectorTypes.µECD };
            Packet.bAuxAPC = new byte[3];
            Packet.bAuxTemp = new byte[8];

            InletType = new ArrayWrapper<InletTypes>(this, () => Packet.btInlet);
            DetectorType = new ArrayWrapper<DetectorTypes>(this, () => Packet.btDet);
            AuxAPC = new ArrayWrapper<byte>(this, () => Packet.bAuxAPC);
            AuxTemp = new ArrayWrapper<byte>(this, () => Packet.bAuxTemp);
            MultiValve = new ArrayWrapper<byte>(this, () => Packet.bMultiValve);

            ValveConfig = new _ValveConfigWrapper(this, () => ref Packet.ValveConfig);
        }

        protected override void OnPrePropertyModified(object sender, PropertyModifiedEventArgs args)
        {
            base.OnPrePropertyModified(sender, args);

            if(args.PropertyName.StartsWith("_ValveConfigWrapper"))
            {
                ValveConfig.ValveCount = ValveConfig.ValveType.Count(t => t != ValveTypes.None);
                ValveConfig.MultiValveCount = ValveConfig.MultiValveType.Count(t => t != ValveTypes.None);
            }
        }

        public bool IsOvenInstalled
        {
            get => Packet.bOven != 0;
            set => Packet.bOven = (byte)(value ? 1 : 0);
        }

        public bool IsCryogenicInstalled
        {
            get => Packet.bCryogenic != 0;
            set => Packet.bCryogenic = (byte)(value ? 1 : 0);
        }

        public ArrayWrapper<InletTypes> InletType { get; }

        public ArrayWrapper<DetectorTypes> DetectorType { get; }

        public ArrayWrapper<byte> AuxAPC { get; }

        public bool IsAutosamplerInstalled
        {
            get => Packet.bAutosampler != 0;
            set => Packet.bAutosampler = (byte)(value ? 1 : 0);
        }

        public Aux4Types Aux4Type
        {
            get => Packet.bMethanizer;
            set => Packet.bMethanizer = value;
        }

        public ArrayWrapper<byte> AuxTemp { get; }

        public ArrayWrapper<byte> MultiValve { get; }

    }
}
