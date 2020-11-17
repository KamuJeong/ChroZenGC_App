using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_AUXAPC_SETTING
    {
        public byte btPort;                                        // 설치 위치 (0 ~ 2)
        public T_LCD_AUXAPC_SETTING lcdAuxApc;
    }
    public static class T_CHROZEN_AUXAPC_SETTINGManager
    {
        static T_CHROZEN_AUXAPC_SETTINGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_AUXAPC_SETTING InitiatedInstance;

        static T_CHROZEN_AUXAPC_SETTING GetInitializedInstance()
        {
            return new T_CHROZEN_AUXAPC_SETTING
            {
                lcdAuxApc = T_LCD_AUXAPC_SETTINGManager.InitiatedInstance

            };
        }
    }
}
