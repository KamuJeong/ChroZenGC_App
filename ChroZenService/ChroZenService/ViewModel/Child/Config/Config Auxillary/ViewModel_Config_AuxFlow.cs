using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_AuxFlow : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_AuxFlow()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        int nAuxIndex;

        float _ActualFlow1;
        public float ActualFlow1 { get { return _ActualFlow1; } set { _ActualFlow1 = value; OnPropertyChanged("ActualFlow1"); } }

        float _ActualFlow2;
        public float ActualFlow2 { get { return _ActualFlow2; } set { _ActualFlow2 = value; OnPropertyChanged("ActualFlow2"); } }

        float _ActualFlow3;
        public float ActualFlow3 { get { return _ActualFlow3; } set { _ActualFlow3 = value; OnPropertyChanged("ActualFlow3"); } }

        byte _btAuxGas;
        public byte btAuxGas { get { return _btAuxGas; } set { _btAuxGas = value; OnPropertyChanged("btAuxGas"); } }

        float _fFlowSet1;
        public float fFlowSet1 { get { return _fFlowSet1; } set { _fFlowSet1 = value; OnPropertyChanged("fFlowSet1"); } }

        bool _fFlowOnoff1;
        public bool fFlowOnoff1 { get { return _fFlowOnoff1; } set { _fFlowOnoff1 = value; OnPropertyChanged("fFlowOnoff1"); } }

        float _fFlowSet2;
        public float fFlowSet2 { get { return _fFlowSet2; } set { _fFlowSet2 = value; OnPropertyChanged("fFlowSet2"); } }

        bool _fFlowOnoff2;
        public bool fFlowOnoff2 { get { return _fFlowOnoff2; } set { _fFlowOnoff2 = value; OnPropertyChanged("fFlowOnoff2"); } }

        float _fFlowSet3;
        public float fFlowSet3 { get { return _fFlowSet3; } set { _fFlowSet3 = value; OnPropertyChanged("fFlowSet3"); } }

        bool _fFlowOnoff3;
        public bool fFlowOnoff3 { get { return _fFlowOnoff3; } set { _fFlowOnoff3 = value; OnPropertyChanged("fFlowOnoff3"); } }

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
