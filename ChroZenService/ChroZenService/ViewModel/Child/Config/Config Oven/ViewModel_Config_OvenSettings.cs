using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;

namespace ChroZenService
{
    public class ViewModel_Config_OvenSettings : Model_Config
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_OvenSettings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            ProgramOnCommand = new RelayCommand(ProgramOnCommandAction);
            ProgramOffCommand = new RelayCommand(ProgramOffCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        TCPManager tcpManager;

        string _ActualTemperature;
        public string ActualTemperature { get { return _ActualTemperature; } set { if (_ActualTemperature != value) { _ActualTemperature = value; OnPropertyChanged("ActualTemperature"); } } }

        string _fTempSet;
        public string fTempSet
        {
            get { return _fTempSet; }
            set
            {
                if (_fTempSet != value)
                {
                    _fTempSet = value;
                    OnPropertyChanged("fTempSet");
                    if (_bTempOnoff)
                    {
                        DisplayString_fTempSet = _fTempSet;
                    }
                    else
                    {
                        DisplayString_fTempSet = "Off";
                    }

                }
            }
        }

        string _DisplayString_fTempSet;
        public string DisplayString_fTempSet { get { return _DisplayString_fTempSet; } set { if (_DisplayString_fTempSet != value) { _DisplayString_fTempSet = value; OnPropertyChanged("DisplayString_fTempSet"); } } }

        bool _bTempOnoff;

        public bool bTempOnoff
        {
            get { return _bTempOnoff; }
            set
            {
                _bTempOnoff = value;

                switch (value)
                {
                    case true:
                        {                          
                            DisplayString_fTempSet = _fTempSet;
                        }
                        break;
                    case false:
                        {
                            DisplayString_fTempSet = "Off";
                        }
                        break;
                }

                OnPropertyChanged("bTempOnoff");
            }
        }

        float _fMaxTemp;
        public float fMaxTemp { get { return _fMaxTemp; } set { if (_fMaxTemp != value) { _fMaxTemp = value; OnPropertyChanged("fMaxTemp"); } } }

        float _fInitTime;
        public float fInitTime { get { return _fInitTime; } set { if (_fInitTime != value) { _fInitTime = value; OnPropertyChanged("fInitTime"); } } }

        //string _fTime;
        //public string fTime { get { return _fTime; } set { _fTime = value; OnPropertyChanged("fTime"); } }

        bool _btMode;
        public bool btMode { get { return _btMode; } set { if (_btMode != value) { _btMode = value; OnPropertyChanged("btMode"); } } }

        #region Rate 

        string _rate_1;
        public string rate_1 { get { return _rate_1; } set { if (_rate_1 != value) { _rate_1 = value; OnPropertyChanged("rate_1"); } } }

        string _rate_2;
        public string rate_2 { get { return _rate_2; } set { if (_rate_2 != value) { _rate_2 = value; OnPropertyChanged("rate_2"); } } }

        string _rate_3;
        public string rate_3 { get { return _rate_3; } set { if (_rate_3 != value) { _rate_3 = value; OnPropertyChanged("rate_3"); } } }

        string _rate_4;
        public string rate_4 { get { return _rate_4; } set { if (_rate_4 != value) { _rate_4 = value; OnPropertyChanged("rate_4"); } } }

        string _rate_5;
        public string rate_5 { get { return _rate_5; } set { if (_rate_5 != value) { _rate_5 = value; OnPropertyChanged("rate_5"); } } }

        string _rate_6;
        public string rate_6 { get { return _rate_6; } set { if (_rate_6 != value) { _rate_6 = value; OnPropertyChanged("rate_6"); } } }

        string _rate_7;
        public string rate_7 { get { return _rate_7; } set { if (_rate_7 != value) { _rate_7 = value; OnPropertyChanged("rate_7"); } } }

        string _rate_8;
        public string rate_8 { get { return _rate_8; } set { if (_rate_8 != value) { _rate_8 = value; OnPropertyChanged("rate_8"); } } }

        string _rate_9;
        public string rate_9 { get { return _rate_9; } set { if (_rate_9 != value) { _rate_9 = value; OnPropertyChanged("rate_9"); } } }

        string _rate_10;
        public string rate_10 { get { return _rate_10; } set { if (_rate_10 != value) { _rate_10 = value; OnPropertyChanged("rate_10"); } } }

        string _rate_11;
        public string rate_11 { get { return _rate_11; } set { if (_rate_11 != value) { _rate_11 = value; OnPropertyChanged("rate_11"); } } }

        string _rate_12;
        public string rate_12 { get { return _rate_12; } set { if (_rate_12 != value) { _rate_12 = value; OnPropertyChanged("rate_12"); } } }

        string _rate_13;
        public string rate_13 { get { return _rate_13; } set { if (_rate_13 != value) { _rate_13 = value; OnPropertyChanged("rate_13"); } } }

        string _rate_14;
        public string rate_14 { get { return _rate_14; } set { if (_rate_14 != value) { _rate_14 = value; OnPropertyChanged("rate_14"); } } }

        string _rate_15;
        public string rate_15 { get { return _rate_15; } set { if (_rate_15 != value) { _rate_15 = value; OnPropertyChanged("rate_15"); } } }

        string _rate_16;
        public string rate_16 { get { return _rate_16; } set { if (_rate_16 != value) { _rate_16 = value; OnPropertyChanged("rate_16"); } } }

        string _rate_17;
        public string rate_17 { get { return _rate_17; } set { if (_rate_17 != value) { _rate_17 = value; OnPropertyChanged("rate_17"); } } }

        string _rate_18;
        public string rate_18 { get { return _rate_18; } set { if (_rate_18 != value) { _rate_18 = value; OnPropertyChanged("rate_18"); } } }

        string _rate_19;
        public string rate_19 { get { return _rate_19; } set { if (_rate_19 != value) { _rate_19 = value; OnPropertyChanged("rate_19"); } } }

        string _rate_20;
        public string rate_20 { get { return _rate_20; } set { if (_rate_20 != value) { _rate_20 = value; OnPropertyChanged("rate_20"); } } }

        string _rate_21;
        public string rate_21 { get { return _rate_21; } set { if (_rate_21 != value) { _rate_21 = value; OnPropertyChanged("rate_21"); } } }

        string _rate_22;
        public string rate_22 { get { return _rate_22; } set { if (_rate_22 != value) { _rate_22 = value; OnPropertyChanged("rate_22"); } } }

        string _rate_23;
        public string rate_23 { get { return _rate_23; } set { if (_rate_23 != value) { _rate_23 = value; OnPropertyChanged("rate_23"); } } }

        string _rate_24;
        public string rate_24 { get { return _rate_24; } set { if (_rate_24 != value) { _rate_24 = value; OnPropertyChanged("rate_24"); } } }

        string _rate_25;
        public string rate_25 { get { return _rate_25; } set { if (_rate_25 != value) { _rate_25 = value; OnPropertyChanged("rate_25"); } } }

        #endregion Rate 

        #region FinalTime

        string _FinalTime_1;
        public string FinalTime_1 { get { return _FinalTime_1; } set { if (_FinalTime_1 != value) { _FinalTime_1 = value; OnPropertyChanged("FinalTime_1"); } } }

        string _FinalTime_2;
        public string FinalTime_2 { get { return _FinalTime_2; } set { if (_FinalTime_2 != value) { _FinalTime_2 = value; OnPropertyChanged("FinalTime_2"); } } }

        string _FinalTime_3;
        public string FinalTime_3 { get { return _FinalTime_3; } set { if (_FinalTime_3 != value) { _FinalTime_3 = value; OnPropertyChanged("FinalTime_3"); } } }

        string _FinalTime_4;
        public string FinalTime_4 { get { return _FinalTime_4; } set { if (_FinalTime_4 != value) { _FinalTime_4 = value; OnPropertyChanged("FinalTime_4"); } } }

        string _FinalTime_5;
        public string FinalTime_5 { get { return _FinalTime_5; } set { if (_FinalTime_5 != value) { _FinalTime_5 = value; OnPropertyChanged("FinalTime_5"); } } }

        string _FinalTime_6;
        public string FinalTime_6 { get { return _FinalTime_6; } set { if (_FinalTime_6 != value) { _FinalTime_6 = value; OnPropertyChanged("FinalTime_6"); } } }

        string _FinalTime_7;
        public string FinalTime_7 { get { return _FinalTime_7; } set { if (_FinalTime_7 != value) { _FinalTime_7 = value; OnPropertyChanged("FinalTime_7"); } } }

        string _FinalTime_8;
        public string FinalTime_8 { get { return _FinalTime_8; } set { if (_FinalTime_8 != value) { _FinalTime_8 = value; OnPropertyChanged("FinalTime_8"); } } }

        string _FinalTime_9;
        public string FinalTime_9 { get { return _FinalTime_9; } set { if (_FinalTime_9 != value) { _FinalTime_9 = value; OnPropertyChanged("FinalTime_9"); } } }

        string _FinalTime_10;
        public string FinalTime_10 { get { return _FinalTime_10; } set { if (_FinalTime_10 != value) { _FinalTime_10 = value; OnPropertyChanged("FinalTime_10"); } } }

        string _FinalTime_11;
        public string FinalTime_11 { get { return _FinalTime_11; } set { if (_FinalTime_11 != value) { _FinalTime_11 = value; OnPropertyChanged("FinalTime_11"); } } }

        string _FinalTime_12;
        public string FinalTime_12 { get { return _FinalTime_12; } set { if (_FinalTime_12 != value) { _FinalTime_12 = value; OnPropertyChanged("FinalTime_12"); } } }

        string _FinalTime_13;
        public string FinalTime_13 { get { return _FinalTime_13; } set { if (_FinalTime_13 != value) { _FinalTime_13 = value; OnPropertyChanged("FinalTime_13"); } } }

        string _FinalTime_14;
        public string FinalTime_14 { get { return _FinalTime_14; } set { if (_FinalTime_14 != value) { _FinalTime_14 = value; OnPropertyChanged("FinalTime_14"); } } }

        string _FinalTime_15;
        public string FinalTime_15 { get { return _FinalTime_15; } set { if (_FinalTime_15 != value) { _FinalTime_15 = value; OnPropertyChanged("FinalTime_15"); } } }

        string _FinalTime_16;
        public string FinalTime_16 { get { return _FinalTime_16; } set { if (_FinalTime_16 != value) { _FinalTime_16 = value; OnPropertyChanged("FinalTime_16"); } } }

        string _FinalTime_17;
        public string FinalTime_17 { get { return _FinalTime_17; } set { if (_FinalTime_17 != value) { _FinalTime_17 = value; OnPropertyChanged("FinalTime_17"); } } }

        string _FinalTime_18;
        public string FinalTime_18 { get { return _FinalTime_18; } set { if (_FinalTime_18 != value) { _FinalTime_18 = value; OnPropertyChanged("FinalTime_18"); } } }

        string _FinalTime_19;
        public string FinalTime_19 { get { return _FinalTime_19; } set { if (_FinalTime_19 != value) { _FinalTime_19 = value; OnPropertyChanged("FinalTime_19"); } } }

        string _FinalTime_20;
        public string FinalTime_20 { get { return _FinalTime_20; } set { if (_FinalTime_20 != value) { _FinalTime_20 = value; OnPropertyChanged("FinalTime_20"); } } }

        string _FinalTime_21;
        public string FinalTime_21 { get { return _FinalTime_21; } set { if (_FinalTime_21 != value) { _FinalTime_21 = value; OnPropertyChanged("FinalTime_21"); } } }

        string _FinalTime_22;
        public string FinalTime_22 { get { return _FinalTime_22; } set { if (_FinalTime_22 != value) { _FinalTime_22 = value; OnPropertyChanged("FinalTime_22"); } } }

        string _FinalTime_23;
        public string FinalTime_23 { get { return _FinalTime_23; } set { if (_FinalTime_23 != value) { _FinalTime_23 = value; OnPropertyChanged("FinalTime_23"); } } }

        string _FinalTime_24;
        public string FinalTime_24 { get { return _FinalTime_24; } set { if (_FinalTime_24 != value) { _FinalTime_24 = value; OnPropertyChanged("FinalTime_24"); } } }

        string _FinalTime_25;
        public string FinalTime_25 { get { return _FinalTime_25; } set { if (_FinalTime_25 != value) { _FinalTime_25 = value; OnPropertyChanged("FinalTime_25"); } } }

        #endregion FinalTime

        #region FinalTemp

        string _FinalTemp_1;
        public string FinalTemp_1 { get { return _FinalTemp_1; } set { if (_FinalTemp_1 != value) { _FinalTemp_1 = value; OnPropertyChanged("FinalTemp_1"); } } }

        string _FinalTemp_2;
        public string FinalTemp_2 { get { return _FinalTemp_2; } set { if (_FinalTemp_2 != value) { _FinalTemp_2 = value; OnPropertyChanged("FinalTemp_2"); } } }

        string _FinalTemp_3;
        public string FinalTemp_3 { get { return _FinalTemp_3; } set { if (_FinalTemp_3 != value) { _FinalTemp_3 = value; OnPropertyChanged("FinalTemp_3"); } } }

        string _FinalTemp_4;
        public string FinalTemp_4 { get { return _FinalTemp_4; } set { if (_FinalTemp_4 != value) { _FinalTemp_4 = value; OnPropertyChanged("FinalTemp_4"); } } }

        string _FinalTemp_5;
        public string FinalTemp_5 { get { return _FinalTemp_5; } set { if (_FinalTemp_5 != value) { _FinalTemp_5 = value; OnPropertyChanged("FinalTemp_5"); } } }

        string _FinalTemp_6;
        public string FinalTemp_6 { get { return _FinalTemp_6; } set { if (_FinalTemp_6 != value) { _FinalTemp_6 = value; OnPropertyChanged("FinalTemp_6"); } } }

        string _FinalTemp_7;
        public string FinalTemp_7 { get { return _FinalTemp_7; } set { if (_FinalTemp_7 != value) { _FinalTemp_7 = value; OnPropertyChanged("FinalTemp_7"); } } }

        string _FinalTemp_8;
        public string FinalTemp_8 { get { return _FinalTemp_8; } set { if (_FinalTemp_8 != value) { _FinalTemp_8 = value; OnPropertyChanged("FinalTemp_8"); } } }

        string _FinalTemp_9;
        public string FinalTemp_9 { get { return _FinalTemp_9; } set { if (_FinalTemp_9 != value) { _FinalTemp_9 = value; OnPropertyChanged("FinalTemp_9"); } } }

        string _FinalTemp_10;
        public string FinalTemp_10 { get { return _FinalTemp_10; } set { if (_FinalTemp_10 != value) { _FinalTemp_10 = value; OnPropertyChanged("FinalTemp_10"); } } }

        string _FinalTemp_11;
        public string FinalTemp_11 { get { return _FinalTemp_11; } set { if (_FinalTemp_11 != value) { _FinalTemp_11 = value; OnPropertyChanged("FinalTemp_11"); } } }

        string _FinalTemp_12;
        public string FinalTemp_12 { get { return _FinalTemp_12; } set { if (_FinalTemp_12 != value) { _FinalTemp_12 = value; OnPropertyChanged("FinalTemp_12"); } } }

        string _FinalTemp_13;
        public string FinalTemp_13 { get { return _FinalTemp_13; } set { if (_FinalTemp_13 != value) { _FinalTemp_13 = value; OnPropertyChanged("FinalTemp_13"); } } }

        string _FinalTemp_14;
        public string FinalTemp_14 { get { return _FinalTemp_14; } set { if (_FinalTemp_14 != value) { _FinalTemp_14 = value; OnPropertyChanged("FinalTemp_14"); } } }

        string _FinalTemp_15;
        public string FinalTemp_15 { get { return _FinalTemp_15; } set { if (_FinalTemp_15 != value) { _FinalTemp_15 = value; OnPropertyChanged("FinalTemp_15"); } } }

        string _FinalTemp_16;
        public string FinalTemp_16 { get { return _FinalTemp_16; } set { if (_FinalTemp_16 != value) { _FinalTemp_16 = value; OnPropertyChanged("FinalTemp_16"); } } }

        string _FinalTemp_17;
        public string FinalTemp_17 { get { return _FinalTemp_17; } set { if (_FinalTemp_17 != value) { _FinalTemp_17 = value; OnPropertyChanged("FinalTemp_17"); } } }

        string _FinalTemp_18;
        public string FinalTemp_18 { get { return _FinalTemp_18; } set { if (_FinalTemp_18 != value) { _FinalTemp_18 = value; OnPropertyChanged("FinalTemp_18"); } } }

        string _FinalTemp_19;
        public string FinalTemp_19 { get { return _FinalTemp_19; } set { if (_FinalTemp_19 != value) { _FinalTemp_19 = value; OnPropertyChanged("FinalTemp_19"); } } }

        string _FinalTemp_20;
        public string FinalTemp_20 { get { return _FinalTemp_20; } set { if (_FinalTemp_20 != value) { _FinalTemp_20 = value; OnPropertyChanged("FinalTemp_20"); } } }

        string _FinalTemp_21;
        public string FinalTemp_21 { get { return _FinalTemp_21; } set { if (_FinalTemp_21 != value) { _FinalTemp_21 = value; OnPropertyChanged("FinalTemp_21"); } } }

        string _FinalTemp_22;
        public string FinalTemp_22 { get { return _FinalTemp_22; } set { if (_FinalTemp_22 != value) { _FinalTemp_22 = value; OnPropertyChanged("FinalTemp_22"); } } }

        string _FinalTemp_23;
        public string FinalTemp_23 { get { return _FinalTemp_23; } set { if (_FinalTemp_23 != value) { _FinalTemp_23 = value; OnPropertyChanged("FinalTemp_23"); } } }

        string _FinalTemp_24;
        public string FinalTemp_24 { get { return _FinalTemp_24; } set { if (_FinalTemp_24 != value) { _FinalTemp_24 = value; OnPropertyChanged("FinalTemp_24"); } } }

        string _FinalTemp_25;
        public string FinalTemp_25 { get { return _FinalTemp_25; } set { if (_FinalTemp_25 != value) { _FinalTemp_25 = value; OnPropertyChanged("FinalTemp_25"); } } }

        #endregion FinalTemp

        #endregion Property

        #region Command

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
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TIME:
                        {
                            fInitTime = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_1:
                        {
                            rate_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_1:
                        {
                            FinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_1:
                        {
                            FinalTemp_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_2:
                        {
                            rate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_2:
                        {
                            FinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_2:
                        {
                            FinalTemp_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[1].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_3:
                        {
                            rate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_3:
                        {
                            FinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_3:
                        {
                            FinalTemp_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[2].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_4:
                        {
                            rate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_4:
                        {
                            FinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_4:
                        {
                            FinalTemp_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[3].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_5:
                        {
                            rate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_5:
                        {
                            FinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_5:
                        {
                            FinalTemp_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[4].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_6:
                        {
                            rate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_6:
                        {
                            FinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_6:
                        {
                            FinalTemp_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[5].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_7:
                        {
                            rate_7 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[6].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_7:
                        {
                            FinalTime_7 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[6].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_7:
                        {
                            FinalTemp_7 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[6].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_8:
                        {
                            rate_8 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[7].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_8:
                        {
                            FinalTime_8 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[7].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_8:
                        {
                            FinalTemp_8 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[7].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_9:
                        {
                            rate_9 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[8].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_9:
                        {
                            FinalTime_9 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[8].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_9:
                        {
                            FinalTemp_9 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[8].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_10:
                        {
                            rate_10 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[9].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_10:
                        {
                            FinalTime_10 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[9].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_10:
                        {
                            FinalTemp_10 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[9].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_11:
                        {
                            rate_11 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[10].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_11:
                        {
                            FinalTime_11 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[10].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_11:
                        {
                            FinalTemp_11 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[10].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_12:
                        {
                            rate_12 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[11].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_12:
                        {
                            FinalTime_12 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[11].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_12:
                        {
                            FinalTemp_12 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[11].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_13:
                        {
                            rate_13 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[12].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_13:
                        {
                            FinalTime_13 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[12].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_13:
                        {
                            FinalTemp_13 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[12].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_14:
                        {
                            rate_14 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[13].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_14:
                        {
                            FinalTime_14 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[13].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_14:
                        {
                            FinalTemp_14 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[13].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_15:
                        {
                            rate_15 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[14].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_15:
                        {
                            FinalTime_15 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[14].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_15:
                        {
                            FinalTemp_15 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[14].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_16:
                        {
                            rate_16 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[15].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_16:
                        {
                            FinalTime_16 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[15].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_16:
                        {
                            FinalTemp_16 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[15].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_17:
                        {
                            rate_17 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[16].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_17:
                        {
                            FinalTime_17 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[16].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_17:
                        {
                            FinalTemp_17 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[16].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_18:
                        {
                            rate_18 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[17].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_18:
                        {
                            FinalTime_18 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[17].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_18:
                        {
                            FinalTemp_18 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[17].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_19:
                        {
                            rate_19 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[18].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_19:
                        {
                            FinalTime_19 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[18].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_19:
                        {
                            FinalTemp_19 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[18].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_20:
                        {
                            rate_20 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[19].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_20:
                        {
                            FinalTime_20 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[19].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_20:
                        {
                            FinalTemp_20 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[19].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_21:
                        {
                            rate_21 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[20].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_21:
                        {
                            FinalTime_21 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[20].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_21:
                        {
                            FinalTemp_21 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[20].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_22:
                        {
                            rate_22 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[21].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_22:
                        {
                            FinalTime_22 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[21].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_22:
                        {
                            FinalTemp_22 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[21].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_23:
                        {
                            rate_23 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[22].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_23:
                        {
                            FinalTime_23 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[22].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_23:
                        {
                            FinalTemp_23 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[22].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_24:
                        {
                            rate_24 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[23].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_24:
                        {
                            FinalTime_24 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[23].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_24:
                        {
                            FinalTemp_24 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[23].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_25:
                        {
                            rate_25 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[24].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_25:
                        {
                            FinalTime_25 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[24].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_25:
                        {
                            FinalTemp_25 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[24].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
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

            switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
            {
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP:
                    {
                        bTempOnoff = true;
                        DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.bTempOnoff = 1;
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_TEMPERATURE_ON, tcpManager);
                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
            }

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
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP:
                    {
                        bTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.bTempOnoff = 0;
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_TEMPERATURE_OFF, tcpManager);
                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
            }
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

        #region DefaultCommand
        public RelayCommand DefaultCommand { get; set; }
        private void DefaultCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("DefaultCommand Fired");
        }
        #endregion DefaultCommand 

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
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP:
                    {
                        vmKeyPad.Title = "Temperature";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = fTempSet;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TIME:
                    {
                        vmKeyPad.Title = "Tempreature Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fInitTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TIME;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_1:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_1:
                    {
                        vmKeyPad.Title = "FinalTemp 1";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "FinalTime 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_1;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_2:
                    {
                        vmKeyPad.Title = "FinalTemp 2";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "FinalTime 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_3:
                    {
                        vmKeyPad.Title = "FinalTemp 3";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "FinalTime 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_3;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_4:
                    {
                        vmKeyPad.Title = "FinalTemp 4";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "FinalTime 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_4;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_5:
                    {
                        vmKeyPad.Title = "FinalTemp 5";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "FinalTime 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_5;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 6";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_6:
                    {
                        vmKeyPad.Title = "FinalTemp 6";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "FinalTime 6";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_6;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_7:
                    {
                        vmKeyPad.Title = "Rate 7";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_7;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_7;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_7:
                    {
                        vmKeyPad.Title = "FinalTemp 7";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_7;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_7;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_7:
                    {
                        vmKeyPad.Title = "FinalTime 7";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_7;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_7;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_8:
                    {
                        vmKeyPad.Title = "Rate 8";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_8;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_8;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_8:
                    {
                        vmKeyPad.Title = "FinalTemp 8";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_8;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_8;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_8:
                    {
                        vmKeyPad.Title = "FinalTime 8";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_8;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_8;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_9:
                    {
                        vmKeyPad.Title = "Rate 9";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_9;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_9;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_9:
                    {
                        vmKeyPad.Title = "FinalTemp 9";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_9;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_9;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_9:
                    {
                        vmKeyPad.Title = "FinalTime 9";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_9;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_9;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_10:
                    {
                        vmKeyPad.Title = "Rate 10";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_10;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_10;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_10:
                    {
                        vmKeyPad.Title = "FinalTemp 10";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_10;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_10;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_10:
                    {
                        vmKeyPad.Title = "FinalTime 10";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_10;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_10;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_11:
                    {
                        vmKeyPad.Title = "Rate 11";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_11;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_11;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_11:
                    {
                        vmKeyPad.Title = "FinalTemp 11";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_11;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_11;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_11:
                    {
                        vmKeyPad.Title = "FinalTime 11";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_11;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_11;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_12:
                    {
                        vmKeyPad.Title = "Rate 12";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_12;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_12;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_12:
                    {
                        vmKeyPad.Title = "FinalTemp 12";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_12;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_12;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_12:
                    {
                        vmKeyPad.Title = "FinalTime 12";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_12;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_12;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_13:
                    {
                        vmKeyPad.Title = "Rate 13";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_13;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_13;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_13:
                    {
                        vmKeyPad.Title = "FinalTemp 13";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_13;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_13;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_13:
                    {
                        vmKeyPad.Title = "FinalTime 13";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_13;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_13;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_14:
                    {
                        vmKeyPad.Title = "Rate 14";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_14;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_14;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_14:
                    {
                        vmKeyPad.Title = "FinalTemp 14";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_14;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_14;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_14:
                    {
                        vmKeyPad.Title = "FinalTime 14";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_14;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_14;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_15:
                    {
                        vmKeyPad.Title = "Rate 15";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_15;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_15;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_15:
                    {
                        vmKeyPad.Title = "FinalTemp 15";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_15;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_15;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_15:
                    {
                        vmKeyPad.Title = "FinalTime 15";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_15;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_15;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_16:
                    {
                        vmKeyPad.Title = "Rate 16";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_16;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_16:
                    {
                        vmKeyPad.Title = "FinalTemp 16";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_16;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_16:
                    {
                        vmKeyPad.Title = "FinalTime 16";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_16;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_17:
                    {
                        vmKeyPad.Title = "Rate 17";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_17;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_17;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_17:
                    {
                        vmKeyPad.Title = "FinalTemp 17";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_17;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_17;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_17:
                    {
                        vmKeyPad.Title = "FinalTime 17";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_17;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_17;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_18:
                    {
                        vmKeyPad.Title = "Rate 18";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_18;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_18;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_18:
                    {
                        vmKeyPad.Title = "FinalTemp 18";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_18;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_18;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_18:
                    {
                        vmKeyPad.Title = "FinalTime 18";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_18;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_18;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_19:
                    {
                        vmKeyPad.Title = "Rate 19";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_19;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_19;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_19:
                    {
                        vmKeyPad.Title = "FinalTemp 19";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_19;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_19;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_19:
                    {
                        vmKeyPad.Title = "FinalTime 19";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_19;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_19;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_20:
                    {
                        vmKeyPad.Title = "Rate 20";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_20;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_20;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_20:
                    {
                        vmKeyPad.Title = "FinalTemp 20";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_20;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_20;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_20:
                    {
                        vmKeyPad.Title = "FinalTime 20";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_20;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_20;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_21:
                    {
                        vmKeyPad.Title = "Rate 21";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_21;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_21;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_21:
                    {
                        vmKeyPad.Title = "FinalTemp 21";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_21;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_21;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_21:
                    {
                        vmKeyPad.Title = "FinalTime 21";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_21;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_21;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_22:
                    {
                        vmKeyPad.Title = "Rate 22";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_22;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_22;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_22:
                    {
                        vmKeyPad.Title = "FinalTemp 22";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_22;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_22;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_22:
                    {
                        vmKeyPad.Title = "FinalTime 22";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_22;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_22;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_23:
                    {
                        vmKeyPad.Title = "Rate 23";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_23;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_23;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_23:
                    {
                        vmKeyPad.Title = "FinalTemp 23";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_23;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_23;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_23:
                    {
                        vmKeyPad.Title = "FinalTime 23";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_23;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_23;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_24:
                    {
                        vmKeyPad.Title = "Rate 24";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_24;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_24;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_24:
                    {
                        vmKeyPad.Title = "FinalTemp 24";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_24;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_24;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_24:
                    {
                        vmKeyPad.Title = "FinalTime 24";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_24;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_24;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_25:
                    {
                        vmKeyPad.Title = "Rate 25";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = rate_25;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_RATE_25;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_25:
                    {
                        vmKeyPad.Title = "FinalTemp 25";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = FinalTemp_25;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TEMP_25;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_25:
                    {
                        vmKeyPad.Title = "FinalTime 25";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = FinalTime_25;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_FINAL_TIME_25;
                    }
                    break;

            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region ProgramOnCommand

        public RelayCommand ProgramOnCommand { get; set; }
        private void ProgramOnCommandAction(object param)
        {
            btMode = true;
            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.btMode = 1;
            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_PROGRAM_ON, tcpManager);

            //TODO :             
            Debug.WriteLine("ProgramOnCommand Fired");
        }

        #endregion ProgramOnCommand 

        #region ProgramOffCommand

        public RelayCommand ProgramOffCommand { get; set; }
        private void ProgramOffCommandAction(object param)
        {
            btMode = false;
            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.btMode = 0;
            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_PROGRAM_OFF, tcpManager);
            //TODO :             
            Debug.WriteLine("ProgramOffCommand Fired");
        }

        #endregion ProgramOffCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
