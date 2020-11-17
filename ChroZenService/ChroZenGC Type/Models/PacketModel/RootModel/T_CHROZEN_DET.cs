using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_DET
    {
        public byte btPort;            // 설치위치(0:front / 1:center / 2:rear) 
        public byte btMakeupgas;        // Makeup Gas(0:N2 / 1 : He / 2 : H2 / 3 : Ar / 4 : ArCh4
                                        // - FID, NPD, FPD, PFPD, PDD 사용
        public float fLitoffset;                                               // default : 5	// Max 50
                                                                               // - FID, NPD, FPD, PFPD, 사용

        public float fIgnitedelay;                                             // FID 점화시도 지연시간
                                                                               // default : 0	// Max 9999 // - FID, NPD, FPD, PFPD, 사용

        public float fIgniteflow;                                              // FID 점화시도 Air유량 
                                                                               // default : 100	// Max 300  // - FID, NPD, FPD, PFPD, 사용

        public float fIgnitetemp;                                              // FID 점화시도 온도 // default : 198	// Max 450

        public byte btConnection;                                              // 연결된 Inlet 위치(0:front / 1 : center / 2 : rear)
        public byte bAutozero;                                                 // 시그널출력 자동영점 (0:Off / 1:On) // default : OFF
        public short iSignalrange;                                         // default : 0	// Max 10- TCD

        public float fTempSet;                                                 // 설정온도(0 ~ 450℃) // default : 50	// Max 450
        public byte bTempOnoff;                                                // 히터 동작 (0:OFF / 1:ON)

        public byte bElectrometer;                                         // Electrometer On/Off (0:Off / 1:On)
        public byte bAutoIgnition;                                         // FID 자동점화

        // 2020-05-04 jolee
        // 이경석 차장 요청 사항 : [float fSignal] 을 안쓰고 short int 타입 2개를 추가 해서 Struct 의 length 와 order 를 맞춤
        //float fSignal;                                                // State의 signal	// 사용안함?
        //public short nDummy0;
        //public short nSensitivity;                                      //
        public short iECDCurrentValue;                                     // ECD Current : 0~350
        public short iSignalvariation;                                     // default : 0 -> -10 ~ 10
                                                                           // ~

        public float fFlowSet1;                                                // 유량설정1
                                                                               // default : Air: 300(FID), 200(NPD) , Mkup,Sam :20, 
                                                                               // Reference(TCD)
                                                                               // Air2:40(FPD) 10(PFPD)
                                                                               // Max : Air,Air2 : 500, Mkup : 100

        public byte bFlowOnoff1;                                               // Flow1 On/Off (0:OFF / 1:ON) 			
        public float fFlowSet2;                                                // 유량설정2
                                                                               // default : Mkup: 30, Ref: 30, Air1:40(FPD) 10(PFPD)
                                                                               // Max 50 	
        public byte bFlowOnoff2;                                               // Flow2 On/Off (0:OFF / 1:ON)
        public float fFlowSet3;                                                //유량설정3
                                                                               // default : H2 : 30(FID), 140(FPD), 12(NPD), 11(PFPD)
                                                                               // Max 150

        public byte bFlowOnoff3;                                               // Flow3 On/Off (0:OFF / 1:ON)

        public byte bBaselineCorrect;                                         // not used - 삭제할까?

        public byte bPolarChange;                                              // TCD 극성변환 (0:OFF / 1:ON) // default : OFF
                                                                               //BYTE btCurPolarity;			                                    // 현재극성의상태
        public byte btInitPola;                                                // TCD 극성변환 사용시 초기값 (0:+ / 1:- ) // default : 0		
        public short iBeadVoltageSet;                                      // TCD 감도(0-9) // default : 0	// Sense로 화면 표시 	NPD Bead 전압(Volt)
        public byte iBeadVoltageOnoff;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public T_TCD_POLAR_PRGM[] Prgm;              //[TCD_POLA_PRGM_CNT]

        // NPD Bead Power On / Off(0:OFF / 1 : ON)

        public byte btBlockSelect;	                // default : 0	// Max 10 – TCD 블록의 종류
    }
    public static class T_CHROZEN_DETManager
    {
        static T_CHROZEN_DETManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_DET InitiatedInstance;

        static T_CHROZEN_DET GetInitializedInstance()
        {
            T_CHROZEN_DET Instnace = new T_CHROZEN_DET
            {
                Prgm = new T_TCD_POLAR_PRGM[6]
            };
            for (int i = 0; i < Instnace.Prgm.Length; i++)
            {
                Instnace.Prgm[i] = T_TCD_POLAR_PRGMManager.InitiatedInstance;
            }

            return Instnace;
        }
    }
}
