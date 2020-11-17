using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_COLUMN_CONDITION_FUNCTION
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
    public static class T_CHROZEN_COLUMN_CONDITION_FUNCTIONManager
    {
        static T_CHROZEN_COLUMN_CONDITION_FUNCTIONManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_COLUMN_CONDITION_FUNCTION InitiatedInstance;

        static T_CHROZEN_COLUMN_CONDITION_FUNCTION GetInitializedInstance()
        {
            return new T_CHROZEN_COLUMN_CONDITION_FUNCTION
            {
                fFlow = new float[3],
                bFlowOnoff = new byte[3]
            };
        }
    }
}
