using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_Calibration : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Calibration()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property


        ViewModel_System_CalibrationAuxTemp _ViewModel_System_CalibrationAuxTemp = new ViewModel_System_CalibrationAuxTemp();
        ViewModel_System_CalibrationAuxTemp ViewModel_System_CalibrationAuxTemp { get { return _ViewModel_System_CalibrationAuxTemp; } set { _ViewModel_System_CalibrationAuxTemp = value; OnPropertyChanged("ViewModel_System_CalibrationAuxTemp"); } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDetFront = new ViewModel_System_CalibrationDet();
        ViewModel_System_CalibrationDet ViewModel_System_CalibrationDetFront { get { return _ViewModel_System_CalibrationDetFront; } set { _ViewModel_System_CalibrationDetFront = value; OnPropertyChanged("ViewModel_System_CalibrationDetFront"); } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDetCenter = new ViewModel_System_CalibrationDet();
        ViewModel_System_CalibrationDet ViewModel_System_CalibrationDetCenter { get { return _ViewModel_System_CalibrationDetCenter; } set { _ViewModel_System_CalibrationDetCenter = value; OnPropertyChanged("ViewModel_System_CalibrationDetCenter"); } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDetRear = new ViewModel_System_CalibrationDet();
        ViewModel_System_CalibrationDet ViewModel_System_CalibrationDetRear { get { return _ViewModel_System_CalibrationDetRear; } set { _ViewModel_System_CalibrationDetRear = value; OnPropertyChanged("ViewModel_System_CalibrationDetRear"); } }

        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInletFront = new ViewModel_System_CalibrationInlet();
        ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInletFront { get { return _ViewModel_System_CalibrationInletFront; } set { _ViewModel_System_CalibrationInletFront = value; OnPropertyChanged("ViewModel_System_CalibrationInletFront"); } }
        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInletCenter = new ViewModel_System_CalibrationInlet();
        ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInletCenter { get { return _ViewModel_System_CalibrationInletCenter; } set { _ViewModel_System_CalibrationInletCenter = value; OnPropertyChanged("ViewModel_System_CalibrationInletCenter"); } }
        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInletRear = new ViewModel_System_CalibrationInlet();
        ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInletRear { get { return _ViewModel_System_CalibrationInletRear; } set { _ViewModel_System_CalibrationInletRear = value; OnPropertyChanged("ViewModel_System_CalibrationInletRear"); } }

        ViewModel_System_CalibrationOven _ViewModel_System_CalibrationOven = new ViewModel_System_CalibrationOven();
        ViewModel_System_CalibrationOven ViewModel_System_CalibrationOven { get { return _ViewModel_System_CalibrationOven; } set { _ViewModel_System_CalibrationOven = value; OnPropertyChanged("ViewModel_System_CalibrationOven"); } }
        ViewModel_System_CalibrationUPC _ViewModel_System_CalibrationUPC = new ViewModel_System_CalibrationUPC();
        ViewModel_System_CalibrationUPC ViewModel_System_CalibrationUPC { get { return _ViewModel_System_CalibrationUPC; } set { _ViewModel_System_CalibrationUPC = value; OnPropertyChanged("ViewModel_System_CalibrationUPC"); } }


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
