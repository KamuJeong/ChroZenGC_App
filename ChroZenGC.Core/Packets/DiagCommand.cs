using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum DiagTarget : byte
    {
        Heater, Ignitor, ExtIO, Valve, Sensor, Power
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DiagCommand
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool bStartStop; // default : stop	// Stop : 0, Start : 1
        public DiagTarget btFunc; // default : 0	
                                  // 0:Heater, 1: Ignitor & Valve, 2: Remot & Signal, 3: APCvalve,

    }
}
