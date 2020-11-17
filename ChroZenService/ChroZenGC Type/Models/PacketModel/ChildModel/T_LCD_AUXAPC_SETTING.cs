using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_LCD_AUXAPC_SETTING
    {
        public byte btAuxGas;                                  //가스종류 (0:N2 / 1:He / 2:H2 / 3:Ar / 4:ArCh4) // default : (N2)

        public float fFlowSet1;                                // 유량설정1 (0 ~ 150ml/min) // default : 20
        public bool fFlowOnoff1;                               // Flow1 On / Off(0:OFF / 1 : ON)
        public float fFlowSet2;                                // 유량설정2 (0 ~ 150ml/min) // default : 20
        public bool fFlowOnoff2;                               // Flow2 On / Off(0:OFF / 1 : ON)
        public float fFlowSet3;                                // 유량설정3 (0 ~ 150ml/min) // default : 20
        public bool fFlowOnoff3;								// Flow3 On/Off (0:OFF / 1:ON)
    }
    public static class T_LCD_AUXAPC_SETTINGManager
    {
        static T_LCD_AUXAPC_SETTINGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_LCD_AUXAPC_SETTING InitiatedInstance;

        static T_LCD_AUXAPC_SETTING GetInitializedInstance()
        {
            return new T_LCD_AUXAPC_SETTING
            {

            };
        }
    }
}
