﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;


namespace ChroZenService
{
    public class ViewModelConfigPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelConfigPage()
        {
            MenuSelectCommand = new RelayCommand(MenuSelectCommandAction);
            SubMenuSelectCommand = new RelayCommand(SubMenuSelectCommandAction);

            EventManager.onPACKCODE_Receivce += PACKCODE_ReceivceEventHandler;
        }

        private void PACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, int nIndex)
        {
            Task.Factory.StartNew(() =>
            {
                switch (e_LC_PACK_CODE)
                {
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                        {
                            ViewModel_Config_OvenSettings.ActualTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fOven.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.fTempSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fOven.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[0] > 0) ViewModel_Config_AuxTemperature.strActAux_1 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_1 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[1] > 0) ViewModel_Config_AuxTemperature.strActAux_2 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_2 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[2] > 0) ViewModel_Config_AuxTemperature.strActAux_3 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_3 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[3] > 0) ViewModel_Config_AuxTemperature.strActAux_4 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[3].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_4 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[4] > 0) ViewModel_Config_AuxTemperature.strActAux_5 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[4].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_5 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[5] > 0) ViewModel_Config_AuxTemperature.strActAux_6 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[5].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_6 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[6] > 0) ViewModel_Config_AuxTemperature.strActAux_7 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[6].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_7 = "";
                            if (DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[7] > 0) ViewModel_Config_AuxTemperature.strActAux_8 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fAux[7].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            else ViewModel_Config_AuxTemperature.strActAux_8 = "";

                            ViewModel_Config_AuxFlow1.ActualFlow1 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_AuxFlow1.ActualFlow2 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_AuxFlow1.ActualFlow3 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_AuxFlow2.ActualFlow1 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[3].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_AuxFlow2.ActualFlow2 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[4].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_AuxFlow2.ActualFlow3 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[5].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_AuxFlow3.ActualFlow1 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[6].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_AuxFlow3.ActualFlow2 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[7].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_AuxFlow3.ActualFlow3 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_AuxFlow[8].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            #region InletSetting

                            ViewModel_Config_FrontInletSettings.ActualTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fInj[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_CenterInletSettings.ActualTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fInj[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_RearInletSettings.ActualTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fInj[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_FrontInletSettings.ActualColumnFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            ViewModel_Config_CenterInletSettings.ActualColumnFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[6].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            ViewModel_Config_RearInletSettings.ActualColumnFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[10].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);

                            if ((CHROZEN_GC_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState == CHROZEN_GC_STATE.RUN)
                            {
                                ViewModel_Config_FrontInletSettings.fColumnFlowSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Setflow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                ViewModel_Config_CenterInletSettings.fColumnFlowSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Setflow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                ViewModel_Config_RearInletSettings.fColumnFlowSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Setflow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);

                                ViewModel_Config_FrontInletSettings.fPressureSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Setpress[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                ViewModel_Config_CenterInletSettings.fPressureSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Setpress[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                ViewModel_Config_RearInletSettings.fPressureSet = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Setpress[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            }

                            ViewModel_Config_FrontInletSettings.ActualPressure = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Press[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            ViewModel_Config_CenterInletSettings.ActualPressure = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Press[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            ViewModel_Config_RearInletSettings.ActualPressure = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Press[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            ViewModel_Config_FrontInletSettings.ActualTotalFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_CenterInletSettings.ActualTotalFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[4].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_RearInletSettings.ActualTotalFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[8].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_FrontInletSettings.ActualSplitFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[3].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_CenterInletSettings.ActualSplitFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[7].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_RearInletSettings.ActualSplitFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[11].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_FrontInletSettings.ActualVelocity = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Velocity_Inj[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_CenterInletSettings.ActualVelocity = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Velocity_Inj[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_RearInletSettings.ActualVelocity = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Velocity_Inj[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            #endregion InletSetting
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING:
                        {
                            #region Oven Config

                            ViewModel_Config_OvenConfig.fMaxTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fMaxTemp;
                            ViewModel_Config_OvenConfig.fEquibTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fEquibTime;
                            ViewModel_Config_OvenConfig.bAutoReadyrun = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.bAutoReadyrun == 1 ? true : false;
                            ViewModel_Config_OvenConfig.bCryogenic = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.bCryogenic == 1 ? true : false;
                            ViewModel_Config_OvenConfig.bFastCryo = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.bFastCryo == 1 ? true : false;
                            ViewModel_Config_OvenConfig.runstart.bOnoff = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Runstart.bOnoff == 1 ? true : false;
                            ViewModel_Config_OvenConfig.runstart.iCount = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Runstart.iCount;
                            ViewModel_Config_OvenConfig.runstart.fCycletime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Runstart.fCycletime;
                            ViewModel_Config_OvenConfig.Postrun.bOnoff = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Postrun.bOnoff == 1 ? true : false;
                            ViewModel_Config_OvenConfig.Postrun.fTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Postrun.fTemp;
                            ViewModel_Config_OvenConfig.Postrun.fTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Postrun.fTime;

                            #endregion Oven Config

                            #region Oven Settings

                            ViewModel_Config_OvenSettings.bTempOnoff = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.bTempOnoff == 1 ? true : false;
                            ViewModel_Config_OvenSettings.fTempSet = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            //switch ((E_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState)
                            //{
                            //    case E_STATE.Run:
                            //        {

                            //        }
                            //        break;
                            //    default:
                            //        {
                            //            ViewModel_Config_OvenSettings.fInitTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fInitTime;
                            //        }
                            //        break;
                            //}

                            ViewModel_Config_OvenSettings.fMaxTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fMaxTemp;
                            ViewModel_Config_OvenSettings.fInitTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fInitTime;
                            ViewModel_Config_OvenSettings.btMode = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.btMode == 1 ? true : false;

                            ViewModel_Config_OvenSettings.rate_1 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[0].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_2 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[1].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_3 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[2].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_4 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[3].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_5 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[4].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_6 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[5].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_7 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[6].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_8 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[7].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_9 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[8].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_10 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[9].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.rate_11 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[10].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_12 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[11].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_13 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[12].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_14 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[13].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_15 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[14].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_16 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[15].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_17 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[16].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_18 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[17].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_19 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[18].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_20 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[19].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.rate_21 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[20].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_22 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[21].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_23 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[22].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_24 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[23].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.rate_25 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[24].fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.FinalTime_1 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[0].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_2 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[1].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_3 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[2].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_4 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[3].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_5 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[4].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_6 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[5].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_7 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[6].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_8 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[7].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_9 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[8].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_10 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[9].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.FinalTime_11 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[10].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_12 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[11].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_13 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[12].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_14 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[13].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_15 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[14].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_16 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[15].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_17 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[16].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_18 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[17].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_19 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[18].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_20 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[19].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.FinalTime_21 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[20].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_22 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[21].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_23 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[22].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_24 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[23].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTime_25 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[24].fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.FinalTemp_1 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[0].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_2 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[1].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_3 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[2].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_4 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[3].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_5 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[4].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_6 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[5].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_7 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[6].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_8 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[7].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_9 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[8].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_10 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[9].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.FinalTemp_11 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[10].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_12 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[11].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_13 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[12].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_14 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[13].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_15 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[14].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_16 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[15].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_17 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[16].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_18 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[17].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_19 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[18].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_20 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[19].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            ViewModel_Config_OvenSettings.FinalTemp_21 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[20].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_22 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[21].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_23 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[22].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_24 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[23].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            ViewModel_Config_OvenSettings.FinalTemp_25 = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[24].fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                            #endregion Oven Settings
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING:
                        {
                            switch (nIndex)
                            {
                                case 0:
                                    {
                                        ViewModel_Config_Signal1.fZero = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.fZero;
                                        ViewModel_Config_Signal1.fSensitivity = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.fSensitivity;

                                        ViewModel_Config_Signal1.bSignalChange = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.bSignalChange == 1 ? true : false;

                                        ViewModel_Config_Signal1.fTime_1 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[0].fTime;
                                        ViewModel_Config_Signal1.fTime_2 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[1].fTime;
                                        ViewModel_Config_Signal1.fTime_3 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[2].fTime;
                                        ViewModel_Config_Signal1.fTime_4 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[3].fTime;
                                        ViewModel_Config_Signal1.fTime_5 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[4].fTime;

                                        ViewModel_Config_Signal1.btDet_0 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.btInitDet;
                                        ViewModel_Config_Signal1.btDet_1 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[0].btDet;
                                        ViewModel_Config_Signal1.btDet_2 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[1].btDet;
                                        ViewModel_Config_Signal1.btDet_3 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[2].btDet;
                                        ViewModel_Config_Signal1.btDet_4 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[3].btDet;
                                        ViewModel_Config_Signal1.btDet_5 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received.packet.Prgm[4].btDet;
                                    }
                                    break;
                                case 1:
                                    {
                                        ViewModel_Config_Signal2.fZero = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.fZero;
                                        ViewModel_Config_Signal2.fSensitivity = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.fSensitivity;

                                        ViewModel_Config_Signal2.bSignalChange = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.bSignalChange == 1 ? true : false;

                                        ViewModel_Config_Signal2.fTime_1 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[0].fTime;
                                        ViewModel_Config_Signal2.fTime_2 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[1].fTime;
                                        ViewModel_Config_Signal2.fTime_3 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[2].fTime;
                                        ViewModel_Config_Signal2.fTime_4 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[3].fTime;
                                        ViewModel_Config_Signal2.fTime_5 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[4].fTime;

                                        ViewModel_Config_Signal2.btDet_0 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.btInitDet;
                                        ViewModel_Config_Signal2.btDet_1 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[0].btDet;
                                        ViewModel_Config_Signal2.btDet_2 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[1].btDet;
                                        ViewModel_Config_Signal2.btDet_3 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[2].btDet;
                                        ViewModel_Config_Signal2.btDet_4 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[3].btDet;
                                        ViewModel_Config_Signal2.btDet_5 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received.packet.Prgm[4].btDet;
                                    }
                                    break;
                                case 2:
                                    {
                                        ViewModel_Config_Signal3.fZero = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.fZero;
                                        ViewModel_Config_Signal3.fSensitivity = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.fSensitivity;

                                        ViewModel_Config_Signal3.bSignalChange = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.bSignalChange == 1 ? true : false;

                                        ViewModel_Config_Signal3.fTime_1 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[0].fTime;
                                        ViewModel_Config_Signal3.fTime_2 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[1].fTime;
                                        ViewModel_Config_Signal3.fTime_3 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[2].fTime;
                                        ViewModel_Config_Signal3.fTime_4 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[3].fTime;
                                        ViewModel_Config_Signal3.fTime_5 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[4].fTime;

                                        ViewModel_Config_Signal3.btDet_0 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.btInitDet;
                                        ViewModel_Config_Signal3.btDet_1 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[0].btDet;
                                        ViewModel_Config_Signal3.btDet_2 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[1].btDet;
                                        ViewModel_Config_Signal3.btDet_3 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[2].btDet;
                                        ViewModel_Config_Signal3.btDet_4 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[3].btDet;
                                        ViewModel_Config_Signal3.btDet_5 = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received.packet.Prgm[4].btDet;
                                    }
                                    break;
                            }

                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING:
                        {
                            ViewModel_Config_ValveInitialState.initState_1 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[0] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_2 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[1] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_3 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[2] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_4 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[3] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_5 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[4] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_6 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[5] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_7 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[6] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.initState_8 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.bInitState[7] > 0 ? true : false;

                            ViewModel_Config_ValveInitialState.initState_M1 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.btMultiInitState[0];
                            ViewModel_Config_ValveInitialState.initState_M2 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.btMultiInitState[1];

                            ViewModel_Config_ValveProgram.btState_1 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[0].btState;
                            ViewModel_Config_ValveProgram.btState_2 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[1].btState;
                            ViewModel_Config_ValveProgram.btState_3 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[2].btState;
                            ViewModel_Config_ValveProgram.btState_4 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[3].btState;
                            ViewModel_Config_ValveProgram.btState_5 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[4].btState;
                            ViewModel_Config_ValveProgram.btState_6 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[5].btState;
                            ViewModel_Config_ValveProgram.btState_7 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[6].btState;
                            ViewModel_Config_ValveProgram.btState_8 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[7].btState;
                            ViewModel_Config_ValveProgram.btState_9 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[8].btState;
                            ViewModel_Config_ValveProgram.btState_10 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[9].btState;
                            ViewModel_Config_ValveProgram.btState_11 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[10].btState;
                            ViewModel_Config_ValveProgram.btState_12 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[11].btState;
                            ViewModel_Config_ValveProgram.btState_13 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[12].btState;
                            ViewModel_Config_ValveProgram.btState_14 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[13].btState;
                            ViewModel_Config_ValveProgram.btState_15 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[14].btState;
                            ViewModel_Config_ValveProgram.btState_16 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[15].btState;
                            ViewModel_Config_ValveProgram.btState_17 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[16].btState;
                            ViewModel_Config_ValveProgram.btState_18 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[17].btState;
                            ViewModel_Config_ValveProgram.btState_19 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[18].btState;
                            ViewModel_Config_ValveProgram.btState_20 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[19].btState;

                            ViewModel_Config_ValveProgram.fTime_1 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[0].fTime;
                            ViewModel_Config_ValveProgram.fTime_2 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[1].fTime;
                            ViewModel_Config_ValveProgram.fTime_3 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[2].fTime;
                            ViewModel_Config_ValveProgram.fTime_4 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[3].fTime;
                            ViewModel_Config_ValveProgram.fTime_5 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[4].fTime;
                            ViewModel_Config_ValveProgram.fTime_6 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[5].fTime;
                            ViewModel_Config_ValveProgram.fTime_7 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[6].fTime;
                            ViewModel_Config_ValveProgram.fTime_8 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[7].fTime;
                            ViewModel_Config_ValveProgram.fTime_9 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[8].fTime;
                            ViewModel_Config_ValveProgram.fTime_10 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[9].fTime;
                            ViewModel_Config_ValveProgram.fTime_11 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[10].fTime;
                            ViewModel_Config_ValveProgram.fTime_12 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[11].fTime;
                            ViewModel_Config_ValveProgram.fTime_13 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[12].fTime;
                            ViewModel_Config_ValveProgram.fTime_14 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[13].fTime;
                            ViewModel_Config_ValveProgram.fTime_15 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[14].fTime;
                            ViewModel_Config_ValveProgram.fTime_16 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[15].fTime;
                            ViewModel_Config_ValveProgram.fTime_17 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[16].fTime;
                            ViewModel_Config_ValveProgram.fTime_18 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[17].fTime;
                            ViewModel_Config_ValveProgram.fTime_19 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[18].fTime;
                            ViewModel_Config_ValveProgram.fTime_20 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[19].fTime;

                            ViewModel_Config_ValveProgram.btNumber_1 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[0].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_2 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[1].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_3 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[2].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_4 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[3].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_5 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[4].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_6 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[5].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_7 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[6].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_8 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[7].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_9 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[8].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_10 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[9].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_11 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[10].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_12 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[11].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_13 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[12].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_14 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[13].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_15 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[14].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_16 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[15].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_17 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[16].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_18 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[17].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_19 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[18].btNumber;
                            ViewModel_Config_ValveProgram.btNumber_20 = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received.packet.Prgm[19].btNumber;
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG:
                        {
                            ViewModel_Config_ValveProgram.valveProgramPickerSource.Clear();

                            ViewModel_Config_ValveInitialState.type1_1 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[0] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_2 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[1] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_3 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[2] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_4 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[3] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_5 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[4] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_6 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[5] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_7 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[6] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_8 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btType1[7] > 0 ? true : false;

                            ViewModel_Config_ValveInitialState.type1_M1 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btMultiType[0] > 0 ? true : false;
                            ViewModel_Config_ValveInitialState.type1_M2 = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.ValveConfig.btMultiType[1] > 0 ? true : false;

                            if (ViewModel_Config_ValveInitialState.type1_1) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("1");
                            if (ViewModel_Config_ValveInitialState.type1_2) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("2");
                            if (ViewModel_Config_ValveInitialState.type1_3) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("3");
                            if (ViewModel_Config_ValveInitialState.type1_4) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("4");
                            if (ViewModel_Config_ValveInitialState.type1_5) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("5");
                            if (ViewModel_Config_ValveInitialState.type1_6) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("6");
                            if (ViewModel_Config_ValveInitialState.type1_7) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("7");
                            if (ViewModel_Config_ValveInitialState.type1_8) ViewModel_Config_ValveProgram.valveProgramPickerSource.Add("8");

                            ViewModel_Config_AuxTemperature.bMethanizer = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bMethanizer;
                            ViewModel_Config_AuxTemperature.bIsAux1Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[0] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux2Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[1] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux3Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[2] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux4Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[3] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux5Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[4] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux6Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[5] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux7Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[6] > 0;
                            ViewModel_Config_AuxTemperature.bIsAux8Enabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxTemp[7] > 0;

                            ViewModel_Config_AuxFlow1.bIsAuxEnabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxAPC[0] > 0;
                            ViewModel_Config_AuxFlow2.bIsAuxEnabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxAPC[1] > 0;
                            ViewModel_Config_AuxFlow3.bIsAuxEnabled = DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.bAuxAPC[2] > 0;

                            ViewModel_Config_FrontInletSettings.e_INLET_TYPE = (E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[0];
                            ViewModel_Config_CenterInletSettings.e_INLET_TYPE = (E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[1];
                            ViewModel_Config_RearInletSettings.e_INLET_TYPE = (E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[2];
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING:
                        {
                            ViewModel_Config_AuxTemperature.fTempSet_1 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[0];
                            ViewModel_Config_AuxTemperature.fTempSet_2 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[1];
                            ViewModel_Config_AuxTemperature.fTempSet_3 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[2];
                            ViewModel_Config_AuxTemperature.fTempSet_4 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[3];
                            ViewModel_Config_AuxTemperature.fTempSet_5 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[4];
                            ViewModel_Config_AuxTemperature.fTempSet_6 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[5];
                            ViewModel_Config_AuxTemperature.fTempSet_7 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[6];
                            ViewModel_Config_AuxTemperature.fTempSet_8 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempSet[7];

                            ViewModel_Config_AuxTemperature.fTempOnoff_1 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[0] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_2 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[1] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_3 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[2] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_4 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[3] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_5 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[4] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_6 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[5] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_7 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[6] == 1 ? true : false;
                            ViewModel_Config_AuxTemperature.fTempOnoff_8 = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received.packet.fTempOnoff[7] == 1 ? true : false;
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING:
                        {
                            switch (nIndex)
                            {
                                case 0:
                                    {
                                        ViewModel_Config_AuxFlow1.btAuxGas = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.btAuxGas;
                                        ViewModel_Config_AuxFlow1.fFlowSet1 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.fFlowSet1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_AuxFlow1.fFlowSet2 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.fFlowSet2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_AuxFlow1.fFlowSet3 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.fFlowSet3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_Config_AuxFlow1.fFlowOnoff1 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.fFlowOnoff1;
                                        ViewModel_Config_AuxFlow1.fFlowOnoff2 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.fFlowOnoff2;
                                        ViewModel_Config_AuxFlow1.fFlowOnoff3 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received.packet.lcdAuxApc.fFlowOnoff3;
                                    }
                                    break;
                                case 1:
                                    {
                                        ViewModel_Config_AuxFlow2.btAuxGas = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.btAuxGas;
                                        ViewModel_Config_AuxFlow2.fFlowSet1 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.fFlowSet1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_AuxFlow2.fFlowSet2 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.fFlowSet2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_AuxFlow2.fFlowSet3 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.fFlowSet3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_Config_AuxFlow2.fFlowOnoff1 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.fFlowOnoff1;
                                        ViewModel_Config_AuxFlow2.fFlowOnoff2 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.fFlowOnoff2;
                                        ViewModel_Config_AuxFlow2.fFlowOnoff3 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received.packet.lcdAuxApc.fFlowOnoff3;
                                    }
                                    break;
                                case 2:
                                    {
                                        ViewModel_Config_AuxFlow3.btAuxGas = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.btAuxGas;
                                        ViewModel_Config_AuxFlow3.fFlowSet1 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.fFlowSet1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_AuxFlow3.fFlowSet2 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.fFlowSet2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_AuxFlow3.fFlowSet3 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.fFlowSet3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_Config_AuxFlow3.fFlowOnoff1 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.fFlowOnoff1;
                                        ViewModel_Config_AuxFlow3.fFlowOnoff2 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.fFlowOnoff2;
                                        ViewModel_Config_AuxFlow3.fFlowOnoff3 = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received.packet.lcdAuxApc.fFlowOnoff3;
                                    }
                                    break;
                            }
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING:
                        {
                            switch (nIndex)
                            {
                                case 0:
                                    {
                                        #region Config

                                        ViewModel_Config_FrontInletConfig.btCarriergas = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.btCarriergas;
                                        ViewModel_Config_FrontInletConfig.btApcMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.btApcMode;
                                        ViewModel_Config_FrontInletConfig.ConnectionToDet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.__btConnection;
                                        ViewModel_Config_FrontInletConfig.fLength = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fLength.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletConfig.fDiameter = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fDiameter.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_FrontInletConfig.fThickness = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fThickness.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_FrontInletConfig.bGasSaverMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.bGasSaverMode == 1 ? true : false;
                                        ViewModel_Config_FrontInletConfig.fGasSaverFlow = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fGasSaverFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_FrontInletConfig.fGasSaverTime = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fGasSaverTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletConfig.fPressureCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fPressCorrect.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                                        ViewModel_Config_FrontInletConfig.bPressCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.bPressCorrect == 1 ? true : false;
                                        ViewModel_Config_FrontInletConfig.bVacuumCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.bVacuumCorrect == 1 ? true : false;

                                        #endregion Config

                                        #region Setting

                                        ViewModel_Config_FrontInletSettings.fTempSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fTempSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletSettings.fTempOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fTempOnoff == 1 ? true : false;

                                        if ((CHROZEN_GC_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState != CHROZEN_GC_STATE.RUN)
                                        {
                                            ViewModel_Config_FrontInletSettings.fPressureSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fPressureSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                            ViewModel_Config_FrontInletSettings.fColumnFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fColumnFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);

                                        }

                                        ViewModel_Config_FrontInletSettings.btInjMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.btInjMode == 1 ? true : false;
                                        ViewModel_Config_FrontInletSettings.fTotalFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fTotalFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletSettings.fSplitFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fSplitFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletSettings.iSplitratio = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.iSplitratio.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                                        ViewModel_Config_FrontInletSettings.fPulsed_FlowPressSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fPulsed_FlowPressSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletSettings.fSplitOnTime = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fSplitOnTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletSettings.fPulsed_Time = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fPulsed_Time.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_FrontInletSettings.fTotalFlowOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fTotalFlowOnoff == 1 ? true : false;

                                        ViewModel_Config_FrontInletSettings.fColumnFlowOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fColumnFlowOnoff == 1 ? true : false;
                                        ViewModel_Config_FrontInletSettings.fPressureOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.fPressureOnoff == 1 ? true : false;

                                        ViewModel_Config_FrontInletSettings.btTempMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.btTempMode;

                                        #endregion Setting

                                    }
                                    break;
                                case 1:
                                    {
                                        ViewModel_Config_CenterInletConfig.btCarriergas = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btCarriergas;
                                        ViewModel_Config_CenterInletConfig.btApcMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btApcMode;
                                        ViewModel_Config_CenterInletConfig.ConnectionToDet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.__btConnection;
                                        ViewModel_Config_CenterInletConfig.fLength = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fLength.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletConfig.fDiameter = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fDiameter.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_CenterInletConfig.fThickness = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fThickness.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_CenterInletConfig.bGasSaverMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.bGasSaverMode == 1 ? true : false;
                                        ViewModel_Config_CenterInletConfig.fGasSaverFlow = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fGasSaverFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_CenterInletConfig.fGasSaverTime = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fGasSaverTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletConfig.fPressureCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fPressCorrect.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                                        ViewModel_Config_CenterInletConfig.bPressCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.bPressCorrect == 1 ? true : false;
                                        ViewModel_Config_CenterInletConfig.bVacuumCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.bVacuumCorrect == 1 ? true : false;

                                        #region Setting

                                        ViewModel_Config_CenterInletSettings.fTempSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fTempSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletSettings.fTempOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fTempOnoff == 1 ? true : false;

                                        if ((CHROZEN_GC_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState != CHROZEN_GC_STATE.RUN)
                                        {
                                            ViewModel_Config_CenterInletSettings.fPressureSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fPressureSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                            ViewModel_Config_CenterInletSettings.fColumnFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fColumnFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);

                                        }

                                        ViewModel_Config_CenterInletSettings.btInjMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btInjMode == 1 ? true : false;
                                        ViewModel_Config_CenterInletSettings.fTotalFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fTotalFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletSettings.fSplitFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fSplitFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletSettings.iSplitratio = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.iSplitratio.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                                        ViewModel_Config_CenterInletSettings.fPulsed_FlowPressSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fPulsed_FlowPressSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletSettings.fSplitOnTime = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fSplitOnTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletSettings.fPulsed_Time = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fPulsed_Time.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_CenterInletSettings.fTotalFlowOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fTotalFlowOnoff == 1 ? true : false;

                                        ViewModel_Config_CenterInletSettings.fColumnFlowOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fColumnFlowOnoff == 1 ? true : false;
                                        ViewModel_Config_CenterInletSettings.fPressureOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.fPressureOnoff == 1 ? true : false;

                                        ViewModel_Config_CenterInletSettings.btTempMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btTempMode;

                                        #endregion Setting

                                    }
                                    break;
                                case 2:
                                    {
                                        ViewModel_Config_RearInletConfig.btCarriergas = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.btCarriergas;
                                        ViewModel_Config_RearInletConfig.btApcMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.btApcMode;
                                        ViewModel_Config_RearInletConfig.ConnectionToDet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.__btConnection;
                                        ViewModel_Config_RearInletConfig.fLength = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fLength.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletConfig.fDiameter = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fDiameter.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_RearInletConfig.fThickness = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fThickness.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_RearInletConfig.bGasSaverMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.bGasSaverMode == 1 ? true : false;
                                        ViewModel_Config_RearInletConfig.fGasSaverFlow = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fGasSaverFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                        ViewModel_Config_RearInletConfig.fGasSaverTime = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fGasSaverTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletConfig.fPressureCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fPressCorrect.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                                        ViewModel_Config_RearInletConfig.bPressCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.bPressCorrect == 1 ? true : false;
                                        ViewModel_Config_RearInletConfig.bVacuumCorrect = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.bVacuumCorrect == 1 ? true : false;

                                        #region Setting

                                        ViewModel_Config_RearInletSettings.fTempSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fTempSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletSettings.fTempOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fTempOnoff == 1 ? true : false;

                                        if ((CHROZEN_GC_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState != CHROZEN_GC_STATE.RUN)
                                        {
                                            ViewModel_Config_RearInletSettings.fPressureSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fPressureSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                                            ViewModel_Config_RearInletSettings.fColumnFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fColumnFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);

                                        }

                                        ViewModel_Config_RearInletSettings.btInjMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.btInjMode == 1 ? true : false;
                                        ViewModel_Config_RearInletSettings.fTotalFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fTotalFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletSettings.fSplitFlowSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fSplitFlowSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletSettings.iSplitratio = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.iSplitratio.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                                        ViewModel_Config_RearInletSettings.fPulsed_FlowPressSet = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fPulsed_FlowPressSet.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletSettings.fSplitOnTime = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fSplitOnTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletSettings.fPulsed_Time = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fPulsed_Time.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_Config_RearInletSettings.fTotalFlowOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fTotalFlowOnoff == 1 ? true : false;

                                        ViewModel_Config_RearInletSettings.fColumnFlowOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fColumnFlowOnoff == 1 ? true : false;
                                        ViewModel_Config_RearInletSettings.fPressureOnoff = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.fPressureOnoff == 1 ? true : false;

                                        ViewModel_Config_RearInletSettings.btTempMode = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received.packet.btTempMode;

                                        #endregion Setting
                                    }
                                    break;
                            }
                        }
                        break;
                }
            });
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        #region Oven
        ViewModel_Config_OvenConfig _ViewModel_Config_OvenConfig = new ViewModel_Config_OvenConfig();
        public ViewModel_Config_OvenConfig ViewModel_Config_OvenConfig { get { return _ViewModel_Config_OvenConfig; } set { _ViewModel_Config_OvenConfig = value; OnPropertyChanged("ViewModel_Config_OvenConfig"); } }
        ViewModel_Config_OvenSettings _ViewModel_Config_OvenSettings = new ViewModel_Config_OvenSettings();
        public ViewModel_Config_OvenSettings ViewModel_Config_OvenSettings { get { return _ViewModel_Config_OvenSettings; } set { _ViewModel_Config_OvenSettings = value; OnPropertyChanged("ViewModel_Config_OvenSettings"); } }
        #endregion Oven

        #region Inlet
        ViewModel_Config_InletConfig _ViewModel_Config_FrontInletConfig = new ViewModel_Config_InletConfig();
        public ViewModel_Config_InletConfig ViewModel_Config_FrontInletConfig { get { return _ViewModel_Config_FrontInletConfig; } set { _ViewModel_Config_FrontInletConfig = value; OnPropertyChanged("ViewModel_Config_FrontInletConfig"); } }
        ViewModel_Config_InletConfig _ViewModel_Config_CenterInletConfig = new ViewModel_Config_InletConfig();
        public ViewModel_Config_InletConfig ViewModel_Config_CenterInletConfig { get { return _ViewModel_Config_CenterInletConfig; } set { _ViewModel_Config_CenterInletConfig = value; OnPropertyChanged("ViewModel_Config_CenterInletConfig"); } }
        ViewModel_Config_InletConfig _ViewModel_Config_RearInletConfig = new ViewModel_Config_InletConfig();
        public ViewModel_Config_InletConfig ViewModel_Config_RearInletConfig { get { return _ViewModel_Config_RearInletConfig; } set { _ViewModel_Config_RearInletConfig = value; OnPropertyChanged("ViewModel_Config_RearInletConfig"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_FrontInletSettings = new ViewModel_Config_InletSettings();
        public ViewModel_Config_InletSettings ViewModel_Config_FrontInletSettings { get { return _ViewModel_Config_FrontInletSettings; } set { _ViewModel_Config_FrontInletSettings = value; OnPropertyChanged("ViewModel_Config_FrontInletSettings"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_CenterInletSettings = new ViewModel_Config_InletSettings();
        public ViewModel_Config_InletSettings ViewModel_Config_CenterInletSettings { get { return _ViewModel_Config_CenterInletSettings; } set { _ViewModel_Config_CenterInletSettings = value; OnPropertyChanged("ViewModel_Config_CenterInletSettings"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_RearInletSettings = new ViewModel_Config_InletSettings();
        public ViewModel_Config_InletSettings ViewModel_Config_RearInletSettings { get { return _ViewModel_Config_RearInletSettings; } set { _ViewModel_Config_RearInletSettings = value; OnPropertyChanged("ViewModel_Config_RearInletSettings"); } }
        #endregion Inlet

        #region Detector
        ViewModel_Config_DetConfig _ViewModel_Config_FrontDetConfig = new ViewModel_Config_DetConfig();
        public ViewModel_Config_DetConfig ViewModel_Config_FrontDetConfig { get { return _ViewModel_Config_FrontDetConfig; } set { _ViewModel_Config_FrontDetConfig = value; OnPropertyChanged("ViewModel_Config_FrontDetConfig"); } }
        ViewModel_Config_DetConfig _ViewModel_Config_CenterDetConfig = new ViewModel_Config_DetConfig();
        public ViewModel_Config_DetConfig ViewModel_Config_CenterDetConfig { get { return _ViewModel_Config_CenterDetConfig; } set { _ViewModel_Config_CenterDetConfig = value; OnPropertyChanged("ViewModel_Config_CenterDetConfig"); } }
        ViewModel_Config_DetConfig _ViewModel_Config_RearDetConfig = new ViewModel_Config_DetConfig();
        public ViewModel_Config_DetConfig ViewModel_Config_RearDetConfig { get { return _ViewModel_Config_RearDetConfig; } set { _ViewModel_Config_RearDetConfig = value; OnPropertyChanged("ViewModel_Config_RearDetConfig"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_FrontDetSettings = new ViewModel_Config_DetSettings();
        public ViewModel_Config_DetSettings ViewModel_Config_FrontDetSettings { get { return _ViewModel_Config_FrontDetSettings; } set { _ViewModel_Config_FrontDetSettings = value; OnPropertyChanged("ViewModel_Config_FrontDetSettings"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_CenterDetSettings = new ViewModel_Config_DetSettings();
        public ViewModel_Config_DetSettings ViewModel_Config_CenterDetSettings { get { return _ViewModel_Config_CenterDetSettings; } set { _ViewModel_Config_CenterDetSettings = value; OnPropertyChanged("ViewModel_Config_CenterDetSettings"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_RearDetSettings = new ViewModel_Config_DetSettings();
        public ViewModel_Config_DetSettings ViewModel_Config_RearDetSettings { get { return _ViewModel_Config_RearDetSettings; } set { _ViewModel_Config_RearDetSettings = value; OnPropertyChanged("ViewModel_Config_RearDetSettings"); } }
        #endregion Detector

        #region Signal
        ViewModel_Config_Signal _ViewModel_Config_Signal1 = new ViewModel_Config_Signal(1);
        public ViewModel_Config_Signal ViewModel_Config_Signal1 { get { return _ViewModel_Config_Signal1; } set { _ViewModel_Config_Signal1 = value; OnPropertyChanged("ViewModel_Config_Signal1"); } }
        ViewModel_Config_Signal _ViewModel_Config_Signal2 = new ViewModel_Config_Signal(2);
        public ViewModel_Config_Signal ViewModel_Config_Signal2 { get { return _ViewModel_Config_Signal2; } set { _ViewModel_Config_Signal2 = value; OnPropertyChanged("ViewModel_Config_Signal2"); } }
        ViewModel_Config_Signal _ViewModel_Config_Signal3 = new ViewModel_Config_Signal(3);
        public ViewModel_Config_Signal ViewModel_Config_Signal3 { get { return _ViewModel_Config_Signal3; } set { _ViewModel_Config_Signal3 = value; OnPropertyChanged("ViewModel_Config_Signal3"); } }
        #endregion Signal

        #region Valve
        ViewModel_Config_ValveInitialState _ViewModel_Config_ValveInitialState = new ViewModel_Config_ValveInitialState();
        public ViewModel_Config_ValveInitialState ViewModel_Config_ValveInitialState { get { return _ViewModel_Config_ValveInitialState; } set { _ViewModel_Config_ValveInitialState = value; OnPropertyChanged("ViewModel_Config_ValveInitialState"); } }
        ViewModel_Config_ValveProgram _ViewModel_Config_ValveProgram = new ViewModel_Config_ValveProgram();
        public ViewModel_Config_ValveProgram ViewModel_Config_ValveProgram { get { return _ViewModel_Config_ValveProgram; } set { _ViewModel_Config_ValveProgram = value; OnPropertyChanged("ViewModel_Config_ValveProgram"); } }
        #endregion Valve

        #region AuxFlow
        ViewModel_Config_AuxFlow _ViewModel_Config_AuxFlow1 = new ViewModel_Config_AuxFlow();
        public ViewModel_Config_AuxFlow ViewModel_Config_AuxFlow1 { get { return _ViewModel_Config_AuxFlow1; } set { _ViewModel_Config_AuxFlow1 = value; OnPropertyChanged("ViewModel_Config_AuxFlow1"); } }
        ViewModel_Config_AuxFlow _ViewModel_Config_AuxFlow2 = new ViewModel_Config_AuxFlow();
        public ViewModel_Config_AuxFlow ViewModel_Config_AuxFlow2 { get { return _ViewModel_Config_AuxFlow2; } set { _ViewModel_Config_AuxFlow2 = value; OnPropertyChanged("ViewModel_Config_AuxFlow2"); } }
        ViewModel_Config_AuxFlow _ViewModel_Config_AuxFlow3 = new ViewModel_Config_AuxFlow();
        public ViewModel_Config_AuxFlow ViewModel_Config_AuxFlow3 { get { return _ViewModel_Config_AuxFlow3; } set { _ViewModel_Config_AuxFlow3 = value; OnPropertyChanged("ViewModel_Config_AuxFlow3"); } }

        ViewModel_Config_AuxTemperature _ViewModel_Config_AuxTemperature = new ViewModel_Config_AuxTemperature();
        public ViewModel_Config_AuxTemperature ViewModel_Config_AuxTemperature { get { return _ViewModel_Config_AuxTemperature; } set { _ViewModel_Config_AuxTemperature = value; OnPropertyChanged("ViewModel_Config_AuxTemperature"); } }
        #endregion AuxFlow

        #region 좌측 메뉴 선택 속성

        E_CONFIG_MENU_TYPE _SelectedMenu = E_CONFIG_MENU_TYPE.OVEN;
        public E_CONFIG_MENU_TYPE SelectedMenu { get { return _SelectedMenu; } set { _SelectedMenu = value; OnPropertyChanged("SelectedMenu"); } }

        E_CONFIG_SUB_MENU_TYPE _SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.OVEN_CONFIG;
        public E_CONFIG_SUB_MENU_TYPE SelectedSubMenu { get { return _SelectedSubMenu; } set { _SelectedSubMenu = value; OnPropertyChanged("SelectedSubMenu"); } }

        #endregion 좌측 메뉴 선택 속성


        #endregion Property

        #region Command

        #region 좌측 메뉴 선택 커멘드

        public RelayCommand MenuSelectCommand { get; set; }
        private void MenuSelectCommandAction(object param)
        {
            SelectedMenu = (E_CONFIG_MENU_TYPE)param;
            switch (SelectedMenu)
            {
                case E_CONFIG_MENU_TYPE.AUX:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.AUX_TEMPERATURE;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.CENTER_DET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.CENTER_DET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.CENTER_INLET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.CENTER_INLET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.FRONT_DET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.FRONT_DET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.FRONT_INLET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.FRONT_INLET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.OVEN:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.OVEN_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.REAR_DET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.REAR_DET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.REAR_INLET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.REAR_INLET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.SIGNAL:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.SIGNAL1;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.VALVE:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.VALVE_INIT_STATE;
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("ViewModelConfigPage : MenuSelectCommand to {0} Fired", SelectedMenu));
        }

        public RelayCommand SubMenuSelectCommand { get; set; }
        private void SubMenuSelectCommandAction(object param)
        {
            SelectedSubMenu = (E_CONFIG_SUB_MENU_TYPE)param;
            //TODO :             
            Debug.WriteLine(string.Format("ViewModelConfigPage : SubMenuSelectCommand to {0} Fired", SelectedSubMenu));
        }

        #endregion 좌측 메뉴 선택 커멘드

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func

    }
}
