using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_VOLTAGE_CHECK
    {
        public float MAIN_V50D;
        public float MAIN_N50V;
        public float MAIN_V12P;
        public float MAIN_V24P;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] APC_INJ_V25D;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] APC_INJ_V33D;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] APC_INJ_V50D;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] APC_INJ_V24;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] APC_INJ_SEN1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] APC_INJ_SEN2;

        public float APC_DET_V25D;
        public float APC_DET_V33D;
        public float APC_DET_SEN;

        public float APC_AUX_V25D;
        public float APC_AUX_V33D;
        public float APC_AUX_SEN;
    }
    public static class T_YL6700GC_VOLTAGE_CHECKManager
    {
        static T_YL6700GC_VOLTAGE_CHECKManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_VOLTAGE_CHECK InitiatedInstance;

        static T_YL6700GC_VOLTAGE_CHECK GetInitializedInstance()
        {
            return new T_YL6700GC_VOLTAGE_CHECK
            {
                APC_INJ_V25D = new float[3],
                APC_INJ_V33D = new float[3],
                APC_INJ_V50D = new float[3],
                APC_INJ_V24 = new float[3],
            };
        }
    }
}
