using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_LOGDATA
    {
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
