using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public static class Model_System_Diagnostics_Extensions
    {
        public static void StartCommand(this Model_System_Diagnostics model, E_SYSTEM_DIAG_COMMAND_TYPE e_SYSTEM_DIAG_COMMAND_TYPE, TCPManager tCPManager)
        {
            switch (e_SYSTEM_DIAG_COMMAND_TYPE)
            {
                case E_SYSTEM_DIAG_COMMAND_TYPE.START_HEATER:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = true;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 0;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.STOP_HEATER:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = false;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 0;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.START_IGNITOR_VALVE:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = true;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 1;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.STOP_IGNITOR_VALVE:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = false;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 1;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.START_REMOTE_SIGNAL:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = true;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 2;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.STOP_REMOTE_SIGNAL:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = false;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 2;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.START_UPC_VALVE_CHECK:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = true;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 3;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.STOP_UPC_VALVE_CHECK:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = false;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 3;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.START_UPC_SENSOR_CHECK:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = true;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 4;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.STOP_UPC_SENSOR_CHECK:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = false;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 4;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.START_POWER_MONITOR:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = true;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 5;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
                case E_SYSTEM_DIAG_COMMAND_TYPE.STOP_POWER_MONITOR:
                    {
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.bStartStop = false;
                        DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet.btFunc = 5;
                        tCPManager.Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                    }
                    break;
            }
        }
    }
}
