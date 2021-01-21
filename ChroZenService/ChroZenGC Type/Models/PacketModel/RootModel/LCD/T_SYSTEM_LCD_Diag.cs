using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_SYSTEM_LCD_Diag
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool bStartStop; // default : stop	// Stop : 0, Start : 1
        public byte btFunc; // default : 0	
                            // 0:Heater, 1: Ignitor & Valve, 2: Remot & Signal, 3: APCvalve,
                            // 4: APCsensor, 5: Powermonitor
    }
    public static class T_SYSTEM_LCD_DiagManager
    {
        static T_SYSTEM_LCD_DiagManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_SYSTEM_LCD_Diag InitiatedInstance;

        static T_SYSTEM_LCD_Diag GetInitializedInstance()
        {
            return new T_SYSTEM_LCD_Diag
            {

            };
        }
    }
}
