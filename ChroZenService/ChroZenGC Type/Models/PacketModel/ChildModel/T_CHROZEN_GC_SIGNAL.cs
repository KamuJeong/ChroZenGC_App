using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_SIGNAL
    {
        public uint nIndex;                // 전송시 마다 1씩 증가
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 150)]
        public float[] fSignal;               // 시그널1,2,3의 50Hz 데이터 , [3][50]
                                              // - 50Hz의 데이터를 1초에 10회 전송함. (1초에 총 500Hz 수신 -> 1회당 50Hz데이터가 전송됨.)

    }
    public static class T_CHROZEN_GC_SIGNALManager
    {
        static T_CHROZEN_GC_SIGNALManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_SIGNAL InitiatedInstance;

        static T_CHROZEN_GC_SIGNAL GetInitializedInstance()
        {
            return new T_CHROZEN_GC_SIGNAL
            {
                fSignal = new float[150]
            };
        }
    }
}
