using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModelSystemPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelSystemPage()
        {
            MenuSelectCommand = new RelayCommand(MenuSelectCommandAction);
            SubMenuSelectCommand = new RelayCommand(SubMenuSelectCommandAction);

            EventManager.onPACKCODE_Receivce += PACKCODE_ReceivceEventHandler;
        }

        private void PACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet)
        {
            switch (e_LC_PACK_CODE)
            {
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                    {
                        #region Calibration

                        CHROZEN_GC_STATE state = (CHROZEN_GC_STATE)((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btState;

                        #region AUX APC1 ~ 3

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_1_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_2_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_3_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_1_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received.auxPacket.Aux_flowCalMeasure[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_2_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received.auxPacket.Aux_flowCalMeasure[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Flow_Row_3_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received.auxPacket.Aux_flowCalMeasure[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[3].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[4].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[5].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[3].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[4].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[5].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[3].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[4].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[5].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_1_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_2_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_3_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_1_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received.auxPacket.Aux_flowCalMeasure[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_2_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received.auxPacket.Aux_flowCalMeasure[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Flow_Row_3_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received.auxPacket.Aux_flowCalMeasure[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[6].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[7].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_Voltage = DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.Disp_AuxValcalib[8].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1) + ChroZenService_Const.STR_UNIT_VOLTAGE;

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[6].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[7].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_Flow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[8].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[6].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[7].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_AuxFlow[8].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_1_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_2_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_3_Set = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received.auxPacket.Aux_flowCalSet[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_1_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received.auxPacket.Aux_flowCalMeasure[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_2_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received.auxPacket.Aux_flowCalMeasure[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Flow_Row_3_Measured = DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received.auxPacket.Aux_flowCalMeasure[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                        //GC state : Calibration일 때
                        switch (state)
                        {
                            case CHROZEN_GC_STATE.CALIBRATION:
                                {
                                    //SensorZero가 Start되었으면
                                    if (ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.bIsDoingSensorZeroCalibration)
                                    {
                                        E_CALIBRATION_STATE sensorZeroState1 = (E_CALIBRATION_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.AuxSenZeroState[0];
                                        switch (sensorZeroState1)
                                        {
                                            case E_CALIBRATION_STATE.STOP:
                                            case E_CALIBRATION_STATE.CHECKING:
                                            case E_CALIBRATION_STATE.PASS:
                                            case E_CALIBRATION_STATE.COMPLETE:
                                            case E_CALIBRATION_STATE.RESET:
                                                {
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_1 = sensorZeroState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_2 = sensorZeroState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_3 = sensorZeroState1.ToString();
                                                }
                                                break;
                                            case E_CALIBRATION_STATE.FAIL:
                                                {
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[0] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_1 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_1 = E_CALIBRATION_STATE.FAIL.ToString();
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[1] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_2 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_2 = E_CALIBRATION_STATE.FAIL.ToString();
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[2] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_3 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_3 = E_CALIBRATION_STATE.FAIL.ToString();
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_1 = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_2 = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_3 = E_CALIBRATION_STATE.STOP.ToString();
                                    }
                                    if (ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.bIsDoingSensorZeroCalibration)
                                    {
                                        E_CALIBRATION_STATE sensorZeroState2 = (E_CALIBRATION_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.AuxSenZeroState[1];
                                        switch (sensorZeroState2)
                                        {
                                            case E_CALIBRATION_STATE.STOP:
                                            case E_CALIBRATION_STATE.CHECKING:
                                            case E_CALIBRATION_STATE.PASS:
                                            case E_CALIBRATION_STATE.COMPLETE:
                                            case E_CALIBRATION_STATE.RESET:
                                                {
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_1 = sensorZeroState2.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_2 = sensorZeroState2.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_3 = sensorZeroState2.ToString();
                                                }
                                                break;
                                            case E_CALIBRATION_STATE.FAIL:
                                                {
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[3] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_1 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_1 = E_CALIBRATION_STATE.FAIL.ToString();
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[4] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_2 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_2 = E_CALIBRATION_STATE.FAIL.ToString();
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[5] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_3 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_3 = E_CALIBRATION_STATE.FAIL.ToString();
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_1 = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_2 = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.SensorZero_Row_3 = E_CALIBRATION_STATE.STOP.ToString();
                                    }
                                    if (ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.bIsDoingSensorZeroCalibration)
                                    {
                                        E_CALIBRATION_STATE sensorZeroState3 = (E_CALIBRATION_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.AuxSenZeroState[2];
                                        switch (sensorZeroState3)
                                        {
                                            case E_CALIBRATION_STATE.STOP:
                                            case E_CALIBRATION_STATE.CHECKING:
                                            case E_CALIBRATION_STATE.PASS:
                                            case E_CALIBRATION_STATE.COMPLETE:
                                            case E_CALIBRATION_STATE.RESET:
                                                {
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_1 = sensorZeroState3.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_2 = sensorZeroState3.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_3 = sensorZeroState3.ToString();
                                                }
                                                break;
                                            case E_CALIBRATION_STATE.FAIL:
                                                {
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[6] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_1 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_1 = E_CALIBRATION_STATE.FAIL.ToString();
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[7] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_2 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_2 = E_CALIBRATION_STATE.FAIL.ToString();
                                                    if (DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_InjErrorCode[8] == 0)
                                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_3 = E_CALIBRATION_STATE.PASS.ToString();
                                                    else ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_3 = E_CALIBRATION_STATE.FAIL.ToString();
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_1 = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_2 = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.SensorZero_Row_3 = E_CALIBRATION_STATE.STOP.ToString();
                                    }

                                    //Valve가 Start되었으면
                                    if (ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.bIsDoingValveCalibration)
                                    {
                                        E_CALIBRATION_STATE valveState1 = (E_CALIBRATION_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.AuxValCalState[0];
                                        switch (valveState1)
                                        {
                                            case E_CALIBRATION_STATE.STOP:
                                            case E_CALIBRATION_STATE.CHECKING:
                                            case E_CALIBRATION_STATE.PASS:
                                            case E_CALIBRATION_STATE.COMPLETE:
                                            case E_CALIBRATION_STATE.RESET:
                                                {
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_State = valveState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_State = valveState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_State = valveState1.ToString();
                                                }
                                                break;
                                            case E_CALIBRATION_STATE.FAIL:
                                                {
                                                    E_ERROR_STATE errorState1 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState1)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                    E_ERROR_STATE errorState2 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState2)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                    E_ERROR_STATE errorState3 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState3)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_1_State = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_2_State = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.Valve_Row_3_State = E_CALIBRATION_STATE.STOP.ToString();
                                    }
                                    if (ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.bIsDoingValveCalibration)
                                    {
                                        E_CALIBRATION_STATE valveState1 = (E_CALIBRATION_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.AuxValCalState[1];
                                        switch (valveState1)
                                        {
                                            case E_CALIBRATION_STATE.STOP:
                                            case E_CALIBRATION_STATE.CHECKING:
                                            case E_CALIBRATION_STATE.PASS:
                                            case E_CALIBRATION_STATE.COMPLETE:
                                            case E_CALIBRATION_STATE.RESET:
                                                {
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_State = valveState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_State = valveState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_State = valveState1.ToString();
                                                }
                                                break;
                                            case E_CALIBRATION_STATE.FAIL:
                                                {
                                                    E_ERROR_STATE errorState1 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState1)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                    E_ERROR_STATE errorState2 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState2)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                    E_ERROR_STATE errorState3 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState3)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_1_State = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_2_State = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2.Valve_Row_3_State = E_CALIBRATION_STATE.STOP.ToString();
                                    }
                                    if (ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.bIsDoingValveCalibration)
                                    {
                                        E_CALIBRATION_STATE valveState1 = (E_CALIBRATION_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.AuxValCalState[2];
                                        switch (valveState1)
                                        {
                                            case E_CALIBRATION_STATE.STOP:
                                            case E_CALIBRATION_STATE.CHECKING:
                                            case E_CALIBRATION_STATE.PASS:
                                            case E_CALIBRATION_STATE.COMPLETE:
                                            case E_CALIBRATION_STATE.RESET:
                                                {
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_State = valveState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_State = valveState1.ToString();
                                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_State = valveState1.ToString();
                                                }
                                                break;
                                            case E_CALIBRATION_STATE.FAIL:
                                                {
                                                    E_ERROR_STATE errorState1 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState1)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                    E_ERROR_STATE errorState2 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState2)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                    E_ERROR_STATE errorState3 = (E_ERROR_STATE)DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received.packet.APC_AuxErrorCode[0];
                                                    switch (errorState3)
                                                    {
                                                        case E_ERROR_STATE.APC_Calib_Error_Volt_High:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_VH;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Time_Over:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_TO;
                                                            }
                                                            break;
                                                        case E_ERROR_STATE.APC_Calib_Error_Valve_16V:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_16V;
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_State = ChroZenService_Const.STR_CALIBRATION_FAIL_DEFAULT;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_1_State = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_2_State = E_CALIBRATION_STATE.STOP.ToString();
                                        ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3.Valve_Row_3_State = E_CALIBRATION_STATE.STOP.ToString();
                                    }
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationOven;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationUPC2;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationUPC3;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationAuxTemp1;
                                    //ViewModel_System_Calibration.ViewModel_System_CalibrationAuxTemp2;
                                }
                                break;
                            default:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_1 = E_CALIBRATION_STATE.STOP.ToString();
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_2 = E_CALIBRATION_STATE.STOP.ToString();
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationUPC1.SensorZero_Row_3 = E_CALIBRATION_STATE.STOP.ToString();
                                }
                                break;
                        }

                        #endregion AUX APC1 ~ 3

                        #region Det

                        switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[0])
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Act = "-";
                                }
                                break;
                            case E_DET_TYPE.ECD:
                            case E_DET_TYPE.uECD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Act = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Act = "-";
                                }
                                break;
                            case E_DET_TYPE.PDD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                }
                                break;
                        }

                        switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[1])
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Act = "-";
                                }
                                break;
                            case E_DET_TYPE.ECD:
                            case E_DET_TYPE.uECD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Act = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Act = "-";
                                }
                                break;
                            case E_DET_TYPE.PDD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                }
                                break;
                        }

                        switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[2])
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Act = "-";
                                }
                                break;
                            case E_DET_TYPE.ECD:
                            case E_DET_TYPE.uECD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Act = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Act = "-";
                                }
                                break;
                            case E_DET_TYPE.PDD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString("##0.000");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Act = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString("##0.000");
                                }
                                break;
                        }

                        #endregion Det

                        #endregion Calibration

                    }
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING:
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ:
                    {

                    }
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP:
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET:
                    {
                        #region Calibration 

                        switch (((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).header.nEventIndex)
                        {
                            case 0:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[0].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[1].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[2].ToString("0.00");

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_1_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[0].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_2_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[1].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.Flow_Row_3_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[2].ToString("0.00");

                                }
                                break;
                            case 1:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[0].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[1].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[2].ToString("0.00");

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_1_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[0].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_2_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[1].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.Flow_Row_3_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[2].ToString("0.00");

                                }
                                break;
                            case 2:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[0].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[1].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Set = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_FlowCalSet[2].ToString("0.00");

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_1_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[0].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_2_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[1].ToString("0.00");
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.Flow_Row_3_Measured = ((T_PACKCODE_LCD_COMMAND_TYPE_DET)packet).detPacket.Det_flowCalMeasure[2].ToString("0.00");

                                }
                                break;
                        }

                        #endregion Calibration

                    }
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN:
                    {
                        #region Calibration 

                        switch (((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).header.nEventIndex)
                        {
                            case 0:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.fSet1 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fSet[0];
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.fSet2 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fSet[1];

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.fMeasure1 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fMeasure[0];
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.fMeasure2 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fMeasure[1];

                                }
                                break;
                            case 1:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.fSet1 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fSet[0];
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.fSet2 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fSet[1];

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.fMeasure1 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fMeasure[0];
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.fMeasure2 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fMeasure[1];

                                }
                                break;
                            case 2:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.fSet1 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fSet[0];
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.fSet2 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fSet[1];

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.fMeasure1 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fMeasure[0];
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.fMeasure2 = ((T_PACKCODE_LCD_COMMAND_TYPE_TEMP)packet).tempPacket.fMeasure[1];

                                }
                                break;
                        }

                        #endregion Calibration
                    }
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_SIGNAL:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_DIAG:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_SIGNAL:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK:
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SPECIAL_FUNCTION:
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG:
                    {
                        #region Calibration

                        #region Det

                        ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.e_DET_TYPE = (E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[0];
                        ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.e_DET_TYPE = (E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[1];
                        ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.e_DET_TYPE = (E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[2];

                        switch ((E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[0])
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle3 = "MakeUp";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle3 = "MakeUp";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle3 = "MakeUp";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow3Visible = true;
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle3 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle3 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle3 = "H2";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow3Visible = true;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle3 = "";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle3 = "";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle3 = "";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow3Visible = false;
                                }
                                break;
                            case E_DET_TYPE.ECD:
                            case E_DET_TYPE.uECD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow3Visible = false;
                                }
                                break;
                            case E_DET_TYPE.PDD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.SensorTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.ValveTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetFront.IsFlow3Visible = false;
                                }
                                break;
                        }

                        switch ((E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[1])
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle3 = "MakeUp";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle3 = "MakeUp";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle3 = "MakeUp";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow3Visible = true;
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle3 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle3 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle3 = "H2";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow3Visible = true;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle3 = "";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle3 = "";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle3 = "";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow3Visible = false;
                                }
                                break;
                            case E_DET_TYPE.ECD:
                            case E_DET_TYPE.uECD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow3Visible = false;
                                }
                                break;
                            case E_DET_TYPE.PDD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.SensorTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.ValveTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetCenter.IsFlow3Visible = false;
                                }
                                break;
                        }

                        switch ((E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[2])
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle3 = "MakeUp";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle3 = "MakeUp";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle1 = "Air";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle2 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle3 = "MakeUp";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow3Visible = true;
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle3 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle3 = "H2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle1 = "Air2";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle2 = "Air1";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle3 = "H2";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow3Visible = true;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle3 = "";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle3 = "";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle1 = "Ref.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle2 = "Sam.";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle3 = "";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow3Visible = false;
                                }
                                break;
                            case E_DET_TYPE.ECD:
                            case E_DET_TYPE.uECD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle1 = "Mkup";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow3Visible = false;
                                }
                                break;
                            case E_DET_TYPE.PDD:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.SensorTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.ValveTitle3 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle1 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsSensor3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow1Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationDetRear.IsFlow3Visible = false;
                                }
                                break;
                        }

                        #endregion Det

                        #region Inlet

                        ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.e_INLET_TYPE = (E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[0];
                        ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.e_INLET_TYPE = (E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[1];
                        ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.e_INLET_TYPE = (E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[2];

                        switch ((E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[0])
                        {
                            case E_INLET_TYPE.Capillary:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.SensorTitle1 = "Total";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.SensorTitle2 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.SensorTitle3 = "Press";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.ValveTitle1 = "Total";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.ValveTitle2 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.ValveTitle3 = "Column";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.FlowTitle1 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.FlowTitle2 = "Split";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.FlowTitle3 = "Column";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsFlow3Visible = true;
                                }
                                break;
                            case E_INLET_TYPE.Not_Installed:
                                break;
                            case E_INLET_TYPE.On_Column:
                            case E_INLET_TYPE.Packed:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.SensorTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.SensorTitle3 = "Press";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.ValveTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.ValveTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.FlowTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletFront.IsFlow3Visible = false;
                                }
                                break;
                        }

                        switch ((E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[1])
                        {
                            case E_INLET_TYPE.Capillary:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.SensorTitle1 = "Total";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.SensorTitle2 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.SensorTitle3 = "Press";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.ValveTitle1 = "Total";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.ValveTitle2 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.ValveTitle3 = "Column";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.FlowTitle1 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.FlowTitle2 = "Split";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.FlowTitle3 = "Column";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsFlow3Visible = true;
                                }
                                break;
                            case E_INLET_TYPE.Not_Installed:
                                break;
                            case E_INLET_TYPE.On_Column:
                            case E_INLET_TYPE.Packed:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.SensorTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.SensorTitle3 = "Press";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.ValveTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.ValveTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.FlowTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletCenter.IsFlow3Visible = false;
                                }
                                break;
                        }

                        switch ((E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[2])
                        {
                            case E_INLET_TYPE.Capillary:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.SensorTitle1 = "Total";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.SensorTitle2 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.SensorTitle3 = "Press";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.ValveTitle1 = "Total";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.ValveTitle2 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.ValveTitle3 = "Column";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.FlowTitle1 = "Purge";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.FlowTitle2 = "Split";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.FlowTitle3 = "Column";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsSensor2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsValve2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsValve3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsFlow2Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsFlow3Visible = true;
                                }
                                break;
                            case E_INLET_TYPE.Not_Installed:
                                break;
                            case E_INLET_TYPE.On_Column:
                            case E_INLET_TYPE.Packed:
                                {
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.SensorTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.SensorTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.SensorTitle3 = "Press";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.ValveTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.ValveTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.ValveTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.FlowTitle1 = "Column";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.FlowTitle2 = "-";
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.FlowTitle3 = "-";

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsSensor1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsSensor2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsSensor3Visible = true;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsValve1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsValve2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsValve3Visible = false;

                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsFlow1Visible = true;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsFlow2Visible = false;
                                    ViewModel_System_Calibration.ViewModel_System_CalibrationInletRear.IsFlow3Visible = false;
                                }
                                break;
                        }

                        #endregion Inlet

                        #endregion Calibration                       
                    }
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_INFORM:
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING:
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_DIAGDATA:
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_SERVICE:
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_SIGNAL:
                    {

                    }
                    break;
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING:
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_SLFEMSG:
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_SVCDATA:
                case YC_Const.E_PACKCODE.PACKCODE_YL6200_TIME_CTRL_SETTING:
                    {

                    }
                    break;
            }
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ViewModel_System_Calibration _ViewModel_System_Calibration = new ViewModel_System_Calibration();
        public ViewModel_System_Calibration ViewModel_System_Calibration { get { return _ViewModel_System_Calibration; } set { _ViewModel_System_Calibration = value; OnPropertyChanged("ViewModel_System_Calibration"); } }
        ViewModel_System_Config _ViewModel_System_Config = new ViewModel_System_Config();
        public ViewModel_System_Config ViewModel_System_Config { get { return _ViewModel_System_Config; } set { _ViewModel_System_Config = value; OnPropertyChanged("ViewModel_System_Config"); } }
        ViewModel_System_Diagnostics _ViewModel_System_Diagnostics = new ViewModel_System_Diagnostics();
        public ViewModel_System_Diagnostics ViewModel_System_Diagnostics { get { return _ViewModel_System_Diagnostics; } set { _ViewModel_System_Diagnostics = value; OnPropertyChanged("ViewModel_System_Diagnostics"); } }
        ViewModel_System_Information _ViewModel_System_Information = new ViewModel_System_Information();
        public ViewModel_System_Information ViewModel_System_Information { get { return _ViewModel_System_Information; } set { _ViewModel_System_Information = value; OnPropertyChanged("ViewModel_System_Information"); } }
        ViewModel_System_Method _ViewModel_System_Method = new ViewModel_System_Method();
        public ViewModel_System_Method ViewModel_System_Method { get { return _ViewModel_System_Method; } set { _ViewModel_System_Method = value; OnPropertyChanged("ViewModel_System_Method"); } }
        ViewModel_System_Settings _ViewModel_System_Settings = new ViewModel_System_Settings();
        public ViewModel_System_Settings ViewModel_System_Settings { get { return _ViewModel_System_Settings; } set { _ViewModel_System_Settings = value; OnPropertyChanged("ViewModel_System_Settings"); } }
        ViewModel_System_TimeControl _ViewModel_System_TimeControl = new ViewModel_System_TimeControl();
        public ViewModel_System_TimeControl ViewModel_System_TimeControl { get { return _ViewModel_System_TimeControl; } set { _ViewModel_System_TimeControl = value; OnPropertyChanged("ViewModel_System_TimeControl"); } }

        #region 좌측 메뉴 선택 속성

        E_SYSTEM_MENU_TYPE _SelectedMenu = E_SYSTEM_MENU_TYPE.INFORMATION;
        public E_SYSTEM_MENU_TYPE SelectedMenu { get { return _SelectedMenu; } set { _SelectedMenu = value; OnPropertyChanged("SelectedMenu"); } }

        E_SYSTEM_SUB_MENU_TYPE _SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.INFO_ROOT;
        public E_SYSTEM_SUB_MENU_TYPE SelectedSubMenu { get { return _SelectedSubMenu; } set { _SelectedSubMenu = value; OnPropertyChanged("SelectedSubMenu"); } }


        #endregion 좌측 메뉴 선택 속성

        #endregion Property

        #region Command

        #region 좌측 메뉴 선택 커멘드

        public RelayCommand MenuSelectCommand { get; set; }
        private void MenuSelectCommandAction(object param)
        {
            SelectedMenu = (E_SYSTEM_MENU_TYPE)param;

            switch (SelectedMenu)
            {
                case E_SYSTEM_MENU_TYPE.CALIBRATION:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.CALIB_OVEN;
                    }
                    break;
                case E_SYSTEM_MENU_TYPE.CONFIG:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.CONFIG_ROOT;
                    }
                    break;
                case E_SYSTEM_MENU_TYPE.DIAGNOSTICS:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.DIAG_ROOT;
                    }
                    break;
                case E_SYSTEM_MENU_TYPE.INFORMATION:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.INFO_ROOT;
                    }
                    break;
                case E_SYSTEM_MENU_TYPE.METHOD:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.METHOD_ROOT;
                    }
                    break;
                case E_SYSTEM_MENU_TYPE.SETTINGS:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.SETTINGS_ROOT;
                    }
                    break;
                case E_SYSTEM_MENU_TYPE.TIMECONTROL:
                    {
                        SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.TIME_CONTROL_ROOT;
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("ViewModelSystemPage : MenuSelectCommand to {0} Fired", SelectedMenu));
        }

        public RelayCommand SubMenuSelectCommand { get; set; }
        private void SubMenuSelectCommandAction(object param)
        {
            SelectedSubMenu = (E_SYSTEM_SUB_MENU_TYPE)param;

            //TODO :             
            Debug.WriteLine(string.Format("ViewModelSystemPage : SubMenuSelectCommand to {0} Fired", SelectedMenu));
        }
        #endregion 좌측 메뉴 선택 커멘드

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func

    }
}
