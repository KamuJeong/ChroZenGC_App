using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_SYSTEM_TIME
    {
       public ushort wYear;
       public ushort wMonth;
       public ushort wDayOfWeek;
       public ushort wDay;
       public ushort wHour;
       public ushort wMinute;
       public ushort wSecond;
       public ushort wMilliseconds;
    }
    public static class T_SYSTEM_TIMEManager
    {
        static T_SYSTEM_TIMEManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_SYSTEM_TIME InitiatedInstance;

        static T_SYSTEM_TIME GetInitializedInstance()
        {
            return new T_SYSTEM_TIME
            {

            };
        }
    }
}
