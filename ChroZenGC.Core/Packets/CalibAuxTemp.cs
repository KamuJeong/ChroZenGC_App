using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CalibAuxTemp
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] Set;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] Measure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] Factor;
    }
}
