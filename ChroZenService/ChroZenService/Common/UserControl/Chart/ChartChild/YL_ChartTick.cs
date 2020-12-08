using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class YL_ChartTick : BindableNotifyBase
    {
        string _TickLabel;
        public string TickLabel { get { return _TickLabel; } set { _TickLabel = value; OnPropertyChanged("TickLabel"); } }

        bool _IsMajorTick;
        public bool IsMajorTick { get { return _IsMajorTick; } set { _IsMajorTick = value; OnPropertyChanged("IsMajorTick"); } }


    }
}
