using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public static class Model_System_Calibration_Extensions
    {
        public static void SendCommand(this Model_System_Calibration model, E_GLOBAL_COMMAND_TYPE e_GLOBAL_COMMAND_TYPE, TCPManager tCPManager)
        {
            switch (e_GLOBAL_COMMAND_TYPE)
            {
                #region Oven
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_CRYOGENIC_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_CRYOGENIC_OFF:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 0
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_FAST_COOLING_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_FAST_COOLING_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_AUTO_READY_RUN_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_AUTO_READY_RUN_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_RUN_START_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_RUN_START_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_LABEL_MAX:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_LABEL_EQUILIBRIUM:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_NO_OF_RUN:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_CYCLE:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_TEMP:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_TIME:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 0
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                #endregion Oven

                #region Oven
                case E_GLOBAL_COMMAND_TYPE.E_OVEN_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 0
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_OVEN_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 0
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                #endregion Oven

                #region INLET

                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_TEMP_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_TEMP_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_SENSORZERO_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_VALVE_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_VALVE_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_VALVE_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_VALVE_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_FLOW_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 4,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_FLOW_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_FLOW_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_FRONT_FLOW_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 1
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 0));

                    }
                    break;

                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_TEMP_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_TEMP_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET2.inletPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_SENSORZERO_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_VALVE_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_VALVE_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_VALVE_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_VALVE_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_FLOW_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 4,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_FLOW_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_FLOW_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_CENTER_FLOW_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 2
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 1));

                    }
                    break;

                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_TEMP_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_TEMP_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET3.inletPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_SENSORZERO_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_VALVE_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_VALVE_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_VALVE_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_VALVE_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_FLOW_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 4,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_FLOW_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_FLOW_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_INLET_REAR_FLOW_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 3
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket, 2));

                    }
                    break;

                #endregion INLET

                #region DET

                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_TEMP_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_TEMP_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_SENSORZERO_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_VALVE_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_VALVE_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_VALVE_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_VALVE_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_FLOW_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_FLOW_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_FLOW_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_FRONT_FLOW_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 4
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1.detPacket, 0));

                    }
                    break;

                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_TEMP_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_TEMP_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_SENSORZERO_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_VALVE_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_VALVE_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_VALVE_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_VALVE_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_FLOW_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_FLOW_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_FLOW_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_CENTER_FLOW_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 5
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2.detPacket, 1));

                    }
                    break;

                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_TEMP_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_TEMP_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_SENSORZERO_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_VALVE_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_VALVE_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_VALVE_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_VALVE_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_FLOW_RESET:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_FLOW_START:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                       tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_FLOW_STOP:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_DET_REAR_FLOW_APPLY:
                    {
                        T_LCD_COMMAND lcdCommand = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 6
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(lcdCommand, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3.detPacket, 2));

                    }
                    break;

                #endregion DET

                #region AUX UPC
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_START:
                    {
                        //2021-01-12 : Start 클릭 시 다른 Start 버튼의 상태를 Stop으로 전환

                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_START:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 7
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 4,
                            Target_Set = 7
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_START:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 7
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 7
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 7
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                    }
                    break;

                case E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_START:
                    {
                        //2021-01-12 : Start 클릭 시 다른 Start 버튼의 상태를 Stop으로 전환

                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_START:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 8
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 4,
                            Target_Set = 8
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_START:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 8
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 8
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 8
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 2,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        //tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_START:
                    {
                        //2021-01-12 : Start 클릭 시 다른 Start 버튼의 상태를 Stop으로 전환

                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 2,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 2,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 2,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 3,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_START:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 3,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 3,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 3,
                            Target_Set = 9
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 4,
                            Target_Set = 9
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_START:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 1,
                            Function_No = 4,
                            Target_Set = 9
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_STOP:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 0,
                            Function_No = 4,
                            Target_Set = 9
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 4,
                            Target_Set = 9
                        };

                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                    }
                    break;

                #endregion AUX UPC

                #region AUX TEMP
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP1_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 10
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP1_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 10
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP2_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 11
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP2_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 11
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP3_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 12
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP3_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 12
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP4_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 13
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP4_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 13
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP5_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 14
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP5_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 14
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP6_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 15
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP6_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 15
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP7_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 16
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP7_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 16
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP8_TEMP_RESET:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 3,
                            Function_No = 1,
                            Target_Set = 17
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_AUXTEMP8_TEMP_APPLY:
                    {
                        T_LCD_COMMAND command = new T_LCD_COMMAND
                        {
                            Command = 8,
                            Action = 2,
                            Function_No = 1,
                            Target_Set = 17
                        };
                        tCPManager.Send(T_PACKCODE_LCD_COMMANDManager.MakePACKCODE_SET(command, YC_Const.E_PACKCODE.PACKCODE_YL6200_COMMAND));
                        tCPManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP.tempPacket, YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                    }
                    break;
                    #endregion AUX TEMP

            }

            Debug.WriteLine(string.Format("{0} Fired", e_GLOBAL_COMMAND_TYPE.ToString()));
        }
    }
    
}
