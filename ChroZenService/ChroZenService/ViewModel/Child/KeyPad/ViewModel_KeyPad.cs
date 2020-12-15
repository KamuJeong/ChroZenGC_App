using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
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

        #region CurrentValue : double

        public static readonly BindableProperty CurrentValueProperty =
        BindableProperty.Create("CurrentValue", typeof(double), typeof(ViewModel_KeyPad),
            defaultValue: 0d,
            propertyChanged: onCurrentValuePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onCurrentValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_KeyPad).CurrentValue = (double)newValue;
            }
        }

        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        #endregion CurrentValue : double

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

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
