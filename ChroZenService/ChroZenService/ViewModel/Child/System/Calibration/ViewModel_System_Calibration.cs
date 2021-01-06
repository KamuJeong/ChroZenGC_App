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

        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property


        ViewModel_System_CalibrationAuxTemp _ViewModel_System_CalibrationAuxTemp1 = new ViewModel_System_CalibrationAuxTemp(ChroZenService_Const.E_AUXTEMP_INDEX.AUXTEMP1);
        public ViewModel_System_CalibrationAuxTemp ViewModel_System_CalibrationAuxTemp1 { get { return _ViewModel_System_CalibrationAuxTemp1; } set { if (_ViewModel_System_CalibrationAuxTemp1 != value) { _ViewModel_System_CalibrationAuxTemp1 = value; OnPropertyChanged("ViewModel_System_CalibrationAuxTemp1"); } } }
        ViewModel_System_CalibrationAuxTemp _ViewModel_System_CalibrationAuxTemp2 = new ViewModel_System_CalibrationAuxTemp(ChroZenService_Const.E_AUXTEMP_INDEX.AUXTEMP2);
        public ViewModel_System_CalibrationAuxTemp ViewModel_System_CalibrationAuxTemp2 { get { return _ViewModel_System_CalibrationAuxTemp2; } set { if (_ViewModel_System_CalibrationAuxTemp2 != value) { _ViewModel_System_CalibrationAuxTemp2 = value; OnPropertyChanged("ViewModel_System_CalibrationAuxTemp2"); } } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDetFront = new ViewModel_System_CalibrationDet(ChroZenService_Const.E_DET_LOCATION.FRONT);
        public ViewModel_System_CalibrationDet ViewModel_System_CalibrationDetFront { get { return _ViewModel_System_CalibrationDetFront; } set { if (_ViewModel_System_CalibrationDetFront != value) { _ViewModel_System_CalibrationDetFront = value; OnPropertyChanged("ViewModel_System_CalibrationDetFront"); } } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDetCenter = new ViewModel_System_CalibrationDet(ChroZenService_Const.E_DET_LOCATION.CENTER);
        public ViewModel_System_CalibrationDet ViewModel_System_CalibrationDetCenter { get { return _ViewModel_System_CalibrationDetCenter; } set { if (_ViewModel_System_CalibrationDetCenter != value) { _ViewModel_System_CalibrationDetCenter = value; OnPropertyChanged("ViewModel_System_CalibrationDetCenter"); } } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDetRear = new ViewModel_System_CalibrationDet(ChroZenService_Const.E_DET_LOCATION.REAR);
        public ViewModel_System_CalibrationDet ViewModel_System_CalibrationDetRear { get { return _ViewModel_System_CalibrationDetRear; } set { if (_ViewModel_System_CalibrationDetRear != value) { _ViewModel_System_CalibrationDetRear = value; OnPropertyChanged("ViewModel_System_CalibrationDetRear"); } } }

        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInletFront = new ViewModel_System_CalibrationInlet(ChroZenService_Const.E_INLET_LOCATION.FRONT);
        public ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInletFront { get { return _ViewModel_System_CalibrationInletFront; } set { if (_ViewModel_System_CalibrationInletFront != value) { _ViewModel_System_CalibrationInletFront = value; OnPropertyChanged("ViewModel_System_CalibrationInletFront"); } } }
        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInletCenter = new ViewModel_System_CalibrationInlet(ChroZenService_Const.E_INLET_LOCATION.CENTER);
        public ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInletCenter { get { return _ViewModel_System_CalibrationInletCenter; } set { if (_ViewModel_System_CalibrationInletCenter != value) { _ViewModel_System_CalibrationInletCenter = value; OnPropertyChanged("ViewModel_System_CalibrationInletCenter"); } } }
        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInletRear = new ViewModel_System_CalibrationInlet(ChroZenService_Const.E_INLET_LOCATION.REAR);
        public ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInletRear { get { return _ViewModel_System_CalibrationInletRear; } set { if (_ViewModel_System_CalibrationInletRear != value) { _ViewModel_System_CalibrationInletRear = value; OnPropertyChanged("ViewModel_System_CalibrationInletRear"); } } }

        ViewModel_System_CalibrationOven _ViewModel_System_CalibrationOven = new ViewModel_System_CalibrationOven();
        public ViewModel_System_CalibrationOven ViewModel_System_CalibrationOven { get { return _ViewModel_System_CalibrationOven; } set { if (_ViewModel_System_CalibrationOven != value) { _ViewModel_System_CalibrationOven = value; OnPropertyChanged("ViewModel_System_CalibrationOven"); } } }
        ViewModel_System_CalibrationUPC _ViewModel_System_CalibrationUPC1 = new ViewModel_System_CalibrationUPC(ChroZenService_Const.E_UPC_INDEX.UPC1);
        public ViewModel_System_CalibrationUPC ViewModel_System_CalibrationUPC1 { get { return _ViewModel_System_CalibrationUPC1; } set { if (_ViewModel_System_CalibrationUPC1 != value) { _ViewModel_System_CalibrationUPC1 = value; OnPropertyChanged("ViewModel_System_CalibrationUPC1"); } } }
        ViewModel_System_CalibrationUPC _ViewModel_System_CalibrationUPC2 = new ViewModel_System_CalibrationUPC(ChroZenService_Const.E_UPC_INDEX.UPC2);
        public ViewModel_System_CalibrationUPC ViewModel_System_CalibrationUPC2 { get { return _ViewModel_System_CalibrationUPC2; } set { if (_ViewModel_System_CalibrationUPC2 != value) { _ViewModel_System_CalibrationUPC2 = value; OnPropertyChanged("ViewModel_System_CalibrationUPC2"); } } }
        ViewModel_System_CalibrationUPC _ViewModel_System_CalibrationUPC3 = new ViewModel_System_CalibrationUPC(ChroZenService_Const.E_UPC_INDEX.UPC3);
        public ViewModel_System_CalibrationUPC ViewModel_System_CalibrationUPC3 { get { return _ViewModel_System_CalibrationUPC3; } set { if (_ViewModel_System_CalibrationUPC3 != value) { _ViewModel_System_CalibrationUPC3 = value; OnPropertyChanged("ViewModel_System_CalibrationUPC3"); } } }

        #endregion Property

        #region Command


        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
