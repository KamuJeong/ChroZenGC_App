using System;
using System.Collections.Generic;
using System.Text;
using YC_ChroZenGC_Type;

namespace ChroZenService
{
    public class ViewModel_MainCenter : BindableNotifyBase
    {
        string _OvenTemperature;
        public string OvenTemperature { get { return _OvenTemperature; } set { _OvenTemperature = value; OnPropertyChanged("OvenTemperature"); } }
        public ViewModel_MainCenter()
        {
            EventManager.onPACKCODE_Receivce += onPACKCODE_ReceiveEventHandler;
        }

        private void onPACKCODE_ReceiveEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet)
        {
            switch (e_LC_PACK_CODE)
            {
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                    {
                        OvenTemperature = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received.packet.ActTemp.fOven.ToString("F2");
                    }
                    break;
            }
        }
    }
}
