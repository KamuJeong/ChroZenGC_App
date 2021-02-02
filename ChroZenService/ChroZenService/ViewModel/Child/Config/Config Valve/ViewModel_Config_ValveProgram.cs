using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_Config_ValveProgram : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_ValveProgram()
        {
            ProgramStateChangeCommand = new RelayCommand(ProgramStateChangeCommandAction);

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

        ObservableCollection<string> _valveProgramPickerSource = new ObservableCollection<string>();
        public ObservableCollection<string> valveProgramPickerSource { get { return _valveProgramPickerSource; } set { _valveProgramPickerSource = value; OnPropertyChanged("valveProgramPickerSource"); } }

        float _fTime_1;
        public float fTime_1 { get { return _fTime_1; } set { _fTime_1 = value; OnPropertyChanged("fTime_1"); } }
        float _fTime_2;
        public float fTime_2 { get { return _fTime_2; } set { _fTime_2 = value; OnPropertyChanged("fTime_2"); } }
        float _fTime_3;
        public float fTime_3 { get { return _fTime_3; } set { _fTime_3 = value; OnPropertyChanged("fTime_3"); } }
        float _fTime_4;
        public float fTime_4 { get { return _fTime_4; } set { _fTime_4 = value; OnPropertyChanged("fTime_4"); } }
        float _fTime_5;
        public float fTime_5 { get { return _fTime_5; } set { _fTime_5 = value; OnPropertyChanged("fTime_5"); } }

        float _fTime_6;
        public float fTime_6 { get { return _fTime_6; } set { _fTime_6 = value; OnPropertyChanged("fTime_6"); } }
        float _fTime_7;
        public float fTime_7 { get { return _fTime_7; } set { _fTime_7 = value; OnPropertyChanged("fTime_7"); } }
        float _fTime_8;
        public float fTime_8 { get { return _fTime_8; } set { _fTime_8 = value; OnPropertyChanged("fTime_8"); } }
        float _fTime_9;
        public float fTime_9 { get { return _fTime_9; } set { _fTime_9 = value; OnPropertyChanged("fTime_9"); } }
        float _fTime_10;
        public float fTime_10 { get { return _fTime_10; } set { _fTime_10 = value; OnPropertyChanged("fTime_10"); } }

        float _fTime_11;
        public float fTime_11 { get { return _fTime_11; } set { _fTime_11 = value; OnPropertyChanged("fTime_11"); } }
        float _fTime_12;
        public float fTime_12 { get { return _fTime_12; } set { _fTime_12 = value; OnPropertyChanged("fTime_12"); } }
        float _fTime_13;
        public float fTime_13 { get { return _fTime_13; } set { _fTime_13 = value; OnPropertyChanged("fTime_13"); } }
        float _fTime_14;
        public float fTime_14 { get { return _fTime_14; } set { _fTime_14 = value; OnPropertyChanged("fTime_14"); } }
        float _fTime_15;
        public float fTime_15 { get { return _fTime_15; } set { _fTime_15 = value; OnPropertyChanged("fTime_15"); } }

        float _fTime_16;
        public float fTime_16 { get { return _fTime_16; } set { _fTime_16 = value; OnPropertyChanged("fTime_16"); } }
        float _fTime_17;
        public float fTime_17 { get { return _fTime_17; } set { _fTime_17 = value; OnPropertyChanged("fTime_17"); } }
        float _fTime_18;
        public float fTime_18 { get { return _fTime_18; } set { _fTime_18 = value; OnPropertyChanged("fTime_18"); } }
        float _fTime_19;
        public float fTime_19 { get { return _fTime_19; } set { _fTime_19 = value; OnPropertyChanged("fTime_19"); } }
        float _fTime_20;
        public float fTime_20 { get { return _fTime_20; } set { _fTime_20 = value; OnPropertyChanged("fTime_20"); } }

        byte _btNumber_1;
        public byte btNumber_1 { get { return _btNumber_1; } set { _btNumber_1 = value; OnPropertyChanged("btNumber_1"); } }
        byte _btNumber_2;
        public byte btNumber_2 { get { return _btNumber_2; } set { _btNumber_2 = value; OnPropertyChanged("btNumber_2"); } }
        byte _btNumber_3;
        public byte btNumber_3 { get { return _btNumber_3; } set { _btNumber_3 = value; OnPropertyChanged("btNumber_3"); } }
        byte _btNumber_4;
        public byte btNumber_4 { get { return _btNumber_4; } set { _btNumber_4 = value; OnPropertyChanged("btNumber_4"); } }
        byte _btNumber_5;
        public byte btNumber_5 { get { return _btNumber_5; } set { _btNumber_5 = value; OnPropertyChanged("btNumber_5"); } }

        byte _btNumber_6;
        public byte btNumber_6 { get { return _btNumber_6; } set { _btNumber_6 = value; OnPropertyChanged("btNumber_6"); } }
        byte _btNumber_7;
        public byte btNumber_7 { get { return _btNumber_7; } set { _btNumber_7 = value; OnPropertyChanged("btNumber_7"); } }
        byte _btNumber_8;
        public byte btNumber_8 { get { return _btNumber_8; } set { _btNumber_8 = value; OnPropertyChanged("btNumber_8"); } }
        byte _btNumber_9;
        public byte btNumber_9 { get { return _btNumber_9; } set { _btNumber_9 = value; OnPropertyChanged("btNumber_9"); } }
        byte _btNumber_10;
        public byte btNumber_10 { get { return _btNumber_10; } set { _btNumber_10 = value; OnPropertyChanged("btNumber_10"); } }

        byte _btNumber_11;
        public byte btNumber_11 { get { return _btNumber_11; } set { _btNumber_11 = value; OnPropertyChanged("btNumber_11"); } }
        byte _btNumber_12;
        public byte btNumber_12 { get { return _btNumber_12; } set { _btNumber_12 = value; OnPropertyChanged("btNumber_12"); } }
        byte _btNumber_13;
        public byte btNumber_13 { get { return _btNumber_13; } set { _btNumber_13 = value; OnPropertyChanged("btNumber_13"); } }
        byte _btNumber_14;
        public byte btNumber_14 { get { return _btNumber_14; } set { _btNumber_14 = value; OnPropertyChanged("btNumber_14"); } }
        byte _btNumber_15;
        public byte btNumber_15 { get { return _btNumber_15; } set { _btNumber_15 = value; OnPropertyChanged("btNumber_15"); } }

        byte _btNumber_16;
        public byte btNumber_16 { get { return _btNumber_16; } set { _btNumber_16 = value; OnPropertyChanged("btNumber_16"); } }
        byte _btNumber_17;
        public byte btNumber_17 { get { return _btNumber_17; } set { _btNumber_17 = value; OnPropertyChanged("btNumber_17"); } }
        byte _btNumber_18;
        public byte btNumber_18 { get { return _btNumber_18; } set { _btNumber_18 = value; OnPropertyChanged("btNumber_18"); } }
        byte _btNumber_19;
        public byte btNumber_19 { get { return _btNumber_19; } set { _btNumber_19 = value; OnPropertyChanged("btNumber_19"); } }
        byte _btNumber_20;
        public byte btNumber_20 { get { return _btNumber_20; } set { _btNumber_20 = value; OnPropertyChanged("btNumber_20"); } }

        byte _btState_1;
        public byte btState_1 { get { return _btState_1; } set { _btState_1 = value; OnPropertyChanged("btState_1"); } }
        byte _btState_2;
        public byte btState_2 { get { return _btState_2; } set { _btState_2 = value; OnPropertyChanged("btState_2"); } }
        byte _btState_3;
        public byte btState_3 { get { return _btState_3; } set { _btState_3 = value; OnPropertyChanged("btState_3"); } }
        byte _btState_4;
        public byte btState_4 { get { return _btState_4; } set { _btState_4 = value; OnPropertyChanged("btState_4"); } }
        byte _btState_5;
        public byte btState_5 { get { return _btState_5; } set { _btState_5 = value; OnPropertyChanged("btState_5"); } }

        byte _btState_6;
        public byte btState_6 { get { return _btState_6; } set { _btState_6 = value; OnPropertyChanged("btState_6"); } }
        byte _btState_7;
        public byte btState_7 { get { return _btState_7; } set { _btState_7 = value; OnPropertyChanged("btState_7"); } }
        byte _btState_8;
        public byte btState_8 { get { return _btState_8; } set { _btState_8 = value; OnPropertyChanged("btState_8"); } }
        byte _btState_9;
        public byte btState_9 { get { return _btState_9; } set { _btState_9 = value; OnPropertyChanged("btState_9"); } }
        byte _btState_10;
        public byte btState_10 { get { return _btState_10; } set { _btState_10 = value; OnPropertyChanged("btState_10"); } }

        byte _btState_11;
        public byte btState_11 { get { return _btState_11; } set { _btState_11 = value; OnPropertyChanged("btState_11"); } }
        byte _btState_12;
        public byte btState_12 { get { return _btState_12; } set { _btState_12 = value; OnPropertyChanged("btState_12"); } }
        byte _btState_13;
        public byte btState_13 { get { return _btState_13; } set { _btState_13 = value; OnPropertyChanged("btState_13"); } }
        byte _btState_14;
        public byte btState_14 { get { return _btState_14; } set { _btState_14 = value; OnPropertyChanged("btState_14"); } }
        byte _btState_15;
        public byte btState_15 { get { return _btState_15; } set { _btState_15 = value; OnPropertyChanged("btState_15"); } }

        byte _btState_16;
        public byte btState_16 { get { return _btState_16; } set { _btState_16 = value; OnPropertyChanged("btState_16"); } }
        byte _btState_17;
        public byte btState_17 { get { return _btState_17; } set { _btState_17 = value; OnPropertyChanged("btState_17"); } }
        byte _btState_18;
        public byte btState_18 { get { return _btState_18; } set { _btState_18 = value; OnPropertyChanged("btState_18"); } }
        byte _btState_19;
        public byte btState_19 { get { return _btState_19; } set { _btState_19 = value; OnPropertyChanged("btState_19"); } }
        byte _btState_20;
        public byte btState_20 { get { return _btState_20; } set { _btState_20 = value; OnPropertyChanged("btState_20"); } }


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
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_1:
                        {
                            fTime_1 = tempFloatVal;

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_2:
                        {
                            fTime_2 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_3:
                        {
                            fTime_3 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_4:
                        {
                            fTime_4 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_5:
                        {
                            fTime_5 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_6:
                        {
                            fTime_6 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_7:
                        {
                            fTime_7 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_8:
                        {
                            fTime_8 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_9:
                        {
                            fTime_9 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_10:
                        {
                            fTime_10 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_11:
                        {
                            fTime_11 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_12:
                        {
                            fTime_12 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_13:
                        {
                            fTime_13 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_14:
                        {
                            fTime_14 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_15:
                        {
                            fTime_15 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_16:
                        {
                            fTime_16 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_17:
                        {
                            fTime_17 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_18:
                        {
                            fTime_18 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_19:
                        {
                            fTime_19 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_20:
                        {
                            fTime_20 = tempFloatVal;
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

        #region ProgramStateChangeCommand
        public RelayCommand ProgramStateChangeCommand { get; set; }
        private void ProgramStateChangeCommandAction(object param)
        {
            switch((E_GLOBAL_COMMAND_TYPE)param)
            {
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_1:
                    {
                        if (btState_1 == 0) btState_1 = 1;
                        else btState_1 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[0].btState = btState_1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_2:
                    {
                        if (btState_2 == 0) btState_2 = 1;
                        else btState_2 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[1].btState = btState_2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_3:
                    {
                        if (btState_3 == 0) btState_3 = 1;
                        else btState_3 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[2].btState = btState_3;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_4:
                    {
                        if (btState_4 == 0) btState_4 = 1;
                        else btState_4 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[3].btState = btState_4;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_5:
                    {
                        if (btState_5 == 0) btState_5 = 1;
                        else btState_5 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[4].btState = btState_5;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_6:
                    {
                        if (btState_6 == 0) btState_6 = 1;
                        else btState_6 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[5].btState = btState_6;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_7:
                    {
                        if (btState_7 == 0) btState_7 = 1;
                        else btState_7 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[6].btState = btState_7;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_8:
                    {
                        if (btState_8 == 0) btState_8 = 1;
                        else btState_8 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[7].btState = btState_8;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_9:
                    {
                        if (btState_9 == 0) btState_9 = 1;
                        else btState_9 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[8].btState = btState_9;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_10:
                    {
                        if (btState_10 == 0) btState_10 = 1;
                        else btState_10 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[9].btState = btState_10;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;

                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_11:
                    {
                        if (btState_11 == 0) btState_11 = 1;
                        else btState_11 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[10].btState = btState_11;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_12:
                    {
                        if (btState_12 == 0) btState_12 = 1;
                        else btState_12 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[11].btState = btState_12;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_13:
                    {
                        if (btState_13 == 0) btState_13 = 1;
                        else btState_13 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[12].btState = btState_13;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_14:
                    {
                        if (btState_14 == 0) btState_14 = 1;
                        else btState_14 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[13].btState = btState_14;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_15:
                    {
                        if (btState_15 == 0) btState_15 = 1;
                        else btState_15 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[14].btState = btState_15;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_16:
                    {
                        if (btState_16 == 0) btState_16 = 1;
                        else btState_16 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[15].btState = btState_16;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_17:
                    {
                        if (btState_17 == 0) btState_17 = 1;
                        else btState_17 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[16].btState = btState_17;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_18:
                    {
                        if (btState_18 == 0) btState_18 = 1;
                        else btState_18 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[17].btState = btState_18;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_19:
                    {
                        if (btState_19 == 0) btState_19 = 1;
                        else btState_19 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[18].btState = btState_19;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_PROGRAM_STATE_20:
                    {
                        if (btState_20 == 0) btState_20 = 1;
                        else btState_20 = 0;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet.Prgm[19].btState = btState_20;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("ProgramStateChangeCommand Fired");
        }
        #endregion ProgramStateChangeCommand 

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
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_1:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_2:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_3:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_4:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_5:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_6:
                    {
                        vmKeyPad.Title = "Time 6";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_6.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_6;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_7:
                    {
                        vmKeyPad.Title = "Time 7";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_7.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_7;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_8:
                    {
                        vmKeyPad.Title = "Time 8";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_8.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_8;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_9:
                    {
                        vmKeyPad.Title = "Time 9";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_9.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_9;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_10:
                    {
                        vmKeyPad.Title = "Time 10";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_10.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_10;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_11:
                    {
                        vmKeyPad.Title = "Time 11";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_11.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_11;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_12:
                    {
                        vmKeyPad.Title = "Time 12";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_12.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_12;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_13:
                    {
                        vmKeyPad.Title = "Time 13";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_13.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_13;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_14:
                    {
                        vmKeyPad.Title = "Time 14";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_14.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_14;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_15:
                    {
                        vmKeyPad.Title = "Time 15";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_15.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_15;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_16:
                    {
                        vmKeyPad.Title = "Time 16";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_16.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_16;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_17:
                    {
                        vmKeyPad.Title = "Time 17";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_17.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_17;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_18:
                    {
                        vmKeyPad.Title = "Time 18";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_18.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_18;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_19:
                    {
                        vmKeyPad.Title = "Time 19";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_19.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_19;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_20:
                    {
                        vmKeyPad.Title = "Time 20";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_20.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.VALVE_PROGRAM_TIME_20;
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
