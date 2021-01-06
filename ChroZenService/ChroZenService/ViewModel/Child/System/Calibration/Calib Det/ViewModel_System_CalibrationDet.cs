using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_System_CalibrationDet : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_CalibrationDet(E_DET_LOCATION m_e_DET_LOCATION)
        {
            e_DET_LOCATION = m_e_DET_LOCATION;

            SetCommand = new RelayCommand(SetCommandAction);
            MeasuredCommand = new RelayCommand(MeasuredCommandAction);
            ResetCommand = new RelayCommand(ResetCommandAction);
            ApplyCommand = new RelayCommand(ApplyCommandAction);
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

        public E_DET_LOCATION e_DET_LOCATION;

        E_DET_TYPE _e_DET_TYPE = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE e_DET_TYPE { get { return _e_DET_TYPE; } set { if (_e_DET_TYPE != value) { _e_DET_TYPE = value; OnPropertyChanged("e_DET_TYPE"); } } }

        bool _IsSensor1Visible = true;
        public bool IsSensor1Visible { get { return _IsSensor1Visible; } set { if (_IsSensor1Visible != value) { _IsSensor1Visible = value; OnPropertyChanged("IsSensor1Visible"); } } }
        bool _IsSensor2Visible = true;
        public bool IsSensor2Visible { get { return _IsSensor2Visible; } set { if (_IsSensor2Visible != value) { _IsSensor2Visible = value; OnPropertyChanged("IsSensor2Visible"); } } }
        bool _IsSensor3Visible = true;
        public bool IsSensor3Visible { get { return _IsSensor3Visible; } set { if (_IsSensor3Visible != value) { _IsSensor3Visible = value; OnPropertyChanged("IsSensor3Visible"); } } }

        bool _IsValve1Visible = true;
        public bool IsValve1Visible { get { return _IsValve1Visible; } set { if (_IsValve1Visible != value) { _IsValve1Visible = value; OnPropertyChanged("IsValve1Visible"); } } }
        bool _IsValve2Visible = true;
        public bool IsValve2Visible { get { return _IsValve2Visible; } set { if (_IsValve2Visible != value) { _IsValve2Visible = value; OnPropertyChanged("IsValve2Visible"); } } }
        bool _IsValve3Visible = true;
        public bool IsValve3Visible { get { return _IsValve3Visible; } set { if (_IsValve3Visible != value) { _IsValve3Visible = value; OnPropertyChanged("IsValve3Visible"); } } }

        bool _IsFlow1Visible = true;
        public bool IsFlow1Visible { get { return _IsFlow1Visible; } set { if (_IsFlow1Visible != value) { _IsFlow1Visible = value; OnPropertyChanged("IsFlow1Visible"); } } }
        bool _IsFlow2Visible = true;
        public bool IsFlow2Visible { get { return _IsFlow2Visible; } set { if (_IsFlow2Visible != value) { _IsFlow2Visible = value; OnPropertyChanged("IsFlow2Visible"); } } }
        bool _IsFlow3Visible = true;
        public bool IsFlow3Visible { get { return _IsFlow3Visible; } set { if (_IsFlow3Visible != value) { _IsFlow3Visible = value; OnPropertyChanged("IsFlow3Visible"); } } }

        string _SensorTitle1 = "DS1";
        public string SensorTitle1 { get { return _SensorTitle1; } set { if (_SensorTitle1 != value) { _SensorTitle1 = value; OnPropertyChanged("SensorTitle1"); } } }
        string _SensorTitle2 = "DS2";
        public string SensorTitle2 { get { return _SensorTitle2; } set { if (_SensorTitle2 != value) { _SensorTitle2 = value; OnPropertyChanged("SensorTitle2"); } } }
        string _SensorTitle3 = "DS3";
        public string SensorTitle3 { get { return _SensorTitle3; } set { if (_SensorTitle3 != value) { _SensorTitle3 = value; OnPropertyChanged("SensorTitle3"); } } }
        string _ValveTitle1 = "DV1";
        public string ValveTitle1 { get { return _ValveTitle1; } set { if (_ValveTitle1 != value) { _ValveTitle1 = value; OnPropertyChanged("ValveTitle1"); } } }
        string _ValveTitle2 = "DV2";
        public string ValveTitle2 { get { return _ValveTitle2; } set { if (_ValveTitle2 != value) { _ValveTitle2 = value; OnPropertyChanged("ValveTitle2"); } } }
        string _ValveTitle3 = "DV3";
        public string ValveTitle3 { get { return _ValveTitle3; } set { if (_ValveTitle3 != value) { _ValveTitle3 = value; OnPropertyChanged("ValveTitle3"); } } }
        string _FlowTitle1 = "DF1";
        public string FlowTitle1 { get { return _FlowTitle1; } set { if (_FlowTitle1 != value) { _FlowTitle1 = value; OnPropertyChanged("FlowTitle1"); } } }
        string _FlowTitle2 = "DF2";
        public string FlowTitle2 { get { return _FlowTitle2; } set { if (_FlowTitle2 != value) { _FlowTitle2 = value; OnPropertyChanged("FlowTitle2"); } } }
        string _FlowTitle3 = "DF3";
        public string FlowTitle3 { get { return _FlowTitle3; } set { if (_FlowTitle3 != value) { _FlowTitle3 = value; OnPropertyChanged("FlowTitle3"); } } }

        string _ActT_1;
        public string ActT_1 { get { return _ActT_1; } set { if (_ActT_1 != value) { _ActT_1 = value; OnPropertyChanged("ActT_1"); } } }

        string _ActT_2;
        public string ActT_2 { get { return _ActT_2; } set { if (_ActT_2 != value) { _ActT_2 = value; OnPropertyChanged("ActT_2"); } } }

        float _fSet1;
        public float fSet1 { get { return _fSet1; } set { if (_fSet1 != value) { _fSet1 = value; OnPropertyChanged("fSet1"); } } }

        float _fSet2;
        public float fSet2 { get { return _fSet2; } set { if (_fSet2 != value) { _fSet2 = value; OnPropertyChanged("fSet2"); } } }

        float _fMeasure1;
        public float fMeasure1 { get { return _fMeasure1; } set { if (_fMeasure1 != value) { _fMeasure1 = value; OnPropertyChanged("fMeasure1"); } } }

        float _fMeasure2;
        public float fMeasure2 { get { return _fMeasure2; } set { if (_fMeasure2 != value) { _fMeasure2 = value; OnPropertyChanged("fMeasure2"); } } }

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
        public string Valve_Row_1_Voltage { get { return _Valve_Row_1_Voltage; } set { if (_Valve_Row_1_Voltage != value) { _Valve_Row_1_Voltage = value; OnPropertyChanged("Valve_Row_1_Voltage"); } } }


        string _Valve_Row_1_Flow;
        public string Valve_Row_1_Flow { get { return _Valve_Row_1_Flow; } set { if (_Valve_Row_1_Flow != value) { _Valve_Row_1_Flow = value; OnPropertyChanged("Valve_Row_1_Flow"); } } }


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

        #region Temp Calibration

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION_T1:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION_T2:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION1:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION2:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION3:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("{0} Det : {1} SetCommand Fired", _e_DET_TYPE, (E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE)param));
        }
        #endregion SetCommand 

        #region MeasuredCommand
        public RelayCommand MeasuredCommand { get; set; }
        private void MeasuredCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION_T1:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION_T2:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION1:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION2:
                case E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE.FLOW_CALIBRATION3:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("{0} Det : {1} MeasuredCommand Fired", _e_DET_TYPE, (E_SYSTEM_CALIBRATION_DET_SET_MEASURE_COMMAND_TYPE)param));
        }
        #endregion MeasuredCommand 

        #region ResetCommand
        public RelayCommand ResetCommand { get; set; }
        private void ResetCommandAction(object param)
        {

            //TODO :             
            Debug.WriteLine("ResetCommand Fired");
        }
        #endregion ResetCommand 

        #region ApplyCommand
        public RelayCommand ApplyCommand { get; set; }
        private void ApplyCommandAction(object param)
        {

            //TODO :             
            Debug.WriteLine("ApplyCommand Fired");
        }
        #endregion ApplyCommand 

        #endregion Temp Calibration

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
