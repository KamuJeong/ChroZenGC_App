using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum ValvePosition : byte
    {
        Valve1, Valve2, Valve3, Valve4, Valve5, Valve6, Valve7, Valve8, Multi1, Multi2, Delete
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _ValveProgram
    {
        public float fTime;
        public ValvePosition btNumber;      // Valve Number (
                                   // 0 : 2 - Position Valve 1 /     1 : 2 - Position Valve 2
                                   // 2 : 2 - Position Valve 3 /     3 : 2 - Position Valve 4
                                   // 4 : 2 - Position Valve 5 /     5 : 2 - Position Valve 6
                                   // 6 : 2 - Position Valve 3 /     7 : 2 - Position Valve 8
                                   // 8 : Multi - Position Valve 1 / 9 : Multi - Position Valve 2
                                   // 10 : Program end)
                                   // 프로그램 끝에는 반드시[Program End]가 있어야 함

        public byte btState;       // Valve Position(0~)
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct ValveSetup
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bInitState;                          // 2 - Position Valve 초기상태(OFF : 0 / ON : 1) // default : OFF,      [CHROGEN_VALVE_COUNT] = 8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bState;                                           // [CHROGEN_VALVE_COUNT]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiInitState;            // Multi - Position Valve초기 위치(Position : 0~) // default : Pos1,      [CHROGEN_MULTI_VALVE_COUNT] = 2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiState;          // Valve Program : YL6700GC_VALVE_PROGRAM = 20,       [CHROGEN_MULTI_VALVE_COUNT] = 2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public _ValveProgram[] Prgm;            // [CHROGEN_VALVE_PROGRAM] = 20;      
    }
}
