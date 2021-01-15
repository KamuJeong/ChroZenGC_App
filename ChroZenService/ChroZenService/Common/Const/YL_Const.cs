using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public static class ChroZenService_Const
    {
        #region ENUM    

        public enum E_DIAGNOSTICS_TYPE
        {
            ROOT,
            HEATER,
            IGNITOR_VALVE,
            REMOTE_SIGNAL,
            UPC_VALVE_CHECK,
            UPC_SENSOR_CHECK,
            POWER_MONITOR
        }

        public enum E_SYSTEM_SETTING_INPUT_TYPE
        {
            INIT_TEMP,
            INIT_TIME,
            RATE,
            FINAL_TEMP,
            FINAL_TIME,
            REMOTE_TIME,
            REMOTE_EVENT1,
            REMOTE_EVENT2,
            INSTALL_DATE,
            DATE,
            TIME
        }

        public enum E_SYSTEM_COFIG_VALVE_TYPE
        {
            VALVE1,
            VALVE2,
            VALVE3,
            VALVE4,
            VALVE5,
            VALVE6,
            VALVE7,
            VALVE8,
            VALVEM1,
            VALVEM2,
        }
        public enum E_SYSTEM_DIAG_FUNCTION_TYPE
        {
            HEATER=0,
            IGNITOR_VALVE,
            REMOTE_SIGNAL,
            APC_VALVE,
            APC_SENSOR,
            POWER_MONITOR
        }

        public enum E_SYSTEM_DIAG_COMMAND_TYPE
        {
            START_HEATER,
            STOP_HEATER,
            START_IGNITOR_VALVE,
            STOP_IGNITOR_VALVE,
            START_REMOTE_SIGNAL,
            STOP_REMOTE_SIGNAL,
            START_UPC_VALVE_CHECK,
            STOP_UPC_VALVE_CHECK,
            START_UPC_SENSOR_CHECK,
            STOP_UPC_SENSOR_CHECK,
            START_POWER_MONITOR,
            STOP_POWER_MONITOR,
        }
        public enum E_GLOBAL_COMMAND_TYPE
        {
            E_OVEN_TEMP_RESET,
            E_OVEN_TEMP_APPLY,

            E_INLET_FRONT_TEMP_RESET,
            E_INLET_FRONT_TEMP_APPLY,
            E_INLET_FRONT_SENSORZERO_RESET,
            E_INLET_FRONT_SENSORZERO_START,
            E_INLET_FRONT_SENSORZERO_STOP,
            E_INLET_FRONT_SENSORZERO_APPLY,
            E_INLET_FRONT_VALVE_RESET,
            E_INLET_FRONT_VALVE_START,
            E_INLET_FRONT_VALVE_STOP,
            E_INLET_FRONT_VALVE_APPLY,
            E_INLET_FRONT_FLOW_RESET,
            E_INLET_FRONT_FLOW_START,
            E_INLET_FRONT_FLOW_STOP,
            E_INLET_FRONT_FLOW_APPLY,

            E_INLET_CENTER_TEMP_RESET,
            E_INLET_CENTER_TEMP_APPLY,
            E_INLET_CENTER_SENSORZERO_RESET,
            E_INLET_CENTER_SENSORZERO_START,
            E_INLET_CENTER_SENSORZERO_STOP,
            E_INLET_CENTER_SENSORZERO_APPLY,
            E_INLET_CENTER_VALVE_RESET,
            E_INLET_CENTER_VALVE_START,
            E_INLET_CENTER_VALVE_STOP,
            E_INLET_CENTER_VALVE_APPLY,
            E_INLET_CENTER_FLOW_RESET,
            E_INLET_CENTER_FLOW_START,
            E_INLET_CENTER_FLOW_STOP,
            E_INLET_CENTER_FLOW_APPLY,

            E_INLET_REAR_TEMP_RESET,
            E_INLET_REAR_TEMP_APPLY,
            E_INLET_REAR_SENSORZERO_RESET,
            E_INLET_REAR_SENSORZERO_START,
            E_INLET_REAR_SENSORZERO_STOP,
            E_INLET_REAR_SENSORZERO_APPLY,
            E_INLET_REAR_VALVE_RESET,
            E_INLET_REAR_VALVE_START,
            E_INLET_REAR_VALVE_STOP,
            E_INLET_REAR_VALVE_APPLY,
            E_INLET_REAR_FLOW_RESET,
            E_INLET_REAR_FLOW_START,
            E_INLET_REAR_FLOW_STOP,
            E_INLET_REAR_FLOW_APPLY,

            E_DET_FRONT_TEMP_RESET,
            E_DET_FRONT_TEMP_APPLY,
            E_DET_FRONT_SENSORZERO_RESET,
            E_DET_FRONT_SENSORZERO_START,
            E_DET_FRONT_SENSORZERO_STOP,
            E_DET_FRONT_SENSORZERO_APPLY,
            E_DET_FRONT_VALVE_RESET,
            E_DET_FRONT_VALVE_START,
            E_DET_FRONT_VALVE_STOP,
            E_DET_FRONT_VALVE_APPLY,
            E_DET_FRONT_FLOW_RESET,
            E_DET_FRONT_FLOW_START,
            E_DET_FRONT_FLOW_STOP,
            E_DET_FRONT_FLOW_APPLY,

            E_DET_CENTER_TEMP_RESET,
            E_DET_CENTER_TEMP_APPLY,
            E_DET_CENTER_SENSORZERO_RESET,
            E_DET_CENTER_SENSORZERO_START,
            E_DET_CENTER_SENSORZERO_STOP,
            E_DET_CENTER_SENSORZERO_APPLY,
            E_DET_CENTER_VALVE_RESET,
            E_DET_CENTER_VALVE_START,
            E_DET_CENTER_VALVE_STOP,
            E_DET_CENTER_VALVE_APPLY,
            E_DET_CENTER_FLOW_RESET,
            E_DET_CENTER_FLOW_START,
            E_DET_CENTER_FLOW_STOP,
            E_DET_CENTER_FLOW_APPLY,

            E_DET_REAR_TEMP_RESET,
            E_DET_REAR_TEMP_APPLY,
            E_DET_REAR_SENSORZERO_RESET,
            E_DET_REAR_SENSORZERO_START,
            E_DET_REAR_SENSORZERO_STOP,
            E_DET_REAR_SENSORZERO_APPLY,
            E_DET_REAR_VALVE_RESET,
            E_DET_REAR_VALVE_START,
            E_DET_REAR_VALVE_STOP,
            E_DET_REAR_VALVE_APPLY,
            E_DET_REAR_FLOW_RESET,
            E_DET_REAR_FLOW_START,
            E_DET_REAR_FLOW_STOP,
            E_DET_REAR_FLOW_APPLY,

            E_AUX1_SENSORZERO_RESET,
            E_AUX1_SENSORZERO_START,
            E_AUX1_SENSORZERO_STOP,
            E_AUX1_SENSORZERO_APPLY,
            E_AUX1_VALVE_RESET,
            E_AUX1_VALVE_START,
            E_AUX1_VALVE_STOP,
            E_AUX1_VALVE_APPLY,
            E_AUX1_FLOW_RESET,
            E_AUX1_FLOW_START,
            E_AUX1_FLOW_STOP,
            E_AUX1_FLOW_APPLY,

            E_AUX2_SENSORZERO_RESET,
            E_AUX2_SENSORZERO_START,
            E_AUX2_SENSORZERO_STOP,
            E_AUX2_SENSORZERO_APPLY,
            E_AUX2_VALVE_RESET,
            E_AUX2_VALVE_START,
            E_AUX2_VALVE_STOP,
            E_AUX2_VALVE_APPLY,
            E_AUX2_FLOW_RESET,
            E_AUX2_FLOW_START,
            E_AUX2_FLOW_STOP,
            E_AUX2_FLOW_APPLY,

            E_AUX3_SENSORZERO_RESET,
            E_AUX3_SENSORZERO_START,
            E_AUX3_SENSORZERO_STOP,
            E_AUX3_SENSORZERO_APPLY,
            E_AUX3_VALVE_RESET,
            E_AUX3_VALVE_START,
            E_AUX3_VALVE_STOP,
            E_AUX3_VALVE_APPLY,
            E_AUX3_FLOW_RESET,
            E_AUX3_FLOW_START,
            E_AUX3_FLOW_STOP,
            E_AUX3_FLOW_APPLY,

            E_AUXTEMP1_TEMP_RESET,
            E_AUXTEMP1_TEMP_APPLY,
            E_AUXTEMP2_TEMP_RESET,
            E_AUXTEMP2_TEMP_APPLY,
            E_AUXTEMP3_TEMP_RESET,
            E_AUXTEMP3_TEMP_APPLY,
            E_AUXTEMP4_TEMP_RESET,
            E_AUXTEMP4_TEMP_APPLY,
            E_AUXTEMP5_TEMP_RESET,
            E_AUXTEMP5_TEMP_APPLY,
            E_AUXTEMP6_TEMP_RESET,
            E_AUXTEMP6_TEMP_APPLY,
            E_AUXTEMP7_TEMP_RESET,
            E_AUXTEMP7_TEMP_APPLY,
            E_AUXTEMP8_TEMP_RESET,
            E_AUXTEMP8_TEMP_APPLY,
        }

        public enum E_KEY_PAD_SET_MEASURE_TYPE
        {
            INLET_FRONT_SET_TEMP_CALIBRATION_T1,
            INLET_FRONT_SET_TEMP_CALIBRATION_T2,
            INLET_FRONT_SET_FLOW_CALIBRATION1,
            INLET_FRONT_SET_FLOW_CALIBRATION2,
            INLET_FRONT_SET_FLOW_CALIBRATION3,
            INLET_FRONT_MEASURE_TEMP_CALIBRATION_T1,
            INLET_FRONT_MEASURE_TEMP_CALIBRATION_T2,
            INLET_FRONT_MEASURE_FLOW_CALIBRATION1,
            INLET_FRONT_MEASURE_FLOW_CALIBRATION2,
            INLET_FRONT_MEASURE_FLOW_CALIBRATION3,

            INLET_CENTER_SET_TEMP_CALIBRATION_T1,
            INLET_CENTER_SET_TEMP_CALIBRATION_T2,
            INLET_CENTER_SET_FLOW_CALIBRATION1,
            INLET_CENTER_SET_FLOW_CALIBRATION2,
            INLET_CENTER_SET_FLOW_CALIBRATION3,
            INLET_CENTER_MEASURE_TEMP_CALIBRATION_T1,
            INLET_CENTER_MEASURE_TEMP_CALIBRATION_T2,
            INLET_CENTER_MEASURE_FLOW_CALIBRATION1,
            INLET_CENTER_MEASURE_FLOW_CALIBRATION2,
            INLET_CENTER_MEASURE_FLOW_CALIBRATION3,

            INLET_REAR_SET_TEMP_CALIBRATION_T1,
            INLET_REAR_SET_TEMP_CALIBRATION_T2,
            INLET_REAR_SET_FLOW_CALIBRATION1,
            INLET_REAR_SET_FLOW_CALIBRATION2,
            INLET_REAR_SET_FLOW_CALIBRATION3,
            INLET_REAR_MEASURE_TEMP_CALIBRATION_T1,
            INLET_REAR_MEASURE_TEMP_CALIBRATION_T2,
            INLET_REAR_MEASURE_FLOW_CALIBRATION1,
            INLET_REAR_MEASURE_FLOW_CALIBRATION2,
            INLET_REAR_MEASURE_FLOW_CALIBRATION3,

            DET_FRONT_SET_TEMP_CALIBRATION_T1,
            DET_FRONT_SET_TEMP_CALIBRATION_T2,
            DET_FRONT_SET_FLOW_CALIBRATION1,
            DET_FRONT_SET_FLOW_CALIBRATION2,
            DET_FRONT_SET_FLOW_CALIBRATION3,
            DET_FRONT_MEASURE_TEMP_CALIBRATION_T1,
            DET_FRONT_MEASURE_TEMP_CALIBRATION_T2,
            DET_FRONT_MEASURE_FLOW_CALIBRATION1,
            DET_FRONT_MEASURE_FLOW_CALIBRATION2,
            DET_FRONT_MEASURE_FLOW_CALIBRATION3,

            DET_CENTER_SET_TEMP_CALIBRATION_T1,
            DET_CENTER_SET_TEMP_CALIBRATION_T2,
            DET_CENTER_SET_FLOW_CALIBRATION1,
            DET_CENTER_SET_FLOW_CALIBRATION2,
            DET_CENTER_SET_FLOW_CALIBRATION3,
            DET_CENTER_MEASURE_TEMP_CALIBRATION_T1,
            DET_CENTER_MEASURE_TEMP_CALIBRATION_T2,
            DET_CENTER_MEASURE_FLOW_CALIBRATION1,
            DET_CENTER_MEASURE_FLOW_CALIBRATION2,
            DET_CENTER_MEASURE_FLOW_CALIBRATION3,

            DET_REAR_SET_TEMP_CALIBRATION_T1,
            DET_REAR_SET_TEMP_CALIBRATION_T2,
            DET_REAR_SET_FLOW_CALIBRATION1,
            DET_REAR_SET_FLOW_CALIBRATION2,
            DET_REAR_SET_FLOW_CALIBRATION3,
            DET_REAR_MEASURE_TEMP_CALIBRATION_T1,
            DET_REAR_MEASURE_TEMP_CALIBRATION_T2,
            DET_REAR_MEASURE_FLOW_CALIBRATION1,
            DET_REAR_MEASURE_FLOW_CALIBRATION2,
            DET_REAR_MEASURE_FLOW_CALIBRATION3,

            AUX1_SET_FLOW_CALIBRATION1,
            AUX1_SET_FLOW_CALIBRATION2,
            AUX1_SET_FLOW_CALIBRATION3,
            AUX1_MEASURE_FLOW_CALIBRATION1,
            AUX1_MEASURE_FLOW_CALIBRATION2,
            AUX1_MEASURE_FLOW_CALIBRATION3,

            AUX2_SET_FLOW_CALIBRATION1,
            AUX2_SET_FLOW_CALIBRATION2,
            AUX2_SET_FLOW_CALIBRATION3,
            AUX2_MEASURE_FLOW_CALIBRATION1,
            AUX2_MEASURE_FLOW_CALIBRATION2,
            AUX2_MEASURE_FLOW_CALIBRATION3,

            AUX3_SET_FLOW_CALIBRATION1,
            AUX3_SET_FLOW_CALIBRATION2,
            AUX3_SET_FLOW_CALIBRATION3,
            AUX3_MEASURE_FLOW_CALIBRATION1,
            AUX3_MEASURE_FLOW_CALIBRATION2,
            AUX3_MEASURE_FLOW_CALIBRATION3,

            AUXTEMP1_SET_TEMP_CALIBRATION1_T1,
            AUXTEMP1_SET_TEMP_CALIBRATION1_T2,
            AUXTEMP1_SET_TEMP_CALIBRATION2_T1,
            AUXTEMP1_SET_TEMP_CALIBRATION2_T2,
            AUXTEMP1_SET_TEMP_CALIBRATION3_T1,
            AUXTEMP1_SET_TEMP_CALIBRATION3_T2,
            AUXTEMP1_SET_TEMP_CALIBRATION4_T1,
            AUXTEMP1_SET_TEMP_CALIBRATION4_T2,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION1_T1,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION1_T2,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION2_T1,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION2_T2,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION3_T1,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION3_T2,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION4_T1,
            AUXTEMP1_MEASURE_TEMP_CALIBRATION4_T2,

            AUXTEMP2_SET_TEMP_CALIBRATION1_T1,
            AUXTEMP2_SET_TEMP_CALIBRATION1_T2,
            AUXTEMP2_SET_TEMP_CALIBRATION2_T1,
            AUXTEMP2_SET_TEMP_CALIBRATION2_T2,
            AUXTEMP2_SET_TEMP_CALIBRATION3_T1,
            AUXTEMP2_SET_TEMP_CALIBRATION3_T2,
            AUXTEMP2_SET_TEMP_CALIBRATION4_T1,
            AUXTEMP2_SET_TEMP_CALIBRATION4_T2,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION1_T1,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION1_T2,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION2_T1,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION2_T2,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION3_T1,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION3_T2,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION4_T1,
            AUXTEMP2_MEASURE_TEMP_CALIBRATION4_T2,

            OVEN_SET_TEMP_CALIBRATION_T1,
            OVEN_SET_TEMP_CALIBRATION_T2,
            OVEN_MEASURE_TEMP_CALIBRATION_T1,
            OVEN_MEASURE_TEMP_CALIBRATION_T2,

            CONFIG_VALVE1_PORT,
            CONFIG_VALVE2_PORT,
            CONFIG_VALVE3_PORT,
            CONFIG_VALVE4_PORT,
            CONFIG_VALVE5_PORT,
            CONFIG_VALVE6_PORT,
            CONFIG_VALVE7_PORT,
            CONFIG_VALVE8_PORT,
            CONFIG_VALVEM1_PORT,
            CONFIG_VALVEM2_PORT,

            CONFIG_VALVE1_FLOW,
            CONFIG_VALVE2_FLOW,
            CONFIG_VALVE3_FLOW,
            CONFIG_VALVE4_FLOW,
            CONFIG_VALVE5_FLOW,
            CONFIG_VALVE6_FLOW,
            CONFIG_VALVE7_FLOW,
            CONFIG_VALVE8_FLOW,
            CONFIG_VALVEM1_FLOW,
            CONFIG_VALVEM2_FLOW,

            SETTING_INIT_TEMP,
            SETTING_INIT_TIME,
            SETTING_RATE,
            SETTING_FINAL_TEMP,
            SETTING_FINAL_TIME,
            SETTING_REMOTE_TIME,
            SETTING_REMOTE_EVENT1,
            SETTING_REMOTE_EVENT2,
            SETTING_INSTALL_DATE,
            SETTING_DATE,
            SETTING_TIME
        }

        public enum E_ERROR_STATE
        {
            GC_Error_None = 0,
            GC_Error_DoorOpen = 1,
            GC_Error_OvenTemp = 2,
            GC_Error_Oven_RangeErr = 3,
            GC_Error_H2_Leak = 4,
            GC_Error_Inj_F_Temp = 11,
            GC_Error_Inj_C_Temp = 12,
            GC_Error_Inj_R_Temp = 13,
            GC_Error_Det_F_Temp = 14,
            GC_Error_Det_C_Temp = 15,
            GC_Error_Det_R_Temp = 16,
            GC_Error_Aux_1_Temp = 17,
            GC_Error_Aux_2_Temp = 18,
            GC_Error_Aux_3_Temp = 19,
            GC_Error_Aux_4_Temp = 20,
            GC_Error_Aux_5_Temp = 21,
            GC_Error_Aux_6_Temp = 22,
            GC_Error_Aux_7_Temp = 23,
            GC_Error_Aux_8_Temp = 24,
            GC_Error_Det_F_Ignition = 25,
            GC_Error_Det_C_Ignition = 26,
            GC_Error_Det_R_Ignition = 27,
            GC_Error_Inj_F_LowGas = 30,
            GC_Error_Inj_C_LowGas = 31,
            GC_Error_Inj_R_LowGas = 32,

            GC_Error_Det_F_Sen1_LowGas = 33,
            GC_Error_Det_F_Sen2_LowGas = 34,
            GC_Error_Det_F_Sen3_LowGas = 35,
            GC_Error_Det_C_Sen1_LowGas = 36,
            GC_Error_Det_C_Sen2_LowGas = 37,
            GC_Error_Det_C_Sen3_LowGas = 38,
            GC_Error_Det_R_Sen1_LowGas = 39,
            GC_Error_Det_R_Sen2_LowGas = 40,
            GC_Error_Det_R_Sen3_LowGas = 41,
            GC_Error_Aux_F_Sen1_LowGas = 42,
            GC_Error_Aux_F_Sen2_LowGas = 43,
            GC_Error_Aux_F_Sen3_LowGas = 44,
            GC_Error_Aux_C_Sen1_LowGas = 45,
            GC_Error_Aux_C_Sen2_LowGas = 46,
            GC_Error_Aux_C_Sen3_LowGas = 47,
            GC_Error_Aux_R_Sen1_LowGas = 48,
            GC_Error_Aux_R_Sen2_LowGas = 49,
            GC_Error_Aux_R_Sen3_LowGas = 50,

            GC_Error_Inj_F_OverFlow = 60,
            GC_Error_Inj_C_OverFlow = 61,
            GC_Error_Inj_R_OverFlow = 62,

            GC_Error_Det_F_Sen1_OverFlow = 63,
            GC_Error_Det_F_Sen2_OverFlow = 64,
            GC_Error_Det_F_Sen3_OverFlow = 65,
            GC_Error_Det_C_Sen1_OverFlow = 66,
            GC_Error_Det_C_Sen2_OverFlow = 67,
            GC_Error_Det_C_Sen3_OverFlow = 68,
            GC_Error_Det_R_Sen1_OverFlow = 69,
            GC_Error_Det_R_Sen2_OverFlow = 70,
            GC_Error_Det_R_Sen3_OverFlow = 71,
            GC_Error_Aux_F_Sen1_OverFlow = 72,
            GC_Error_Aux_F_Sen2_OverFlow = 73,
            GC_Error_Aux_F_Sen3_OverFlow = 74,
            GC_Error_Aux_C_Sen1_OverFlow = 75,
            GC_Error_Aux_C_Sen2_OverFlow = 76,
            GC_Error_Aux_C_Sen3_OverFlow = 77,
            GC_Error_Aux_R_Sen1_OverFlow = 78,
            GC_Error_Aux_R_Sen2_OverFlow = 79,
            GC_Error_Aux_R_Sen3_OverFlow = 80,

            GC_Error_Det_F_TCD_Ref_LowGas = 90,
            GC_Error_Det_C_TCD_Ref_LowGas = 91,
            GC_Error_Det_R_TCD_Ref_LowGas = 92,

            GC_Error_Det_F_TCD_Mkup_LowGas = 100,
            GC_Error_Det_C_TCD_Mkup_LowGas = 101,
            GC_Error_Det_R_TCD_Mkup_LowGas = 102,

            GC_Error_48V_Heater_Fuse = 110,
            GC_Error_MultiP_1_Valve = 120,
            GC_Error_MultiP_2_Valve = 121,

            GC_Error_Cryo_Control = 130,

            GC_APC_Error_None = 150,
            GC_APC_Error_Inj_F_Setting = 151,
            GC_APC_Error_Inj_C_Setting = 152,
            GC_APC_Error_Inj_R_Setting = 153,
            GC_APC_Error_Det_F_Setting = 154,
            GC_APC_Error_Det_C_Setting = 155,
            GC_APC_Error_Det_R_Setting = 156,
            GC_APC_Error_Aux_F_Setting = 157,
            GC_APC_Error_Aux_C_Setting = 158,
            GC_APC_Error_Aux_R_Setting = 159,

            APC_Calib_Error_None = 170,
            APC_Calib_Error_Inj_F_Setting = 171,
            APC_Calib_Error_Inj_C_Setting = 172,
            APC_Calib_Error_Inj_R_Setting = 173,
            APC_Calib_Error_Det_F_Setting = 174,
            APC_Calib_Error_Det_C_Setting = 175,
            APC_Calib_Error_Det_R_Setting = 176,
            APC_Calib_Error_Aux_F_Setting = 177,
            APC_Calib_Error_Aux_C_Setting = 178,
            APC_Calib_Error_Aux_R_Setting = 179,
            // 180~183 은 Valve Calibration Fail 메시지 표시용으로 에러창 안 띄움.
            APC_Calib_Error_Volt_High = 180,
            APC_Calib_Error_Time_Over = 181,
            APC_Calib_Error_Valve_16V = 182,
            APC_Calib_Error_Fail = 183,

            GC_Error_Code_Max
        }

        public enum E_CALIBRATION_STATE
        {
            STOP,
            CHECKING,
            PASS,
            FAIL,
            COMPLETE,
            RESET
        }
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
        public enum E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE
        {
            FLOW_CALIBRATION1,
            FLOW_CALIBRATION2,
            FLOW_CALIBRATION3,
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

        public static float FLOAT_CALIBRATION_MAX_FLOW = 9999f;
        public static float FLOAT_CALIBRATION_MAX_TEMPERATURE = 450f;
        public static string STR_CALIBRATION_FAIL_VH = "VH FAIL";
        public static string STR_CALIBRATION_FAIL_TO = "TO FAIL";
        public static string STR_CALIBRATION_FAIL_16V = "16V FAIL";
        public static string STR_CALIBRATION_FAIL_DEFAULT = "FAIL";
        public static string STR_UNIT_VOLTAGE = " V";
        public static string STR_FORMAT_BELOW_POINT_1 = "0.0";
        public static string STR_FORMAT_BELOW_POINT_2 = "0.00";
        public static string STR_FORMAT_BELOW_POINT_3 = "0.000";
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
