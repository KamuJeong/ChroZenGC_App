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
            MenuSelectCommand = new RelayCommand(MenuSelectCommandAction);
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

        #region 좌측 메뉴 선택 속성
        bool _IsOvenMenuSelected = true;
        public bool IsOvenMenuSelected
        {
            get { return _IsOvenMenuSelected; }
            set
            {
                _IsOvenMenuSelected = value;
                if (value == true)
                {
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsOvenMenuSelected");
            }
        }

        bool _IsFrontInletMenuSelected;
        public bool IsFrontInletMenuSelected
        {
            get { return _IsFrontInletMenuSelected; }
            set
            {
                _IsFrontInletMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsFrontInletMenuSelected");
            }
        }

        bool _IsCenterInletMenuSelected;
        public bool IsCenterInletMenuSelected
        {
            get { return _IsCenterInletMenuSelected; }
            set
            {
                _IsCenterInletMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsCenterInletMenuSelected");
            }
        }

        bool _IsBottomInletMenuSelected;
        public bool IsBottomInletMenuSelected
        {
            get { return _IsBottomInletMenuSelected; }
            set
            {
                _IsBottomInletMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsBottomInletMenuSelected");
            }
        }

        bool _IsFrontDetectorMenuSelected;
        public bool IsFrontDetectorMenuSelected
        {
            get { return _IsFrontDetectorMenuSelected; }
            set
            {
                _IsFrontDetectorMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsFrontDetectorMenuSelected");
            }
        }

        bool _IsCenterDetectorMenuSelected;
        public bool IsCenterDetectorMenuSelected
        {
            get { return _IsCenterDetectorMenuSelected; }
            set
            {
                _IsCenterDetectorMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsCenterDetectorMenuSelected");
            }
        }

        bool _IsBottomDetectorMenuSelected;
        public bool IsBottomDetectorMenuSelected
        {
            get { return _IsBottomDetectorMenuSelected; }
            set
            {
                _IsBottomDetectorMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsBottomDetectorMenuSelected");
            }
        }

        bool _IsSignalMenuSelected;
        public bool IsSignalMenuSelected
        {
            get { return _IsSignalMenuSelected; }
            set
            {
                _IsSignalMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsValveMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsSignalMenuSelected");
            }
        }

        bool _IsValveMenuSelected;
        public bool IsValveMenuSelected
        {
            get { return _IsValveMenuSelected; }
            set
            {
                _IsValveMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsAuxMenuSelected = false;
                }
                OnPropertyChanged("IsValveMenuSelected");
            }
        }

        bool _IsAuxMenuSelected;
        public bool IsAuxMenuSelected
        {
            get { return _IsAuxMenuSelected; }
            set
            {
                _IsAuxMenuSelected = value;
                if (value == true)
                {
                    IsOvenMenuSelected = false;
                    IsFrontInletMenuSelected = false;
                    IsCenterInletMenuSelected = false;
                    IsBottomInletMenuSelected = false;
                    IsFrontDetectorMenuSelected = false;
                    IsCenterDetectorMenuSelected = false;
                    IsBottomDetectorMenuSelected = false;
                    IsSignalMenuSelected = false;
                    IsValveMenuSelected = false;
                }
                OnPropertyChanged("IsAuxMenuSelected");
            }
        }
        #endregion 좌측 메뉴 선택 속성

        #endregion Property

        #region Command

        #region 좌측 메뉴 선택 커멘드

        public RelayCommand MenuSelectCommand { get; set; }
        private void MenuSelectCommandAction(object param)
        {
            switch (param)
            {
                case "Oven":
                    {
                        IsOvenMenuSelected = true;
                    }
                    break;
                case "FrontInlet":
                    {
                        IsFrontInletMenuSelected = true;
                    }
                    break;
                case "CenterInlet":
                    {
                        IsCenterInletMenuSelected = true;
                    }
                    break;
                case "RearInlet":
                    {
                        IsBottomInletMenuSelected = true;
                    }
                    break;
                case "FrontDetector":
                    {
                        IsFrontDetectorMenuSelected = true;
                    }
                    break;
                case "CenterDetector":
                    {
                        IsCenterDetectorMenuSelected = true;
                    }
                    break;
                case "RearDetector":
                    {
                        IsBottomDetectorMenuSelected = true;
                    }
                    break;
                case "Signal":
                    {
                        IsSignalMenuSelected = true;
                    }
                    break;
                case "Valve":
                    {
                        IsValveMenuSelected = true;
                    }
                    break;
                case "Aux":
                    {
                        IsAuxMenuSelected = true;
                    }
                    break;
            }
            //TODO :             
            Debug.WriteLine("DefaultCommand Fired");
        }

        #endregion 좌측 메뉴 선택 커멘드

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func

    }
}
