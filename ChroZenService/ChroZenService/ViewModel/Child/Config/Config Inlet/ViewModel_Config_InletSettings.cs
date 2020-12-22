using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Config_InletSettings : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_InletSettings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        E_INLET_TYPE _e_INLET_TYPE = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE e_INLET_TYPE { get { return _e_INLET_TYPE; } set { _e_INLET_TYPE = value; OnPropertyChanged("e_INLET_TYPE"); } }

        float _fTempSet;
        public float fTempSet { get { return _fTempSet; } set { _fTempSet = value; OnPropertyChanged("fTempSet"); } }

        bool _fTempOnoff;
        public bool fTempOnoff { get { return fTempOnoff; } set { _fTempOnoff = value; OnPropertyChanged("fTempOnoff"); } }

        float _ActualTemperature;
        public float ActualTemperature { get { return _ActualTemperature; } set { _ActualTemperature = value; OnPropertyChanged("ActualTemperature"); } }

        bool _btInjMode;
        public bool btInjMode { get { return _btInjMode; } set { _btInjMode = value; OnPropertyChanged("btInjMode"); } }

        float _ActualColumnFlow;
        public float ActualColumnFlow { get { return _ActualColumnFlow; } set { _ActualColumnFlow = value; OnPropertyChanged("ActualColumnFlow"); } }

        float _ActualPressure;
        public float ActualPressure { get { return _ActualPressure; } set { _ActualPressure = value; OnPropertyChanged("ActualPressure"); } }

        float _ActualTotalFlow;
        public float ActualTotalFlow { get { return _ActualTotalFlow; } set { _ActualTotalFlow = value; OnPropertyChanged("ActualTotalFlow"); } }

        float _ActualSplitFlow;
        public float ActualSplitFlow { get { return _ActualSplitFlow; } set { _ActualSplitFlow = value; OnPropertyChanged("ActualSplitFlow"); } }

        float _ActualVelocity;
        public float ActualVelocity { get { return _ActualVelocity; } set { _ActualVelocity = value; OnPropertyChanged("ActualVelocity"); } }

        float _fColumnFlowSet;
        public float fColumnFlowSet { get { return _fColumnFlowSet; } set { _fColumnFlowSet = value; OnPropertyChanged("fColumnFlowSet"); } }

        bool _fColumnFlowOnoff;
        public bool fColumnFlowOnoff { get { return _fColumnFlowOnoff; } set { _fColumnFlowOnoff = value; OnPropertyChanged("fColumnFlowOnoff"); } }

        float _fPressureSet;
        public float fPressureSet { get { return _fPressureSet; } set { _fPressureSet = value; OnPropertyChanged("fPressureSet"); } }

        bool _fPressureOnoff;
        public bool fPressureOnoff { get { return _fPressureOnoff; } set { _fPressureOnoff = value; OnPropertyChanged("fPressureOnoff"); } }

        float _fTotalFlowSet;
        public float fTotalFlowSet { get { return _fTotalFlowSet; } set { _fTotalFlowSet = value; OnPropertyChanged("fTotalFlowSet"); } }

        bool _fTotalFlowOnoff;
        public bool fTotalFlowOnoff { get { return _fTotalFlowOnoff; } set { _fTotalFlowOnoff = value; OnPropertyChanged("fTotalFlowOnoff"); } }

        float _fSplitFlowSet;
        public float fSplitFlowSet { get { return _fSplitFlowSet; } set { _fSplitFlowSet = value; OnPropertyChanged("fSplitFlowSet"); } }

        short _iSplitratio;
        public short iSplitratio { get { return _iSplitratio; } set { _iSplitratio = value; OnPropertyChanged("iSplitratio"); } }

        float _fPulsed_FlowPressSet;
        public float fPulsed_FlowPressSet { get { return _fPulsed_FlowPressSet; } set { _fPulsed_FlowPressSet = value; OnPropertyChanged("fPulsed_FlowPressSet"); } }

        float _fSplitOnTime;
        public float fSplitOnTime { get { return _fSplitOnTime; } set { _fSplitOnTime = value; OnPropertyChanged("fSplitOnTime"); } }

        float _fPulsed_Time;
        public float fPulsed_Time { get { return _fPulsed_Time; } set { _fPulsed_Time = value; OnPropertyChanged("fPulsed_Time"); } }

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
