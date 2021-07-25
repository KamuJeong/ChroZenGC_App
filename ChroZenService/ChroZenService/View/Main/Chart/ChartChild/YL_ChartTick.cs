using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class YL_ChartTick : BindableNotifyBase
    {
        string _TickLabel;
        public string TickLabel { get { return _TickLabel; } set { if (_TickLabel != value) { _TickLabel = value; OnPropertyChanged("TickLabel"); } } }

        bool _IsMajorTick;
        public bool IsMajorTick { get { return _IsMajorTick; } set { if (_IsMajorTick != value) { _IsMajorTick = value; OnPropertyChanged("IsMajorTick"); } } }

        public SKPoint startPoint = new SKPoint();
        public SKPoint endPoint = new SKPoint();
    }
}
