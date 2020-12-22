using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_AuxTemperature : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_AuxTemperature()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        float[] _fTempSet = new float[ChroZenService_Const.AUX_CNT];
        public float[] fTempSet { get { return _fTempSet; } set { _fTempSet = value; OnPropertyChanged("fTempSet"); } }

        byte[] _fTempOnoff = new byte[ChroZenService_Const.AUX_CNT];
        public byte[] fTempOnoff { get { return _fTempOnoff; } set { _fTempOnoff = value; OnPropertyChanged("fTempOnoff"); } }

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
