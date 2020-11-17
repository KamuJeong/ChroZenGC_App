using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_TIME_CTRL_SETTING
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public T_TIME_CONTROL_TYPE[] Prgm;             //[TIME_CTRL_PRGM_CNT] = 1
    }
    public static class T_TIME_CTRL_SETTINGManager
    {
        static T_TIME_CTRL_SETTINGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_TIME_CTRL_SETTING InitiatedInstance;

        static T_TIME_CTRL_SETTING GetInitializedInstance()
        {
            return new T_TIME_CTRL_SETTING
            {
                Prgm = new T_TIME_CONTROL_TYPE[]
                {
                    new T_TIME_CONTROL_TYPE()
                },
            };
        }
    }
}
