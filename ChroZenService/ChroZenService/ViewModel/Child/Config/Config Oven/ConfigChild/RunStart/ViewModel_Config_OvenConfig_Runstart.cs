using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_OvenConfig_Runstart : BindableNotifyBase
    {
        bool _bOnoff;
        public bool bOnoff { get { return _bOnoff; } set { if (_bOnoff != value) { _bOnoff = value; OnPropertyChanged("bOnoff"); } } }

        ushort _iCount;
        public ushort iCount { get { return _iCount; } set { if (_iCount != value) { _iCount = value; OnPropertyChanged("iCount"); } } }

        float _fCycletime;
        public float fCycletime { get { return _fCycletime; } set { if (_fCycletime != value) { _fCycletime = value; OnPropertyChanged("fCycletime"); } } }
    }
}
