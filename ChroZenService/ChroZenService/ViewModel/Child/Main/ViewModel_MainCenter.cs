using System;
using System.Collections.Generic;
using System.Text;
using YC_ChroZenGC_Type;

namespace ChroZenService
{
    public class ViewModel_MainCenter : BindableNotifyBase
    {
        string _OvenTemperature;
        public string OvenTemperature { get { return _OvenTemperature; } set { if (_OvenTemperature != value) { if (_OvenTemperature != value) { _OvenTemperature = value; OnPropertyChanged("OvenTemperature"); } } } }

        string _SelectedInletTemperature;
        public string SelectedInletTemperature { get { return _SelectedInletTemperature; } set { if (_SelectedInletTemperature != value) { _SelectedInletTemperature = value;  OnPropertyChanged("SelectedInletTemperature"); } } }

        string _SelectedDetTemperature;
        public string SelectedDetTemperature { get { return _SelectedDetTemperature; } set { if (_SelectedDetTemperature != value) { _SelectedDetTemperature = value; OnPropertyChanged("SelectedDetTemperature"); } } }

        string _Step;
        public string Step { get { return _Step; } set { if (_Step != value) { _Step = value; OnPropertyChanged("Step"); } } }

        
        public ViewModel_MainCenter()
        {
            
        }
    }
}
