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
    public class ViewModel_Config_InletConfig : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_InletConfig()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            InletCarrierGasIndexChangeCommand = new RelayCommand(InletCarrierGasIndexChangeCommandAction);
            InletUPCModeIndexChangeCommand = new RelayCommand(InletUPCModeIndexChangeCommandAction);
            InletConnectionIndexChangeCommand = new RelayCommand(InletConnectionIndexChangeCommandAction);

            GasSaverOnCommand = new RelayCommand(GasSaverOnCommandAction);
            GasSaverOffCommand = new RelayCommand(GasSaverOffCommandAction);

            PressureCorrectOnCommand = new RelayCommand(PressureCorrectOnCommandAction);
            PressureCorrectOffCommand = new RelayCommand(PressureCorrectOffCommandAction);

            VacuumCorrectOnCommand = new RelayCommand(VacuumCorrectOnCommandAction);
            VacuumCorrectOffCommand = new RelayCommand(VacuumCorrectOffCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        E_INLET_TYPE _e_INLET_TYPE = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE e_INLET_TYPE { get { return _e_INLET_TYPE; } set { _e_INLET_TYPE = value; OnPropertyChanged("e_INLET_TYPE"); } }

        int _btCarriergas;
        public int btCarriergas { get { return _btCarriergas; } set { _btCarriergas = value; OnPropertyChanged("btCarriergas"); } }

        int _btApcMode;
        public int btApcMode { get { return _btApcMode; } set { _btApcMode = value; OnPropertyChanged("btApcMode"); } }

        int _ConnectionToDet;
        public int ConnectionToDet { get { return _ConnectionToDet; } set { _ConnectionToDet = value; OnPropertyChanged("ConnectionToDet"); } }


        string _fLength;
        public string fLength { get { return _fLength; } set { _fLength = value; OnPropertyChanged("fLength"); } }

        string _fDiameter;
        public string fDiameter { get { return _fDiameter; } set { _fDiameter = value; OnPropertyChanged("fDiameter"); } }

        string _fThickness;
        public string fThickness { get { return _fThickness; } set { _fThickness = value; OnPropertyChanged("fThickness"); } }

        bool _bGasSaverMode;
        public bool bGasSaverMode { get { return _bGasSaverMode; } set { _bGasSaverMode = value; OnPropertyChanged("bGasSaverMode"); } }

        string _fGasSaverFlow;
        public string fGasSaverFlow { get { return _fGasSaverFlow; } set { _fGasSaverFlow = value; OnPropertyChanged("fGasSaverFlow"); } }

        string _fGasSaverTime;
        public string fGasSaverTime { get { return _fGasSaverTime; } set { _fGasSaverTime = value; OnPropertyChanged("fGasSaverTime"); } }

        string _fPressureCorrect;
        public string fPressureCorrect { get { return _fPressureCorrect; } set { _fPressureCorrect = value; OnPropertyChanged("fPressureCorrect"); } }

        bool _bPressCorrect;
        public bool bPressCorrect { get { return _bPressCorrect; } set { _bPressCorrect = value; OnPropertyChanged("bPressCorrect"); } }

        bool _bVacuumCorrect;
        public bool bVacuumCorrect { get { return _bVacuumCorrect; } set { _bVacuumCorrect = value; OnPropertyChanged("bVacuumCorrect"); } }
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
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_LENGTH:
                        {
                            fLength = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.fLength = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_ID:
                        {
                            fDiameter = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.fDiameter = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_FILM_THICKNESS:
                        {
                            fThickness = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.fThickness = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_FLOW:
                        {
                            fGasSaverFlow = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.fGasSaverFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_TIME:
                        {
                            fGasSaverTime = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.fGasSaverTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_PRESSURE_CORRECT:
                        {
                            fPressureCorrect = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.fPressCorrect = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_LENGTH:
                        {
                            fLength = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.fLength = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_ID:
                        {
                            fDiameter = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.fDiameter = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_FILM_THICKNESS:
                        {
                            fThickness = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.fThickness = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_FLOW:
                        {
                            fGasSaverFlow = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.fGasSaverFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_TIME:
                        {
                            fGasSaverTime = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.fGasSaverTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_PRESSURE_CORRECT:
                        {
                            fPressureCorrect = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.fPressCorrect = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_LENGTH:
                        {
                            fLength = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.fLength = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_ID:
                        {
                            fDiameter = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.fDiameter = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_FILM_THICKNESS:
                        {
                            fThickness = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.fThickness = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_FLOW:
                        {
                            fGasSaverFlow = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.fGasSaverFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_TIME:
                        {
                            fGasSaverTime = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.fGasSaverTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_PRESSURE_CORRECT:
                        {
                            fPressureCorrect = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.fPressCorrect = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
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
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_LENGTH:
                    {
                        vmKeyPad.Title = "Length";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = fLength;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_LENGTH;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_ID:
                    {
                        vmKeyPad.Title = "I.D.";
                        vmKeyPad.MaxValue = 1;
                        vmKeyPad.CurrentValue = fDiameter;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_ID;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_FILM_THICKNESS:
                    {
                        vmKeyPad.Title = "Thickness";
                        vmKeyPad.MaxValue = 50;
                        vmKeyPad.CurrentValue = fThickness;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_FILM_THICKNESS;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_FLOW:
                    {
                        vmKeyPad.Title = "Flow";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fGasSaverFlow;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_TIME:
                    {
                        vmKeyPad.Title = "Time";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fGasSaverTime;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_PRESSURE_CORRECT:
                    {
                        vmKeyPad.Title = "Correct Value";
                        vmKeyPad.MaxValue = 20;
                        vmKeyPad.CurrentValue = fPressureCorrect;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_CONFIG_PRESSURE_CORRECT;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_LENGTH:
                    {
                        vmKeyPad.Title = "Length";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = fLength;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_LENGTH;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_ID:
                    {
                        vmKeyPad.Title = "I.D.";
                        vmKeyPad.MaxValue = 1;
                        vmKeyPad.CurrentValue = fDiameter;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_ID;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_FILM_THICKNESS:
                    {
                        vmKeyPad.Title = "Thickness";
                        vmKeyPad.MaxValue = 50;
                        vmKeyPad.CurrentValue = fThickness;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_FILM_THICKNESS;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_FLOW:
                    {
                        vmKeyPad.Title = "Flow";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fGasSaverFlow;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_TIME:
                    {
                        vmKeyPad.Title = "Time";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fGasSaverTime;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_PRESSURE_CORRECT:
                    {
                        vmKeyPad.Title = "Correct Value";
                        vmKeyPad.MaxValue = 20;
                        vmKeyPad.CurrentValue = fPressureCorrect;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_CONFIG_PRESSURE_CORRECT;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_LENGTH:
                    {
                        vmKeyPad.Title = "Length";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = fLength;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_LENGTH;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_ID:
                    {
                        vmKeyPad.Title = "I.D.";
                        vmKeyPad.MaxValue = 1;
                        vmKeyPad.CurrentValue = fDiameter;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_ID;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_FILM_THICKNESS:
                    {
                        vmKeyPad.Title = "Thickness";
                        vmKeyPad.MaxValue = 50;
                        vmKeyPad.CurrentValue = fThickness;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_FILM_THICKNESS;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_FLOW:
                    {
                        vmKeyPad.Title = "Flow";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fGasSaverFlow;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_TIME:
                    {
                        vmKeyPad.Title = "Time";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fGasSaverTime;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_PRESSURE_CORRECT:
                    {
                        vmKeyPad.Title = "Correct Value";
                        vmKeyPad.MaxValue = 20;
                        vmKeyPad.CurrentValue = fPressureCorrect;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_CONFIG_PRESSURE_CORRECT;
                    }
                    break;
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region InletCarrierGasIndexChangeCommand
        public RelayCommand InletCarrierGasIndexChangeCommand { get; set; }
        private void InletCarrierGasIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Inlet Front":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btCarriergas = (byte)btCarriergas;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case "Inlet Center":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btCarriergas = (byte)btCarriergas;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case "Inlet Rear":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btCarriergas = (byte)btCarriergas;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("InletCarrierGasIndexChangeCommand Fired");
        }
        #endregion InletCarrierGasIndexChangeCommand 

        #region InletUPCModeIndexChangeCommand
        public RelayCommand InletUPCModeIndexChangeCommand { get; set; }
        private void InletUPCModeIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Inlet Front":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btApcMode = (byte)btApcMode;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case "Inlet Center":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btApcMode = (byte)btApcMode;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case "Inlet Rear":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btApcMode = (byte)btApcMode;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("InletUPCModeIndexChangeCommand Fired");
        }
        #endregion InletUPCModeIndexChangeCommand 

        #region InletConnectionIndexChangeCommand
        public RelayCommand InletConnectionIndexChangeCommand { get; set; }
        private void InletConnectionIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Inlet Front":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.__btConnection = (byte)ConnectionToDet;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case "Inlet Center":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.__btConnection = (byte)ConnectionToDet;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case "Inlet Rear":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.__btConnection = (byte)ConnectionToDet;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.btPortNo = 2;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("InletConnectionIndexChangeCommand Fired");
        }
        #endregion InletConnectionIndexChangeCommand 

        #region GasSaverOnCommand
        public RelayCommand GasSaverOnCommand { get; set; }
        private void GasSaverOnCommandAction(object param)
        {
            bGasSaverMode = true;

            switch ((E_INLET_LOCATION)param)
            {
                case E_INLET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.bGasSaverMode = bGasSaverMode ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.bGasSaverMode = bGasSaverMode ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.bGasSaverMode = bGasSaverMode ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("GasSaverOnCommand Fired");
        }
        #endregion GasSaverOnCommand 

        #region GasSaverOffCommand
        public RelayCommand GasSaverOffCommand { get; set; }
        private void GasSaverOffCommandAction(object param)
        {
            bGasSaverMode = false;

            switch ((E_INLET_LOCATION)param)
            {
                case E_INLET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.bGasSaverMode = bGasSaverMode ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.bGasSaverMode = bGasSaverMode ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.bGasSaverMode = bGasSaverMode ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("GasSaverOffCommand Fired");
        }
        #endregion GasSaverOffCommand 

        #region PressureCorrectOnCommand
        public RelayCommand PressureCorrectOnCommand { get; set; }
        private void PressureCorrectOnCommandAction(object param)
        {
            bPressCorrect = true;

            switch ((E_INLET_LOCATION)param)
            {
                case E_INLET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.bPressCorrect = bPressCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.bPressCorrect = bPressCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.bPressCorrect = bPressCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("PressureCorrectOnCommand Fired");
        }
        #endregion PressureCorrectOnCommand 

        #region PressureCorrectOffCommand
        public RelayCommand PressureCorrectOffCommand { get; set; }
        private void PressureCorrectOffCommandAction(object param)
        {
            bPressCorrect = false;

            switch ((E_INLET_LOCATION)param)
            {
                case E_INLET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.bPressCorrect = bPressCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.bPressCorrect = bPressCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.bPressCorrect = bPressCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("PressureCorrectOffCommand Fired");
        }
        #endregion PressureCorrectOffCommand 

        #region VacuumCorrectOnCommand
        public RelayCommand VacuumCorrectOnCommand { get; set; }
        private void VacuumCorrectOnCommandAction(object param)
        {
            bVacuumCorrect = true;

            switch ((E_INLET_LOCATION)param)
            {
                case E_INLET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.bVacuumCorrect = bVacuumCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.bVacuumCorrect = bVacuumCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.bVacuumCorrect = bVacuumCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("VacuumCorrectOnCommand Fired");
        }
        #endregion VacuumCorrectOnCommand 

        #region VacuumCorrectOffCommand
        public RelayCommand VacuumCorrectOffCommand { get; set; }
        private void VacuumCorrectOffCommandAction(object param)
        {
            bVacuumCorrect = false;

            switch ((E_INLET_LOCATION)param)
            {
                case E_INLET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet.bVacuumCorrect = bVacuumCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet.bVacuumCorrect = bVacuumCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send.packet));
                    }
                    break;
                case E_INLET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet.bVacuumCorrect = bVacuumCorrect ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("VacuumCorrectOffCommand Fired");
        }
        #endregion VacuumCorrectOffCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
