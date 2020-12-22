using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_OvenConfig_Runstart : BindableNotifyBase
    {
        byte _bOnoff;
        public byte bOnoff { get { return _bOnoff; } set { _bOnoff = value; OnPropertyChanged("bOnoff"); } }

        ushort _iCount;
        public ushort iCount { get { return _iCount; } set { _iCount = value; OnPropertyChanged("iCount"); } }

        float _fCycletime;
        public float fCycletime { get { return _fCycletime; } set { _fCycletime = value; OnPropertyChanged("fCycletime"); } }
    }
}
