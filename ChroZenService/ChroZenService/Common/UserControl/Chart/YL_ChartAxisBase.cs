using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class YL_ChartAxisBase : ContentView
    {
        public static readonly BindableProperty MajorTicksAndLabelsProperty =
            BindableProperty.Create("MajorTicksAndLabels", typeof(ObservableCollection<Tuple<double, string>>), typeof(YL_ChartAxisBase),
                propertyChanged: onMajorTicksAndLabelsPropertyChanged
                , defaultBindingMode: BindingMode.OneWay);

        public ObservableCollection<Tuple<double, string>> MajorTicksAndLabels
        {
            get { return (ObservableCollection<Tuple<double, string>>)GetValue(MajorTicksAndLabelsProperty); }
            set { SetValue(MajorTicksAndLabelsProperty, value); }
        }

        public static readonly BindableProperty ChartRawDataProperty =
            BindableProperty.Create("ChartRawData", typeof(YL_ChartElementRawData), typeof(YL_ChartAxisBase),
                defaultValue: new YL_ChartElementRawData(),
                propertyChanged: onChartRawDataPropertyChanged
                , defaultBindingMode: BindingMode.OneWay);

        public YL_ChartElementRawData ChartRawData
        {
            get { return (YL_ChartElementRawData)GetValue(ChartRawDataProperty); }
            set { SetValue(ChartRawDataProperty, value); }
        }
        public virtual void ChartRawDataUpdated() { }

        private static void onMajorTicksAndLabelsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as YL_ChartAxisBase).MajorTicksAndLabels = (newValue as ObservableCollection<Tuple<double, string>>);
            }
        }

        private static void onChartRawDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != null)
            {

            }
            if (newValue != null)
            {
                (bindable as YL_ChartAxisBase).ChartRawData = (newValue as YL_ChartElementRawData);
            }
        }
    }
}
