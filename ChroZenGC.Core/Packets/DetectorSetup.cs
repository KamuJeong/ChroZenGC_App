using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum InitPolarity : byte
    {
        Positive, Negative
    }

    public enum Polarity : byte
    {
        Positive, Negative, Delete
    }

    public enum DetectorConnection : byte
    {
        FrontInlet, CenterInlet, RearInlet
    }

    public struct _TCDPolarityProgram
    {
        public float fTime;            // 극성변환시간
        public Polarity btPolarity;    // 극성
    }


    public struct DetectorSetup
    {
        public byte btPort;            // 설치위치(0:front / 1:center / 2:rear) 
        public GasTypes btMakeupgas;   // Makeup Gas(0:N2 / 1 : He / 2 : H2 / 3 : Ar / 4 : ArCh4
                                       // - FID, NPD, FPD, PFPD, PDD 사용
        public float fLitoffset;                                               // default : 5	// Max 50
                                                                               // - FID, NPD, FPD, PFPD, 사용

        public float fIgnitedelay;                                             // FID 점화시도 지연시간
                                                                               // default : 0	// Max 9999 // - FID, NPD, FPD, PFPD, 사용

        public float fIgniteflow;                                              // FID 점화시도 Air유량 
                                                                               // default : 100	// Max 300  // - FID, NPD, FPD, PFPD, 사용

        public float fIgnitetemp;                                              // FID 점화시도 온도 // default : 198	// Max 450

        public DetectorConnection btConnection;                                              // 연결된 Inlet 위치(0:front / 1 : center / 2 : rear)
        public byte bAutozero;                                                 // 시그널출력 자동영점 (0:Off / 1:On) // default : OFF
        public short iSignalrange;                                         // default : 0	// Max 10- TCD

        public float fTempSet;                                                 // 설정온도(0 ~ 450℃) // default : 50	// Max 450
        public byte bTempOnoff;                                                // 히터 동작 (0:OFF / 1:ON)

        public byte bElectrometer;                                         // Electrometer On/Off (0:Off / 1:On)
        public byte bAutoIgnition;                                         // FID 자동점화
                                     //
        public short iECDCurrentValue;                                     // ECD Current : 0~350
        public short iSignalvariation;                                     // default : 0 -> -10 ~ 10 (Sensitivity on DetConfig)
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
        public InitPolarity btInitPola;                                                // TCD 극성변환 사용시 초기값 (0:+ / 1:- ) // default : 0		
        public short iBeadVoltageSet;                                      // TCD 감도(0-9) // default : 0	// Sense로 화면 표시 	NPD Bead 전압(Volt)
        public byte iBeadVoltageOnoff;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public _TCDPolarityProgram[] Prgm;              //[TCD_POLA_PRGM_CNT]

        // NPD Bead Power On / Off(0:OFF / 1 : ON)

        public byte btBlockSelect;	                // default : 0	// Max 10 – TCD 블록의 종류
    }

}
