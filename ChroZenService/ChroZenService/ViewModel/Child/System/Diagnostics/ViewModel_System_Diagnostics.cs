﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_System_Diagnostics : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Diagnostics()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        E_DIAGNOSTICS_TYPE _e_DIAGNOSTICS_TYPE = E_DIAGNOSTICS_TYPE.ROOT;
        public E_DIAGNOSTICS_TYPE e_DIAGNOSTICS_TYPE { get { return _e_DIAGNOSTICS_TYPE; } set { if (_e_DIAGNOSTICS_TYPE != value) { _e_DIAGNOSTICS_TYPE = value; OnPropertyChanged("e_DIAGNOSTICS_TYPE"); } } }

        ViewModel_System_DiagnosticsHeater _ViewModel_System_DiagnosticsHeater = new ViewModel_System_DiagnosticsHeater();
        public ViewModel_System_DiagnosticsHeater ViewModel_System_DiagnosticsHeater { get { return _ViewModel_System_DiagnosticsHeater; } set { if (_ViewModel_System_DiagnosticsHeater != value) { _ViewModel_System_DiagnosticsHeater = value; OnPropertyChanged("ViewModel_System_DiagnosticsHeater"); } } }
        ViewModel_System_DiagnosticsIgnitorAndValve _ViewModel_System_DiagnosticsIgnitorAndValve = new ViewModel_System_DiagnosticsIgnitorAndValve();
        public ViewModel_System_DiagnosticsIgnitorAndValve ViewModel_System_DiagnosticsIgnitorAndValve { get { return _ViewModel_System_DiagnosticsIgnitorAndValve; } set { if (_ViewModel_System_DiagnosticsIgnitorAndValve != value) { _ViewModel_System_DiagnosticsIgnitorAndValve = value; OnPropertyChanged("ViewModel_System_DiagnosticsIgnitorAndValve"); } } }
        ViewModel_System_DiagnosticsPowerMonitor _ViewModel_System_DiagnosticsPowerMonitor = new ViewModel_System_DiagnosticsPowerMonitor();
        public ViewModel_System_DiagnosticsPowerMonitor ViewModel_System_DiagnosticsPowerMonitor { get { return _ViewModel_System_DiagnosticsPowerMonitor; } set { if (_ViewModel_System_DiagnosticsPowerMonitor != value) { _ViewModel_System_DiagnosticsPowerMonitor = value; OnPropertyChanged("ViewModel_System_DiagnosticsPowerMonitor"); } } }
        ViewModel_System_DiagnosticsRemoteSignal _ViewModel_System_DiagnosticsRemoteSignal = new ViewModel_System_DiagnosticsRemoteSignal();
        public ViewModel_System_DiagnosticsRemoteSignal ViewModel_System_DiagnosticsRemoteSignal { get { return _ViewModel_System_DiagnosticsRemoteSignal; } set { if (_ViewModel_System_DiagnosticsRemoteSignal != value) { _ViewModel_System_DiagnosticsRemoteSignal = value; OnPropertyChanged("ViewModel_System_DiagnosticsRemoteSignal"); } } }
        ViewModel_System_DiagnosticsUpcSensorCheck _ViewModel_System_DiagnosticsUpcSensorCheck = new ViewModel_System_DiagnosticsUpcSensorCheck();
        public ViewModel_System_DiagnosticsUpcSensorCheck ViewModel_System_DiagnosticsUpcSensorCheck { get { return _ViewModel_System_DiagnosticsUpcSensorCheck; } set { if (_ViewModel_System_DiagnosticsUpcSensorCheck != value) { _ViewModel_System_DiagnosticsUpcSensorCheck = value; OnPropertyChanged("ViewModel_System_DiagnosticsUpcSensorCheck"); } } }
        ViewModel_System_DiagnosticsUpcValveCheck _ViewModel_System_DiagnosticsUpcValveCheck = new ViewModel_System_DiagnosticsUpcValveCheck();
        public ViewModel_System_DiagnosticsUpcValveCheck ViewModel_System_DiagnosticsUpcValveCheck { get { return _ViewModel_System_DiagnosticsUpcValveCheck; } set { if (_ViewModel_System_DiagnosticsUpcValveCheck != value) { _ViewModel_System_DiagnosticsUpcValveCheck = value; OnPropertyChanged("ViewModel_System_DiagnosticsUpcValveCheck"); } } }

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
