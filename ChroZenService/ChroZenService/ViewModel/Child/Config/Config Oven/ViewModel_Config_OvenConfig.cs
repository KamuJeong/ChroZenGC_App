using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_Config_OvenConfig : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_OvenConfig()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        float _fMaxTemp;
        public float fMaxTemp { get { return _fMaxTemp; } set { _fMaxTemp = value; OnPropertyChanged("fMaxTemp"); } }

        float _fEquibTime;
        public float fEquibTime { get { return _fEquibTime; } set { _fEquibTime = value; OnPropertyChanged("fEquibTime"); } }

        byte _bAutoReadyrun;
        public byte bAutoReadyrun { get { return _bAutoReadyrun; } set { _bAutoReadyrun = value; OnPropertyChanged("bAutoReadyrun"); } }

        byte _bCryogenic;
        public byte bCryogenic { get { return _bCryogenic; } set { _bCryogenic = value; OnPropertyChanged("bCryogenic"); } }

        byte _bFastCryo;
        public byte bFastCryo { get { return _bFastCryo; } set { _bFastCryo = value; OnPropertyChanged("bFastCryo"); } }

        ViewModel_Config_OvenConfig_Runstart _runstart;
        public ViewModel_Config_OvenConfig_Runstart runstart { get { return _runstart; } set { _runstart = value; OnPropertyChanged("runstart"); } }

        ViewModel_Cofig_OvenConfig_Postrun _Postrun;
        public ViewModel_Cofig_OvenConfig_Postrun Postrun { get { return _Postrun; } set { _Postrun = value; OnPropertyChanged("Postrun"); } }


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
