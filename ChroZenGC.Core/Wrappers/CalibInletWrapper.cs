using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class CalibInletWrapper : PacketWrapper<CalibInlet>
    {
        public const uint PacketCode = 0x67810;
        public override uint Code => PacketCode;

        public CalibInletWrapper()
        {
            Packet.FlowSet = new float[3];
            Packet.FlowMeasure = new float[3];

            Temp = new CalibTempSetWrapper(this, () => ref Packet.Temp);
            FlowSet = new ArrayWrapper<float>(this, () => Packet.FlowSet);
            FlowMeasure = new ArrayWrapper<float>(this, () => Packet.FlowMeasure);
        }

        public CalibTempSetWrapper Temp { get; }

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
