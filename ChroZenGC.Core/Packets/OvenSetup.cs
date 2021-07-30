using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum OvenMode : byte
    {
        Isothermal, Program
    }

    public enum Coolants : byte
    {
        LN2, LCO2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _OvenProgram
    {
        public float fRate;            // 분당승온(하강)비율(0~℃/min) 	// 승온속도 [0 - 100]
        public float fFinalTemp;       // 프로그램 모드에서 설정(목표)온도
                                       // 첫번째(0번 배열)은 다른 프로그램들과 달리 오븐 프로그램의 첫번째이다. - 다른 프로그램(Inlet 등)은 첫번째가 초기값임.

        public float fFinalTime;       // 설정(목표)온도 유지시간(분)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _RunStart
    {
        public byte bOnoff;        // 자동반복분석(0:OFF / 1 : ON) 	// default : OFF
        public ushort iCount;      // 반복횟수(1~9999) // default : 1
        public float fCycletime; // 반복간격 (0~9999 min)
                                 // 총 분석시간 보다 크게 입력해야 함.
                                 // default : 10	
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _PostRun
    {
        public byte bOnoff;                // 후처리기능 (0:OFF / 1:ON)
        public float fTemp;                // 후처리온도
        public float fTime;                // 후처리 유지 시간 (0~9999min)  
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OvenSetup
    {
        public float fMaxTemp;                             // 오븐 최대온도설정 (-80℃ ~ 450℃) // default : 450
        public float fEquibTime;                           // 평형시간 (0~9999min / default = 1.0min)

        public byte bCryogenic;                            // 극저온 Cryogenic 사용여부(0:사용하지 않음 / 1:사용) 	// default : OFF
        public Coolants btCoolant;                             // 냉각재(0:Liquid N2 / 1:Liquid CO2) 	// default : OFF
        public byte bFastCryo;                             // Fast mode 설정(0:OFF / 1:ON) 	// default : OFF   -> 6500GC에서는 사용 안함
        public byte __bCryoTimeout;                        //  -> 6500GC에서는 사용 안함
        public byte __bCryoFault;                          //  -> 6500GC에서는 사용 안함

        public float fTempSet;                             // 설정온도(-80℃ ~ fMaxTemp) // default : 50	
        public byte bTempOnoff;                            // 히터 ON / OFF(0:OFF / 1 : ON) // default : OFF        
        public float fInitTime;                            // 초기유지시간(0~9999min / default = 10min)
        public OvenMode btMode;                                // 오븐작동모드(0:Iso-thermal(등온) / 1:Program Mode)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        public _OvenProgram[] Prgm;                         // [OVEN_PRGM_CNT]
                                                           // OVEN_PRGM_CNT = 25

        public byte bAutoReadyrun;                         // 준비상태 자동복원 (0:OFF / 1:ON) // default : ON
        public float fTotalRunTime;                        // - 총 분석시간 // 계산하여 표시
                                                           // Isothermal Mode : fInitTime // Programmed Mode : fInitTime + 
                                                           //enum { Off = 0, On };							//		((finalTemp(현재행) - finalTemp(이전행))/Rate(현재행)) + finalTime(현재행)
        public _RunStart Runstart;

        //CHROZEN_RUNSTART_FUNCTION_t Runstart;	
        // Run Start 정보 - 자동반복분석
        public _PostRun Postrun;

    }
}
