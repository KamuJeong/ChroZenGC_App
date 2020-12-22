using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_ValveInitialState : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_ValveInitialState()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        public byte[] _btType1 = new byte[ChroZenService_Const.SYSTEM_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_GC_SYSTEM_CONFIG.ValveConfig
        /// </summary>
        public byte[] btType1 { get { return _btType1; } set { _btType1 = value; OnPropertyChanged("btType1"); } }

        public byte[] _bInitState = new byte[ChroZenService_Const.SYSTEM_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_VALVE_SETTING
        /// </summary>
        public byte[] bInitState { get { return _bInitState; } set { _bInitState = value; OnPropertyChanged("bInitState"); } }

        public byte[] _btMultiType = new byte[ChroZenService_Const.SYSTEM_MULTI_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_GC_SYSTEM_CONFIG.ValveConfig
        /// </summary>
        public byte[] btMultiType { get { return _btMultiType; } set { _btMultiType = value; OnPropertyChanged("btMultiType"); } }

        public byte[] _btMultiInitState = new byte[ChroZenService_Const.SYSTEM_MULTI_VALVE_CNT];

        /// <summary>
        /// T_CHROZEN_VALVE_SETTING
        /// </summary>
        public byte[] btMultiInitState { get { return _btMultiInitState; } set { _btMultiInitState = value; OnPropertyChanged("btMultiInitState"); } }

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
