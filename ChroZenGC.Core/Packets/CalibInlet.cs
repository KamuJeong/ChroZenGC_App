using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum CalibrationTypes : byte
    {
        SensorZero, Valve, Flow, Temp
    }

    public enum CalibrationSensors : byte
    {
        Sensor1, Sensor2, Sensor3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CalibInlet
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
