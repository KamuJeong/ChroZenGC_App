using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class CalibAuxTempWrapper : PacketWrapper<CalibAuxTemp>
    {
        public const uint PacketCode = 0x67780;
        public override uint Code => PacketCode;

        public CalibAuxTempWrapper()
        {
            Packet.Set = new float[16];
            Packet.Measure = new float[16];
            Packet.Factor = new float[16];

            for(int i=0; i<8; ++i)
            {
                Packet.Set[i * 2] = Packet.Measure[i * 2] = 52.1f;
                Packet.Set[i * 2 + 1] = Packet.Measure[i * 2 + 1] = 211.3f;
            }

        }

        public float Aux1_Set1
        {
            get => Packet.Set[0];
            set => Packet.Set[0] = value;
        }

        public float Aux1_Set2
        {
            get => Packet.Set[1];
            set => Packet.Set[1] = value;
        }

        public float Aux2_Set1
        {
            get => Packet.Set[2];
            set => Packet.Set[2] = value;
        }

        public float Aux2_Set2
        {
            get => Packet.Set[3];
            set => Packet.Set[3] = value;
        }

        public float Aux3_Set1
        {
            get => Packet.Set[4];
            set => Packet.Set[4] = value;
        }

        public float Aux3_Set2
        {
            get => Packet.Set[5];
            set => Packet.Set[5] = value;
        }

        public float Aux4_Set1
        {
            get => Packet.Set[6];
            set => Packet.Set[6] = value;
        }

        public float Aux4_Set2
        {
            get => Packet.Set[7];
            set => Packet.Set[7] = value;
        }

        public float Aux5_Set1
        {
            get => Packet.Set[8];
            set => Packet.Set[8] = value;
        }

        public float Aux5_Set2
        {
            get => Packet.Set[9];
            set => Packet.Set[9] = value;
        }

        public float Aux6_Set1
        {
            get => Packet.Set[10];
            set => Packet.Set[10] = value;
        }

        public float Aux6_Set2
        {
            get => Packet.Set[11];
            set => Packet.Set[11] = value;
        }

        public float Aux7_Set1
        {
            get => Packet.Set[12];
            set => Packet.Set[12] = value;
        }

        public float Aux7_Set2
        {
            get => Packet.Set[13];
            set => Packet.Set[13] = value;
        }

        public float Aux8_Set1
        {
            get => Packet.Set[14];
            set => Packet.Set[14] = value;
        }

        public float Aux8_Set2
        {
            get => Packet.Set[15];
            set => Packet.Set[15] = value;
        }


        public float Aux1_Measure1
        {
            get => Packet.Measure[0];
            set => Packet.Measure[0] = value;
        }

        public float Aux1_Measure2
        {
            get => Packet.Measure[1];
            set => Packet.Measure[1] = value;
        }

        public float Aux2_Measure1
        {
            get => Packet.Measure[2];
            set => Packet.Measure[2] = value;
        }

        public float Aux2_Measure2
        {
            get => Packet.Measure[3];
            set => Packet.Measure[3] = value;
        }

        public float Aux3_Measure1
        {
            get => Packet.Measure[4];
            set => Packet.Measure[4] = value;
        }

        public float Aux3_Measure2
        {
            get => Packet.Measure[5];
            set => Packet.Measure[5] = value;
        }

        public float Aux4_Measure1
        {
            get => Packet.Measure[6];
            set => Packet.Measure[6] = value;
        }

        public float Aux4_Measure2
        {
            get => Packet.Measure[7];
            set => Packet.Measure[7] = value;
        }

        public float Aux5_Measure1
        {
            get => Packet.Measure[8];
            set => Packet.Measure[8] = value;
        }

        public float Aux5_Measure2
        {
            get => Packet.Measure[9];
            set => Packet.Measure[9] = value;
        }

        public float Aux6_Measure1
        {
            get => Packet.Measure[10];
            set => Packet.Measure[10] = value;
        }

        public float Aux6_Measure2
        {
            get => Packet.Measure[11];
            set => Packet.Measure[11] = value;
        }

        public float Aux7_Measure1
        {
            get => Packet.Measure[12];
            set => Packet.Measure[12] = value;
        }

        public float Aux7_Measure2
        {
            get => Packet.Measure[13];
            set => Packet.Measure[13] = value;
        }

        public float Aux8_Measure1
        {
            get => Packet.Measure[14];
            set => Packet.Measure[14] = value;
        }

        public float Aux8_Measure2
        {
            get => Packet.Measure[15];
            set => Packet.Measure[15] = value;
        }

    }
}