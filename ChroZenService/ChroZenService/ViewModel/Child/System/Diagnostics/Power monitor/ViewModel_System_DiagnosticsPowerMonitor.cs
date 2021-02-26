using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsPowerMonitor : Model_System_Diagnostics
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsPowerMonitor()
        {
            StartStopCommand = new RelayCommand(StartStopCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;
        string _MAIN_V50D;
        public string MAIN_V50D { get { return _MAIN_V50D; } set { if (_MAIN_V50D != value) { _MAIN_V50D = value; OnPropertyChanged("MAIN_V50D"); } } }

        string _MAIN_N50V;
        public string MAIN_N50V { get { return _MAIN_N50V; } set { if (_MAIN_N50V != value) { _MAIN_N50V = value; OnPropertyChanged("MAIN_N50V"); } } }

        string _MAIN_V12P;
        public string MAIN_V12P { get { return _MAIN_V12P; } set { if (_MAIN_V12P != value) { _MAIN_V12P = value; OnPropertyChanged("MAIN_V12P"); } } }

        string _MAIN_V24P;
        public string MAIN_V24P { get { return _MAIN_V24P; } set { if (_MAIN_V24P != value) { _MAIN_V24P = value; OnPropertyChanged("MAIN_V24P"); } } }

        string _APC_INJ_V25D_1;
        public string APC_INJ_V25D_1 { get { return _APC_INJ_V25D_1; } set { if (_APC_INJ_V25D_1 != value) { _APC_INJ_V25D_1 = value; OnPropertyChanged("APC_INJ_V25D_1"); } } }

        string _APC_INJ_V25D_2;
        public string APC_INJ_V25D_2 { get { return _APC_INJ_V25D_2; } set { if (_APC_INJ_V25D_2 != value) { _APC_INJ_V25D_2 = value; OnPropertyChanged("APC_INJ_V25D_2"); } } }

        string _APC_INJ_V25D_3;
        public string APC_INJ_V25D_3 { get { return _APC_INJ_V25D_3; } set { if (_APC_INJ_V25D_3 != value) { _APC_INJ_V25D_3 = value; OnPropertyChanged("APC_INJ_V25D_3"); } } }

        string _APC_INJ_V33D_1;
        public string APC_INJ_V33D_1 { get { return _APC_INJ_V33D_1; } set { if (_APC_INJ_V33D_1 != value) { _APC_INJ_V33D_1 = value; OnPropertyChanged("APC_INJ_V33D_1"); } } }

        string _APC_INJ_V33D_2;
        public string APC_INJ_V33D_2 { get { return _APC_INJ_V33D_2; } set { if (_APC_INJ_V33D_2 != value) { _APC_INJ_V33D_2 = value; OnPropertyChanged("APC_INJ_V33D_2"); } } }

        string _APC_INJ_V33D_3;
        public string APC_INJ_V33D_3 { get { return _APC_INJ_V33D_3; } set { if (_APC_INJ_V33D_3 != value) { _APC_INJ_V33D_3 = value; OnPropertyChanged("APC_INJ_V33D_3"); } } }

        string _APC_INJ_V50D_1;
        public string APC_INJ_V50D_1 { get { return _APC_INJ_V50D_1; } set { if (_APC_INJ_V50D_1 != value) { _APC_INJ_V50D_1 = value; OnPropertyChanged("APC_INJ_V50D_1"); } } }

        string _APC_INJ_V50D_2;
        public string APC_INJ_V50D_2 { get { return _APC_INJ_V50D_2; } set { if (_APC_INJ_V50D_2 != value) { _APC_INJ_V50D_2 = value; OnPropertyChanged("APC_INJ_V50D_2"); } } }

        string _APC_INJ_V50D_3;
        public string APC_INJ_V50D_3 { get { return _APC_INJ_V50D_3; } set { if (_APC_INJ_V50D_3 != value) { _APC_INJ_V50D_3 = value; OnPropertyChanged("APC_INJ_V50D_3"); } } }

        string _APC_INJ_V24_1;
        public string APC_INJ_V24_1 { get { return _APC_INJ_V24_1; } set { if (_APC_INJ_V24_1 != value) { _APC_INJ_V24_1 = value; OnPropertyChanged("APC_INJ_V24_1"); } } }

        string _APC_INJ_V24_2;
        public string APC_INJ_V24_2 { get { return _APC_INJ_V24_2; } set { if (_APC_INJ_V24_2 != value) { _APC_INJ_V24_2 = value; OnPropertyChanged("APC_INJ_V24_2"); } } }

        string _APC_INJ_V24_3;
        public string APC_INJ_V24_3 { get { return _APC_INJ_V24_3; } set { if (_APC_INJ_V24_3 != value) { _APC_INJ_V24_3 = value; OnPropertyChanged("APC_INJ_V24_3"); } } }

        string _APC_INJ_SEN1_1;
        public string APC_INJ_SEN1_1 { get { return _APC_INJ_SEN1_1; } set { if (_APC_INJ_SEN1_1 != value) { _APC_INJ_SEN1_1 = value; OnPropertyChanged("APC_INJ_SEN1_1"); } } }

        string _APC_INJ_SEN1_2;
        public string APC_INJ_SEN1_2 { get { return _APC_INJ_SEN1_2; } set { if (_APC_INJ_SEN1_2 != value) { _APC_INJ_SEN1_2 = value; OnPropertyChanged("APC_INJ_SEN1_2"); } } }

        string _APC_INJ_SEN1_3;
        public string APC_INJ_SEN1_3 { get { return _APC_INJ_SEN1_3; } set { if (_APC_INJ_SEN1_3 != value) { _APC_INJ_SEN1_3 = value; OnPropertyChanged("APC_INJ_SEN1_3"); } } }

        string _APC_INJ_SEN2_1;
        public string APC_INJ_SEN2_1 { get { return _APC_INJ_SEN2_1; } set { if (_APC_INJ_SEN2_1 != value) { _APC_INJ_SEN2_1 = value; OnPropertyChanged("APC_INJ_SEN2_1"); } } }

        string _APC_INJ_SEN2_2;
        public string APC_INJ_SEN2_2 { get { return _APC_INJ_SEN2_2; } set { if (_APC_INJ_SEN2_2 != value) { _APC_INJ_SEN2_2 = value; OnPropertyChanged("APC_INJ_SEN2_2"); } } }

        string _APC_INJ_SEN2_3;
        public string APC_INJ_SEN2_3 { get { return _APC_INJ_SEN2_3; } set { if (_APC_INJ_SEN2_3 != value) { _APC_INJ_SEN2_3 = value; OnPropertyChanged("APC_INJ_SEN2_3"); } } }

        string _APC_DET_V25D;
        public string APC_DET_V25D { get { return _APC_DET_V25D; } set { if (_APC_DET_V25D != value) { _APC_DET_V25D = value; OnPropertyChanged("APC_DET_V25D"); } } }

        string _APC_DET_V33D;
        public string APC_DET_V33D { get { return _APC_DET_V33D; } set { if (_APC_DET_V33D != value) { _APC_DET_V33D = value; OnPropertyChanged("APC_DET_V33D"); } } }

        string _APC_DET_SEN;
        public string APC_DET_SEN { get { return _APC_DET_SEN; } set { if (_APC_DET_SEN != value) { _APC_DET_SEN = value; OnPropertyChanged("APC_DET_SEN"); } } }

        string _APC_AUX_V25D;
        public string APC_AUX_V25D { get { return _APC_AUX_V25D; } set { if (_APC_AUX_V25D != value) { _APC_AUX_V25D = value; OnPropertyChanged("APC_AUX_V25D"); } } }

        string _APC_AUX_V33D;
        public string APC_AUX_V33D { get { return _APC_AUX_V33D; } set { if (_APC_AUX_V33D != value) { _APC_AUX_V33D = value; OnPropertyChanged("APC_AUX_V33D"); } } }

        string _APC_AUX_SEN;
        public string APC_AUX_SEN { get { return _APC_AUX_SEN; } set { if (_APC_AUX_SEN != value) { _APC_AUX_SEN = value; OnPropertyChanged("APC_AUX_SEN"); } } }

        #endregion Property

        #region Command

        #region StartStopCommand
        public RelayCommand StartStopCommand { get; set; }
        private void StartStopCommandAction(object param)
        {
            this.StartCommand((ChroZenService_Const.E_SYSTEM_DIAG_COMMAND_TYPE)param, tcpManager);
            //TODO :             
            Debug.WriteLine("StartStopCommand Fired");
        }
        #endregion StartStopCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
