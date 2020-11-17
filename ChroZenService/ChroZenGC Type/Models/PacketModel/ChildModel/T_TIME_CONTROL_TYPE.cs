using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_TIME_CONTROL_TYPE
    {
        public byte bDaily;
        public T_SYSTEM_TIME SysTime;
        public byte btFunction;
        public byte btPortNo;
        public float fValue;
    }
    public static class T_TIME_CONTROL_TYPEManager
    {
        static T_TIME_CONTROL_TYPEManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_TIME_CONTROL_TYPE InitiatedInstance;

        static T_TIME_CONTROL_TYPE GetInitializedInstance()
        {
            return new T_TIME_CONTROL_TYPE
            {

            };
        }
    }
}
