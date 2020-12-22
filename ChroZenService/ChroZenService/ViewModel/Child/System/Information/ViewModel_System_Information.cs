﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_Information : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_Information()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        string _ModelName = "ChrozenGC";
        public string ModelName { get { return _ModelName; } set { _ModelName = value; OnPropertyChanged("ModelName"); } }

        string _InstDate;

        /// <summary>
        /// T_INST_INFORM
        /// </summary>
        public string InstDate { get { return _InstDate; } set { _InstDate = value; OnPropertyChanged("InstDate"); } }

        string _InstVersion;

        /// <summary>
        /// T_INST_INFORM
        /// </summary>
        public string InstVersion { get { return _InstVersion; } set { _InstVersion = value; OnPropertyChanged("InstVersion"); } }

        string _InstSerialNo;

        /// <summary>
        /// T_INST_INFORM
        /// </summary>
        public string InstSerialNo { get { return _InstSerialNo; } set { _InstSerialNo = value; OnPropertyChanged("InstSerialNo"); } }
        string _IPAddress;

        /// <summary>
        /// T_SYSTEM_CONFIG
        /// </summary>
        public string IPAddress { get { return _IPAddress; } set { _IPAddress = value; OnPropertyChanged("IPAddress"); } }

        string _cPortNo;

        /// <summary>
        /// T_SYSTEM_CONFIG
        /// </summary>
        public string cPortNo { get { return _cPortNo; } set { _cPortNo = value; OnPropertyChanged("cPortNo"); } }

        string _NetMask;
        public string NetMask { get { return _NetMask; } set { _NetMask = value; OnPropertyChanged("NetMask"); } }

        string _GateWay;
        public string GateWay { get { return _GateWay; } set { _GateWay = value; OnPropertyChanged("GateWay"); } }

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
