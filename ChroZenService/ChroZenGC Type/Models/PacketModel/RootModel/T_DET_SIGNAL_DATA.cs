using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_DET_SIGNAL_DATA
    {
        public byte no;        // 0 / 1			// 0 or 1 	
        public byte btStartNo; // 50:none			// 50개 데이터 중 Start 가 실행된 시점	 (분석 시작 신호를 받았을 시에 0 값을 갖는다, 아닐시에는 50)
        public byte btStopNo;                      // 50개 데이터 중 Stop 명령이 실행된 시점	
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btSigChgNo;                 // 50개 데이터 중 Signal Change가 된 시점,     [3]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] btPolaChgNo;                // 50개 데이터 중 TCD Polarity Change가 된 시점,       [3]

        public T_CHROZEN_GC_SIGNAL sigData;       // 시그널 데이터
    }
    public static class T_DET_SIGNAL_DATAManager
    {
        static T_DET_SIGNAL_DATAManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_DET_SIGNAL_DATA InitiatedInstance;

        static T_DET_SIGNAL_DATA GetInitializedInstance()
        {
            return new T_DET_SIGNAL_DATA
            {
                btSigChgNo = new byte[3],
                btPolaChgNo = new byte[3],
                sigData = T_CHROZEN_GC_SIGNALManager.InitiatedInstance
            };
        }
    }
}
