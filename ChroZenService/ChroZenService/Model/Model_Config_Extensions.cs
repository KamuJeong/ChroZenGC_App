using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public static class Model_Config_Extensions
    {
        public static void SendCommand(this Model_Config model, E_GLOBAL_COMMAND_TYPE e_GLOBAL_COMMAND_TYPE, TCPManager tCPManager)
        {
            switch (e_GLOBAL_COMMAND_TYPE)
            {
                #region Oven

                #region Oven Config

                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_LABEL_MAX:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_LABEL_EQUILIBRIUM:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_CRYOGENIC_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_CRYOGENIC_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_FAST_COOLING_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_FAST_COOLING_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_AUTO_READY_RUN_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_AUTO_READY_RUN_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_RUN_START_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_RUN_START_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_OFF:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_NO_OF_RUN:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_CYCLE:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_TEMP:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_POSTRUN_TIME:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_PROGRAM_ON:
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_PROGRAM_OFF:
                    {
                        tCPManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                    }
                    break;

                    #endregion Oven Config

                    #region Oven Setting


                    #endregion Oven Setting

                    #endregion Oven

                    #region Signal

                    #region Signal 1

                    

                    #endregion Signal 1

                    #region Signal 2



                    #endregion Signal 2

                    #region Signal 3



                    #endregion Signal 3

                    #endregion Signal
            }

            Debug.WriteLine(string.Format("{0} Fired", e_GLOBAL_COMMAND_TYPE.ToString()));
        }
    }
}
