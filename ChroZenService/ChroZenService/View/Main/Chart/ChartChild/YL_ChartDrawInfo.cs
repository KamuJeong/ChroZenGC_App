using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public static class YL_ChartDrawInfo
    {
        public static float fChartHeight = 195;
        public static float fDetStartX = 69;
        public static float fDetTextYOffset = 5;
        public static float fDetTextXOffset = -50;
        public static float fTemperatureStartX = 0;
        public static SKPaint textPaint = new SKPaint
        {
            TextSize = 14,
            Color = new SKColor(0xff, 0xff, 0xff, 0xff),
            IsAntialias = true,
            FilterQuality = SKFilterQuality.High,
            IsEmbeddedBitmapText = true

        };
        public static YL_ChartLine XAxisLine = new YL_ChartLine();
        public static YL_ChartLine YDetAxisLine = new YL_ChartLine();
        public static YL_ChartLine YTempAxisLine = new YL_ChartLine();
        public static YL_ChartLine XAxisGuideLine = new YL_ChartLine();
        public static YL_ChartLine YTempAxisGuideLine = new YL_ChartLine();
        public static YL_ChartLine YDetAxisGuideLine = new YL_ChartLine();        
    }
}
