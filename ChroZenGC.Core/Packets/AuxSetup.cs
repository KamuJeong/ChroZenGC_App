using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AuxTempSetup
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fTempSet;                              // 설정온도(0 ~ ℃) // default : 50 // Max 300 , [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] fTempOnoff;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AuxUPCSetup
    {
        public int btPort;

        public GasTypes btAuxGas;                                  //가스종류 (0:N2 / 1:He / 2:H2 / 3:Ar / 4:ArCh4) // default : (N2)

        public float fFlowSet1;                                // 유량설정1 (0 ~ 150ml/min) // default : 20
//        [MarshalAs(UnmanagedType.Bool)]
        public bool fFlowOnoff1;                               // Flow1 On / Off(0:OFF / 1 : ON)
        public float fFlowSet2;                                // 유량설정2 (0 ~ 150ml/min) // default : 20
//        [MarshalAs(UnmanagedType.Bool)]
        public bool fFlowOnoff2;                               // Flow2 On / Off(0:OFF / 1 : ON)
        public float fFlowSet3;                                // 유량설정3 (0 ~ 150ml/min) // default : 20
//        [MarshalAs(UnmanagedType.Bool)]
        public bool fFlowOnoff3;								// Flow3 On/Off (0:OFF / 1:ON)
    }
}
