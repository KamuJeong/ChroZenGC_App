using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static YC_ChroZenGC_Type.YC_Const;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_SYSTEM_CONFIG
    {
        public byte btSave;

        public byte bOven;                                 // Oven - (0:Not Install / 1:Install)
        public byte bCryogenic;                            // 극저온 Cryogenic - (0:Not Install / 1:Install)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btInlet;             // Inlet1~3의 종류 [YC_Const.INLET_SLOT_COUNT]
                                           // (0:Not Install / 1 : Capillary / 2 : Packed / 3 : OnColumn)
        public enum INLET_TYPE
        {
            NOT_INSTALLED,
            CAPILLARY,
            PACKED,
            ON_COLUMN
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btDet;                //  Detector1~3의 종류 [DET_SLOT_COUNT]
                                            //  (0:Not Install / 1:FID / 2:TCD / 3:FPD / 4:NPD / 5:ECD
                                            //  / 6:PFPD / 7:PDD / 8:FPD / 9:NPD / A: uTCD / B: uECD)

        public enum DET_TYPE
        {
            NOT_INSTALLED,
            FID,
            TCD,
            FPD_Not_used,
            NPD_Not_used,
            ECD,
            PFPD,
            PDD,
            FPD,
            NPD,
            uTCD,
            uECD
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bAuxAPC;                // Auxiliary APC (0:Not Install / 1:Type 1~ 6:Type6) [AUX_APC_COUNT]

        public byte bAutosampler;                          // AutoSampler - (0:Not Install / 1:Install)

        public byte bMethanizer;                           // Methanizer- (0:Not Install / 1:Install)
                                                           // Auxiliary 8개 중 하나 // Valve port 4로 고정한다.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bAuxTemp;              // Sampling Valve의 히터 설치여부 [AUX_TEMP_COUNT]
                                             // Auxiliary Heater 1의 설치정보 : Valve1 온도 제어
                                             // Auxiliary Heater 8의 설치정보 : Valve8 온도 제어
                                             //	위항목의 Methanizer의 설치는Valve4위치에 설치하여 온도 제어한다.
                                             //	- (0:Not Install / 1 : Install)
                                             //	// Sampling Valve의 히터 설치여부 
                                             //	// 밸브의 설치여부는 YL6700GC_VALVE_CONFIG_t에서 설정

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bMultiValve;        // (0:Not Install / 1:Install) // RS232C포트에 연결됨 [MVALVE_SLOT_COUNT]
                                          //VALVE_CONFIG_t ValveConfig;					// Valve 설치 정보
        public T_VALVE_CONFIG ValveConfig;
    }
    public static class T_CHROZEN_GC_SYSTEM_CONFIGManager
    {
        static T_CHROZEN_GC_SYSTEM_CONFIGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_SYSTEM_CONFIG InitiatedInstance;

        static T_CHROZEN_GC_SYSTEM_CONFIG GetInitializedInstance()
        {
            return new T_CHROZEN_GC_SYSTEM_CONFIG
            {
                btInlet = new byte[YC_Const.INLET_SLOT_COUNT],
                btDet = new byte[YC_Const.DET_SLOT_COUNT],
                bAuxAPC = new byte[YC_Const.AUX_APC_COUNT],
                bAuxTemp = new byte[YC_Const.AUX_TEMP_COUNT],
                bMultiValve = new byte[YC_Const.VALVE_SLOT_COUNT],
                ValveConfig = T_VALVE_CONFIGManager.InitiatedInstance
            };
        }
    }
}
