using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChroZenService
{
    public class YL_ChartElementRawData
    {
        //public YC_ChartElementRawDataTemperature yC_ChartElementRawDataTemperature = new YC_ChartElementRawDataTemperature();

        public YC_ChartElementRawDataDetector[] yC_ChartElementRawDataDetector = new
            YC_ChartElementRawDataDetector[3]
        {
            new YC_ChartElementRawDataDetector(),
            new YC_ChartElementRawDataDetector(),
            new YC_ChartElementRawDataDetector()
        };

        public YC_ChartElementRawDataTimeStamp yC_ChartElementRawDataTimeStamp = new YC_ChartElementRawDataTimeStamp();

    }

    public class YC_ChartElementRawDataTemperature
    {
        public List<float> RawData = new List<float>();
    }

    public class YC_ChartElementRawDataDetector
    {
        public List<float> RawData = new List<float>();
    }

    public class YC_ChartElementRawDataTimeStamp
    {
        public List<float> RawData = new List<float>();
    }
}
