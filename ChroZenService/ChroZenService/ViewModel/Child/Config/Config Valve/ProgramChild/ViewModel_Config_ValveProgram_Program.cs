using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_ValveProgram_Program : BindableNotifyBase
    {
        float _fTime;
        public float fTime { get { return _fTime; } set { _fTime = value; OnPropertyChanged("fTime"); } }

        byte _btNumber;
        public byte btNumber { get { return _btNumber; } set { _btNumber = value; OnPropertyChanged("btNumber"); } }

        byte _btState;
        public byte btState { get { return _btState; } set { _btState = value; OnPropertyChanged("btState"); } }
    }
}
