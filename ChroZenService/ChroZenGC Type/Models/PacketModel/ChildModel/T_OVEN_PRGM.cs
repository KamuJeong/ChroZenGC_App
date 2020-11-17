using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_OVEN_PRGM
    {
        public float fRate;            // 분당승온(하강)비율(0~℃/min) 	// 승온속도 [0 - 100]
        public float fFinalTemp;       // 프로그램 모드에서 설정(목표)온도
                                       // 첫번째(0번 배열)은 다른 프로그램들과 달리 오븐 프로그램의 첫번째이다. - 다른 프로그램(Inlet 등)은 첫번째가 초기값임.

        public float fFinalTime;       // 설정(목표)온도 유지시간(분)
    }
    public static class T_OVEN_PRGMManager
    {
        static T_OVEN_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_OVEN_PRGM InitiatedInstance;

        static T_OVEN_PRGM GetInitializedInstance()
        {
            return new T_OVEN_PRGM
            {

            };
        }
    }
}
