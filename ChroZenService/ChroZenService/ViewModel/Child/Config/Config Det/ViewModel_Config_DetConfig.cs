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
    public class ViewModel_Config_DetConfig : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_DetConfig()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            DetMakeupgasIndexChangeCommand = new RelayCommand(DetMakeupgasIndexChangeCommandAction);
            DetConnectionIndexChangeCommand = new RelayCommand(DetConnectionIndexChangeCommandAction);
            DetBlockselectIndexChangeCommand = new RelayCommand(DetBlockselectIndexChangeCommandAction);
            DetSignalRangeIndexChangeCommand = new RelayCommand(DetSignalRangeIndexChangeCommandAction);
            AutozeroOnCommand = new RelayCommand(AutozeroOnCommandAction);
            AutozeroOffCommand = new RelayCommand(AutozeroOffCommandAction);
            DetSignalvariationIndexChangeCommand = new RelayCommand(DetSignalvariationIndexChangeCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
            
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;
        E_DET_TYPE _e_DET_TYPE = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE e_DET_TYPE { get { return _e_DET_TYPE; } set { if (_e_DET_TYPE != value) { _e_DET_TYPE = value; OnPropertyChanged("e_DET_TYPE"); } } }

        int _btMakeupgas;
        public int btMakeupgas { get { return _btMakeupgas; } set { if (_btMakeupgas != value) { _btMakeupgas = value; OnPropertyChanged("btMakeupgas"); } } }
        int _btConnection;
        public int btConnection { get { return _btConnection; } set { if (_btConnection != value) { _btConnection = value; OnPropertyChanged("btConnection"); } } }
        int _iSignalrange;
        public int iSignalrange { get { return _iSignalrange; } set { if (_iSignalrange != value) { _iSignalrange = value; OnPropertyChanged("iSignalrange"); } } }
        bool _bAutozero;
        public bool bAutozero { get { return _bAutozero; } set { if (_bAutozero != value) { _bAutozero = value; OnPropertyChanged("bAutozero"); } } }
        int _btBlockSelect;
        public int btBlockSelect { get { return _btBlockSelect; } set { if (_btBlockSelect != value) { _btBlockSelect = value; OnPropertyChanged("btBlockSelect"); } } }
        int _iSignalvariation;
        public int iSignalvariation { get { return _iSignalvariation; } set { if (_iSignalvariation != value) { _iSignalvariation = value; OnPropertyChanged("iSignalvariation"); } } }

        string _fLitoffset;
        public string fLitoffset { get { return _fLitoffset; } set { if (_fLitoffset != value) { _fLitoffset = value; OnPropertyChanged("fLitoffset"); } } }
        string _fIgnitedelay;
        public string fIgnitedelay { get { return _fIgnitedelay; } set { if (_fIgnitedelay != value) { _fIgnitedelay = value; OnPropertyChanged("fIgnitedelay"); } } }
        string _fIgniteflow;
        public string fIgniteflow { get { return _fIgniteflow; } set { if (_fIgniteflow != value) { _fIgniteflow = value; OnPropertyChanged("fIgniteflow"); } } }
        string _fIgnitetemp;
        public string fIgnitetemp { get { return _fIgnitetemp; } set { if (_fIgnitetemp != value) { _fIgnitetemp = value; OnPropertyChanged("fIgnitetemp"); } } }

        #endregion Property

        #region Command

        #region KeyPad : CancelCommand

        public RelayCommand KeyPadCancelCommand { get; set; }
        private void KeyPadCancelCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
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
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

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
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

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
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_LIT_OFFSET:
                        {
                            fLitoffset = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fLitoffset = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_DELAY:
                        {
                            fIgnitedelay = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fIgnitedelay = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;

                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_FLOW:
                        {
                            fIgniteflow = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fIgniteflow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_TEMP:
                        {
                            fIgnitetemp = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fIgnitetemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
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
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

        }

        #endregion KeyPad : OnCommand

        #region KeyPad : OffCommand

        public RelayCommand KeyPadOffCommand { get; set; }
        private void KeyPadOffCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
        }

        #endregion KeyPad : OffCommand

        #region KeyPad : KeyPadClickCommand

        public RelayCommand KeyPadKeyPadClickCommand { get; set; }
        private void KeyPadKeyPadClickCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
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

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            {
                IsKeyPadShown = true,
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
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_LIT_OFFSET:
                    {
                        vmKeyPad.Title = "Lit Offset";
                        vmKeyPad.MaxValue = 0.05;

                        vmKeyPad.CurrentValue = fLitoffset;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_LIT_OFFSET;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_DELAY:
                    {
                        vmKeyPad.Title = "Ignite Delay";
                        vmKeyPad.MaxValue = 9999;

                        vmKeyPad.CurrentValue = fIgnitedelay;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_DELAY;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_FLOW:
                    {
                        vmKeyPad.Title = "Ignite Flow";
                        vmKeyPad.MaxValue = 300;

                        vmKeyPad.CurrentValue = fIgniteflow;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_TEMP:
                    {
                        vmKeyPad.Title = "Ignite Temp";
                        vmKeyPad.MaxValue = 450;

                        vmKeyPad.CurrentValue = fIgnitetemp;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_CONFIG_IGNITE_TEMP;
                    }
                    break;
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region DetMakeupgasIndexChangeCommand
        public RelayCommand DetMakeupgasIndexChangeCommand { get; set; }
        private void DetMakeupgasIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Front Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.btMakeupgas = (byte)btMakeupgas;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case "Center Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.btMakeupgas = (byte)btMakeupgas;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.btMakeupgas = (byte)btMakeupgas;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }


            //TODO :             
            Debug.WriteLine("DetMakeupgasIndexChangeCommand Fired");
        }
        #endregion DetMakeupgasIndexChangeCommand 

        #region DetConnectionIndexChangeCommand
        public RelayCommand DetConnectionIndexChangeCommand { get; set; }
        private void DetConnectionIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Front Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.btConnection = (byte)btConnection;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case "Center Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.btConnection = (byte)btConnection;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.btConnection = (byte)btConnection;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("DetConnectionIndexChangeCommand Fired");
        }
        #endregion DetConnectionIndexChangeCommand 

        #region DetBlockselectIndexChangeCommand
        public RelayCommand DetBlockselectIndexChangeCommand { get; set; }
        private void DetBlockselectIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Front Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.btBlockSelect = (byte)btBlockSelect;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case "Center Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.btBlockSelect = (byte)btBlockSelect;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.btBlockSelect = (byte)btBlockSelect;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("DetBlockselectIndexChangeCommand Fired");
        }
        #endregion DetBlockselectIndexChangeCommand 

        #region DetSignalRangeIndexChangeCommand
        public RelayCommand DetSignalRangeIndexChangeCommand { get; set; }
        private void DetSignalRangeIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Front Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.iSignalrange = (short)iSignalrange;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case "Center Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.iSignalrange = (short)iSignalrange;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.iSignalrange = (short)iSignalrange;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("DetSignalRangeIndexChangeCommand Fired");
        }
        #endregion DetSignalRangeIndexChangeCommand 

        #region AutozeroOnCommand
        public RelayCommand AutozeroOnCommand { get; set; }
        private void AutozeroOnCommandAction(object param)
        {
            bAutozero = true; //20210706 권민경

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bAutozero = bAutozero ? (byte)1 : (byte)0; //20210706 권민경
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bAutozero = bAutozero ? (byte)1 : (byte)0; //20210706 권민경
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bAutozero = bAutozero ? (byte)1 : (byte)0; //20210706 권민경
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("AutozeroOnCommand Fired");
        }
        #endregion AutozeroOnCommand 

        #region AutozeroOffCommand
        public RelayCommand AutozeroOffCommand { get; set; }
        private void AutozeroOffCommandAction(object param)
        {
            bAutozero = false; //20210706 권민경

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bAutozero = bAutozero ? (byte)1 : (byte)0; //20210706 권민경
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bAutozero = bAutozero ? (byte)1 : (byte)0; //20210706 권민경
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bAutozero = bAutozero ? (byte)1 : (byte)0; //20210706 권민경
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("AutozeroOffCommand Fired");
        }
        #endregion AutozeroOffCommand 

        #region DetSignalvariationIndexChangeCommand
        public RelayCommand DetSignalvariationIndexChangeCommand { get; set; }
        private void DetSignalvariationIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Front Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.iSignalvariation = (short)iSignalvariation;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case "Center Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.iSignalvariation = (short)iSignalvariation;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Det":
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.iSignalvariation = (short)iSignalvariation;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("DetSignalvariationIndexChangeCommand Fired");
        }
        #endregion DetSignalvariationIndexChangeCommand 

        #region DefaultCommand
        public RelayCommand DefaultCommand { get; set; }
        private void DefaultCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("DefaultCommand Fired");
        }
        #endregion DefaultCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
