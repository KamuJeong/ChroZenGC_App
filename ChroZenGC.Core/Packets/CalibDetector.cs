using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CalibDetector
    {
        public _CalibTempSet Temp;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] FlowSet;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] FlowMeasure;

        public CalibrationTypes Type;
        public CalibrationSensors Sensor;
    }
}
