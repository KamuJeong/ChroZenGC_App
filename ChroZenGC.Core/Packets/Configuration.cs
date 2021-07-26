using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum ValveTypes : byte
    {
        None, GSV, LSV,
    }

    public enum ActuatorTypes : byte
    {
        Air, Electric,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _ValveConfig
    {
        public byte btMultiCount;                          // Multi Position Valve 수
        public byte btValveCount;                          // ?? 2-Position Valve 수 // (Air or Electronic Actuator)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ValveTypes[] btType1;                            // 2-Position Valve1~8의 밸브타입   [8] 
                                                          // #define TYPE_NONE		0 // 설치안됨
                                                          // #define TYPE_GSV			1
                                                          // #define TYPE_LSV			2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ActuatorTypes[] btType2;                            // #define TYPE_AIR			1		// Air Actuator [8]
                                                          // #define TYPE_ELE			2		// Electronic Actuator

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btPort;                             // 2-Position Valve1~Valve8의 포트수 [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fLoop1;                            // 2-Position Valve1~Valve8의 루프1 용량  [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fLoop2;                            // 2-Position Valve1~Valve8의 루프2 용량 [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btInlet;                            // 2-Position Valve1~Valve8에 연결된 Inlet. port 번호 [8]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public ValveTypes[] btMultiType;                        // Multi Position Valve1~2의 밸브타입 [2]
                                                          // #define TYPE_NONE			0  // 설치안됨
                                                          // #define TYPE_GSV			1
                                                          // #define TYPE_LSV			2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiPort;                        // Multi Position Valve1~2의 포트수 [2]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fMultiLoop;                        // Multi Position Valve1~2의 루프용량 [2]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiInlet;                       // Multi Position Valve1~2 에 연결된 Inlet. port 번호 [2]
    }

    public enum InletTypes : byte
    {
        None, Capillary, Packed, OnColumn,
    }

    public enum DetectorTypes : byte
    {
        None, FID, TCD, FPD_Not_used, NPD_Not_used, ECD, PFPD, PDD, FPD, NPD, uTCD, uECD,
    }

    public enum Aux4Types : byte
    {
        Valve, Methanizer, TransferLine,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Configuration
    {
        public byte btSave;

        public byte bOven;                      // Oven - (0:Not Install / 1:Install)
        public byte bCryogenic;                 // 극저온 Cryogenic - (0:Not Install / 1:Install)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public InletTypes[] btInlet;             // Inlet1~3의 종류 [YC_Const.INLET_SLOT_COUNT]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public DetectorTypes[] btDet;                //  Detector1~3의 종류 [DET_SLOT_COUNT]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bAuxAPC;                // Auxiliary APC (0:Not Install / 1:Type 1~ 6:Type6) [AUX_APC_COUNT]

        public byte bAutosampler;                          // AutoSampler - (0:Not Install / 1:Install)

        public Aux4Types bMethanizer;                           // Methanizer- (0:Not Install / 1:Install)
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

        public _ValveConfig ValveConfig;
    }
}
