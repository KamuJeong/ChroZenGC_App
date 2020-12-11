using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
   public class ViewModelSystemPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelSystemPage()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ViewModel_System_Calibration _ViewModel_System_Calibration = new ViewModel_System_Calibration();
        ViewModel_System_Calibration ViewModel_System_Calibration { get { return _ViewModel_System_Calibration; } set { _ViewModel_System_Calibration = value; OnPropertyChanged("ViewModel_System_Calibration"); } }
        ViewModel_System_CalibrationAuxTemp _ViewModel_System_CalibrationAuxTemp = new ViewModel_System_CalibrationAuxTemp();
        ViewModel_System_CalibrationAuxTemp ViewModel_System_CalibrationAuxTemp { get { return _ViewModel_System_CalibrationAuxTemp; } set { _ViewModel_System_CalibrationAuxTemp = value; OnPropertyChanged("ViewModel_System_CalibrationAuxTemp"); } }
        ViewModel_System_CalibrationDet _ViewModel_System_CalibrationDet = new ViewModel_System_CalibrationDet();
        ViewModel_System_CalibrationDet ViewModel_System_CalibrationDet { get { return _ViewModel_System_CalibrationDet; } set { _ViewModel_System_CalibrationDet = value; OnPropertyChanged("ViewModel_System_CalibrationDet"); } }
        ViewModel_System_CalibrationInlet _ViewModel_System_CalibrationInlet = new ViewModel_System_CalibrationInlet();
        ViewModel_System_CalibrationInlet ViewModel_System_CalibrationInlet { get { return _ViewModel_System_CalibrationInlet; } set { _ViewModel_System_CalibrationInlet = value; OnPropertyChanged("ViewModel_System_CalibrationInlet"); } }
        ViewModel_System_CalibrationOven _ViewModel_System_CalibrationOven = new ViewModel_System_CalibrationOven();
        ViewModel_System_CalibrationOven ViewModel_System_CalibrationOven { get { return _ViewModel_System_CalibrationOven; } set { _ViewModel_System_CalibrationOven = value; OnPropertyChanged("ViewModel_System_CalibrationOven"); } }
        ViewModel_System_CalibrationUPC _ViewModel_System_CalibrationUPC = new ViewModel_System_CalibrationUPC();
        ViewModel_System_CalibrationUPC ViewModel_System_CalibrationUPC { get { return _ViewModel_System_CalibrationUPC; } set { _ViewModel_System_CalibrationUPC = value; OnPropertyChanged("ViewModel_System_CalibrationUPC"); } }
        ViewModel_System_Config _ViewModel_System_Config = new ViewModel_System_Config();
        ViewModel_System_Config ViewModel_System_Config { get { return _ViewModel_System_Config; } set { _ViewModel_System_Config = value; OnPropertyChanged("ViewModel_System_Config"); } }
        ViewModel_System_Diagnostics _ViewModel_System_Diagnostics = new ViewModel_System_Diagnostics();
        ViewModel_System_Diagnostics ViewModel_System_Diagnostics { get { return _ViewModel_System_Diagnostics; } set { _ViewModel_System_Diagnostics = value; OnPropertyChanged("ViewModel_System_Diagnostics"); } }
        ViewModel_System_DiagnosticsHeater _ViewModel_System_DiagnosticsHeater = new ViewModel_System_DiagnosticsHeater();
        ViewModel_System_DiagnosticsHeater ViewModel_System_DiagnosticsHeater { get { return _ViewModel_System_DiagnosticsHeater; } set { _ViewModel_System_DiagnosticsHeater = value; OnPropertyChanged("ViewModel_System_DiagnosticsHeater"); } }
        ViewModel_System_DiagnosticsIgnitorAndValve _ViewModel_System_DiagnosticsIgnitorAndValve = new ViewModel_System_DiagnosticsIgnitorAndValve();
        ViewModel_System_DiagnosticsIgnitorAndValve ViewModel_System_DiagnosticsIgnitorAndValve { get { return _ViewModel_System_DiagnosticsIgnitorAndValve; } set { _ViewModel_System_DiagnosticsIgnitorAndValve = value; OnPropertyChanged("ViewModel_System_DiagnosticsIgnitorAndValve"); } }
        ViewModel_System_DiagnosticsPowerMonitor _ViewModel_System_DiagnosticsPowerMonitor = new ViewModel_System_DiagnosticsPowerMonitor();
        ViewModel_System_DiagnosticsPowerMonitor ViewModel_System_DiagnosticsPowerMonitor { get { return _ViewModel_System_DiagnosticsPowerMonitor; } set { _ViewModel_System_DiagnosticsPowerMonitor = value; OnPropertyChanged("ViewModel_System_DiagnosticsPowerMonitor"); } }
        ViewModel_System_DiagnosticsRemoteSignal _ViewModel_System_DiagnosticsRemoteSignal = new ViewModel_System_DiagnosticsRemoteSignal();
        ViewModel_System_DiagnosticsRemoteSignal ViewModel_System_DiagnosticsRemoteSignal { get { return _ViewModel_System_DiagnosticsRemoteSignal; } set { _ViewModel_System_DiagnosticsRemoteSignal = value; OnPropertyChanged("ViewModel_System_DiagnosticsRemoteSignal"); } }
        ViewModel_System_DiagnosticsUpcSensorCheck _ViewModel_System_DiagnosticsUpcSensorCheck = new ViewModel_System_DiagnosticsUpcSensorCheck();
        ViewModel_System_DiagnosticsUpcSensorCheck ViewModel_System_DiagnosticsUpcSensorCheck { get { return _ViewModel_System_DiagnosticsUpcSensorCheck; } set { _ViewModel_System_DiagnosticsUpcSensorCheck = value; OnPropertyChanged("ViewModel_System_DiagnosticsUpcSensorCheck"); } }
        ViewModel_System_DiagnosticsUpcValveCheck _ViewModel_System_DiagnosticsUpcValveCheck = new ViewModel_System_DiagnosticsUpcValveCheck();
        ViewModel_System_DiagnosticsUpcValveCheck ViewModel_System_DiagnosticsUpcValveCheck { get { return _ViewModel_System_DiagnosticsUpcValveCheck; } set { _ViewModel_System_DiagnosticsUpcValveCheck = value; OnPropertyChanged("ViewModel_System_DiagnosticsUpcValveCheck"); } }
        ViewModel_System_Information _ViewModel_System_Information = new ViewModel_System_Information();
        ViewModel_System_Information ViewModel_System_Information { get { return _ViewModel_System_Information; } set { _ViewModel_System_Information = value; OnPropertyChanged("ViewModel_System_Information"); } }
        ViewModel_System_Method _ViewModel_System_Method = new ViewModel_System_Method();
        ViewModel_System_Method ViewModel_System_Method { get { return _ViewModel_System_Method; } set { _ViewModel_System_Method = value; OnPropertyChanged("ViewModel_System_Method"); } }
        ViewModel_System_Settings _ViewModel_System_Settings = new ViewModel_System_Settings();
        ViewModel_System_Settings ViewModel_System_Settings { get { return _ViewModel_System_Settings; } set { _ViewModel_System_Settings = value; OnPropertyChanged("ViewModel_System_Settings"); } }
        ViewModel_System_TimeControl _ViewModel_System_TimeControl = new ViewModel_System_TimeControl();
        ViewModel_System_TimeControl ViewModel_System_TimeControl { get { return _ViewModel_System_TimeControl; } set { _ViewModel_System_TimeControl = value; OnPropertyChanged("ViewModel_System_TimeControl"); } }

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
