using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_ValveProgram : ChildNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_Config_ValveProgram()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ObservableCollection<ViewModel_Config_ValveProgram_Program> _OC_ViewModel_Config_ValveProgram_Program = new ObservableCollection<ViewModel_Config_ValveProgram_Program>(new ViewModel_Config_ValveProgram_Program[ChroZenService_Const.VALVE_PROGRAM_CNT]);

        public ObservableCollection<ViewModel_Config_ValveProgram_Program> OC_ViewModel_Config_ValveProgram_Program
        {
            get { return _OC_ViewModel_Config_ValveProgram_Program; }
            set { _OC_ViewModel_Config_ValveProgram_Program = value; OnPropertyChanged("OC_ViewModel_Config_ValveProgram_Program"); }
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
