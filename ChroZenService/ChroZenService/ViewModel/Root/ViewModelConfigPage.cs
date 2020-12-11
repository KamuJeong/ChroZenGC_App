using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModelConfigPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelConfigPage()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ViewModel_Config_AuxFlow _ViewModel_Config_AuxFlow = new ViewModel_Config_AuxFlow();
        ViewModel_Config_AuxFlow ViewModel_Config_AuxFlow { get { return _ViewModel_Config_AuxFlow; } set { _ViewModel_Config_AuxFlow = value; OnPropertyChanged("ViewModel_Config_AuxFlow"); } }
        ViewModel_Config_AuxTemperature _ViewModel_Config_AuxTemperature = new ViewModel_Config_AuxTemperature();
        ViewModel_Config_AuxTemperature ViewModel_Config_AuxTemperature { get { return _ViewModel_Config_AuxTemperature; } set { _ViewModel_Config_AuxTemperature = value; OnPropertyChanged("ViewModel_Config_AuxTemperature"); } }
        ViewModel_Config_DetConfig _ViewModel_Config_DetConfig = new ViewModel_Config_DetConfig();
        ViewModel_Config_DetConfig ViewModel_Config_DetConfig { get { return _ViewModel_Config_DetConfig; } set { _ViewModel_Config_DetConfig = value; OnPropertyChanged("ViewModel_Config_DetConfig"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_DetSettings = new ViewModel_Config_DetSettings();
        ViewModel_Config_DetSettings ViewModel_Config_DetSettings { get { return _ViewModel_Config_DetSettings; } set { _ViewModel_Config_DetSettings = value; OnPropertyChanged("ViewModel_Config_DetSettings"); } }
        ViewModel_Config_InletConfig _ViewModel_Config_InletConfig = new ViewModel_Config_InletConfig();
        ViewModel_Config_InletConfig ViewModel_Config_InletConfig { get { return _ViewModel_Config_InletConfig; } set { _ViewModel_Config_InletConfig = value; OnPropertyChanged("ViewModel_Config_InletConfig"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_InletSettings = new ViewModel_Config_InletSettings();
        ViewModel_Config_InletSettings ViewModel_Config_InletSettings { get { return _ViewModel_Config_InletSettings; } set { _ViewModel_Config_InletSettings = value; OnPropertyChanged("ViewModel_Config_InletSettings"); } }
        ViewModel_Config_OvenConfig _ViewModel_Config_OvenConfig = new ViewModel_Config_OvenConfig();
        ViewModel_Config_OvenConfig ViewModel_Config_OvenConfig { get { return _ViewModel_Config_OvenConfig; } set { _ViewModel_Config_OvenConfig = value; OnPropertyChanged("ViewModel_Config_OvenConfig"); } }
        ViewModel_Config_OvenSettings _ViewModel_Config_OvenSettings = new ViewModel_Config_OvenSettings();
        ViewModel_Config_OvenSettings ViewModel_Config_OvenSettings { get { return _ViewModel_Config_OvenSettings; } set { _ViewModel_Config_OvenSettings = value; OnPropertyChanged("ViewModel_Config_OvenSettings"); } }
        ViewModel_Config_Signal _ViewModel_Config_Signal = new ViewModel_Config_Signal();
        ViewModel_Config_Signal ViewModel_Config_Signal { get { return _ViewModel_Config_Signal; } set { _ViewModel_Config_Signal = value; OnPropertyChanged("ViewModel_Config_Signal"); } }
        ViewModel_Config_ValveInitialState _ViewModel_Config_ValveInitialState = new ViewModel_Config_ValveInitialState();
        ViewModel_Config_ValveInitialState ViewModel_Config_ValveInitialState { get { return _ViewModel_Config_ValveInitialState; } set { _ViewModel_Config_ValveInitialState = value; OnPropertyChanged("ViewModel_Config_ValveInitialState"); } }
        ViewModel_Config_ValveProgram _ViewModel_Config_ValveProgram = new ViewModel_Config_ValveProgram();
        ViewModel_Config_ValveProgram ViewModel_Config_ValveProgram { get { return _ViewModel_Config_ValveProgram; } set { _ViewModel_Config_ValveProgram = value; OnPropertyChanged("ViewModel_Config_ValveProgram"); } }

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
