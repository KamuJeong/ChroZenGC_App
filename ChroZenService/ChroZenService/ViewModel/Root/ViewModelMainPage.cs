using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModelMainPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        TCPManager tcpManager;

        public ViewModelMainPage()
        {
            SelectHomeMenu = new RelayCommand(SelectHomeMenuAction);
            SelectSystemMenu = new RelayCommand(SelectSystemMenuAction);
            SelectConfigMenu = new RelayCommand(SelectConfigMenuAction);
            ErrorSelect = new RelayCommand(ErrorSelectAction);
            ErrorResetSelect = new RelayCommand(ErrorResetSelectAction);
            ErrorCloseSelect = new RelayCommand(ErrorCloseSelectAction);

            EventManager.onPACKCODE_Receivce += PACKCODE_ReceivceEventHandler;
            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
            EventManager.onKeyPadRequest += KeyPadRequest_EventHandler;
            //tcpManager = new TCPManager();
            //Task.Factory.StartNew(() => { tcpManager.ConnectDevice("192.168.0.88", 4242); });
        }

        private void KeyPadRequest_EventHandler(ViewModel_KeyPad viewModel_KeyPad)
        {
            ViewModel_KeyPad.CopyFrom(viewModel_KeyPad);
        }

        private void PACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet)
        {
            Task.Factory.StartNew(() =>
            {
                switch (e_LC_PACK_CODE)
                {
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                        {
                            #region MainPage

                            #region MainTop

                            ViewModel_MainTop.DeviceRuntimeCurrent = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.fRunTime.ToString("F1");
                            ViewModel_MainTop.DeviceRunStartCurrent = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.iCurrentRun.ToString();
                            ViewModel_MainTop.DeviceRunStartTotal = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btPrgmStep.ToString();

                            E_STATE state = (E_STATE)((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btState;
                            ViewModel_MainTop.CHROZEN_GC_STATE_String = state.ToString();
                            switch (state)
                            {
                                case E_STATE.AutoReadyRun:
                                case E_STATE.Run:
                                case E_STATE.Calibration:
                                case E_STATE.ColumnCondition:
                                case E_STATE.Diagnostics:
                                case E_STATE.GasSaver:
                                case E_STATE.PostRun:
                                case E_STATE.PowerSaveMode:
                                    {
                                        ViewModel_MainTop.StateColorBrush = ViewModel_MainTop.RunColorBrush;
                                    }
                                    break;
                                case E_STATE.Error:
                                    {
                                        ViewModel_MainTop.StateColorBrush = ViewModel_MainTop.ErrorColorBrush;
                                    }
                                    break;
                                case E_STATE.Initilize:
                                case E_STATE.Ready:
                                    {
                                        ViewModel_MainTop.StateColorBrush = ViewModel_MainTop.ReadyColorBrush;
                                    }
                                    break;
                                case E_STATE.NotReady:
                                case E_STATE.Unknown:
                                    {
                                        ViewModel_MainTop.StateColorBrush = ViewModel_MainTop.NotReadyColorBrush;
                                    }
                                    break;
                            }
                            #endregion MainTop

                            #region MainCenter

                            //오븐 온도
                            ViewModel_MainCenter.OvenTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fOven.ToString("F2");

                            //선택된 인렛 온도
                            if (ViewModel_MainSide_Left.IsTopVisible)
                            {
                                ViewModel_MainCenter.SelectedInletTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fInj[0].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Left.IsCenterVisible)
                            {
                                ViewModel_MainCenter.SelectedInletTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fInj[1].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Left.IsBottomVisible)
                            {
                                ViewModel_MainCenter.SelectedInletTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fInj[2].ToString("F0");
                            }

                            //선택된 디텍터 온도
                            if (ViewModel_MainSide_Right.IsTopVisible)
                            {
                                ViewModel_MainCenter.SelectedDetTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fDet[0].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Right.IsCenterVisible)
                            {
                                ViewModel_MainCenter.SelectedDetTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fDet[1].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Right.IsBottomVisible)
                            {
                                ViewModel_MainCenter.SelectedDetTemperature = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fDet[2].ToString("F0");
                            }

                            //Step
                            ViewModel_MainCenter.Step = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btStep.ToString();

                            #endregion MainCenter

                            #region MainLeft

                            ViewModel_MainSide_Left.TopFlow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_InjFlow[0 * 4 + 2].ToString("F2");
                            ViewModel_MainSide_Left.TopPressure = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_Press[0].ToString("F2");

                            ViewModel_MainSide_Left.CenterFlow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_InjFlow[0 * 4 + 2].ToString("F2");
                            ViewModel_MainSide_Left.CenterPressure = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_Press[1].ToString("F2");

                            ViewModel_MainSide_Left.BottomFlow = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_InjFlow[0 * 4 + 2].ToString("F2");
                            ViewModel_MainSide_Left.BottomPressure = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_Press[2].ToString("F2");

                            #endregion MainLeft

                            #region MainRight

                            ViewModel_MainSide_Right.TopSignalStrength = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.fSignal[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[0])
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow3Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopFlow1Name = "Air";
                                        ViewModel_MainSide_Right.TopFlow2Name = "H2";
                                        ViewModel_MainSide_Right.TopFlow3Name = "MakeUp";

                                        ViewModel_MainSide_Right.TopIsFlow1Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = true;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow3Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopFlow1Name = "Air2";
                                        ViewModel_MainSide_Right.TopFlow2Name = "Air1";
                                        ViewModel_MainSide_Right.TopFlow3Name = "H2";

                                        ViewModel_MainSide_Right.TopIsFlow1Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = true;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopFlow1Name = "Ref.";
                                        ViewModel_MainSide_Right.TopFlow2Name = "Sam.";

                                        ViewModel_MainSide_Right.TopIsFlow1Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = false;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.ECD:
                                case E_DET_TYPE.uECD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopFlow1Name = "Mkup";

                                        ViewModel_MainSide_Right.TopIsFlow1Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = false;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = false;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.PDD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopIsFlow1Using = false;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = false;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = false;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                            }

                            ViewModel_MainSide_Right.CenterSignalStrength = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.fSignal[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[1])
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow3Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterFlow1Name = "Air";
                                        ViewModel_MainSide_Right.CenterFlow2Name = "H2";
                                        ViewModel_MainSide_Right.CenterFlow3Name = "MakeUp";

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = true;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow3Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterFlow1Name = "Air2";
                                        ViewModel_MainSide_Right.CenterFlow2Name = "Air1";
                                        ViewModel_MainSide_Right.CenterFlow3Name = "H2";

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = true;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterFlow1Name = "Ref.";
                                        ViewModel_MainSide_Right.CenterFlow2Name = "Sam.";

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = false;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.ECD:
                                case E_DET_TYPE.uECD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterFlow1Name = "Mkup";

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = false;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = false;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.PDD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = false;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = false;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = false;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                            }

                            ViewModel_MainSide_Right.BottomSignalStrength = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.fSignal[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[2])
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow3Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.BottomFlow1Name = "Air";
                                        ViewModel_MainSide_Right.BottomFlow2Name = "H2";
                                        ViewModel_MainSide_Right.BottomFlow3Name = "MakeUp";

                                        ViewModel_MainSide_Right.BottomIsFlow1Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow2Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow3Using = true;
                                        ViewModel_MainSide_Right.BottomSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow3Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.BottomFlow1Name = "Air2";
                                        ViewModel_MainSide_Right.BottomFlow2Name = "Air1";
                                        ViewModel_MainSide_Right.BottomFlow3Name = "H2";

                                        ViewModel_MainSide_Right.BottomIsFlow1Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow2Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow3Using = true;
                                        ViewModel_MainSide_Right.BottomSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow2Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.BottomFlow1Name = "Ref.";
                                        ViewModel_MainSide_Right.BottomFlow2Name = "Sam.";

                                        ViewModel_MainSide_Right.BottomIsFlow1Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow2Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow3Using = false;
                                        ViewModel_MainSide_Right.BottomSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.ECD:
                                case E_DET_TYPE.uECD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.BottomFlow1Name = "Mkup";

                                        ViewModel_MainSide_Right.BottomIsFlow1Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow2Using = false;
                                        ViewModel_MainSide_Right.BottomIsFlow3Using = false;
                                        ViewModel_MainSide_Right.BottomSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.PDD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.BottomIsFlow1Using = false;
                                        ViewModel_MainSide_Right.BottomIsFlow2Using = false;
                                        ViewModel_MainSide_Right.BottomIsFlow3Using = false;
                                        ViewModel_MainSide_Right.BottomSignalUnit = "mV";
                                    }
                                    break;
                            }

                            #endregion MainRight

                            //ViewModel_MainSide_Left.IsTopAvailabe =
                            //    ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.d
                            #endregion MainPage
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING:
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING:
                        {
                            APC_MODE aPC_MODE = (APC_MODE)((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.btApcMode;
                            switch ((MAIN_SIDE_ELEMENT_TYPE)((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.btPortNo)
                            {
                                case MAIN_SIDE_ELEMENT_TYPE.TOP:
                                    {
                                        ViewModel_MainSide_Left.TopSplitRatio = string.Format(" 1 / {0}", ((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.iSplitratio.ToString());
                                        ViewModel_MainSide_Left.TopCarrierGasType = ((CARRIER_GAS_TYPE)((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.btCarriergas).ToString();
                                        ViewModel_MainSide_Left.TopApcMode = aPC_MODE.ToString().Replace("_", ".");
                                    }
                                    break;
                                case MAIN_SIDE_ELEMENT_TYPE.CENTER:
                                    {
                                        ViewModel_MainSide_Left.CenterSplitRatio = string.Format(" 1 / {0}", ((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.iSplitratio.ToString());
                                        ViewModel_MainSide_Left.CenterCarrierGasType = ((CARRIER_GAS_TYPE)((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.btCarriergas).ToString();
                                        ViewModel_MainSide_Left.CenterApcMode = aPC_MODE.ToString().Replace("_", ".");
                                    }
                                    break;
                                case MAIN_SIDE_ELEMENT_TYPE.BOTTOM:
                                    {
                                        ViewModel_MainSide_Left.BottomSplitRatio = string.Format(" 1 / {0}", ((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.iSplitratio.ToString());
                                        ViewModel_MainSide_Left.BottomCarrierGasType = ((CARRIER_GAS_TYPE)((T_PACKCODE_CHROZEN_INLET_SETTING)packet).packet.btCarriergas).ToString();
                                        ViewModel_MainSide_Left.BottomApcMode = aPC_MODE.ToString().Replace("_", ".");
                                    }
                                    break;
                            }
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_SIGNAL:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_DIAG:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_SIGNAL:
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK:
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING:
                        {
                            #region MainPage

                            #region MainTop

                            ViewModel_MainTop.DeviceRuntimeTotal = ((T_PACKCODE_CHROZEN_OVEN_SETTING)packet).packet.fTotalRunTime.ToString("F1");

                            #endregion MainTop

                            //T_PACKCODE_CHROZEN_OVEN_SETTING m_packet = ((T_PACKCODE_CHROZEN_OVEN_SETTING)packet);
                            //m_packet.packet.Prgm

                            #endregion MainPage
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SPECIAL_FUNCTION:
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG:
                        {
                            #region MainPage

                            #region MainLeft

                            ViewModel_MainSide_Left.IsTopAvailable =
                                (E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[0] == E_INLET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Left.IsCenterAvailable =
                                 (E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[1] == E_INLET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Left.IsBottomAvailable =
                                 (E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[2] == E_INLET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Left.TopType = ((E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[0]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Left.CenterType = ((E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[1]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Left.BottomType = ((E_INLET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btInlet[2]).ToString().Replace("_", " ");


                            #endregion MainLeft

                            #region MainCenter

                            ViewModel_MainCenter.OvenTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fOven.ToString("F2");

                            #endregion MainCenter

                            #region MainRight

                            ViewModel_MainSide_Right.IsTopAvailable =
                                (E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[0] == E_DET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Right.IsCenterAvailable =
                                (E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[1] == E_DET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Right.IsBottomAvailable =
                                (E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[2] == E_DET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Right.TopType = ((E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[0]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Right.CenterType = ((E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[1]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Right.BottomType = ((E_DET_TYPE)((T_PACKCODE_CHROZEN_SYSTEM_CONFIG)packet).packet.btDet[2]).ToString().Replace("_", " ");

                            //ViewModelConfigPage.ViewModel_Config_FrontDetConfig.
                            #endregion MainRight

                            #endregion MainPage
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
            });

        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ViewModel_MainTop _ViewModel_MainTop = new ViewModel_MainTop();
        public ViewModel_MainTop ViewModel_MainTop { get { return _ViewModel_MainTop; } set { ViewModel_MainTop = value; OnPropertyChanged("ViewModel_MainTop"); } }

        ViewModel_MainBottom _ViewModel_MainBottom = new ViewModel_MainBottom();
        public ViewModel_MainBottom ViewModel_MainBottom { get { return _ViewModel_MainBottom; } set { ViewModel_MainBottom = value; OnPropertyChanged("ViewModel_MainBottom"); } }

        ViewModel_MainCenter _ViewModel_MainCenter = new ViewModel_MainCenter();
        public ViewModel_MainCenter ViewModel_MainCenter { get { return _ViewModel_MainCenter; } set { ViewModel_MainCenter = value; OnPropertyChanged("ViewModel_MainCenter"); } }

        ViewModel_MainSide_Left _ViewModel_MainSide_Left = new ViewModel_MainSide_Left();
        public ViewModel_MainSide_Left ViewModel_MainSide_Left { get { return _ViewModel_MainSide_Left; } set { ViewModel_MainSide_Left = value; OnPropertyChanged("ViewModel_MainSide_Left"); } }

        ViewModel_MainSide_Right _ViewModel_MainSide_Right = new ViewModel_MainSide_Right();
        public ViewModel_MainSide_Right ViewModel_MainSide_Right { get { return _ViewModel_MainSide_Right; } set { ViewModel_MainSide_Right = value; OnPropertyChanged("ViewModel_MainSide_Right"); } }

        ViewModel_MainChart _ViewModel_MainChart = new ViewModel_MainChart();
        public ViewModel_MainChart ViewModel_MainChart { get { return _ViewModel_MainChart; } set { _ViewModel_MainChart = value; OnPropertyChanged("ViewModel_MainChart"); } }

        bool _IsErrorPopupVisible = false;
        public bool IsErrorPopupVisible { get { return _IsErrorPopupVisible; } set { _IsErrorPopupVisible = value; OnPropertyChanged("IsErrorPopupVisible"); } }

        bool _IsConfigPageVisible = false;
        public bool IsConfigPageVisible { get { return _IsConfigPageVisible; } set { _IsConfigPageVisible = value; OnPropertyChanged("IsConfigPageVisible"); } }

        bool _IsSystemPageVisible = false;
        public bool IsSystemPageVisible { get { return _IsSystemPageVisible; } set { _IsSystemPageVisible = value; OnPropertyChanged("IsSystemPageVisible"); } }

        bool _IsMainPageVisible = true;
        public bool IsMainPageVisible { get { return _IsMainPageVisible; } set { _IsMainPageVisible = value; OnPropertyChanged("IsMainPageVisible"); } }


        ViewModel_KeyPad _ViewModel_KeyPad = new ViewModel_KeyPad();
        public ViewModel_KeyPad ViewModel_KeyPad { get { return _ViewModel_KeyPad; } set { _ViewModel_KeyPad = value; OnPropertyChanged("ViewModel_KeyPad"); } }

        ViewModelConfigPage _ViewModelConfigPage = new ViewModelConfigPage();
        public ViewModelConfigPage ViewModelConfigPage { get { return _ViewModelConfigPage; } set { _ViewModelConfigPage = value; OnPropertyChanged("ViewModelConfigPage"); } }

        ViewModelSystemPage _ViewModelSystemPage = new ViewModelSystemPage();
        public ViewModelSystemPage ViewModelSystemPage { get { return _ViewModelSystemPage; } set { _ViewModelSystemPage = value; OnPropertyChanged("ViewModelSystemPage"); } }
        #endregion Property

        #region Command

        #region 에러 창 닫기 선택 
        public RelayCommand ErrorCloseSelect { get; set; }
        private void ErrorCloseSelectAction(object param)
        {
            //TODO : state가 에러 해제 되었을 때 자동 닫기 하는지 확인 필요
            IsErrorPopupVisible = false;
            Debug.WriteLine("ErrorCloseSelect");
        }
        #endregion 에러 창 닫기 선택 

        #region 에러 리셋 선택 
        public RelayCommand ErrorResetSelect { get; set; }
        private void ErrorResetSelectAction(object param)
        {
            T_PACKCODE_CHROZEN_COMMAND packCode = T_PACKCODE_CHROZEN_COMMANDManager.InitiatedInstance;
            packCode.packet.btCommand = 30;
            tcpManager.Send(T_PACKCODE_CHROZEN_COMMANDManager.MakePACKCODE_SET(packCode.packet));
            IsErrorPopupVisible = false;
            Debug.WriteLine("ErrorResetSelect");
        }
        #endregion 에러 리셋 선택

        #region 에러 선택 
        public RelayCommand ErrorSelect { get; set; }
        private void ErrorSelectAction(object param)
        {
            if ((E_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState == E_STATE.Error)
            {
                IsErrorPopupVisible = true;
                Debug.WriteLine("ErrorSelected");
            }
        }
        #endregion 에러 선택

        #region 홈 메뉴
        public RelayCommand SelectHomeMenu { get; set; }
        private void SelectHomeMenuAction(object param)
        {
            IsSystemPageVisible = false;
            IsConfigPageVisible = false;
            IsMainPageVisible = true;
        }
        #endregion 홈 메뉴

        #region 시스템 설정 메뉴
        public RelayCommand SelectSystemMenu { get; set; }
        private void SelectSystemMenuAction(object param)
        {
            IsSystemPageVisible = true;
            IsConfigPageVisible = false;
            IsMainPageVisible = false;
        }
        #endregion 시스템 설정 메뉴

        #region 장비 설정 메뉴
        public RelayCommand SelectConfigMenu { get; set; }
        private void SelectConfigMenuAction(object param)
        {
            IsSystemPageVisible = false;
            IsConfigPageVisible = true;
            IsMainPageVisible = false;
        }
        #endregion 장비 설정 메뉴

        #endregion Command

        #endregion Binding

        #region Instance Func

        private void UpdateTime()
        {

        }

        private void UpdateViewModel()
        {

        }

        #endregion Instance Func

    }
}
