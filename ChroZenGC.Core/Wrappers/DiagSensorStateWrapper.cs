using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class DiagSensorStateWrapper : PacketWrapper<DiagSensorState>
    {
        public const uint PacketCode = 0x67720;
        public override uint Code => PacketCode;

        public DiagSensorStateWrapper()
        {
            Packet.Inj_Volt = new float[9];
            Packet.Det_Volt = new float[9];
            Packet.Aux_Volt = new float[9];

            InletSensors = new ArrayWrapper<float>(this, () => Packet.Inj_Volt);
            DetectorSensors = new ArrayWrapper<float>(this, () => Packet.Det_Volt);
            AuxSensors = new ArrayWrapper<float>(this, () => Packet.Aux_Volt);
        }

        public ArrayWrapper<float> InletSensors { get; }
        public ArrayWrapper<float> DetectorSensors { get; }
        public ArrayWrapper<float> AuxSensors { get; }
    }
}
