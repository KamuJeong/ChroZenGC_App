using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChroZenService
{
    interface I_YLChartAxisBase
    {
        ObservableCollection<Tuple<double, string>> MajorTicksAndLabels { get; set; }
    }
}
