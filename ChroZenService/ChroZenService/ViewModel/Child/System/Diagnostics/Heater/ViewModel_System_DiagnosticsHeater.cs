using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsHeater : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsHeater()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        float _fOven;

        /// <summary>
        /// Oven Temp
        /// </summary>
        public float fOven { get { return _fOven; } set { _fOven = value; OnPropertyChanged("fOven"); } }

        float[] _fInj;

        /// <summary>
        /// Inlet Front ~ Rear Temp
        /// </summary>
        public float[] fInj { get { return _fInj; } set { _fInj = value; OnPropertyChanged("fInj"); } }

        float[] _fDet;

        /// <summary>
        /// Det Front ~ Rear Temp
        /// </summary>
        public float[] fDet { get { return _fDet; } set { _fDet = value; OnPropertyChanged("fDet"); } }

        float[] _fAux;

        /// <summary>
        /// Aux 1 ~ 8 Temp
        /// </summary>
        public float[] fAux { get { return _fAux; } set { _fAux = value; OnPropertyChanged("fAux"); } }

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
