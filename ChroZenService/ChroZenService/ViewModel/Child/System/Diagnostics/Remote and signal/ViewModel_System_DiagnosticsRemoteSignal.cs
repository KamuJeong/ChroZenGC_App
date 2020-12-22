using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsRemoteSignal : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsRemoteSignal()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        bool _bIsStartOutOn;
        public bool bIsStartOutOn { get { return _bIsStartOutOn; } set { _bIsStartOutOn = value; OnPropertyChanged("bIsStartOutOn"); } }

        bool _bIsReadyOutOn;
        public bool bIsReadyOutOn { get { return _bIsReadyOutOn; } set { _bIsReadyOutOn = value; OnPropertyChanged("bIsReadyOutOn"); } }

        string _SignalFront;
        public string SignalFront { get { return _SignalFront; } set { _SignalFront = value; OnPropertyChanged("SignalFront"); } }

        string _SignalCenter;
        public string SignalCenter { get { return _SignalCenter; } set { _SignalCenter = value; OnPropertyChanged("SignalCenter"); } }

        string _SignalRear;
        public string SignalRear { get { return _SignalRear; } set { _SignalRear = value; OnPropertyChanged("SignalRear"); } }

        string _StateLED;
        public string StateLED { get { return _StateLED; } set { _StateLED = value; OnPropertyChanged("StateLED"); } }

        string _LEDButton;
        public string LEDButton { get { return _LEDButton; } set { _LEDButton = value; OnPropertyChanged("LEDButton"); } }

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
