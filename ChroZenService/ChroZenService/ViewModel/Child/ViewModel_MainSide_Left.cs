using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_MainSide_Left : BindableNotifyBase
    {
        public static readonly BindableProperty ChartElementRawDataProperty =
        BindableProperty.Create("ChartElementRawData", typeof(YL_ChartElementRawData), typeof(ViewModel_MainChart),
            defaultValue: new YL_ChartElementRawData(),
            propertyChanged: onChartRawDataPropertyChanged
            , defaultBindingMode: BindingMode.OneWay);

        private static void onChartRawDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ViewModel_MainChart).ChartElementRawData = (newValue as YL_ChartElementRawData);
            }
        }

        public YL_ChartElementRawData ChartElementRawData
        {
            get { return (YL_ChartElementRawData)GetValue(ChartElementRawDataProperty); }
            set { SetValue(ChartElementRawDataProperty, value); }
        }
    }
}
