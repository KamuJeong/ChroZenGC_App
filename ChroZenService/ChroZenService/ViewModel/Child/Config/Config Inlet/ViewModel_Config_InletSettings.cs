using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;
using static YC_ChroZenGC_Type.T_CHROZEN_INLET;

namespace ChroZenService
{
    public class ViewModel_Config_InletSettings : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_InletSettings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);

            InletInjectionModeIndexChangeCommand = new RelayCommand(InletInjectionModeIndexChangeCommandAction);
            TempModeIndexChangeCommand = new RelayCommand(TempModeIndexChangeCommandAction);

            Navigation_NextCommand = new RelayCommand(Navigation_NextCommandAction);
            Navigation_PrevCommand = new RelayCommand(Navigation_PrevCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };


        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property
        TCPManager tcpManager;

        E_INLET_TYPE _e_INLET_TYPE = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE e_INLET_TYPE { get { return _e_INLET_TYPE; } set { if (_e_INLET_TYPE != value) { _e_INLET_TYPE = value; OnPropertyChanged("e_INLET_TYPE"); } } }

        byte _ApcMode;

        /// <summary>
        /// casing rule
        /// 0,2 : 
        ///     column flow set -> enable
        ///     Pressure set -> disable
        /// 1,3 : 
        ///     column total flow -> disable
        ///     column split flow -> disable
        ///     Pressure set -> enable
        /// </summary>

        public byte ApcMode
        {
            get { return _ApcMode; }
            set
            {
                if (_ApcMode != value)
                {

                    switch (value)
                    {
                        case 0:
                            {
                                DisplayString_fPressureSet = "Off";

                                TableTitle = "Constant Flow";
                                if (_fColumnFlowOnoff == true)
                                    DisplayString_fColumnFlowSet = fColumnFlowSet;
                                else DisplayString_fColumnFlowSet = "Off";

                                DisplayString_fTotalFlowSet = fTotalFlowSet;

                                DisplayString_fSplitFlowSet = fSplitFlowSet;
                            }
                            break;
                        case 1:
                            {
                                DisplayString_fColumnFlowSet = "Off";
                                DisplayString_fTotalFlowSet = "Off";
                                DisplayString_fSplitFlowSet = "Off";

                                TableTitle = "Constant Press";

                                if (_fPressureOnoff)
                                    DisplayString_fPressureSet = fPressureSet;
                                else DisplayString_fPressureSet = "Off";
                            }
                            break;
                        case 2:
                            {
                                DisplayString_fPressureSet = "Off";

                                TableTitle = "Programed Flow";

                                if (_fColumnFlowOnoff == true)
                                    DisplayString_fColumnFlowSet = fColumnFlowSet;
                                else DisplayString_fColumnFlowSet = "Off";

                                DisplayString_fTotalFlowSet = fTotalFlowSet;

                                DisplayString_fSplitFlowSet = fSplitFlowSet;
                            }
                            break;
                        case 3:
                            {
                                DisplayString_fColumnFlowSet = "Off";
                                DisplayString_fTotalFlowSet = "Off";
                                DisplayString_fSplitFlowSet = "Off";

                                TableTitle = "Programed Press";

                                if (_fPressureOnoff)
                                    DisplayString_fPressureSet = fPressureSet;
                                else DisplayString_fPressureSet = "Off";
                            }
                            break;
                    }

                    _ApcMode = value;
                    OnPropertyChanged("ApcMode");
                }
            }
        }

        byte _btTempMode;
        public byte btTempMode { get { return _btTempMode; } set { if (_btTempMode != value) { _btTempMode = value; OnPropertyChanged("btTempMode"); } } }

        string _TableTitle;
        public string TableTitle { get { return _TableTitle; } set { if (_TableTitle != value) { _TableTitle = value; OnPropertyChanged("TableTitle"); } } }

        bool _IsFirstPage = true;
        public bool IsFirstPage { get { return _IsFirstPage; } set { if (_IsFirstPage != value) { _IsFirstPage = value; OnPropertyChanged("IsFirstPage"); } } }



        bool _fTempOnoff;
        public bool fTempOnoff
        {
            get { return fTempOnoff; }
            set
            {
                if (_fTempOnoff != value)
                {
                    _fTempOnoff = value;
                    OnPropertyChanged("fTempOnoff");

                    SetTemp();
                }
            }
        }

        string _ActualTemperature;
        public string ActualTemperature { get { return _ActualTemperature; } set { if (_ActualTemperature != value) { _ActualTemperature = value; OnPropertyChanged("ActualTemperature"); } } }

        byte _btInjMode;
        public byte btInjMode { get { return _btInjMode; }
            set
            {
                if (_btInjMode != value)
                {
                    _btInjMode = value;

                    switch ((E_INLET_INJ_MODE)value)
                    {
                        case E_INLET_INJ_MODE.SPLIT_MODE:
                        case E_INLET_INJ_MODE.SPLITLESS_MODE:
                            {
                                DisplayString_fTotalFlowSet = fTotalFlowSet;
                                DisplayString_fSplitFlowSet = fSplitFlowSet;
                            }
                            break;
                        case E_INLET_INJ_MODE.PULSED_SPLIT_MODE:
                        case E_INLET_INJ_MODE.PULSED_SPLITLESS_MODE:
                            {
                                DisplayString_fTotalFlowSet = "Off";
                                DisplayString_fSplitFlowSet = "Off";
                            }
                            break;                           
                }
                    OnPropertyChanged("btInjMode");
                }
            }
        }

        string _ActualColumnFlow;
        public string ActualColumnFlow { get { return _ActualColumnFlow; } set { if (_ActualColumnFlow != value) { _ActualColumnFlow = value; OnPropertyChanged("ActualColumnFlow"); } } }

        string _ActualPressure;
        public string ActualPressure { get { return _ActualPressure; } set { if (_ActualPressure != value) { _ActualPressure = value; OnPropertyChanged("ActualPressure"); } } }

        string _ActualTotalFlow;
        public string ActualTotalFlow { get { return _ActualTotalFlow; } set { if (_ActualTotalFlow != value) { _ActualTotalFlow = value; OnPropertyChanged("ActualTotalFlow"); } } }

        string _ActualSplitFlow;
        public string ActualSplitFlow { get { return _ActualSplitFlow; } set { if (_ActualSplitFlow != value) { _ActualSplitFlow = value; OnPropertyChanged("ActualSplitFlow"); } } }

        string _ActualVelocity;
        public string ActualVelocity { get { return _ActualVelocity; } set { if (_ActualVelocity != value) { _ActualVelocity = value; OnPropertyChanged("ActualVelocity"); } } }



        bool _fColumnFlowOnoff;
        public bool fColumnFlowOnoff
        {
            get { return _fColumnFlowOnoff; }
            set
            {

                if (_fColumnFlowOnoff != value)
                {
                    _fColumnFlowOnoff = value;

                    OnPropertyChanged("fColumnFlowOnoff");

                    SetColumnFlow();
                }
            }
        }

        bool _fPressureOnoff;
        public bool fPressureOnoff
        {
            get { return _fPressureOnoff; }
            set
            {
                if (_fPressureOnoff != value)
                {
                    _fPressureOnoff = value;

                    OnPropertyChanged("fPressureOnoff");

                    SetPressure();
                }
            }
        }

        bool _fTotalFlowOnoff;
        public bool fTotalFlowOnoff
        {
            get { return _fTotalFlowOnoff; }
            set
            {
                if (_fTotalFlowOnoff != value)
                {
                    _fTotalFlowOnoff = value;

                    OnPropertyChanged("fTotalFlowOnoff");

                    //SetTotalFlow();
                }
            }
        }



        string _iSplitratio;
        public string iSplitratio
        {
            get { return _iSplitratio; }
            set
            {
                //if (_iSplitratio != value)
                { _iSplitratio = value; OnPropertyChanged("iSplitratio"); }
            }
        }

        string _fPulsed_FlowPressSet;
        public string fPulsed_FlowPressSet { get { return _fPulsed_FlowPressSet; } set { if (_fPulsed_FlowPressSet != value) { _fPulsed_FlowPressSet = value; OnPropertyChanged("fPulsed_FlowPressSet"); } } }

        string _fSplitOnTime;
        public string fSplitOnTime { get { return _fSplitOnTime; } set { if (_fSplitOnTime != value) { _fSplitOnTime = value; OnPropertyChanged("fSplitOnTime"); } } }

        string _fPulsed_Time;
        public string fPulsed_Time { get { return _fPulsed_Time; } set { if (_fPulsed_Time != value) { _fPulsed_Time = value; OnPropertyChanged("fPulsed_Time"); } } }


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
                    SetTemp();

                }
            }
        }

        string _fColumnFlowSet;
        public string fColumnFlowSet
        {
            get { return _fColumnFlowSet; }
            set
            {
                //if (_fColumnFlowSet != value)
                {

                    _fColumnFlowSet = value;
                    OnPropertyChanged("fColumnFlowSet");
                    SetColumnFlow();
                }
            }
        }

        string _fPressureSet;
        public string fPressureSet
        {
            get { return _fPressureSet; }
            set
            {
                if (_fPressureSet != value)
                {
                    _fPressureSet = value;
                    OnPropertyChanged("fPressureSet");
                    SetPressure();
                }
            }
        }

        string _fTotalFlowSet;
        public string fTotalFlowSet
        {
            get { return _fTotalFlowSet; }
            set
            {
                //if (_fTotalFlowSet != value)
                {
                    _fTotalFlowSet = value;
                    OnPropertyChanged("fTotalFlowSet");
                    SetTotalFlow();
                }
            }
        }

        string _fSplitFlowSet;
        public string fSplitFlowSet
        {
            get { return _fSplitFlowSet; }
            set
            {
                //if (_fSplitFlowSet != value)
                {
                    _fSplitFlowSet = value;
                    OnPropertyChanged("fSplitFlowSet");
                    SetSplitFlow();
                }
            }
        }

        string _DisplayString_fTempSet;
        public string DisplayString_fTempSet { get { return _DisplayString_fTempSet; } set { if (_DisplayString_fTempSet != value) { _DisplayString_fTempSet = value; OnPropertyChanged("DisplayString_fTempSet"); } } }
        string _DisplayString_fColumnFlowSet;
        public string DisplayString_fColumnFlowSet { get { return _DisplayString_fColumnFlowSet; } set { if (_DisplayString_fColumnFlowSet != value) { _DisplayString_fColumnFlowSet = value; OnPropertyChanged("DisplayString_fColumnFlowSet"); } } }
        string _DisplayString_fPressureSet;
        public string DisplayString_fPressureSet { get { return _DisplayString_fPressureSet; } set { if (_DisplayString_fPressureSet != value) { _DisplayString_fPressureSet = value; OnPropertyChanged("DisplayString_fPressureSet"); } } }
        string _DisplayString_fTotalFlowSet;
        public string DisplayString_fTotalFlowSet { get { return _DisplayString_fTotalFlowSet; } set { if (_DisplayString_fTotalFlowSet != value) { _DisplayString_fTotalFlowSet = value; OnPropertyChanged("DisplayString_fTotalFlowSet"); } } }
        string _DisplayString_fSplitFlowSet;
        public string DisplayString_fSplitFlowSet { get { return _DisplayString_fSplitFlowSet; } set { if (_DisplayString_fSplitFlowSet != value) { _DisplayString_fSplitFlowSet = value; OnPropertyChanged("DisplayString_fSplitFlowSet"); } } }

        #region Temp Program -> On-Column Only

        //string _temp_fRate_1;
        //public string temp_fRate_1 { get { return _temp_fRate_1; } set { _temp_fRate_1 = value; OnPropertyChanged("temp_fRate_1"); } }

        string _temp_fRate_2;
        public string temp_fRate_2 { get { return _temp_fRate_2; } set { if (_temp_fRate_2 != value) { _temp_fRate_2 = value; OnPropertyChanged("temp_fRate_2"); } } }

        string _temp_fRate_3;
        public string temp_fRate_3 { get { return _temp_fRate_3; } set { if (_temp_fRate_3 != value) { _temp_fRate_3 = value; OnPropertyChanged("temp_fRate_3"); } } }

        string _temp_fRate_4;
        public string temp_fRate_4 { get { return _temp_fRate_4; } set { if (_temp_fRate_4 != value) { _temp_fRate_4 = value; OnPropertyChanged("temp_fRate_4"); } } }

        string _temp_fRate_5;
        public string temp_fRate_5 { get { return _temp_fRate_5; } set { if (_temp_fRate_5 != value) { _temp_fRate_5 = value; OnPropertyChanged("temp_fRate_5"); } } }

        string _temp_fRate_6;
        public string temp_fRate_6 { get { return _temp_fRate_6; } set { if (_temp_fRate_6 != value) { _temp_fRate_6 = value; OnPropertyChanged("temp_fRate_6"); } } }

        string _temp_fFinalTemp_1;
        public string temp_fFinalTemp_1 { get { return _temp_fFinalTemp_1; } set { if (_temp_fFinalTemp_1 != value) { _temp_fFinalTemp_1 = value; OnPropertyChanged("temp_fFinalTemp_1"); } } }

        string _temp_fFinalTemp_2;
        public string temp_fFinalTemp_2 { get { return _temp_fFinalTemp_2; } set { if (_temp_fFinalTemp_2 != value) { _temp_fFinalTemp_2 = value; OnPropertyChanged("temp_fFinalTemp_2"); } } }

        string _temp_fFinalTemp_3;
        public string temp_fFinalTemp_3 { get { return _temp_fFinalTemp_3; } set { if (_temp_fFinalTemp_3 != value) { _temp_fFinalTemp_3 = value; OnPropertyChanged("temp_fFinalTemp_3"); } } }

        string _temp_fFinalTemp_4;
        public string temp_fFinalTemp_4 { get { return _temp_fFinalTemp_4; } set { if (_temp_fFinalTemp_4 != value) { _temp_fFinalTemp_4 = value; OnPropertyChanged("temp_fFinalTemp_4"); } } }

        string _temp_fFinalTemp_5;
        public string temp_fFinalTemp_5 { get { return _temp_fFinalTemp_5; } set { if (_temp_fFinalTemp_5 != value) { _temp_fFinalTemp_5 = value; OnPropertyChanged("temp_fFinalTemp_5"); } } }

        string _temp_fFinalTemp_6;
        public string temp_fFinalTemp_6 { get { return _temp_fFinalTemp_6; } set { if (_temp_fFinalTemp_6 != value) { _temp_fFinalTemp_6 = value; OnPropertyChanged("temp_fFinalTemp_6"); } } }

        string _temp_fFinalTime_1;
        public string temp_fFinalTime_1 { get { return _temp_fFinalTime_1; } set { if (_temp_fFinalTime_1 != value) { _temp_fFinalTime_1 = value; OnPropertyChanged("temp_fFinalTime_1"); } } }

        string _temp_fFinalTime_2;
        public string temp_fFinalTime_2 { get { return _temp_fFinalTime_2; } set { if (_temp_fFinalTime_2 != value) { _temp_fFinalTime_2 = value; OnPropertyChanged("temp_fFinalTime_2"); } } }

        string _temp_fFinalTime_3;
        public string temp_fFinalTime_3 { get { return _temp_fFinalTime_3; } set { if (_temp_fFinalTime_3 != value) { _temp_fFinalTime_3 = value; OnPropertyChanged("temp_fFinalTime_3"); } } }

        string _temp_fFinalTime_4;
        public string temp_fFinalTime_4 { get { return _temp_fFinalTime_4; } set { if (_temp_fFinalTime_4 != value) { _temp_fFinalTime_4 = value; OnPropertyChanged("temp_fFinalTime_4"); } } }

        string _temp_fFinalTime_5;
        public string temp_fFinalTime_5 { get { return _temp_fFinalTime_5; } set { if (_temp_fFinalTime_5 != value) { _temp_fFinalTime_5 = value; OnPropertyChanged("temp_fFinalTime_5"); } } }

        string _temp_fFinalTime_6;
        public string temp_fFinalTime_6 { get { return _temp_fFinalTime_6; } set { if (_temp_fFinalTime_6 != value) { _temp_fFinalTime_6 = value; OnPropertyChanged("temp_fFinalTime_6"); } } }

        #endregion Temp Program -> On-Column Only

        #region Flow Program

        //string _flow_fRate_1;
        //public string flow_fRate_1 { get { return _flow_fRate_1; } set { _flow_fRate_1 = value; OnPropertyChanged("flow_fRate_1"); } }

        string _flow_fRate_2;
        public string flow_fRate_2 { get { return _flow_fRate_2; } set { if (_flow_fRate_2 != value) { _flow_fRate_2 = value; OnPropertyChanged("flow_fRate_2"); } } }

        string _flow_fRate_3;
        public string flow_fRate_3 { get { return _flow_fRate_3; } set { if (_flow_fRate_3 != value) { _flow_fRate_3 = value; OnPropertyChanged("flow_fRate_3"); } } }

        string _flow_fRate_4;
        public string flow_fRate_4 { get { return _flow_fRate_4; } set { if (_flow_fRate_4 != value) { _flow_fRate_4 = value; OnPropertyChanged("flow_fRate_4"); } } }

        string _flow_fRate_5;
        public string flow_fRate_5 { get { return _flow_fRate_5; } set { if (_flow_fRate_5 != value) { _flow_fRate_5 = value; OnPropertyChanged("flow_fRate_5"); } } }

        string _flow_fRate_6;
        public string flow_fRate_6 { get { return _flow_fRate_6; } set { if (_flow_fRate_6 != value) { _flow_fRate_6 = value; OnPropertyChanged("flow_fRate_6"); } } }

        string _flow_fFinalFlow_1;
        public string flow_fFinalFlow_1 { get { return _flow_fFinalFlow_1; } set { if (_flow_fFinalFlow_1 != value) { _flow_fFinalFlow_1 = value; OnPropertyChanged("flow_fFinalFlow_1"); } } }

        string _flow_fFinalFlow_2;
        public string flow_fFinalFlow_2 { get { return _flow_fFinalFlow_2; } set { if (_flow_fFinalFlow_2 != value) { _flow_fFinalFlow_2 = value; OnPropertyChanged("flow_fFinalFlow_2"); } } }

        string _flow_fFinalFlow_3;
        public string flow_fFinalFlow_3 { get { return _flow_fFinalFlow_3; } set { if (_flow_fFinalFlow_3 != value) { _flow_fFinalFlow_3 = value; OnPropertyChanged("flow_fFinalFlow_3"); } } }

        string _flow_fFinalFlow_4;
        public string flow_fFinalFlow_4 { get { return _flow_fFinalFlow_4; } set { if (_flow_fFinalFlow_4 != value) { _flow_fFinalFlow_4 = value; OnPropertyChanged("flow_fFinalFlow_4"); } } }

        string _flow_fFinalFlow_5;
        public string flow_fFinalFlow_5 { get { return _flow_fFinalFlow_5; } set { if (_flow_fFinalFlow_5 != value) { _flow_fFinalFlow_5 = value; OnPropertyChanged("flow_fFinalFlow_5"); } } }

        string _flow_fFinalFlow_6;
        public string flow_fFinalFlow_6 { get { return _flow_fFinalFlow_6; } set { if (_flow_fFinalFlow_6 != value) { _flow_fFinalFlow_6 = value; OnPropertyChanged("flow_fFinalFlow_6"); } } }

        string _flow_fFinalTime_1;
        public string flow_fFinalTime_1 { get { return _flow_fFinalTime_1; } set { if (_flow_fFinalTime_1 != value) { _flow_fFinalTime_1 = value; OnPropertyChanged("flow_fFinalTime_1"); } } }

        string _flow_fFinalTime_2;
        public string flow_fFinalTime_2 { get { return _flow_fFinalTime_2; } set { if (_flow_fFinalTime_2 != value) { _flow_fFinalTime_2 = value; OnPropertyChanged("flow_fFinalTime_2"); } } }

        string _flow_fFinalTime_3;
        public string flow_fFinalTime_3 { get { return _flow_fFinalTime_3; } set { if (_flow_fFinalTime_3 != value) { _flow_fFinalTime_3 = value; OnPropertyChanged("flow_fFinalTime_3"); } } }

        string _flow_fFinalTime_4;
        public string flow_fFinalTime_4 { get { return _flow_fFinalTime_4; } set { if (_flow_fFinalTime_4 != value) { _flow_fFinalTime_4 = value; OnPropertyChanged("flow_fFinalTime_4"); } } }

        string _flow_fFinalTime_5;
        public string flow_fFinalTime_5 { get { return _flow_fFinalTime_5; } set { if (_flow_fFinalTime_5 != value) { _flow_fFinalTime_5 = value; OnPropertyChanged("flow_fFinalTime_5"); } } }

        string _flow_fFinalTime_6;
        public string flow_fFinalTime_6 { get { return _flow_fFinalTime_6; } set { if (_flow_fFinalTime_6 != value) { _flow_fFinalTime_6 = value; OnPropertyChanged("flow_fFinalTime_6"); } } }

        #endregion Flow Program 

        #region Press Program 

        //string _press_fRate_1;
        //public string press_fRate_1 { get { return _press_fRate_1; } set { _press_fRate_1 = value; OnPropertyChanged("press_fRate_1"); } }

        string _press_fRate_2;
        public string press_fRate_2 { get { return _press_fRate_2; } set { if (_press_fRate_2 != value) { _press_fRate_2 = value; OnPropertyChanged("press_fRate_2"); } } }

        string _press_fRate_3;
        public string press_fRate_3 { get { return _press_fRate_3; } set { if (_press_fRate_3 != value) { _press_fRate_3 = value; OnPropertyChanged("press_fRate_3"); } } }

        string _press_fRate_4;
        public string press_fRate_4 { get { return _press_fRate_4; } set { if (_press_fRate_4 != value) { _press_fRate_4 = value; OnPropertyChanged("press_fRate_4"); } } }

        string _press_fRate_5;
        public string press_fRate_5 { get { return _press_fRate_5; } set { if (_press_fRate_5 != value) { _press_fRate_5 = value; OnPropertyChanged("press_fRate_5"); } } }

        string _press_fRate_6;
        public string press_fRate_6 { get { return _press_fRate_6; } set { if (_press_fRate_6 != value) { _press_fRate_6 = value; OnPropertyChanged("press_fRate_6"); } } }

        string _press_fFinalPress_1;
        public string press_fFinalPress_1 { get { return _press_fFinalPress_1; } set { if (_press_fFinalPress_1 != value) { _press_fFinalPress_1 = value; OnPropertyChanged("press_fFinalPress_1"); } } }

        string _press_fFinalPress_2;
        public string press_fFinalPress_2 { get { return _press_fFinalPress_2; } set { if (_press_fFinalPress_2 != value) { _press_fFinalPress_2 = value; OnPropertyChanged("press_fFinalPress_2"); } } }

        string _press_fFinalPress_3;
        public string press_fFinalPress_3 { get { return _press_fFinalPress_3; } set { if (_press_fFinalPress_3 != value) { _press_fFinalPress_3 = value; OnPropertyChanged("press_fFinalPress_3"); } } }

        string _press_fFinalPress_4;
        public string press_fFinalPress_4 { get { return _press_fFinalPress_4; } set { if (_press_fFinalPress_4 != value) { _press_fFinalPress_4 = value; OnPropertyChanged("press_fFinalPress_4"); } } }

        string _press_fFinalPress_5;
        public string press_fFinalPress_5 { get { return _press_fFinalPress_5; } set { if (_press_fFinalPress_5 != value) { _press_fFinalPress_5 = value; OnPropertyChanged("press_fFinalPress_5"); } } }

        string _press_fFinalPress_6;
        public string press_fFinalPress_6 { get { return _press_fFinalPress_6; } set { if (_press_fFinalPress_6 != value) { _press_fFinalPress_6 = value; OnPropertyChanged("press_fFinalPress_6"); } } }

        string _press_fFinalTime_1;
        public string press_fFinalTime_1 { get { return _press_fFinalTime_1; } set { if (_press_fFinalTime_1 != value) { _press_fFinalTime_1 = value; OnPropertyChanged("press_fFinalTime_1"); } } }

        string _press_fFinalTime_2;
        public string press_fFinalTime_2 { get { return _press_fFinalTime_2; } set { if (_press_fFinalTime_2 != value) { _press_fFinalTime_2 = value; OnPropertyChanged("press_fFinalTime_2"); } } }

        string _press_fFinalTime_3;
        public string press_fFinalTime_3 { get { return _press_fFinalTime_3; } set { if (_press_fFinalTime_3 != value) { _press_fFinalTime_3 = value; OnPropertyChanged("press_fFinalTime_3"); } } }

        string _press_fFinalTime_4;
        public string press_fFinalTime_4 { get { return _press_fFinalTime_4; } set { if (_press_fFinalTime_4 != value) { _press_fFinalTime_4 = value; OnPropertyChanged("press_fFinalTime_4"); } } }

        string _press_fFinalTime_5;
        public string press_fFinalTime_5 { get { return _press_fFinalTime_5; } set { if (_press_fFinalTime_5 != value) { _press_fFinalTime_5 = value; OnPropertyChanged("press_fFinalTime_5"); } } }

        string _press_fFinalTime_6;
        public string press_fFinalTime_6 { get { return _press_fFinalTime_6; } set { if (_press_fFinalTime_6 != value) { _press_fFinalTime_6 = value; OnPropertyChanged("press_fFinalTime_6"); } } }

        #endregion Press Program 

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
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //
        }

        #endregion KeyPad : CancelCommand

        #region KeyPad : DeleteCommand

        public RelayCommand KeyPadDeleteCommand { get; set; }
        private void KeyPadDeleteCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

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
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

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
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TEMPERATURE:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_COLUMN_FLOW:
                        {
                            ValidateAndSetColumnFlow(tempFloatVal);
                            fColumnFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fColumnFlowSet = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTotalFlowSet = float.Parse(fTotalFlowSet);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fSplitFlowSet = float.Parse(fSplitFlowSet);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.iSplitratio = short.Parse(iSplitratio);

                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;

                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PRESSURE:
                        {
                            fPressureSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fPressureSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TOTAL_FLOW:
                        {
                            ValidateAndSetTotalFlow(tempFloatVal);
                            fTotalFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTotalFlowSet = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fSplitFlowSet = float.Parse(fSplitFlowSet);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.iSplitratio = short.Parse(iSplitratio);

                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_FLOW:
                        {
                            ValidateAndSetSplitFlow(tempFloatVal);
                            fSplitFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTotalFlowSet = float.Parse(fTotalFlowSet);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fSplitFlowSet = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.iSplitratio = short.Parse(iSplitratio);

                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_RATIO:
                        {
                            ValidateAndSetSplitRatio((int)tempFloatVal);
                            iSplitratio = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.iSplitratio = (short)tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PULSED_PRESSURE:
                        {
                            fPulsed_FlowPressSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fPulsed_FlowPressSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PULSED_TIME:
                        {
                            fPulsed_Time = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fPulsed_Time = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_ON_TIME:
                        {
                            fSplitOnTime = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fSplitOnTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    #region Front Programed Pressure

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_2:
                        {

                            press_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_3:
                        {
                            press_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_4:
                        {
                            press_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_5:
                        {
                            press_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_6:
                        {
                            press_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1:
                        {
                            press_fFinalPress_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[0].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2:
                        {
                            press_fFinalPress_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[1].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3:
                        {
                            press_fFinalPress_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[2].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4:
                        {
                            press_fFinalPress_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[3].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5:
                        {
                            press_fFinalPress_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[4].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6:
                        {
                            press_fFinalPress_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[5].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1:
                        {
                            press_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2:
                        {
                            press_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3:
                        {
                            press_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4:
                        {
                            press_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5:
                        {
                            press_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6:
                        {
                            press_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.presPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Front Programed Pressure

                    #region Front Programed Flow

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_2:
                        {
                            flow_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_3:
                        {
                            flow_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_4:
                        {
                            flow_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_5:
                        {
                            flow_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_6:
                        {
                            flow_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1:
                        {
                            flow_fFinalFlow_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[0].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2:
                        {
                            flow_fFinalFlow_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[1].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3:
                        {
                            flow_fFinalFlow_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[2].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4:
                        {
                            flow_fFinalFlow_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[3].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5:
                        {
                            flow_fFinalFlow_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[4].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6:
                        {
                            flow_fFinalFlow_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[5].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1:
                        {
                            flow_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2:
                        {
                            flow_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3:
                        {
                            flow_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4:
                        {
                            flow_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5:
                        {
                            flow_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6:
                        {
                            flow_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.flowPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Front Programed Flow

                    #region Front Programed Temperature

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_2:
                        {
                            temp_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_3:
                        {
                            temp_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_4:
                        {
                            temp_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_5:
                        {
                            temp_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_6:
                        {
                            temp_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1:
                        {
                            temp_fFinalTemp_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[0].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2:
                        {
                            temp_fFinalTemp_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[1].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3:
                        {
                            temp_fFinalTemp_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[2].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4:
                        {
                            temp_fFinalTemp_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[3].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5:
                        {
                            temp_fFinalTemp_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[4].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6:
                        {
                            temp_fFinalTemp_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[5].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1:
                        {
                            temp_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2:
                        {
                            temp_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3:
                        {
                            temp_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4:
                        {
                            temp_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5:
                        {
                            temp_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6:
                        {
                            temp_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.tempPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Front Programed Temperature

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TEMPERATURE:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_COLUMN_FLOW:
                        {
                            ValidateAndSetColumnFlow(tempFloatVal);
                            fColumnFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fColumnFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PRESSURE:
                        {
                            fPressureSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fPressureSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TOTAL_FLOW:
                        {
                            ValidateAndSetTotalFlow(tempFloatVal);
                            fTotalFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTotalFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_FLOW:
                        {
                            ValidateAndSetSplitFlow(tempFloatVal);
                            fSplitFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fSplitFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_RATIO:
                        {
                            ValidateAndSetSplitRatio((int)tempFloatVal);
                            iSplitratio = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.iSplitratio = (short)tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PULSED_PRESSURE:
                        {
                            fPulsed_FlowPressSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fPulsed_FlowPressSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PULSED_TIME:
                        {
                            fPulsed_Time = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fPulsed_Time = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_ON_TIME:
                        {
                            fSplitOnTime = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fSplitOnTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    #region Center Programed Pressure

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_2:
                        {

                            press_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_3:
                        {
                            press_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_4:
                        {
                            press_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_5:
                        {
                            press_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_6:
                        {
                            press_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1:
                        {
                            press_fFinalPress_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[0].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2:
                        {
                            press_fFinalPress_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[1].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3:
                        {
                            press_fFinalPress_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[2].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4:
                        {
                            press_fFinalPress_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[3].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5:
                        {
                            press_fFinalPress_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[4].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6:
                        {
                            press_fFinalPress_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[5].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1:
                        {
                            press_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2:
                        {
                            press_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3:
                        {
                            press_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4:
                        {
                            press_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5:
                        {
                            press_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6:
                        {
                            press_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.presPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Center Programed Pressure

                    #region Center Programed Flow

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_2:
                        {
                            flow_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_3:
                        {
                            flow_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_4:
                        {
                            flow_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_5:
                        {
                            flow_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_6:
                        {
                            flow_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1:
                        {
                            flow_fFinalFlow_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[0].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2:
                        {
                            flow_fFinalFlow_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[1].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3:
                        {
                            flow_fFinalFlow_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[2].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4:
                        {
                            flow_fFinalFlow_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[3].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5:
                        {
                            flow_fFinalFlow_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[4].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6:
                        {
                            flow_fFinalFlow_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[5].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1:
                        {
                            flow_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2:
                        {
                            flow_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3:
                        {
                            flow_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4:
                        {
                            flow_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5:
                        {
                            flow_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6:
                        {
                            flow_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.flowPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Center Programed Flow

                    #region Center Programed Temperature

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_2:
                        {
                            temp_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_3:
                        {
                            temp_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_4:
                        {
                            temp_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_5:
                        {
                            temp_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_6:
                        {
                            temp_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1:
                        {
                            temp_fFinalTemp_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[0].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2:
                        {
                            temp_fFinalTemp_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[1].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3:
                        {
                            temp_fFinalTemp_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[2].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4:
                        {
                            temp_fFinalTemp_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[3].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5:
                        {
                            temp_fFinalTemp_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[4].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6:
                        {
                            temp_fFinalTemp_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[5].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1:
                        {
                            temp_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2:
                        {
                            temp_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3:
                        {
                            temp_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4:
                        {
                            temp_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5:
                        {
                            temp_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6:
                        {
                            temp_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.tempPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Center Programed Temperature

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TEMPERATURE:
                        {
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_COLUMN_FLOW:
                        {
                            ValidateAndSetColumnFlow(tempFloatVal);
                            fColumnFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fColumnFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PRESSURE:
                        {
                            fPressureSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fPressureSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TOTAL_FLOW:
                        {
                            ValidateAndSetTotalFlow(tempFloatVal);
                            fTotalFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTotalFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_FLOW:
                        {
                            ValidateAndSetSplitFlow(tempFloatVal);
                            fSplitFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fSplitFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_RATIO:
                        {
                            ValidateAndSetSplitRatio((int)tempFloatVal);
                            iSplitratio = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_0);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.iSplitratio = (short)tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PULSED_PRESSURE:
                        {
                            fPulsed_FlowPressSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fPulsed_FlowPressSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PULSED_TIME:
                        {
                            fPulsed_Time = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fPulsed_Time = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_ON_TIME:
                        {
                            fSplitOnTime = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fSplitOnTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    #region Rear Programed Pressure

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_2:
                        {

                            press_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_3:
                        {
                            press_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_4:
                        {
                            press_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_5:
                        {
                            press_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_6:
                        {
                            press_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1:
                        {
                            press_fFinalPress_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[0].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2:
                        {
                            press_fFinalPress_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[1].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3:
                        {
                            press_fFinalPress_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[2].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4:
                        {
                            press_fFinalPress_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[3].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5:
                        {
                            press_fFinalPress_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[4].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6:
                        {
                            press_fFinalPress_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[5].fFinalPress = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1:
                        {
                            press_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2:
                        {
                            press_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3:
                        {
                            press_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4:
                        {
                            press_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5:
                        {
                            press_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6:
                        {
                            press_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.presPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Rear Programed Pressure

                    #region Rear Programed Flow

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_2:
                        {
                            flow_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_3:
                        {
                            flow_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_4:
                        {
                            flow_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_5:
                        {
                            flow_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_6:
                        {
                            flow_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1:
                        {
                            flow_fFinalFlow_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[0].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2:
                        {
                            flow_fFinalFlow_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[1].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3:
                        {
                            flow_fFinalFlow_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[2].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4:
                        {
                            flow_fFinalFlow_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[3].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5:
                        {
                            flow_fFinalFlow_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[4].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6:
                        {
                            flow_fFinalFlow_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[5].fFinalFlow = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1:
                        {
                            flow_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2:
                        {
                            flow_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3:
                        {
                            flow_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4:
                        {
                            flow_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5:
                        {
                            flow_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6:
                        {
                            flow_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.flowPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    #endregion Rear Programed Flow

                    #region Rear Programed Temperature

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_2:
                        {
                            temp_fRate_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[1].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_3:
                        {
                            temp_fRate_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[2].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_4:
                        {
                            temp_fRate_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[3].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_5:
                        {
                            temp_fRate_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[4].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_6:
                        {
                            temp_fRate_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[5].fRate = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1:
                        {
                            temp_fFinalTemp_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[0].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2:
                        {
                            temp_fFinalTemp_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[1].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3:
                        {
                            temp_fFinalTemp_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[2].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4:
                        {
                            temp_fFinalTemp_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[3].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5:
                        {
                            temp_fFinalTemp_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[4].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6:
                        {
                            temp_fFinalTemp_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[5].fFinalTemp = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1:
                        {
                            temp_fFinalTime_1 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[0].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2:
                        {
                            temp_fFinalTime_2 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[1].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3:
                        {
                            temp_fFinalTime_3 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[2].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4:
                        {
                            temp_fFinalTime_4 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[3].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5:
                        {
                            temp_fFinalTime_5 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[4].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6:
                        {
                            temp_fFinalTime_6 = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.tempPrgm[5].fFinalTime = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                        #endregion Rear Programed Temperature
                }
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;

            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //
        }

        #endregion KeyPad : ApplyCommand

        #region KeyPad : OnCommand

        public RelayCommand KeyPadOnCommand { get; set; }
        private void KeyPadOnCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
            float tempFloatVal = 0;
            if (float.TryParse(mainVM.ViewModel_KeyPad.CurrentValue, out tempFloatVal))
            {
                switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
                {
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TEMPERATURE:
                        {
                            fTempOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTempOnoff = _fTempOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            #endregion

                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_COLUMN_FLOW:
                        {
                            fColumnFlowOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fColumnFlowOnoff = _fColumnFlowOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            ValidateAndSetColumnFlow(tempFloatVal);
                            fColumnFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fColumnFlowSet = tempFloatVal;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTotalFlowSet = float.Parse(fTotalFlowSet);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fSplitFlowSet = float.Parse(fSplitFlowSet);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.iSplitratio = short.Parse(iSplitratio);

                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PRESSURE:
                        {
                            fPressureOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fPressureOnoff = _fPressureOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fPressureSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fPressureSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    //case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TOTAL_FLOW:
                    //    {
                    //        fTotalFlowOnoff = true;
                    //        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTotalFlowOnoff = fTotalFlowOnoff ? (byte)1 : (byte)0;
                    //        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                    //        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    //    }
                    //    break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TEMPERATURE:
                        {
                            fTempOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTempOnoff = _fTempOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            #endregion
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_COLUMN_FLOW:
                        {
                            fColumnFlowOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fColumnFlowOnoff = _fColumnFlowOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            ValidateAndSetColumnFlow(tempFloatVal);
                            fColumnFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fColumnFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PRESSURE:
                        {
                            fPressureOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fPressureOnoff = _fPressureOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fPressureSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fPressureSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    //case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TOTAL_FLOW:
                    //    {
                    //        fTotalFlowOnoff = true;
                    //        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTotalFlowOnoff = fTotalFlowOnoff ? (byte)1 : (byte)0;
                    //        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                    //        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    //    }
                    //    break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TEMPERATURE:
                        {
                            fTempOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTempOnoff = _fTempOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fTempSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTempSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            #endregion
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_COLUMN_FLOW:
                        {
                            fColumnFlowOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fColumnFlowOnoff = _fColumnFlowOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            ValidateAndSetColumnFlow(tempFloatVal);
                            fColumnFlowSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_2);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fColumnFlowSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            #endregion
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PRESSURE:
                        {
                            fPressureOnoff = true;
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fPressureOnoff = _fPressureOnoff ? (byte)1 : (byte)0;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                            #region 210402 권민경 OnCommand 시에 현재 설정값으로 On 되게끔
                            fPressureSet = tempFloatVal.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_3);
                            DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fPressureSet = tempFloatVal;
                            tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                            #endregion

                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                        //case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TOTAL_FLOW:
                        //    {
                        //        fTotalFlowOnoff = true;
                        //        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTotalFlowOnoff = fTotalFlowOnoff ? (byte)1 : (byte)0;
                        //        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                        //        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        //    }
                        //    break;
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
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

            switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
            {
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TEMPERATURE:
                    {
                        fTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTempOnoff = _fTempOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_COLUMN_FLOW:
                    {
                        fColumnFlowOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fColumnFlowOnoff = _fColumnFlowOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PRESSURE:
                    {
                        fPressureOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fPressureOnoff = _fPressureOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                //case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TOTAL_FLOW:
                //    {
                //        fTotalFlowOnoff = false;
                //        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.fTotalFlowOnoff = fTotalFlowOnoff ? (byte)1 : (byte)0;
                //        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));

                //        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                //        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                //    }
                //    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TEMPERATURE:
                    {
                        fTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTempOnoff = _fTempOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_COLUMN_FLOW:
                    {
                        fColumnFlowOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fColumnFlowOnoff = _fColumnFlowOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PRESSURE:
                    {
                        fPressureOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fPressureOnoff = _fPressureOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                //case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TOTAL_FLOW:
                //    {
                //        fTotalFlowOnoff = false;
                //        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.fTotalFlowOnoff = fTotalFlowOnoff ? (byte)1 : (byte)0;
                //        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));

                //        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                //        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                //    }
                //    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TEMPERATURE:
                    {
                        fTempOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTempOnoff = _fTempOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_COLUMN_FLOW:
                    {
                        fColumnFlowOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fColumnFlowOnoff = _fColumnFlowOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PRESSURE:
                    {
                        fPressureOnoff = false;
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fPressureOnoff = _fPressureOnoff ? (byte)1 : (byte)0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    }
                    break;
                    //case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TOTAL_FLOW:
                    //    {
                    //        fTotalFlowOnoff = false;
                    //        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.fTotalFlowOnoff = fTotalFlowOnoff ? (byte)1 : (byte)0;
                    //        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));

                    //        mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
                    //        //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                    //    }
                    //    break;
            }
        }

        #endregion KeyPad : OffCommand

        #region KeyPad : KeyPadClickCommand

        public RelayCommand KeyPadKeyPadClickCommand { get; set; }
        private void KeyPadKeyPadClickCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
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
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TEMPERATURE:
                    {
                        vmKeyPad.Title = "Temperature";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        //if (_fTempOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fTempSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TEMPERATURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_COLUMN_FLOW:
                    {
                        vmKeyPad.Title = "Column Flow";
                        vmKeyPad.MaxValue = 30;
                        //if (_fColumnFlowOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fColumnFlowSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fColumnFlowSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_COLUMN_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PRESSURE:
                    {
                        vmKeyPad.Title = "Pressure";
                        vmKeyPad.MaxValue = 150;
                        //if (_fPressureOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fPressureSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fPressureSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PRESSURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TOTAL_FLOW:
                    {
                        vmKeyPad.Title = "Total Flow";
                        vmKeyPad.MaxValue = 1000;

                        vmKeyPad.CurrentValue = fTotalFlowSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_TOTAL_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_FLOW:
                    {
                        vmKeyPad.Title = "Split Flow";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fSplitFlowSet;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_RATIO:
                    {
                        vmKeyPad.Title = "Split Ratio";
                        vmKeyPad.MaxValue = 7500;
                        vmKeyPad.CurrentValue = iSplitratio;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_RATIO;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PULSED_PRESSURE:
                    {
                        vmKeyPad.Title = "Pulsed Pressure";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = fPulsed_FlowPressSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PULSED_PRESSURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_ON_TIME:
                    {
                        vmKeyPad.Title = "Split on Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fSplitOnTime;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_SPLIT_ON_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PULSED_TIME:
                    {
                        vmKeyPad.Title = "Pulsed Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fPulsed_Time;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PULSED_TIME;
                    }
                    break;
                #region Front Programed Pressure

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1:
                    {
                        vmKeyPad.Title = "Press Init";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2:
                    {
                        vmKeyPad.Title = "Press 1";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3:
                    {
                        vmKeyPad.Title = "Press 2";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4:
                    {
                        vmKeyPad.Title = "Press 3";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5:
                    {
                        vmKeyPad.Title = "Press 4";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6:
                    {
                        vmKeyPad.Title = "Press 5";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6;
                    }
                    break;
                #endregion Front Programed Pressure

                #region Front Programed Flow

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1:
                    {
                        vmKeyPad.Title = "Flow Init";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2:
                    {
                        vmKeyPad.Title = "Flow 1";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3:
                    {
                        vmKeyPad.Title = "Flow 2";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4:
                    {
                        vmKeyPad.Title = "Flow 3";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5:
                    {
                        vmKeyPad.Title = "Flow 4";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6:
                    {
                        vmKeyPad.Title = "Flow 5";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6;
                    }
                    break;
                #endregion Front Programed Flow

                #region Front Programed Temperature

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1:
                    {
                        vmKeyPad.Title = "Temp Init";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2:
                    {
                        vmKeyPad.Title = "Temp 1";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3:
                    {
                        vmKeyPad.Title = "Temp 2";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4:
                    {
                        vmKeyPad.Title = "Temp 3";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5:
                    {
                        vmKeyPad.Title = "Temp 4";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6:
                    {
                        vmKeyPad.Title = "Temp 5";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_FRONT_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6;
                    }
                    break;
                #endregion Front Programed Temperature

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TEMPERATURE:
                    {
                        vmKeyPad.Title = "Temperature";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        //if (_fTempOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fTempSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TEMPERATURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_COLUMN_FLOW:
                    {
                        vmKeyPad.Title = "Column Flow";
                        vmKeyPad.MaxValue = 30;
                        //if (_fColumnFlowOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fColumnFlowSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fColumnFlowSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_COLUMN_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PRESSURE:
                    {
                        vmKeyPad.Title = "Pressure";
                        vmKeyPad.MaxValue = 150;
                        //if (_fPressureOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fPressureSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fPressureSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PRESSURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TOTAL_FLOW:
                    {
                        vmKeyPad.Title = "Total Flow";
                        vmKeyPad.MaxValue = 1000;

                        vmKeyPad.CurrentValue = fTotalFlowSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_TOTAL_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_FLOW:
                    {
                        vmKeyPad.Title = "Split Flow";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fSplitFlowSet;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_RATIO:
                    {
                        vmKeyPad.Title = "Split Ratio";
                        vmKeyPad.MaxValue = 7500;
                        vmKeyPad.CurrentValue = iSplitratio;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_RATIO;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PULSED_PRESSURE:
                    {
                        vmKeyPad.Title = "Pulsed Pressure";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = fPulsed_FlowPressSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PULSED_PRESSURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_ON_TIME:
                    {
                        vmKeyPad.Title = "Split on Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fSplitOnTime;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_SPLIT_ON_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PULSED_TIME:
                    {
                        vmKeyPad.Title = "Pulsed Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fPulsed_Time;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PULSED_TIME;
                    }
                    break;

                #region Center Programed Pressure

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1:
                    {
                        vmKeyPad.Title = "Press Init";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2:
                    {
                        vmKeyPad.Title = "Press 1";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3:
                    {
                        vmKeyPad.Title = "Press 2";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4:
                    {
                        vmKeyPad.Title = "Press 3";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5:
                    {
                        vmKeyPad.Title = "Press 4";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6:
                    {
                        vmKeyPad.Title = "Press 5";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6;
                    }
                    break;
                #endregion Center Programed Pressure

                #region Center Programed Flow

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1:
                    {
                        vmKeyPad.Title = "Flow Init";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2:
                    {
                        vmKeyPad.Title = "Flow 1";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3:
                    {
                        vmKeyPad.Title = "Flow 2";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4:
                    {
                        vmKeyPad.Title = "Flow 3";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5:
                    {
                        vmKeyPad.Title = "Flow 4";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6:
                    {
                        vmKeyPad.Title = "Flow 5";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6;
                    }
                    break;
                #endregion Center Programed Flow

                #region Center Programed Temperature

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1:
                    {
                        vmKeyPad.Title = "Temp Init";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2:
                    {
                        vmKeyPad.Title = "Temp 1";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3:
                    {
                        vmKeyPad.Title = "Temp 2";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4:
                    {
                        vmKeyPad.Title = "Temp 3";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5:
                    {
                        vmKeyPad.Title = "Temp 4";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6:
                    {
                        vmKeyPad.Title = "Temp 5";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_CENTER_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6;
                    }
                    break;
                #endregion Center Programed Temperature
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TEMPERATURE:
                    {
                        vmKeyPad.Title = "Temperature";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        //if (_fTempOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fTempSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fTempSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TEMPERATURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_COLUMN_FLOW:
                    {
                        vmKeyPad.Title = "Column Flow";
                        vmKeyPad.MaxValue = 30;
                        //if (_fColumnFlowOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fColumnFlowSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fColumnFlowSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_COLUMN_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PRESSURE:
                    {
                        vmKeyPad.Title = "Pressure";
                        vmKeyPad.MaxValue = 150;
                        //if (_fPressureOnoff)
                        //{
                        //    vmKeyPad.CurrentValue = fPressureSet;
                        //}
                        //else
                        //    vmKeyPad.CurrentValue = "Off";
                        vmKeyPad.CurrentValue = fPressureSet; //20210405 권민경 Off일때도 CurrentValue에 표시(On하면 바로 켜지게)
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PRESSURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TOTAL_FLOW:
                    {
                        vmKeyPad.Title = "Total Flow";
                        vmKeyPad.MaxValue = 1000;

                        vmKeyPad.CurrentValue = fTotalFlowSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_TOTAL_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_FLOW:
                    {
                        vmKeyPad.Title = "Split Flow";
                        vmKeyPad.MaxValue = 1000;
                        vmKeyPad.CurrentValue = fSplitFlowSet;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_FLOW;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_RATIO:
                    {
                        vmKeyPad.Title = "Split Ratio";
                        vmKeyPad.MaxValue = 7500;
                        vmKeyPad.CurrentValue = iSplitratio;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_RATIO;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PULSED_PRESSURE:
                    {
                        vmKeyPad.Title = "Pulsed Pressure";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = fPulsed_FlowPressSet;

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PULSED_PRESSURE;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_ON_TIME:
                    {
                        vmKeyPad.Title = "Split on Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fSplitOnTime;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_SPLIT_ON_TIME;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PULSED_TIME:
                    {
                        vmKeyPad.Title = "Pulsed Time";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = fPulsed_Time;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PULSED_TIME;
                    }
                    break;
                #region Rear Programed Pressure

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = press_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1:
                    {
                        vmKeyPad.Title = "Press Init";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2:
                    {
                        vmKeyPad.Title = "Press 1";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3:
                    {
                        vmKeyPad.Title = "Press 2";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4:
                    {
                        vmKeyPad.Title = "Press 3";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5:
                    {
                        vmKeyPad.Title = "Press 4";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6:
                    {
                        vmKeyPad.Title = "Press 5";
                        vmKeyPad.MaxValue = 150;
                        vmKeyPad.CurrentValue = press_fFinalPress_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_PRESS_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = press_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_PRESSURE_FINAL_TIME_6;
                    }
                    break;
                #endregion Rear Programed Pressure

                #region Rear Programed Flow

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1:
                    {
                        vmKeyPad.Title = "Flow Init";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2:
                    {
                        vmKeyPad.Title = "Flow 1";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3:
                    {
                        vmKeyPad.Title = "Flow 2";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4:
                    {
                        vmKeyPad.Title = "Flow 3";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5:
                    {
                        vmKeyPad.Title = "Flow 4";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6:
                    {
                        vmKeyPad.Title = "Flow 5";
                        vmKeyPad.MaxValue = 30;
                        vmKeyPad.CurrentValue = flow_fFinalFlow_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_FLOW_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = flow_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_FLOW_FINAL_TIME_6;
                    }
                    break;
                #endregion Rear Programed Flow

                #region Rear Programed Temperature

                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_2:
                    {
                        vmKeyPad.Title = "Rate 1";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_3:
                    {
                        vmKeyPad.Title = "Rate 2";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_4:
                    {
                        vmKeyPad.Title = "Rate 3";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_5:
                    {
                        vmKeyPad.Title = "Rate 4";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_6:
                    {
                        vmKeyPad.Title = "Rate 5";
                        vmKeyPad.MaxValue = 100;
                        vmKeyPad.CurrentValue = temp_fRate_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_RATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1:
                    {
                        vmKeyPad.Title = "Temp Init";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2:
                    {
                        vmKeyPad.Title = "Temp 1";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3:
                    {
                        vmKeyPad.Title = "Temp 2";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4:
                    {
                        vmKeyPad.Title = "Temp 3";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5:
                    {
                        vmKeyPad.Title = "Temp 4";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6:
                    {
                        vmKeyPad.Title = "Temp 5";
                        vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                        vmKeyPad.CurrentValue = temp_fFinalTemp_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TEMPERATURE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1:
                    {
                        vmKeyPad.Title = "Time Init";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_1;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_2;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_3;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_4;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_5;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.MaxValue = 9999;
                        vmKeyPad.CurrentValue = temp_fFinalTime_6;
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.INLET_REAR_SETTING_PROGRAMMED_TEMPERATURE_FINAL_TIME_6;
                    }
                    break;
                    #endregion Rear Programed Temperature
            }



            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #region InletInjectionModeIndexChangeCommand
        public RelayCommand InletInjectionModeIndexChangeCommand { get; set; }
        private void InletInjectionModeIndexChangeCommandAction(object title)
        {           
            switch (title.ToString())
            {
                case "Front Inlet":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.btInjMode = btInjMode;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                    }
                    break;
                case "Center Inlet":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.btInjMode = btInjMode;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Inlet":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.btInjMode = btInjMode;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("InletInjectionModeIndexChangeCommand Fired");
        }
        #endregion InletInjectionModeIndexChangeCommand 

        #region TempModeIndexChangeCommand
        public RelayCommand TempModeIndexChangeCommand { get; set; }
        private void TempModeIndexChangeCommandAction(object title)
        {
            switch (title.ToString())
            {
                case "Front Inlet":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet.btTempMode = btTempMode;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front.packet));
                    }
                    break;
                case "Center Inlet":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet.btTempMode = btTempMode;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center.packet));
                    }
                    break;
                case "Rear Inlet":
                    {
                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet.btTempMode = btTempMode;
                        tcpManager.Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(
             DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("TempModeIndexChangeCommand Fired");
        }
        #endregion TempModeIndexChangeCommand 

        #region Navigation_NextCommand
        public RelayCommand Navigation_NextCommand { get; set; }
        private void Navigation_NextCommandAction(object param)
        {
            IsFirstPage = false;

            //TODO :             
            Debug.WriteLine("Navigation_NextCommand Fired");
        }
        #endregion Navigation_NextCommand 

        #region Navigation_PrevCommand
        public RelayCommand Navigation_PrevCommand { get; set; }
        private void Navigation_PrevCommandAction(object param)
        {
            IsFirstPage = true;

            //TODO :             
            Debug.WriteLine("Navigation_PrevCommand Fired");
        }
        #endregion AuxAPC1_OnCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        void SetTemp()
        {
            if (_fTempOnoff == false)
            {
                DisplayString_fTempSet = "Off";
            }
            else
                DisplayString_fTempSet = fTempSet;
        }

        void SetColumnFlow()
        {
            switch (_ApcMode)
            {
                case 0:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Constant Flow";

                        if (_fColumnFlowOnoff == true)
                            DisplayString_fColumnFlowSet = fColumnFlowSet;
                        else DisplayString_fColumnFlowSet = "Off";
                    }
                    break;
                case 1:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Constant Press";
                    }
                    break;
                case 2:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Programed Flow";

                        if (_fColumnFlowOnoff == true)
                            DisplayString_fColumnFlowSet = fColumnFlowSet;
                        else DisplayString_fColumnFlowSet = "Off";
                    }
                    break;
                case 3:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Programed Press";
                    }
                    break;
            }
        }

        void SetTotalFlow()
        {
            switch (_ApcMode)
            {
                case 0:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Constant Flow";

                        DisplayString_fTotalFlowSet = fTotalFlowSet;

                    }
                    break;
                case 1:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Constant Press";
                    }
                    break;
                case 2:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Programed Flow";

                        DisplayString_fTotalFlowSet = fTotalFlowSet;
                    }
                    break;
                case 3:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Programed Press";
                    }
                    break;
            }
        }

        void SetSplitFlow()
        {
            switch (_ApcMode)
            {
                case 0:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Constant Flow";

                        DisplayString_fSplitFlowSet = fSplitFlowSet;
                    }
                    break;
                case 1:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Constant Press";
                    }
                    break;
                case 2:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Programed Flow";
                        DisplayString_fSplitFlowSet = fSplitFlowSet;
                    }
                    break;
                case 3:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Programed Press";
                    }
                    break;
            }
        }

        void SetPressure()
        {
            switch (_ApcMode)
            {
                case 0:
                    {
                        DisplayString_fPressureSet = "Off";

                        TableTitle = "Constant Flow";
                    }
                    break;
                case 1:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Constant Press";

                        if (_fPressureOnoff)
                            DisplayString_fPressureSet = fPressureSet;
                        else DisplayString_fPressureSet = "Off";
                    }
                    break;
                case 2:
                    {
                        DisplayString_fPressureSet = "Off";
                        TableTitle = "Programed Flow";
                    }
                    break;
                case 3:
                    {
                        DisplayString_fColumnFlowSet = "Off";
                        DisplayString_fTotalFlowSet = "Off";
                        DisplayString_fSplitFlowSet = "Off";

                        TableTitle = "Programed Press";
                        if (_fPressureOnoff)
                            DisplayString_fPressureSet = fPressureSet;
                        else DisplayString_fPressureSet = "Off";
                    }
                    break;
            }
        }

        void ValidateAndSetColumnFlow(float fColumnFlow)
        {
            if (_fSplitFlowSet != null && _fTotalFlowSet != null && _iSplitratio != null)
            {
                switch (e_INLET_TYPE)
                {
                    case E_INLET_TYPE.Capillary:
                        {
                            float fSplitFlow = float.Parse(_fSplitFlowSet);
                            float fTotalFlow = float.Parse(_fTotalFlowSet);
                            int iSplit = int.Parse(_iSplitratio);

                            switch ((E_INLET_INJ_MODE)btInjMode)
                            {
                                case E_INLET_INJ_MODE.SPLIT_MODE:
                                case E_INLET_INJ_MODE.SPLITLESS_MODE:
                                case E_INLET_INJ_MODE.PULSED_SPLIT_MODE:
                                case E_INLET_INJ_MODE.PULSED_SPLITLESS_MODE:
                                    {


                                        //fTempRatio, (fTempRatio-1)!=0
                                        fTotalFlow = (float)((iSplit * fColumnFlow) + 3);
                                        fTotalFlowSet = fTotalFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        SetTotalFlow();
                                        //methodDataObject.Inlet1DataObject.fTotalFlowSet = (fTempRatio / (float)(fTempRatio - 1)) * methodDataObject.Inlet1DataObject.fSplitFlowSet + 3;
                                        fSplitFlow = (fTotalFlow - 3) * ((float)(iSplit - 1) / (float)(iSplit));
                                        fSplitFlowSet = fSplitFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                                        SetSplitFlow();
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        void ValidateAndSetTotalFlow(float fTotalFlow)
        {
            if (_fSplitFlowSet != null && _fColumnFlowSet != null && _iSplitratio != null)
            {
                float fSplitFlow = float.Parse(_fSplitFlowSet);
                float fColumnFlow = float.Parse(_fColumnFlowSet);
                int iSplit = int.Parse(_iSplitratio);

                if (iSplit == 0 || fTotalFlow - fSplitFlow - 3 == 0)
                {
                    return;
                }
                else
                {
                    iSplit = (short)Math.Truncate((fTotalFlow - 3) / fColumnFlow);
                    iSplitratio = iSplit.ToString();

                    //fSplitFlow = (fTotalFlow - 3) * ((float)(iSplit) / (float)(iSplit + 1));
                    //fSplitFlowSet = fSplitFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);

                    //fTotalFlow = (float)((iSplit * fColumnFlow) + 3);
                    fTotalFlowSet = fTotalFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                    SetTotalFlow();

                    //methodDataObject.Inlet1DataObject.iSplitratio = (short)(Math.Round((float)(fTemp - 3) / (float)(fTemp - methodDataObject.Inlet1DataObject.fSplitFlowSet - 3)));
                    fSplitFlow = (fTotalFlow - 3) - fColumnFlow;
                    fSplitFlowSet = fSplitFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                    SetSplitFlow();

                    iSplit = (short)Math.Truncate(((float)(fTotalFlow - 3) / (float)(fTotalFlow - fSplitFlow - 3)));
                    iSplitratio = iSplit.ToString();
                }
            }
        }

        void ValidateAndSetSplitFlow(float fSplitFlow)
        {
            if (_fTotalFlowSet != null && _fColumnFlowSet != null && _iSplitratio != null)
            {
                float fTotalFlow = float.Parse(_fTotalFlowSet);
                float fColumnFlow = float.Parse(_fColumnFlowSet);
                int iSplit = int.Parse(_iSplitratio);

                if (fTotalFlow - fSplitFlow - 3 == 0 || iSplit == 1)
                {
                    return;
                }
                else
                {

                    fTotalFlow = (float)fSplitFlow + fColumnFlow + 3;
                    fTotalFlowSet = fTotalFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                    SetTotalFlow();

                    //methodDataObject.Inlet1DataObject.fTotalFlowSet = (float)(methodDataObject.Inlet1DataObject.iSplitratio / (float)(methodDataObject.Inlet1DataObject.iSplitratio - 1)) * fTemp + 3;
                    iSplit = (short)Math.Truncate(((float)(fTotalFlow - 3) / (float)(fTotalFlow - fSplitFlow - 3)));
                    iSplitratio = iSplit.ToString();

                    //fSplitFlow = (fTotalFlow - 3) * ((float)(iSplit) / (float)(iSplit + 1));
                    fSplitFlowSet = fSplitFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                    SetSplitFlow();
                }
            }
        }

        void ValidateAndSetSplitRatio(int iSplit)
        {
            if (_fSplitFlowSet != null && _fTotalFlowSet != null && _iSplitratio != null)
            {
                float fSplitFlow = float.Parse(_fSplitFlowSet);
                float fTotalFlow = float.Parse(_fTotalFlowSet);
                float fColumnFlow = float.Parse(_fColumnFlowSet);

                if (iSplit == 0 || iSplit == 1) return;

                //fTempRatio, (fTempRatio-1)!=0
                fTotalFlow = (float)((iSplit * fColumnFlow) + 3);
                fTotalFlowSet = fTotalFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                SetTotalFlow();
                //methodDataObject.Inlet1DataObject.fTotalFlowSet = (fTempRatio / (float)(fTempRatio - 1)) * methodDataObject.Inlet1DataObject.fSplitFlowSet + 3;
                fSplitFlow = (fTotalFlow - 3) * ((float)(iSplit - 1) / (float)(iSplit));
                fSplitFlowSet = fSplitFlow.ToString(ChroZenService_Const.STR_FORMAT_BELOW_POINT_1);
                SetSplitFlow();
            }
        }

        #endregion Instance Func
    }
}
