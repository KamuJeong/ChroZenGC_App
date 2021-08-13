using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum InitSignalDetectors : byte
    {
        FrontDetector, CenterDetector, RearDetector
    }

    public enum SignalDetectors : byte
    {
        FrontDetector, CenterDetector, RearDetector, Delete
    }

    public struct _SignalProgram
    {
        public float fTime;
        public SignalDetectors btDet;                                 // Detector (0:front / 1:center / 2:rear)
                                                           // 프로그램 의 마지막은 btDet = 3;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SignalSetup
    {
        public byte btPort;                                        // 검출기 설치 위치 (0:front / 1:center / 2:rear)
        public float fValue;
        public float fSensitivity;
        public float fZero;

        public byte bSignalChange;                             //신호변환
        public byte __btBaselineCorrect;
        public InitSignalDetectors btInitDet;                                 //초기 시그널 출력 검출기

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public _SignalProgram[] Prgm;                     // [SIGNAL_PRGM_COUNT]
    }
}
