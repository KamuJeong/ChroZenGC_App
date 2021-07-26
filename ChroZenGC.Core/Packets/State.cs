using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum Modes : byte
    {
        Init, Ready, NotReady, Run, Error, PowerSave, Diagnostics, Calibration, Unknown, PostRun, AutoReadyRun, ColumnCondition, GasSaver
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct _CurrentTemperature
    {
        public float fOven;
        public float fOvenSet;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fInj;            //3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fInjSet;         //3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fDet;            //3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fAux;            //8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fExt;            //2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _CurrentFlow
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Press;                   // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Disp_FrontInjFlow;                 // 3 X 4 = 12
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Disp_CenterInjFlow;                 // 3 X 4 = 12
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Disp_RearInjFlow;                 // 3 X 4 = 12

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Velocity_Inj;            // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Setflow;                 // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Setpress;                // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_FrontDetFlow;                 // 3 X 3 = 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_CenterDetFlow;                 // 3 X 3 = 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_RearDetFlow;                 // 3 X 3 = 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Aux1Flow;                 // 3 X 3 = 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Aux2Flow;                 // 3 X 3 = 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Aux3Flow;                 // 3 X 3 = 9
    }

    [Flags]
    public enum TemperatureFlags : UInt32
    {
        Oven = 1 << 0,
        Inlet1 = 1 << 1,
        Inlet2 = 1 << 2,
        Inlet3 = 1 << 3,
        Detector1 = 1 << 4,
        Detector2 = 1 << 5,
        Detector3 = 1 << 6,
        Aux1 = 1 << 7,
        Aux2 = 1 << 8,
        Aux3 = 1 << 9,
        Aux4 = 1 << 10,
        Aux5 = 1 << 11,
        Aux6 = 1 << 12,
        Aux7 = 1 << 13,
        Aux8 = 1 << 14,
    }
    
    [Flags]
    public enum FlowFlags : UInt32
    { 
        ColumnFlow1 = 1 << 0,
        ColumnFlow2 = 1 << 1,
        ColumnFlow3 = 1 << 2,
        FrontDetectorFlow1 = 1 << 3,
        FrontDetectorFlow2 = 1 << 4,
        FrontDetectorFlow3 = 1 << 5,
        CenterDetectorFlow1 = 1 << 6,
        CenterDetectorFlow2 = 1 << 7,
        CenterDetectorFlow3 = 1 << 8,
        RearDetectorFlow1 = 1 << 9,
        RearDetectorFlow2 = 1 << 10,
        RearDetectorFlow3 = 1 << 11,
        ColumnPressure1 = 1 << 12,
        ColumnPressure2 = 1 << 13,
        ColumnPressure3 = 1 << 14,
        Aux1Flow1 = 1 << 15,
        Aux1Flow2 = 1 << 16,
        Aux1Flow3 = 1 << 17,
        Aux2Flow1 = 1 << 18,
        Aux2Flow2 = 1 << 19,
        Aux2Flow3 = 1 << 20,
        Aux3Flow1 = 1 << 21,
        Aux3Flow2 = 1 << 22,
        Aux3Flow3 = 1 << 23,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct State
    {
        public Modes btState;
        public byte btPrgmStep;                        // 반복 분석 총 횟수
        public float fRunTime;                         // 현재 Run 진행시간
        public byte bRepeatRun;                        // 반복분석 여부 ( 0 = 반복 분석 아님, 1 = 반복 분석) 
                                                       //enum { RepeatOff, RepeatOn };
        public uint iCurrentRun;               // 현재 진행중인 Run 횟수

        public byte btErrorCode;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btGasSaver;                     // GasSaver 실행 여부,    3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btCurSignal;                    // 현재 출력되는 signal,    3

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btCurPolarity;                  // 현재 Polarity,   3
                                                      //enum { plus, minus };
        public _CurrentTemperature ActTemp;
        public _CurrentFlow ActFlow;

        public TemperatureFlags TempReady;
        public TemperatureFlags TempOnoff;

        public FlowFlags FlowReady;
        public FlowFlags FlowOnoff;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fSignal;                       // 현재 시그널 - DETECTOR signal,  3

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btValveState;                   //    8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiValveState;              //    2

        public byte btStep;
    }
}
