using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_Signal_Program : BindableNotifyBase
    {
        float _fTime;
        public float fTime { get { return _fTime; } set { _fTime = value; OnPropertyChanged("fTime"); } }

        byte _btDet;
        public byte btDet { get { return _btDet; } set { _btDet = value; OnPropertyChanged("btDet"); } }
    }
}
