using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _CalibTempSet
    {
        public float Set1;
        public float Set2;
        public float Measure1;
        public float Measure2;
        public float Factor1;
        public float Factor2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CalibOven
    {
        public _CalibTempSet Set;
    }
}
