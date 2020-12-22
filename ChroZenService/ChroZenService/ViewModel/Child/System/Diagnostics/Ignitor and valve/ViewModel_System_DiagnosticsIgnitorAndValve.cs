using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_DiagnosticsIgnitorAndValve : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_DiagnosticsIgnitorAndValve()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        bool _bIsIgnitor_1_On;
        public bool bIsIgnitor_1_On { get { return _bIsIgnitor_1_On; } set { _bIsIgnitor_1_On = value; OnPropertyChanged("bIsIgnitor_1_On"); } }

        bool _bIsIgnitor_2_On;
        public bool bIsIgnitor_2_On { get { return _bIsIgnitor_2_On; } set { _bIsIgnitor_2_On = value; OnPropertyChanged("bIsIgnitor_2_On"); } }

        bool _bIsIgnitor_3_On;
        public bool bIsIgnitor_3_On { get { return _bIsIgnitor_3_On; } set { _bIsIgnitor_3_On = value; OnPropertyChanged("bIsIgnitor_3_On"); } }

        bool _bIsValve_1_On;
        public bool bIsValve_1_On { get { return _bIsValve_1_On; } set { _bIsValve_1_On = value; OnPropertyChanged("bIsValve_1_On"); } }

        bool _bIsValve_2_On;
        public bool bIsValve_2_On { get { return _bIsValve_2_On; } set { _bIsValve_2_On = value; OnPropertyChanged("bIsValve_2_On"); } }

        bool _bIsValve_3_On;
        public bool bIsValve_3_On { get { return _bIsValve_3_On; } set { _bIsValve_3_On = value; OnPropertyChanged("bIsValve_3_On"); } }

        bool _bIsValve_4_On;
        public bool bIsValve_4_On { get { return _bIsValve_4_On; } set { _bIsValve_4_On = value; OnPropertyChanged("bIsValve_4_On"); } }

        bool _bIsValve_5_On;
        public bool bIsValve_5_On { get { return _bIsValve_5_On; } set { _bIsValve_5_On = value; OnPropertyChanged("bIsValve_5_On"); } }

        bool _bIsValve_6_On;
        public bool bIsValve_6_On { get { return _bIsValve_6_On; } set { _bIsValve_6_On = value; OnPropertyChanged("bIsValve_6_On"); } }

        bool _bIsValve_7_On;
        public bool bIsValve_7_On { get { return _bIsValve_7_On; } set { _bIsValve_7_On = value; OnPropertyChanged("bIsValve_7_On"); } }

        bool _bIsValve_8_On;
        public bool bIsValve_8_On { get { return _bIsValve_8_On; } set { _bIsValve_8_On = value; OnPropertyChanged("bIsValve_8_On"); } }

        bool _bIsFan_1_On;
        public bool bIsFan_1_On { get { return _bIsFan_1_On; } set { _bIsFan_1_On = value; OnPropertyChanged("bIsFan_1_On"); } }
        bool _bIsFan_2_On;
        public bool bIsFan_2_On { get { return _bIsFan_2_On; } set { _bIsFan_2_On = value; OnPropertyChanged("bIsFan_2_On"); } }
        bool _bIsFan_3_On;
        public bool bIsFan_3_On { get { return _bIsFan_3_On; } set { _bIsFan_3_On = value; OnPropertyChanged("bIsFan_3_On"); } }

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
