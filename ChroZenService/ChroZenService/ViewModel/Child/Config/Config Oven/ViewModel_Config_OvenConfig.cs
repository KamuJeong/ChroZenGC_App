using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_Config_OvenConfig : Observable
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_OvenConfig()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            CryogenicCoolingOnCommand = new RelayCommand(CryogenicCoolingOnCommandAction);
            CryogenicCoolingOffCommand = new RelayCommand(CryogenicCoolingOffCommandAction);

            FastCoolingOnCommand = new RelayCommand(FastCoolingOnCommandAction);
            FastCoolingOffCommand = new RelayCommand(FastCoolingOffCommandAction);

            AutoReadyrunOnCommand = new RelayCommand(AutoReadyrunOnCommandAction);
            AutoReadyrunOffCommand = new RelayCommand(AutoReadyrunOffCommandAction);

            RunStartOnCommand = new RelayCommand(RunStartOnCommandAction);
            RunStartOffCommand = new RelayCommand(RunStartOffCommandAction);

            PostRunOnCommand = new RelayCommand(PostRunOnCommandAction);
            PostRunOffCommand = new RelayCommand(PostRunOffCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        TCPManager tcpManager;

        float _fMaxTemp;
        public float fMaxTemp { get { return _fMaxTemp; } set { if (_fMaxTemp != value) { _fMaxTemp = value; OnPropertyChanged(); } } }

        float _fEquibTime;
        public float fEquibTime { get { return _fEquibTime; } set { if (_fEquibTime != value) { _fEquibTime = value; OnPropertyChanged(); } } }

        bool _bAutoReadyrun;
        public bool bAutoReadyrun { get { return _bAutoReadyrun; } set { if (_bAutoReadyrun != value) { _bAutoReadyrun = value; OnPropertyChanged(); } } }

        bool _bCryogenic;
        public bool bCryogenic { get { return _bCryogenic; } set { if (_bCryogenic != value) { _bCryogenic = value; OnPropertyChanged(); } } }

        bool _bFastCryo;
        public bool bFastCryo { get { return _bFastCryo; } set { if (_bFastCryo != value) { _bFastCryo = value; OnPropertyChanged(); } } }

        ViewModel_Config_OvenConfig_Runstart _runstart = new ViewModel_Config_OvenConfig_Runstart();
        public ViewModel_Config_OvenConfig_Runstart runstart { get { return _runstart; } set { if (_runstart != value) { _runstart = value; OnPropertyChanged(); } } }

        ViewModel_Cofig_OvenConfig_Postrun _Postrun = new ViewModel_Cofig_OvenConfig_Postrun();
        public ViewModel_Cofig_OvenConfig_Postrun Postrun { get { return _Postrun; } set { if (_Postrun != value) { _Postrun = value; OnPropertyChanged(); } } }
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
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_MAX_TEMP:
                        {
                            fMaxTemp = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp = fMaxTemp;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_EQUILIBRIUM_TIME:
                        {
                            fEquibTime = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fEquibTime = fEquibTime;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_NO_OF_RUN:
                        {
                            runstart.iCount = (ushort)tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Runstart.iCount = runstart.iCount;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_CYCLE_TIME:
                        {
                            runstart.fCycletime = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Runstart.fCycletime = runstart.fCycletime;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_POSTRUN_TEMP:
                        {
                            Postrun.fTemp = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Postrun.fTemp = Postrun.fTemp;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_POSTRUN_TIME:
                        {
                            Postrun.fTime = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Postrun.fTime = Postrun.fTime;
                            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
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
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_MAX_TEMP:
                    {
                        vmKeyPad.Title = "Max Temp";
                        vmKeyPad.CurrentValue = fMaxTemp.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 450;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_MAX_TEMP;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_EQUILIBRIUM_TIME:
                    {
                        vmKeyPad.Title = "Equilibrium Time";
                        vmKeyPad.CurrentValue = fEquibTime.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_EQUILIBRIUM_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_NO_OF_RUN:
                    {
                        vmKeyPad.Title = "No. of run";
                        vmKeyPad.CurrentValue = runstart.iCount.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 120;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_NO_OF_RUN;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_CYCLE_TIME:
                    {
                        vmKeyPad.Title = "Cycle Time";
                        vmKeyPad.CurrentValue = runstart.iCount.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 120;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_CYCLE_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_POSTRUN_TEMP:
                    {
                        vmKeyPad.Title = "PostRun Temp";
                        vmKeyPad.CurrentValue = runstart.iCount.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 120;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_POSTRUN_TEMP;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_POSTRUN_TIME:
                    {
                        vmKeyPad.Title = "PostRun Time";
                        vmKeyPad.CurrentValue = runstart.iCount.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 120;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.OVEN_CONFIG_POSTRUN_TIME;
                    }
                    break;

            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region CryogenicCoolingOnCommand
        public RelayCommand CryogenicCoolingOnCommand { get; set; }
        private void CryogenicCoolingOnCommandAction(object param)
        {
            bCryogenic = true;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.bCryogenic = 1;

            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("CryogenicCoolingOnCommand Fired");
        }
        #endregion CryogenicCoolingOnCommand 

        #region CryogenicCoolingOffCommand
        public RelayCommand CryogenicCoolingOffCommand { get; set; }
        private void CryogenicCoolingOffCommandAction(object param)
        {
            bCryogenic = false;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.bCryogenic = 0;

            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("CryogenicCoolingOffCommand Fired");
        }
        #endregion CryogenicCoolingOffCommand 

        #region FastCoolingOnCommand
        public RelayCommand FastCoolingOnCommand { get; set; }
        private void FastCoolingOnCommandAction(object param)
        {
            bFastCryo = true;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.bFastCryo = 1;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("FastCoolingOnCommand Fired");
        }
        #endregion FastCoolingOnCommand 

        #region FastCoolingOffCommand
        public RelayCommand FastCoolingOffCommand { get; set; }
        private void FastCoolingOffCommandAction(object param)
        {
            bFastCryo = false;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.bFastCryo = 0;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("FastCoolingOffCommand Fired");
        }
        #endregion FastCoolingOffCommand 

        #region AutoReadyrunOnCommand
        public RelayCommand AutoReadyrunOnCommand { get; set; }
        private void AutoReadyrunOnCommandAction(object param)
        {
            bAutoReadyrun = true;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.bAutoReadyrun = 1;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("AutoReadyrunOnCommand Fired");
        }
        #endregion AutoReadyrunOnCommand 

        #region AutoReadyrunOffCommand
        public RelayCommand AutoReadyrunOffCommand { get; set; }
        private void AutoReadyrunOffCommandAction(object param)
        {
            bAutoReadyrun = false;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.bAutoReadyrun = 0;
            //this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_CONFIG_OVEN_AUTO_READY_RUN_OFF, tcpManager);
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("AutoReadyrunOffCommand Fired");
        }
        #endregion AutoReadyrunOffCommand 

        #region RunStartOnCommand
        public RelayCommand RunStartOnCommand { get; set; }
        private void RunStartOnCommandAction(object param)
        {
            runstart.bOnoff = true;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Runstart.bOnoff = 1;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("RunStartOnCommand Fired");
        }
        #endregion RunStartOnCommand 

        #region RunStartOffCommand
        public RelayCommand RunStartOffCommand { get; set; }
        private void RunStartOffCommandAction(object param)
        {
            runstart.bOnoff = false;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Runstart.bOnoff = 0;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("RunStartOffCommand Fired");
        }
        #endregion RunStartOffCommand 

        #region PostRunOnCommand
        public RelayCommand PostRunOnCommand { get; set; }
        private void PostRunOnCommandAction(object param)
        {
            Postrun.bOnoff = true;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Postrun.bOnoff = 1;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("PostRunOnCommand Fired");
        }
        #endregion PostRunOnCommand 

        #region PostRunOffCommand
        public RelayCommand PostRunOffCommand { get; set; }
        private void PostRunOffCommandAction(object param)
        {
            Postrun.bOnoff = false;

            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Postrun.bOnoff = 0;
            tcpManager.Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet));
            //TODO :             
            Debug.WriteLine("PostRunOffCommand Fired");
        }
        #endregion PostRunOffCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
