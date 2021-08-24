using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class DiagPowerCheckWrapper : PacketWrapper<DiagPowerCheck>
    {
        public const uint PacketCode = 0x67730;
        public override uint Code => PacketCode;

        public DiagPowerCheckWrapper()
        {
            Packet.APC_INJ_V25D = new float[3];
            Packet.APC_INJ_V33D = new float[3];
            Packet.APC_INJ_V50D = new float[3];
            Packet.APC_INJ_V24 = new float[3];
            Packet.APC_INJ_SEN1 = new float[3];
            Packet.APC_INJ_SEN2 = new float[3];

            Inlet_2_5V = new ArrayWrapper<float>(this, () => Packet.APC_INJ_V25D);
            Inlet_3_3V = new ArrayWrapper<float>(this, () => Packet.APC_INJ_V33D);
            Inlet_5V = new ArrayWrapper<float>(this, () => Packet.APC_INJ_V50D);
            Inlet_24V = new ArrayWrapper<float>(this, () => Packet.APC_INJ_V24);
            Inlet_Flow_Sensor = new ArrayWrapper<float>(this, () => Packet.APC_INJ_SEN1);
            Inlet_Pressure_Sensor = new ArrayWrapper<float>(this, () => Packet.APC_INJ_SEN2);
        }

        public float Main_5V
        {
            get => Packet.MAIN_V50D;
            set => Packet.MAIN_V50D = value;
        }

        public float Main_N5V
        {
            get => Packet.MAIN_N50V;
            set => Packet.MAIN_N50V = value;
        }

        public float Main_12V
        {
            get => Packet.MAIN_V12P;
            set => Packet.MAIN_V12P = value;
        }

        public float Main_24V
        {
            get => Packet.MAIN_V24P;
            set => Packet.MAIN_V24P = value;
        }

        public ArrayWrapper<float> Inlet_2_5V { get; }
        public ArrayWrapper<float> Inlet_3_3V { get; }
        public ArrayWrapper<float> Inlet_5V { get; }
        public ArrayWrapper<float> Inlet_24V { get; }
        public ArrayWrapper<float> Inlet_Flow_Sensor { get; }
        public ArrayWrapper<float> Inlet_Pressure_Sensor { get; }

        public float Det_2_5V
        {
            get => Packet.APC_DET_V25D;
            set => Packet.APC_DET_V25D = value;
        }

        public float Det_3_3V
        {
            get => Packet.APC_DET_V33D;
            set => Packet.APC_DET_V33D = value;
        }

        public float Det_Pressure_Sensor
        {
            get => Packet.APC_DET_SEN;
            set => Packet.APC_DET_SEN = value;
        }

        public float Aux_2_5V
        {
            get => Packet.APC_AUX_V25D;
            set => Packet.APC_AUX_V25D = value;
        }

        public float Aux_3_3V
        {
            get => Packet.APC_AUX_V33D;
            set => Packet.APC_AUX_V33D = value;
        }

        public float Aux_Pressure_Sensor
        {
            get => Packet.APC_AUX_SEN;
            set => Packet.APC_AUX_SEN = value;
        }

    }
}
