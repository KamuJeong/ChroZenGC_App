using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModelConfigPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelConfigPage()
        {
            MenuSelectCommand = new RelayCommand(MenuSelectCommandAction);
            SubMenuSelectCommand = new RelayCommand(SubMenuSelectCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        #region Oven
        ViewModel_Config_OvenConfig _ViewModel_Config_OvenConfig = new ViewModel_Config_OvenConfig();
        public ViewModel_Config_OvenConfig ViewModel_Config_OvenConfig { get { return _ViewModel_Config_OvenConfig; } set { _ViewModel_Config_OvenConfig = value; OnPropertyChanged("ViewModel_Config_OvenConfig"); } }
        ViewModel_Config_OvenSettings _ViewModel_Config_OvenSettings = new ViewModel_Config_OvenSettings();
        public ViewModel_Config_OvenSettings ViewModel_Config_OvenSettings { get { return _ViewModel_Config_OvenSettings; } set { _ViewModel_Config_OvenSettings = value; OnPropertyChanged("ViewModel_Config_OvenSettings"); } }
        #endregion Oven

        #region Inlet
        ViewModel_Config_InletConfig _ViewModel_Config_FrontInletConfig = new ViewModel_Config_InletConfig();
        public ViewModel_Config_InletConfig ViewModel_Config_FrontInletConfig { get { return _ViewModel_Config_FrontInletConfig; } set { _ViewModel_Config_FrontInletConfig = value; OnPropertyChanged("ViewModel_Config_FrontInletConfig"); } }
        ViewModel_Config_InletConfig _ViewModel_Config_CenterInletConfig = new ViewModel_Config_InletConfig();
        public ViewModel_Config_InletConfig ViewModel_Config_CenterInletConfig { get { return _ViewModel_Config_CenterInletConfig; } set { _ViewModel_Config_CenterInletConfig = value; OnPropertyChanged("ViewModel_Config_CenterInletConfig"); } }
        ViewModel_Config_InletConfig _ViewModel_Config_RearInletConfig = new ViewModel_Config_InletConfig();
        public ViewModel_Config_InletConfig ViewModel_Config_RearInletConfig { get { return _ViewModel_Config_RearInletConfig; } set { _ViewModel_Config_RearInletConfig = value; OnPropertyChanged("ViewModel_Config_RearInletConfig"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_FrontInletSettings = new ViewModel_Config_InletSettings();
        public ViewModel_Config_InletSettings ViewModel_Config_FrontInletSettings { get { return _ViewModel_Config_FrontInletSettings; } set { _ViewModel_Config_FrontInletSettings = value; OnPropertyChanged("ViewModel_Config_FrontInletSettings"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_CenterInletSettings = new ViewModel_Config_InletSettings();
        public ViewModel_Config_InletSettings ViewModel_Config_CenterInletSettings { get { return _ViewModel_Config_CenterInletSettings; } set { _ViewModel_Config_CenterInletSettings = value; OnPropertyChanged("ViewModel_Config_CenterInletSettings"); } }
        ViewModel_Config_InletSettings _ViewModel_Config_RearInletSettings = new ViewModel_Config_InletSettings();
        public ViewModel_Config_InletSettings ViewModel_Config_RearInletSettings { get { return _ViewModel_Config_RearInletSettings; } set { _ViewModel_Config_RearInletSettings = value; OnPropertyChanged("ViewModel_Config_RearInletSettings"); } }
        #endregion Inlet

        #region Detector
        ViewModel_Config_DetConfig _ViewModel_Config_FrontDetConfig = new ViewModel_Config_DetConfig();
        public ViewModel_Config_DetConfig ViewModel_Config_FrontDetConfig { get { return _ViewModel_Config_FrontDetConfig; } set { _ViewModel_Config_FrontDetConfig = value; OnPropertyChanged("ViewModel_Config_FrontDetConfig"); } }
        ViewModel_Config_DetConfig _ViewModel_Config_CenterDetConfig = new ViewModel_Config_DetConfig();
        public ViewModel_Config_DetConfig ViewModel_Config_CenterDetConfig { get { return _ViewModel_Config_CenterDetConfig; } set { _ViewModel_Config_CenterDetConfig = value; OnPropertyChanged("ViewModel_Config_CenterDetConfig"); } }
        ViewModel_Config_DetConfig _ViewModel_Config_RearDetConfig = new ViewModel_Config_DetConfig();
        public ViewModel_Config_DetConfig ViewModel_Config_RearDetConfig { get { return _ViewModel_Config_RearDetConfig; } set { _ViewModel_Config_RearDetConfig = value; OnPropertyChanged("ViewModel_Config_RearDetConfig"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_FrontDetSettings = new ViewModel_Config_DetSettings();
        public ViewModel_Config_DetSettings ViewModel_Config_FrontDetSettings { get { return _ViewModel_Config_FrontDetSettings; } set { _ViewModel_Config_FrontDetSettings = value; OnPropertyChanged("ViewModel_Config_FrontDetSettings"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_CenterDetSettings = new ViewModel_Config_DetSettings();
        public ViewModel_Config_DetSettings ViewModel_Config_CenterDetSettings { get { return _ViewModel_Config_CenterDetSettings; } set { _ViewModel_Config_CenterDetSettings = value; OnPropertyChanged("ViewModel_Config_CenterDetSettings"); } }
        ViewModel_Config_DetSettings _ViewModel_Config_RearDetSettings = new ViewModel_Config_DetSettings();
        public ViewModel_Config_DetSettings ViewModel_Config_RearDetSettings { get { return _ViewModel_Config_RearDetSettings; } set { _ViewModel_Config_RearDetSettings = value; OnPropertyChanged("ViewModel_Config_RearDetSettings"); } }
        #endregion Detector

        #region Signal
        ViewModel_Config_Signal _ViewModel_Config_Signal1 = new ViewModel_Config_Signal();
        public ViewModel_Config_Signal ViewModel_Config_Signal1 { get { return _ViewModel_Config_Signal1; } set { _ViewModel_Config_Signal1 = value; OnPropertyChanged("ViewModel_Config_Signal1"); } }
        ViewModel_Config_Signal _ViewModel_Config_Signal2 = new ViewModel_Config_Signal();
        public ViewModel_Config_Signal ViewModel_Config_Signal2 { get { return _ViewModel_Config_Signal2; } set { _ViewModel_Config_Signal2 = value; OnPropertyChanged("ViewModel_Config_Signal2"); } }
        ViewModel_Config_Signal _ViewModel_Config_Signal3 = new ViewModel_Config_Signal();
        public ViewModel_Config_Signal ViewModel_Config_Signal3 { get { return _ViewModel_Config_Signal3; } set { _ViewModel_Config_Signal3 = value; OnPropertyChanged("ViewModel_Config_Signal3"); } }
        #endregion Signal

        #region Valve
        ViewModel_Config_ValveInitialState _ViewModel_Config_ValveInitialState = new ViewModel_Config_ValveInitialState();
        public ViewModel_Config_ValveInitialState ViewModel_Config_ValveInitialState { get { return _ViewModel_Config_ValveInitialState; } set { _ViewModel_Config_ValveInitialState = value; OnPropertyChanged("ViewModel_Config_ValveInitialState"); } }
        ViewModel_Config_ValveProgram _ViewModel_Config_ValveProgram = new ViewModel_Config_ValveProgram();
        public ViewModel_Config_ValveProgram ViewModel_Config_ValveProgram { get { return _ViewModel_Config_ValveProgram; } set { _ViewModel_Config_ValveProgram = value; OnPropertyChanged("ViewModel_Config_ValveProgram"); } }
        #endregion Valve

        #region AuxFlow
        ViewModel_Config_AuxFlow _ViewModel_Config_AuxFlow = new ViewModel_Config_AuxFlow();
        public ViewModel_Config_AuxFlow ViewModel_Config_AuxFlow { get { return _ViewModel_Config_AuxFlow; } set { _ViewModel_Config_AuxFlow = value; OnPropertyChanged("ViewModel_Config_AuxFlow"); } }
        ViewModel_Config_AuxTemperature _ViewModel_Config_AuxTemperature = new ViewModel_Config_AuxTemperature();
        public ViewModel_Config_AuxTemperature ViewModel_Config_AuxTemperature { get { return _ViewModel_Config_AuxTemperature; } set { _ViewModel_Config_AuxTemperature = value; OnPropertyChanged("ViewModel_Config_AuxTemperature"); } }
        #endregion AuxFlow

        #region 좌측 메뉴 선택 속성

        E_CONFIG_MENU_TYPE _SelectedMenu = E_CONFIG_MENU_TYPE.OVEN;
        public E_CONFIG_MENU_TYPE SelectedMenu { get { return _SelectedMenu; } set { _SelectedMenu = value; OnPropertyChanged("SelectedMenu"); } }

        E_CONFIG_SUB_MENU_TYPE _SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.OVEN_CONFIG;
        public E_CONFIG_SUB_MENU_TYPE SelectedSubMenu { get { return _SelectedSubMenu; } set { _SelectedSubMenu = value; OnPropertyChanged("SelectedSubMenu"); } }
        
        #endregion 좌측 메뉴 선택 속성


        #endregion Property

        #region Command

        #region 좌측 메뉴 선택 커멘드

        public RelayCommand MenuSelectCommand { get; set; }
        private void MenuSelectCommandAction(object param)
        {
            SelectedMenu = (E_CONFIG_MENU_TYPE)param;        
            switch(SelectedMenu)
            {
                case E_CONFIG_MENU_TYPE.AUX:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.AUX_TEMPERATURE;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.CENTER_DET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.CENTER_DET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.CENTER_INLET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.CENTER_INLET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.FRONT_DET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.FRONT_DET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.FRONT_INLET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.FRONT_INLET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.OVEN:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.OVEN_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.REAR_DET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.REAR_DET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.REAR_INLET:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.REAR_INLET_SETTING;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.SIGNAL:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.SIGNAL1;
                    }
                    break;
                case E_CONFIG_MENU_TYPE.VALVE:
                    {
                        SelectedSubMenu = E_CONFIG_SUB_MENU_TYPE.VALVE_INIT_STATE;
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine(string.Format("ViewModelConfigPage : MenuSelectCommand to {0} Fired",SelectedMenu));
        }

        public RelayCommand SubMenuSelectCommand { get; set; }
        private void SubMenuSelectCommandAction(object param)
        {
            SelectedSubMenu = (E_CONFIG_SUB_MENU_TYPE)param;
            //TODO :             
            Debug.WriteLine(string.Format("ViewModelConfigPage : SubMenuSelectCommand to {0} Fired", SelectedSubMenu));
        }

        #endregion 좌측 메뉴 선택 커멘드

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func

    }
}
