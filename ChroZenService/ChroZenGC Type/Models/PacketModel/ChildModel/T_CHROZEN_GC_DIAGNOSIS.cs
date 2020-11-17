using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_DIAGNOSIS
    {
        public byte btLeakTest;
        public byte btHeaterTest;
        public byte btSensorTest;
        public byte btBoardTest;
        public bool bReset;
        public bool bCalibReset;
    }
    public static class T_CHROZEN_GC_DIAGNOSISManager
    {
        static T_CHROZEN_GC_DIAGNOSISManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_DIAGNOSIS InitiatedInstance;

        static T_CHROZEN_GC_DIAGNOSIS GetInitializedInstance()
        {
            return new T_CHROZEN_GC_DIAGNOSIS
            {

            };
        }
    }
}
