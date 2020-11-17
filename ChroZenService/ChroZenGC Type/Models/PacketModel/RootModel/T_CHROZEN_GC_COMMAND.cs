using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_COMMAND
    {
        public byte btCommand;                                 // 실행명령
                                                               // (0: None / 1 : Start / 2 : Stop / 3 : Ready Run)
                                                               //	4: Column Condition
                                                               //	(10: GC_Command_PowerSaveMode /
                                                               //	55 : GC_Command_WakeUp)
                                                               //enum { None = 0, Start, Stop, ReadyRun, ColumnCondition, Shutdown, StartUp, Diagnostics, Method, Calibration, StandbyMode };
                                                               //enum { None = 0, Start, Stop, ReadyRun, ColumnCondition, GC_Command_PowerSaveMode = 10, GC_Command_Wakeup = 55 };


        public byte btSubCommand1;                             // 명령 옵션1
                                                               //	enum { Leak = 1, Board, Heater, Sensor, All, Reset };
        public byte btSubCommand2;                             // 명령 옵션1
                                                               //YL6200GC_COMMAND_t()						// 6500 GC 
                                                               //{
                                                               //	memset(this, 0, sizeof(YL6200GC_COMMAND_t));
                                                               //}
    }
    public static class T_CHROZEN_GC_COMMANDManager
    {
        static T_CHROZEN_GC_COMMANDManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_COMMAND InitiatedInstance;

        static T_CHROZEN_GC_COMMAND GetInitializedInstance()
        {
            return new T_CHROZEN_GC_COMMAND
            {

            };
        }
    }
}
