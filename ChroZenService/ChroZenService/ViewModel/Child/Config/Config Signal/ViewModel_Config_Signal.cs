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
    public class ViewModel_Config_Signal : Model_Config
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_Signal(int nIndex)
        {
            nSignalIndex = nIndex;
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            SignalChangeOnCommand = new RelayCommand(SignalChangeOnCommandAction);
            SignalChangeOffCommand = new RelayCommand(SignalChangeOffCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        TCPManager tcpManager;

        public int nSignalIndex;

        float _fZero;
        public float fZero { get { return _fZero; } set { if (_fZero != value) { _fZero = value; OnPropertyChanged("fZero"); } } }

        float _fSensitivity;
        public float fSensitivity { get { return _fSensitivity; } set { if (_fSensitivity != value) { _fSensitivity = value; OnPropertyChanged("fSensitivity"); } } }

        bool _bSignalChange;
        public bool bSignalChange { get { return _bSignalChange; } set { if (_bSignalChange != value) { _bSignalChange = value; OnPropertyChanged("bSignalChange"); } } }



        int _btDet_0;
        public int btDet_0 { get { return _btDet_0; } set { if (_btDet_0 != value) { _btDet_0 = value; OnPropertyChanged("btDet_0"); } } }

        float _fTime_1;
        public float fTime_1 { get { return _fTime_1; } set { if (_fTime_1 != value) { _fTime_1 = value; OnPropertyChanged("fTime_1"); } } }

        int _btDet_1;
        public int btDet_1 { get { return _btDet_1; } set { if (_btDet_1 != value) { _btDet_1 = value; OnPropertyChanged("btDet_1"); } } }

        float _fTime_2;
        public float fTime_2 { get { return _fTime_2; } set { if (_fTime_2 != value) { _fTime_2 = value; OnPropertyChanged("fTime_2"); } } }

        int _btDet_2;
        public int btDet_2 { get { return _btDet_2; } set { if (_btDet_2 != value) { _btDet_2 = value; OnPropertyChanged("btDet_2"); } } }

        float _fTime_3;
        public float fTime_3 { get { return _fTime_3; } set { if (_fTime_3 != value) { _fTime_3 = value; OnPropertyChanged("fTime_3"); } } }

        int _btDet_3;
        public int btDet_3 { get { return _btDet_3; } set { if (_btDet_3 != value) { _btDet_3 = value; OnPropertyChanged("btDet_3"); } } }

        float _fTime_4;
        public float fTime_4 { get { return _fTime_4; } set { if (_fTime_4 != value) { _fTime_4 = value; OnPropertyChanged("fTime_4"); } } }

        int _btDet_4;
        public int btDet_4 { get { return _btDet_4; } set { if (_btDet_4 != value) { _btDet_4 = value; OnPropertyChanged("btDet_4"); } } }

        float _fTime_5;
        public float fTime_5 { get { return _fTime_5; } set { if (_fTime_5 != value) { _fTime_5 = value; OnPropertyChanged("fTime_5"); } } }

        int _btDet_5;
        public int btDet_5 { get { return _btDet_5; } set { if (_btDet_5 != value) { _btDet_5 = value; OnPropertyChanged("btDet_5"); } } }


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

            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0)
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
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_SIGNAL_ZERO:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_SIGNAL_ZERO:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_SIGNAL_ZERO:
                        {
                            fZero = tempFloatVal;

                            switch (nSignalIndex)
                            {
                                case 1:
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.fZero = fZero;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet));
                                    }
                                    break;
                                case 2:
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.fZero = fZero;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet));
                                    }
                                    break;
                                case 3:
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.fZero = fZero;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet));
                                    }
                                    break;
                            }
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_SENSITIVITY:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_SENSITIVITY:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_SENSITIVITY:
                        {
                            fSensitivity = tempFloatVal;

                            switch (nSignalIndex)
                            {
                                case 1:
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.fSensitivity = fSensitivity;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet));
                                    }
                                    break;
                                case 2:
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.fSensitivity = fSensitivity;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet));
                                    }
                                    break;
                                case 3:
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.fSensitivity = fSensitivity;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet));
                                    }
                                    break;
                            }
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_1:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_1:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_1:
                        {
                            fTime_1 = tempFloatVal;

                            SortTimeAndSource();
                            SetTimeAndSourcePrgmAndSend(nSignalIndex);
                           
                            //DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fRate = tempFloatVal;
                            //tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_2:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_2:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_2:
                        {
                            fTime_2 = tempFloatVal;

                            SortTimeAndSource();
                            SetTimeAndSourcePrgmAndSend(nSignalIndex);
                            //DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fRate = tempFloatVal;
                            //tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET2_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_3:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_3:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_3:
                        {
                            fTime_3 = tempFloatVal;

                            SortTimeAndSource();
                            SetTimeAndSourcePrgmAndSend(nSignalIndex);
                            //DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fRate = tempFloatVal;
                            //tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET3_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_4:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_4:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_4:
                        {
                            fTime_4 = tempFloatVal;

                            SortTimeAndSource();
                            SetTimeAndSourcePrgmAndSend(nSignalIndex);
                            //DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fRate = tempFloatVal;
                            //tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET4_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_5:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_5:
                    case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_5:
                        {
                            fTime_5 = tempFloatVal;

                            SortTimeAndSource();
                            SetTimeAndSourcePrgmAndSend(nSignalIndex);
                            //DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet.Prgm[0].fRate = tempFloatVal;
                            //tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET5_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
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

            //switch ((E_KEY_PAD_SET_MEASURE_TYPE)param)
            //{
            //    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP:
            //        {
            //            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_TEMPERATURE_ON, tcpManager);
            //        }
            //        break;
            //}

        }

        #endregion KeyPad : OnCommand

        #region KeyPad : OffCommand

        public RelayCommand KeyPadOffCommand { get; set; }
        private void KeyPadOffCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            //switch ((E_KEY_PAD_SET_MEASURE_TYPE)param)
            //{
            //    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_SETTING_TEMP:
            //        {
            //            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_SETTING_TEMPERATURE_OFF, tcpManager);
            //        }
            //        break;
            //}
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
                        else if (mainVM.ViewModel_KeyPad.CurrentValue == "0") //20210407 권민경: 기존값이 0일때 0 지우기
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue + sender.Text, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue = sender.Text;
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
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_SIGNAL_ZERO:
                    {
                        vmKeyPad.Title = "Signal Zero";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fZero.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_SIGNAL_ZERO;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_SIGNAL_ZERO:
                    {
                        vmKeyPad.Title = "Signal Zero";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fZero.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_SIGNAL_ZERO;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_SIGNAL_ZERO:
                    {
                        vmKeyPad.Title = "Signal Zero";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fZero.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_SIGNAL_ZERO;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_SENSITIVITY:
                    {
                        vmKeyPad.Title = "Sensitivity";
                        vmKeyPad.MaxValue = 10;
                        vmKeyPad.CurrentValue = fSensitivity.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_SENSITIVITY;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_SENSITIVITY:
                    {
                        vmKeyPad.Title = "Sensitivity";
                        vmKeyPad.MaxValue = 10;
                        vmKeyPad.CurrentValue = fSensitivity.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_SENSITIVITY;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_SENSITIVITY:
                    {
                        vmKeyPad.Title = "Sensitivity";
                        vmKeyPad.MaxValue = 10;
                        vmKeyPad.CurrentValue = fSensitivity.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_SENSITIVITY;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_1:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_2:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_3:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_4:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_5:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_1_PROGRAM_TIME_5;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_1:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_2:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_3:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_4:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_5:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_2_PROGRAM_TIME_5;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_1:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_2:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_3:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_4:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_5:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fTime_5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SIGNAL_3_PROGRAM_TIME_5;
                    }
                    break;
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region SignalChangeOnCommand

        public RelayCommand SignalChangeOnCommand { get; set; }
        private void SignalChangeOnCommandAction(object param)
        {
            bSignalChange = true;

            switch ((E_GLOBAL_COMMAND_TYPE)param)
            {
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_FRONT_SIGNAL_CHANGE_ON:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.bSignalChange = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet));

                        //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_FRONT_SIGNAL_CHANGE_ON, tcpManager);
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_CENTER_SIGNAL_CHANGE_ON:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.bSignalChange = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet));
                        //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_CENTER_SIGNAL_CHANGE_ON, tcpManager);
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_REAR_SIGNAL_CHANGE_ON:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.bSignalChange = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet));
                        //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_REAR_SIGNAL_CHANGE_ON, tcpManager);
                    }
                    break;
            }


            //TODO :             
            Debug.WriteLine("SignalChangeOnCommand Fired");
        }

        #endregion SignalChangeOnCommand 

        #region SignalChangeOffCommand

        public RelayCommand SignalChangeOffCommand { get; set; }
        private void SignalChangeOffCommandAction(object param)
        {
            bSignalChange = false;
            switch ((E_GLOBAL_COMMAND_TYPE)param)
            {
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_FRONT_SIGNAL_CHANGE_ON:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.bSignalChange = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet));
                        //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_FRONT_SIGNAL_CHANGE_OFF, tcpManager);
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_CENTER_SIGNAL_CHANGE_ON:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.bSignalChange = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet));
                        //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_CENTER_SIGNAL_CHANGE_OFF, tcpManager);
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_REAR_SIGNAL_CHANGE_ON:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.bSignalChange = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet));
                        //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_SIGNAL_REAR_SIGNAL_CHANGE_OFF, tcpManager);
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("SignalChangeOffCommand Fired");
        }

        #endregion SignalChangeOffCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        private void SortTimeAndSource()
        {
            List<Tuple<float, int>> listTimeSourceArr = new List<Tuple<float, int>>
            {
               new Tuple<float,int>(fTime_1, btDet_1 ),
               new Tuple<float,int>(fTime_2, btDet_2 ),
               new Tuple<float,int>(fTime_3, btDet_3 ),
               new Tuple<float,int>(fTime_4, btDet_4 ),
               new Tuple<float,int>(fTime_5, btDet_5 ),
            };

            int nRoopCount = 4;

            while (nRoopCount > 1)
            {
                for (int i = 0; i < nRoopCount; i++)
                {
                    if (listTimeSourceArr[i].Item1 > listTimeSourceArr[i + 1].Item1)
                    {
                        Tuple<float, int> tempTuple = new Tuple<float, int>(listTimeSourceArr[i + 1].Item1, listTimeSourceArr[i + 1].Item2);

                        listTimeSourceArr[i + 1] = new Tuple<float, int>(listTimeSourceArr[i].Item1, listTimeSourceArr[i].Item2);
                        listTimeSourceArr[i] = new Tuple<float, int>(tempTuple.Item1, tempTuple.Item2);
                    }
                }
                nRoopCount -= 1;
            }
            fTime_1 = listTimeSourceArr[0].Item1;
            btDet_1 = listTimeSourceArr[0].Item2;
            fTime_2 = listTimeSourceArr[1].Item1;
            btDet_2 = listTimeSourceArr[1].Item2;
            fTime_3 = listTimeSourceArr[2].Item1;
            btDet_3 = listTimeSourceArr[2].Item2;
            fTime_4 = listTimeSourceArr[3].Item1;
            btDet_4 = listTimeSourceArr[3].Item2;
            fTime_5 = listTimeSourceArr[4].Item1;
            btDet_5 = listTimeSourceArr[4].Item2;
        }

        private void SetTimeAndSourcePrgmAndSend(int nSignalIndex)
        {
            switch (nSignalIndex)
            {
                case 1:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[0].fTime = fTime_1;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[1].fTime = fTime_2;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[2].fTime = fTime_3;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[3].fTime = fTime_4;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[4].fTime = fTime_5;

                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[0].btDet = (byte)btDet_1;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[1].btDet = (byte)btDet_2;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[2].btDet = (byte)btDet_3;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[3].btDet = (byte)btDet_4;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet.Prgm[4].btDet = (byte)btDet_5;

                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send.packet));
                    }
                    break;
                case 2:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[0].fTime = fTime_1;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[1].fTime = fTime_2;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[2].fTime = fTime_3;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[3].fTime = fTime_4;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[4].fTime = fTime_5;

                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[0].btDet = (byte)btDet_1;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[1].btDet = (byte)btDet_2;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[2].btDet = (byte)btDet_3;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[3].btDet = (byte)btDet_4;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet.Prgm[4].btDet = (byte)btDet_5;

                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send.packet));
                    }
                    break;
                case 3:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[0].fTime = fTime_1;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[1].fTime = fTime_2;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[2].fTime = fTime_3;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[3].fTime = fTime_4;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[4].fTime = fTime_5;

                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[0].btDet = (byte)btDet_1;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[1].btDet = (byte)btDet_2;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[2].btDet = (byte)btDet_3;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[3].btDet = (byte)btDet_4;
                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet.Prgm[4].btDet = (byte)btDet_5;

                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send.packet));
                    }
                    break;
            }           
        }

        #endregion Instance Func
    }
}
