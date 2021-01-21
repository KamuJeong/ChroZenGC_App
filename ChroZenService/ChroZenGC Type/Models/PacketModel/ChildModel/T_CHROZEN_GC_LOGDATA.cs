using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_LOGDATA
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool bUseLogging;
    }

    public static class T_CHROZEN_GC_LOGDATAManager
    {
        static T_CHROZEN_GC_LOGDATAManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_LOGDATA InitiatedInstance;

        static T_CHROZEN_GC_LOGDATA GetInitializedInstance()
        {
            return new T_CHROZEN_GC_LOGDATA
            {
               
            };
        }
    }
}
