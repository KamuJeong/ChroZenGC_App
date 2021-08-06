using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_System_CalibrationUPC : Model_System_Calibration
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_CalibrationUPC(E_UPC_INDEX e_UPC_INDEX)
        {
            _e_UPC_INDEX = e_UPC_INDEX;

            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);
            MeasuredCommand = new RelayCommand(MeasuredCommandAction);

            SensorZeroResetCommand = new RelayCommand(SensorZeroResetCommandAction);
            SensorZeroStartCommand = new RelayCommand(SensorZeroStartCommandAction);
            SensorZeroStopCommand = new RelayCommand(SensorZeroStopCommandAction);
            SensorZeroApplyCommand = new RelayCommand(SensorZeroApplyCommandAction);

            ValveResetCommand = new RelayCommand(ValveResetCommandAction);
            ValveStartCommand = new RelayCommand(ValveStartCommandAction);
            ValveStopCommand = new RelayCommand(ValveStopCommandAction);
            ValveApplyCommand = new RelayCommand(ValveApplyCommandAction);

            FlowResetCommand = new RelayCommand(FlowResetCommandAction);
            FlowStartCommand = new RelayCommand(FlowStartCommandAction);
            FlowStopCommand = new RelayCommand(FlowStopCommandAction);
            FlowApplyCommand = new RelayCommand(FlowApplyCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        public E_UPC_INDEX _e_UPC_INDEX;

        bool _bIsDoingSensorZeroCalibration;
        public bool bIsDoingSensorZeroCalibration { get { return _bIsDoingSensorZeroCalibration; } set { if (_bIsDoingSensorZeroCalibration != value) { _bIsDoingSensorZeroCalibration = value; OnPropertyChanged("bIsDoingSensorZeroCalibration"); } } }

        string _SensorZero_Row_1;
        public string SensorZero_Row_1 { get { return _SensorZero_Row_1; } set { if (_SensorZero_Row_1 != value) { _SensorZero_Row_1 = value; OnPropertyChanged("SensorZero_Row_1"); } } }

        string _SensorZero_Row_2;
        public string SensorZero_Row_2 { get { return _SensorZero_Row_2; } set { if (_SensorZero_Row_2 != value) { _SensorZero_Row_2 = value; OnPropertyChanged("SensorZero_Row_2"); } } }

        string _SensorZero_Row_3;
        public string SensorZero_Row_3 { get { return _SensorZero_Row_3; } set { if (_SensorZero_Row_3 != value) { _SensorZero_Row_3 = value; OnPropertyChanged("SensorZero_Row_3"); } } }

        bool _bIsDoingValveCalibration;
        public bool bIsDoingValveCalibration { get { return _bIsDoingValveCalibration; } set { if (_bIsDoingValveCalibration != value) { _bIsDoingValveCalibration = value; OnPropertyChanged("bIsDoingValveCalibration"); } } } 

        string _Valve_Row_1_State;
        public string Valve_Row_1_State { get { return _Valve_Row_1_State; } set { if (_Valve_Row_1_State != value) { _Valve_Row_1_State = value; OnPropertyChanged("Valve_Row_1_State"); } } }


        string _Valve_Row_1_Voltage;
        public string Valve_Row_1_Voltage { get { return _Valve_Row_1_Voltage; } set { if (_Valve_Row_1_Voltage != value) {  _Valve_Row_1_Voltage = value; OnPropertyChanged("Valve_Row_1_Voltage"); } } } 


        string _Valve_Row_1_Flow;
        public string Valve_Row_1_Flow { get { return _Valve_Row_1_Flow; } set { if (_Valve_Row_1_Flow != value) {  _Valve_Row_1_Flow = value; OnPropertyChanged("Valve_Row_1_Flow"); } } } 


        string _Valve_Row_2_State;
        public string Valve_Row_2_State { get { return _Valve_Row_2_State; } set { if (_Valve_Row_2_State != value) { _Valve_Row_2_State = value; OnPropertyChanged("Valve_Row_2_State"); } } } 


        string _Valve_Row_2_Voltage;
        public string Valve_Row_2_Voltage { get { return _Valve_Row_2_Voltage; } set { if (_Valve_Row_2_Voltage != value) { _Valve_Row_2_Voltage = value; OnPropertyChanged("Valve_Row_2_Voltage"); } } }

        string _Valve_Row_2_Flow;
        public string Valve_Row_2_Flow { get { return _Valve_Row_2_Flow; } set { if (_Valve_Row_2_Flow != value) { _Valve_Row_2_Flow = value; OnPropertyChanged("Valve_Row_2_Flow"); } } }

        string _Valve_Row_3_State;
        public string Valve_Row_3_State { get { return _Valve_Row_3_State; } set { if (_Valve_Row_3_State != value) { _Valve_Row_3_State = value; OnPropertyChanged("Valve_Row_3_State"); } } }

        string _Valve_Row_3_Voltage;
        public string Valve_Row_3_Voltage { get { return _Valve_Row_3_Voltage; } set { if (_Valve_Row_3_Voltage != value) { _Valve_Row_3_Voltage = value; OnPropertyChanged("Valve_Row_3_Voltage"); } } }

        string _Valve_Row_3_Flow;
        public string Valve_Row_3_Flow { get { return _Valve_Row_3_Flow; } set { if (_Valve_Row_3_Flow != value) { _Valve_Row_3_Flow = value; OnPropertyChanged("Valve_Row_3_Flow"); } } }

        bool _bIsDoingFlowCalibration;

        /// <summary>
        /// State==7
        /// </summary>
        public bool bIsDoingFlowCalibration { get { return _bIsDoingFlowCalibration; } set { if (_bIsDoingFlowCalibration != value) { _bIsDoingFlowCalibration = value; OnPropertyChanged("bIsDoingFlowCalibration"); } } }

        string _Flow_Row_1_Act;
        public string Flow_Row_1_Act { get { return _Flow_Row_1_Act; } set { if (_Flow_Row_1_Act != value) { _Flow_Row_1_Act = value; OnPropertyChanged("Flow_Row_1_Act"); } } }

        string _Flow_Row_1_Set;
        public string Flow_Row_1_Set { get { return _Flow_Row_1_Set; } set { if (_Flow_Row_1_Set != value) { _Flow_Row_1_Set = value; OnPropertyChanged("Flow_Row_1_Set"); } } }

        string _Flow_Row_1_Measured;
        public string Flow_Row_1_Measured { get { return _Flow_Row_1_Measured; } set { if (_Flow_Row_1_Measured != value) { _Flow_Row_1_Measured = value; OnPropertyChanged("Flow_Row_1_Measured"); } } }

        string _Flow_Row_2_Act;
        public string Flow_Row_2_Act { get { return _Flow_Row_2_Act; } set { if (_Flow_Row_2_Act != value) { _Flow_Row_2_Act = value; OnPropertyChanged("Flow_Row_2_Act"); } } }

        string _Flow_Row_2_Set;
        public string Flow_Row_2_Set { get { return _Flow_Row_2_Set; } set { if (_Flow_Row_2_Set != value) { _Flow_Row_2_Set = value; OnPropertyChanged("Flow_Row_2_Set"); } } }

        string _Flow_Row_2_Measured;
        public string Flow_Row_2_Measured { get { return _Flow_Row_2_Measured; } set { if (_Flow_Row_2_Measured != value) { _Flow_Row_2_Measured = value; OnPropertyChanged("Flow_Row_2_Measured"); } } }

        string _Flow_Row_3_Act;
        public string Flow_Row_3_Act { get { return _Flow_Row_3_Act; } set { if (_Flow_Row_3_Act != value) { _Flow_Row_3_Act = value; OnPropertyChanged("Flow_Row_3_Act"); } } }

        string _Flow_Row_3_Set;
        public string Flow_Row_3_Set { get { return _Flow_Row_3_Set; } set { if (_Flow_Row_3_Set != value) { _Flow_Row_3_Set = value; OnPropertyChanged("Flow_Row_3_Set"); } } }

        string _Flow_Row_3_Measured;
        public string Flow_Row_3_Measured { get { return _Flow_Row_3_Measured; } set { if (_Flow_Row_3_Measured != value) { _Flow_Row_3_Measured = value; OnPropertyChanged("Flow_Row_3_Measured"); } } }


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
            //
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
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX1_SET_FLOW_CALIBRATION1:
                        {
                            Flow_Row_1_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket.Aux_flowCalSet[0] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX1_SET_FLOW_CALIBRATION2:
                        {
                            Flow_Row_2_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket.Aux_flowCalSet[1] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX1_SET_FLOW_CALIBRATION3:
                        {
                            Flow_Row_3_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket.Aux_flowCalSet[2] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX1_MEASURE_FLOW_CALIBRATION1:
                        {
                            Flow_Row_1_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket.Aux_flowCalMeasure[0] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX1_MEASURE_FLOW_CALIBRATION2:
                        {
                            Flow_Row_2_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket.Aux_flowCalMeasure[1] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX1_MEASURE_FLOW_CALIBRATION3:
                        {
                            Flow_Row_3_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket.Aux_flowCalMeasure[2] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1.auxPacket, 0));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX2_SET_FLOW_CALIBRATION1:
                        {
                            Flow_Row_1_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket.Aux_flowCalSet[0] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX2_SET_FLOW_CALIBRATION2:
                        {
                            Flow_Row_2_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket.Aux_flowCalSet[1] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX2_SET_FLOW_CALIBRATION3:
                        {
                            Flow_Row_3_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket.Aux_flowCalSet[2] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX2_MEASURE_FLOW_CALIBRATION1:
                        {
                            Flow_Row_1_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket.Aux_flowCalMeasure[0] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX2_MEASURE_FLOW_CALIBRATION2:
                        {
                            Flow_Row_2_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket.Aux_flowCalMeasure[1] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX2_MEASURE_FLOW_CALIBRATION3:
                        {
                            Flow_Row_3_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket.Aux_flowCalMeasure[2] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2.auxPacket, 1));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX3_SET_FLOW_CALIBRATION1:
                        {
                            Flow_Row_1_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket.Aux_flowCalSet[0] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX3_SET_FLOW_CALIBRATION2:
                        {
                            Flow_Row_2_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket.Aux_flowCalSet[1] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX3_SET_FLOW_CALIBRATION3:
                        {
                            Flow_Row_3_Set = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket.Aux_flowCalSet[2] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX3_MEASURE_FLOW_CALIBRATION1:
                        {
                            Flow_Row_1_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket.Aux_flowCalMeasure[0] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX3_MEASURE_FLOW_CALIBRATION2:
                        {
                            Flow_Row_2_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket.Aux_flowCalMeasure[1] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.AUX3_MEASURE_FLOW_CALIBRATION3:
                        {
                            Flow_Row_3_Measured = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket.Aux_flowCalMeasure[2] = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3.auxPacket, 2));
                        }
                        break;
                }
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;

            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //
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

        #region SensorZero

        #region SensorZeroResetCommand
        public RelayCommand SensorZeroResetCommand { get; set; }
        private void SensorZeroResetCommandAction(object param)
        {
            switch(_e_UPC_INDEX)
            {
                case E_UPC_INDEX.UPC1:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_RESET, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC2:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_RESET, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC3:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_RESET, tcpManager);
                    }
                    break;
            }
        }
        #endregion SensorZeroResetCommand 

        #region SensorZeroStartCommand
        public RelayCommand SensorZeroStartCommand { get; set; }
        private void SensorZeroStartCommandAction(object param)
        {
            bIsDoingSensorZeroCalibration = !bIsDoingSensorZeroCalibration;
            //Start
            if (bIsDoingSensorZeroCalibration)
            {
                switch (_e_UPC_INDEX)
                {
                    case E_UPC_INDEX.UPC1:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_START, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC2:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_START, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC3:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_START, tcpManager);
                        }
                        break;
                }
            }
            //Stop
            else
            {
                switch (_e_UPC_INDEX)
                {
                    case E_UPC_INDEX.UPC1:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_STOP, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC2:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_STOP, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC3:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_STOP, tcpManager);
                        }
                        break;
                }
            }
        }
        #endregion SensorZeroStartCommand 

        #region SensorZeroStopCommand
        public RelayCommand SensorZeroStopCommand { get; set; }
        private void SensorZeroStopCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("SensorZeroStopCommand Fired");
        }
        #endregion SensorZeroStopCommand 

        #region SensorZeroApplyCommand
        public RelayCommand SensorZeroApplyCommand { get; set; }
        private void SensorZeroApplyCommandAction(object param)
        {
            switch (_e_UPC_INDEX)
            {
                case E_UPC_INDEX.UPC1:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_SENSORZERO_APPLY, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC2:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_SENSORZERO_APPLY, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC3:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_SENSORZERO_APPLY, tcpManager);
                    }
                    break;
            }
        }
        #endregion SensorZeroApplyCommand 

        #endregion SensorZero

        #region Valve

        #region ValveResetCommand
        public RelayCommand ValveResetCommand { get; set; }
        private void ValveResetCommandAction(object param)
        {
            switch (_e_UPC_INDEX)
            {
                case E_UPC_INDEX.UPC1:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_RESET, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC2:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_RESET, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC3:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_RESET, tcpManager);
                    }
                    break;
            }
           
        }
        #endregion ValveResetCommand 

        #region ValveStartCommand
        public RelayCommand ValveStartCommand { get; set; }
        private void ValveStartCommandAction(object param)
        {
            bIsDoingValveCalibration = !bIsDoingValveCalibration;
            //Start
            if (bIsDoingValveCalibration)
            {
                switch (_e_UPC_INDEX)
                {
                    case E_UPC_INDEX.UPC1:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_START, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC2:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_START, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC3:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_START, tcpManager);
                        }
                        break;
                }                
            }
            //Stop
            else
            {
                switch (_e_UPC_INDEX)
                {
                    case E_UPC_INDEX.UPC1:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_STOP, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC2:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_STOP, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC3:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_STOP, tcpManager);
                        }
                        break;
                }
            }
            //TODO :             
            Debug.WriteLine("ValveStartCommand Fired");
        }
        #endregion ValveStartCommand 

        #region ValveStopCommand
        public RelayCommand ValveStopCommand { get; set; }
        private void ValveStopCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("ValveStopCommand Fired");
        }
        #endregion ValveStopCommand 

        #region ValveApplyCommand
        public RelayCommand ValveApplyCommand { get; set; }
        private void ValveApplyCommandAction(object param)
        {
            switch (_e_UPC_INDEX)
            {
                case E_UPC_INDEX.UPC1:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_VALVE_APPLY, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC2:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_VALVE_APPLY, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC3:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_VALVE_APPLY, tcpManager);
                    }
                    break;
            }
        }
        #endregion ValveApplyCommand 

        #endregion Valve

        #region Flow

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            {
                IsKeyPadShown = true,
                KeyPadType = KeyPad.E_KEYPAD_TYPE.DOUBLE,
                MaxValue = ChroZenService_Const.FLOAT_CALIBRATION_MAX_FLOW,
                MinValue = 0,
                CancelCommand = KeyPadCancelCommand,
                ApplyCommand = KeyPadApplyCommand,
                DeleteCommand = KeyPadDeleteCommand,
                OnCommand = KeyPadOnCommand,
                OffCommand = KeyPadOffCommand,
                KeyPadClickCommand = KeyPadKeyPadClickCommand,
            };
            switch ((E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION1:
                    {
                        vmKeyPad.Title = "Flow1 Set";
                        vmKeyPad.CurrentValue = Flow_Row_1_Set;
                        switch (_e_UPC_INDEX)
                        {
                            case E_UPC_INDEX.UPC1:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX1_SET_FLOW_CALIBRATION1;
                                }
                                break;
                            case E_UPC_INDEX.UPC2:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX2_SET_FLOW_CALIBRATION1;
                                }
                                break;
                            case E_UPC_INDEX.UPC3:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX3_SET_FLOW_CALIBRATION1;
                                }
                                break;
                        }
                    }
                    break;
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION2:
                    {
                        vmKeyPad.Title = "Flow2 Set";
                        vmKeyPad.CurrentValue = Flow_Row_2_Set;
                        switch (_e_UPC_INDEX)
                        {
                            case E_UPC_INDEX.UPC1:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX1_SET_FLOW_CALIBRATION2;
                                }
                                break;
                            case E_UPC_INDEX.UPC2:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX2_SET_FLOW_CALIBRATION2;
                                }
                                break;
                            case E_UPC_INDEX.UPC3:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX3_SET_FLOW_CALIBRATION2;
                                }
                                break;
                        }
                    }
                    break;
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION3:
                    {
                        vmKeyPad.Title = "Flow3 Set";
                        vmKeyPad.CurrentValue = Flow_Row_3_Set;
                        switch (_e_UPC_INDEX)
                        {
                            case E_UPC_INDEX.UPC1:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX1_SET_FLOW_CALIBRATION3;
                                }
                                break;
                            case E_UPC_INDEX.UPC2:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX2_SET_FLOW_CALIBRATION3;
                                }
                                break;
                            case E_UPC_INDEX.UPC3:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX3_SET_FLOW_CALIBRATION3;
                                }
                                break;
                        }
                    }
                    break;
            }
            
            //TODO :             
            Debug.WriteLine(string.Format("{0} : {1} SetCommand Fired", _e_UPC_INDEX, (E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE)param));
        }
        #endregion SetCommand 

        #region MeasuredCommand
        public RelayCommand MeasuredCommand { get; set; }
        private void MeasuredCommandAction(object param)
        {
            ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            {
                IsKeyPadShown = true,
                KeyPadType = KeyPad.E_KEYPAD_TYPE.DOUBLE,
                MaxValue = ChroZenService_Const.FLOAT_CALIBRATION_MAX_FLOW,
                MinValue = 0,
                CancelCommand = KeyPadCancelCommand,
                ApplyCommand = KeyPadApplyCommand,
                DeleteCommand = KeyPadDeleteCommand,
                OnCommand = KeyPadOnCommand,
                OffCommand = KeyPadOffCommand,
                KeyPadClickCommand = KeyPadKeyPadClickCommand,
            };
            switch ((E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION1:
                    {
                        vmKeyPad.Title = "Flow1 Measure";
                        vmKeyPad.CurrentValue = Flow_Row_1_Act;
                        switch (_e_UPC_INDEX)
                        {
                            case E_UPC_INDEX.UPC1:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX1_MEASURE_FLOW_CALIBRATION1;
                                }
                                break;
                            case E_UPC_INDEX.UPC2:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX2_MEASURE_FLOW_CALIBRATION1;
                                }
                                break;
                            case E_UPC_INDEX.UPC3:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX3_MEASURE_FLOW_CALIBRATION1;
                                }
                                break;
                        }
                    }
                    break;
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION2:
                    {
                        vmKeyPad.Title = "Flow2 Measure";
                        vmKeyPad.CurrentValue = Flow_Row_1_Act;
                        switch (_e_UPC_INDEX)
                        {
                            case E_UPC_INDEX.UPC1:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX1_MEASURE_FLOW_CALIBRATION2;
                                }
                                break;
                            case E_UPC_INDEX.UPC2:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX2_MEASURE_FLOW_CALIBRATION2;
                                }
                                break;
                            case E_UPC_INDEX.UPC3:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX3_MEASURE_FLOW_CALIBRATION2;
                                }
                                break;
                        }
                    }
                    break;
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION3:
                    {
                        vmKeyPad.Title = "Flow3 Measure";
                        vmKeyPad.CurrentValue = Flow_Row_3_Act;
                        switch (_e_UPC_INDEX)
                        {
                            case E_UPC_INDEX.UPC1:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX1_MEASURE_FLOW_CALIBRATION3;
                                }
                                break;
                            case E_UPC_INDEX.UPC2:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX2_MEASURE_FLOW_CALIBRATION3;
                                }
                                break;
                            case E_UPC_INDEX.UPC3:
                                {
                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.AUX3_MEASURE_FLOW_CALIBRATION3;
                                }
                                break;
                        }
                    }
                    break;
            }
            
            //TODO :             
            Debug.WriteLine(string.Format("{0} : {1} MeasuredCommand Fired", _e_UPC_INDEX, (E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE)param));
        }
        #endregion MeasuredCommand 

        #region FlowResetCommand
        public RelayCommand FlowResetCommand { get; set; }
        private void FlowResetCommandAction(object param)
        {
            switch (_e_UPC_INDEX)
            {
                case E_UPC_INDEX.UPC1:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_RESET, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC2:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_RESET, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC3:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_RESET, tcpManager);
                    }
                    break;
            }            
        }
        #endregion FlowResetCommand 

        #region FlowStartCommand
        public RelayCommand FlowStartCommand { get; set; }
        private void FlowStartCommandAction(object param)
        {
            bIsDoingFlowCalibration = !bIsDoingFlowCalibration;
            //Start
            if (bIsDoingFlowCalibration)
            {
                switch (_e_UPC_INDEX)
                {
                    case E_UPC_INDEX.UPC1:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_START, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC2:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_START, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC3:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_START, tcpManager);
                        }
                        break;
                }
            }
            //Stop
            else
            {
                switch (_e_UPC_INDEX)
                {
                    case E_UPC_INDEX.UPC1:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_STOP, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC2:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_STOP, tcpManager);
                        }
                        break;
                    case E_UPC_INDEX.UPC3:
                        {
                            this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_STOP, tcpManager);
                        }
                        break;
                }
            }
        }
        #endregion FlowStartCommand 

        #region FlowStopCommand
        public RelayCommand FlowStopCommand { get; set; }
        private void FlowStopCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("FlowStopCommand Fired");
        }
        #endregion FlowStopCommand 

        #region FlowApplyCommand
        public RelayCommand FlowApplyCommand { get; set; }
        private void FlowApplyCommandAction(object param)
        {
            switch (_e_UPC_INDEX)
            {
                case E_UPC_INDEX.UPC1:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX1_FLOW_APPLY, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC2:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX2_FLOW_APPLY, tcpManager);
                    }
                    break;
                case E_UPC_INDEX.UPC3:
                    {
                        this.SendCommand(E_GLOBAL_COMMAND_TYPE.E_AUX3_FLOW_APPLY, tcpManager);
                    }
                    break;
            }
        }
        #endregion FlowApplyCommand 

        #endregion Flow


        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
