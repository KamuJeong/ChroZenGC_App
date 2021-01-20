using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_System_Settings : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Settings()
        {
            StartStopCommand = new RelayCommand(StartStopCommandAction);

            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);

            RemoteAccess_OnCommand = new RelayCommand(RemoteAccess_OnCommandAction);
            RemoteAccess_OffCommand = new RelayCommand(RemoteAccess_OffCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        bool _bOnoff;
        public bool bOnoff { get { return _bOnoff; } set { _bOnoff = value; OnPropertyChanged("bOnoff"); } }
        float _fInitTemp;
        public float fInitTemp { get { return _fInitTemp; } set { _fInitTemp = value; OnPropertyChanged("fInitTemp"); } }
        string _fInitTime;
        public string fInitTime { get { return _fInitTime; } set { _fInitTime = value; OnPropertyChanged("fInitTime"); } }
        string _fRate;
        public string fRate { get { return _fRate; } set { _fRate = value; OnPropertyChanged("fRate"); } }
        float _fFinalTemp;
        public float fFinalTemp { get { return _fFinalTemp; } set { _fFinalTemp = value; OnPropertyChanged("fFinalTemp"); } }
        string _fFinalTime;
        public string fFinalTime { get { return _fFinalTime; } set { _fFinalTime = value; OnPropertyChanged("fFinalTime"); } }

        float _fTime;
        public float fTime { get { return _fTime; } set { _fTime = value; OnPropertyChanged("fTime"); } }
        bool _RemoteAccess_bOnoff;
        public bool RemoteAccess_bOnoff { get { return _RemoteAccess_bOnoff; } set { _RemoteAccess_bOnoff = value; OnPropertyChanged("RemoteAccess_bOnoff"); } }
        float _fEventTime1;
        public float fEventTime1 { get { return _fEventTime1; } set { _fEventTime1 = value; OnPropertyChanged("fEventTime1"); } }
        float _fEventTime2;
        public float fEventTime2 { get { return _fEventTime2; } set { _fEventTime2 = value; OnPropertyChanged("fEventTime2"); } }

        string _InstDate;

        /// <summary>
        /// T_INST_INFORM
        /// </summary>
        public string InstDate { get { return _InstDate; } set { _InstDate = value; OnPropertyChanged("InstDate"); } }

        string _Date;
        public string Date { get { return _Date; } set { _Date = value; OnPropertyChanged("Date"); } }

        string _Time;
        public string Time { get { return _Time; } set { _Time = value; OnPropertyChanged("Time"); } }

        #endregion Property

        #region Command

        #region StartStopCommand
        public RelayCommand StartStopCommand { get; set; }
        private void StartStopCommandAction(object param)
        {
            bOnoff = !bOnoff;

            //TODO :             
            Debug.WriteLine("StartStopCommand Fired");
        }
        #endregion StartStopCommand 

        #region RemoteAccess_OnCommand
        public RelayCommand RemoteAccess_OnCommand { get; set; }
        private void RemoteAccess_OnCommandAction(object param)
        {
            RemoteAccess_bOnoff = true;

            //TODO :             
            Debug.WriteLine("RemoteAccess_OnCommand Fired");
        }
        #endregion RemoteAccess_OnCommand 

        #region RemoteAccess_OffCommand
        public RelayCommand RemoteAccess_OffCommand { get; set; }
        private void RemoteAccess_OffCommandAction(object param)
        {
            RemoteAccess_bOnoff = false;

            //TODO :             
            Debug.WriteLine("RemoteAccess_OffCommand Fired");
        }
        #endregion RemoteAccess_OnCommand 


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
                    case E_KEY_PAD_SET_MEASURE_TYPE.SETTING_INIT_TEMP:
                        {
                            fInitTemp = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SETTING_INIT_TIME:
                        {
                            fInitTime = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SETTING_RATE:
                        {
                            fRate = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SETTING_FINAL_TEMP:
                        {
                            fFinalTemp = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET4_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.SETTING_FINAL_TIME:
                        {
                            fFinalTime = (byte)tempFloatVal;
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

            switch ((E_SYSTEM_SETTING_INPUT_TYPE)param)
            {
                case E_SYSTEM_SETTING_INPUT_TYPE.INIT_TEMP:
                    {
                        vmKeyPad.Title = "Init Temp";
                        vmKeyPad.CurrentValue = fInitTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 450;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_INIT_TEMP;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.INIT_TIME:
                    {
                        vmKeyPad.Title = "Init Time";
                        vmKeyPad.CurrentValue = fInitTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_INIT_TIME;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.RATE:
                    {
                        vmKeyPad.Title = "Rate";
                        vmKeyPad.CurrentValue = fRate.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 120;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_RATE;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.FINAL_TEMP:
                    {
                        vmKeyPad.Title = "Final Temp";
                        vmKeyPad.CurrentValue = fFinalTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 450;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_FINAL_TEMP;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.FINAL_TIME:
                    {
                        vmKeyPad.Title = "Final Time";
                        vmKeyPad.CurrentValue = fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_FINAL_TIME;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.REMOTE_TIME:
                    {
                        vmKeyPad.Title = "Remote Time";
                        vmKeyPad.CurrentValue = fTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_REMOTE_TIME;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.REMOTE_EVENT1:
                    {
                        vmKeyPad.Title = "Remote &#x0a;Event1";
                        vmKeyPad.CurrentValue = fEventTime1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_REMOTE_EVENT1;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.REMOTE_EVENT2:
                    {
                        vmKeyPad.Title = "Remote &#x0a;Event2";
                        vmKeyPad.CurrentValue = fEventTime2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_REMOTE_EVENT2;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.INSTALL_DATE:
                    {
                        vmKeyPad.Title = "Install Date";
                        vmKeyPad.CurrentValue = fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_INSTALL_DATE;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.DATE:
                    {
                        vmKeyPad.Title = "Date";
                        vmKeyPad.CurrentValue = fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_DATE;
                    }
                    break;
                case E_SYSTEM_SETTING_INPUT_TYPE.TIME:
                    {
                        vmKeyPad.Title = "Time";
                        vmKeyPad.CurrentValue = fFinalTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.SETTING_TIME;
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
