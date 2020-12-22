using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_Config : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Config()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        byte[] _btInlet = new byte[ChroZenService_Const.INLET_CNT];
        public byte[] btInlet { get { return _btInlet; } set { _btInlet = value; OnPropertyChanged("btInlet"); } }

        byte[] _btDet = new byte[ChroZenService_Const.DET_CNT];
        byte[] btDet { get { return _btDet; } set { _btDet = value; OnPropertyChanged("btDet"); } }

        byte _bMethanizer;
        /// <summary>
        /// 0 : Valve
        /// 1 : Methanizer
        /// 2 : TransferLine
        /// </summary>
        public byte bMethanizer { get { return _bMethanizer; } set { _bMethanizer = value; OnPropertyChanged("bMethanizer"); } }

        byte[] _bAuxAPC = new byte[ChroZenService_Const.AUX_APC_CNT];
        public byte[] bAuxAPC { get { return _bAuxAPC; } set { _bAuxAPC = value; OnPropertyChanged("bAuxAPC"); } }

        byte _bCryogenic;
        public byte bCryogenic { get { return _bCryogenic; } set { _bCryogenic = value; OnPropertyChanged("bCryogenic"); } }

        byte[] _bAuxTemp = new byte[ChroZenService_Const.AUX_CNT];
        public byte[] bAuxTemp { get { return _bAuxTemp; } set { _bAuxTemp = value; OnPropertyChanged("bAuxTemp"); } }

        byte[] _bMultiValve = new byte[ChroZenService_Const.SYSTEM_MULTI_VALVE_CNT];
        public byte[] bMultiValve { get { return _bMultiValve; } set { _bMultiValve = value; OnPropertyChanged("bMultiValve"); } }

        byte[] _btType1;
        public byte[] btType1 { get { return _btType1; } set { _btType1 = value; OnPropertyChanged("btType1"); } }

        byte[] _btPort;
        public byte[] btPort { get { return _btPort; } set { _btPort = value; OnPropertyChanged("btPort"); } }

        float[] _fLoop1;
        public float[] fLoop1 { get { return _fLoop1; } set { _fLoop1 = value; OnPropertyChanged("fLoop1"); } }

        byte[] _btType2;
        public byte[] btType2 { get { return _btType2; } set { _btType2 = value; OnPropertyChanged("btType2"); } }

        byte _btCoolant;
        /// <summary>
        /// T_CHROZEN_GC_OVEN
        /// </summary>
        public byte btCoolant { get { return _btCoolant; } set { _btCoolant = value; OnPropertyChanged("btCoolant"); } }

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
