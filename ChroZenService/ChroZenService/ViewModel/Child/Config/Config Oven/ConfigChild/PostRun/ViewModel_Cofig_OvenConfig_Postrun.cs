using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Cofig_OvenConfig_Postrun : BindableNotifyBase
    {
        bool _bOnoff;
        public bool bOnoff { get { return _bOnoff; } set { if (_bOnoff != value) { _bOnoff = value; OnPropertyChanged("bOnoff"); } } }

        float _fTemp;
        public float fTemp { get { return _fTemp; } set { if (_fTemp != value) { _fTemp = value; OnPropertyChanged("fTemp"); } } }

        float _fTime;
        public float fTime { get { return _fTime; } set { if (_fTime != value) { _fTime = value; OnPropertyChanged("fTime"); } } }
    }
}
