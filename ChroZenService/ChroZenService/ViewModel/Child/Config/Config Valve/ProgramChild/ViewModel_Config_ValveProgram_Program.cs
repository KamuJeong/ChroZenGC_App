using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_ValveProgram_Program : BindableNotifyBase
    {
        float _fTime;
        public float fTime { get { return _fTime; } set { if (_fTime != value) { _fTime = value; OnPropertyChanged("fTime"); } } }

        byte _btNumber;
        public byte btNumber { get { return _btNumber; } set { if (_btNumber != value) { _btNumber = value; OnPropertyChanged("btNumber"); } } }

        byte _btState;
        public byte btState { get { return _btState; } set { if (_btState != value) { _btState = value; OnPropertyChanged("btState"); } } }
    }
}
