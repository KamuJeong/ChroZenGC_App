using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_System_Config : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Config()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
            AuxAPC1_OnCommand = new RelayCommand(AuxAPC1_OnCommandAction);
            AuxAPC1_OffCommand = new RelayCommand(AuxAPC1_OffCommandAction);
            AuxAPC2_OnCommand = new RelayCommand(AuxAPC2_OnCommandAction);
            AuxAPC2_OffCommand = new RelayCommand(AuxAPC2_OffCommandAction);
            AuxAPC3_OnCommand = new RelayCommand(AuxAPC3_OnCommandAction);
            AuxAPC3_OffCommand = new RelayCommand(AuxAPC3_OffCommandAction);
            Navigation_NextCommand = new RelayCommand(Navigation_NextCommandAction);
            Navigation_PrevCommand = new RelayCommand(Navigation_PrevCommandAction);

            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);

            Set_PortCommand = new RelayCommand(Set_PortCommandAction);
            Set_LoopCommand = new RelayCommand(Set_LoopCommandAction);
            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        E_INLET_TYPE _btInlet1 = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE btInlet1 { get { return _btInlet1; } set { if (_btInlet1 != value) { _btInlet1 = value; OnPropertyChanged("btInlet1"); } } }

        E_INLET_TYPE _btInlet2 = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE btInlet2 { get { return _btInlet2; } set { if (_btInlet2 != value) { _btInlet2 = value; OnPropertyChanged("btInlet2"); } } }

        E_INLET_TYPE _btInlet3 = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE btInlet3 { get { return _btInlet3; } set { if (_btInlet3 != value) { _btInlet3 = value; OnPropertyChanged("btInlet3"); } } }

        E_DET_TYPE _btDet1 = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE btDet1 { get { return _btDet1; } set { if (_btDet1 != value) { _btDet1 = value; OnPropertyChanged("btDet1"); } } }

        E_DET_TYPE _btDet2 = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE btDet2 { get { return _btDet2; } set { if (_btDet2 != value) { _btDet2 = value; OnPropertyChanged("btDet2"); } } }

        E_DET_TYPE _btDet3 = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE btDet3 { get { return _btDet3; } set { if (_btDet3 != value) { _btDet3 = value; OnPropertyChanged("btDet3"); } } }

        byte _bMethanizer;
        /// <summary>
        /// 0 : Valve
        /// 1 : Methanizer
        /// 2 : TransferLine
        /// </summary>
        public byte bMethanizer { get { return _bMethanizer; } set { if (_bMethanizer != value) { _bMethanizer = value; OnPropertyChanged("bMethanizer"); } } }

        bool _bAuxAPC1;
        public bool bAuxAPC1 { get { return _bAuxAPC1; } set { if (_bAuxAPC1 != value) { _bAuxAPC1 = value; OnPropertyChanged("bAuxAPC1"); } } }

        bool _bAuxAPC2;
        public bool bAuxAPC2 { get { return _bAuxAPC2; } set { if (_bAuxAPC2 != value) { _bAuxAPC2 = value; OnPropertyChanged("bAuxAPC2"); } } }

        bool _bAuxAPC3;
        public bool bAuxAPC3 { get { return _bAuxAPC3; } set { if (_bAuxAPC3 != value) { _bAuxAPC3 = value; OnPropertyChanged("bAuxAPC3"); } } }

        byte _bCryogenic;
        public byte bCryogenic { get { return _bCryogenic; } set { if (_bCryogenic != value) { _bCryogenic = value; OnPropertyChanged("bCryogenic"); } } }

        byte _bAuxTemp1;
        public byte bAuxTemp1 { get { return _bAuxTemp1; } set { if (_bAuxTemp1 != value) { _bAuxTemp1 = value; OnPropertyChanged("bAuxTemp1"); } } }
        byte _bAuxTemp2;
        public byte bAuxTemp2 { get { return _bAuxTemp2; } set { if (_bAuxTemp2 != value) { _bAuxTemp2 = value; OnPropertyChanged("bAuxTemp2"); } } }
        byte _bAuxTemp3;
        public byte bAuxTemp3 { get { return _bAuxTemp3; } set { if (_bAuxTemp3 != value) { _bAuxTemp3 = value; OnPropertyChanged("bAuxTemp3"); } } }
        byte _bAuxTemp4;
        public byte bAuxTemp4 { get { return _bAuxTemp4; } set { if (_bAuxTemp4 != value) { _bAuxTemp4 = value; OnPropertyChanged("bAuxTemp4"); } } }
        byte _bAuxTemp5;
        public byte bAuxTemp5 { get { return _bAuxTemp5; } set { if (_bAuxTemp5 != value) { _bAuxTemp5 = value; OnPropertyChanged("bAuxTemp5"); } } }
        byte _bAuxTemp6;
        public byte bAuxTemp6 { get { return _bAuxTemp6; } set { if (_bAuxTemp6 != value) { _bAuxTemp6 = value; OnPropertyChanged("bAuxTemp6"); } } }
        byte _bAuxTemp7;
        public byte bAuxTemp7 { get { return _bAuxTemp7; } set { if (_bAuxTemp7 != value) { _bAuxTemp7 = value; OnPropertyChanged("bAuxTemp7"); } } }
        byte _bAuxTemp8;
        public byte bAuxTemp8 { get { return _bAuxTemp8; } set { if (_bAuxTemp8 != value) { _bAuxTemp8 = value; OnPropertyChanged("bAuxTemp8"); } } }

        //byte[] _bAuxTemp = new byte[ChroZenService_Const.AUX_CNT];
        //public byte[] bAuxTemp { get { return _bAuxTemp; } set { if (_bAuxTemp != value) { _bAuxTemp = value; OnPropertyChanged("bAuxTemp"); } } }

        byte _bMultiValve1;
        public byte bMultiValve1 { get { return _bMultiValve1; } set { if (_bMultiValve1 != value) { _bMultiValve1 = value; OnPropertyChanged("bMultiValve1"); } } }

        byte _bMultiValve2;
        public byte bMultiValve2 { get { return _bMultiValve2; } set { if (_bMultiValve2 != value) { _bMultiValve2 = value; OnPropertyChanged("bMultiValve2"); } } }

        //byte[] _bMultiValve = new byte[ChroZenService_Const.SYSTEM_MULTI_VALVE_CNT];
        //public byte[] bMultiValve { get { return _bMultiValve; } set { if (_bMultiValve != value) { _bMultiValve = value; OnPropertyChanged("bMultiValve"); } } }

        bool _IsFirstPage = true;
        public bool IsFirstPage { get { return _IsFirstPage; } set { if (_IsFirstPage != value) { _IsFirstPage = value; OnPropertyChanged("IsFirstPage"); } } }

        //byte[] _btType1;
        //public byte[] btType1 { get { return _btType1; } set { if (_btType1 != value) { _btType1 = value; OnPropertyChanged("btType1"); } } }

        byte _btType1_1;
        public byte btType1_1 { get { return _btType1_1; } set { if (_btType1_1 != value) { _btType1_1 = value; OnPropertyChanged("btType1_1"); } } }

        byte _btType1_2;
        public byte btType1_2 { get { return _btType1_2; } set { if (_btType1_2 != value) { _btType1_2 = value; OnPropertyChanged("btType1_2"); } } }

        byte _btType1_3;
        public byte btType1_3 { get { return _btType1_3; } set { if (_btType1_3 != value) { _btType1_3 = value; OnPropertyChanged("btType1_3"); } } }

        byte _btType1_4;
        public byte btType1_4 { get { return _btType1_4; } set { if (_btType1_4 != value) { _btType1_4 = value; OnPropertyChanged("btType1_4"); } } }

        byte _btType1_5;
        public byte btType1_5 { get { return _btType1_5; } set { if (_btType1_5 != value) { _btType1_5 = value; OnPropertyChanged("btType1_5"); } } }

        byte _btType1_6;
        public byte btType1_6 { get { return _btType1_6; } set { if (_btType1_6 != value) { _btType1_6 = value; OnPropertyChanged("btType1_6"); } } }

        byte _btType1_7;
        public byte btType1_7 { get { return _btType1_7; } set { if (_btType1_7 != value) { _btType1_7 = value; OnPropertyChanged("btType1_7"); } } }

        byte _btType1_8;
        public byte btType1_8 { get { return _btType1_8; } set { if (_btType1_8 != value) { _btType1_8 = value; OnPropertyChanged("btType1_8"); } } }

        byte _btType1_M1;
        public byte btType1_M1 { get { return _btType1_M1; } set { if (_btType1_M1 != value) { _btType1_M1 = value; OnPropertyChanged("btType1_M1"); } } }

        byte _btType1_M2;
        public byte btType1_M2 { get { return _btType1_M2; } set { if (_btType1_M2 != value) { _btType1_M2 = value; OnPropertyChanged("btType1_M2"); } } }

        byte _btType2_1;
        public byte btType2_1 { get { return _btType2_1; } set { if (_btType2_1 != value) { _btType2_1 = value; OnPropertyChanged("btType2_1"); } } }

        byte _btType2_2;
        public byte btType2_2 { get { return _btType2_2; } set { if (_btType2_2 != value) { _btType2_2 = value; OnPropertyChanged("btType2_2"); } } }

        byte _btType2_3;
        public byte btType2_3 { get { return _btType2_3; } set { if (_btType2_3 != value) { _btType2_3 = value; OnPropertyChanged("btType2_3"); } } }

        byte _btType2_4;
        public byte btType2_4 { get { return _btType2_4; } set { if (_btType2_4 != value) { _btType2_4 = value; OnPropertyChanged("btType2_4"); } } }

        byte _btType2_5;
        public byte btType2_5 { get { return _btType2_5; } set { if (_btType2_5 != value) { _btType2_5 = value; OnPropertyChanged("btType2_5"); } } }

        byte _btType2_6;
        public byte btType2_6 { get { return _btType2_6; } set { if (_btType2_6 != value) { _btType2_6 = value; OnPropertyChanged("btType2_6"); } } }

        byte _btType2_7;
        public byte btType2_7 { get { return _btType2_7; } set { if (_btType2_7 != value) { _btType2_7 = value; OnPropertyChanged("btType2_7"); } } }

        byte _btType2_8;
        public byte btType2_8 { get { return _btType2_8; } set { if (_btType2_8 != value) { _btType2_8 = value; OnPropertyChanged("btType2_8"); } } }

        byte _btType2_M1;
        public byte btType2_M1 { get { return _btType2_M1; } set { if (_btType2_M1 != value) { _btType2_M1 = value; OnPropertyChanged("btType2_M1"); } } }

        byte _btType2_M2;
        public byte btType2_M2 { get { return _btType2_M2; } set { if (_btType2_M2 != value) { _btType2_M2 = value; OnPropertyChanged("btType2_M2"); } } }

        byte _btPort1;
        public byte btPort1 { get { return _btPort1; } set { if (_btPort1 != value) { _btPort1 = value; OnPropertyChanged("btPort1"); } } }

        byte _btPort2;
        public byte btPort2 { get { return _btPort2; } set { if (_btPort2 != value) { _btPort2 = value; OnPropertyChanged("btPort2"); } } }

        byte _btPort3;
        public byte btPort3 { get { return _btPort3; } set { if (_btPort3 != value) { _btPort3 = value; OnPropertyChanged("btPort3"); } } }

        byte _btPort4;
        public byte btPort4 { get { return _btPort4; } set { if (_btPort4 != value) { _btPort4 = value; OnPropertyChanged("btPort4"); } } }

        byte _btPort5;
        public byte btPort5 { get { return _btPort5; } set { if (_btPort5 != value) { _btPort5 = value; OnPropertyChanged("btPort5"); } } }

        byte _btPort6;
        public byte btPort6 { get { return _btPort6; } set { if (_btPort6 != value) { _btPort6 = value; OnPropertyChanged("btPort6"); } } }

        byte _btPort7;
        public byte btPort7 { get { return _btPort7; } set { if (_btPort7 != value) { _btPort7 = value; OnPropertyChanged("btPort7"); } } }

        byte _btPort8;
        public byte btPort8 { get { return _btPort8; } set { if (_btPort8 != value) { _btPort8 = value; OnPropertyChanged("btPort8"); } } }

        byte _btPortM1;
        public byte btPortM1 { get { return _btPortM1; } set { if (_btPortM1 != value) { _btPortM1 = value; OnPropertyChanged("btPortM1"); } } }

        byte _btPortM2;
        public byte btPortM2 { get { return _btPortM2; } set { if (_btPortM2 != value) { _btPortM2 = value; OnPropertyChanged("btPortM2"); } } }
            
        float _fLoop1;
        public float fLoop1 { get { return _fLoop1; } set { if (_fLoop1 != value) { _fLoop1 = value; OnPropertyChanged("fLoop1"); } } }

        float _fLoop2;
        public float fLoop2 { get { return _fLoop2; } set { if (_fLoop2 != value) { _fLoop2 = value; OnPropertyChanged("fLoop2"); } } }

        float _fLoop3;
        public float fLoop3 { get { return _fLoop3; } set { if (_fLoop3 != value) { _fLoop3 = value; OnPropertyChanged("fLoop3"); } } }

        float _fLoop4;
        public float fLoop4 { get { return _fLoop4; } set { if (_fLoop4 != value) { _fLoop4 = value; OnPropertyChanged("fLoop4"); } } }

        float _fLoop5;
        public float fLoop5 { get { return _fLoop5; } set { if (_fLoop5 != value) { _fLoop5 = value; OnPropertyChanged("fLoop5"); } } }

        float _fLoop6;
        public float fLoop6 { get { return _fLoop6; } set { if (_fLoop6 != value) { _fLoop6 = value; OnPropertyChanged("fLoop6"); } } }

        float _fLoop7;
        public float fLoop7 { get { return _fLoop7; } set { if (_fLoop7 != value) { _fLoop7 = value; OnPropertyChanged("fLoop7"); } } }

        float _fLoop8;
        public float fLoop8 { get { return _fLoop8; } set { if (_fLoop8 != value) { _fLoop8 = value; OnPropertyChanged("fLoop8"); } } }

        float _fLoopM1;
        public float fLoopM1 { get { return _fLoopM1; } set { if (_fLoopM1 != value) { _fLoopM1 = value; OnPropertyChanged("fLoopM1"); } } }

        float _fLoopM2;
        public float fLoopM2 { get { return _fLoopM2; } set { if (_fLoopM2 != value) { _fLoopM2 = value; OnPropertyChanged("fLoopM2"); } } }


        //byte[] _btPort;
        //public byte[] btPort { get { return _btPort; } set { if (_btPort != value) { _btPort = value; OnPropertyChanged("btPort"); } } }

        //float[] _fLoop1;
        //public float[] fLoop1 { get { return _fLoop1; } set { if (_fLoop1 != value) { _fLoop1 = value; OnPropertyChanged("fLoop1"); } } }

        //byte[] _btType2;
        //public byte[] btType2 { get { return _btType2; } set { if (_btType2 != value) { _btType2 = value; OnPropertyChanged("btType2"); } } }

        byte _btCoolant;
        /// <summary>
        /// T_CHROZEN_GC_OVEN
        /// </summary>
        public byte btCoolant { get { return _btCoolant; } set { if (_btCoolant != value) { _btCoolant = value; OnPropertyChanged("btCoolant"); } } }

        #endregion Property

        #region Command

        #region AuxAPC1_OnCommand
        public RelayCommand AuxAPC1_OnCommand { get; set; }
        private void AuxAPC1_OnCommandAction(object param)
        {
            bAuxAPC1 = true;

            //TODO :             
            Debug.WriteLine("AuxAPC1_OnCommand Fired");
        }
        #endregion AuxAPC1_OnCommand 

        #region AuxAPC1_OffCommand
        public RelayCommand AuxAPC1_OffCommand { get; set; }
        private void AuxAPC1_OffCommandAction(object param)
        {
            bAuxAPC1 = false;

            //TODO :             
            Debug.WriteLine("AuxAPC1_OffCommand Fired");
        }
        #endregion AuxAPC1_OnCommand 

        #region AuxAPC2_OnCommand
        public RelayCommand AuxAPC2_OnCommand { get; set; }
        private void AuxAPC2_OnCommandAction(object param)
        {
            bAuxAPC2 = true;

            //TODO :             
            Debug.WriteLine("AuxAPC2_OnCommand Fired");
        }
        #endregion AuxAPC2_OnCommand 

        #region AuxAPC2_OffCommand
        public RelayCommand AuxAPC2_OffCommand { get; set; }
        private void AuxAPC2_OffCommandAction(object param)
        {
            bAuxAPC2 = false;

            //TODO :             
            Debug.WriteLine("AuxAPC2_OffCommand Fired");
        }
        #endregion AuxAPC2_OnCommand 

        #region AuxAPC3_OnCommand
        public RelayCommand AuxAPC3_OnCommand { get; set; }
        private void AuxAPC3_OnCommandAction(object param)
        {
            bAuxAPC3 = true;

            //TODO :             
            Debug.WriteLine("AuxAPC3_OnCommand Fired");
        }
        #endregion AuxAPC3_OnCommand 

        #region AuxAPC3_OffCommand
        public RelayCommand AuxAPC3_OffCommand { get; set; }
        private void AuxAPC3_OffCommandAction(object param)
        {
            bAuxAPC3 = false;

            //TODO :             
            Debug.WriteLine("AuxAPC3_OffCommand Fired");
        }
        #endregion AuxAPC3_OnCommand 

        #region Navigation_NextCommand
        public RelayCommand Navigation_NextCommand { get; set; }
        private void Navigation_NextCommandAction(object param)
        {
            IsFirstPage = false;

            //TODO :             
            Debug.WriteLine("Navigation_NextCommand Fired");
        }
        #endregion Navigation_NextCommand 

        #region Navigation_PrevCommand
        public RelayCommand Navigation_PrevCommand { get; set; }
        private void Navigation_PrevCommandAction(object param)
        {
            IsFirstPage = true;

            //TODO :             
            Debug.WriteLine("Navigation_PrevCommand Fired");
        }
        #endregion AuxAPC1_OnCommand 

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
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE1_PORT:
                        {
                            btPort1 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE2_PORT:
                        {
                            btPort2 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE3_PORT:
                        {
                            btPort3 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE4_PORT:
                        {
                            btPort4 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET4_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE5_PORT:
                        {
                            btPort5 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET5_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE6_PORT:
                        {
                            btPort6 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET6_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE7_PORT:
                        {
                            btPort7 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET7_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE8_PORT:
                        {
                            btPort8 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET8_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM1_PORT:
                        {
                            btPortM1 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLETM1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM2_PORT:
                        {
                            btPortM2 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLETM2_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                       
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE1_FLOW:
                        {
                            fLoop1 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[1] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE2_FLOW:
                        {
                            fLoop2 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET2_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[2] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE3_FLOW:
                        {
                            fLoop3 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET3_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[3] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE4_FLOW:
                        {
                            fLoop4 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET4_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[4] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE5_FLOW:
                        {
                            fLoop5 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET5_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[5] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE6_FLOW:
                        {
                            fLoop6 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET6_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[6] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE7_FLOW:
                        {
                            fLoop7 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET7_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[7] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE8_FLOW:
                        {
                            fLoop8 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET8_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[8] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM1_FLOW:
                        {
                            fLoopM1 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLETM1_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[M1] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM2_FLOW:
                        {
                            fLoopM2 = tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLETM2_Send.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[M2] = tempFloatVal;
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

        #region Set_PortCommand
        public RelayCommand Set_PortCommand { get; set; }
        private void Set_PortCommandAction(object param)
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

            switch ((E_SYSTEM_COFIG_VALVE_TYPE)param)
            {
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE1:
                    {
                        vmKeyPad.Title = "Valve1 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE1_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE2:
                    {
                        vmKeyPad.Title = "Valve2 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE2_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE3:
                    {
                        vmKeyPad.Title = "Valve3 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE3_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE4:
                    {
                        vmKeyPad.Title = "Valve4 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE4_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE5:
                    {
                        vmKeyPad.Title = "Valve5 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE5_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE6:
                    {
                        vmKeyPad.Title = "Valve6 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE6_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE7:
                    {
                        vmKeyPad.Title = "Valve7 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE7_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE8:
                    {
                        vmKeyPad.Title = "Valve8 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE8_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVEM1:
                    {
                        vmKeyPad.Title = "ValveM1 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM1_PORT;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVEM2:
                    {
                        vmKeyPad.Title = "ValveM2 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 16;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM2_PORT;
                    }
                    break;
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("Set_PortCommand Fired");
        }
        #endregion Set_PortCommand 

        #region Set_LoopCommand
        public RelayCommand Set_LoopCommand { get; set; }
        private void Set_LoopCommandAction(object param)
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

            switch ((E_SYSTEM_COFIG_VALVE_TYPE)param)
            {
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE1:
                    {
                        vmKeyPad.Title = "Valve1 Vol";
                        vmKeyPad.CurrentValue = fLoop1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE1_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE2:
                    {
                        vmKeyPad.Title = "Valve2 Vol";
                        vmKeyPad.CurrentValue = fLoop2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE2_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE3:
                    {
                        vmKeyPad.Title = "Valve3 Vol";
                        vmKeyPad.CurrentValue = fLoop3.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE3_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE4:
                    {
                        vmKeyPad.Title = "Valve4 Vol";
                        vmKeyPad.CurrentValue = fLoop4.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE4_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE5:
                    {
                        vmKeyPad.Title = "Valve5 Vol";
                        vmKeyPad.CurrentValue = fLoop5.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE5_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE6:
                    {
                        vmKeyPad.Title = "Valve6 Vol";
                        vmKeyPad.CurrentValue = fLoop6.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE6_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE7:
                    {
                        vmKeyPad.Title = "Valve7 Vol";
                        vmKeyPad.CurrentValue = fLoop7.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE7_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVE8:
                    {
                        vmKeyPad.Title = "Valve8 Vol";
                        vmKeyPad.CurrentValue = fLoop8.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVE8_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVEM1:
                    {
                        vmKeyPad.Title = "ValveM1 Vol";
                        vmKeyPad.CurrentValue = fLoopM1.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM1_FLOW;
                    }
                    break;
                case E_SYSTEM_COFIG_VALVE_TYPE.VALVEM2:
                    {
                        vmKeyPad.Title = "ValveM2 Vol";
                        vmKeyPad.CurrentValue = fLoopM2.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.CONFIG_VALVEM2_FLOW;
                    }
                    break;
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);
             
            //TODO :             
            Debug.WriteLine("Set_LoopCommand Fired");
        }
        #endregion Set_LoopCommand 

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
