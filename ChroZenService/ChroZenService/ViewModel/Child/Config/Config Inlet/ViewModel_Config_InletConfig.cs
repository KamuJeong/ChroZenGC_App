using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Config_InletConfig : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_InletConfig()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        E_INLET_TYPE _e_INLET_TYPE = E_INLET_TYPE.Not_Installed;
        public E_INLET_TYPE e_INLET_TYPE { get { return _e_INLET_TYPE; } set { _e_INLET_TYPE = value; OnPropertyChanged("e_INLET_TYPE"); } }

        int _btCarriergas;
        public int btCarriergas { get { return _btCarriergas; } set { _btCarriergas = value; OnPropertyChanged("btCarriergas"); } }

        int _btApcMode;
        public int btApcMode { get { return _btApcMode; } set { _btApcMode = value; OnPropertyChanged("btApcMode"); } }

        int _ConnectionToDet;
        public int ConnectionToDet { get { return _ConnectionToDet; } set { _ConnectionToDet = value; OnPropertyChanged("ConnectionToDet"); } }


        float _fLength;
        public float fLength { get { return _fLength; } set { _fLength = value; OnPropertyChanged("fLength"); } }

        float _fDiameter;
        public float fDiameter { get { return _fDiameter; } set { _fDiameter = value; OnPropertyChanged("fDiameter"); } }

        float _fThickness;
        public float fThickness { get { return _fThickness; } set { _fThickness = value; OnPropertyChanged("fThickness"); } }

        float _bGasSaverMode;
        public float bGasSaverMode { get { return _bGasSaverMode; } set { _bGasSaverMode = value; OnPropertyChanged("bGasSaverMode"); } }

        float _fGasSaverFlow;
        public float fGasSaverFlow { get { return _fGasSaverFlow; } set { _fGasSaverFlow = value; OnPropertyChanged("fGasSaverFlow"); } }

        float _fGasSaverTime;
        public float fGasSaverTime { get { return _fGasSaverTime; } set { _fGasSaverTime = value; OnPropertyChanged("fGasSaverTime"); } }

        float _fPressureCorrect;
        public float fPressureCorrect { get { return _fPressureCorrect; } set { _fPressureCorrect = value; OnPropertyChanged("fPressureCorrect"); } }

        bool _bPressCorrect;
        public bool bPressCorrect { get { return _bPressCorrect; } set { _bPressCorrect = value; OnPropertyChanged("bPressCorrect"); } }

        bool _bVacuumCorrect;
        public bool bVacuumCorrect { get { return _bVacuumCorrect; } set { _bVacuumCorrect = value; OnPropertyChanged("bVacuumCorrect"); } }
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
