using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_Settings : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Settings()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        byte _bOnoff;
        public byte bOnoff { get { return _bOnoff; } set { _bOnoff = value; OnPropertyChanged("bOnoff"); } }
        float _fInitTemp;
        public float fInitTemp { get { return _fInitTemp; } set { _fInitTemp = value; OnPropertyChanged("fInitTemp"); } }
        float _fInitTime;
        public float fInitTime { get { return _fInitTime; } set { _fInitTime = value; OnPropertyChanged("fInitTime"); } }
        float _fRate;
        public float fRate { get { return _fRate; } set { _fRate = value; OnPropertyChanged("fRate"); } }
        float _fFinalTemp;
        public float fFinalTemp { get { return _fFinalTemp; } set { _fFinalTemp = value; OnPropertyChanged("fFinalTemp"); } }
        float _fFinalTime;
        public float fFinalTime { get { return _fFinalTime; } set { _fFinalTime = value; OnPropertyChanged("fFinalTime"); } }

        float _fTime;
        public float fTime { get { return _fTime; } set { _fTime = value; OnPropertyChanged("fTime"); } }
        byte _RemoteAccess_bOnoff;
        public byte RemoteAccess_bOnoff { get { return _RemoteAccess_bOnoff; } set { _RemoteAccess_bOnoff = value; OnPropertyChanged("RemoteAccess_bOnoff"); } }
        float _fEventTime1;
        public float fEventTime1 { get { return _fEventTime1; } set { _fEventTime1 = value; OnPropertyChanged("fEventTime1"); } }
        float _fEventTime2;
        public float fEventTime2 { get { return _fEventTime2; } set { _fEventTime2 = value; OnPropertyChanged("fEventTime2"); } }

        string _InstDate;

        /// <summary>
        /// T_INST_INFORM
        /// </summary>
        public string InstDate { get { return _InstDate; } set { _InstDate = value; OnPropertyChanged("InstDate"); } }

        string _Date;
        public string Date;

        string _Time;
        public string Time;
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
