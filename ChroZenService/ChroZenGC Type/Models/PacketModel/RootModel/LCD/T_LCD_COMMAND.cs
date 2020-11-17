using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_LCD_COMMAND
    {
        public byte Command;
        // 0: None
        // 1: Start
        // 2: Stop (Start 등 아래의 모든 명령을 중지 시킴)
        // 3: Ready Run
        // 4: Column Condition	- XXX사용안함.
        // 5: Shutdown	
        // 6: Start up	
        // 7: Diagnostics
        // 8: Calibration
        // 9: Method (1: Load / 2: Save) (Method No)
        // 10: PowerSave Mode

        public byte Action;
        //Command가 <Calibration>인 경우
        // Calib_Stop		0
        // Calib_Start		1
        // Calib_Apply	    2
        // Calib_Reset	    3

        //< Diagnostics>
        // default : stop	// Stop : 0, Start : 1

        // <Method>
        // (1: Load / 2: Save)

        public byte Function_No;
        // <Calibration>
        // Calib_none	    0
        // Calib_temp	    1
        // Calib_SenZero    2
        // Calib_Valve	    3
        // Calib_Flow	    4
        // PRESS_CALIB	    5
        // SIGNAL_CALIB	    6

        // < Diagnostics>
        // 0:Heater, 1: Ignitor & Valve, 2: Remot & Signal, 
        // 3: APCvalve, 4: APCsensor, 5: Powermonitor

        // <Method>
        // 1~20 : Method No

        public byte Target_Set;
        //<Calibration>
        // 0: Oven 1:InletF 2:InletC 3:InletR 
        // 4:DetF 5:DetC 6:DetR 
        // 7:Aux_APC1 8:Aux_APC2 9:Aux_APC3
        // 10:Aux1 11:Aux2 12:Aux3 13:Aux4
        // 14:Aux5 15:Aux6 16:Aux7 17:Aux8
        // 18:Signal1 19:Signal2 20:Signal3
    }

    public static class T_LCD_COMMANDManager
    {
        static T_LCD_COMMANDManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_LCD_COMMAND InitiatedInstance;

        static T_LCD_COMMAND GetInitializedInstance()
        {
            return new T_LCD_COMMAND
            {
               
            };
        }
    }
}
