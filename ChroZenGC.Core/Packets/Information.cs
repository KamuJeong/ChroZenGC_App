using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct _SystemConfig
    {
        public _SystemTime SysTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] cIPAddress;//16
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cPortNo;//5
        public byte bPassword;
        public byte bAutosampler;
        public byte bKeyLock;
        public byte bKeyBeep;
        public byte bWarnningBeep;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct _Inst_Inform
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string InstDate;      // xxxx.xx.xx : 11
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string InstVersion;   // 1.0.0,  x.x.xx : 32
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string InstSerialNo;	// G6700xxxx, : 10
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Information
    {
        public _SystemConfig SysConfig;
        public _Inst_Inform InstInfo;
    }
}
