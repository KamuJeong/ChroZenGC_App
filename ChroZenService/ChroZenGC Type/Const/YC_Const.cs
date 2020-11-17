using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public class YC_Const
    {
        public class NetworkParam
        {
            public static IPAddress IP_LocalEP = new IPAddress(new byte[4] { 127, 0, 0, 1 });
            public static IPAddress IP_ChrogenAddress = new IPAddress(new byte[4] { 10, 10, 10, 99 });
            public static int n_ChrogenPort = 4242;
        }
        public class SocketStateObject
        {
            // Client socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 4096;
            // Receive raw bytes.  
            public byte[] rawBuffer = new byte[BufferSize];

            // Received lengthed bytes.  
            public byte[] lengthedBuffer;
        }

        #region Config const
        public static string SER_NUM = "0";
        public static string FW_VERSION = "0";
        public const string DEVICE_SHORT_NAME = "GC";

        #endregion Config const

        #region Method const
        public static int DataRate = 500;
        public static float fMinTemp = -80;
        public static float fMinTime = 0;
        public static float fMaxTime = 9999;
        public static float fMaxTemp = 450;
        public static float fMinRate = 0;
        public static float fMaxRate = 100;
        public static int nMinRepeatCount = 1;
        public static int nMaxRepeatCount = 9999;
        public static float fCapillaryMinFlow = 0;
        public static float fCapillaryMaxFlow = 30;
        public static float fPackedMinFlow = fCapillaryMinFlow;
        public static float fPackedMaxFlow = 200;
        public static float fOnColumnMinFlow = fPackedMinFlow;
        public static float fOnColumnMaxFlow = fPackedMaxFlow;
        public static float fMinPressureCorrect = 0;
        public static float fMaxPressureCorrect = 100;

        public static float fCapillaryMinPressure = 0;
        public static float fCapillaryMaxPressure = 150;
        public static float fMinPulsedPressure = 0;
        public static float fMaxPulsedPressure = 150;

        public static short nMinSplitRatio = 1;
        public static short nMaxSplitRatio = 7500;
        public static float fMinSplitOnTime = 0;
        public static float fMaxSplitOnTime = 9999;
        public static float fMinSplitFlow = 0;
        public static float fMaxSplitFlow = 1000;
        public static float fMinTotalFlow = 0;
        public static float fMaxTotalFlow = 1000;
        public static float fMinGasSaverFlow = 1;
        public static float fMaxGasSaverFlow = 1000;

        public static float fMinColumnLength = 5;
        public static float fMaxColumnLength = 150;
        public static float fMinColumnDiameter = 0.1f;
        public static float fMaxColumnDiameter = 1;
        public static float fMinColumnThickness = 0;
        public static float fMaxColumnThickness = 50;

        public static float fMinAuxTemp = 0;
        public static float fMaxAuxTemp = 250;
        public static float fMinMethanizerTemp = 0;
        public static float fMaxMethanizerTemp = 400;
        public static float fMinStartPulseWidth = 0;
        public static float fMaxStartPulseWidth = 5000;
        public static float fMinUpcFlow = 0;
        public static float fMaxUpcFlow = 150;

        public static float fMinSensitivity = -10;
        public static float fMaxSensitivity = 10;

        public static float fMinSignalZero = -9999;
        public static float fMaxSignalZero = 1000;

        public static float fMinDetOffset = 0;//범위 미확인 임의 입력
        public static float fMaxDetOffset = 50;
        public static float fMinIgniteDelay = 0;
        public static float fMaxIgniteDelay = 9999;
        public static float fMinIgniteFlow = 0;
        public static float fMaxIgniteFlow = 300;
        public static float fMinIgniteTemp = 0;
        public static float fMaxIgniteTemp = 450;
        public static int nMinSignalSensitivity = -10;
        public static int nMaxSignalSensitivity = 10;
        public static int nMinSignalRange = 0;
        public static int nMaxSignalRange = 10;
        public static float fMinDetFidTemp = 0;
        public static float fMaxDetFidTemp = 450;
        public static float fMinDetNoneFidTemp = 0;
        public static float fMaxDetNoneFidTemp = 400;
        public static float fMinDetFlow1Air = 0;
        public static float fMaxDetFlow1Air = 500;
        public static float fMinDetFlow1Mkup = 0;
        public static float fMaxDetFlow1Mkup = 100;
        public static float fMinDetFlow2 = 0;
        public static float fMaxDetFlow2 = 100;
        public static float fMinDetFlow3 = 0;
        public static float fMaxDetFlow3 = 150;
        public static int nMinBeadVoltage = 0;
        public static int nMaxBeadVoltage = 9;
      
        #endregion Method const

        public static string STR_NULL = "";
        public static string STR_NAVIGATE_OVEN_CONFIG = "Oven Config";
        public static string STR_NAVIGATE_OVEN_SETTING = "Oven Setting";
        public static string STR_NAVIGATE_CAPILLARY_CONFIG = "Capillary" + Environment.NewLine + " Config";
        public static string STR_NAVIGATE_CAPILLARY_SETTING = "Capillary" + Environment.NewLine + " Settings";
        public static string STR_NAVIGATE_VALVE_CONFIG = "  Valve" + Environment.NewLine + " Config";
        public static string STR_NAVIGATE_VALVE_SETTING = "  Valve" + Environment.NewLine + " Settings";
        public static string STR_NAVIGATE_AUX_TEMPERATURE = "   Aux" + Environment.NewLine + " Config";
        public static string STR_NAVIGATE_AUX_FLOW = "Aux Settings";

        #region Det Title string

        public static string STR_DET_NOT_INSTALLED = "Not installed";
        public static string STR_DET_FID = "FID";
        public static string STR_DET_TCD = "TCD";
        public static string STR_DET_FPD_NOT_USED = "FPD - Not used";
        public static string STR_DET_NPD_NOT_USED = "NPD - Not used";
        public static string STR_DET_ECD = "ECD";
        public static string STR_DET_PFPD = "PFPD";
        public static string STR_DET_PDD = "PDD";
        public static string STR_DET_FPD = "FPD";
        public static string STR_DET_NPD = "NPD";
        public static string STR_DET_uTCD = "uTCD";
        public static string STR_DET_uECD = "uECD";

        #endregion Det Title string

        #region Inlet Title string

        public static string STR_INLET_NOT_INSTALLED = "Not installed";
        public static string STR_INLET_CAPILLARY = "Capillary";
        public static string STR_INLET_PACKED = "Packed";
        public static string STR_INLET_ON_COLUMN = "On-column";

        #endregion Inlet Title string

        #region State string

        public const string CHROZEN_GC_STATE_READY = "Ready";
        public const string CHROZEN_GC_STATE_NOT_READY = "Not ready";
        public const string CHROZEN_GC_STATE_RUN = "Run";
        public const string CHROZEN_GC_STATE_ERROR = "Error";
        public const string CHROZEN_GC_STATE_POWER_SAVE_MODE = "Power save mode";
        public const string CHROZEN_GC_STATE_DIAGNOSTICS = "Diagnostics";
        public const string CHROZEN_GC_STATE_CALIBRATION = "Calibration";
        public const string CHROZEN_GC_STATE_UNKNOWN = "Unknown";
        public const string CHROZEN_GC_STATE_POST_RUN = "Post run";
        public const string CHROZEN_GC_STATE_AUTO_READY_RUN = "Auto ready run";
        public const string CHROZEN_GC_STATE_COLUMN_CONDITION = "Column condition";
        public const string CHROZEN_GC_STATE_GAS_SAVER = "Gas saver";

        #endregion State string

        #region Config string

        public const string ADD_ON_OVEN_INSTALLED = "Installed";
        public const string ADD_ON_OVEN_NOT_INSTALLED = "None";
        public const string ADD_ON_CRYOGENIC_INSTALLED = "Installed";
        public const string ADD_ON_CRYOGENIC_NOT_INSTALLED = "None";
        public const string ADD_ON_AUTOSAMPLER_INSTALLED = "Installed";
        public const string ADD_ON_AUTOSAMPLER_NOT_INSTALLED = "None";
        public const string ADD_ON_METHANIZER_INSTALLED = "Installed";
        public const string ADD_ON_METHANIZER_NOT_INSTALLED = "None";
        public const string AUX_TEMP_AUX_APC_TYPE_0 = "None";
        public const string AUX_TEMP_AUX_APC_TYPE_1 = "Type1";
        public const string AUX_TEMP_AUX_APC_TYPE_2 = "Type2";
        public const string AUX_TEMP_AUX_APC_TYPE_3 = "Type3";
        public const string AUX_TEMP_AUX_APC_TYPE_4 = "Type4";
        public const string AUX_TEMP_AUX_APC_TYPE_5 = "Type5";
        public const string AUX_TEMP_AUX_APC_TYPE_6 = "Type6";
        public const string INLET_INFO_INLET_TYPE_0 = "None";
        public const string INLET_INFO_INLET_TYPE_1 = "Capillary";
        public const string INLET_INFO_INLET_TYPE_2 = "Packed";
        public const string INLET_INFO_INLET_TYPE_3 = "OnColumn";
        public const string DET_INFO_DET_TYPE_0 = "None";
        public const string DET_INFO_DET_TYPE_1 = "FID";
        public const string DET_INFO_DET_TYPE_2 = "TCD";
        public const string DET_INFO_DET_TYPE_3 = "FPD-Old";
        public const string DET_INFO_DET_TYPE_4 = "NPD-Old";
        public const string DET_INFO_DET_TYPE_5 = "ECD";
        public const string DET_INFO_DET_TYPE_6 = "PFPD";
        public const string DET_INFO_DET_TYPE_7 = "PDD";
        public const string DET_INFO_DET_TYPE_8 = "FPD";
        public const string DET_INFO_DET_TYPE_9 = "NPD";
        public const string DET_INFO_DET_TYPE_A = "uTCD";
        public const string DET_INFO_DET_TYPE_B = "uECD";
        public const string VALVE_INFO_VALVE_TYPE1_0 = "None";
        public const string VALVE_INFO_VALVE_TYPE1_1 = "GSV";
        public const string VALVE_INFO_VALVE_TYPE1_2 = "LSV";
        public const string VALVE_INFO_VALVE_TYPE2_1 = "AIR";
        public const string VALVE_INFO_VALVE_TYPE2_2 = "ELE";

        #endregion Config string

        #region 메소드 스트링
        public const string INVALID_VALUE = "INVALID";

        public const string MARKER_CLOSE = "Close";
        public const string MARKER_OPEN = "Open";
        public const string MARKER_PULSE = "Pulse";

        public const string DEFAULT_MARKOUT_STRING_CLOSE = "Close";
        public const string DEFAULT_MARKOUT_STRING_OPEN = "Open";

        public const string DEFAULT_VALVE_STRING_POS1 = "Pos1";
        public const string DEFAULT_VALVE_STRING_POS2 = "Pos2";

        public const string EXT_OUT_STRING_CLOSE = "Close";
        public const string EXT_OUT_STRING_OPEN = "Open";

        public const string START_EXT_IN_STRING_NONE = "None";
        public const string START_EXT_IN_STRING_0_1 = "0 > 1";
        public const string START_EXT_IN_STRING_1_0 = "1 > 0";

        public const string READY_EXT_IN_STRING_0 = "Level 0";
        public const string READY_EXT_IN_STRING_1 = "Level 1";

        public const string SWITCH_STRING_OFF = "OFF";
        public const string SWITCH_STRING_ON = "ON";

        public const string MARKOUT_CLOSE = "Contact close";
        public const string MARKOUT_OPEN = "Contact open";

        #endregion 메소드 스트링

        /// <summary>
        /// resource interface id method
        /// </summary>
        public const string RESOURCE_INTERFACE_ID_METHOD = @"method";

        /// <summary>
        /// resource interface id config
        /// </summary>
        public const string RESOURCE_INTERFACE_ID_CONFIG = @"config";

        /// <summary>
        /// resource interface id status
        /// </summary>
        public const string RESOURCE_INTERFACE_ID_STATUS = @"status";

        /// <summary>
        /// resource interface id pretreatment
        /// </summary>
        public const string RESOURCE_INTERFACE_ID_PRETREATMENT = @"pretreatment";

        /// <summary>
        /// resource interface id for (direct) control
        /// </summary>
        public const string RESOURCE_INTERACE_ID_CONTROLING = @"controling";

        /// <summary>
        /// 1
        /// </summary>
        public static int TIME_CTRL_PRGM_CNT = 1;
        /// <summary>
        /// 6
        /// </summary>
        public static int INLET_PRGM_COUNT = 6;
        /// <summary>
        /// 20
        /// </summary>
        public static int VALVE_PRGM_COUNT = 20;
        /// <summary>
        /// 3
        /// </summary>
        public static int INLET_SLOT_COUNT = 3;
        /// <summary>
        /// 3
        /// </summary>
        public static int DET_SLOT_COUNT = 3;
        /// <summary>
        /// 2
        /// </summary>
        public static int AUX_SLOT_COUNT = 2;
        /// <summary>
        /// 8
        /// </summary>
        public static int VALVE_SLOT_COUNT = 8;
        /// <summary>
        /// 2
        /// </summary>
        public static int MVALVE_SLOT_COUNT = 2;
        /// <summary>
        /// 5
        /// </summary>
        public static int SIGNAL_PRGM_COUNT = 5;
        /// <summary>
        /// 3
        /// </summary>
        public static int AUX_APC_COUNT = 3;
        /// <summary>
        /// 8
        /// </summary>
        public static int AUX_TEMP_COUNT = 8;
        /// <summary>
        /// 25
        /// </summary>
        public static int OVEN_PRGM_CNT = 25;
        /// <summary>
        /// 5
        /// </summary>
        public static int TCD_POLA_PRGM_CNT = 5;
        /// <summary>
        /// 5
        /// </summary>
        public static int POLAR_PRGM_COUNT = 5;
        /// <summary>
        /// 20
        /// </summary>
        public static int CHROGEN_VALVE_PROGRAM = 20;
        public static int YL6700GC_VALVE_PROGRAM = CHROGEN_VALVE_PROGRAM;
        /// <summary>
        /// 8
        /// </summary>
        public static int CHROGEN_VALVE_COUNT = 8;
        public static int YL6700GC_VALVE_COUNT = CHROGEN_VALVE_COUNT;
        /// <summary>
        /// 2
        /// </summary>
        public static int CHROGEN_MULTI_VALVE_COUNT = 2;
        public static int YL6700GC_MULTI_VALVE_COUNT = CHROGEN_MULTI_VALVE_COUNT;

        #region enum
        public enum E_DET_POSITION
        {
            FRONT,
            CENTER,
            REAR
        }

        public enum E_PACKCODE
        {
            /// <summary>
            /// CHROZEN-GC 구성 정보
            /// </summary>
            PACKCODE_CHROZEN_SYSTEM_INFORM = 0x67100,

            /// <summary>
            /// 
            /// </summary>
            PACKCODE_CHROZEN_SYSTEM_CONFIG = 0x67110,

            /// <summary>
            /// Oven Settings
            /// </summary>
            PACKCODE_CHROZEN_OVEN_SETTING = 0x67120,

            /// <summary>
            /// Inlet Settings
            /// </summary>
            PACKCODE_CHROZEN_INLET_SETTING = 0x67130,

            /// <summary>
            /// Detector Settings
            /// </summary>
            PACKCODE_CHROZEN_DET_SETTING = 0x67140,

            /// <summary>
            /// Valve Settings
            /// </summary>
            PACKCODE_CHROZEN_VALVE_SETTING = 0x67150,

            /// <summary>
            /// Auxiliary & Methanizer Settings
            /// </summary>
            PACKCODE_CHROZEN_AUX_TEMP_SETTING = 0x67160,

            /// <summary>
            /// Auxiliary APC Flow Settings
            /// </summary>
            PACKCODE_CHROZEN_AUX_APC_SETTING = 0x67165,

            /// <summary>
            /// Signal Settings
            /// </summary>
            PACKCODE_YL6200_SIGNAL_SETTING = 0x67170,

            /// <summary>
            /// Special Settings
            /// </summary>
            PACKCODE_CHROZEN_SPECIAL_FUNCTION = 0x67180,

            /// <summary>
            /// Time Control Settings
            /// </summary>
            PACKCODE_YL6200_TIME_CTRL_SETTING = 0x67371,

            /// <summary>
            /// Present state of instrument
            /// </summary>
            PACKCODE_CHROZEN_SYSTEM_STATE = 0x67500,

            /// <summary>
            /// Self message
            /// </summary>
            PACKCODE_YL6200_SLFEMSG = 0x67510,

            /// <summary>
            /// Command
            /// </summary>
            PACKCODE_YL6200_COMMAND = 0x67520,

            /// <summary>
            /// Signal Data
            /// </summary>
            PACKCODE_YL6200_SIGNAL = 0x67530,

            #region 20201020 박상수 추가 

            PACKCODE_YL6200_DIAGDATA = 0x67600,
            PACKCODE_YL6200_SERVICE = 0x67610,
            PACKCODE_YL6200_SVCDATA = 0x67620,

            PACKCODE_CHROZEN_LCD_SIGNAL = 0x67700,

            /// <summary>
            /// YL6700GC_APX_Calib_Read_t (0x27) GC -> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_APC_CALIB_READ = 0x67710,

            /// <summary>
            /// APC_SENSOR_VOLTAGE_t (0x3A) GC -> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE = 0x67720,

            /// <summary>
            /// YL6700GC_VOLTAGE_CHECK_t (0x3B) GC -> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK = 0x67730,

            /// <summary>
            /// YL6700GC_TEMP_CALIB_VALUE_t (0x4B) GC <-> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP = 0x67780,

            /// <summary>
            /// SIGNAL_CALIBRATION_DATA_t (0x4C) GC <-> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_CALIB_SIGNAL = 0x67790,

            /// <summary>
            /// YL6700GC_TEMP_CALIB_VALUE_t (0x41) GC <-> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_CALIB_OVEN = 0x67800,

            /// <summary>
            /// YL6700GC_TEMP_CALIB_VALUE_t (0x42) GC <-> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_CALIB_INLET = 0x67810,

            /// <summary>
            /// YL6700GC_TEMP_CALIB_VALUE_t YL6700GC_APC_INLET_Calib_Write_t(0x45) GC <-> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_CALIB_DET = 0x67840,

            /// <summary>
            /// YL6700GC_TEMP_CALIB_VALUE_t YL6700GC_APC_INLET_Calib_Write_t (0x48) GC <-> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_CALIB_APCAUX = 0x67870,

            /// <summary>
            /// SYSTEM_LCD_Diag_t (0x34) GC -> LCD
            /// </summary>
            PACKCODE_CHROZEN_LCD_DIAG = 0x67900,

            #endregion 20201020 박상수 추가
        }

        enum E_Locations
        {
            UnknownPort = -1, FrontPort = 0, CenterPort, RearPort
        }

        enum InletTypes
        {
            InletNone = 0, Capillary, Packed, OnColumn
        };

        enum DetectorTypes
        {
            DetectorNone = 0, FID, TCD, FPD, NPD, ECD, PFPD, PDD, uTCD
        };

        enum AuxiliaryAPCTypes
        {
            APCNone = 0, Type1, Type2, Type3, Type4, Type5, Type6
        };

        enum ValveTypes
        {
            ValveNone = 0, GSV, LSV
        };

        enum ActuatorTypes
        {
            UnknownActuator = 0, AirActuator, ElectricActuator
        };

        enum E_OVEN_MODE
        {
            Isothermal = 0, Program
        }

        enum E_TEMP_ON_OFF
        {
            Off = 0, On
        }

        enum E_COOLANT
        {
            N2 = 0, CO2
        }

        public enum DIAGNOSIS_CONTROL_TYPE
        {
            START,
            STOP
        }

        #endregion enum
    }
}
