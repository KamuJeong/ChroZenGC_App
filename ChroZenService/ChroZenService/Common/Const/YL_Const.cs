using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public static class ChroZenService_Const
    {
        #region ENUM        

        public enum E_UPC_INDEX
        {
            UPC1,
            UPC2,
            UPC3
        }
        public enum E_AUXTEMP_INDEX
        {
            AUXTEMP1,
            AUXTEMP2
        }
        public enum E_INLET_LOCATION
        {
            FRONT,
            CENTER,
            REAR
        }
        public enum E_DET_LOCATION
        {
            FRONT,
            CENTER,
            REAR
        }
        public enum E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE
        {
            TEMP_CALIBRATION_T1,
            TEMP_CALIBRATION_T2,
        }

        public enum E_SYSTEM_CALIBRATION_INLET_SET_MEASURE_COMMAND_TYPE
        {
            TEMP_CALIBRATION_T1,
            TEMP_CALIBRATION_T2,
            FLOW_CALIBRATION1,
            FLOW_CALIBRATION2,
            FLOW_CALIBRATION3,
        }

        public enum E_SYSTEM_CALIBRATION_INLET_CONTROL_COMMAND_TYPE
        {
            TEMP_CALIBRATION,
            SENSOR_ZERO,
            VALVE,
            FLOW,
        }

        public enum E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE
        {
            TEMP_CALIBRATION_T1,
            TEMP_CALIBRATION_T2,
            FLOW_CALIBRATION1,
            FLOW_CALIBRATION2,
            FLOW_CALIBRATION3,
        }

        public enum E_SYSTEM_CALIBRATION_DET_CONTROL_COMMAND_TYPE
        {
            TEMP_CALIBRATION,
            SENSOR_ZERO,
            VALVE,
            FLOW,
        }

        public enum E_SYSTEM_CALIBRATION_AUX_UPC_CONTROL_COMMAND_TYPE
        {
            SENSOR_ZERO,
            VALVE,
            FLOW,
        }

        public enum E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE
        {
            TEMP_CALIBRATION1_T1,
            TEMP_CALIBRATION1_T2,
            TEMP_CALIBRATION2_T1,
            TEMP_CALIBRATION2_T2,
            TEMP_CALIBRATION3_T1,
            TEMP_CALIBRATION3_T2,
            TEMP_CALIBRATION4_T1,
            TEMP_CALIBRATION4_T2,
        }

        public enum E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE
        {
            TEMP_CALIBRATION1,
            TEMP_CALIBRATION2,
            TEMP_CALIBRATION3,
            TEMP_CALIBRATION4,
        }

        public enum E_SYSTEM_SUB_MENU_TYPE
        {
            CALIB_ROOT,
            CALIB_AUX_TEMP1,
            CALIB_AUX_TEMP2,
            CALIB_DET_FRONT,
            CALIB_DET_CENTER,
            CALIB_DET_REAR,
            CALIB_INLET_FRONT,
            CALIB_INLET_CENTER,
            CALIB_INLET_REAR,
            CALIB_OVEN,
            CALIB_UPC1,
            CALIB_UPC2,
            CALIB_UPC3,
            CONFIG_ROOT,
            DIAG_ROOT,
            DIAG_HEATER,
            DIAG_IGNITOR_VALVE,
            DIAG_POWER_MONITOR,
            DIAG_REMOTE_SIGNAL,
            DIAG_UPC_SENSOR_CHECK,
            DIAG_UPC_VALVE_CHECK,
            INFO_ROOT,
            METHOD_ROOT,
            SETTINGS_ROOT,
            TIME_CONTROL_ROOT,
        }

        public enum E_SYSTEM_MENU_TYPE
        {
            INFORMATION,
            CONFIG,
            SETTINGS,
            DIAGNOSTICS,
            CALIBRATION,
            TIMECONTROL,
            METHOD
        }

        public enum E_CONFIG_MENU_TYPE
        {
            OVEN,
            FRONT_INLET,
            CENTER_INLET,
            REAR_INLET,
            FRONT_DET,
            CENTER_DET,
            REAR_DET,
            SIGNAL,
            VALVE,
            AUX
        }

        public enum E_CONFIG_SUB_MENU_TYPE
        {
            OVEN_CONFIG,
            OVEN_SETTING,
            FRONT_INLET_CONFIG,
            FRONT_INLET_SETTING,
            CENTER_INLET_CONFIG,
            CENTER_INLET_SETTING,
            REAR_INLET_CONFIG,
            REAR_INLET_SETTING,
            FRONT_DET_CONFIG,
            FRONT_DET_SETTING,
            CENTER_DET_CONFIG,
            CENTER_DET_SETTING,
            REAR_DET_CONFIG,
            REAR_DET_SETTING,
            SIGNAL1,
            SIGNAL2,
            SIGNAL3,
            VALVE_INIT_STATE,
            VALVE_PROGRAM,
            AUX_TEMPERATURE,
            AUX_FLOW
        }

        public enum CHART_DELTA_TYPE
        {
            CHART_DELTA,
            AXIS_DELTA
        }

        public enum CHART_AXIS_TYPE
        {
            Y_SIGNAL,
            Y_TEMPERATURE,
        }

        public enum MAIN_SIDE_BUTTON_TYPE
        {
            INLET,
            DET
        }
        public enum MAIN_SIDE_ELEMENT_TYPE
        {
            TOP,
            CENTER,
            BOTTOM
        }
        public enum APC_MODE
        {
            Const_Flow,
            Const_Press,
            Prog_Flow,
            Prog_Press
        }

        public enum CARRIER_GAS_TYPE
        {
            N2,
            He,
            H2,
            Ar,
            ArCh4
        }

        #endregion ENUM

        #region Const Value
        public static int METHOD_PROGRAM_CNT = 20;
        public static int TIME_CONTROL_PROGRAM_CNT = 20;
        public static int AUX_APC_CNT = 3;
        public static int INLET_CNT = 3;
        public static int DET_CNT = 3;
        public static int AUX_CNT = 8;
        public static int VALVE_PROGRAM_CNT = 20;
        public static int SYSTEM_VALVE_CNT = 8;
        public static int SYSTEM_MULTI_VALVE_CNT = 2;
        public static int SIGNAL_PRGM_CNT = 5;
        public static int OVEN_PRGM_CNT = 25;

        public static float fDetMaxVal = 10000;
        public static int MinorTicksPerMajorTick = 5;
        public static double dMainPageEnabledSideInfoHeight = 257;

        #endregion Const Value
    }
}
