using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModelMainPage : BindableNotifyBase
    {

        private static ViewModelMainPage _Instance;
        #region 생성자 & 이벤트 헨들러
        public static ViewModelMainPage SingleTonInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ViewModelMainPage();
                }

                return _Instance;
            }
        }

        TCPManager tcpManager;

        public ViewModelMainPage()
        {
            SelectHomeMenu = new RelayCommand(SelectHomeMenuAction);
            SelectSystemMenu = new RelayCommand(SelectSystemMenuAction);
            SelectConfigMenu = new RelayCommand(SelectConfigMenuAction);
            ErrorSelect = new RelayCommand(ErrorSelectAction);
            ErrorResetSelect = new RelayCommand(ErrorResetSelectAction);
            ErrorCloseSelect = new RelayCommand(ErrorCloseSelectAction);

            SetCommand = new RelayCommand(SetCommandAction);
            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            EventManager.onPACKCODE_Receivce += PACKCODE_ReceivceEventHandler;
            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
            EventManager.onKeyPadRequest += KeyPadRequest_EventHandler;

            EventManager.onConnectSuccess += onConnectSuccess_EventHandler;
            EventManager.onDisconnected += onDisconnected_EventHandler;
            _Instance = this;

            //tcpManager = new TCPManager();
            //Task.Factory.StartNew(() => { tcpManager.ConnectDevice("192.168.0.88", 4242); });

        }

        private void onDisconnected_EventHandler()
        {
            IsLoginPageVisible = true;
        }

        private void onConnectSuccess_EventHandler()
        {
            IsLoginPageVisible = false;
        }

        private void KeyPadRequest_EventHandler(ViewModel_KeyPad viewModel_KeyPad)
        {
            ViewModel_KeyPad.CopyFrom(viewModel_KeyPad);
        }

        private void PACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, int nIndex)
        {
            Task.Factory.StartNew(() =>
            {
                switch (e_LC_PACK_CODE)
                {
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                        {
                            #region MainPage

                            #region MainTop

                            ViewModel_MainTop.DeviceRuntimeCurrent = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.fRunTime.ToString("F1");
                            ViewModel_MainTop.DeviceRunStartCurrent = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.iCurrentRun.ToString();
                            ViewModel_MainTop.DeviceRunStartTotal = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btPrgmStep.ToString();

                            E_STATE state = (E_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btState;
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
                            ViewModel_MainCenter.OvenTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fOven.ToString("F2");

                            //선택된 인렛 온도
                            if (ViewModel_MainSide_Left.IsTopVisible)
                            {
                                ViewModel_MainCenter.SelectedInletTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fInj[0].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Left.IsCenterVisible)
                            {
                                ViewModel_MainCenter.SelectedInletTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fInj[1].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Left.IsBottomVisible)
                            {
                                ViewModel_MainCenter.SelectedInletTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fInj[2].ToString("F0");
                            }

                            //선택된 디텍터 온도
                            if (ViewModel_MainSide_Right.IsTopVisible)
                            {
                                ViewModel_MainCenter.SelectedDetTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fDet[0].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Right.IsCenterVisible)
                            {
                                ViewModel_MainCenter.SelectedDetTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fDet[1].ToString("F0");
                            }
                            else if (ViewModel_MainSide_Right.IsBottomVisible)
                            {
                                ViewModel_MainCenter.SelectedDetTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fDet[2].ToString("F0");
                            }

                            //Step
                            ViewModel_MainCenter.Step = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.btStep.ToString();

                            #endregion MainCenter

                            #region MainLeft

                            ViewModel_MainSide_Left.TopFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[0 * 4 + 2].ToString("F2");
                            ViewModel_MainSide_Left.TopPressure = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Press[0].ToString("F2");

                            ViewModel_MainSide_Left.CenterFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[0 * 4 + 2].ToString("F2");
                            ViewModel_MainSide_Left.CenterPressure = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Press[1].ToString("F2");

                            ViewModel_MainSide_Left.BottomFlow = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_InjFlow[0 * 4 + 2].ToString("F2");
                            ViewModel_MainSide_Left.BottomPressure = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_Press[2].ToString("F2");

                            #endregion MainLeft

                            #region MainRight

                            ViewModel_MainSide_Right.TopSignalStrength = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.fSignal[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[0])
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow3Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.TopFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow3Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.TopFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.TopFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.TopFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopFlow1Name = "Mkup";

                                        ViewModel_MainSide_Right.TopIsFlow1Using = true;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = false;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = false;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.PDD:
                                    {
                                        ViewModel_MainSide_Right.TopFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.TopIsFlow1Using = false;
                                        ViewModel_MainSide_Right.TopIsFlow2Using = false;
                                        ViewModel_MainSide_Right.TopIsFlow3Using = false;
                                        ViewModel_MainSide_Right.TopSignalUnit = "mV";
                                    }
                                    break;
                            }

                            ViewModel_MainSide_Right.CenterSignalStrength = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.fSignal[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[1])
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow3Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.CenterFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow3Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.CenterFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.CenterFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.CenterFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterFlow1Name = "Mkup";

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = true;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = false;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = false;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.PDD:
                                    {
                                        ViewModel_MainSide_Right.CenterFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.CenterIsFlow1Using = false;
                                        ViewModel_MainSide_Right.CenterIsFlow2Using = false;
                                        ViewModel_MainSide_Right.CenterIsFlow3Using = false;
                                        ViewModel_MainSide_Right.CenterSignalUnit = "mV";
                                    }
                                    break;
                            }

                            ViewModel_MainSide_Right.BottomSignalStrength = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.fSignal[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);

                            switch ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[2])
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow3Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.BottomFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow3Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[2].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.BottomFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        ViewModel_MainSide_Right.BottomFlow2Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[1].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                                        ViewModel_MainSide_Right.BottomFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                                        ViewModel_MainSide_Right.BottomFlow1Name = "Mkup";

                                        ViewModel_MainSide_Right.BottomIsFlow1Using = true;
                                        ViewModel_MainSide_Right.BottomIsFlow2Using = false;
                                        ViewModel_MainSide_Right.BottomIsFlow3Using = false;
                                        ViewModel_MainSide_Right.BottomSignalUnit = "mV";
                                    }
                                    break;
                                case E_DET_TYPE.PDD:
                                    {
                                        ViewModel_MainSide_Right.BottomFlow1Value = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActFlow.Disp_DetFlow[0].ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

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
                            switch (nIndex)
                            {
                                case 0:
                                    {
                                        ViewModel_MainSide_Left.TopSplitRatio = string.Format(" 1 / {0}", DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.iSplitratio.ToString());
                                        ViewModel_MainSide_Left.TopCarrierGasType = ((CARRIER_GAS_TYPE)DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.btCarriergas).ToString();
                                        ViewModel_MainSide_Left.TopApcMode = ((APC_MODE)DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received.packet.btPortNo).ToString().Replace("_", ".");
                                    }
                                    break;
                                case 1:
                                    {
                                        ViewModel_MainSide_Left.CenterSplitRatio = string.Format(" 1 / {0}", DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.iSplitratio.ToString());
                                        ViewModel_MainSide_Left.CenterCarrierGasType = ((CARRIER_GAS_TYPE)DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btCarriergas).ToString();
                                        ViewModel_MainSide_Left.CenterApcMode = ((APC_MODE)DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btPortNo).ToString().Replace("_", ".");
                                    }
                                    break;
                                case 2:
                                    {
                                        ViewModel_MainSide_Left.BottomSplitRatio = string.Format(" 1 / {0}", DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.iSplitratio.ToString());
                                        ViewModel_MainSide_Left.BottomCarrierGasType = ((CARRIER_GAS_TYPE)DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btCarriergas).ToString();
                                        ViewModel_MainSide_Left.BottomApcMode = ((APC_MODE)DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received.packet.btPortNo).ToString().Replace("_", ".");
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

                            ViewModel_MainTop.DeviceRuntimeTotal = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTotalRunTime.ToString("F1");

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
                                (E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[0] == E_INLET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Left.IsCenterAvailable =
                                 (E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[1] == E_INLET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Left.IsBottomAvailable =
                                 (E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[2] == E_INLET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Left.TopType = ((E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[0]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Left.CenterType = ((E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[1]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Left.BottomType = ((E_INLET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btInlet[2]).ToString().Replace("_", " ");


                            #endregion MainLeft

                            #region MainCenter

                            ViewModel_MainCenter.OvenTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fOven.ToString("F2");

                            #endregion MainCenter

                            #region MainRight

                            ViewModel_MainSide_Right.IsTopAvailable =
                                (E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[0] == E_DET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Right.IsCenterAvailable =
                                (E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[1] == E_DET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Right.IsBottomAvailable =
                                (E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[2] == E_DET_TYPE.Not_Installed ? false : true;
                            ViewModel_MainSide_Right.TopType = ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[0]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Right.CenterType = ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[1]).ToString().Replace("_", " ");
                            ViewModel_MainSide_Right.BottomType = ((E_DET_TYPE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received.packet.btDet[2]).ToString().Replace("_", " ");

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
        string _IPString;
        public string IPString { get { return _IPString; } set { if (_IPString != value) { _IPString = value; OnPropertyChanged("IPString"); } } }

        bool _IsLoginPageVisible = true;
        public bool IsLoginPageVisible { get { return _IsLoginPageVisible; } set { if (_IsLoginPageVisible != value) { _IsLoginPageVisible = value; OnPropertyChanged("IsLoginPageVisible"); } } }

        bool _IsSplashVisible;
        public bool IsSplashVisible { get { return _IsSplashVisible; } set { if (_IsSplashVisible != value) { _IsSplashVisible = value; OnPropertyChanged("IsSplashVisible"); } } }

        ViewModel_MainTop _ViewModel_MainTop = new ViewModel_MainTop();
        public ViewModel_MainTop ViewModel_MainTop { get { return _ViewModel_MainTop; } set { if (_ViewModel_MainTop != value) { _ViewModel_MainTop = value; OnPropertyChanged("ViewModel_MainTop"); } } }

        ViewModel_MainBottom _ViewModel_MainBottom = new ViewModel_MainBottom();
        public ViewModel_MainBottom ViewModel_MainBottom { get { return _ViewModel_MainBottom; } set { if (_ViewModel_MainBottom != value) { _ViewModel_MainBottom = value; OnPropertyChanged("ViewModel_MainBottom"); } } }

        ViewModel_MainCenter _ViewModel_MainCenter = new ViewModel_MainCenter();
        public ViewModel_MainCenter ViewModel_MainCenter { get { return _ViewModel_MainCenter; } set { if (_ViewModel_MainCenter != value) { _ViewModel_MainCenter = value; OnPropertyChanged("ViewModel_MainCenter"); } } }

        ViewModel_MainSide_Left _ViewModel_MainSide_Left = new ViewModel_MainSide_Left();
        public ViewModel_MainSide_Left ViewModel_MainSide_Left { get { return _ViewModel_MainSide_Left; } set { if (_ViewModel_MainSide_Left != value) { _ViewModel_MainSide_Left = value; OnPropertyChanged("ViewModel_MainSide_Left"); } } }

        ViewModel_MainSide_Right _ViewModel_MainSide_Right = new ViewModel_MainSide_Right();
        public ViewModel_MainSide_Right ViewModel_MainSide_Right { get { return _ViewModel_MainSide_Right; } set { if (_ViewModel_MainSide_Right != value) { _ViewModel_MainSide_Right = value; OnPropertyChanged("ViewModel_MainSide_Right"); } } }

        ViewModel_MainChart _ViewModel_MainChart = new ViewModel_MainChart();
        public ViewModel_MainChart ViewModel_MainChart { get { return _ViewModel_MainChart; } set { if (_ViewModel_MainChart != value) { _ViewModel_MainChart = value; OnPropertyChanged("ViewModel_MainChart"); } } }

        bool _IsErrorPopupVisible = false;
        public bool IsErrorPopupVisible { get { return _IsErrorPopupVisible; } set { if (_IsErrorPopupVisible != value) { _IsErrorPopupVisible = value; OnPropertyChanged("IsErrorPopupVisible"); } } }

        bool _IsConfigPageVisible = false;
        public bool IsConfigPageVisible { get { return _IsConfigPageVisible; } set { if (_IsConfigPageVisible != value) { _IsConfigPageVisible = value; OnPropertyChanged("IsConfigPageVisible"); } } }

        bool _IsSystemPageVisible = false;
        public bool IsSystemPageVisible { get { return _IsSystemPageVisible; } set { if (_IsSystemPageVisible != value) { _IsSystemPageVisible = value; OnPropertyChanged("IsSystemPageVisible"); } } }

        bool _IsMainPageVisible = true;
        public bool IsMainPageVisible { get { return _IsMainPageVisible; } set { if (_IsMainPageVisible != value) { _IsMainPageVisible = value; OnPropertyChanged("IsMainPageVisible"); } } }


        ViewModel_KeyPad _ViewModel_KeyPad = new ViewModel_KeyPad();
        public ViewModel_KeyPad ViewModel_KeyPad { get { return _ViewModel_KeyPad; } set { if (_ViewModel_KeyPad != value) { _ViewModel_KeyPad = value; OnPropertyChanged("ViewModel_KeyPad"); } } }

        ViewModelConfigPage _ViewModelConfigPage = new ViewModelConfigPage();
        public ViewModelConfigPage ViewModelConfigPage { get { return _ViewModelConfigPage; } set { if (_ViewModelConfigPage != value) { _ViewModelConfigPage = value; OnPropertyChanged("ViewModelConfigPage"); } } }

        ViewModelSystemPage _ViewModelSystemPage = new ViewModelSystemPage();
        public ViewModelSystemPage ViewModelSystemPage { get { return _ViewModelSystemPage; } set { if (_ViewModelSystemPage != value) { _ViewModelSystemPage = value; OnPropertyChanged("ViewModelSystemPage"); } } }
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

        #region KeyPad : CancelCommand

        public RelayCommand KeyPadCancelCommand { get; set; }
        private void KeyPadCancelCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;
            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //EventManager.KeyPadRequestEvent(vmKeyPad);
        }

        #endregion KeyPad : CancelCommand

        #region KeyPad : DeleteCommand

        public RelayCommand KeyPadDeleteCommand { get; set; }
        private void KeyPadDeleteCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1)
            {
                double tempVal;
                double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Substring(0, mainVM.ViewModel_KeyPad.CurrentValue.Length - 1), out tempVal);
                Debug.WriteLine(string.Format("tempVal : {0}", tempVal));
                mainVM.ViewModel_KeyPad.CurrentValue = tempVal.ToString();
            }
            mainVM.ViewModel_KeyPad.IsNeedRefresh = false;
        }

        #endregion KeyPad : DeleteCommand

        #region KeyPad : ApplyCommand

        public RelayCommand KeyPadApplyCommand { get; set; }
        private void KeyPadApplyCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            //.시작 케이스
            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
            {
                double tempVal;
                double.TryParse("0" + mainVM.ViewModel_KeyPad.CurrentValue, out tempVal);
                if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                {
                    mainVM.ViewModel_KeyPad.CurrentValue = "0" + mainVM.ViewModel_KeyPad.CurrentValue;
                }
            }
            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '-' &&
                mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
            {
                double tempVal;
                double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0"), out tempVal);
                if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                {
                    mainVM.ViewModel_KeyPad.CurrentValue = mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0");
                }
            }
            float tempFloatVal = 0;
            if (float.TryParse(mainVM.ViewModel_KeyPad.CurrentValue, out tempFloatVal))
            {
                switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
                {

                    case E_KEY_PAD_SET_MEASURE_TYPE.IP_SETTING:
                        {
                            IPString = tempFloatVal.ToString();
                            IPAddress ipAddress;
                            if (IPAddress.TryParse(IPString, out ipAddress))
                            {
                                EventManager.TryConnectEvent(IPString);
                            }
                        }
                        break;
                }
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;

            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //EventManager.KeyPadRequestEvent(vmKeyPad);
        }

        #endregion KeyPad : ApplyCommand

        #region KeyPad : OnCommand

        public RelayCommand KeyPadOnCommand { get; set; }
        private void KeyPadOnCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;
        }

        #endregion KeyPad : OnCommand

        #region KeyPad : OffCommand

        public RelayCommand KeyPadOffCommand { get; set; }
        private void KeyPadOffCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

        }

        #endregion KeyPad : OffCommand

        #region KeyPad : KeyPadClickCommand

        public RelayCommand KeyPadKeyPadClickCommand { get; set; }
        private void KeyPadKeyPadClickCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;
            if (mainVM.ViewModel_KeyPad.IsNeedRefresh)
            {
                mainVM.ViewModel_KeyPad.CurrentValue = "";
                mainVM.ViewModel_KeyPad.IsNeedRefresh = false;
            }

            switch (sender.Text)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    {
                        //.시작 케이스
                        if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
                        {
                            double tempVal;
                            double.TryParse("0" + mainVM.ViewModel_KeyPad.CurrentValue, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                        else if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '-' &&
                            mainVM.ViewModel_KeyPad.CurrentValue[1] == '.')
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0"), out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                        else
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue + sender.Text, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                    }
                    break;
                    //case ".":
                    //    {
                    //        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("."))
                    //        {
                    //            mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                    //        }
                    //    }
                    //    break;
                    //case "-/+":
                    //    {
                    //        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("-"))
                    //        {
                    //            mainVM.ViewModel_KeyPad.CurrentValue = "-" + mainVM.ViewModel_KeyPad.CurrentValue;
                    //        }
                    //    }
                    //break;

            }
        }

        #endregion KeyPad : KeyPadClickCommand

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            {
                IsKeyPadShown = true,
                KeyPadType = KeyPad.E_KEYPAD_TYPE.DOUBLE,
                MinValue = 0,
                CancelCommand = KeyPadCancelCommand,
                ApplyCommand = KeyPadApplyCommand,
                DeleteCommand = KeyPadDeleteCommand,
                OnCommand = KeyPadOnCommand,
                OffCommand = KeyPadOffCommand,
                KeyPadClickCommand = KeyPadKeyPadClickCommand,
            };

            switch ((E_KEY_PAD_SET_MEASURE_TYPE)param)
            {
                case E_KEY_PAD_SET_MEASURE_TYPE.IP_SETTING:
                    {
                        vmKeyPad.Title = "Set IP";

                        vmKeyPad.CurrentValue = ViewModelSystemPage.ViewModel_System_Information.IPAddress;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.IP_SETTING;
                    }
                    break;
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

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
