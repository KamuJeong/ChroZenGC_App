using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_APC_INLET_Calib_Write
    {
        public T_YL6700GC_TEMP_CALIB_VALUE t_YL6700GC_TEMP_CALIB_VALUE;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] inj_flowCalSet;//3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] inj_flowCalMeasure;//3
        public byte inj_CalibState;
        public byte inj_FlowCalType;//Flow Calib 적용할 센서 종류  //sen1, sen2, sen3
    }
    public static class T_YL6700GC_APC_INLET_Calib_WriteManager
    {
        static T_YL6700GC_APC_INLET_Calib_WriteManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_APC_INLET_Calib_Write InitiatedInstance;

        static T_YL6700GC_APC_INLET_Calib_Write GetInitializedInstance()
        {
            return new T_YL6700GC_APC_INLET_Calib_Write
            {
                t_YL6700GC_TEMP_CALIB_VALUE = T_YL6700GC_TEMP_CALIB_VALUEManager.InitiatedInstance,
                inj_flowCalSet = new float[3],
                inj_flowCalMeasure = new float[3],
            };
        }
    }
}
