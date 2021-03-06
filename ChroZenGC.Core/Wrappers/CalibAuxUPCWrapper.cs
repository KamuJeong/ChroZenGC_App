using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class CalibAuxUPCWrapper : PacketWrapper<CalibAuxUPC>
    {
        public const uint PacketCode = 0x67870;
        public override uint Code => PacketCode;

        public CalibAuxUPCWrapper()
        {
            Packet.FlowSet = new float[3];
            Packet.FlowMeasure = new float[3];

            FlowSet = new ArrayWrapper<float>(this, () => Packet.FlowSet);
            FlowMeasure = new ArrayWrapper<float>(this, () => Packet.FlowMeasure);
        }

        public ArrayWrapper<float> FlowSet { get; }
        public ArrayWrapper<float> FlowMeasure { get; }

        public CalibrationTypes Type
        {
            get => Packet.Type;
            set => Packet.Type = value;
        }

        public CalibrationSensors Sensor
        {
            get => Packet.Sensor;
            set => Packet.Sensor = value;
        }
    }
}
