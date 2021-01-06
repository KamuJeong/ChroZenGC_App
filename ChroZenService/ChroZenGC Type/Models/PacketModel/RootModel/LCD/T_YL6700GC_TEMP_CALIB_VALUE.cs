using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_TEMP_CALIB_VALUE
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fSet;//2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fMeasure;//2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fFactor;//2
    }
    public static class T_YL6700GC_TEMP_CALIB_VALUEManager
    {
        static T_YL6700GC_TEMP_CALIB_VALUEManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_TEMP_CALIB_VALUE InitiatedInstance;

        static T_YL6700GC_TEMP_CALIB_VALUE GetInitializedInstance()
        {
            return new T_YL6700GC_TEMP_CALIB_VALUE
            {
                fSet = new float[] { YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP, YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP },
                fMeasure = new float[] { YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP, YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP },
                fFactor = new float[2],
            };
        }
    }
}
