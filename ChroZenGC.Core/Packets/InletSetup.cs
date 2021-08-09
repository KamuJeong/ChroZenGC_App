using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum GasTypes : byte
    {
        N2, He, H2, Ar, ArCH4
    }

    public enum APCModes : byte
    {
        ConstantFlow, ConstantPressure, ProgrammedFlow, ProgrammedPressure
    }

    public enum TempModes : byte
    {
        Isothermal, Program, TrackOven
    }

    public enum InjectModes : byte
    {
        Split, Splitless, PulsedSplit, PulsedSplitless
    }

    public enum InletConnection : byte
    {
        FrontDetector, CenterDetector, RearDetector, MSD
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct _InletTempProgram
    {
        public float fRate;                // 분당승온(하강)비율(0~100℃/min)
        public float fFinalTemp;           // 프로그램 모드에서 설정(목표)온도
        public float fFinalTime;           // 설정(목표)온도 유지시간(분)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _ApcFlowProgram
    {
        public float fRate;                // 유량변화율(ml/min/min)
        public float fFinalFlow;           // 설정(목표)유량(ml/min)
        public float fFinalTime;           // 설정유량 유지시간(min)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _ApcPressProgram
    {
        public float fRate;                // 압력변화율(psi/min)
        public float fFinalPress;      // 설정(목표)압력(psi/min)	
        public float fFinalTime;         // 설정압력 유지시간(min)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InletSetup
    {
        public byte btPortNo;             // 설치위치(0:front / 1:center / 2:rear)
                                          //Inlet->Config : Carrier Gas
        public GasTypes btCarriergas;               // Carrier Gas(0:N2 / 1:He / 2:H2 / 3:Ar / 4:ArCh4)

        public APCModes btApcMode;

        public float fLength;                  // [CO]										// Column Length (m)
                                               //Inlet->APC : Column.Diameter(mm)
        public float fDiameter;                // [CO]										// Column I.D. (mm)
                                               //Inlet->APC : Column.Thickness(um)
        public float fThickness;               // [CO]										// Column Film Thickness (um)
        public InletConnection btConnection;            // ???  -> 6500GC -> not used - detector에서셋팅

        public byte bGasSaverMode;             // [C]	0: OFF 1:ON							// 가스절약모드설정(0:Off / 1:On)  -> 6500GC에서는 BYTE대신 BOOL사용
        public float fGasSaverTime;            // [C]	0: OFF 1:ON							// 가스절약모드 시작시간(0~9999min)
        public float fGasSaverFlow;            // [C]	0: OFF 1:ON							// 가스절약모드 유량(ml/min)	

        public byte bPressCorrect;                       //OFF(0:Off / 1 : On) // default : OFF
                                                         // Capillary, On-Column Inlet에서 사용

        public float fPressCorrect;                      // 0.0psi
        public byte bVacuumCorrect;                      // ON (0:Off / 1:On) // default : ON
                                                         // Capillary, On-Column Inlet에서 사용

        public TempModes btTempMode;                          //On - Column 온도프로그램 모드
                                                         //(0:Iso - thermal / 1 : Program Mode / 2 : Track Oven)
        public float fTempSet;                           // 설정온도(0 ~ 450℃)
        public byte fTempOnoff;                          // 히터 동작(0:OFF / 1 : ON)

        public InjectModes btInjMode;                           // 190822
                                                         // Capillary Inlet APC 모드(0:Split mode / 1:Splitless mode)
                                                         //	2:Pulsed Split mode / 3 : Pulsed Splitless mode) - 20180724


        public float fColumnFlowSet;                     // Column Flow(ml/min) 
                                                         // -- APC Mode가 [Constant Flow]이거나 [Programed Flow]일 때 설정 가능
                                                         //BOOL bColumnFlowOnoff;													// Flow On/Off (0:OFF / 1:ON)
        public byte fColumnFlowOnoff;

        public float fPressureSet;                       // Column Pressure(psi) 
                                                         // -- APC Mode가 [Constant Pressure] 이거나 [Programed Pressure]일 때 설정 가능
                                                         //BOOL bPressureOnoff;														// Pressure On / Off(0:OFF / 1 : ON) – 사용안함. - 20180724
        public byte fPressureOnoff;
        public short iSplitratio;                        // [C]										// Capillary Inlet Split Ratio

        public float fPulsed_FlowPressSet;               // default : 20 psi	
        public float fPulsed_Time;                       // default : 1 min

        public float fSplitFlowSet;            // [C]	// Capillary Inlet Split Flow
        public float fSplitOnTime;             // [C]	// Capillary Inlet의 Splitless mode 에서 Split mode로 변경되는 시간(min)
        public float fTotalFlowSet;            // [C]	// Capillary Inlet Total Flow
                                               //BOOL __bTotalFlowOnoff;			// [C] not used
        public byte fTotalFlowOnoff;                                                       // Capillary Inlet Total Flow On / Off(0:OFF / 1 : ON) – 사용안함 - 20180724

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public _InletTempProgram[] tempPrgm;        // - On-Column Inlet일 경우만 사용가능 index[0]이 초기값임, 6

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public _ApcFlowProgram[] flowPrgm;         // 6

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public _ApcPressProgram[] presPrgm;        //6       
    }
}
