using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ChroZenService.ChartHelper;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_OVEN;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_ChartYAxis : YL_ChartAxisBase
    {
        public static readonly BindableProperty ChartAxisTypeProperty =
        BindableProperty.Create("ChartAxisType", typeof(CHART_AXIS_TYPE), typeof(View_ChartYAxis),
            propertyChanged: onChartAxisTypePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        public CHART_AXIS_TYPE ChartAxisType
        {
            get { return (CHART_AXIS_TYPE)GetValue(ChartAxisTypeProperty); }
            set { SetValue(ChartAxisTypeProperty, value); }
        }

        private static void onChartAxisTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as View_ChartYAxis).ChartAxisType = (CHART_AXIS_TYPE)newValue;
            }
        }

        List<YL_ChartTick> _AxisLabels = new List<YL_ChartTick>();
        public List<YL_ChartTick> AxisLabels
        {
            get { return _AxisLabels; }
            set { _AxisLabels = value; }
        }

        public View_ChartYAxis()
        {
            InitializeComponent();

            sKCanvasViewXAxis.PaintSurface += OnCanvasViewPaintSurface;
            EventManager.onChartDeltaChanged += ChartDeltaChangedEventHandler;
            EventManager.onChartOffsetChanged += onChartOffsetChangedEventHandler;
            EventManager.onTemperatureUpdated += TemperatureUpdatedEventHandler;
            EventManager.onChartOffsetChanged += onChartOffsetChangedEventHandler;
        }

        float VerticalDelta = 1;
        float VerticalOffset = 0;

        private void TemperatureUpdatedEventHandler()
        {
            //Task.Factory.StartNew(() => {
            CalcChartData();
            sKCanvasViewXAxis.InvalidateSurface();
            //});

        }

        private void onChartOffsetChangedEventHandler(double deltaX, float deltaY)
        {
            //Task.Factory.StartNew(() =>
            //{
            VerticalOffset = deltaY;
            CalcChartData();
            sKCanvasViewXAxis.InvalidateSurface();
            //Debug.WriteLine(string.Format("View_ChartYAxis : YAxis Y Offset Changed To={0}", deltaY));
            //});

        }

        private void CalcChartData()
        {
            switch (ChartAxisType)
            {
                case CHART_AXIS_TYPE.Y_SIGNAL:
                    {
                        YL_ChartDrawInfo.fDetStartX = 69;
                        YL_ChartDrawInfo.YDetAxisLine.startPoint = new SKPoint(YL_ChartDrawInfo.fDetStartX, 0);
                        YL_ChartDrawInfo.YDetAxisLine.linePaint.Color = new SKColor(0xff, 0xff, 0xff, 0xff);

                        float fStartX = 59;
                        //Det Y축 시작 값
                        float fTStartVal = ChartHelper.GetMaxSignal(VerticalDelta, VerticalOffset);
                        float fValRange = (fTStartVal - VerticalOffset);
                        AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.Y_DET, fTStartVal, VerticalOffset, fVerticalDelta: VerticalDelta);
                        //Debug.WriteLine(string.Format("fTStartVal = {0}, VerticalOffset={1}, AxisLabels.Count={2}", fTStartVal, VerticalOffset, AxisLabels.Count));
                        //Y축 Majortick 시작 index
                        //float fYMajorTickSeed = (float)Math.Abs(AxisLabels.Count * VerticalOffset / fValRange);
                        TickInfo tickInfo = GetTickInfo(ChartHelper.E_LABEL_TYPE.Y_DET, fTStartVal, VerticalOffset, fVerticalDelta: VerticalDelta);

                        float fMinValTickInterval = tickInfo.fMajorTickInterval / ChroZenService_Const.MinorTicksPerMajorTick;

                        //minor tick 구간의 수
                        float fYMinorTickRangeCount = fValRange / fMinValTickInterval;

                        //minor tick 구간 pixel범위
                        float fYMinorTickInterval = YL_ChartDrawInfo.fChartHeight / (fYMinorTickRangeCount);

                        //major tick 구간 pixel범위
                        float fYMajorTickInterval = fYMinorTickInterval * ChroZenService_Const.MinorTicksPerMajorTick;

                        //Det Y축 시작 pixel Offset
                        float fYMinorTickOffset = -fValRange % fYMinorTickInterval;

                        float fYMajorTickOffset = -fValRange % fYMajorTickInterval;


                        int nYMajorTickStartOffset = 0;

                        //최소 값을 minTickVal로 나누어 MajorTick 시작 인덱스 계산
                        //(int)Abs(minval/mintickval) -> minTickCount 취득
                        int nMinorTickCountOfMinVal = (int)Math.Abs(Math.Ceiling((fTStartVal - fValRange) / (tickInfo.fMajorTickInterval / ChroZenService_Const.MinorTicksPerMajorTick)));
                        if ((fTStartVal - fValRange) >= 0)
                        {
                            nYMajorTickStartOffset = (ChroZenService_Const.MinorTicksPerMajorTick - nMinorTickCountOfMinVal % ChroZenService_Const.MinorTicksPerMajorTick) % ChroZenService_Const.MinorTicksPerMajorTick;

                        }
                        else
                            nYMajorTickStartOffset = nMinorTickCountOfMinVal % ChroZenService_Const.MinorTicksPerMajorTick;


                        float fMinVal = fTStartVal - fValRange;
                        Debug.WriteLine(string.Format("Raw fMinVal = {0}", fMinVal));
                        float nMajorTickVal = (float)(fValRange / (fYMinorTickRangeCount / ChroZenService_Const.MinorTicksPerMajorTick));
                        float nMinorTickVal = nMajorTickVal / ChroZenService_Const.MinorTicksPerMajorTick;
                        float fSpareValForMinorTick = fMinVal % nMajorTickVal;
                        fYMinorTickOffset = ((fMinVal % nMinorTickVal) / nMinorTickVal) * fYMinorTickInterval;
                        if (fMinVal > 0)
                            fYMinorTickOffset = fYMinorTickOffset - fYMinorTickInterval;

                        AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.Y_DET, fTStartVal, VerticalOffset, nYMajorTickStartOffset, VerticalDelta);
                        //Debug.WriteLine(string.Format("fTStartVal = {0}, VerticalOffset={1}, AxisLabels.Count={2}, nYMajorTickStartOffset={3}", fTStartVal, VerticalOffset, AxisLabels.Count, nYMajorTickStartOffset));
                        float fMajorTickLength = 10;
                        float fMinorTickLength = 5;


                        label0.IsVisible = false;
                        label1.IsVisible = false;
                        label2.IsVisible = false;
                        label3.IsVisible = false;
                        label4.IsVisible = false;
                        label5.IsVisible = false;
                        label6.IsVisible = false;
                        label7.IsVisible = false;
                        label8.IsVisible = false;

                        float fTextYOffest = 5;
                        float fTextXOffset = -40;

                        for (int i = 0; i < AxisLabels.Count; i++)
                        {
                            //Draw Major Tick 
                            if ((i % ChroZenService_Const.MinorTicksPerMajorTick) == nYMajorTickStartOffset)
                            {
                                fStartX = 59;
                                int nMajorTickIndex = i / ChroZenService_Const.MinorTicksPerMajorTick;
                                AxisLabels[i].startPoint.X = fStartX;
                                AxisLabels[i].startPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMajorTickInterval * nMajorTickIndex) - (fYMinorTickInterval * nYMajorTickStartOffset) + fYMinorTickOffset;
                                //Debug.WriteLine(string.Format("nYMajorTickstartPoint = {0}", startPoint.Y));

                                AxisLabels[i].endPoint.X = fStartX + fMajorTickLength;
                                AxisLabels[i].endPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMajorTickInterval * nMajorTickIndex) - (fYMinorTickInterval * nYMajorTickStartOffset) + fYMinorTickOffset;
                                //canvas.DrawLine(startPoint, endPoint, temperaturePaint);

                                SKPoint textPoint = new SKPoint();
                                textPoint.X = AxisLabels[i].endPoint.X + fTextXOffset;
                                textPoint.Y = AxisLabels[i].endPoint.Y + fTextYOffest;
                                Thickness textMargin = new Thickness(textPoint.X, textPoint.Y, 0, 0);
                                SKPaint textPaint = new SKPaint
                                {
                                    TextSize = 14,
                                    Color = new SKColor(0xff, 0xff, 0xff, 0xff),
                                    IsAntialias = true,
                                    FilterQuality = SKFilterQuality.High,
                                    IsEmbeddedBitmapText = true

                                };
                                //canvas.DrawText(AxisLabels[i].TickLabel, textPoint, textPaint);                               
                            }
                            //Draw Minor Tick
                            else
                            {
                                fStartX = 64;
                                AxisLabels[i].startPoint.X = fStartX;
                                AxisLabels[i].startPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMinorTickInterval * i) + fYMinorTickOffset;
                                AxisLabels[i].endPoint.X = fStartX + fMinorTickLength;
                                AxisLabels[i].endPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMinorTickInterval * i) + fYMinorTickOffset;
                            }
                        }
                    }
                    break;
                case CHART_AXIS_TYPE.Y_TEMPERATURE:
                    {

                    }
                    break;
            }
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            if (ChartAxisType == CHART_AXIS_TYPE.Y_TEMPERATURE)
            {
                YL_ChartDrawInfo.fTemperatureStartX = 0;
                YL_ChartDrawInfo.YTempAxisLine.startPoint = new SKPoint(YL_ChartDrawInfo.fTemperatureStartX, 0);
                YL_ChartDrawInfo.YTempAxisLine.linePaint.Color = new SKColor(0x3c, 0xb0, 0x43, 0xff);

                AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.Y_TEMP);

                //Y축 최대 값은 가시성을 고려하여 Max온도의 2배로 설정
                float fYAxisMaxVal = ChartHelper.GetMaxTemperature() * 2 > 400 ? 400 : ChartHelper.GetMaxTemperature() * 2;

                //minor tick당 pixel 수
                float fYAxisUnit = YL_ChartDrawInfo.fChartHeight / fYAxisMaxVal;

                //major tick당 pixel 수
                float fYMinorTickInterval = fYAxisMaxVal / AxisLabels.Count * fYAxisUnit;
                float fYMajotTickInterval = fYMinorTickInterval * ChroZenService_Const.MinorTicksPerMajorTick;

                float fMajorTickLength = 10;
                float fMinorTickLength = 5;

                label0.IsVisible = false;
                label1.IsVisible = false;
                label2.IsVisible = false;
                label3.IsVisible = false;
                label4.IsVisible = false;
                label5.IsVisible = false;
                label6.IsVisible = false;
                label7.IsVisible = false;
                label8.IsVisible = false;

                float fTextYOffest = -10;

                for (int i = 0; i < AxisLabels.Count; i++)
                {
                    //Draw Major Tick 
                    if (i % ChroZenService_Const.MinorTicksPerMajorTick == 0)
                    {
                        int nMajorTickIndex = i / ChroZenService_Const.MinorTicksPerMajorTick;
                        AxisLabels[i].startPoint.X = YL_ChartDrawInfo.fTemperatureStartX;
                        AxisLabels[i].startPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMajotTickInterval * nMajorTickIndex);
                        AxisLabels[i].endPoint.X = YL_ChartDrawInfo.fTemperatureStartX + fMajorTickLength;
                        AxisLabels[i].endPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMajotTickInterval * nMajorTickIndex);
                        //canvas.DrawLine(startPoint, endPoint, temperaturePaint);

                        SKPoint textPoint = new SKPoint();
                        textPoint.X = AxisLabels[i].endPoint.X;
                        textPoint.Y = AxisLabels[i].endPoint.Y + fTextYOffest;
                        Thickness textMargin = new Thickness(textPoint.X, textPoint.Y, 0, 0);

                        switch (nMajorTickIndex)
                        {
                            case 0:
                                {
                                    label0.IsVisible = true;
                                    label0.Text = AxisLabels[i].TickLabel;
                                    label0.Margin = textMargin;
                                }
                                break;
                            case 1:
                                {
                                    label1.IsVisible = true;
                                    label1.Text = AxisLabels[i].TickLabel;
                                    label1.Margin = textMargin;
                                }
                                break;
                            case 2:
                                {
                                    label2.IsVisible = true;
                                    label2.Text = AxisLabels[i].TickLabel;
                                    label2.Margin = textMargin;
                                }
                                break;
                            case 3:
                                {
                                    label3.IsVisible = true;
                                    label3.Text = AxisLabels[i].TickLabel;
                                    label3.Margin = textMargin;
                                }
                                break;
                            case 4:
                                {
                                    label4.IsVisible = true;
                                    label4.Text = AxisLabels[i].TickLabel;
                                    label4.Margin = textMargin;
                                }
                                break;
                            case 5:
                                {
                                    label5.IsVisible = true;
                                    label5.Text = AxisLabels[i].TickLabel;
                                    label5.Margin = textMargin;
                                }
                                break;
                            case 6:
                                {
                                    label6.IsVisible = true;
                                    label6.Text = AxisLabels[i].TickLabel;
                                    label6.Margin = textMargin;
                                }
                                break;
                            case 7:
                                {
                                    label7.IsVisible = true;
                                    label7.Text = AxisLabels[i].TickLabel;
                                    label7.Margin = textMargin;
                                }
                                break;
                            case 8:
                                {
                                    label8.IsVisible = true;
                                    label8.Text = AxisLabels[i].TickLabel;
                                    label8.Margin = textMargin;
                                }
                                break;
                        }
                    }
                    //Draw Minor Tick
                    else
                    {
                        AxisLabels[i].startPoint.X = YL_ChartDrawInfo.fTemperatureStartX;
                        AxisLabels[i].startPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMinorTickInterval * i);
                        AxisLabels[i].endPoint.X = YL_ChartDrawInfo.fTemperatureStartX + fMinorTickLength;
                        AxisLabels[i].endPoint.Y = (YL_ChartDrawInfo.fChartHeight - fYMinorTickInterval * i);
                        //        canvas.DrawLine(fStartX,
                        //(fChartHeight - fYMinorTickInterval * i),
                        //fStartX + fMinorTickLength,
                        //(fChartHeight - fYMinorTickInterval * i), temperaturePaint);
                    }
                }
                canvas.DrawLine(YL_ChartDrawInfo.fTemperatureStartX, 0, YL_ChartDrawInfo.fTemperatureStartX, YL_ChartDrawInfo.fChartHeight, YL_ChartDrawInfo.YTempAxisLine.linePaint);
                for (int i = 0; i < AxisLabels.Count; i++)
                {
                    canvas.DrawLine(AxisLabels[i].startPoint, AxisLabels[i].endPoint, YL_ChartDrawInfo.YTempAxisLine.linePaint);
                }
            }
            else if (ChartAxisType == CHART_AXIS_TYPE.Y_SIGNAL)
            {
                canvas.DrawLine(YL_ChartDrawInfo.fDetStartX, 0, YL_ChartDrawInfo.fDetStartX, YL_ChartDrawInfo.fChartHeight, YL_ChartDrawInfo.YDetAxisLine.linePaint);


                for (int i = 0; i < AxisLabels.Count; i++)
                {
                    //Draw Major Tick 
                    if (AxisLabels[i].IsMajorTick)
                    {
                        SKPoint textPoint = new SKPoint();
                        float fXTextOffset = -YL_ChartDrawInfo.textPaint.MeasureText(AxisLabels[i].TickLabel) - 10;
                        //Debug.WriteLine(string.Format("fXTextOffset={0}", fXTextOffset));
                        //textPoint.X = AxisLabels[i].endPoint.X + YL_ChartDrawInfo.fDetTextXOffset;
                        textPoint.X = AxisLabels[i].endPoint.X + fXTextOffset;
                        textPoint.Y = AxisLabels[i].endPoint.Y + YL_ChartDrawInfo.fDetTextYOffset;

                        canvas.DrawText(AxisLabels[i].TickLabel, textPoint, YL_ChartDrawInfo.textPaint);
                    }
                    //Draw Minor Tick
                    canvas.DrawLine(AxisLabels[i].startPoint, AxisLabels[i].endPoint, YL_ChartDrawInfo.YDetAxisLine.linePaint);

                }
            }
        }


        private void ChartDeltaChangedEventHandler(double deltaX, float deltaY)
        {

            VerticalDelta = deltaY;
            CalcChartData();
            sKCanvasViewXAxis.InvalidateSurface();
            //Debug.WriteLine(string.Format("View_ChartYAxis : YAxis Y Delta Changed To={0}", deltaY));


        }
    }
}