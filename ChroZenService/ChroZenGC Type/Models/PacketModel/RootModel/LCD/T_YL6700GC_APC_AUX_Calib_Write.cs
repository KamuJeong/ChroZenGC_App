using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_APC_AUX_Calib_Write
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Aux_flowCalSet;    //3 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Aux_flowCalMeasure;    //3 
        public byte Aux_CalibState;    // Calibration 종류	//
        public byte Aux_FlowCalType;   // Flow Calib 적용할 센서 종류	// sen1, sen2 sen3
    }
    public static class T_YL6700GC_APC_AUX_Calib_WriteManager
    {
        static T_YL6700GC_APC_AUX_Calib_WriteManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_APC_AUX_Calib_Write InitiatedInstance;

        static T_YL6700GC_APC_AUX_Calib_Write GetInitializedInstance()
        {
            return new T_YL6700GC_APC_AUX_Calib_Write
            {
                Aux_flowCalSet = new float[3],
                Aux_flowCalMeasure = new float[3],                
            };
        }
    }
}
