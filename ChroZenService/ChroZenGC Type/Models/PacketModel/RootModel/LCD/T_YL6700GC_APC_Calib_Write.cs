using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_APC_Calib_Write
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] inj_flowCalSet;//9, // 0:Pur 1:Spl 2:col(Press)	// 2: pack-On
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Det_flowCalSet;//9, // 0:H2(FID)  1:mk_up(FID)/sam(TCD) 2:Air(FID)/ref(TCD)/mk_up(ECD)	

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Inj_flowCalMeasure;//9,	// 0:Pur 1:Spl 2:col(Press) // 2: pack-On
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Det_flowCalMeasure;//9, // 0:H2(FID)  1:mk_up(FID)/sam(TCD) 2:Air(FID)/ref(TCD)/mk_up(ECD)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Inj_CalibState;//3,  // Calibration 종류	//
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Det_CalibState;//3,  // Calibration 종류

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Inj_FlowCalType;//3, // Flow Calib 적용할 센서 종류	// sen1, sen2 sen3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Det_FlowCalType;//3, // Flow Calib 적용할 센서 종류

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Aux_flowCalSet;//9, // 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Aux_flowCalMeasure;//9, // 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Aux_CalibState;//3,     // Calibration 종류	//
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Aux_FlowCalType;//3,    // Flow Calib 적용할 센서 종류	// sen1, sen2 sen3
    }
    public static class T_YL6700GC_APC_Calib_WriteManager
    {
        static T_YL6700GC_APC_Calib_WriteManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_APC_Calib_Write InitiatedInstance;

        static T_YL6700GC_APC_Calib_Write GetInitializedInstance()
        {
            return new T_YL6700GC_APC_Calib_Write
            {
                inj_flowCalSet = new float[9],
                Det_flowCalSet = new float[9],
                Inj_flowCalMeasure = new float[9],
                Det_flowCalMeasure = new float[9],
                Inj_CalibState = new byte[3],
                Det_CalibState = new byte[3],
                Inj_FlowCalType = new byte[3],
                Det_FlowCalType = new byte[3],
                Aux_flowCalSet = new float[9],
                Aux_flowCalMeasure = new float[9],
                Aux_CalibState = new byte[3],
                Aux_FlowCalType = new byte[3],
            };
        }
    }
}
