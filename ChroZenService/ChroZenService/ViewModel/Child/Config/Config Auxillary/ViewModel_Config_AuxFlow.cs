using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_Config_AuxFlow : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_AuxFlow()
        {
            ProgramValveIndexChangeCommand = new RelayCommand(ProgramValveIndexChangeCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);


            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        TCPManager tcpManager;

        int nAuxIndex;

        string _ActualFlow1;
        public string ActualFlow1 { get { return _ActualFlow1; } set { if (_ActualFlow1 != value) { _ActualFlow1 = value; OnPropertyChanged("ActualFlow1"); } } }

        string _ActualFlow2;
        public string ActualFlow2 { get { return _ActualFlow2; } set { if (_ActualFlow2 != value) { _ActualFlow2 = value; OnPropertyChanged("ActualFlow2"); } } }

        string _ActualFlow3;
        public string ActualFlow3 { get { return _ActualFlow3; } set { if (_ActualFlow3 != value) { _ActualFlow3 = value; OnPropertyChanged("ActualFlow3"); } } }

        byte _btAuxGas;
        public byte btAuxGas { get { return _btAuxGas; } set { if (_btAuxGas != value) { _btAuxGas = value; OnPropertyChanged("btAuxGas"); } } }

        string _fFlowSet1;
        public string fFlowSet1
        {
            get { return _fFlowSet1; }
            set
            {
                if (_fFlowSet1 != value)
                {
                    _fFlowSet1 = value;

                    switch (fFlowOnoff1)
                    {
                        case true:
                            {
                                setDisplayString1 = fFlowSet1;
                            }
                            break;
                        case false:
                            {
                                setDisplayString1 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fFlowSet1");
                }
            }
        }

        bool _fFlowOnoff1;
        public bool fFlowOnoff1
        {
            get { return _fFlowOnoff1; }
            set
            {
                if (_fFlowOnoff1 != value)
                {
                    _fFlowOnoff1 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString1 = fFlowSet1;
                            }
                            break;
                        case false:
                            {
                                setDisplayString1 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fFlowOnoff1");
                }
            }
        }

        string _fFlowSet2;
        public string fFlowSet2
        {
            get { return _fFlowSet2; }
            set
            {
                if (_fFlowSet2 != value)
                {
                    _fFlowSet2 = value;

                    switch (fFlowOnoff2)
                    {
                        case true:
                            {
                                setDisplayString2 = fFlowSet2;
                            }
                            break;
                        case false:
                            {
                                setDisplayString2 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fFlowSet2");
                }
            }
        }

        bool _fFlowOnoff2;
        public bool fFlowOnoff2
        {
            get { return _fFlowOnoff2; }
            set
            {
                if (_fFlowOnoff2 != value)
                {
                    _fFlowOnoff2 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString2 = fFlowSet2;
                            }
                            break;
                        case false:
                            {
                                setDisplayString2 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fFlowOnoff2");
                }
            }
        }

        string _fFlowSet3;
        public string fFlowSet3
        {
            get { return _fFlowSet3; }
            set
            {
                if (_fFlowSet3 != value)
                {
                    _fFlowSet3 = value;
                    switch (fFlowOnoff3)
                    {
                        case true:
                            {
                                setDisplayString3 = fFlowSet3;
                            }
                            break;
                        case false:
                            {
                                setDisplayString3 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fFlowSet3");
                }
            }
        }

        bool _fFlowOnoff3;
        public bool fFlowOnoff3
        {
            get { return _fFlowOnoff3; }
            set
            {
                if (_fFlowOnoff3 != value)
                {
                    _fFlowOnoff3 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString3 = fFlowSet3;
                            }
                            break;
                        case false:
                            {
                                setDisplayString3 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fFlowOnoff3");
                }
            }
        }

        string _setDisplayString1;
        public string setDisplayString1 { get { return _setDisplayString1; } set { if (_setDisplayString1 != value) { _setDisplayString1 = value; OnPropertyChanged("setDisplayString1"); } } }
        string _setDisplayString2;
        public string setDisplayString2 { get { return _setDisplayString2; } set { if (_setDisplayString2 != value) { _setDisplayString2 = value; OnPropertyChanged("setDisplayString2"); } } }
        string _setDisplayString3;
        public string setDisplayString3 { get { return _setDisplayString3; } set { if (_setDisplayString3 != value) { _setDisplayString3 = value; OnPropertyChanged("setDisplayString3"); } } }

        bool _bIsAuxEnabled;
        public bool bIsAuxEnabled { get { return _bIsAuxEnabled; } set { if (_bIsAuxEnabled != value) { _bIsAuxEnabled = value; OnPropertyChanged("bIsAuxEnabled"); } } }


        #endregion Property

        #region Command

        #region ProgramValveIndexChangeCommand
        public RelayCommand ProgramValveIndexChangeCommand { get; set; }
        private void ProgramValveIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Aux UPC 1":
                    {
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.btAuxGas = btAuxGas;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));
                    }
                    break;
                case "Aux UPC 2":
                    {
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.btAuxGas = btAuxGas;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(
            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));
                    }
                    break;
                case "Aux UPC 3":
                    {
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.btAuxGas = btAuxGas;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(
            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("ProgramValveIndexChangeCommand Fired");
        }
        #endregion ProgramValveIndexChangeCommand 

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
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_1:
                        {
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowSet1 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_2:
                        {
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowSet2 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_3:
                        {
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowSet3 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_1:
                        {
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowSet1 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_2:
                        {
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowSet2 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_3:
                        {
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowSet3 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_1:
                        {
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowSet1 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_2:
                        {
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowSet2 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_3:
                        {
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowSet3 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
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

            float tempFloatVal = 0;
            if (float.TryParse(mainVM.ViewModel_KeyPad.CurrentValue, out tempFloatVal))
            {
                switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
                {
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_1:
                        {
                            fFlowOnoff1 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowOnoff1 = fFlowOnoff1;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowSet1 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_2:
                        {
                            fFlowOnoff2 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowOnoff2 = fFlowOnoff2;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowSet2 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_3:
                        {
                            fFlowOnoff3 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowOnoff3 = fFlowOnoff3;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowSet3 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_1:
                        {
                            fFlowOnoff1 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowOnoff1 = fFlowOnoff1;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowSet1 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_2:
                        {
                            fFlowOnoff2 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowOnoff2 = fFlowOnoff2;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowSet2 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_3:
                        {
                            fFlowOnoff3 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowOnoff3 = fFlowOnoff3;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowSet3 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_1:
                        {
                            fFlowOnoff1 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowOnoff1 = fFlowOnoff1;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowSet1 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_2:
                        {
                            fFlowOnoff2 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowOnoff2 = fFlowOnoff2;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowSet2 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_3:
                        {
                            fFlowOnoff3 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowOnoff3 = fFlowOnoff3;
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowSet3 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                }
            }
            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
        }

        #endregion KeyPad : OnCommand

        #region KeyPad : OffCommand

        public RelayCommand KeyPadOffCommand { get; set; }
        private void KeyPadOffCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
            {
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_1:
                    {
                        fFlowOnoff1 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowOnoff1 = fFlowOnoff1;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_2:
                    {
                        fFlowOnoff2 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowOnoff2 = fFlowOnoff2;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_3:
                    {
                        fFlowOnoff3 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.lcdAuxApc.fFlowOnoff3 = fFlowOnoff3;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet.btPort = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_1:
                    {
                        fFlowOnoff1 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowOnoff1 = fFlowOnoff1;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_2:
                    {
                        fFlowOnoff2 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowOnoff2 = fFlowOnoff2;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_3:
                    {
                        fFlowOnoff3 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.lcdAuxApc.fFlowOnoff3 = fFlowOnoff3;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet.btPort = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_1:
                    {
                        fFlowOnoff1 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowOnoff1 = fFlowOnoff1;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_2:
                    {
                        fFlowOnoff2 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowOnoff2 = fFlowOnoff2;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_3:
                    {
                        fFlowOnoff3 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.lcdAuxApc.fFlowOnoff3 = fFlowOnoff3;
                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet.btPort = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
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
                case ".":
                    {
                        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("."))
                        {
                            mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                        }
                    }
                    break;
                case "-/+":
                    {
                        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("-"))
                        {
                            mainVM.ViewModel_KeyPad.CurrentValue = "-" + mainVM.ViewModel_KeyPad.CurrentValue;
                        }
                    }
                    break;

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
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_1:
                    {
                        vmKeyPad.Title = "Aux1-Flow1";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff1 == true)
                        {
                            vmKeyPad.CurrentValue = fFlowSet1;
                        }
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_2:
                    {
                        vmKeyPad.Title = "Aux1-Flow2";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff2 == true)
                            vmKeyPad.CurrentValue = fFlowSet2;
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_3:
                    {
                        vmKeyPad.Title = "Aux1-Flow3";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff3 == true)
                            vmKeyPad.CurrentValue = fFlowSet3;
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_1_FLOW_FLOW_3;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_1:
                    {
                        vmKeyPad.Title = "Aux2-Flow1";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff1 == true)
                        {
                            vmKeyPad.CurrentValue = fFlowSet1;
                        }
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_2:
                    {
                        vmKeyPad.Title = "Aux2-Flow2";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff2 == true)
                            vmKeyPad.CurrentValue = fFlowSet2;
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_3:
                    {
                        vmKeyPad.Title = "Aux2-Flow3";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff3 == true)
                            vmKeyPad.CurrentValue = fFlowSet3;
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_2_FLOW_FLOW_3;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_1:
                    {
                        vmKeyPad.Title = "Aux3-Flow1";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff1 == true)
                        {
                            vmKeyPad.CurrentValue = fFlowSet1;
                        }
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_2:
                    {
                        vmKeyPad.Title = "Aux3-Flow2";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff2 == true)
                            vmKeyPad.CurrentValue = fFlowSet2;
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_3:
                    {
                        vmKeyPad.Title = "Aux3-Flow3";
                        vmKeyPad.MaxValue = 150;
                        if (fFlowOnoff3 == true)
                            vmKeyPad.CurrentValue = fFlowSet3;
                        else
                            vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_3_FLOW_FLOW_3;
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

        #endregion Instance Func
    }
}
