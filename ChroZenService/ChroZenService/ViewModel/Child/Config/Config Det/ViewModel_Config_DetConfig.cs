using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Config_DetConfig : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_DetConfig()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        E_DET_TYPE _e_DET_TYPE = E_DET_TYPE.Not_Installed;
        public E_DET_TYPE e_DET_TYPE { get { return _e_DET_TYPE; } set { _e_DET_TYPE = value; OnPropertyChanged("e_DET_TYPE"); } }

        int _btMakeupgas;
        public int btMakeupgas { get { return _btMakeupgas; } set { _btMakeupgas = value; OnPropertyChanged("btMakeupgas"); } }
        int _btConnection;
        public int btConnection { get { return _btConnection; } set { _btConnection = value; OnPropertyChanged("btConnection"); } }
        int _iSignalrange;
        public int iSignalrange { get { return _iSignalrange; } set { _iSignalrange = value; OnPropertyChanged("iSignalrange"); } }
        int _bAutozero;
        public int bAutozero { get { return _bAutozero; } set { _bAutozero = value; OnPropertyChanged("bAutozero"); } }
        int _btBlockSelect;
        public int btBlockSelect { get { return _btBlockSelect; } set { _btBlockSelect = value; OnPropertyChanged("btBlockSelect"); } }
        int _iSignalvariation;
        public int iSignalvariation { get { return _iSignalvariation; } set { _iSignalvariation = value; OnPropertyChanged("iSignalvariation"); } }

        float _fLitoffset;
        public float fLitoffset { get { return _fLitoffset; } set { _fLitoffset = value; OnPropertyChanged("fLitoffset"); } }
        float _fIgnitedelay;
        public float fIgnitedelay { get { return _fIgnitedelay; } set { _fIgnitedelay = value; OnPropertyChanged("fIgnitedelay"); } }
        float _fIgniteflow;
        public float fIgniteflow { get { return _fIgniteflow; } set { _fIgniteflow = value; OnPropertyChanged("fIgniteflow"); } }
        float _fIgnitetemp;
        public float fIgnitetemp { get { return _fIgnitetemp; } set { _fIgnitetemp = value; OnPropertyChanged("fIgnitetemp"); } }

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
