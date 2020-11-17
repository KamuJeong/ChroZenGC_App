using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_INST_INFORM
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public char[] InstDate;      // xxxx.xx.xx : 11
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] InstVersion;   // 1.0.0,  x.x.xx : 32
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] InstSerialNo;	// G6700xxxx, : 10
    }
    public static class T_INST_INFORMManager
    {
        static T_INST_INFORMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_INST_INFORM InitiatedInstance;

        static T_INST_INFORM GetInitializedInstance()
        {
            return new T_INST_INFORM
            {
                InstDate = new char[11],
                InstVersion = YC_Type_Util.StringToCharArray("1.0.0", 32),
                InstSerialNo = YC_Type_Util.StringToCharArray("G6700xxxx", 10),
            };
        }
    }
}
