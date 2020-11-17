using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_DET_SIGNAL_SETTING
    {
        //btPort = 0;
        //fValue = 0.0f;
        //fSensitivity = 0.0f;
        //fZero = 0.0f;

        //bSignalChange = FALSE;
        //__btBaselineCorrect = 0;
        //btInitDet = 0;

        public byte btPort;                                        // 검출기 설치 위치 (0:front / 1:center / 2:rear)
        public float fValue;
        public float fSensitivity;
        public float fZero;

        public byte bSignalChange;                             //신호변환
        public byte __btBaselineCorrect;
        public byte btInitDet;                                 //초기 시그널 출력 검출기

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public T_SIGNAL_PRGM[] Prgm;                     // [SIGNAL_PRGM_COUNT]

    }
    public static class T_DET_SIGNAL_SETTINGManager
    {
        static T_DET_SIGNAL_SETTINGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_DET_SIGNAL_SETTING InitiatedInstance;

        static T_DET_SIGNAL_SETTING GetInitializedInstance()
        {
            return new T_DET_SIGNAL_SETTING
            {
                Prgm = new T_SIGNAL_PRGM[]
                {
                    T_SIGNAL_PRGMManager.InitiatedInstance,
                    T_SIGNAL_PRGMManager.InitiatedInstance,
                    T_SIGNAL_PRGMManager.InitiatedInstance,
                    T_SIGNAL_PRGMManager.InitiatedInstance,
                    T_SIGNAL_PRGMManager.InitiatedInstance,
                }
            };
        }
    }
}
