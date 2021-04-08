using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModel_Config_ValveInitialState : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_ValveInitialState()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);

            OnCommand = new RelayCommand(OnCommandAction);
            OffCommand = new RelayCommand(OffCommandAction);

            EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        TCPManager tcpManager;

        public byte[] _btType1 = new byte[ChroZenService_Const.SYSTEM_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_GC_SYSTEM_CONFIG.ValveConfig
        /// </summary>
        public byte[] btType1 { get { return _btType1; } set { if (_btType1 != value) { _btType1 = value; OnPropertyChanged("btType1"); } } }

        public byte[] _bInitState = new byte[ChroZenService_Const.SYSTEM_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_VALVE_SETTING
        /// </summary>
        public byte[] bInitState { get { return _bInitState; } set { if (_bInitState != value) { _bInitState = value; OnPropertyChanged("bInitState"); } } }

        public byte[] _btMultiType = new byte[ChroZenService_Const.SYSTEM_MULTI_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_GC_SYSTEM_CONFIG.ValveConfig
        /// </summary>
        public byte[] btMultiType { get { return _btMultiType; } set { if (_btMultiType != value) { _btMultiType = value; OnPropertyChanged("btMultiType"); } } }

        public byte[] _btMultiInitState = new byte[ChroZenService_Const.SYSTEM_MULTI_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_VALVE_SETTING
        /// </summary>
        public byte[] btMultiInitState { get { return _btMultiInitState; } set { if (_btMultiInitState != value) { _btMultiInitState = value; OnPropertyChanged("btMultiInitState"); } } }

        bool _type1_1;
        public bool type1_1 { get { return _type1_1; } set { if (_type1_1 != value) { _type1_1 = value; OnPropertyChanged("type1_1"); } } }
        bool _type1_2;
        public bool type1_2 { get { return _type1_2; } set { if (_type1_2 != value) { _type1_2 = value; OnPropertyChanged("type1_2"); } } }
        bool _type1_3;
        public bool type1_3 { get { return _type1_3; } set { if (_type1_3 != value) { _type1_3 = value; OnPropertyChanged("type1_3"); } } }
        bool _type1_4;
        public bool type1_4 { get { return _type1_4; } set { if (_type1_4 != value) { _type1_4 = value; OnPropertyChanged("type1_4"); } } }
        bool _type1_5;
        public bool type1_5 { get { return _type1_5; } set { if (_type1_5 != value) { _type1_5 = value; OnPropertyChanged("type1_5"); } } }
        bool _type1_6;
        public bool type1_6 { get { return _type1_6; } set { if (_type1_6 != value) { _type1_6 = value; OnPropertyChanged("type1_6"); } } }
        bool _type1_7;
        public bool type1_7 { get { return _type1_7; } set { if (_type1_7 != value) { _type1_7 = value; OnPropertyChanged("type1_7"); } } }
        bool _type1_8;
        public bool type1_8 { get { return _type1_8; } set { if (_type1_8 != value) { _type1_8 = value; OnPropertyChanged("type1_8"); } } }

        bool _type1_M1;
        public bool type1_M1 { get { return _type1_M1; } set { if (_type1_M1 != value) { _type1_M1 = value; OnPropertyChanged("type1_M1"); } } }
        bool _type1_M2;
        public bool type1_M2 { get { return _type1_M2; } set { if (_type1_M2 != value) { _type1_M2 = value; OnPropertyChanged("type1_M2"); } } }

        bool _initState_1;
        public bool initState_1 { get { return _initState_1; } set { if (_initState_1 != value) { _initState_1 = value; OnPropertyChanged("initState_1"); } } }
        bool _initState_2;
        public bool initState_2 { get { return _initState_2; } set { if (_initState_2 != value) { _initState_2 = value; OnPropertyChanged("initState_2"); } } }
        bool _initState_3;
        public bool initState_3 { get { return _initState_3; } set { if (_initState_3 != value) { _initState_3 = value; OnPropertyChanged("initState_3"); } } }
        bool _initState_4;
        public bool initState_4 { get { return _initState_4; } set { if (_initState_4 != value) { _initState_4 = value; OnPropertyChanged("initState_4"); } } }
        bool _initState_5;
        public bool initState_5 { get { return _initState_5; } set { if (_initState_5 != value) { _initState_5 = value; OnPropertyChanged("initState_5"); } } }
        bool _initState_6;
        public bool initState_6 { get { return _initState_6; } set { if (_initState_6 != value) { _initState_6 = value; OnPropertyChanged("initState_6"); } } }
        bool _initState_7;
        public bool initState_7 { get { return _initState_7; } set { if (_initState_7 != value) { _initState_7 = value; OnPropertyChanged("initState_7"); } } }
        bool _initState_8;
        public bool initState_8 { get { return _initState_8; } set { if (_initState_8 != value) { _initState_8 = value; OnPropertyChanged("initState_8"); } } }

        byte _initState_M1;
        public byte initState_M1 { get { return _initState_M1; } set { if (_initState_M1 != value) { _initState_M1 = value; OnPropertyChanged("initState_M1"); } } }
        byte _initState_M2;
        public byte initState_M2 { get { return _initState_M2; } set { if (_initState_M2 != value) { _initState_M2 = value; OnPropertyChanged("initState_M2"); } } }

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

        #region OnCommand
        public RelayCommand OnCommand { get; set; }
        private void OnCommandAction(object param)
        {
            

            switch ((E_GLOBAL_COMMAND_TYPE)param)
            {
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_1:
                    {
                        initState_1 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[0] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_2:
                    {
                        initState_2 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[1] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_3:
                    {
                        initState_3 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[2] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_4:
                    {
                        initState_4 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[3] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_5:
                    {
                        initState_5 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[4] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_6:
                    {
                        initState_6 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[5] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_7:
                    {
                        initState_7 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[6] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_8:
                    {
                        initState_8 = true;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[7] = 1;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("OnCommand Fired");
        }
        #endregion OnCommand 

        #region OffCommand
        public RelayCommand OffCommand { get; set; }
        private void OffCommandAction(object param)
        {
            switch ((E_GLOBAL_COMMAND_TYPE)param)
            {
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_1:
                    {
                        initState_1 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[0] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_2:
                    {
                        initState_2 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[1] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_3:
                    {
                        initState_3 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[2] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_4:
                    {
                        initState_4 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[3] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_5:
                    {
                        initState_5 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[4] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_6:
                    {
                        initState_6 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[5] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_7:
                    {
                        initState_7 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[6] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
                case E_GLOBAL_COMMAND_TYPE.E_CONFIG_VALVE_INITSTATE_8:
                    {
                        initState_8 = false;
                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet.bInitState[7] = 0;
                        tcpManager.Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING.packet));
                    }
                    break;
            }

            //TODO :             
            Debug.WriteLine("OffCommand Fired");
        }
        #endregion OffCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
