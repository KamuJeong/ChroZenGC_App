using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;

namespace ChroZenService
{
    public class ViewModel_MainTop : BindableNotifyBase
    {
        Timer t;

        string _DeviceRuntimeCurrent;
        public string DeviceRuntimeCurrent { get { return _DeviceRuntimeCurrent; } set { if (_DeviceRuntimeCurrent != value) { _DeviceRuntimeCurrent = value; OnPropertyChanged("DeviceRuntimeCurrent"); } } }

        string _DeviceRuntimeTotal;
        public string DeviceRuntimeTotal { get { return _DeviceRuntimeTotal; } set { if (_DeviceRuntimeTotal != value) { _DeviceRuntimeTotal = value; OnPropertyChanged("DeviceRuntimeTotal"); } } }

        string _DeviceRunStartCurrent;
        public string DeviceRunStartCurrent { get { return _DeviceRunStartCurrent; } set { if (_DeviceRunStartCurrent != value) { _DeviceRunStartCurrent = value; OnPropertyChanged("DeviceRunStartCurrent"); } } }

        string _DeviceRunStartTotal;
        public string DeviceRunStartTotal { get { return _DeviceRunStartTotal; } set { if (_DeviceRunStartTotal != value) { _DeviceRunStartTotal = value; OnPropertyChanged("DeviceRunStartTotal"); } } }

        string _CurrentTime;
        public string CurrentTime { get { return _CurrentTime; } set { if (_CurrentTime != value) { _CurrentTime = value; OnPropertyChanged("CurrentTime"); } } }

        private string _CHROZEN_GC_STATE_String;
        public string CHROZEN_GC_STATE_String
        {
            get { return _CHROZEN_GC_STATE_String; }
            set
            {
                if (_CHROZEN_GC_STATE_String != value)
                {
                    _CHROZEN_GC_STATE_String = value;
                    OnPropertyChanged("CHROZEN_GC_STATE_String");
                }
            }
        }

        private string _CHROZEN_GC_CONNECTION_STATE_String;
        public string CHROZEN_GC_CONNECTION_STATE_String
        {
            get { return _CHROZEN_GC_CONNECTION_STATE_String; }
            set
            {
                if (_CHROZEN_GC_CONNECTION_STATE_String != value)
                {
                    _CHROZEN_GC_CONNECTION_STATE_String = value;
                    OnPropertyChanged("CHROZEN_GC_CONNECTION_STATE_String");
                }
            }
        }
        Color _ConnectedColorBrush = Color.Gray;
        public Color ConnectedColorBrush { get { return _ConnectedColorBrush; } set { if (_ConnectedColorBrush != value) { _ConnectedColorBrush = value; OnPropertyChanged("ConnectedColorBrush"); } } }

        public Color CalibrationColorBrush = Color.Yellow;

        public Color ReadyColorBrush = Color.Yellow;

        public Color NotReadyColorBrush = Color.Gray;

        public Color RunColorBrush = Color.Cyan;

        public Color DiagnosticColorBrush = Color.Cyan;

        public Color ErrorColorBrush = Color.Red;

        Color _StateColorBrush = Color.Gray;
        public Color StateColorBrush { get { return _StateColorBrush; } set { if (_StateColorBrush != value) { _StateColorBrush = value; OnPropertyChanged("StateColorBrush"); } } }

        public ViewModel_MainTop()
        {
            EventManager.onConnectSuccess += onConnectSuccessEventHandler;
            EventManager.onDisconnected += onDisconnectedEventHandler;
            t = new Timer(TimerUpdated, null, 0, 1000);
        }
        ~ViewModel_MainTop()
        {
            t.Dispose();
        }

        private void TimerUpdated(object state)
        {
            CurrentTime = DateTime.Now.ToString("hhh:mm:ss");
        }

        private void onDisconnectedEventHandler()
        {
            CHROZEN_GC_CONNECTION_STATE_String = "Disconnected";
            ConnectedColorBrush = ErrorColorBrush;
        }

        private void onConnectSuccessEventHandler()
        {
            CHROZEN_GC_CONNECTION_STATE_String = "Connected";
            ConnectedColorBrush = RunColorBrush;
        }
    }
}
