using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_SYSTEM_CONFIG
    {
        public T_SYSTEM_TIME SysTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] cIPAddress;//16
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] cPortNo;//5
        public byte bPassword;
        public byte bAutosampler;
        public byte bKeyLock;
        public byte bKeyBeep;
        public byte bWarnningBeep;
    }
    public static class T_SYSTEM_CONFIGManager
    {
        static T_SYSTEM_CONFIGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_SYSTEM_CONFIG InitiatedInstance;

        static T_SYSTEM_CONFIG GetInitializedInstance()
        {
            return new T_SYSTEM_CONFIG
            {
                cIPAddress = new byte[16],
                cPortNo = new byte[5]
            };
        }
    }
}
