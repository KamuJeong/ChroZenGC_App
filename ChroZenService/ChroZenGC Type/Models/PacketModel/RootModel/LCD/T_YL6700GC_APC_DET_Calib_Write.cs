using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_APC_DET_Calib_Write
    {
        public T_YL6700GC_TEMP_CALIB_VALUE t_YL6700GC_TEMP_CALIB_VALUE;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Det_FlowCalSet;//3, 1:mk_up(FID)/sam(TCD) 2:Air(FID)/ref(TCD)/mk_up(ECD)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Det_flowCalMeasure;//3,        // 0:H2(FID)  1:mk_up(FID)/sam(TCD) 2:Air(FID)/ref(TCD)/mk_up(ECD)
        public byte Det_CalibState;    // Calibration 종류
        public byte Det_FlowCalType;	// Flow Calib 적용할 센서 종류
    }
    public static class T_YL6700GC_APC_DET_Calib_WriteManager
    {
        static T_YL6700GC_APC_DET_Calib_WriteManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_APC_DET_Calib_Write InitiatedInstance;

        static T_YL6700GC_APC_DET_Calib_Write GetInitializedInstance()
        {
            return new T_YL6700GC_APC_DET_Calib_Write
            {
                t_YL6700GC_TEMP_CALIB_VALUE = T_YL6700GC_TEMP_CALIB_VALUEManager.InitiatedInstance,
                Det_FlowCalSet = new float[3],
                Det_flowCalMeasure = new float[3],
            };
        }
    }
}
