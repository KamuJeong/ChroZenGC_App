using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_SPECIAL_FUNCTION
    {
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public T_CHROZEN_COLUMN_CONDITION_FUNCTION Colclean; //4
        public T_REMOTE_ACCESS_FUNCTION Remote;
    }
    public static class T_CHROZEN_SPECIAL_FUNCTIONManager
    {
        static T_CHROZEN_SPECIAL_FUNCTIONManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_SPECIAL_FUNCTION InitiatedInstance;

        static T_CHROZEN_SPECIAL_FUNCTION GetInitializedInstance()
        {
            return new T_CHROZEN_SPECIAL_FUNCTION
            {
                Colclean = new T_CHROZEN_COLUMN_CONDITION_FUNCTION(),
                //[]
                //{
                //   T_CHROZEN_COLUMN_CONDITION_FUNCTIONManager.InitiatedInstance,
                //   T_CHROZEN_COLUMN_CONDITION_FUNCTIONManager.InitiatedInstance,
                //   T_CHROZEN_COLUMN_CONDITION_FUNCTIONManager.InitiatedInstance,
                //   T_CHROZEN_COLUMN_CONDITION_FUNCTIONManager.InitiatedInstance,
                //},
                Remote = T_REMOTE_ACCESS_FUNCTIONManager.InitiatedInstance
            };
        }
    }
}
