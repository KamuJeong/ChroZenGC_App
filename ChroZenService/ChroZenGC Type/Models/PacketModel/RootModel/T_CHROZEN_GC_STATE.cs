using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_STATE
    {
        public enum CHROZEN_GC_STATE
        {
            INITIALIZE,
            READY,
            NOT_READY,
            RUN,
            ERROR,
            POWER_SAVE_MODE,
            DIAGNOSTICS,
            CALIBRATION,
            UNKNOWN,
            POST_RUN,
            AUTO_READY_RUN,
            COLUMN_CONDITION,
            GAS_SAVER
        };
        public byte btState;
        public enum E_STATE { Initilize = 0, Ready, NotReady, Run, Error, PowerSaveMode, Diagnostics, Calibration, Unknown, PostRun, AutoReadyRun, ColumnCondition, GasSaver };
        public byte btPrgmStep;                        // 반복 분석 총 횟수
        public float fRunTime;                         // 현재 Run 진행시간
        public byte bRepeatRun;                        // 반복분석 여부 ( 0 = 반복 분석 아님, 1 = 반복 분석) 
                                                       //enum { RepeatOff, RepeatOn };
        public uint iCurrentRun;               // 현재 진행중인 Run 횟수

        public byte btErrorCode;
        //enum { Normal, DoorOpen, OvenError, ThermalSensorErro = 10, HeatingError, FireError = 20, TempCalibrationError = 30, SensorZeroError, ValveCalibrationError, FlowCalibrationError, PressureCalibrationError, GasFlowLow = 40, TCDRefFlowLow = 42, TCDMakeupFlowLow = 43 };
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btGasSaver;                     // GasSaver 실행 여부,    3
                                                      //enum { SaveOff, SaveOn };
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btCurSignal;                    // 현재 출력되는 signal,    3
                                                      //enum { fornt = 0, center, rear };
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btCurPolarity;                  // 현재 Polarity,   3
                                                      //enum { plus, minus };
        public T_CHROZEN_GC_DEV_TEMP ActTemp;
        public T_CHROZEN_GC_APC_FLOW ActFlow;

        public T_CHROZEN_GC_TEMP_READY TempReady;
        public T_CHROZEN_GC_TEMP_READY TempOnoff;

        public T_CHROZEN_GC_FLOW_READY FlowReady;
        public T_CHROZEN_GC_FLOW_READY FlowOnoff;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fSignal;                       // 현재 시그널 - DETECTOR signal,  3

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btValveState;                   //    8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiValveState;              //    2

        public byte btStep;
    }
    public static class T_CHROZEN_GC_STATEManager
    {
        static T_CHROZEN_GC_STATEManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_STATE InitiatedInstance;

        static T_CHROZEN_GC_STATE GetInitializedInstance()
        {
            return new T_CHROZEN_GC_STATE
            {
                btGasSaver = new byte[3],
                btCurSignal = new byte[3],
                btCurPolarity = new byte[3],
                ActTemp = T_CHROZEN_GC_DEV_TEMPManager.InitiatedInstance,
                ActFlow = T_CHROZEN_GC_APC_FLOWManager.InitiatedInstance,
                TempReady = T_CHROZEN_GC_TEMP_READYManager.InitiatedInstance,
                TempOnoff = T_CHROZEN_GC_TEMP_READYManager.InitiatedInstance,
                FlowReady = T_CHROZEN_GC_FLOW_READYManager.InitiatedInstance,
                FlowOnoff = T_CHROZEN_GC_FLOW_READYManager.InitiatedInstance,
                fSignal = new float[3],
                btValveState = new byte[8],
                btMultiValveState = new byte[2]
            };
        }
    }
}
