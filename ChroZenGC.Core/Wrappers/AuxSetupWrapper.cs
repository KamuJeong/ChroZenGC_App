using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class AuxTempSetupWrapper : PacketWrapper<AuxTempSetup>
    {
        public const uint PacketCode = 0x67160;
        public override uint Code => PacketCode;

        public AuxTempSetupWrapper()
        {
            Packet.fTempOnoff = new byte[8];
            Packet.fTempSet = new float[8];

            TempOnOff = new ArrayWrapper<byte>(this, () => Packet.fTempOnoff);
            TempSet = new ArrayWrapper<float>(this, () => Packet.fTempSet);
        }

        public ArrayWrapper<byte> TempOnOff { get; }
        public ArrayWrapper<float> TempSet { get; }

    }


    public class AuxUPCSetupWrapper : PacketWrapper<AuxUPCSetup>
    {
        public const uint PacketCode = 0x67165;
        public override uint Code => PacketCode;

        public AuxUPCSetupWrapper()
        {
        }

        public int PortNo 
        { 
            get => Packet.btPort; 
            set => Packet.btPort = value; 
        }

        public GasTypes AuxGas 
        { 
            get => Packet.btAuxGas;
            set => Packet.btAuxGas = value; 
        }
        //가스종류 (0:N2 / 1:He / 2:H2 / 3:Ar / 4:ArCh4) // default : (N2)

        public float FlowSet1 
        { 
            get => Packet.fFlowSet1; 
            set => Packet.fFlowSet1 = value; 
        }

        // 유량설정1 (0 ~ 150ml/min) // default : 20
        public bool FlowOnoff1 
        { 
            get => Packet.fFlowOnoff1; 
            set => Packet.fFlowOnoff1 = value; 
        }                              // Flow1 On / Off(0:OFF / 1 : ON)

        public float FlowSet2 
        { 
            get => Packet.fFlowSet2; 
            set => Packet.fFlowSet2 = value; 
        }                                // 유량설정2 (0 ~ 150ml/min) // default : 20

        public bool FlowOnoff2 
        { 
            get => Packet.fFlowOnoff2; 
            set => Packet.fFlowOnoff2 = value; 
        }                               // Flow2 On / Off(0:OFF / 1 : ON)

        public float FlowSet3 
        { 
            get => Packet.fFlowSet3; 
            set => Packet.fFlowSet3 = value; 
        }   // 유량설정3 (0 ~ 150ml/min) // default : 20

        public bool FlowOnoff3 
        { 
            get => Packet.fFlowOnoff3; 
            set => Packet.fFlowOnoff3 = value; 
        }								// Flow3 On/Off (0:OFF / 1:ON)
    }
}
