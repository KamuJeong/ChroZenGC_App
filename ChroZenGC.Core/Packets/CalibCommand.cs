using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum CalibActions : byte
    {
        Stop, Start, Apply, Reset
    }

    public enum CalibFunctions : byte
    {
        None, Temp, SensZero, Valve, Flow, Press, Signal 
    }

    public enum CalibTargets : byte
    {
        Oven, Inlet1, Inlet2, Inlet3, Det1, Det2, Det3, AuxUPC1, AuxUPC2, AuxUPC3, 
        Aux1, Aux2, Aux3, Aux4, Aux5, Aux6, Aux7, Aux8, Signal1, Signal2, Signal3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CalibCommand
    {
        public CommandCodes command;
        public CalibActions action;
        public CalibFunctions function;
        public CalibTargets target;
    }
}
