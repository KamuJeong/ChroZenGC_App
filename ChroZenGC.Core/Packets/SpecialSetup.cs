using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _ColumnCondition
    {
        public byte bOnoff;        // 제어기에서 사용안함. mpu/evc에서는 사용 --> 실행후 자동 off
        public float fInitTemp;
        public float fInitTime;
        public float fRate;
        public float fFinalTemp;
        public float fFinalTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fFlow;     // 유량 설정,      [3]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bFlowOnoff; //     [3]
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _RemoteAccess
    {
        public float fTime;            // Start signal 출력유지시간 (mSec) (100-5000)msec
        public byte bOnoff;
        public float fEventTime1;  // Start signal 출력시간 (min) (0-9999)
        public float fEventTime2;	//
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SpecialSetup
    {
        public _ColumnCondition ColumnClean;
        public _RemoteAccess RemoteAccess;
    }
}
