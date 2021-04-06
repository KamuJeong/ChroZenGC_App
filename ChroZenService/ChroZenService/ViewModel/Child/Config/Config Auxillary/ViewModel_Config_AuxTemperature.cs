using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Config_AuxTemperature : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_AuxTemperature()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

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

        float _fTempSet_1;
        public float fTempSet_1
        {
            get { return _fTempSet_1; }
            set
            {
                if (_fTempSet_1 != value)
                {
                    _fTempSet_1 = value;
                    switch (fTempOnoff_1)
                    {
                        case true:
                            {
                                setDisplayString1 = fTempSet_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString1 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_1");
                }
            }
        }
        float _fTempSet_2;
        public float fTempSet_2
        {
            get { return _fTempSet_2; }
            set
            {
                if (_fTempSet_2 != value)
                {
                    _fTempSet_2 = value;
                    switch (fTempOnoff_2)
                    {
                        case true:
                            {
                                setDisplayString2 = fTempSet_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString2 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_2");
                }
            }
        }
        float _fTempSet_3;
        public float fTempSet_3
        {
            get { return _fTempSet_3; }
            set
            {
                if (_fTempSet_3 != value)
                {
                    _fTempSet_3 = value;
                    switch (fTempOnoff_3)
                    {
                        case true:
                            {
                                setDisplayString3 = fTempSet_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString3 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_3");
                }
            }
        }
        float _fTempSet_4;
        public float fTempSet_4
        {
            get { return _fTempSet_4; }
            set
            {
                if (_fTempSet_4 != value)
                {
                    _fTempSet_4 = value;
                    OnPropertyChanged("fTempSet_4");
                    switch (fTempOnoff_4)
                    {
                        case true:
                            {
                                setDisplayString4 = fTempSet_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString4 = "Off";
                            }
                            break;
                    }
                }
            }
        }
        float _fTempSet_5;
        public float fTempSet_5
        {
            get { return _fTempSet_5; }
            set
            {
                if (_fTempSet_5 != value)
                {
                    _fTempSet_5 = value;
                    switch (fTempOnoff_5)
                    {
                        case true:
                            {
                                setDisplayString5 = fTempSet_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString5 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_5");
                }
            }
        }
        float _fTempSet_6;
        public float fTempSet_6
        {
            get { return _fTempSet_6; }
            set
            {
                if (_fTempSet_6 != value)
                {
                    _fTempSet_6 = value;
                    switch (fTempOnoff_6)
                    {
                        case true:
                            {
                                setDisplayString6 = fTempSet_6.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString6 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_6");
                }
            }
        }
        float _fTempSet_7;
        public float fTempSet_7
        {
            get { return _fTempSet_7; }
            set
            {
                if (_fTempSet_7 != value)
                {
                    _fTempSet_7 = value;
                    switch (fTempOnoff_7)
                    {
                        case true:
                            {
                                setDisplayString7 = fTempSet_7.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString7 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_7");
                }
            }
        }
        float _fTempSet_8;
        public float fTempSet_8
        {
            get { return _fTempSet_8; }
            set
            {
                if (_fTempSet_8 != value)
                {
                    _fTempSet_8 = value;
                    switch (fTempOnoff_8)
                    {
                        case true:
                            {
                                setDisplayString8 = fTempSet_8.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString8 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempSet_8");
                }
            }
        }

        bool _fTempOnoff_1;
        public bool fTempOnoff_1
        {
            get { return _fTempOnoff_1; }
            set
            {
                if (_fTempOnoff_1 != value)
                {
                    _fTempOnoff_1 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString1 = fTempSet_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString1 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_1");
                }
            }
        }
        bool _fTempOnoff_2;
        public bool fTempOnoff_2
        {
            get { return _fTempOnoff_2; }
            set
            {
                if (_fTempOnoff_2 != value)
                {
                    _fTempOnoff_2 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString2 = fTempSet_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString2 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_2");
                }
            }
        }
        bool _fTempOnoff_3;
        public bool fTempOnoff_3
        {
            get { return _fTempOnoff_3; }
            set
            {
                if (_fTempOnoff_3 != value)
                {
                    _fTempOnoff_3 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString3 = fTempSet_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString3 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_3");
                }
            }
        }
        bool _fTempOnoff_4;
        public bool fTempOnoff_4
        {
            get { return _fTempOnoff_4; }
            set
            {
                if (_fTempOnoff_4 != value)
                {
                    _fTempOnoff_4 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString4 = fTempSet_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString4 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_4");
                }
            }
        }
        bool _fTempOnoff_5;
        public bool fTempOnoff_5
        {
            get { return _fTempOnoff_5; }
            set
            {
                if (_fTempOnoff_5 != value)
                {
                    _fTempOnoff_5 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString5 = fTempSet_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString5 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_5");
                }
            }
        }
        bool _fTempOnoff_6;
        public bool fTempOnoff_6
        {
            get { return _fTempOnoff_6; }
            set
            {
                if (_fTempOnoff_6 != value)
                {
                    _fTempOnoff_6 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString6 = fTempSet_6.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString6 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_6");
                }
            }
        }
        bool _fTempOnoff_7;
        public bool fTempOnoff_7
        {
            get { return _fTempOnoff_7; }
            set
            {
                if (_fTempOnoff_7 != value)
                {
                    _fTempOnoff_7 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString7 = fTempSet_7.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString7 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_7");
                }
            }
        }
        bool _fTempOnoff_8;
        public bool fTempOnoff_8
        {
            get { return _fTempOnoff_8; }
            set
            {
                if (_fTempOnoff_8 != value)
                {
                    _fTempOnoff_8 = value;
                    switch (value)
                    {
                        case true:
                            {
                                setDisplayString8 = fTempSet_8.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            }
                            break;
                        case false:
                            {
                                setDisplayString8 = "Off";
                            }
                            break;
                    }

                    OnPropertyChanged("fTempOnoff_8");
                }
            }
        }
        string _strActAux_1;
        public string strActAux_1 { get { return _strActAux_1; } set { if (_strActAux_1 != value) { _strActAux_1 = value; OnPropertyChanged("strActAux_1"); } } }
        string _strActAux_2;
        public string strActAux_2 { get { return _strActAux_2; } set { if (_strActAux_2 != value) { _strActAux_2 = value; OnPropertyChanged("strActAux_2"); } } }
        string _strActAux_3;
        public string strActAux_3 { get { return _strActAux_3; } set { if (_strActAux_3 != value) { _strActAux_3 = value; OnPropertyChanged("strActAux_3"); } } }
        string _strActAux_4;
        public string strActAux_4 { get { return _strActAux_4; } set { if (_strActAux_4 != value) { _strActAux_4 = value; OnPropertyChanged("strActAux_4"); } } }
        string _strActAux_5;
        public string strActAux_5 { get { return _strActAux_5; } set { if (_strActAux_5 != value) { _strActAux_5 = value; OnPropertyChanged("strActAux_5"); } } }
        string _strActAux_6;
        public string strActAux_6 { get { return _strActAux_6; } set { if (_strActAux_6 != value) { _strActAux_6 = value; OnPropertyChanged("strActAux_6"); } } }
        string _strActAux_7;
        public string strActAux_7 { get { return _strActAux_7; } set { if (_strActAux_7 != value) { _strActAux_7 = value; OnPropertyChanged("strActAux_7"); } } }
        string _strActAux_8;
        public string strActAux_8 { get { return _strActAux_8; } set { if (_strActAux_8 != value) { _strActAux_8 = value; OnPropertyChanged("strActAux_8"); } } }

        string _setDisplayString1;
        public string setDisplayString1 { get { return _setDisplayString1; } set { if (_setDisplayString1 != value) { _setDisplayString1 = value; OnPropertyChanged("setDisplayString1"); } } }
        string _setDisplayString2;
        public string setDisplayString2 { get { return _setDisplayString2; } set { if (_setDisplayString2 != value) { _setDisplayString2 = value; OnPropertyChanged("setDisplayString2"); } } }
        string _setDisplayString3;
        public string setDisplayString3 { get { return _setDisplayString3; } set { if (_setDisplayString3 != value) { _setDisplayString3 = value; OnPropertyChanged("setDisplayString3"); } } }
        string _setDisplayString4;
        public string setDisplayString4 { get { return _setDisplayString4; } set { if (_setDisplayString4 != value) { _setDisplayString4 = value; OnPropertyChanged("setDisplayString4"); } } }
        string _setDisplayString5;
        public string setDisplayString5 { get { return _setDisplayString5; } set { if (_setDisplayString5 != value) { _setDisplayString5 = value; OnPropertyChanged("setDisplayString5"); } } }
        string _setDisplayString6;
        public string setDisplayString6 { get { return _setDisplayString6; } set { if (_setDisplayString6 != value) { _setDisplayString6 = value; OnPropertyChanged("setDisplayString6"); } } }
        string _setDisplayString7;
        public string setDisplayString7 { get { return _setDisplayString7; } set { if (_setDisplayString7 != value) { _setDisplayString7 = value; OnPropertyChanged("setDisplayString7"); } } }
        string _setDisplayString8;
        public string setDisplayString8 { get { return _setDisplayString8; } set { if (_setDisplayString8 != value) { _setDisplayString8 = value; OnPropertyChanged("setDisplayString8"); } } }

        bool _bIsAux1Enabled;
        public bool bIsAux1Enabled { get { return _bIsAux1Enabled; } set { if (_bIsAux1Enabled != value) { _bIsAux1Enabled = value; OnPropertyChanged("bIsAux1Enabled"); } } }
        bool _bIsAux2Enabled;
        public bool bIsAux2Enabled { get { return _bIsAux2Enabled; } set { if (_bIsAux2Enabled != value) { _bIsAux2Enabled = value; OnPropertyChanged("bIsAux2Enabled"); } } }
        bool _bIsAux3Enabled;
        public bool bIsAux3Enabled { get { return _bIsAux3Enabled; } set { if (_bIsAux3Enabled != value) { _bIsAux3Enabled = value; OnPropertyChanged("bIsAux3Enabled"); } } }
        bool _bIsAux4Enabled;
        public bool bIsAux4Enabled { get { return _bIsAux4Enabled; } set { if (_bIsAux4Enabled != value) { _bIsAux4Enabled = value; OnPropertyChanged("bIsAux4Enabled"); } } }
        bool _bIsAux5Enabled;
        public bool bIsAux5Enabled { get { return _bIsAux5Enabled; } set { if (_bIsAux5Enabled != value) { _bIsAux5Enabled = value; OnPropertyChanged("bIsAux5Enabled"); } } }
        bool _bIsAux6Enabled;
        public bool bIsAux6Enabled { get { return _bIsAux6Enabled; } set { if (_bIsAux6Enabled != value) { _bIsAux6Enabled = value; OnPropertyChanged("bIsAux6Enabled"); } } }
        bool _bIsAux7Enabled;
        public bool bIsAux7Enabled { get { return _bIsAux7Enabled; } set { if (_bIsAux7Enabled != value) { _bIsAux7Enabled = value; OnPropertyChanged("bIsAux7Enabled"); } } }
        bool _bIsAux8Enabled;
        public bool bIsAux8Enabled { get { return _bIsAux8Enabled; } set { if (_bIsAux8Enabled != value) { _bIsAux8Enabled = value; OnPropertyChanged("bIsAux8Enabled"); } } }

        byte _bMethanizer;
        public byte bMethanizer { get { return _bMethanizer; } set { if (_bMethanizer != value) { _bMethanizer = value; OnPropertyChanged("bMethanizer"); } } }

        float[] _fTempSet = new float[ChroZenService_Const.AUX_CNT];
        public float[] fTempSet { get { return _fTempSet; } set { if (_fTempSet != value) { _fTempSet = value; OnPropertyChanged("fTempSet"); } } }

        byte[] _fTempOnoff = new byte[ChroZenService_Const.AUX_CNT];
        public byte[] fTempOnoff { get { return _fTempOnoff; } set { if (_fTempOnoff != value) { _fTempOnoff = value; OnPropertyChanged("fTempOnoff"); } } }

        #endregion Property

        #region Command

        #region DefaultCommand
        public RelayCommand DefaultCommand { get; set; }
        private void DefaultCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("DefaultCommand Fired");
        }

        #endregion DefaultCommand 


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
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_1:
                        {
                            fTempSet_1 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[0] = fTempSet_1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_2:
                        {
                            fTempSet_2 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[1] = fTempSet_2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_3:
                        {
                            fTempSet_3 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[2] = fTempSet_3;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_4:
                        {
                            fTempSet_4 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[3] = fTempSet_4;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_5:
                        {
                            fTempSet_5 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[4] = fTempSet_5;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_6:
                        {
                            fTempSet_6 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[5] = fTempSet_6;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_7:
                        {
                            fTempSet_7 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[6] = fTempSet_7;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_8:
                        {
                            fTempSet_8 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[7] = fTempSet_8;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
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
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_1:
                        {
                            fTempOnoff_1 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[0] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_1 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[0] = fTempSet_1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_2:
                        {
                            fTempOnoff_2 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[1] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_2 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[1] = fTempSet_2;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_3:
                        {
                            fTempOnoff_3 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[2] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_3 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[2] = fTempSet_3;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_4:
                        {
                            fTempOnoff_4 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[3] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_4 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[3] = fTempSet_4;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_5:
                        {
                            fTempOnoff_5 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[4] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_5 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[4] = fTempSet_5;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_6:
                        {
                            fTempOnoff_6 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[5] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_6 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[5] = fTempSet_6;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_7:
                        {
                            fTempOnoff_7 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[6] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_7 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[6] = fTempSet_7;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_8:
                        {
                            fTempOnoff_8 = true;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[7] = 1;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet_8 = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempSet[7] = fTempSet_8;
                            tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
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
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_1:
                    {
                        fTempOnoff_1 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[0] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_2:
                    {
                        fTempOnoff_2 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[1] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_3:
                    {
                        fTempOnoff_3 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[2] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_4:
                    {
                        fTempOnoff_4 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[3] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_5:
                    {
                        fTempOnoff_5 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[4] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_6:
                    {
                        fTempOnoff_6 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[5] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_7:
                    {
                        fTempOnoff_7 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[6] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_8:
                    {
                        fTempOnoff_8 = false;
                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet.fTempOnoff[7] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));

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
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_1:
                    {
                        vmKeyPad.Title = "Aux 1";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_1 == true)
                        //{
                        //    vmKeyPad.CurrentValue = fTempSet_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_2:
                    {
                        vmKeyPad.Title = "Aux 2";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_2 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_3:
                    {
                        vmKeyPad.Title = "Aux 3";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_3 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_4:
                    {

                        vmKeyPad.MaxValue = 250;
                        switch ((E_METHANIZER)bMethanizer)
                        {
                            case E_METHANIZER.Valve:
                                {
                                    vmKeyPad.Title = "Valve";
                                }
                                break;
                            case E_METHANIZER.Methanizer:
                                {
                                    vmKeyPad.Title = "Methanizer";
                                }
                                break;
                            case E_METHANIZER.TransferLine:
                                {
                                    vmKeyPad.Title = "Transfer line";
                                }
                                break;
                        }

                        //if (fTempOnoff_4 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_5:
                    {
                        vmKeyPad.Title = "Aux 5";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_5 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_6:
                    {
                        vmKeyPad.Title = "Aux 6";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_6 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_6.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_6.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_7:
                    {
                        vmKeyPad.Title = "Aux 7";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_7 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_7.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_7.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_7;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_8:
                    {
                        vmKeyPad.Title = "Aux 8";
                        vmKeyPad.MaxValue = 250;
                        //if (fTempOnoff_8 == true)
                        //    vmKeyPad.CurrentValue = fTempSet_8.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet_8.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1); //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX_TEMPERATURE_SET_8;
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
