using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    //public class ViewModel_System_DiagnosticsIgnitorAndValve : Model_System_Diagnostics
    //{
    //    #region 생성자 & 이벤트 헨들러

    //    public ViewModel_System_DiagnosticsIgnitorAndValve()
    //    {
    //        StartStopCommand = new RelayCommand(StartStopCommandAction);

    //        EventManager.onMainInitialized += (tcpManagerSource) => { tcpManager = tcpManagerSource; };
    //    }

    //    #endregion 생성자 & 이벤트 헨들러

    //    #region Binding

    //    #region Property
    //    TCPManager tcpManager;
    //    bool _bIsIgnitor_1_On;
    //    public bool bIsIgnitor_1_On { get { return _bIsIgnitor_1_On; } set { if (_bIsIgnitor_1_On != value) { _bIsIgnitor_1_On = value; OnPropertyChanged("bIsIgnitor_1_On"); } } }

    //    bool _bIsIgnitor_2_On;
    //    public bool bIsIgnitor_2_On { get { return _bIsIgnitor_2_On; } set { if (_bIsIgnitor_2_On != value) { _bIsIgnitor_2_On = value; OnPropertyChanged("bIsIgnitor_2_On"); } } }

    //    bool _bIsIgnitor_3_On;
    //    public bool bIsIgnitor_3_On { get { return _bIsIgnitor_3_On; } set { if (_bIsIgnitor_3_On != value) { _bIsIgnitor_3_On = value; OnPropertyChanged("bIsIgnitor_3_On"); } } }

    //    bool _bIsValve_1_On;
    //    public bool bIsValve_1_On { get { return _bIsValve_1_On; } set { if (_bIsValve_1_On != value) { _bIsValve_1_On = value; OnPropertyChanged("bIsValve_1_On"); } } }

    //    bool _bIsValve_2_On;
    //    public bool bIsValve_2_On { get { return _bIsValve_2_On; } set { if (_bIsValve_2_On != value) { _bIsValve_2_On = value; OnPropertyChanged("bIsValve_2_On"); } } }

    //    bool _bIsValve_3_On;
    //    public bool bIsValve_3_On { get { return _bIsValve_3_On; } set { if (_bIsValve_3_On != value) { _bIsValve_3_On = value; OnPropertyChanged("bIsValve_3_On"); } } }

    //    bool _bIsValve_4_On;
    //    public bool bIsValve_4_On { get { return _bIsValve_4_On; } set { if (_bIsValve_4_On != value) { _bIsValve_4_On = value; OnPropertyChanged("bIsValve_4_On"); } } }

    //    bool _bIsValve_5_On;
    //    public bool bIsValve_5_On { get { return _bIsValve_5_On; } set { if (_bIsValve_5_On != value) { _bIsValve_5_On = value; OnPropertyChanged("bIsValve_5_On"); } } }

    //    bool _bIsValve_6_On;
    //    public bool bIsValve_6_On { get { return _bIsValve_6_On; } set { if (_bIsValve_6_On != value) { _bIsValve_6_On = value; OnPropertyChanged("bIsValve_6_On"); } } }

    //    bool _bIsValve_7_On;
    //    public bool bIsValve_7_On { get { return _bIsValve_7_On; } set { if (_bIsValve_7_On != value) { _bIsValve_7_On = value; OnPropertyChanged("bIsValve_7_On"); } } }

    //    bool _bIsValve_8_On;
    //    public bool bIsValve_8_On { get { return _bIsValve_8_On; } set { if (_bIsValve_8_On != value) { _bIsValve_8_On = value; OnPropertyChanged("bIsValve_8_On"); } } }

    //    bool _bIsFan_1_On;
    //    public bool bIsFan_1_On { get { return _bIsFan_1_On; } set { if (_bIsFan_1_On != value) { _bIsFan_1_On = value; OnPropertyChanged("bIsFan_1_On"); } } }
    //    bool _bIsFan_2_On;
    //    public bool bIsFan_2_On { get { return _bIsFan_2_On; } set { if (_bIsFan_2_On != value) { _bIsFan_2_On = value; OnPropertyChanged("bIsFan_2_On"); } } }
    //    bool _bIsFan_3_On;
    //    public bool bIsFan_3_On { get { return _bIsFan_3_On; } set { if (_bIsFan_3_On != value) { _bIsFan_3_On = value; OnPropertyChanged("bIsFan_3_On"); } } }

    //    #endregion Property

    //    #region Command

    //    #region StartStopCommand
    //    public RelayCommand StartStopCommand { get; set; }
    //    private void StartStopCommandAction(object param)
    //    {
    //        this.StartCommand((ChroZenService_Const.E_SYSTEM_DIAG_COMMAND_TYPE)param, tcpManager);
    //        if ((ChroZenService_Const.E_SYSTEM_DIAG_COMMAND_TYPE)param == ChroZenService_Const.E_SYSTEM_DIAG_COMMAND_TYPE.START_IGNITOR_VALVE)
    //        {
    //            bIsIgnitor_1_On = true;
    //            bIsIgnitor_2_On = true;
    //            bIsIgnitor_3_On = true;
    //            bIsValve_1_On = true;
    //            bIsValve_2_On = true;
    //            bIsValve_3_On = true;
    //            bIsValve_4_On = true;
    //            bIsValve_5_On = true;
    //            bIsValve_6_On = true;
    //            bIsValve_7_On = true;
    //            bIsValve_8_On = true;
    //            bIsFan_1_On = true;
    //            bIsFan_2_On = true;
    //            bIsFan_3_On = true;
    //        }
    //        else
    //        {
    //            bIsIgnitor_1_On = false;
    //            bIsIgnitor_2_On = false;
    //            bIsIgnitor_3_On = false;
    //            bIsValve_1_On = false;
    //            bIsValve_2_On = false;
    //            bIsValve_3_On = false;
    //            bIsValve_4_On = false;
    //            bIsValve_5_On = false;
    //            bIsValve_6_On = false;
    //            bIsValve_7_On = false;
    //            bIsValve_8_On = false;
    //            bIsFan_1_On = false;
    //            bIsFan_2_On = false;
    //            bIsFan_3_On = false;
    //        }
    //        //TODO :             
    //        Debug.WriteLine("StartStopCommand Fired");
    //    }
    //    #endregion StartStopCommand 

    //    #endregion Command

    //    #endregion Binding

    //    #region Instance Func

    //    #endregion Instance Func
    //}
}
