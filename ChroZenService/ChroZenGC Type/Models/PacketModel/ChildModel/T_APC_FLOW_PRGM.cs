using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_APC_FLOW_PRGM
    {
       public float fRate;                // 유량변화율(ml/min/min)
       public float fFinalFlow;           // 설정(목표)유량(ml/min)
       public float fFinalTime;           // 설정유량 유지시간(min)
    }
    public static class T_APC_FLOW_PRGMManager
    {
        static T_APC_FLOW_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_APC_FLOW_PRGM InitiatedInstance;

        static T_APC_FLOW_PRGM GetInitializedInstance()
        {
            return new T_APC_FLOW_PRGM
            {

            };
        }
    }
}
