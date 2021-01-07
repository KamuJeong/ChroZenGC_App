using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;
using static ChroZenService.KeyPad;

namespace ChroZenService
{
    public class ViewModel_KeyPad : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_KeyPad()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        #region KEY_PAD_SET_MEASURE_TYPE : E_KEY_PAD_SET_MEASURE_TYPE

        public static readonly BindableProperty KEY_PAD_SET_MEASURE_TYPEProperty =
        BindableProperty.Create("KEY_PAD_SET_MEASURE_TYPE", typeof(E_KEY_PAD_SET_MEASURE_TYPE), typeof(ViewModel_KeyPad));

        public E_KEY_PAD_SET_MEASURE_TYPE KEY_PAD_SET_MEASURE_TYPE
        {
            get { return (E_KEY_PAD_SET_MEASURE_TYPE)GetValue(KEY_PAD_SET_MEASURE_TYPEProperty); }
            set { SetValue(KEY_PAD_SET_MEASURE_TYPEProperty, value); }
        }

        #endregion KEY_PAD_SET_MEASURE_TYPE : E_KEY_PAD_SET_MEASURE_TYPE

        #region IsNeedRefresh : bool

        public static readonly BindableProperty IsNeedRefreshProperty =
        BindableProperty.Create("IsNeedRefresh", typeof(bool), typeof(ViewModel_KeyPad));

        public bool IsNeedRefresh
        {
            get { return (bool)GetValue(IsNeedRefreshProperty); }
            set { SetValue(IsNeedRefreshProperty, value); }
        }

        #endregion IsNeedRefresh : bool

        #region CurrentValue : string

        public static readonly BindableProperty CurrentValueProperty =
        BindableProperty.Create("CurrentValue", typeof(string), typeof(ViewModel_KeyPad));

        public string CurrentValue
        {
            get { return (string)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        #endregion CurrentValue : string

        #region IsKeyPadShown : bool

        public static readonly BindableProperty IsKeyPadShownProperty =
        BindableProperty.Create("IsKeyPadShown", typeof(bool), typeof(ViewModel_KeyPad),
            defaultValue: false,
            propertyChanged: onIsKeyPadShownPropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onIsKeyPadShownPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_KeyPad).IsKeyPadShown = (bool)newValue;
            }
        }

        public bool IsKeyPadShown
        {
            get { return (bool)GetValue(IsKeyPadShownProperty); }
            set { SetValue(IsKeyPadShownProperty, value); }
        }

        #endregion IsKeyPadShown : bool

        #region Title : string

        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(ViewModel_KeyPad),
            defaultValue: "",
            propertyChanged: onTitlePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_KeyPad).Title = (string)newValue;
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion Title : string

        #region KeyPadType : E_KEYPAD_TYPE

        public static readonly BindableProperty KeyPadTypeProperty =
        BindableProperty.Create("KeyPadType", typeof(E_KEYPAD_TYPE), typeof(ViewModel_KeyPad),
            defaultValue: E_KEYPAD_TYPE.INT,
            propertyChanged: onKeyPadTypePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onKeyPadTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_KeyPad).KeyPadType = (E_KEYPAD_TYPE)newValue;
            }
        }

        public E_KEYPAD_TYPE KeyPadType
        {
            get { return (E_KEYPAD_TYPE)GetValue(KeyPadTypeProperty); }
            set { SetValue(KeyPadTypeProperty, value); }
        }

        #endregion KeyPadType : E_KEYPAD_TYPE

        #region MaxValue : double

        public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create("MaxValue", typeof(double), typeof(ViewModel_KeyPad),
            defaultValue: 0d,
            propertyChanged: onMaxValuePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onMaxValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_KeyPad).MaxValue = (double)newValue;
            }
        }

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        #endregion MaxValue : double

        #region MinValue : double

        public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create("MinValue", typeof(double), typeof(ViewModel_KeyPad),
            defaultValue: 0d,
            propertyChanged: onMinValuePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onMinValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_KeyPad).MinValue = (double)newValue;
            }
        }

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        #endregion MinValue : double

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

        #region KeyPadClickCommand

        public static readonly BindableProperty KeyPadClickCommandProperty = BindableProperty.Create("KeyPadClickCommand", typeof(RelayCommand), typeof(ViewModel_KeyPad));

        public RelayCommand KeyPadClickCommand
        {
            set
            {
                SetValue(KeyPadClickCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(KeyPadClickCommandProperty);

            }
        }
        #endregion KeyPadClickCommand

        #region DeleteCommand

        public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create("DeleteCommand", typeof(RelayCommand), typeof(ViewModel_KeyPad));

        public RelayCommand DeleteCommand
        {
            set
            {
                SetValue(DeleteCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(DeleteCommandProperty);

            }
        }
        #endregion DeleteCommand

        #region CancelCommand

        public static readonly BindableProperty CancelCommandProperty = BindableProperty.Create("CancelCommand", typeof(RelayCommand), typeof(ViewModel_KeyPad));

        public RelayCommand CancelCommand
        {
            set
            {
                SetValue(CancelCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(CancelCommandProperty);

            }
        }
        #endregion CancelCommand

        #region ApplyCommand

        public static readonly BindableProperty ApplyCommandProperty = BindableProperty.Create("ApplyCommand", typeof(RelayCommand), typeof(ViewModel_KeyPad));

        public RelayCommand ApplyCommand
        {
            set
            {
                SetValue(ApplyCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(ApplyCommandProperty);

            }
        }
        #endregion ApplyCommand

        #region OnCommand

        public static readonly BindableProperty OnCommandProperty = BindableProperty.Create("OnCommand", typeof(RelayCommand), typeof(ViewModel_KeyPad));

        public RelayCommand OnCommand
        {
            set
            {
                SetValue(OnCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(OnCommandProperty);

            }
        }
        #endregion OnCommand

        #region OffCommand

        public static readonly BindableProperty OffCommandProperty = BindableProperty.Create("OffCommand", typeof(RelayCommand), typeof(KeyPad));

        public RelayCommand OffCommand
        {
            set
            {
                SetValue(OffCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(OffCommandProperty);

            }
        }
        #endregion OffCommand

        #endregion Command

        #endregion Binding

        #region Instance Func

        public void CopyFrom(ViewModel_KeyPad vmInstance)
        {
            this.KeyPadClickCommand = vmInstance.KeyPadClickCommand;
            this.DeleteCommand = vmInstance.DeleteCommand;
            this.CancelCommand = vmInstance.CancelCommand;
            this.ApplyCommand = vmInstance.ApplyCommand;
            this.OnCommand = vmInstance.OnCommand;
            this.OffCommand = vmInstance.OffCommand;
            if (vmInstance.CurrentValue != null)
                this.CurrentValue = vmInstance.CurrentValue;            
            this.IsKeyPadShown = vmInstance.IsKeyPadShown;
            this.Title = vmInstance.Title;
            this.KeyPadType = vmInstance.KeyPadType;
            this.MaxValue = vmInstance.MaxValue;
            this.MinValue = vmInstance.MinValue;
            this.IsNeedRefresh = true;
            this.KEY_PAD_SET_MEASURE_TYPE = vmInstance.KEY_PAD_SET_MEASURE_TYPE;
        }

        #endregion Instance Func
    }
}
