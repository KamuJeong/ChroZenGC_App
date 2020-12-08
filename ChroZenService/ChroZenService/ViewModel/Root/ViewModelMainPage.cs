using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModelMainPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelMainPage()
        {
            SelectSystemMenu = new RelayCommand(SelectSystemMenuAction);
            SelectConfigMenu = new RelayCommand(SelectConfigMenuAction);
            EventManager.onPACKCODE_Receivce += PACKCODE_ReceivceEventHandler;
        }

        private void PACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet)
        {
            Task.Factory.StartNew(() => {
                switch (e_LC_PACK_CODE)
                {
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                        {
                            #region MainPage

                            #region MainTop

                            ViewModel_MainTop.DeviceRuntimeCurrent = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.fRunTime.ToString("F1");
                            ViewModel_MainTop.DeviceRunStartCurrent = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.iCurrentRun.ToString();
                            ViewModel_MainTop.DeviceRunStartTotal = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btPrgmStep.ToString();

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
        public ViewModel_MainChart ViewModel_MainChart { get { return _ViewModel_MainChart; } set { ViewModel_MainChart = value; OnPropertyChanged("ViewModel_MainChart"); } }

        #endregion Property

        #region Command

        #region 시스템 설정 메뉴
        public RelayCommand SelectSystemMenu { get; set; }
        private void SelectSystemMenuAction(object param)
        {

        }
        #endregion 시스템 설정 메뉴

        #region 장비 설정 메뉴
        public RelayCommand SelectConfigMenu { get; set; }
        private void SelectConfigMenuAction(object param)
        {

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
