using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_CalibrationAuxTemp : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_CalibrationAuxTemp()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        float _ActualTemp_Calib1;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public float ActualTemp_Calib1 { get { return _ActualTemp_Calib1; } set { _ActualTemp_Calib1 = value; OnPropertyChanged("ActualTemp_Calib1"); } }

        float _fSet1_Calib1;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib1 { get { return _fSet1_Calib1; } set { _fSet1_Calib1 = value; OnPropertyChanged("fSet1_Calib1"); } }

        float _fSet2_Calib1;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib1 { get { return _fSet2_Calib1; } set { _fSet2_Calib1 = value; OnPropertyChanged("fSet2_Calib1"); } }

        float _Measure1_Calib1;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib1 { get { return _Measure1_Calib1; } set { _Measure1_Calib1 = value; OnPropertyChanged("Measure1_Calib1"); } }

        float _Measure2_Calib1;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib1 { get { return _Measure2_Calib1; } set { _Measure2_Calib1 = value; OnPropertyChanged("Measure2_Calib1"); } }

        float _ActualTemp_Calib2;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public float ActualTemp_Calib2 { get { return _ActualTemp_Calib2; } set { _ActualTemp_Calib2 = value; OnPropertyChanged("ActualTemp_Calib2"); } }

        float _fSet1_Calib2;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib2 { get { return _fSet1_Calib2; } set { _fSet1_Calib2 = value; OnPropertyChanged("fSet1_Calib2"); } }

        float _fSet2_Calib2;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib2 { get { return _fSet2_Calib2; } set { _fSet2_Calib2 = value; OnPropertyChanged("fSet2_Calib2"); } }

        float _Measure1_Calib2;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib2 { get { return _Measure1_Calib2; } set { _Measure1_Calib2 = value; OnPropertyChanged("Measure1_Calib2"); } }

        float _Measure2_Calib2;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib2 { get { return _Measure2_Calib2; } set { _Measure2_Calib2 = value; OnPropertyChanged("Measure2_Calib2"); } }


        float _ActualTemp_Calib3;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public float ActualTemp_Calib3 { get { return _ActualTemp_Calib3; } set { _ActualTemp_Calib3 = value; OnPropertyChanged("ActualTemp_Calib3"); } }

        float _fSet1_Calib3;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib3 { get { return _fSet1_Calib3; } set { _fSet1_Calib3 = value; OnPropertyChanged("fSet1_Calib3"); } }

        float _fSet2_Calib3;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib3 { get { return _fSet2_Calib3; } set { _fSet2_Calib3 = value; OnPropertyChanged("fSet2_Calib3"); } }

        float _Measure1_Calib3;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib3 { get { return _Measure1_Calib3; } set { _Measure1_Calib3 = value; OnPropertyChanged("Measure1_Calib3"); } }

        float _Measure2_Calib3;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib3 { get { return _Measure2_Calib3; } set { _Measure2_Calib3 = value; OnPropertyChanged("Measure2_Calib3"); } }


        float _ActualTemp_Calib4;
        /// <summary>
        /// T_CHROZEN_GC_STATE
        /// </summary>
        public float ActualTemp_Calib4 { get { return _ActualTemp_Calib4; } set { _ActualTemp_Calib4 = value; OnPropertyChanged("ActualTemp_Calib4"); } }

        float _fSet1_Calib4;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[0]
        /// </summary>
        public float fSet1_Calib4 { get { return _fSet1_Calib4; } set { _fSet1_Calib4 = value; OnPropertyChanged("fSet1_Calib4"); } }

        float _fSet2_Calib4;
        /// <summary>
        /// T_TEMP_CALIBRATION.fSet[1]
        /// </summary>
        public float fSet2_Calib4 { get { return _fSet2_Calib4; } set { _fSet2_Calib4 = value; OnPropertyChanged("fSet2_Calib4"); } }

        float _Measure1_Calib4;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[0]
        /// </summary>
        public float Measure1_Calib4 { get { return _Measure1_Calib4; } set { _Measure1_Calib4 = value; OnPropertyChanged("Measure1_Calib4"); } }

        float _Measure2_Calib4;
        /// <summary>
        /// T_TEMP_CALIBRATION.fMeasure[1]
        /// </summary>
        public float Measure2_Calib4 { get { return _Measure2_Calib4; } set { _Measure2_Calib4 = value; OnPropertyChanged("Measure2_Calib4"); } }

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

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
