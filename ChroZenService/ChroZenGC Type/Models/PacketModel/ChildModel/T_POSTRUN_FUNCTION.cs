using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_POSTRUN_FUNCTION
    {
       public byte bOnoff;                // 후처리기능 (0:OFF / 1:ON)
       public float fTemp;                // 후처리온도
       public float fTime;                // 후처리 유지 시간 (0~9999min)  
    }
    public static class T_POSTRUN_FUNCTIONManager
    {
        static T_POSTRUN_FUNCTIONManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_POSTRUN_FUNCTION InitiatedInstance;

        static T_POSTRUN_FUNCTION GetInitializedInstance()
        {
            return new T_POSTRUN_FUNCTION
            {

            };
        }
    }
}
