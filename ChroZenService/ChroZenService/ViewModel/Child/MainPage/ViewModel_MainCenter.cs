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

        string _SelectedInletTemperature;
        public string SelectedInletTemperature { get { return _SelectedInletTemperature; } set { _SelectedInletTemperature = value; OnPropertyChanged("SelectedInletTemperature"); } }

        string _SelectedDetTemperature;
        public string SelectedDetTemperature { get { return _SelectedDetTemperature; } set { _SelectedDetTemperature = value; OnPropertyChanged("SelectedDetTemperature"); } }

        string _Step;
        public string Step { get { return _Step; } set { _Step = value; OnPropertyChanged("Step"); } }

        
        public ViewModel_MainCenter()
        {
            
        }
    }
}
