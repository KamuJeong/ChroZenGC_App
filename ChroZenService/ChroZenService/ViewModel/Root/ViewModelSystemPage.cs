using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public class ViewModelSystemPage : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModelSystemPage()
        {
            MenuSelectCommand = new RelayCommand(MenuSelectCommandAction);
            SubMenuSelectCommand = new RelayCommand(SubMenuSelectCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        ViewModel_System_Calibration _ViewModel_System_Calibration = new ViewModel_System_Calibration();
        ViewModel_System_Calibration ViewModel_System_Calibration { get { return _ViewModel_System_Calibration; } set { _ViewModel_System_Calibration = value; OnPropertyChanged("ViewModel_System_Calibration"); } }
        ViewModel_System_Config _ViewModel_System_Config = new ViewModel_System_Config();
        ViewModel_System_Config ViewModel_System_Config { get { return _ViewModel_System_Config; } set { _ViewModel_System_Config = value; OnPropertyChanged("ViewModel_System_Config"); } }
        ViewModel_System_Diagnostics _ViewModel_System_Diagnostics = new ViewModel_System_Diagnostics();
        ViewModel_System_Diagnostics ViewModel_System_Diagnostics { get { return _ViewModel_System_Diagnostics; } set { _ViewModel_System_Diagnostics = value; OnPropertyChanged("ViewModel_System_Diagnostics"); } }        
        ViewModel_System_Information _ViewModel_System_Information = new ViewModel_System_Information();
        ViewModel_System_Information ViewModel_System_Information { get { return _ViewModel_System_Information; } set { _ViewModel_System_Information = value; OnPropertyChanged("ViewModel_System_Information"); } }
        ViewModel_System_Method _ViewModel_System_Method = new ViewModel_System_Method();
        ViewModel_System_Method ViewModel_System_Method { get { return _ViewModel_System_Method; } set { _ViewModel_System_Method = value; OnPropertyChanged("ViewModel_System_Method"); } }
        ViewModel_System_Settings _ViewModel_System_Settings = new ViewModel_System_Settings();
        ViewModel_System_Settings ViewModel_System_Settings { get { return _ViewModel_System_Settings; } set { _ViewModel_System_Settings = value; OnPropertyChanged("ViewModel_System_Settings"); } }
        ViewModel_System_TimeControl _ViewModel_System_TimeControl = new ViewModel_System_TimeControl();
        ViewModel_System_TimeControl ViewModel_System_TimeControl { get { return _ViewModel_System_TimeControl; } set { _ViewModel_System_TimeControl = value; OnPropertyChanged("ViewModel_System_TimeControl"); } }

        #region 좌측 메뉴 선택 속성

        E_SYSTEM_MENU_TYPE _SelectedMenu = E_SYSTEM_MENU_TYPE.INFORMATION;
        public E_SYSTEM_MENU_TYPE SelectedMenu { get { return _SelectedMenu; } set { _SelectedMenu = value; OnPropertyChanged("SelectedMenu"); } }

        E_SYSTEM_SUB_MENU_TYPE _SelectedSubMenu = E_SYSTEM_SUB_MENU_TYPE.INFO_ROOT;
        public E_SYSTEM_SUB_MENU_TYPE SelectedSubMenu { get { return _SelectedSubMenu; } set { _SelectedSubMenu = value; OnPropertyChanged("SelectedSubMenu"); } }


        #endregion 좌측 메뉴 선택 속성

        #endregion Property

        #region Command

        #region 좌측 메뉴 선택 커멘드

        public RelayCommand MenuSelectCommand { get; set; }
        private void MenuSelectCommandAction(object param)
        {
            SelectedMenu = (E_SYSTEM_MENU_TYPE)param;

            //TODO :             
            Debug.WriteLine(string.Format("ViewModelSystemPage : MenuSelectCommand to {0} Fired", SelectedMenu));
        }

        public RelayCommand SubMenuSelectCommand { get; set; }
        private void SubMenuSelectCommandAction(object param)
        {
            SelectedSubMenu = (E_SYSTEM_SUB_MENU_TYPE)param;

            //TODO :             
            Debug.WriteLine(string.Format("ViewModelSystemPage : SubMenuSelectCommand to {0} Fired", SelectedMenu));
        }
        #endregion 좌측 메뉴 선택 커멘드

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func

    }
}
