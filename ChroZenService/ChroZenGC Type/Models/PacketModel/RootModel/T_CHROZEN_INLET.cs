using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_INLET
    {
        //iSplitratio = 10;
        //fSplitOnTime = 1.0f;
        //fSplitFlowSet = 27.0f;
        //fTotalFlowSet = 33.0f;

        //fLength = 30.0f;		// [CO]
        //fDiameter = 0.32f;		// [CO]
        //fThickness = 0.25f;		// [CO]
        //fColumnFlowSet = 3.0f;
        public byte btPortNo;             // 설치위치(0:front / 1:center / 2:rear)
        //Inlet->Config : Carrier Gas
        public byte btCarriergas;               // Carrier Gas(0:N2 / 1:He / 2:H2 / 3:Ar / 4:ArCh4)
        public enum E_INLET_CARRIER_GAS_TYPE
        {
            N2,
            He,
            H2,
            Ar,
            ArCH4
        }
        //Inlet->Config : APC Mode
        public byte btApcMode;
        // APC Mode(0:Constant Flow 
        // 1:Constant Pressure / 2:Programed Flow / 3:Programed Pressure

        public enum E_INLET_APC_MODE
        {
            CONSTANT_FLOW,
            CONSTANT_PRESSURE,
            PROGRAMMED_FLOW,
            PROGRAMMED_PRESSURE
        }

        //Inlet->APC : Column.Length(m)
        public float fLength;                  // [CO]										// Column Length (m)
        //Inlet->APC : Column.Diameter(mm)
        public float fDiameter;                // [CO]										// Column I.D. (mm)
        //Inlet->APC : Column.Thickness(um)
        public float fThickness;               // [CO]										// Column Film Thickness (um)
        public byte __btConnection;            // ???  -> 6500GC -> not used - detector에서셋팅

        //Inlet->
        public byte bGasSaverMode;             // [C]	0: OFF 1:ON							// 가스절약모드설정(0:Off / 1:On)  -> 6500GC에서는 BYTE대신 BOOL사용
        public float fGasSaverTime;            // [C]	0: OFF 1:ON							// 가스절약모드 시작시간(0~9999min)
        public float fGasSaverFlow;            // [C]	0: OFF 1:ON							// 가스절약모드 유량(ml/min)	

        public byte bPressCorrect;                                                         //OFF(0:Off / 1 : On) // default : OFF
                                                                                           // Capillary, On-Column Inlet에서 사용

        public float fPressCorrect;                                                        // 0.0psi
        public byte bVacuumCorrect;                                                        // ON (0:Off / 1:On) // default : ON
                                                                                           // Capillary, On-Column Inlet에서 사용

        public enum E_INLET_TEMP_MODE
        {
            ISO_THERMAL,
            PROGRAM,
            TRACK_OVEN
        }

        public byte btTempMode;                                                            //On - Column 온도프로그램 모드
                                                                                           //(0:Iso - thermal / 1 : Program Mode / 2 : Track Oven)
        public float fTempSet;                                                             // 설정온도(0 ~ 450℃)
        public byte fTempOnoff;                                                            // 히터 동작(0:OFF / 1 : ON)

        public byte btInjMode;                                                             // 190822
                                                                                           // Capillary Inlet APC 모드(0:Split mode / 1:Splitless mode)
                                                                                           //	2:Pulsed Split mode / 3 : Pulsed Splitless mode) - 20180724
        public enum E_INLET_INJ_MODE
        {
            SPLIT_MODE,
            SPLITLESS_MODE,
            PULSED_SPLIT_MODE,
            PULSED_SPLITLESS_MODE
        }

        public float fColumnFlowSet;                                                       // Column Flow(ml/min) 
                                                                                           // -- APC Mode가 [Constant Flow]이거나 [Programed Flow]일 때 설정 가능
                                                                                           //BOOL bColumnFlowOnoff;													// Flow On/Off (0:OFF / 1:ON)
        public byte fColumnFlowOnoff;

        public float fPressureSet;                                                         // Column Pressure(psi) 
                                                                                           // -- APC Mode가 [Constant Pressure] 이거나 [Programed Pressure]일 때 설정 가능
                                                                                           //BOOL bPressureOnoff;														// Pressure On / Off(0:OFF / 1 : ON) – 사용안함. - 20180724
        public byte fPressureOnoff;
        public short iSplitratio;                                                          // [C]										// Capillary Inlet Split Ratio

        public float fPulsed_FlowPressSet;                                                 // default : 20 psi	
        public float fPulsed_Time;                                                         // default : 1 min

        public float fSplitFlowSet;            // [C]										// Capillary Inlet Split Flow
        public float fSplitOnTime;             // [C]										// Capillary Inlet의 Splitless mode 에서 Split mode로 변경되는 시간(min)
        public float fTotalFlowSet;            // [C]										// Capillary Inlet Total Flow
                                               //BOOL __bTotalFlowOnoff;			// [C] not used
        public byte fTotalFlowOnoff;                                                       // Capillary Inlet Total Flow On / Off(0:OFF / 1 : ON) – 사용안함 - 20180724

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public T_INLET_TEMP_PRGM[] tempPrgm;        // - On-Column Inlet일 경우만 사용가능 index[0]이 초기값임, 6

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public T_APC_FLOW_PRGM[] flowPrgm;         // 6

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public T_APC_PRESS_PRGM[] presPrgm;        //6       
    }
    public static class T_CHROZEN_INLETManager
    {
        static T_CHROZEN_INLETManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_INLET InitiatedInstance;

        static T_CHROZEN_INLET GetInitializedInstance()
        {
            return new T_CHROZEN_INLET
            {
                iSplitratio = 10,
                fSplitOnTime = 1,
                fSplitFlowSet = 27,
                fTotalFlowSet = 33,
                fLength = 30,
                fDiameter = 0.32f,
                fThickness = 0.25f,
                fColumnFlowSet = 3.0f,
                tempPrgm = new T_INLET_TEMP_PRGM[]
                {
                    T_INLET_TEMP_PRGMManager.InitiatedInstance,
                    T_INLET_TEMP_PRGMManager.InitiatedInstance,
                    T_INLET_TEMP_PRGMManager.InitiatedInstance,
                    T_INLET_TEMP_PRGMManager.InitiatedInstance,
                    T_INLET_TEMP_PRGMManager.InitiatedInstance,
                    T_INLET_TEMP_PRGMManager.InitiatedInstance,
                },
                flowPrgm = new T_APC_FLOW_PRGM[]
                {
                    T_APC_FLOW_PRGMManager.InitiatedInstance,
                    T_APC_FLOW_PRGMManager.InitiatedInstance,
                    T_APC_FLOW_PRGMManager.InitiatedInstance,
                    T_APC_FLOW_PRGMManager.InitiatedInstance,
                    T_APC_FLOW_PRGMManager.InitiatedInstance,
                    T_APC_FLOW_PRGMManager.InitiatedInstance,
                },
                presPrgm = new T_APC_PRESS_PRGM[]
                {
                    T_APC_PRESS_PRGMManager.InitiatedInstance,
                    T_APC_PRESS_PRGMManager.InitiatedInstance,
                    T_APC_PRESS_PRGMManager.InitiatedInstance,
                    T_APC_PRESS_PRGMManager.InitiatedInstance,
                    T_APC_PRESS_PRGMManager.InitiatedInstance,
                    T_APC_PRESS_PRGMManager.InitiatedInstance,
                }
            };
        }
    }
}
