
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using YC_ChroZenGC_Type;

namespace ChroZenService
{
    public class ViewModel_MainChart : BindableNotifyBase
    {
        int _SelectedDetectorIndex;
        public int SelectedDetectorIndex { get { return _SelectedDetectorIndex; } set { _SelectedDetectorIndex = value; OnPropertyChanged("SelectedDetectorIndex"); } }

        //ObservableCollection<Point> _TemperatureValues = new ObservableCollection<Point>();

        //public ObservableCollection<Point> TemperatureValues { get { return _TemperatureValues; } set { _TemperatureValues = value; OnPropertyChanged("TemperatureValues"); } }

        //ObservableCollection<Point>[] _DetectorValues = new ObservableCollection<Point>[]
        //    {
        //        new ObservableCollection<Point>(),
        //        new ObservableCollection<Point>(),
        //        new ObservableCollection<Point>(),
        //    };
        //public ObservableCollection<Point>[] DetectorValues { get { return _DetectorValues; } set { _DetectorValues = value; OnPropertyChanged("DetectorValues"); } }

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

        public ViewModel_MainChart()
        {
            EventManager.onPACKCODE_Receivce += onPACKCODE_ReceivceEventHandler;
        }

        private void onPACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet)
        {
            switch (e_LC_PACK_CODE)
            {
                case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                    {
                        ChartElementRawData.yC_ChartElementRawDataDetector[0].RawData.Add(((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btCurSignal[0]);
                        ChartElementRawData.yC_ChartElementRawDataDetector[1].RawData.Add(((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btCurSignal[1]);
                        ChartElementRawData.yC_ChartElementRawDataDetector[2].RawData.Add(((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.btCurSignal[2]);
                        ChartElementRawData.yC_ChartElementRawDataTemperature.RawData.Add(((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fOven);
                        ChartElementRawData.yC_ChartElementRawDataTimeStamp.RawData.Add(((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.fRunTime);
                        EventManager.RawDataUpdatedEvent();
                    }
                    break;
            }
        }
    }
}
