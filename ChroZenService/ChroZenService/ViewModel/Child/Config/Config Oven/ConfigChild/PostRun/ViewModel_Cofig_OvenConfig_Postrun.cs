using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Cofig_OvenConfig_Postrun : BindableNotifyBase
    {
        bool _bOnoff;
        public bool bOnoff { get { return _bOnoff; } set { _bOnoff = value; OnPropertyChanged("bOnoff"); } }

        float _fTemp;
        public float fTemp { get { return _fTemp; } set { _fTemp = value; OnPropertyChanged("fTemp"); } }

        float _fTime;
        public float fTime { get { return _fTime; } set { _fTime = value; OnPropertyChanged("fTime"); } }
    }
}
