using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_TimeControl : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_TimeControl()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ObservableCollection<ViewModel_System_TimeControl_TimeControlType> _OC_ViewModel_System_TimeControl_TimeControlType =
            new ObservableCollection<ViewModel_System_TimeControl_TimeControlType>(new ViewModel_System_TimeControl_TimeControlType[ChroZenService_Const.TIME_CONTROL_PROGRAM_CNT]);
        ObservableCollection<ViewModel_System_TimeControl_TimeControlType> OC_ViewModel_System_TimeControl_TimeControlType
        {
            get { return _OC_ViewModel_System_TimeControl_TimeControlType; }
            set { _OC_ViewModel_System_TimeControl_TimeControlType = value; OnPropertyChanged("OC_ViewModel_System_TimeControl_TimeControlType"); }
        }

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
