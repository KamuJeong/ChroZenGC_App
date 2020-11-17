using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_SYSTEM_INFORM
    {
        public T_SYSTEM_CONFIG SysConfig;
        public T_INST_INFORM InstInfo;
    }
    public static class T_CHROZEN_GC_SYSTEM_INFORMManager
    {
        static T_CHROZEN_GC_SYSTEM_INFORMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_SYSTEM_INFORM InitiatedInstance;

        static T_CHROZEN_GC_SYSTEM_INFORM GetInitializedInstance()
        {
            return new T_CHROZEN_GC_SYSTEM_INFORM
            {
                SysConfig = T_SYSTEM_CONFIGManager.InitiatedInstance,
                InstInfo = T_INST_INFORMManager.InitiatedInstance
            };
        }
    }
}
