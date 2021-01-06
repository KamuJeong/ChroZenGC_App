using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_System_CalibrationAuxTemp : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_CalibrationAuxTemp(E_AUXTEMP_INDEX e_AUXTEMP_INDEX)
        {
            _e_AUXTEMP_INDEX = e_AUXTEMP_INDEX;
            SetCommand = new RelayCommand(SetCommandAction);
            MeasuredCommand = new RelayCommand(MeasuredCommandAction);
            ResetCommand = new RelayCommand(ResetCommandAction);
            ApplyCommand = new RelayCommand(ApplyCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        public E_AUXTEMP_INDEX _e_AUXTEMP_INDEX;

        string _ActualTemp_Calib1;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public string ActualTemp_Calib1
        {
            get { return _ActualTemp_Calib1; }
            set
            {
                if (_ActualTemp_Calib1 != value)
                { _ActualTemp_Calib1 = value; OnPropertyChanged("ActualTemp_Calib1"); }
            }
        }

        float _fSet1_Calib1 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib1 { get { return _fSet1_Calib1; } set { if (_fSet1_Calib1 != value) { _fSet1_Calib1 = value; OnPropertyChanged("fSet1_Calib1"); } } }

        float _fSet2_Calib1 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib1 { get { return _fSet2_Calib1; } set { if (_fSet2_Calib1 != value) { _fSet2_Calib1 = value; OnPropertyChanged("fSet2_Calib1"); } } }

        float _Measure1_Calib1 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib1 { get { return _Measure1_Calib1; } set { if (_Measure1_Calib1 != value) { _Measure1_Calib1 = value; OnPropertyChanged("Measure1_Calib1"); } } }

        float _Measure2_Calib1 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib1 { get { return _Measure2_Calib1; } set { if (_Measure2_Calib1 != value) { _Measure2_Calib1 = value; OnPropertyChanged("Measure2_Calib1"); } } }

        string _ActualTemp_Calib2;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public string ActualTemp_Calib2 { get { return _ActualTemp_Calib2; } set { if (_ActualTemp_Calib2 != value) { _ActualTemp_Calib2 = value; OnPropertyChanged("ActualTemp_Calib2"); } } }

        float _fSet1_Calib2 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib2 { get { return _fSet1_Calib2; } set { if (_fSet1_Calib2 != value) { _fSet1_Calib2 = value; OnPropertyChanged("fSet1_Calib2"); } } }

        float _fSet2_Calib2 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib2 { get { return _fSet2_Calib2; } set { if (_fSet2_Calib2 != value) { _fSet2_Calib2 = value; OnPropertyChanged("fSet2_Calib2"); } } }

        float _Measure1_Calib2 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib2 { get { return _Measure1_Calib2; } set { if (_Measure1_Calib2 != value) { _Measure1_Calib2 = value; OnPropertyChanged("Measure1_Calib2"); } } }

        float _Measure2_Calib2 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib2 { get { return _Measure2_Calib2; } set { if (_Measure2_Calib2 != value) { _Measure2_Calib2 = value; OnPropertyChanged("Measure2_Calib2"); } } }


        string _ActualTemp_Calib3;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public string ActualTemp_Calib3 { get { return _ActualTemp_Calib3; } set { if (_ActualTemp_Calib3 != value) { _ActualTemp_Calib3 = value; OnPropertyChanged("ActualTemp_Calib3"); } } }

        float _fSet1_Calib3 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib3 { get { return _fSet1_Calib3; } set { if (_fSet1_Calib3 != value) { _fSet1_Calib3 = value; OnPropertyChanged("fSet1_Calib3"); } } }

        float _fSet2_Calib3 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib3 { get { return _fSet2_Calib3; } set { if (_fSet2_Calib3 != value) { _fSet2_Calib3 = value; OnPropertyChanged("fSet2_Calib3"); } } }

        float _Measure1_Calib3 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib3 { get { return _Measure1_Calib3; } set { if (_Measure1_Calib3 != value) { _Measure1_Calib3 = value; OnPropertyChanged("Measure1_Calib3"); } } }

        float _Measure2_Calib3 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib3 { get { return _Measure2_Calib3; } set { if (_Measure2_Calib3 != value) { _Measure2_Calib3 = value; OnPropertyChanged("Measure2_Calib3"); } } }


        string _ActualTemp_Calib4;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public string ActualTemp_Calib4 { get { return _ActualTemp_Calib4; } set { if (_ActualTemp_Calib4 != value) { _ActualTemp_Calib4 = value; OnPropertyChanged("ActualTemp_Calib4"); } } }

        float _fSet1_Calib4 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib4 { get { return _fSet1_Calib4; } set { if (_fSet1_Calib4 != value) { _fSet1_Calib4 = value; OnPropertyChanged("fSet1_Calib4"); } } }

        float _fSet2_Calib4 = YC_Const.FLOAT_DEFAULT_SET_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib4 { get { return _fSet2_Calib4; } set { if (_fSet2_Calib4 != value) { _fSet2_Calib4 = value; OnPropertyChanged("fSet2_Calib4"); } } }

        float _Measure1_Calib4 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib4 { get { return _Measure1_Calib4; } set { if (_Measure1_Calib4 != value) { _Measure1_Calib4 = value; OnPropertyChanged("Measure1_Calib4"); } } }

        float _Measure2_Calib4 = YC_Const.FLOAT_DEFAULT_MEASURE_AUX_TEMP;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib4 { get { return _Measure2_Calib4; } set { if (_Measure2_Calib4 != value) { _Measure2_Calib4 = value; OnPropertyChanged("Measure2_Calib4"); } } }

        #endregion Property

        #region Command

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION1_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION1_T2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION2_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION2_T2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION3_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION3_T2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION4_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION4_T2:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("{0} : {1} SetCommand Fired", _e_AUXTEMP_INDEX, (E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE)param));
        }
        #endregion SetCommand 

        #region MeasuredCommand
        public RelayCommand MeasuredCommand { get; set; }
        private void MeasuredCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION1_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION1_T2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION2_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION2_T2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION3_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION3_T2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION4_T1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE.TEMP_CALIBRATION4_T2:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("{0} : {1} MeasuredCommand Fired", _e_AUXTEMP_INDEX, (E_SYSTEM_CALIBRATION_AUXTEMP_SET_MEASURE_COMMAND_TYPE)param));
        }
        #endregion MeasuredCommand 

        #region ResetCommand
        public RelayCommand ResetCommand { get; set; }
        private void ResetCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION3:
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION4:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("ResetCommand Fired");
        }
        #endregion ResetCommand 

        #region ApplyCommand
        public RelayCommand ApplyCommand { get; set; }
        private void ApplyCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION1:
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION2:
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION3:
                case E_SYSTEM_CALIBRATION_AUXTEMP_RESET_APPLY_COMMAND_TYPE.TEMP_CALIBRATION4:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("ApplyCommand Fired");
        }
        #endregion ApplyCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
