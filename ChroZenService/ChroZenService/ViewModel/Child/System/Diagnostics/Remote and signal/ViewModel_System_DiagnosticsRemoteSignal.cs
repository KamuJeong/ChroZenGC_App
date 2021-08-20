using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    //public class ViewModel_System_DiagnosticsRemoteSignal : Model_System_Diagnostics
    //{
    //    #region 생성자 & 이벤트 헨들러

    //    public ViewModel_System_DiagnosticsRemoteSignal()
    //    {
    //        StartStopCommand = new RelayCommand(StartStopCommandAction);

    //        EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
    //    }

    //    #endregion 생성자 & 이벤트 헨들러

    //    #region Binding

    //    #region Property
    //    TCPManager tcpManager;
    //    bool _bIsStartOutOn;
    //    public bool bIsStartOutOn { get { return _bIsStartOutOn; } set { if (_bIsStartOutOn != value) { _bIsStartOutOn = value; OnPropertyChanged("bIsStartOutOn"); } } }

    //    bool _bIsReadyOutOn;
    //    public bool bIsReadyOutOn { get { return _bIsReadyOutOn; } set { if (_bIsReadyOutOn != value) { _bIsReadyOutOn = value; OnPropertyChanged("bIsReadyOutOn"); } } }

    //    string _SignalFront;
    //    public string SignalFront { get { return _SignalFront; } set { if (_SignalFront != value) { _SignalFront = value; OnPropertyChanged("SignalFront"); } } }

    //    string _SignalCenter;
    //    public string SignalCenter { get { return _SignalCenter; } set { if (_SignalCenter != value) { _SignalCenter = value; OnPropertyChanged("SignalCenter"); } } }

    //    string _SignalRear;
    //    public string SignalRear { get { return _SignalRear; } set { if (_SignalRear != value) { _SignalRear = value; OnPropertyChanged("SignalRear"); } } }

    //    string _StateLED;
    //    public string StateLED { get { return _StateLED; } set { if (_StateLED != value) { _StateLED = value; OnPropertyChanged("StateLED"); } } }

    //    string _LEDButton;
    //    public string LEDButton { get { return _LEDButton; } set { if (_LEDButton != value) { _LEDButton = value; OnPropertyChanged("LEDButton"); } } }

    //    #endregion Property

    //    #region Command

    //    #region StartStopCommand
    //    public RelayCommand StartStopCommand { get; set; }
    //    private void StartStopCommandAction(object param)
    //    {
    //        this.StartCommand((ChroZenService_Const.E_SYSTEM_DIAG_COMMAND_TYPE)param, tcpManager);
    //        //TODO :             
    //        Debug.WriteLine("StartStopCommand Fired");
    //    }
    //    #endregion StartStopCommand 

    //    #endregion Command

    //    #endregion Binding

    //    #region Instance Func

    //    #endregion Instance Func
    //}
}
