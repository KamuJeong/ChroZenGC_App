using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsHeater : Model_System_Diagnostics
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsHeater()
        {
            StartStopCommand = new RelayCommand(StartStopCommandAction);
            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        string _fOven;

        /// <summary>
        /// Oven Temp
        /// </summary>
        public string fOven { get { return _fOven; } set { _fOven = value; OnPropertyChanged("fOven"); } }

        string _fInj_1;

        /// <summary>
        /// Inlet Front ~ Rear Temp
        /// </summary>
        public string fInj_1 { get { return _fInj_1; } set { _fInj_1 = value; OnPropertyChanged("fInj_1"); } }

        string _fInj_2;

        /// <summary>
        /// Inlet Front ~ Rear Temp
        /// </summary>
        public string fInj_2 { get { return _fInj_2; } set { _fInj_2 = value; OnPropertyChanged("fInj_2"); } }

        string _fInj_3;

        /// <summary>
        /// Inlet Front ~ Rear Temp
        /// </summary>
        public string fInj_3 { get { return _fInj_3; } set { _fInj_3 = value; OnPropertyChanged("fInj_3"); } }

        string _fDet_1;

        /// <summary>
        /// Det Front ~ Rear Temp
        /// </summary>
        public string fDet_1 { get { return _fDet_1; } set { _fDet_1 = value; OnPropertyChanged("fDet_1"); } }

        string _fDet_2;

        /// <summary>
        /// Det Front ~ Rear Temp
        /// </summary>
        public string fDet_2 { get { return _fDet_2; } set { _fDet_2 = value; OnPropertyChanged("fDet_2"); } }

        string _fDet_3;

        /// <summary>
        /// Det Front ~ Rear Temp
        /// </summary>
        public string fDet_3 { get { return _fDet_3; } set { _fDet_3 = value; OnPropertyChanged("fDet_3"); } }

        string _fAux_1;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_1 { get { return _fAux_1; } set { _fAux_1 = value; OnPropertyChanged("fAux_1"); } }

        string _fAux_2;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_2 { get { return _fAux_2; } set { _fAux_2 = value; OnPropertyChanged("fAux_2"); } }

        string _fAux_3;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_3 { get { return _fAux_3; } set { _fAux_3 = value; OnPropertyChanged("fAux_3"); } }

        string _fAux_4;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_4 { get { return _fAux_4; } set { _fAux_4 = value; OnPropertyChanged("fAux_4"); } }

        string _fAux_5;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_5 { get { return _fAux_5; } set { _fAux_5 = value; OnPropertyChanged("fAux_5"); } }

        string _fAux_6;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_6 { get { return _fAux_6; } set { _fAux_6 = value; OnPropertyChanged("fAux_6"); } }

        string _fAux_7;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_7 { get { return _fAux_7; } set { _fAux_7 = value; OnPropertyChanged("fAux_7"); } }

        string _fAux_8;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public string fAux_8 { get { return _fAux_8; } set { _fAux_8 = value; OnPropertyChanged("fAux_8"); } }

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
