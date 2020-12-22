using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_OvenSettings : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_OvenSettings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        float _ActualTemperature;
        public float ActualTemperature { get { return _ActualTemperature; } set { _ActualTemperature = value; OnPropertyChanged("ActualTemperature"); } }

        float _fTempSet;
        public float fTempSet { get { return _fTempSet; } set { _fTempSet = value; OnPropertyChanged("fTempSet"); } }

        bool _bTempOnoff;
        public bool bTempOnoff { get { return _bTempOnoff; } set { _bTempOnoff = value; OnPropertyChanged("bTempOnoff"); } }

        float _fMaxTemp;
        public float fMaxTemp { get { return _fMaxTemp; } set { _fMaxTemp = value; OnPropertyChanged("fMaxTemp"); } }

        float _fInitTime;
        public float fInitTime { get { return _fInitTime; } set { _fInitTime = value; OnPropertyChanged("fInitTime"); } }

        bool _btMode;
        public bool btMode { get { return _btMode; } set { _btMode = value; OnPropertyChanged("btMode"); } }

        ObservableCollection<ViewModel_Config_OvenSettings_Program> _OC_ViewModel_Config_OvenSettings_Program = new ObservableCollection<ViewModel_Config_OvenSettings_Program>(new ViewModel_Config_OvenSettings_Program[ChroZenService_Const.OVEN_PRGM_CNT]);
        public ObservableCollection<ViewModel_Config_OvenSettings_Program> OC_ViewModel_Config_OvenSettings_Program
        {
            get { return _OC_ViewModel_Config_OvenSettings_Program; }
            set
            {
                _OC_ViewModel_Config_OvenSettings_Program = value;
                OnPropertyChanged("OC_ViewModel_Config_OvenSettings_Program");
            }
        }

        #endregion Property

        #region Command

        #region DefaultCommand
        public RelayCommand DefaultCommand { get; set; }
        private void DefaultCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("DefaultCommand Fired");
        }
        #endregion DefaultCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
