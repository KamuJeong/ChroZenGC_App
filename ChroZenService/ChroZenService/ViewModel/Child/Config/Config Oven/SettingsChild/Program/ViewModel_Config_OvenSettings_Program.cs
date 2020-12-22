using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_OvenSettings_Program : BindableNotifyBase
    {
        float _fRate;
        public float fRate { get { return _fRate; } set { _fRate = value; OnPropertyChanged("fRate"); } }
        float _fFinalTemp;
        public float fFinalTemp { get { return _fFinalTemp; } set { _fFinalTemp = value; OnPropertyChanged("fFinalTemp"); } }
        float _fFinalTime;
        public float fFinalTime { get { return _fFinalTime; } set { _fFinalTime = value; OnPropertyChanged("fFinalTime"); } }
    }
}
