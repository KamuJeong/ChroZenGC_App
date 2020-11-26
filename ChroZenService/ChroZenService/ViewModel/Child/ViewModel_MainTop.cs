using System;
using System.Collections.Generic;
using System.Text;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;

namespace ChroZenService
{
    public class ViewModel_MainTop : BindableNotifyBase
    {
        private string _CHROZEN_GC_STATE_String;
        public string CHROZEN_GC_STATE_String
        {
            get { return _CHROZEN_GC_STATE_String; }
            set
            {
                _CHROZEN_GC_STATE_String = value;
                OnPropertyChanged("CHROZEN_GC_STATE_String");
            }
        }

        public ViewModel_MainTop()
        {
            EventManager.onConnectSuccess += onConnectSuccessEventHandler;
            EventManager.onDisconnected += onDisconnectedEventHandler;
        }

        private void onDisconnectedEventHandler()
        {
            CHROZEN_GC_STATE_String = "Disconnected";
        }

        private void onConnectSuccessEventHandler()
        {
            CHROZEN_GC_STATE_String = "Connected";
        }
    }
}
