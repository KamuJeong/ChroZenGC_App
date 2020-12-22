using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_Signal : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_Signal()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        public int nSignalIndex;

        float _fZero;
        public float fZero { get { return _fZero; } set { _fZero = value; OnPropertyChanged("fZero"); } }

        float _fSensitivity;
        public float fSensitivity { get { return _fSensitivity; } set { _fSensitivity = value; OnPropertyChanged("fSensitivity"); } }

        byte _bSignalChange;
        public byte bSignalChange { get { return _bSignalChange; } set { _bSignalChange = value; OnPropertyChanged("bSignalChange"); } }


        ObservableCollection<ViewModel_Config_Signal_Program> _Prgm = new ObservableCollection<ViewModel_Config_Signal_Program>(new ViewModel_Config_Signal_Program[ChroZenService_Const.SIGNAL_PRGM_CNT]);
        public ObservableCollection<ViewModel_Config_Signal_Program> Prgm { get { return _Prgm; } set { _Prgm = value; OnPropertyChanged("Prgm"); } }

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
