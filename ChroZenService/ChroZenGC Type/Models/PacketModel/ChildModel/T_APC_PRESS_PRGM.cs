using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_APC_PRESS_PRGM
    {
        public float fRate;                // 압력변화율(psi/min)
        public float fFinalPress;      // 설정(목표)압력(psi/min)	
        public float fFinalTime;         // 설정압력 유지시간(min)
    }
    public static class T_APC_PRESS_PRGMManager
    {
        static T_APC_PRESS_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_APC_PRESS_PRGM InitiatedInstance;

        static T_APC_PRESS_PRGM GetInitializedInstance()
        {
            return new T_APC_PRESS_PRGM
            {

            };
        }
    }
}
