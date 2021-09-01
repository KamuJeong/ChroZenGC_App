using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum SensorZeroValveStates : byte
    {
        Stop, Checking, Pass, Error, Complete, Reset
    }

    public enum ValveCalibErrors : byte
    {
        VoltageHigh = 180, TimeOver, Valve16V, Fail
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CalibState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroValveStates[] InletSensorZeroState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroValveStates[] DetectorSensorZeroState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroValveStates[] InletValveState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroValveStates[] DetectorValveState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] FrontInletValveVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] CenterInletValveVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] RearInletValveVoltage;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] FrontDetectorValveVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] CenterDetectorValveVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] RearDetectorValveVoltage;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public ValveCalibErrors[] InletValveError;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public ValveCalibErrors[] DetectorValveError;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroValveStates[] AuxSensorZeroState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SensorZeroValveStates[] AuxValveState;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Aux1ValveVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Aux2ValveVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Aux3ValveVoltage;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public ValveCalibErrors[] AuxValveError;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] InletSensorVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] DetectorSensorVoltage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] AuxSensorVoltage;
    }
}
