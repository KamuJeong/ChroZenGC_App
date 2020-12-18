using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public static class ChroZenService_Const
    {
        public enum E_SYSTEM_SUB_MENU_TYPE
        {
            CALIB_ROOT,
            CALIB_AUX_TEMP,
            CALIB_DET_FRONT,
            CALIB_DET_CENTER,
            CALIB_DET_REAR,
            CALIB_INLET_FRONT,
            CALIB_INLET_CENTER,
            CALIB_INLET_REAR,
            CALIB_OVEN,
            CALIB_UPC,
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
        public enum DET_TYPE
        {

        }
        public enum CARRIER_GAS_TYPE
        {
            N2,
            He,
            H2,
            Ar,
            ArCh4
        }

        public static float fDetMaxVal = 10000;
        public static int MinorTicksPerMajorTick = 5;
        public static double dMainPageEnabledSideInfoHeight = 257;
    }
}
