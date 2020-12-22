using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Config_DetSettings : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_DetSettings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        E_DET_TYPE _e_DET_TYPE = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE e_DET_TYPE { get { return _e_DET_TYPE; } set { _e_DET_TYPE = value; OnPropertyChanged("e_DET_TYPE"); } }

        float fFlowSet1;
        float fFlowSet2;
        float fFlowSet3;

        bool bFlowOnoff1;
        bool bFlowOnoff2;
        bool bFlowOnoff3;

        float CurrentSignal;
        bool bElectrometer;//Discharge Module

        float ActualTemperature;
        float fTempSet;
        bool bTempOnoff;
        bool bAutoIgnition;
        float iBeadVoltageSet;//Sense

        #region TCD, uTCD

        bool iBeadVoltageOnoff;//Filament
        bool bPolarChange;//Polarity Change

        #endregion TCD, uTCD

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
