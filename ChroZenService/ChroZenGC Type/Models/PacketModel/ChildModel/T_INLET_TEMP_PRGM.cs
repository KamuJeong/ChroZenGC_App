using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_INLET_TEMP_PRGM
    {
        public float fRate;                // 분당승온(하강)비율(0~100℃/min)
        public float fFinalTemp;           // 프로그램 모드에서 설정(목표)온도
        public float fFinalTime;           // 설정(목표)온도 유지시간(분)
    }
    public static class T_INLET_TEMP_PRGMManager
    {
        static T_INLET_TEMP_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_INLET_TEMP_PRGM InitiatedInstance;

        static T_INLET_TEMP_PRGM GetInitializedInstance()
        {
            return new T_INLET_TEMP_PRGM
            {

            };
        }
    }
}
