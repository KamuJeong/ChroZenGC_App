using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsUpcSensorCheck : Model_System_Diagnostics
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsUpcSensorCheck()
        {
            StartStopCommand = new RelayCommand(StartStopCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        bool _IsFirstPageVisible;
        public bool IsFirstPageVisible { get { return _IsFirstPageVisible; } set { _IsFirstPageVisible = value; OnPropertyChanged("IsFirstPageVisible"); } }

        #region First page

        string _FrontInletSensor_1;
        public string FrontInletSensor_1 { get { return _FrontInletSensor_1; } set { _FrontInletSensor_1 = value; OnPropertyChanged("FrontInletSensor_1"); } }

        string _FrontInletSensor_2;
        public string FrontInletSensor_2 { get { return _FrontInletSensor_2; } set { _FrontInletSensor_2 = value; OnPropertyChanged("FrontInletSensor_2"); } }

        string _FrontInletSensor_3;
        public string FrontInletSensor_3 { get { return _FrontInletSensor_3; } set { _FrontInletSensor_3 = value; OnPropertyChanged("FrontInletSensor_3"); } }

        string _CenterInletSensor_1;
        public string CenterInletSensor_1 { get { return _CenterInletSensor_1; } set { _CenterInletSensor_1 = value; OnPropertyChanged("CenterInletSensor_1"); } }

        string _CenterInletSensor_2;
        public string CenterInletSensor_2 { get { return _CenterInletSensor_2; } set { _CenterInletSensor_2 = value; OnPropertyChanged("CenterInletSensor_2"); } }

        string _CenterInletSensor_3;
        public string CenterInletSensor_3 { get { return _CenterInletSensor_3; } set { _CenterInletSensor_3 = value; OnPropertyChanged("CenterInletSensor_3"); } }

        string _RearInletSensor_1;
        public string RearInletSensor_1 { get { return _RearInletSensor_1; } set { _RearInletSensor_1 = value; OnPropertyChanged("RearInletSensor_1"); } }

        string _RearInletSensor_2;
        public string RearInletSensor_2 { get { return _RearInletSensor_2; } set { _RearInletSensor_2 = value; OnPropertyChanged("RearInletSensor_2"); } }

        string _RearInletSensor_3;
        public string RearInletSensor_3 { get { return _RearInletSensor_3; } set { _RearInletSensor_3 = value; OnPropertyChanged("RearInletSensor_3"); } }

        string _FrontDetSensor_1;
        public string FrontDetSensor_1 { get { return _FrontDetSensor_1; } set { _FrontDetSensor_1 = value; OnPropertyChanged("FrontDetSensor_1"); } }

        string _FrontDetSensor_2;
        public string FrontDetSensor_2 { get { return _FrontDetSensor_2; } set { _FrontDetSensor_2 = value; OnPropertyChanged("FrontDetSensor_2"); } }

        string _FrontDetSensor_3;
        public string FrontDetSensor_3 { get { return _FrontDetSensor_3; } set { _FrontDetSensor_3 = value; OnPropertyChanged("FrontDetSensor_3"); } }

        string _CenterDetSensor_1;
        public string CenterDetSensor_1 { get { return _CenterDetSensor_1; } set { _CenterDetSensor_1 = value; OnPropertyChanged("CenterDetSensor_1"); } }

        string _CenterDetSensor_2;
        public string CenterDetSensor_2 { get { return _CenterDetSensor_2; } set { _CenterDetSensor_2 = value; OnPropertyChanged("CenterDetSensor_2"); } }

        string _CenterDetSensor_3;
        public string CenterDetSensor_3 { get { return _CenterDetSensor_3; } set { _CenterDetSensor_3 = value; OnPropertyChanged("CenterDetSensor_3"); } }

        #endregion First page

        #region Second page

        string _RearDetSensor_1;
        public string RearDetSensor_1 { get { return _RearDetSensor_1; } set { _RearDetSensor_1 = value; OnPropertyChanged("RearDetSensor_1"); } }

        string _RearDetSensor_2;
        public string RearDetSensor_2 { get { return _RearDetSensor_2; } set { _RearDetSensor_2 = value; OnPropertyChanged("RearDetSensor_2"); } }

        string _RearDetSensor_3;
        public string RearDetSensor_3 { get { return _RearDetSensor_3; } set { _RearDetSensor_3 = value; OnPropertyChanged("RearDetSensor_3"); } }

        string _FrontAuxAPCSensor_1;
        public string FrontAuxAPCSensor_1 { get { return _FrontAuxAPCSensor_1; } set { _FrontAuxAPCSensor_1 = value; OnPropertyChanged("FrontAuxAPCSensor_1"); } }

        string _FrontAuxAPCSensor_2;
        public string FrontAuxAPCSensor_2 { get { return _FrontAuxAPCSensor_2; } set { _FrontAuxAPCSensor_2 = value; OnPropertyChanged("FrontAuxAPCSensor_2"); } }

        string _FrontAuxAPCSensor_3;
        public string FrontAuxAPCSensor_3 { get { return _FrontAuxAPCSensor_3; } set { _FrontAuxAPCSensor_3 = value; OnPropertyChanged("FrontAuxAPCSensor_3"); } }

        string _CenterAuxAPCSensor_1;
        public string CenterAuxAPCSensor_1 { get { return _CenterAuxAPCSensor_1; } set { _CenterAuxAPCSensor_1 = value; OnPropertyChanged("CenterAuxAPCSensor_1"); } }

        string _CenterAuxAPCSensor_2;
        public string CenterAuxAPCSensor_2 { get { return _CenterAuxAPCSensor_2; } set { _CenterAuxAPCSensor_2 = value; OnPropertyChanged("CenterAuxAPCSensor_2"); } }

        string _CenterAuxAPCSensor_3;
        public string CenterAuxAPCSensor_3 { get { return _CenterAuxAPCSensor_3; } set { _CenterAuxAPCSensor_3 = value; OnPropertyChanged("CenterAuxAPCSensor_3"); } }

        string _RearAuxAPCSensor_1;
        public string RearAuxAPCSensor_1 { get { return _RearAuxAPCSensor_1; } set { _RearAuxAPCSensor_1 = value; OnPropertyChanged("RearAuxAPCSensor_1"); } }

        string _RearAuxAPCSensor_2;
        public string RearAuxAPCSensor_2 { get { return _RearAuxAPCSensor_2; } set { _RearAuxAPCSensor_2 = value; OnPropertyChanged("RearAuxAPCSensor_2"); } }

        string _RearAuxAPCSensor_3;
        public string RearAuxAPCSensor_3 { get { return _RearAuxAPCSensor_3; } set { _RearAuxAPCSensor_3 = value; OnPropertyChanged("RearAuxAPCSensor_3"); } }

        #endregion Second page
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
