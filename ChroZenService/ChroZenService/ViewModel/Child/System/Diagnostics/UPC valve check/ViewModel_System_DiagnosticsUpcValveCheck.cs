using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsUpcValveCheck : Model_System_Diagnostics
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsUpcValveCheck()
        {
            StartStopCommand = new RelayCommand(StartStopCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;
        string _FrontInletValve;
        public string FrontInletValve { get { return _FrontInletValve; } set { _FrontInletValve = value; OnPropertyChanged("FrontInletValve"); } }

        string _CenterInletValve;
        public string CenterInletValve { get { return _CenterInletValve; } set { _CenterInletValve = value; OnPropertyChanged("CenterInletValve"); } }

        string _RearInletValve;
        public string RearInletValve { get { return _RearInletValve; } set { _RearInletValve = value; OnPropertyChanged("RearInletValve"); } }

        string _FrontDetValve;
        public string FrontDetValve { get { return _FrontDetValve; } set { _FrontDetValve = value; OnPropertyChanged("FrontDetValve"); } }

        string _CenterDetValve;
        public string CenterDetValve { get { return _CenterDetValve; } set { _CenterDetValve = value; OnPropertyChanged("CenterDetValve"); } }

        string _RearDetValve;
        public string RearDetValve { get { return _RearDetValve; } set { _RearDetValve = value; OnPropertyChanged("RearDetValve"); } }

        string _FrontAuxAPCValve;
        public string FrontAuxAPCValve { get { return _FrontAuxAPCValve; } set { _FrontAuxAPCValve = value; OnPropertyChanged("FrontAuxAPCValve"); } }

        string _CenterAuxAPCValve;
        public string CenterAuxAPCValve { get { return _CenterAuxAPCValve; } set { _CenterAuxAPCValve = value; OnPropertyChanged("CenterAuxAPCValve"); } }

        string _RearAuxAPCValve;
        public string RearAuxAPCValve { get { return _RearAuxAPCValve; } set { _RearAuxAPCValve = value; OnPropertyChanged("RearAuxAPCValve"); } }


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
