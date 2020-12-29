using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_System_CalibrationOven : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_CalibrationOven()
        {
            SetCommand = new RelayCommand(SetCommandAction);
            MeasuredCommand = new RelayCommand(MeasuredCommandAction);
            ResetCommand = new RelayCommand(ResetCommandAction);
            ApplyCommand = new RelayCommand(ApplyCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        float _ActualTemp;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public float ActualTemp { get { return _ActualTemp; } set { _ActualTemp = value; OnPropertyChanged("ActualTemp"); } }

        float _fSet1;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1 { get { return _fSet1; } set { _fSet1 = value; OnPropertyChanged("fSet1"); } }

        float _fSet2;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2 { get { return _fSet2; } set { _fSet2 = value; OnPropertyChanged("fSet2"); } }

        float _Measure1;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1 { get { return _Measure1; } set { _Measure1 = value; OnPropertyChanged("Measure1"); } }

        float _Measure2;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2 { get { return _Measure2; } set { _Measure2 = value; OnPropertyChanged("Measure2"); } }


        #endregion Property

        #region Command

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE.TEMP_CALIBRATION_T1:
                case E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE.TEMP_CALIBRATION_T2:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region MeasuredCommand
        public RelayCommand MeasuredCommand { get; set; }
        private void MeasuredCommandAction(object param)
        {
            switch ((E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE)param)
            {
                case E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE.TEMP_CALIBRATION_T1:
                case E_SYSTEM_CALIBRATION_OVEN_COMMAND_TYPE.TEMP_CALIBRATION_T2:
                    {

                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("MeasuredCommand Fired");
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

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
