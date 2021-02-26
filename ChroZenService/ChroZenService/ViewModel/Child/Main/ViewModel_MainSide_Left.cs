using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_MainSide_Left : BindableNotifyBase
    {
        #region NotifybaseProperty

        string _TopType;
        public string TopType { get { return _TopType; } set { if (_TopType != value) { _TopType = value; OnPropertyChanged("TopType"); } } }

        string _TopFlow;
        public string TopFlow { get { return _TopFlow; } set { if (_TopFlow != value) { _TopFlow = value; OnPropertyChanged("TopFlow"); } } }

        string _TopPressure;
        public string TopPressure { get { return _TopPressure; } set { if (_TopPressure != value) { _TopPressure = value; OnPropertyChanged("TopPressure"); } } }

        string _TopCarrierGasType;
        public string TopCarrierGasType { get { return _TopCarrierGasType; } set { if (_TopCarrierGasType != value) { _TopCarrierGasType = value; OnPropertyChanged("TopCarrierGasType"); } } }

        string _TopSplitRatio;
        public string TopSplitRatio { get { return _TopSplitRatio; } set { if (_TopSplitRatio != value) { _TopSplitRatio = value; OnPropertyChanged("TopSplitRatio"); } } }

        string _TopApcMode;
        public string TopApcMode { get { return _TopApcMode; } set { if (_TopApcMode != value) { _TopApcMode = value; OnPropertyChanged("TopApcMode"); } } }

        string _CenterType;
        public string CenterType { get { return _CenterType; } set { if (_CenterType != value) { _CenterType = value; OnPropertyChanged("CenterType"); } } }

        string _CenterFlow;
        public string CenterFlow { get { return _CenterFlow; } set { if (_CenterFlow != value) { _CenterFlow = value; OnPropertyChanged("CenterFlow"); } } }

        string _CenterPressure;
        public string CenterPressure { get { return _CenterPressure; } set { if (_CenterPressure != value) { _CenterPressure = value; OnPropertyChanged("CenterPressure"); } } }

        string _CenterCarrierGasType;
        public string CenterCarrierGasType { get { return _CenterCarrierGasType; } set { if (_CenterCarrierGasType != value) { _CenterCarrierGasType = value; OnPropertyChanged("CenterCarrierGasType"); } } }

        string _CenterSplitRatio;
        public string CenterSplitRatio { get { return _CenterSplitRatio; } set { if (_CenterSplitRatio != value) { _CenterSplitRatio = value; OnPropertyChanged("CenterSplitRatio"); } } }

        string _CenterApcMode;
        public string CenterApcMode { get { return _CenterApcMode; } set { if (_CenterApcMode != value) { _CenterApcMode = value; OnPropertyChanged("CenterApcMode"); } } }

        string _BottomType;
        public string BottomType { get { return _BottomType; } set { if (_BottomType != value) { _BottomType = value; OnPropertyChanged("BottomType"); } } }

        string _BottomFlow;
        public string BottomFlow { get { return _BottomFlow; } set { if (_BottomFlow != value) { _BottomFlow = value; OnPropertyChanged("BottomFlow"); } } }

        string _BottomPressure;
        public string BottomPressure { get { return _BottomPressure; } set { if (_BottomPressure != value) { _BottomPressure = value; OnPropertyChanged("BottomPressure"); } } }

        string _BottomCarrierGasType;
        public string BottomCarrierGasType { get { return _BottomCarrierGasType; } set { if (_BottomCarrierGasType != value) { _BottomCarrierGasType = value; OnPropertyChanged("BottomCarrierGasType"); } } }

        string _BottomSplitRatio;
        public string BottomSplitRatio { get { return _BottomSplitRatio; } set { if (_BottomSplitRatio != value) { _BottomSplitRatio = value; OnPropertyChanged("BottomSplitRatio"); } } }

        string _BottomApcMode;
        public string BottomApcMode { get { return _BottomApcMode; } set { if (_BottomApcMode != value) { _BottomApcMode = value; OnPropertyChanged("BottomApcMode"); } } }

        bool _IsTopAvailable;
        public bool IsTopAvailable
        {
            get { return _IsTopAvailable; }
            set
            {
                if (_IsTopAvailable != value)
                {
                    _IsTopAvailable = value;
                    if (value == true) SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.TOP);
                    OnPropertyChanged("IsTopAvailable");
                }
            }
        }

        bool _IsCenterAvailable;
        public bool IsCenterAvailable
        {
            get { return _IsCenterAvailable; }
            set
            {
                if (_IsCenterAvailable != value)
                {
                    _IsCenterAvailable = value;
                    if (value == true) SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.CENTER);
                    OnPropertyChanged("IsCenterAvailable");
                }
            }
        }

        bool _IsBottomAvailable;
        public bool IsBottomAvailable
        {
            get { return _IsBottomAvailable; }
            set
            {
                if (_IsBottomAvailable != value)
                {
                    _IsBottomAvailable = value;
                    if (value == true) SetElemntVisibility(MAIN_SIDE_ELEMENT_TYPE.BOTTOM);
                    OnPropertyChanged("IsBottomAvailable");
                }
            }
        }

        #endregion NotifybaseProperty

        #region BindableProperty

        #region TopHeight : GridLength

        public static readonly BindableProperty TopHeightProperty =
        BindableProperty.Create("TopHeight", typeof(GridLength), typeof(ViewModel_MainSide_Left),
            defaultValue: new GridLength(ChroZenService_Const.dMainPageEnabledSideInfoHeight)
            , defaultBindingMode: BindingMode.OneWay);


        public GridLength TopHeight
        {
            get { return (GridLength)GetValue(TopHeightProperty); }
            set { SetValue(TopHeightProperty, value); }
        }

        #endregion TopHeight : GridLength

        #region CenterHeight : GridLength

        public static readonly BindableProperty CenterHeightProperty =
        BindableProperty.Create("CenterHeight", typeof(GridLength), typeof(ViewModel_MainSide_Left),
            defaultValue: new GridLength(0)
            , defaultBindingMode: BindingMode.OneWay);

        public GridLength CenterHeight
        {
            get { return (GridLength)GetValue(CenterHeightProperty); }
            set { SetValue(CenterHeightProperty, value); }
        }

        #endregion CenterHeight : GridLength

        #region BottomHeight : GridLength

        public static readonly BindableProperty BottomHeightProperty =
        BindableProperty.Create("BottomHeight", typeof(GridLength), typeof(ViewModel_MainSide_Left),
            defaultValue: new GridLength(0)
            , defaultBindingMode: BindingMode.OneWay);


        public GridLength BottomHeight
        {
            get { return (GridLength)GetValue(BottomHeightProperty); }
            set { SetValue(BottomHeightProperty, value); }
        }

        #endregion BottomHeight : GridLength

        #region IsTopVisible : bool

        public static readonly BindableProperty IsTopVisibleProperty =
        BindableProperty.Create("IsTopVisible", typeof(bool), typeof(ViewModel_MainSide_Left),
            defaultValue: true
            , defaultBindingMode: BindingMode.TwoWay);

        public bool IsTopVisible
        {
            get { return (bool)GetValue(IsTopVisibleProperty); }
            set { SetValue(IsTopVisibleProperty, value); }
        }

        #endregion IsTopVisible : GridLength

        #region IsCenterVisible : bool

        public static readonly BindableProperty IsCenterVisibleProperty =
        BindableProperty.Create("IsCenterVisible", typeof(bool), typeof(ViewModel_MainSide_Left),
            defaultValue: false
            , defaultBindingMode: BindingMode.TwoWay);


        public bool IsCenterVisible
        {
            get { return (bool)GetValue(IsCenterVisibleProperty); }
            set { SetValue(IsCenterVisibleProperty, value); }
        }

        #endregion IsCenterVisible : GridLength

        #region IsBottomVisible : bool

        public static readonly BindableProperty IsBottomVisibleProperty =
        BindableProperty.Create("IsBottomVisible", typeof(bool), typeof(ViewModel_MainSide_Left),
            defaultValue: false
            , defaultBindingMode: BindingMode.TwoWay);

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

        public ViewModel_MainSide_Left()
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
                    }
                    break;
            }
        }

        #endregion Instance Func
    }
}
