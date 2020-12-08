using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YC_ChroZenGC_Type;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_OVEN;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YL_Chart : ContentView
    {
        public static readonly BindableProperty ChartRawDataProperty =
            BindableProperty.Create("ChartRawData", typeof(YL_ChartElementRawData), typeof(YL_Chart),
            defaultValue: new YL_ChartElementRawData(),
            propertyChanged: onYL_ChartElementRawDataPropertyChanged
            , defaultBindingMode: BindingMode.OneWay);

        public YL_ChartElementRawData ChartRawData
        {
            get { return (YL_ChartElementRawData)GetValue(ChartRawDataProperty); }
            set { SetValue(ChartRawDataProperty, value); }
        }

        double _VerticalOffset = 0;

        /// <summary>
        /// Detector 값 전시 Offset
        /// </summary>
        public double VerticalOffset
        {
            get { return _VerticalOffset; }
            set
            {

                _VerticalOffset = value;
            }
        }

        double _VerticalDelta = 1;

        /// <summary>
        /// Detector값 Y축 Scale
        /// </summary>
        public double VerticalDelta
        {
            get { return _VerticalDelta; }
            set
            {
                //if (value < -235) _VerticalDelta = -234;
                //else if (value > 10000) _VerticalDelta = 10000;
                //else
                _VerticalDelta = value;
            }
        }

        float _fMaxDet = 0.02f;
        public float fMaxDet { get { return _fMaxDet; } set { _fMaxDet = value; OnPropertyChanged("fMaxDet"); } }

        float _fMinDet = 0;
        public float fMinDet { get { return _fMaxDet; } set { _fMaxDet = value; OnPropertyChanged("fMinDet"); } }

        private static void onYL_ChartElementRawDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as YL_Chart).ChartRawData = (newValue as YL_ChartElementRawData);
        }

        public YL_Chart()
        {
            InitializeComponent();
            //skb = new SKBitmap(470, 235, SKColorType.Bgra8888, SKAlphaType.Opaque);
            sKCanvasViewChart.PaintSurface += OnCanvasViewPaintSurface;
            sKCanvasViewTemperatureChart.PaintSurface += SKCanvasViewTemperatureChart_PaintSurface;
            EventManager.onRunStarted += onRunStartedEventHandler;
            EventManager.onRunStopped += onRunStoppedEventHandler;
            EventManager.onMethodUpdated += onMethodUpdatedEventHandler;
            EventManager.onRawDataUpdated += onRawDataUpdatedHandler;
            EventManager.onTemperatureUpdated += onTemperatureUpdatedEventHandler;
        }

        private void SKCanvasViewTemperatureChart_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            SKPaint temperaturePaint = new SKPaint();
            temperaturePaint.Color = new SKColor(0x00, 0xff, 0x00, 0xff);
            temperaturePaint.IsAntialias = true;
            //temperaturePaint.IsDither = true;
            //temperaturePaint.Style = SKPaintStyle.Stroke;
            temperaturePaint.StrokeWidth = 2;
            SKPath temperaturePath = new SKPath();

            float fXUnit = 470 / (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTotalRunTime);
            float fYUnitSeed = (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet * 2) > 400 ? 400 : (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet * 2);
            float fYUnitForOven = 195 / fYUnitSeed;

            canvas.Clear();
            switch ((E_OVEN_MODE)DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.btMode)
            {
                case E_OVEN_MODE.ISO_THREMAL:
                    {
                        canvas.DrawLine(0,
                (235f - DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet * fYUnitForOven),
                470,
                (235f - DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet * fYUnitForOven), temperaturePaint);
                    }
                    break;
                case E_OVEN_MODE.PROGRAM_MODE:
                    {
                        float fTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fInitTime;
                        float fTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet;

                        float fTotalTime = 0;
                        fTotalTime += fTime;

                        float fTempMax = fTemp;
                        float fTempMin = 0;

                        List<SKPoint> sKPoints = new List<SKPoint>();
                        SKPoint tempStart = new SKPoint(0, fTemp);
                        sKPoints.Add(tempStart);
                        SKPoint tempP1 = new SKPoint(fTime * fXUnit, fTemp);
                        sKPoints.Add(tempP1);

                        for (int i = 0; i < DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm.Length; i++)
                        {
                            if (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fRate <= 0) continue;

                            if (fTempMax < DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp)
                            {
                                fTempMax = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp;
                            }

                            if (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp < fTempMin)
                            {
                                fTempMin = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp;
                            }

                            fTime = Math.Abs(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp - fTemp) / DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fRate;

                            fTotalTime += fTime;
                            sKPoints.Add(new SKPoint(fTotalTime * fXUnit, DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp));
                            fTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp;

                            fTotalTime += DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTime;
                            sKPoints.Add(new SKPoint(fTotalTime * fXUnit, DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp));
                        }

                        fYUnitSeed = (fTempMax * 2) > 400 ? 400 : fTempMax * 2;
                        fYUnitForOven = 195 / fYUnitSeed;

                        for (int i = 1; i < sKPoints.Count; i++)
                        {
                            //temperaturePath.LineTo(sKPoints[i].X, (235 - sKPoints[i].Y * fYUnitForOven));
                            canvas.DrawLine(sKPoints[i - 1].X, (235 - sKPoints[i - 1].Y * fYUnitForOven), sKPoints[i].X, (235 - sKPoints[i].Y * fYUnitForOven), temperaturePaint);
                        }
                        //canvas.DrawPath(temperaturePath, temperaturePaint);
                    }
                    break;
            }
        }

        private void onTemperatureUpdatedEventHandler()
        {
            //Task.Factory.StartNew(() => {
            sKCanvasViewTemperatureChart.InvalidateSurface();
            //});
        }

        private void CalculateLabels(ref ObservableCollection<string> labels)
        {

        }

        private void onRawDataUpdatedHandler()
        {
            //Task.Factory.StartNew(() => {
            sKCanvasViewChart.InvalidateSurface();
            //});
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            SKPaint temperaturePaint = new SKPaint();
            SKPaint detectorPaint = new SKPaint();
            SKPaint currentTimeMarkerPaint = new SKPaint();
            currentTimeMarkerPaint.StrokeWidth = 2;
            detectorPaint.StrokeWidth = 2;
            canvas.Clear();
            {
                detectorPaint.Color = new SKColor(0xff, 0xff, 0xff, 0xff);
                temperaturePaint.Color = new SKColor(0x00, 0xff, 0x00, 0xff);
                currentTimeMarkerPaint.Color = new SKColor(0xff, 0xa5, 0x0, 0xff);
                //470 pixel에 fTotalRunTime*60*5개의 data point를 찍고 각 point를 line으로 잇는다.
                float fXUnit = 470 / (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTotalRunTime);

                float fTStartVal = ChartHelper.GetMaxSignal((float)VerticalDelta, (float)VerticalOffset);
                float fDetSignalRange = (float)(fTStartVal - VerticalOffset);

                float fChartHeight = 195;
                float fYUnitForDetector = fChartHeight / fDetSignalRange;
                float fYUnitOffsetForDetector = (float)(fYUnitForDetector * VerticalOffset);
                float fYUnitForOven = fChartHeight / DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet;

                if (ChartRawData.yC_ChartElementRawDataTimeStamp.RawData.Count > 1)
                {
                    float xStart = 0;
                    float xEnd = 0;
                    for (int i = 1; i < ChartRawData.yC_ChartElementRawDataTimeStamp.RawData.Count; i++)
                    {
                        float detY1Val = (235f - ChartRawData.yC_ChartElementRawDataDetector[0].RawData[i] * fYUnitForDetector + fYUnitOffsetForDetector);
                        float detY2Val = (235f - ChartRawData.yC_ChartElementRawDataDetector[0].RawData[i - 1] * fYUnitForDetector + fYUnitOffsetForDetector);
                        xStart = ChartRawData.yC_ChartElementRawDataTimeStamp.RawData[i] * fXUnit;
                        xEnd = ChartRawData.yC_ChartElementRawDataTimeStamp.RawData[i - 1] * fXUnit;
                        canvas.DrawLine(xStart,
                        detY1Val,
                        xEnd,
                        detY2Val, detectorPaint);

                    }
                    //주황색 현재 시간 기준 세로 선
                    canvas.DrawLine(xEnd,
                        235 - 0,
                        xEnd,
                        235 - 195, currentTimeMarkerPaint);
                }
            }
        }

        private void onRunStartedEventHandler()
        {
            DataManager.RunState.e_CHART_DRAW_STATE = DataManager.RunState.E_CHART_DRAW_STATE.DRAW;
        }

        private void onRunStoppedEventHandler()
        {
            DataManager.RunState.e_CHART_DRAW_STATE = DataManager.RunState.E_CHART_DRAW_STATE.STOP;
        }

        private void onMethodUpdatedEventHandler()
        {
            Task.Factory.StartNew(() => UpdateChart());
        }

        void DrawGridLine()
        {

        }

        void StartDrawChartData()
        {

        }

        void StopDrawChartData()
        {

        }

        void UpdateChart()
        {
            DrawGridLine();

        }

        private void onVerticalOffsetChanged()
        {
            Debug.WriteLine(string.Format("onVerticalOffsetChanged : VerticalOffset={0}", VerticalOffset));
        }

        private void onVerticalDeltaChanged()
        {
            Debug.WriteLine(string.Format("onVerticalDeltaChanged : VerticalDelta={0}", VerticalDelta));
        }

        private void Axis_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

            if (e.StatusType == GestureStatus.Running)
            {
                VerticalDelta += e.TotalY / 100;
                sKCanvasViewChart.InvalidateSurface();
                EventManager.ChartDeltaChangedEvent(e.TotalX, (float)VerticalDelta);
            }
            Debug.WriteLine(string.Format("Axis : Pan StatusType={0}, VerticalDelta={1}, TotalY={2}", e.StatusType.ToString(), VerticalDelta, e.TotalY));


        }

        private void Chart_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

            if (e.StatusType == GestureStatus.Running)
            {
                VerticalOffset += e.TotalY * 7;
                sKCanvasViewChart.InvalidateSurface();
                EventManager.ChartOffsetChangedEvent(e.TotalX, (float)VerticalOffset);
            }
            Debug.WriteLine(string.Format("Chart : Pan StatusType={0}, VerticalOffset={1}, TotalY={2}", e.StatusType.ToString(), VerticalOffset, e.TotalY));


        }
    }
}