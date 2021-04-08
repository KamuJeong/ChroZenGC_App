using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Config_DetSettings : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_DetSettings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            ElectrometerOnCommand = new RelayCommand(ElectrometerOnCommandAction);
            ElectrometerOffCommand = new RelayCommand(ElectrometerOffCommandAction);
            AutoIgnitionOnCommand = new RelayCommand(AutoIgnitionOnCommandAction);
            AutoIgnitionOffCommand = new RelayCommand(AutoIgnitionOffCommandAction);
            FilamentOnCommand = new RelayCommand(FilamentOnCommandAction);
            FilamentOffCommand = new RelayCommand(FilamentOffCommandAction);
            PolarityChangeOnCommand = new RelayCommand(PolarityChangeOnCommandAction);
            PolarityChangeOffCommand = new RelayCommand(PolarityChangeOffCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        E_DET_TYPE _e_DET_TYPE = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE e_DET_TYPE
        {
            get { return _e_DET_TYPE; }
            set
            {
                if (_e_DET_TYPE != value)
                {
                    switch (value)
                    {
                        case E_DET_TYPE.PDD:
                            {
                                Flow1Enabled = false;
                                Flow2Enabled = false;
                                Flow3Enabled = false;
                                SenseEnabled = false;
                                SignalEnabled = false;
                                PDD_UIEnabled = true;
                                ElectrometerEnabled = false;
                                AutoIgnitionEnabled = false;
                                FilamentEnabled = false;
                                PolarityChangeEnabled = false;
                                LineHeight = 90;
                                BottomLineHeight = 2;
                                FrameHeight = (double)Application.Current.Resources["HEIGHT_DET_SETTING_GROUP_PDD"];
                            }
                            break;
                        case E_DET_TYPE.ECD:
                        case E_DET_TYPE.uECD:
                            {
                                Flow1Enabled = false;
                                Flow2Enabled = true;
                                Flow3Enabled = false;
                                SenseEnabled = false;
                                SignalEnabled = false;
                                PDD_UIEnabled = false;
                                ElectrometerEnabled = false;
                                AutoIgnitionEnabled = false;
                                FilamentEnabled = false;
                                PolarityChangeEnabled = false;
                                LineHeight = 125;
                                BottomLineHeight = 2;
                                FrameHeight = (double)Application.Current.Resources["HEIGHT_DET_SETTING_GROUP_ECD"];

                                Flow2Title = "Make up";
                            }
                            break;
                        case E_DET_TYPE.FID:
                        case E_DET_TYPE.NPD:
                            {
                                Flow1Enabled = true;
                                Flow2Enabled = true;
                                Flow3Enabled = true;
                                SenseEnabled = false;
                                SignalEnabled = true;
                                PDD_UIEnabled = false;
                                ElectrometerEnabled = true;
                                AutoIgnitionEnabled = true;
                                FilamentEnabled = false;
                                PolarityChangeEnabled = false;
                                LineHeight = 248;
                                BottomLineHeight = 75;
                                FrameHeight = (double)Application.Current.Resources["HEIGHT_DET_SETTING_GROUP_8ROW"];

                                Flow1Title = "Air";
                                Flow3Title = "H2";
                                Flow2Title = "Make up";
                            }
                            break;
                        case E_DET_TYPE.FPD:
                        case E_DET_TYPE.PFPD:
                            {
                                Flow1Enabled = true;
                                Flow2Enabled = true;
                                Flow3Enabled = true;
                                SignalEnabled = true;
                                SenseEnabled = false;
                                PDD_UIEnabled = false;
                                ElectrometerEnabled = true;
                                AutoIgnitionEnabled = true;
                                FilamentEnabled = false;
                                PolarityChangeEnabled = false;
                                LineHeight = 248;
                                BottomLineHeight = 75;
                                FrameHeight = (double)Application.Current.Resources["HEIGHT_DET_SETTING_GROUP_8ROW"];

                                Flow1Title = "Air2";
                                Flow3Title = "H2";
                                Flow2Title = "Air1";
                            }
                            break;
                        case E_DET_TYPE.TCD:
                        case E_DET_TYPE.uTCD:
                            {
                                Flow1Enabled = true;
                                Flow2Enabled = true;
                                Flow3Enabled = false;
                                SenseEnabled = true;
                                SignalEnabled = true;
                                PDD_UIEnabled = false;
                                ElectrometerEnabled = false;
                                AutoIgnitionEnabled = false;
                                FilamentEnabled = true;
                                PolarityChangeEnabled = true;
                                LineHeight = 248;
                                BottomLineHeight = 75;
                                FrameHeight = (double)Application.Current.Resources["HEIGHT_DET_SETTING_GROUP_8ROW"];

                                Flow1Title = "Reference";
                                Flow2Title = "Sample";
                            }
                            break;
                    }
                    _e_DET_TYPE = value;
                    OnPropertyChanged("e_DET_TYPE");
                }
            }
        }

        double _FrameHeight;
        public double FrameHeight
        {
            get { return _FrameHeight; }
            set
            {
                if (_FrameHeight != value)
                {
                    _FrameHeight = value;
                    OnPropertyChanged("FrameHeight");
                }
            }
        }

        double _LineHeight;
        public double LineHeight
        {
            get { return _LineHeight; }
            set
            {
                if (_LineHeight != value)
                {
                    _LineHeight = value;
                    OnPropertyChanged("LineHeight");
                }
            }
        }

        double _BottomLineHeight;
        public double BottomLineHeight
        {
            get { return _BottomLineHeight; }
            set
            {
                if (_BottomLineHeight != value)
                {
                    _BottomLineHeight = value;
                    OnPropertyChanged("BottomLineHeight");
                }
            }
        }


        double _Flow1Height;
        public double Flow1Height
        {
            get { return _Flow1Height; }
            set
            {
                if (_Flow1Height != value)
                {
                    _Flow1Height = value;
                    OnPropertyChanged("Flow1Height");
                }
            }
        }

        double _Flow2Height;
        public double Flow2Height
        {
            get { return _Flow2Height; }
            set
            {
                if (_Flow2Height != value)
                {
                    _Flow2Height = value;
                    OnPropertyChanged("Flow2Height");
                }
            }
        }

        double _Flow3Height;
        public double Flow3Height
        {
            get { return _Flow3Height; }
            set
            {
                if (_Flow3Height != value)
                {
                    _Flow3Height = value;
                    OnPropertyChanged("Flow3Height");
                }
            }
        }

        double _SenseHeight;
        public double SenseHeight
        {
            get { return _SenseHeight; }
            set
            {
                if (_SenseHeight != value)
                {
                    _SenseHeight = value;
                    OnPropertyChanged("SenseHeight");
                }
            }
        }

        double _SignalHeight;
        public double SignalHeight
        {
            get { return _SignalHeight; }
            set
            {
                if (_SignalHeight != value)
                {
                    _SignalHeight = value;
                    OnPropertyChanged("SignalHeight");
                }
            }
        }

        double _ElectrometerHeight;
        public double ElectrometerHeight
        {
            get { return _ElectrometerHeight; }
            set
            {
                if (_ElectrometerHeight != value)
                {
                    _ElectrometerHeight = value;
                    OnPropertyChanged("ElectrometerHeight");
                }
            }
        }

        double _AutoIgnitionHeight;
        public double AutoIgnitionHeight
        {
            get { return _AutoIgnitionHeight; }
            set
            {
                if (_AutoIgnitionHeight != value)
                {
                    _AutoIgnitionHeight = value;
                    OnPropertyChanged("AutoIgnitionHeight");
                }
            }
        }

        double _FilamentHeight;
        public double FilamentHeight
        {
            get { return _FilamentHeight; }
            set
            {
                if (_FilamentHeight != value)
                {
                    _FilamentHeight = value;
                    OnPropertyChanged("FilamentHeight");
                }
            }
        }

        double _PolarityChangeHeight;
        public double PolarityChangeHeight
        {
            get { return _PolarityChangeHeight; }
            set
            {
                if (_PolarityChangeHeight != value)
                {
                    _PolarityChangeHeight = value;
                    OnPropertyChanged("PolarityChangeHeight");
                }
            }
        }

        double _PDD_UIHeight;
        public double PDD_UIHeight
        {
            get { return _PDD_UIHeight; }
            set
            {
                if (_PDD_UIHeight != value)
                {
                    _PDD_UIHeight = value;
                    OnPropertyChanged("PDD_UIHeight");
                }
            }
        }

        bool _Flow1Enabled;
        public bool Flow1Enabled
        {
            get { return _Flow1Enabled; }
            set
            {
                if (_Flow1Enabled != value)
                {
                    if (value)
                    {
                        Flow1Height = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        Flow1Height = 0;
                    }
                    _Flow1Enabled = value;
                    OnPropertyChanged("Flow1Enabled");
                }
            }
        }

        bool _Flow2Enabled;
        public bool Flow2Enabled
        {
            get { return _Flow2Enabled; }
            set
            {
                if (_Flow2Enabled != value)
                {
                    if (value)
                    {
                        Flow2Height = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        Flow2Height = 0;
                    }
                    _Flow2Enabled = value;
                    OnPropertyChanged("Flow2Enabled");
                }
            }
        }

        bool _Flow3Enabled;
        public bool Flow3Enabled
        {
            get { return _Flow3Enabled; }
            set
            {
                if (_Flow3Enabled != value)
                {
                    if (value)
                    {
                        Flow3Height = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        Flow3Height = 0;
                    }

                    _Flow3Enabled = value;
                    OnPropertyChanged("Flow3Enabled");
                }
            }
        }

        bool _SenseEnabled;
        public bool SenseEnabled
        {
            get { return _SenseEnabled; }
            set
            {
                if (_SenseEnabled != value)
                {
                    if (value)
                    {
                        SenseHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        SenseHeight = 0;
                    }

                    _SenseEnabled = value;
                    OnPropertyChanged("SenseEnabled");
                }
            }
        }

        bool _SignalEnabled;
        public bool SignalEnabled
        {
            get { return _SignalEnabled; }
            set
            {
                if (_SignalEnabled != value)
                {
                    if (value)
                    {
                        SignalHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        SignalHeight = 0;
                    }

                    _SignalEnabled = value;
                    OnPropertyChanged("SignalEnabled");
                }
            }
        }

        bool _ElectrometerEnabled;
        public bool ElectrometerEnabled
        {
            get { return _ElectrometerEnabled; }
            set
            {
                if (_ElectrometerEnabled != value)
                {
                    if (value)
                    {
                        ElectrometerHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        ElectrometerHeight = 0;
                    }

                    _ElectrometerEnabled = value;
                    OnPropertyChanged("ElectrometerEnabled");
                }
            }
        }

        bool _AutoIgnitionEnabled;
        public bool AutoIgnitionEnabled
        {
            get { return _AutoIgnitionEnabled; }
            set
            {
                if (_AutoIgnitionEnabled != value)
                {
                    if (value)
                    {
                        AutoIgnitionHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        AutoIgnitionHeight = 0;
                    }

                    _AutoIgnitionEnabled = value;
                    OnPropertyChanged("AutoIgnitionEnabled");
                }
            }
        }

        bool _FilamentEnabled;
        public bool FilamentEnabled
        {
            get { return _FilamentEnabled; }
            set
            {
                if (_FilamentEnabled != value)
                {
                    if (value)
                    {
                        FilamentHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        FilamentHeight = 0;
                    }

                    _FilamentEnabled = value;
                    OnPropertyChanged("FilamentEnabled");
                }
            }
        }

        bool _PolarityChangeEnabled;
        public bool PolarityChangeEnabled
        {
            get { return _PolarityChangeEnabled; }
            set
            {
                if (_PolarityChangeEnabled != value)
                {
                    if (value)
                    {
                        PolarityChangeHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        PolarityChangeHeight = 0;
                    }

                    _PolarityChangeEnabled = value;
                    OnPropertyChanged("PolarityChangeEnabled");
                }
            }
        }

        bool _PDD_UIEnabled;
        public bool PDD_UIEnabled
        {
            get { return _PDD_UIEnabled; }
            set
            {
                if (_PDD_UIEnabled != value)
                {
                    if (value)
                    {
                        PDD_UIHeight = (double)Application.Current.Resources["HEIGHT_CONTROLPAGE_NARROW_1"];
                    }
                    else
                    {
                        PDD_UIHeight = 0;
                    }

                    _PDD_UIEnabled = value;
                    OnPropertyChanged("PDD_UIEnabled");
                }
            }
        }

        string _Flow1Title;
        public string Flow1Title
        {
            get { return _Flow1Title; }
            set
            {
                if (_Flow1Title != value)
                {
                    _Flow1Title = value;
                    OnPropertyChanged("Flow1Title");
                }
            }
        }

        string _Flow2Title;
        public string Flow2Title
        {
            get { return _Flow2Title; }
            set
            {
                if (_Flow2Title != value)
                {
                    _Flow2Title = value;
                    OnPropertyChanged("Flow2Title");
                }
            }
        }

        string _Flow3Title;
        public string Flow3Title
        {
            get { return _Flow3Title; }
            set
            {
                if (_Flow3Title != value)
                {
                    _Flow3Title = value;
                    OnPropertyChanged("Flow3Title");
                }
            }
        }

        string _fFlowAct1;
        public string fFlowAct1
        {
            get { return _fFlowAct1; }
            set
            {
                if (_fFlowAct1 != value)
                {
                    _fFlowAct1 = value;
                    OnPropertyChanged("fFlowAct1");
                }
            }
        }
        string _fFlowAct2;
        public string fFlowAct2
        {
            get { return _fFlowAct2; }
            set
            {
                if (_fFlowAct2 != value)
                {
                    _fFlowAct2 = value;
                    OnPropertyChanged("fFlowAct2");
                }
            }
        }
        string _fFlowAct3;
        public string fFlowAct3
        {
            get { return _fFlowAct3; }
            set
            {
                if (_fFlowAct3 != value)
                {
                    _fFlowAct3 = value;
                    OnPropertyChanged("fFlowAct3");
                }
            }
        }

        string _fFlowSet1;
        public string fFlowSet1
        {
            get { return _fFlowSet1; }
            set
            {
                if (_fFlowSet1 != value)
                {
                    _fFlowSet1 = value;
                    OnPropertyChanged("fFlowSet1");

                    if (_bFlowOnoff1)
                    {
                        DisplayString_fFlowSet1 = _fFlowSet1;
                    }
                    else
                    {
                        DisplayString_fFlowSet1 = "Off";
                    }
                }
            }
        }
        string _fFlowSet2;
        public string fFlowSet2
        {
            get { return _fFlowSet2; }
            set
            {
                if (_fFlowSet2 != value)
                {
                    _fFlowSet2 = value;
                    OnPropertyChanged("fFlowSet2");
                    if (_bFlowOnoff2)
                    {
                        DisplayString_fFlowSet2 = _fFlowSet2;
                    }
                    else
                    {
                        DisplayString_fFlowSet2 = "Off";
                    }
                }
            }
        }
        string _fFlowSet3;
        public string fFlowSet3
        {
            get { return _fFlowSet3; }
            set
            {
                if (_fFlowSet3 != value)
                {
                    _fFlowSet3 = value;
                    OnPropertyChanged("fFlowSet3");
                    if (_bFlowOnoff3)
                    {
                        DisplayString_fFlowSet3 = _fFlowSet3;
                    }
                    else
                    {
                        DisplayString_fFlowSet3 = "Off";
                    }
                }
            }
        }

        string _DisplayString_fFlowSet1;
        public string DisplayString_fFlowSet1
        {
            get { return _DisplayString_fFlowSet1; }
            set
            {
                if (_DisplayString_fFlowSet1 != value)
                {
                    _DisplayString_fFlowSet1 = value;
                    OnPropertyChanged("DisplayString_fFlowSet1");
                }
            }
        }

        string _DisplayString_fFlowSet2;
        public string DisplayString_fFlowSet2
        {
            get { return _DisplayString_fFlowSet2; }
            set
            {
                if (_DisplayString_fFlowSet2 != value)
                {
                    _DisplayString_fFlowSet2 = value;
                    OnPropertyChanged("DisplayString_fFlowSet2");
                }
            }
        }

        string _DisplayString_fFlowSet3;
        public string DisplayString_fFlowSet3
        {
            get { return _DisplayString_fFlowSet3; }
            set
            {
                if (_DisplayString_fFlowSet3 != value)
                {
                    _DisplayString_fFlowSet3 = value;
                    OnPropertyChanged("DisplayString_fFlowSet3");
                }
            }
        }

        bool _bFlowOnoff1;
        public bool bFlowOnoff1
        {
            get { return _bFlowOnoff1; }
            set
            {
                if (_bFlowOnoff1 != value)
                {
                    if (value)
                    {
                        DisplayString_fFlowSet1 = _fFlowSet1;
                    }
                    else
                    {
                        DisplayString_fFlowSet1 = "Off";
                    }

                    _bFlowOnoff1 = value;
                    OnPropertyChanged("bFlowOnoff1");
                }
            }
        }
        bool _bFlowOnoff2;
        public bool bFlowOnoff2
        {
            get { return _bFlowOnoff2; }
            set
            {
                if (_bFlowOnoff2 != value)
                {
                    if (value)
                    {
                        DisplayString_fFlowSet2 = _fFlowSet2;
                    }
                    else
                    {
                        DisplayString_fFlowSet2 = "Off";
                    }
                    _bFlowOnoff2 = value;
                    OnPropertyChanged("bFlowOnoff2");
                }
            }
        }
        bool _bFlowOnoff3;
        public bool bFlowOnoff3
        {
            get { return _bFlowOnoff3; }
            set
            {
                if (_bFlowOnoff3 != value)
                {
                    if (value)
                    {
                        DisplayString_fFlowSet3 = _fFlowSet3;
                    }
                    else
                    {
                        DisplayString_fFlowSet3 = "Off";
                    }

                    _bFlowOnoff3 = value;
                    OnPropertyChanged("bFlowOnoff3");
                }
            }
        }

        string _DisplayCurrentSignal = "Off";
        public string DisplayCurrentSignal
        {
            get { return _DisplayCurrentSignal; }
            set
            {
                if (_DisplayCurrentSignal != value)
                {
                    _DisplayCurrentSignal = value;
                    OnPropertyChanged("DisplayCurrentSignal");
                }
            }
        }

        bool _bElectrometer;//Discharge Module
        public bool bElectrometer
        {
            get { return _bElectrometer; }
            set
            {
                if (_bElectrometer != value)
                {
                    _bElectrometer = value;
                    OnPropertyChanged("bElectrometer");                    
                }
            }
        }

        string _ActualTemperature;
        public string ActualTemperature
        {
            get { return _ActualTemperature; }
            set
            {
                if (_ActualTemperature != value)
                {
                    _ActualTemperature = value;
                    OnPropertyChanged("ActualTemperature");
                }
            }
        }
        string _fTempSet;
        public string fTempSet
        {
            get { return _fTempSet; }
            set
            {
                if (_fTempSet != value)
                {
                    _fTempSet = value;
                    OnPropertyChanged("fTempSet");
                    if (_bTempOnoff)
                    {
                        DisplayString_fTempSet = _fTempSet;
                    }
                    else
                    {
                        DisplayString_fTempSet = "Off";
                    }

                    //_fTempSet = value;
                    //OnPropertyChanged("fTempSet");
                }
            }
        }

        string _DisplayString_fTempSet;
        public string DisplayString_fTempSet
        {
            get { return _DisplayString_fTempSet; }
            set
            {
                if (_DisplayString_fTempSet != value)
                {
                    _DisplayString_fTempSet = value;
                    OnPropertyChanged("DisplayString_fTempSet");
                }
            }
        }

        bool _bTempOnoff;
        public bool bTempOnoff
        {
            get { return _bTempOnoff; }
            set
            {
                if (_bTempOnoff != value)
                {
                    if (value)
                    {
                        DisplayString_fTempSet = _fTempSet;
                    }
                    else
                    {
                        DisplayString_fTempSet = "Off";
                    }
                    _bTempOnoff = value;
                    OnPropertyChanged("bTempOnoff");
                }
            }
        }
        bool _bAutoIgnition;
        public bool bAutoIgnition
        {
            get { return _bAutoIgnition; }
            set
            {
                if (_bAutoIgnition != value)
                {
                    _bAutoIgnition = value;
                    OnPropertyChanged("bAutoIgnition");
                }
            }
        }
        string _iBeadVoltageSet;//Sense
        public string iBeadVoltageSet
        {
            get { return _iBeadVoltageSet; }
            set
            {
                if (_iBeadVoltageSet != value)
                {
                    _iBeadVoltageSet = value;
                    OnPropertyChanged("iBeadVoltageSet");
                }
            }
        }

        #region TCD, uTCD

        bool _iBeadVoltageOnoff;//Filament
        public bool iBeadVoltageOnoff
        {
            get { return _iBeadVoltageOnoff; }
            set
            {
                if (_iBeadVoltageOnoff != value)
                {
                    _iBeadVoltageOnoff = value;
                    OnPropertyChanged("iBeadVoltageOnoff");
                }
            }
        }
        bool _bPolarChange;//Polarity Change
        public bool bPolarChange
        {
            get { return _bPolarChange; }
            set
            {
                if (_bPolarChange != value)
                {
                    _bPolarChange = value;
                    OnPropertyChanged("bPolarChange");
                }
            }
        }

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

        #region KeyPad : CancelCommand

        public RelayCommand KeyPadCancelCommand { get; set; }
        private void KeyPadCancelCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;
            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //EventManager.KeyPadRequestEvent(vmKeyPad);
        }

        #endregion KeyPad : CancelCommand

        #region KeyPad : DeleteCommand

        public RelayCommand KeyPadDeleteCommand { get; set; }
        private void KeyPadDeleteCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0)
            {
                double tempVal;
                double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Substring(0, mainVM.ViewModel_KeyPad.CurrentValue.Length - 1), out tempVal);
                Debug.WriteLine(string.Format("tempVal : {0}", tempVal));
                mainVM.ViewModel_KeyPad.CurrentValue = tempVal.ToString();
            }
            mainVM.ViewModel_KeyPad.IsNeedRefresh = false;
        }

        #endregion KeyPad : DeleteCommand

        #region KeyPad : ApplyCommand

        public RelayCommand KeyPadApplyCommand { get; set; }
        private void KeyPadApplyCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            //.시작 케이스
            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
            {
                double tempVal;
                double.TryParse("0" + mainVM.ViewModel_KeyPad.CurrentValue, out tempVal);
                if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                {
                    mainVM.ViewModel_KeyPad.CurrentValue = "0" + mainVM.ViewModel_KeyPad.CurrentValue;
                }
            }
            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '-' &&
                mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
            {
                double tempVal;
                double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0"), out tempVal);
                if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                {
                    mainVM.ViewModel_KeyPad.CurrentValue = mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0");
                }
            }
            float tempFloatVal = 0;
            if (float.TryParse(mainVM.ViewModel_KeyPad.CurrentValue, out tempFloatVal))
            {
                switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
                {
                    #region Front

                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_TEMPERATURE:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_1:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_2:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_3:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.NPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet3 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_SENSE:
                        {
                            iBeadVoltageSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.iBeadVoltageSet = (short)tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                        }
                        break;

                    #endregion Front

                    #region Center

                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_TEMPERATURE:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_1:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_2:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_3:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.NPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet3 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_SENSE:
                        {
                            iBeadVoltageSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.iBeadVoltageSet = (short)tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                        }
                        break;

                    #endregion Center

                    #region Rear

                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_TEMPERATURE:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_1:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet1 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_2:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.NPD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                                case E_DET_TYPE.TCD:
                                case E_DET_TYPE.uTCD:
                                    {
                                        fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet2 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_3:
                        {
                            switch (e_DET_TYPE)
                            {
                                case E_DET_TYPE.FID:
                                case E_DET_TYPE.FPD:
                                case E_DET_TYPE.NPD:
                                case E_DET_TYPE.PFPD:
                                    {
                                        fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet3 = tempFloatVal;
                                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                                    }
                                    break;
                            }
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_SENSE:
                        {
                            iBeadVoltageSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.iBeadVoltageSet = (short)tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                        }
                        break;

                        #endregion Rear
                }
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;

            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //EventManager.KeyPadRequestEvent(vmKeyPad);
        }

        #endregion KeyPad : ApplyCommand

        #region KeyPad : OnCommand

        public RelayCommand KeyPadOnCommand { get; set; }
        private void KeyPadOnCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            float tempFloatVal = 0;
            if (float.TryParse(mainVM.ViewModel_KeyPad.CurrentValue, out tempFloatVal))
            {
                switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
                {
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_TEMPERATURE:
                        {
                            bTempOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bTempOnoff = _bTempOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            #endregion
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_1:
                        {
                            bFlowOnoff1 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bFlowOnoff1 = _bFlowOnoff1 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet1 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_2:
                        {
                            bFlowOnoff2 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bFlowOnoff2 = _bFlowOnoff2 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet2 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_3:
                        {
                            bFlowOnoff3 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bFlowOnoff3 = _bFlowOnoff3 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.fFlowSet3 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_TEMPERATURE:
                        {
                            bTempOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bTempOnoff = _bTempOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                            #endregion
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_1:
                        {
                            bFlowOnoff1 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bFlowOnoff1 = _bFlowOnoff1 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet1 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_2:
                        {
                            bFlowOnoff2 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bFlowOnoff2 = _bFlowOnoff2 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet2 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_3:
                        {
                            bFlowOnoff3 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bFlowOnoff3 = _bFlowOnoff3 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.fFlowSet3 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_TEMPERATURE:
                        {
                            bTempOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bTempOnoff = _bTempOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                            #endregion

                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_1:
                        {
                            bFlowOnoff1 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bFlowOnoff1 = _bFlowOnoff1 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet1 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_2:
                        {
                            bFlowOnoff2 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bFlowOnoff2 = _bFlowOnoff2 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet2 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_3:
                        {
                            bFlowOnoff3 = true;
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bFlowOnoff3 = _bFlowOnoff3 ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fFlowSet3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.fFlowSet3 = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                }
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
        }

        #endregion KeyPad : OnCommand

        #region KeyPad : OffCommand

        public RelayCommand KeyPadOffCommand { get; set; }
        private void KeyPadOffCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;

            switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
            {
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_TEMPERATURE:
                    {
                        bTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bTempOnoff = _bTempOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_1:
                    {
                        bFlowOnoff1 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bFlowOnoff1 = _bFlowOnoff1 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_2:
                    {
                        bFlowOnoff2 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bFlowOnoff2 = _bFlowOnoff2 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_3:
                    {
                        bFlowOnoff3 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bFlowOnoff3 = _bFlowOnoff3 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_TEMPERATURE:
                    {
                        bTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bTempOnoff = _bTempOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_1:
                    {
                        bFlowOnoff1 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bFlowOnoff1 = _bFlowOnoff1 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_2:
                    {
                        bFlowOnoff2 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bFlowOnoff2 = _bFlowOnoff2 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_3:
                    {
                        bFlowOnoff3 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bFlowOnoff3 = _bFlowOnoff3 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_TEMPERATURE:
                    {
                        bTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bTempOnoff = _bTempOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_1:
                    {
                        bFlowOnoff1 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bFlowOnoff1 = _bFlowOnoff1 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_2:
                    {
                        bFlowOnoff2 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bFlowOnoff2 = _bFlowOnoff2 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_3:
                    {
                        bFlowOnoff3 = false;
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bFlowOnoff3 = _bFlowOnoff3 ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
            }
        }

        #endregion KeyPad : OffCommand

        #region KeyPad : KeyPadClickCommand

        public RelayCommand KeyPadKeyPadClickCommand { get; set; }
        private void KeyPadKeyPadClickCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModelMainPage mainVM = (ViewModelMainPage)sender.BindingContext;
            if (mainVM.ViewModel_KeyPad.IsNeedRefresh)
            {
                mainVM.ViewModel_KeyPad.CurrentValue = "";
                mainVM.ViewModel_KeyPad.IsNeedRefresh = false;
            }

            switch (sender.Text)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    {
                        //.시작 케이스
                        if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
                        {
                            double tempVal;
                            double.TryParse("0" + mainVM.ViewModel_KeyPad.CurrentValue, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                        else if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '-' &&
                            mainVM.ViewModel_KeyPad.CurrentValue[1] == '.')
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0"), out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                        else if (mainVM.ViewModel_KeyPad.CurrentValue == "0") //20210407 권민경: 기존값이 0일때 0 지우기
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue + sender.Text, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue = sender.Text;
                            }
                        }
                        else
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue + sender.Text, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                    }
                    break;
                case ".":
                    {
                        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("."))
                        {
                            mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                        }
                    }
                    break;
                case "-/+":
                    {
                        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("-"))
                        {
                            mainVM.ViewModel_KeyPad.CurrentValue = "-" + mainVM.ViewModel_KeyPad.CurrentValue;
                        }
                    }
                    break;

            }
        }

        #endregion KeyPad : KeyPadClickCommand

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            {
                IsKeyPadShown = true,
                KeyPadType = KeyPad.E_KEYPAD_TYPE.DOUBLE,
                MinValue = 0,
                CancelCommand = KeyPadCancelCommand,
                ApplyCommand = KeyPadApplyCommand,
                DeleteCommand = KeyPadDeleteCommand,
                OnCommand = KeyPadOnCommand,
                OffCommand = KeyPadOffCommand,
                KeyPadClickCommand = KeyPadKeyPadClickCommand,
            };

            switch ((E_KEY_PAD_SET_MEASURE_TYPE)param)
            {
                #region Front
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_TEMPERATURE:
                    {
                        vmKeyPad.Title = "Temperatrue";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = fTempSet;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_TEMPERATURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_1:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "Air2";
                                    vmKeyPad.MaxValue = 500;
                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    vmKeyPad.Title = "Reference";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    vmKeyPad.Title = "Air";
                                    vmKeyPad.MaxValue = 500;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                        }
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_2:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    vmKeyPad.Title = "Make Up";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "Air1";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    vmKeyPad.Title = "Sample";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                        }
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_3:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.NPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "H2";
                                    vmKeyPad.MaxValue = 150;

                                    vmKeyPad.CurrentValue = fFlowSet3;

                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_FLOW_3;
                                }
                                break;
                        }
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_SENSE:
                    {
                        vmKeyPad.Title = "Sense";
                        vmKeyPad.MaxValue = 9;

                        vmKeyPad.CurrentValue = iBeadVoltageSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_FRONT_SETTING_SENSE;
                    }
                    break;
                #endregion Front

                #region Center
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_TEMPERATURE:
                    {
                        vmKeyPad.Title = "Temperatrue";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;

                        vmKeyPad.CurrentValue = fTempSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_TEMPERATURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_1:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "Air2";
                                    vmKeyPad.MaxValue = 500;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    vmKeyPad.Title = "Reference";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    vmKeyPad.Title = "Air";
                                    vmKeyPad.MaxValue = 500;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                        }
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_2:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    vmKeyPad.Title = "Make Up";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "Air1";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    vmKeyPad.Title = "Sample";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                        }
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_3:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.NPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "H2";
                                    vmKeyPad.MaxValue = 150;

                                    vmKeyPad.CurrentValue = fFlowSet3;

                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_FLOW_3;
                                }
                                break;
                        }
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_SENSE:
                    {
                        vmKeyPad.Title = "Sense";
                        vmKeyPad.MaxValue = 9;

                        vmKeyPad.CurrentValue = iBeadVoltageSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_CENTER_SETTING_SENSE;
                    }
                    break;
                #endregion Center

                #region Rear
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_TEMPERATURE:
                    {
                        vmKeyPad.Title = "Temperatrue";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;

                        vmKeyPad.CurrentValue = fTempSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_TEMPERATURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_1:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "Air2";
                                    vmKeyPad.MaxValue = 500;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    vmKeyPad.Title = "Reference";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    vmKeyPad.Title = "Air";
                                    vmKeyPad.MaxValue = 500;

                                    vmKeyPad.CurrentValue = fFlowSet1;
                                }
                                break;
                        }
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_2:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.NPD:
                                {
                                    vmKeyPad.Title = "Make Up";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "Air1";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                            case E_DET_TYPE.TCD:
                            case E_DET_TYPE.uTCD:
                                {
                                    vmKeyPad.Title = "Sample";
                                    vmKeyPad.MaxValue = 100;

                                    vmKeyPad.CurrentValue = fFlowSet2;
                                }
                                break;
                        }
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_3:
                    {
                        switch (e_DET_TYPE)
                        {
                            case E_DET_TYPE.FID:
                            case E_DET_TYPE.FPD:
                            case E_DET_TYPE.NPD:
                            case E_DET_TYPE.PFPD:
                                {
                                    vmKeyPad.Title = "H2";
                                    vmKeyPad.MaxValue = 150;

                                    vmKeyPad.CurrentValue = fFlowSet3;

                                    vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_FLOW_3;
                                }
                                break;
                        }
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_SENSE:
                    {
                        vmKeyPad.Title = "Sense";
                        vmKeyPad.MaxValue = 9;

                        vmKeyPad.CurrentValue = iBeadVoltageSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.DET_REAR_SETTING_SENSE;
                    }
                    break;
                    #endregion Rear
            }

            EventManager.KeyPadRequestEvent(vmKeyPad);

            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region ElectrometerOnCommand
        public RelayCommand ElectrometerOnCommand { get; set; }
        private void ElectrometerOnCommandAction(object param)
        {
            bElectrometer = true;
            SetCurrentSignal((E_DET_LOCATION)param);
            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bElectrometer = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bElectrometer = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bElectrometer = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("ElectrometerOnCommand Fired");
        }
        #endregion ElectrometerOnCommand 

        #region ElectrometerOffCommand
        public RelayCommand ElectrometerOffCommand { get; set; }
        private void ElectrometerOffCommandAction(object param)
        {
            bElectrometer = false;
            SetCurrentSignal((E_DET_LOCATION)param);
            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bElectrometer = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bElectrometer = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bElectrometer = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("ElectrometerOffCommand Fired");
        }
        #endregion ElectrometerOffCommand 

        #region AutoIgnitionOnCommand
        public RelayCommand AutoIgnitionOnCommand { get; set; }
        private void AutoIgnitionOnCommandAction(object param)
        {
            bAutoIgnition = true;

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bAutoIgnition = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bAutoIgnition = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bAutoIgnition = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("AutoIgnitionOnCommand Fired");
        }
        #endregion AutoIgnitionOnCommand 

        #region AutoIgnitionOffCommand
        public RelayCommand AutoIgnitionOffCommand { get; set; }
        private void AutoIgnitionOffCommandAction(object param)
        {
            bAutoIgnition = false;

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bAutoIgnition = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bAutoIgnition = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bAutoIgnition = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("AutoIgnitionOffCommand Fired");
        }
        #endregion AutoIgnitionOffCommand 

        #region FilamentOnCommand
        public RelayCommand FilamentOnCommand { get; set; }
        private void FilamentOnCommandAction(object param)
        {
            iBeadVoltageOnoff = true;

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.iBeadVoltageOnoff = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.iBeadVoltageOnoff = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.iBeadVoltageOnoff = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("FilamentOnCommand Fired");
        }
        #endregion FilamentOnCommand 

        #region FilamentOffCommand
        public RelayCommand FilamentOffCommand { get; set; }
        private void FilamentOffCommandAction(object param)
        {
            iBeadVoltageOnoff = false;

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.iBeadVoltageOnoff = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.iBeadVoltageOnoff = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.iBeadVoltageOnoff = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("FilamentOffCommand Fired");
        }
        #endregion FilamentOffCommand 

        #region PolarityChangeOnCommand
        public RelayCommand PolarityChangeOnCommand { get; set; }
        private void PolarityChangeOnCommandAction(object param)
        {
            bPolarChange = true;

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bPolarChange = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bPolarChange = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bPolarChange = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("PolarityChangeOnCommand Fired");
        }
        #endregion PolarityChangeOnCommand 

        #region PolarityChangeOffCommand
        public RelayCommand PolarityChangeOffCommand { get; set; }
        private void PolarityChangeOffCommandAction(object param)
        {
            bPolarChange = false;

            switch ((E_DET_LOCATION)param)
            {
                case E_DET_LOCATION.FRONT:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet.bPolarChange = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front.packet));
                    }
                    break;
                case E_DET_LOCATION.CENTER:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet.bPolarChange = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center.packet));
                    }
                    break;
                case E_DET_LOCATION.REAR:
                    {
                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet.bPolarChange = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(
                            DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("PolarityChangeOffCommand Fired");
        }
        #endregion PolarityChangeOffCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        void SetCurrentSignal(E_DET_LOCATION e_DET_LOCATION)
        {
            if (bElectrometer)
            {
                byte btInletIndex = 0;

                switch(e_DET_LOCATION)
                {
                    case E_DET_LOCATION.FRONT:
                        {
                            btInletIndex = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.btCurSignal[0];
                        }
                        break;
                    case E_DET_LOCATION.CENTER:
                        {
                            btInletIndex = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.btCurSignal[1];
                        }
                        break;
                    case E_DET_LOCATION.REAR:
                        {
                            btInletIndex = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.btCurSignal[2];
                        }
                        break;
                }

                float fCurrentSignal = DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.fSignal[btInletIndex];
                    

                if (fCurrentSignal > 1000)
                {
                    DisplayCurrentSignal = fCurrentSignal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                }
                else if (fCurrentSignal > 100)
                {
                    DisplayCurrentSignal = fCurrentSignal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                }
                else if (fCurrentSignal > 0)
                {
                    DisplayCurrentSignal = fCurrentSignal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                }
                else DisplayCurrentSignal = "0";
            }
            else
            {
                DisplayCurrentSignal = "OFF";
            }
        }

        #endregion Instance Func
    }
}
