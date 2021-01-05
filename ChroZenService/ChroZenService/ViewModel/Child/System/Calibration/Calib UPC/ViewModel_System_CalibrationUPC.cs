using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_System_CalibrationUPC : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_CalibrationUPC(E_UPC_INDEX e_UPC_INDEX)
        {
            _e_UPC_INDEX = e_UPC_INDEX;
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
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        public E_UPC_INDEX _e_UPC_INDEX;

        bool _bIsDoingSensorZeroCalibration;
        public bool bIsDoingSensorZeroCalibration { get { return _bIsDoingSensorZeroCalibration; } set { _bIsDoingSensorZeroCalibration = value; OnPropertyChanged("bIsDoingSensorZeroCalibration"); } }

        string _SensorZero_Row_1;
        public string SensorZero_Row_1 { get { return _SensorZero_Row_1; } set { _SensorZero_Row_1 = value; OnPropertyChanged("SensorZero_Row_1"); } }

        string _SensorZero_Row_2;
        public string SensorZero_Row_2 { get { return _SensorZero_Row_2; } set { _SensorZero_Row_2 = value; OnPropertyChanged("SensorZero_Row_2"); } }

        string _SensorZero_Row_3;
        public string SensorZero_Row_3 { get { return _SensorZero_Row_3; } set { _SensorZero_Row_3 = value; OnPropertyChanged("SensorZero_Row_3"); } }

        bool _bIsDoingValveCalibration;
        public bool bIsDoingValveCalibration { get { return _bIsDoingValveCalibration; } set { _bIsDoingValveCalibration = value; OnPropertyChanged("bIsDoingValveCalibration"); } }

        string _Valve_Row_1_State;
        public string Valve_Row_1_State { get { return _Valve_Row_1_State; } set { _Valve_Row_1_State = value; OnPropertyChanged("Valve_Row_1_State"); } }


        string _Valve_Row_1_Voltage;
        public string Valve_Row_1_Voltage { get { return _Valve_Row_1_Voltage; } set { _Valve_Row_1_Voltage = value; OnPropertyChanged("Valve_Row_1_Voltage"); } }


        string _Valve_Row_1_Flow;
        public string Valve_Row_1_Flow { get { return _Valve_Row_1_Flow; } set { _Valve_Row_1_Flow = value; OnPropertyChanged("Valve_Row_1_Flow"); } }


        string _Valve_Row_2_State;
        public string Valve_Row_2_State { get { return _Valve_Row_2_State; } set { _Valve_Row_2_State = value; OnPropertyChanged("Valve_Row_2_State"); } }


        string _Valve_Row_2_Voltage;
        public string Valve_Row_2_Voltage { get { return _Valve_Row_2_Voltage; } set { _Valve_Row_2_Voltage = value; OnPropertyChanged("Valve_Row_2_Voltage"); } }

        string _Valve_Row_2_Flow;
        public string Valve_Row_2_Flow { get { return _Valve_Row_2_Flow; } set { _Valve_Row_2_Flow = value; OnPropertyChanged("Valve_Row_2_Flow"); } }

        string _Valve_Row_3_State;
        public string Valve_Row_3_State { get { return _Valve_Row_3_State; } set { _Valve_Row_3_State = value; OnPropertyChanged("Valve_Row_3_State"); } }

        string _Valve_Row_3_Voltage;
        public string Valve_Row_3_Voltage { get { return _Valve_Row_3_Voltage; } set { _Valve_Row_3_Voltage = value; OnPropertyChanged("Valve_Row_3_Voltage"); } }

        string _Valve_Row_3_Flow;
        public string Valve_Row_3_Flow { get { return _Valve_Row_3_Flow; } set { _Valve_Row_3_Flow = value; OnPropertyChanged("Valve_Row_3_Flow"); } }

        bool _bIsDoingFlowCalibration;

        /// <summary>
        /// State==7
        /// </summary>
        public bool bIsDoingFlowCalibration { get { return _bIsDoingFlowCalibration; } set { _bIsDoingFlowCalibration = value; OnPropertyChanged("bIsDoingFlowCalibration"); } }

        string _Flow_Row_1_Act;
        public string Flow_Row_1_Act { get { return _Flow_Row_1_Act; } set { _Flow_Row_1_Act = value; OnPropertyChanged("Flow_Row_1_Act"); } }

        string _Flow_Row_1_Set;
        public string Flow_Row_1_Set { get { return _Flow_Row_1_Set; } set { _Flow_Row_1_Set = value; OnPropertyChanged("Flow_Row_1_Set"); } }

        string _Flow_Row_1_Measured;
        public string Flow_Row_1_Measured { get { return _Flow_Row_1_Measured; } set { _Flow_Row_1_Measured = value; OnPropertyChanged("Flow_Row_1_Measured"); } }

        string _Flow_Row_2_Act;
        public string Flow_Row_2_Act { get { return _Flow_Row_2_Act; } set { _Flow_Row_2_Act = value; OnPropertyChanged("Flow_Row_2_Act"); } }

        string _Flow_Row_2_Set;
        public string Flow_Row_2_Set { get { return _Flow_Row_2_Set; } set { _Flow_Row_2_Set = value; OnPropertyChanged("Flow_Row_2_Set"); } }

        string _Flow_Row_2_Measured;
        public string Flow_Row_2_Measured { get { return _Flow_Row_2_Measured; } set { _Flow_Row_2_Measured = value; OnPropertyChanged("Flow_Row_2_Measured"); } }

        string _Flow_Row_3_Act;
        public string Flow_Row_3_Act { get { return _Flow_Row_3_Act; } set { _Flow_Row_3_Act = value; OnPropertyChanged("Flow_Row_3_Act"); } }

        string _Flow_Row_3_Set;
        public string Flow_Row_3_Set { get { return _Flow_Row_3_Set; } set { _Flow_Row_3_Set = value; OnPropertyChanged("Flow_Row_3_Set"); } }

        string _Flow_Row_3_Measured;
        public string Flow_Row_3_Measured { get { return _Flow_Row_3_Measured; } set { _Flow_Row_3_Measured = value; OnPropertyChanged("Flow_Row_3_Measured"); } }


        #endregion Property

        #region Command

        #region SensorZero

        #region SensorZeroResetCommand
        public RelayCommand SensorZeroResetCommand { get; set; }
        private void SensorZeroResetCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("SensorZeroResetCommand Fired");
        }
        #endregion SensorZeroResetCommand 

        #region SensorZeroStartCommand
        public RelayCommand SensorZeroStartCommand { get; set; }
        private void SensorZeroStartCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("SensorZeroStartCommand Fired");
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
            //TODO :             
            Debug.WriteLine("SensorZeroApplyCommand Fired");
        }
        #endregion SensorZeroApplyCommand 

        #endregion SensorZero

        #region Valve

        #region ValveResetCommand
        public RelayCommand ValveResetCommand { get; set; }
        private void ValveResetCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("ValveResetCommand Fired");
        }
        #endregion ValveResetCommand 

        #region ValveStartCommand
        public RelayCommand ValveStartCommand { get; set; }
        private void ValveStartCommandAction(object param)
        {
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
            //TODO :             
            Debug.WriteLine("ValveApplyCommand Fired");
        }
        #endregion ValveApplyCommand 

        #endregion Valve

        #region Flow

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION1:
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION2:
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION3:
                    {

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
            switch ((E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION1:
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION2:
                case E_SYSTEM_CALIBRATION_AUX_UPC_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION3:
                    {

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
            //TODO :             
            Debug.WriteLine("FlowResetCommand Fired");
        }
        #endregion FlowResetCommand 

        #region FlowStartCommand
        public RelayCommand FlowStartCommand { get; set; }
        private void FlowStartCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("FlowStartCommand Fired");
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
            //TODO :             
            Debug.WriteLine("FlowApplyCommand Fired");
        }
        #endregion FlowApplyCommand 

        #endregion Flow


        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
