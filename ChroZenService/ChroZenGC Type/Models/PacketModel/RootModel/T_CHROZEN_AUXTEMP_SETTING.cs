using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_AUXTEMP_SETTING
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fTempSet;                              // 설정온도(0 ~ ℃) // default : 50 // Max 300 , [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] fTempOnoff;								// 히터 동작(0:OFF / 1:ON), [8]
    }
    public static class T_CHROZEN_AUXTEMP_SETTINGManager
    {
        static T_CHROZEN_AUXTEMP_SETTINGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_AUXTEMP_SETTING InitiatedInstance;

        static T_CHROZEN_AUXTEMP_SETTING GetInitializedInstance()
        {
            return new T_CHROZEN_AUXTEMP_SETTING
            {
                fTempSet = new float[8],
                fTempOnoff = new byte[8]
            };
        }
    }
}
