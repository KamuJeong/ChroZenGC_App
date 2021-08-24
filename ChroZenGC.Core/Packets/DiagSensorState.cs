using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DiagSensorState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Inj_Volt;//9,			// Inj 3*3 Voltage
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Det_Volt;//9,			// Det 3*3 Voltage
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Aux_Volt;//9,			// Aux 3*3 Voltage
    }
}
