using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum CommandCodes : byte
    {
        None, Start, Stop, ReadyRun, ColumnCondition, Shutdown, Startup, Diagnostics, Calibration, Method, PowerSave, Reset = 30, Wakeup = 55,
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct GCCommand
    {
        public CommandCodes btCommand;
        public byte btSubCommand1;
        public byte btSubCommand2;
    }
}
