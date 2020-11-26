using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModelMainPage : BindableNotifyBase
    {
        #region 생성자

        public ViewModelMainPage()
        {
            SelectSystemMenu = new RelayCommand(SelectSystemMenuAction);
            SelectConfigMenu = new RelayCommand(SelectConfigMenuAction);
        }       
        #endregion 생성자

        #region Binding

        #region Property

        ViewModel_MainTop _ViewModel_MainTop = new ViewModel_MainTop();
        public ViewModel_MainTop ViewModel_MainTop { get { return _ViewModel_MainTop; } set { ViewModel_MainTop = value; OnPropertyChanged("ViewModel_MainTop"); } }

        ViewModel_MainBottom _ViewModel_MainBottom = new ViewModel_MainBottom();
        public ViewModel_MainBottom ViewModel_MainBottom { get { return _ViewModel_MainBottom; } set { ViewModel_MainBottom = value; OnPropertyChanged("ViewModel_MainBottom"); } }

        ViewModel_MainCenter _ViewModel_MainCenter = new ViewModel_MainCenter();
        public ViewModel_MainCenter ViewModel_MainCenter { get { return _ViewModel_MainCenter; } set { ViewModel_MainCenter = value; OnPropertyChanged("ViewModel_MainCenter"); } }

        ViewModel_MainSide_Left _ViewModel_MainSide_Left = new ViewModel_MainSide_Left();
        public ViewModel_MainSide_Left ViewModel_MainSide_Left { get { return _ViewModel_MainSide_Left; } set { ViewModel_MainSide_Left = value; OnPropertyChanged("ViewModel_MainSide_Left"); } }

        ViewModel_MainSide_Right _ViewModel_MainSide_Right = new ViewModel_MainSide_Right();
        public ViewModel_MainSide_Right ViewModel_MainSide_Right { get { return _ViewModel_MainSide_Right; } set { ViewModel_MainSide_Right = value; OnPropertyChanged("ViewModel_MainSide_Right"); } }

        ViewModel_MainChart _ViewModel_MainChart = new ViewModel_MainChart();
        public ViewModel_MainChart ViewModel_MainChart { get { return _ViewModel_MainChart; } set { ViewModel_MainChart = value; OnPropertyChanged("ViewModel_MainChart"); } }

        #endregion Property

        #region Command

        #region 시스템 설정 메뉴
        public RelayCommand SelectSystemMenu { get; set; }
        private void SelectSystemMenuAction(object param)
        {
            
        }
        #endregion 시스템 설정 메뉴

        #region 장비 설정 메뉴
        public RelayCommand SelectConfigMenu { get; set; }
        private void SelectConfigMenuAction(object param)
        {

        }
        #endregion 장비 설정 메뉴

        #endregion Command

        #endregion Binding


    }
}
