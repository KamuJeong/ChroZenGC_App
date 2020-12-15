using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_MainSide_Right : BindableNotifyBase
    {
        #region NotifybaseProperty

        string _TopType;
        public string TopType { get { return _TopType; } set { _TopType = value; OnPropertyChanged("TopType"); } }

        string _CenterType;
        public string CenterType { get { return _CenterType; } set { _CenterType = value; OnPropertyChanged("CenterType"); } }

        string _BottomType;
        public string BottomType { get { return _BottomType; } set { _BottomType = value; OnPropertyChanged("BottomType"); } }

        string _TopSignalStrength;
        public string TopSignalStrength { get { return _TopSignalStrength; } set { _TopSignalStrength = value; OnPropertyChanged("TopSignalStrength"); } }

        string _TopSignalUnit;
        public string TopSignalUnit { get { return _TopSignalUnit; } set { _TopSignalUnit = value; OnPropertyChanged("TopSignalUnit"); } }

        string _TopFlow1Name;
        public string TopFlow1Name { get { return _TopFlow1Name; } set { _TopFlow1Name = value; OnPropertyChanged("TopFlow1Name"); } }

        string _TopFlow2Name;
        public string TopFlow2Name { get { return _TopFlow2Name; } set { _TopFlow2Name = value; OnPropertyChanged("TopFlow2Name"); } }

        string _TopFlow3Name;
        public string TopFlow3Name { get { return _TopFlow3Name; } set { _TopFlow3Name = value; OnPropertyChanged("TopFlow3Name"); } }

        string _TopFlow1Value;
        public string TopFlow1Value { get { return _TopFlow1Value; } set { _TopFlow1Value = value; OnPropertyChanged("TopFlow1Value"); } }

        string _TopFlow2Value;
        public string TopFlow2Value { get { return _TopFlow2Value; } set { _TopFlow2Value = value; OnPropertyChanged("TopFlow2Value"); } }

        string _TopFlow3Value;
        public string TopFlow3Value { get { return _TopFlow3Value; } set { _TopFlow3Value = value; OnPropertyChanged("TopFlow3Value"); } }

        bool _TopIsFlow1Using;
        public bool TopIsFlow1Using { get { return _TopIsFlow1Using; } set { _TopIsFlow1Using = value; OnPropertyChanged("TopIsFlow1Using"); } }

        bool _TopIsFlow2Using;
        public bool TopIsFlow2Using { get { return _TopIsFlow2Using; } set { _TopIsFlow2Using = value; OnPropertyChanged("TopIsFlow2Using"); } }

        bool _TopIsFlow3Using;
        public bool TopIsFlow3Using { get { return _TopIsFlow3Using; } set { _TopIsFlow3Using = value; OnPropertyChanged("TopIsFlow3Using"); } }
        
        string _CenterSignalStrength;
        public string CenterSignalStrength { get { return _CenterSignalStrength; } set { _CenterSignalStrength = value; OnPropertyChanged("CenterSignalStrength"); } }

        string _CenterSignalUnit;
        public string CenterSignalUnit { get { return _CenterSignalUnit; } set { _CenterSignalUnit = value; OnPropertyChanged("CenterSignalUnit"); } }
        
        string _CenterFlow1Name;
        public string CenterFlow1Name { get { return _CenterFlow1Name; } set { _CenterFlow1Name = value; OnPropertyChanged("CenterFlow1Name"); } }

        string _CenterFlow2Name;
        public string CenterFlow2Name { get { return _CenterFlow2Name; } set { _CenterFlow2Name = value; OnPropertyChanged("CenterFlow2Name"); } }

        string _CenterFlow3Name;
        public string CenterFlow3Name { get { return _CenterFlow3Name; } set { _CenterFlow3Name = value; OnPropertyChanged("CenterFlow3Name"); } }

        string _CenterFlow1Value;
        public string CenterFlow1Value { get { return _CenterFlow1Value; } set { _CenterFlow1Value = value; OnPropertyChanged("CenterFlow1Value"); } }

        string _CenterFlow2Value;
        public string CenterFlow2Value { get { return _CenterFlow2Value; } set { _CenterFlow2Value = value; OnPropertyChanged("CenterFlow2Value"); } }

        string _CenterFlow3Value;
        public string CenterFlow3Value { get { return _CenterFlow3Value; } set { _CenterFlow3Value = value; OnPropertyChanged("CenterFlow3Value"); } }

        bool _CenterIsFlow1Using;
        public bool CenterIsFlow1Using { get { return _CenterIsFlow1Using; } set { _CenterIsFlow1Using = value; OnPropertyChanged("CenterIsFlow1Using"); } }

        bool _CenterIsFlow2Using;
        public bool CenterIsFlow2Using { get { return _CenterIsFlow2Using; } set { _CenterIsFlow2Using = value; OnPropertyChanged("CenterIsFlow2Using"); } }

        bool _CenterIsFlow3Using;
        public bool CenterIsFlow3Using { get { return _CenterIsFlow3Using; } set { _CenterIsFlow3Using = value; OnPropertyChanged("CenterIsFlow3Using"); } }

        string _BottomSignalStrength;
        public string BottomSignalStrength { get { return _BottomSignalStrength; } set { _BottomSignalStrength = value; OnPropertyChanged("BottomSignalStrength"); } }

        string _BottomSignalUnit;
        public string BottomSignalUnit { get { return _BottomSignalUnit; } set { _BottomSignalUnit = value; OnPropertyChanged("BottomSignalUnit"); } }
        
        string _BottomFlow1Name;
        public string BottomFlow1Name { get { return _BottomFlow1Name; } set { _BottomFlow1Name = value; OnPropertyChanged("BottomFlow1Name"); } }

        string _BottomFlow2Name;
        public string BottomFlow2Name { get { return _BottomFlow2Name; } set { _BottomFlow2Name = value; OnPropertyChanged("BottomFlow2Name"); } }

        string _BottomFlow3Name;
        public string BottomFlow3Name { get { return _BottomFlow3Name; } set { _BottomFlow3Name = value; OnPropertyChanged("BottomFlow3Name"); } }

        string _BottomFlow1Value;
        public string BottomFlow1Value { get { return _BottomFlow1Value; } set { _BottomFlow1Value = value; OnPropertyChanged("BottomFlow1Value"); } }

        string _BottomFlow2Value;
        public string BottomFlow2Value { get { return _BottomFlow2Value; } set { _BottomFlow2Value = value; OnPropertyChanged("BottomFlow2Value"); } }

        string _BottomFlow3Value;
        public string BottomFlow3Value { get { return _BottomFlow3Value; } set { _BottomFlow3Value = value; OnPropertyChanged("BottomFlow3Value"); } }

        bool _BottomIsFlow1Using;
        public bool BottomIsFlow1Using { get { return _BottomIsFlow1Using; } set { _BottomIsFlow1Using = value; OnPropertyChanged("BottomIsFlow1Using"); } }

        bool _BottomIsFlow2Using;
        public bool BottomIsFlow2Using { get { return _BottomIsFlow2Using; } set { _BottomIsFlow2Using = value; OnPropertyChanged("BottomIsFlow2Using"); } }

        bool _BottomIsFlow3Using;
        public bool BottomIsFlow3Using { get { return _BottomIsFlow3Using; } set { _BottomIsFlow3Using = value; OnPropertyChanged("BottomIsFlow3Using"); } }
        
        bool _IsTopAvailable;
        public bool IsTopAvailable
        {
            get { return _IsTopAvailable; }
            set
            {
                _IsTopAvailable = value;
                if (value == true) SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.TOP);
                OnPropertyChanged("IsTopAvailable");
            }
        }

        bool _IsCenterAvailable;
        public bool IsCenterAvailable
        {
            get { return _IsCenterAvailable; }
            set
            {
                _IsCenterAvailable = value;
                if (value == true) SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.CENTER);
                OnPropertyChanged("IsCenterAvailable");
            }
        }

        bool _IsBottomAvailable;
        public bool IsBottomAvailable
        {
            get { return _IsBottomAvailable; }
            set
            {
                _IsBottomAvailable = value;
                if (value == true) SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.BOTTOM);
                OnPropertyChanged("IsBottomAvailable");
            }
        }

        #endregion NotifybaseProperty

        #region BindableProperty

        #region TopHeight : GridLength

        public static readonly BindableProperty TopHeightProperty =
        BindableProperty.Create("TopHeight", typeof(GridLength), typeof(ViewModel_MainSide_Right),
            defaultValue: new GridLength(ChroZenService_Const.dMainPageEnabledSideInfoHeight),
            propertyChanged: onTopHeightPropertyChanged
            , defaultBindingMode: BindingMode.OneWay);

        private static void onTopHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainSide_Right).TopHeight = (GridLength)newValue;
            }
        }

        public GridLength TopHeight
        {
            get { return (GridLength)GetValue(TopHeightProperty); }
            set { SetValue(TopHeightProperty, value); }
        }

        #endregion TopHeight : GridLength

        #region CenterHeight : GridLength

        public static readonly BindableProperty CenterHeightProperty =
        BindableProperty.Create("CenterHeight", typeof(GridLength), typeof(ViewModel_MainSide_Right),
            defaultValue: new GridLength(0),
            propertyChanged: onCenterHeightPropertyChanged
            , defaultBindingMode: BindingMode.OneWay);

        private static void onCenterHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainSide_Right).CenterHeight = (GridLength)newValue;
            }
        }

        public GridLength CenterHeight
        {
            get { return (GridLength)GetValue(CenterHeightProperty); }
            set { SetValue(CenterHeightProperty, value); }
        }

        #endregion CenterHeight : GridLength

        #region BottomHeight : GridLength

        public static readonly BindableProperty BottomHeightProperty =
        BindableProperty.Create("BottomHeight", typeof(GridLength), typeof(ViewModel_MainSide_Right),
            defaultValue: new GridLength(0),
            propertyChanged: onBottomHeightPropertyChanged
            , defaultBindingMode: BindingMode.OneWay);

        private static void onBottomHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainSide_Right).BottomHeight = (GridLength)newValue;
            }
        }

        public GridLength BottomHeight
        {
            get { return (GridLength)GetValue(BottomHeightProperty); }
            set { SetValue(BottomHeightProperty, value); }
        }

        #endregion BottomHeight : GridLength

        #region IsTopVisible : bool

        public static readonly BindableProperty IsTopVisibleProperty =
        BindableProperty.Create("IsTopVisible", typeof(bool), typeof(ViewModel_MainSide_Right),
            defaultValue: true,
            propertyChanged: onIsTopVisiblePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onIsTopVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainSide_Right).IsTopVisible = (bool)newValue;
            }
        }

        public bool IsTopVisible
        {
            get { return (bool)GetValue(IsTopVisibleProperty); }
            set { SetValue(IsTopVisibleProperty, value); }
        }

        #endregion IsTopVisible : GridLength

        #region IsCenterVisible : bool

        public static readonly BindableProperty IsCenterVisibleProperty =
        BindableProperty.Create("IsCenterVisible", typeof(bool), typeof(ViewModel_MainSide_Right),
            defaultValue: false,
            propertyChanged: onIsCenterVisiblePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onIsCenterVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainSide_Right).IsCenterVisible = (bool)newValue;
            }
        }

        public bool IsCenterVisible
        {
            get { return (bool)GetValue(IsCenterVisibleProperty); }
            set { SetValue(IsCenterVisibleProperty, value); }
        }

        #endregion IsCenterVisible : GridLength

        #region IsBottomVisible : bool

        public static readonly BindableProperty IsBottomVisibleProperty =
        BindableProperty.Create("IsBottomVisible", typeof(bool), typeof(ViewModel_MainSide_Right),
            defaultValue: false,
            propertyChanged: onIsBottomVisiblePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onIsBottomVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainSide_Right).IsBottomVisible = (bool)newValue;
            }
        }

        public bool IsBottomVisible
        {
            get { return (bool)GetValue(IsBottomVisibleProperty); }
            set { SetValue(IsBottomVisibleProperty, value); }
        }

        #endregion IsBottomVisible : GridLength

        public RelayCommand TopClick { get; set; }
        public RelayCommand CenterClick { get; set; }
        public RelayCommand BottomClick { get; set; }

        #endregion BindableProperty

        #region 생성자

        public ViewModel_MainSide_Right()
        {
            TopClick = new RelayCommand(TopClickEventHandler);
            CenterClick = new RelayCommand(CenterClickEventHandler);
            BottomClick = new RelayCommand(BottomClickEventHandler);
        }

        private void TopClickEventHandler(object obj)
        {
            SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.TOP);
        }

        private void CenterClickEventHandler(object obj)
        {
            SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.CENTER);
        }

        private void BottomClickEventHandler(object obj)
        {
            SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.BOTTOM);
        }

        #endregion 생성자

        #region Instance Func

        void SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE mAIN_SIDE_ELEMENT_TYPE)
        {
            switch (mAIN_SIDE_ELEMENT_TYPE)
            {
                case MAIN_SIDE_ELEMENT_TYPE.TOP:
                    {
                        IsTopVisible = true;
                        IsCenterVisible = false;
                        IsBottomVisible = false;
                        TopHeight = new GridLength(ChroZenService_Const.dMainPageEnabledSideInfoHeight);
                        CenterHeight = new GridLength(0);
                        BottomHeight = new GridLength(0);
                        EventManager.DetectorSelectionChangedToEvent(0);
                    }
                    break;
                case MAIN_SIDE_ELEMENT_TYPE.CENTER:
                    {
                        IsTopVisible = false;
                        IsCenterVisible = true;
                        IsBottomVisible = false;
                        TopHeight = new GridLength(0);
                        CenterHeight = new GridLength(ChroZenService_Const.dMainPageEnabledSideInfoHeight);
                        BottomHeight = new GridLength(0);
                        EventManager.DetectorSelectionChangedToEvent(1);
                    }
                    break;
                case MAIN_SIDE_ELEMENT_TYPE.BOTTOM:
                    {
                        IsTopVisible = false;
                        IsCenterVisible = false;
                        IsBottomVisible = true;
                        TopHeight = new GridLength(0);
                        CenterHeight = new GridLength(0);
                        BottomHeight = new GridLength(ChroZenService_Const.dMainPageEnabledSideInfoHeight);
                        EventManager.DetectorSelectionChangedToEvent(2);
                    }
                    break;
            }
        }

        #endregion Instance Func
    }
}
