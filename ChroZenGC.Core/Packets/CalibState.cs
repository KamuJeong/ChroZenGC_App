using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum SensorZeroStates
    {
        Stop, Checking, Pass, Error, Complete, Reset
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct CalibState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroStates[] InletSensorZeroState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroStates[] DetectorSensorZeroState;



        public CalibActions action;
        public CalibFunctions function;
        public CalibTargets target;
    }
}
