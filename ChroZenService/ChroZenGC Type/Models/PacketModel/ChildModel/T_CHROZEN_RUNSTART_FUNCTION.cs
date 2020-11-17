using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_RUNSTART_FUNCTION
    {
        public byte bOnoff;        // 자동반복분석(0:OFF / 1 : ON) 	// default : OFF
        public ushort iCount;      // 반복횟수(1~9999) // default : 1
        public float fCycletime; // 반복간격 (0~9999 min)
                                 // 총 분석시간 보다 크게 입력해야 함.
                                 // default : 10	
    }

    public static class T_CHROZEN_RUNSTART_FUNCTIONManager
    {
        static T_CHROZEN_RUNSTART_FUNCTIONManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_RUNSTART_FUNCTION InitiatedInstance;

        static T_CHROZEN_RUNSTART_FUNCTION GetInitializedInstance()
        {
            return new T_CHROZEN_RUNSTART_FUNCTION
            {
                iCount = 1,
                fCycletime = 10
            };
        }
    }
}
