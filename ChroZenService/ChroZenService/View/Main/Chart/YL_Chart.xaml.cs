using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChroZenGC.Core.Wrappers;
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

        int nSelectedDetectorIndex;
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
                if (value < 0)
                    _VerticalDelta = 0.00001;
                else _VerticalDelta = value;
            }
        }

        float _fMaxDet = 0.02f;
        public float fMaxDet { get { return _fMaxDet; } set { if (_fMaxDet != value) { _fMaxDet = value; OnPropertyChanged("fMaxDet"); } } }

        float _fMinDet = 0;
        public float fMinDet { get { return _fMaxDet; } set { if (_fMaxDet != value) { _fMaxDet = value; OnPropertyChanged("fMinDet"); } } }

        private static void onYL_ChartElementRawDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as YL_Chart).ChartRawData = (newValue as YL_ChartElementRawData);
        }

        public YL_Chart()
        {
            InitializeComponent();

            var model = Resolver.Resolve<ChroZenGC.Core.Model>();
            ovenSetup = model.Oven;
            ovenSetup.PropertyModified += (s, e) => Redraw();
            ovenSetup.PropertyChanged += (s, e) => { if (e.PropertyName == "Binary") Redraw(); };

            model.State.PropertyChanged += OnStatePropertyChanged;



            //skb = new SKBitmap(470, 235, SKColorType.Bgra8888, SKAlphaType.Opaque);
            //sKCanvasViewGrid.PaintSurface += OnsKCanvasViewGridPaintSurface;
            //sKCanvasViewChart.PaintSurface += OnCanvasViewPaintSurface;
            //sKCanvasViewTemperatureChart.PaintSurface += SKCanvasViewTemperatureChart_PaintSurface;
            //EventManager.onRunStarted += onRunStartedEventHandler;
            //EventManager.onRunStopped += onRunStoppedEventHandler;
            //EventManager.onMethodUpdated += onMethodUpdatedEventHandler;
            //EventManager.onRawDataUpdated += onRawDataUpdatedHandler;
            //EventManager.onTemperatureUpdated += onTemperatureUpdatedEventHandler;
            //EventManager.onDetectorSelectionChangedTo += onDetectorSelectionChangedToEventHandler;
        }

        private int counterStateReceived = 0;
        private int counterLastRedrawn = 0;
        private List<ValueTuple<float, float, float, float>> SignalPoints = new List<ValueTuple<float, float, float, float>>();

        private void OnStatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ++counterStateReceived;

            if(e.PropertyName == "Binary")
            {
                var state = sender as StateWrapper;
                if(state.Mode == ChroZenGC.Core.Packets.Modes.Run)
                {
                    if(state.RunTime <= SignalPoints.LastOrDefault().Item1)
                    {
                        SignalPoints.Clear();
                        counterStateReceived = 0;
                    }
                    SignalPoints.Add((state.RunTime, state.Signal[0], state.Signal[1], state.Signal[2]));
                }
            }
            else
            {
                if (counterStateReceived != counterLastRedrawn + 1)
                    Redraw();

                counterLastRedrawn = counterStateReceived;
            }

            if (Math.Abs(counterStateReceived - counterLastRedrawn) >= 5)   // per 1 second
                Redraw();
        }

        private void onDetectorSelectionChangedToEventHandler(int nDetIndex)
        {
            //nSelectedDetectorIndex = nDetIndex;
            //sKCanvasViewChart.InvalidateSurface();
            //sKCanvasViewGrid.InvalidateSurface();
        }

        private void OnsKCanvasViewGridPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //SKImageInfo info = e.Info;
            //SKSurface surface = e.Surface;
            //SKCanvas canvas = surface.Canvas;
            //SKPaint paint = new SKPaint();
            //paint.Color = new SKColor(0x00, 0x00, 0xff, 0xff);//blue
            //canvas.Clear();

            ////세로 Grid선          
            //for (int j = 0; j < xAxis.AxisLabels.Count; j++)
            //{
            //    if (xAxis.AxisLabels[j].IsMajorTick == true)
            //    {
            //        canvas.DrawLine(xAxis.AxisLabels[j].startPoint.X, 195f - 195, xAxis.AxisLabels[j].startPoint.X, 195f - 0, paint);
            //    }
            //}

            ////가로 Grid선
            //for (int j = 0; j < detAxis.AxisLabelsArr[nSelectedDetectorIndex].Count; j++)
            //{
            //    if (detAxis.AxisLabelsArr[nSelectedDetectorIndex][j].IsMajorTick == true)
            //    {
            //        canvas.DrawLine(0, detAxis.AxisLabelsArr[nSelectedDetectorIndex][j].startPoint.Y, 470, detAxis.AxisLabelsArr[nSelectedDetectorIndex][j].startPoint.Y, paint);
            //        //Debug.WriteLine("Y : {0}", detAxis.AxisLabels[j].startPoint.Y);
            //    }
            //}
        }

        private void SKCanvasViewTemperatureChart_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //SKImageInfo info = e.Info;
            //SKSurface surface = e.Surface;
            //SKCanvas canvas = surface.Canvas;
            //SKPaint temperaturePaint = new SKPaint();
            //temperaturePaint.Color = new SKColor(0x00, 0xff, 0x00, 0xff);
            //temperaturePaint.IsAntialias = true;
            ////temperaturePaint.IsDither = true;
            ////temperaturePaint.Style = SKPaintStyle.Stroke;
            //temperaturePaint.StrokeWidth = 2;
            //SKPath temperaturePath = new SKPath();

            //float fXUnit = 470 / (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTotalRunTime);
            //float fYUnitSeed = (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTempSet * 2) > 400 ? 400 : (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTempSet * 2);
            //float fYUnitForOven = 195 / fYUnitSeed;

            //canvas.Clear();


            //switch ((E_OVEN_MODE)DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.btMode)
            //{
            //    case E_OVEN_MODE.ISO_THREMAL:
            //        {
            //            canvas.DrawLine(0,
            //    (195f - DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTempSet * fYUnitForOven),
            //    470,
            //    (195f - DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTempSet * fYUnitForOven), temperaturePaint);
            //        }
            //        break;
            //    case E_OVEN_MODE.PROGRAM_MODE:
            //        {
            //            float fTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fInitTime;
            //            float fTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTempSet;

            //            float fTotalTime = 0;
            //            fTotalTime += fTime;

            //            float fTempMax = fTemp;
            //            float fTempMin = 0;

            //            List<SKPoint> sKPoints = new List<SKPoint>();
            //            SKPoint tempStart = new SKPoint(0, fTemp);
            //            sKPoints.Add(tempStart);
            //            SKPoint tempP1 = new SKPoint(fTime * fXUnit, fTemp);
            //            sKPoints.Add(tempP1);

            //            for (int i = 0; i < DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm.Length; i++)
            //            {
            //                if (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fRate <= 0) continue;

            //                if (fTempMax < DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp)
            //                {
            //                    fTempMax = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp;
            //                }

            //                if (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp < fTempMin)
            //                {
            //                    fTempMin = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp;
            //                }

            //                fTime = Math.Abs(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp - fTemp) / DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fRate;

            //                fTotalTime += fTime;
            //                sKPoints.Add(new SKPoint(fTotalTime * fXUnit, DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp));
            //                fTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp;

            //                fTotalTime += DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTime;
            //                sKPoints.Add(new SKPoint(fTotalTime * fXUnit, DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.Prgm[i].fFinalTemp));
            //            }

            //            fYUnitSeed = (fTempMax * 2) > 400 ? 400 : fTempMax * 2;
            //            fYUnitForOven = 195 / fYUnitSeed;

            //            for (int i = 1; i < sKPoints.Count; i++)
            //            {
            //                //temperaturePath.LineTo(sKPoints[i].X, (235 - sKPoints[i].Y * fYUnitForOven));
            //                canvas.DrawLine(sKPoints[i - 1].X, (195 - sKPoints[i - 1].Y * fYUnitForOven), sKPoints[i].X, (195 - sKPoints[i].Y * fYUnitForOven), temperaturePaint);
            //            }
            //            //canvas.DrawPath(temperaturePath, temperaturePaint);
            //        }
            //        break;
            //}
        }

        private void onTemperatureUpdatedEventHandler()
        {
            //Task.Factory.StartNew(() => {
            //sKCanvasViewTemperatureChart.InvalidateSurface();
            //});
        }

        private void CalculateLabels(ref ObservableCollection<string> labels)
        {

        }

        private void onRawDataUpdatedHandler()
        {
            //Task.Factory.StartNew(() => {
            //sKCanvasViewChart.InvalidateSurface();
            //});
        }


        private OvenSetupWrapper ovenSetup;


        private static void ChartPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!object.Equals(oldValue, newValue) && bindable is YL_Chart view)
                view.Redraw();

        }
        public void Redraw()
        {
            counterLastRedrawn = counterStateReceived;

            Canvas.InvalidateSurface();
        }

        public static readonly BindableProperty UnitsProperty = BindableProperty.Create("Units", typeof(string), typeof(YL_Chart),
                                                                           defaultValue: "mV", propertyChanged: ChartPropertyChanged);
        public string Units
        {
            get => (string)GetValue(UnitsProperty);
            set => SetValue(UnitsProperty, value);
        }

        public static readonly BindableProperty MaxProperty = BindableProperty.Create("Max", typeof(float), typeof(YL_Chart),
                                                                           defaultValue: 1000.0f, propertyChanged: ChartPropertyChanged, coerceValue: CorceMaxValue);

        private static object CorceMaxValue(BindableObject bindable, object value) => Math.Max((bindable as YL_Chart).Min + 1.0, (float)value);

        public float Max
        {
            get => (float)GetValue(MaxProperty);
            set => SetValue(UnitsProperty, value);
        }

        public static readonly BindableProperty MinProperty = BindableProperty.Create("Min", typeof(float), typeof(YL_Chart),
                                                                           defaultValue: 0.0f, propertyChanged: ChartPropertyChanged);
        public float Min
        {
            get => (float)GetValue(MinProperty);
            set => SetValue(UnitsProperty, value);
        }

        public float TotalRunTime => ovenSetup.TotalRunTime;

        public List<ValueTuple<float, float>> OvenProgramPoints => ovenSetup.ProgramPoints.ToList();

        private float fontScale = 24;

        private float convertX(in SKRectI rect, float x) => x * rect.Width / TotalRunTime + rect.Left;

        private float convertL(in SKRectI rect, float l) => (float)rect.Bottom - l * rect.Height / (Max - Min);

        private float convertR(in SKRectI rect, float r) => (float)rect.Bottom - r * rect.Height / (450 + 88);

        private (List<float> tickers, double interval) prepareTickers(float min, float max)
        {
            var diff = max - min;
            var logDiff = Math.Log10(diff);
            var exp = Math.Floor(logDiff);

            double tick = Math.Pow(10.0, exp);
            double small = tick / 5;
            switch ((int)(diff / tick))
            {
                case int n when n > 5:
                    small = tick;
                    tick *= 2;
                    break;

                case 1:
                    small = tick / 10;
                    tick /= 5;
                    break;

                case int n when n <= 2:
                    small = tick / 5;
                    tick /= 2;
                    break;

            }

            var tickers = new List<float>();
            double value = Math.Floor(min / tick) * tick;
            while (value <= max)
            {
                if (value >= min)
                {
                    tickers.Add((float)value);
                }
                value += tick;
            }

            return (tickers, small);
        }


        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var rect = info.Rect;
            fontScale = (int)(rect.Height * 0.035);


            var signalTick = prepareTickers(Min, Max);
            var timeTick = prepareTickers(0, TotalRunTime);
            var ovenTick = prepareTickers(-88, 450);

            try
            {
                DrawBackground(canvas, rect);

                int margin = (int)(fontScale / 2);

                rect.Left += margin;
                rect.Right -= margin;
                rect.Top += margin;
                rect.Bottom -= margin * 2;

                SKSizeI signalCaptionSize = DrawSignalCaption(canvas, rect, true);
                SKSizeI ovenCaptionSize = DrawOvenCaption(canvas, rect, true);
                SKSizeI timeCaptionSize = DrawTimeCaption(canvas, rect, true);
                int timeScaleHeight = DrawTimeScale(canvas, rect, timeTick.tickers, true);
                int signalScaleWidth = DrawSignalScale(canvas, rect, signalTick.tickers, true);
                int ovenScaleWidth = DrawOvenScale(canvas, rect, ovenTick.tickers, true);

                var rectDraw = rect;
                rectDraw.Right = rect.Left + Math.Max(signalScaleWidth, signalCaptionSize.Width);
                rectDraw.Left = rectDraw.Right - signalCaptionSize.Width;
                rectDraw.Bottom = rectDraw.Top + signalCaptionSize.Height;
                DrawSignalCaption(canvas, rectDraw, false);

                rectDraw.Top = rectDraw.Bottom;
                rectDraw.Bottom = rect.Bottom - timeCaptionSize.Height - timeScaleHeight;
                DrawSignalScale(canvas, rectDraw, signalTick.tickers, false);

                rectDraw.Left = rect.Right - Math.Max(ovenScaleWidth, ovenCaptionSize.Width);
                rectDraw.Right = rectDraw.Left + ovenCaptionSize.Width;
                rectDraw.Top = rect.Top;
                rectDraw.Bottom = rectDraw.Top + ovenCaptionSize.Height;
                DrawOvenCaption(canvas, rectDraw, false);

                rectDraw.Top = rectDraw.Bottom;
                rectDraw.Bottom = rect.Bottom - timeCaptionSize.Height - timeScaleHeight;
                DrawOvenScale(canvas, rectDraw, ovenTick.tickers, false);

                rectDraw.Right = rectDraw.Left - 1;
                rectDraw.Left = rectDraw.Right - timeCaptionSize.Width;
                rectDraw.Bottom = rect.Bottom;
                rectDraw.Top = rectDraw.Bottom - timeCaptionSize.Height;
                DrawTimeCaption(canvas, rectDraw, false);

                rectDraw.Bottom = rectDraw.Top;
                rectDraw.Top -= timeScaleHeight;
                rectDraw.Left = rect.Left + Math.Max(signalScaleWidth, signalCaptionSize.Width);
                rectDraw.Right = rect.Right - Math.Max(ovenScaleWidth, ovenCaptionSize.Width);
                DrawTimeScale(canvas, rectDraw, timeTick.tickers, false);

                rectDraw.Bottom = rectDraw.Top;
                rectDraw.Top = rect.Top + Math.Max(signalCaptionSize.Height, ovenCaptionSize.Height);
                DrawOvenData(canvas, rectDraw);

                //rect.Bottom -= DrawTimeCaption(canvas, rect).Height;

                //rect.Left += DrawSignalScale(canvas, rect, signalGrids).Width;

                //rect.Right -= DrawOvenScale(canvas, rect).Width;

                //rect.Bottom -= DrawTimeScale(canvas, rect, timeGrids).Height;

                //DrawGridLines(canvas, rect, timeGrids, signalGrids);

                //DrawOvenData(canvas, rect);

                //DrawSignalData(canvas, rect);

            }
            catch (NotImplementedException ex)
            {

            }




            //SKPaint temperaturePaint = new SKPaint()
            //{
            //    StrokeWidth=10,
            //    Style = SKPaintStyle.Stroke,
            //    Color = SKColors.Blue
            //};
            //SKPaint detectorPaint = new SKPaint();
            //SKPaint currentTimeMarkerPaint = new SKPaint();
            //currentTimeMarkerPaint.StrokeWidth = 2;
            //detectorPaint.StrokeWidth = 2;



            //{
            //    detectorPaint.Color = new SKColor(0xff, 0xff, 0xff, 0xff);
            //    temperaturePaint.Color = new SKColor(0x00, 0xff, 0x00, 0xff);
            //    currentTimeMarkerPaint.Color = new SKColor(0xff, 0xa5, 0x0, 0xff);
            //    //470 pixel에 fTotalRunTime*60*5개의 data point를 찍고 각 point를 line으로 잇는다.
            //    float fXUnit = 470 / (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTotalRunTime);

            //    float fTStartVal = ChartHelper.GetMaxSignal((float)VerticalDelta, (float)VerticalOffset);
            //    float fDetSignalRange = (float)(fTStartVal - VerticalOffset);

            //    float fChartHeight = 195;
            //    float fYUnitForDetector = fChartHeight / fDetSignalRange;
            //    float fYUnitOffsetForDetector = (float)(fYUnitForDetector * VerticalOffset);
            //    float fYUnitForOven = fChartHeight / DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTempSet;

            //    float xStart = 0;
            //    float xEnd = 0;
            //    if (ChartRawData.yC_ChartElementRawDataTimeStamp.RawData.Count > 1)
            //    {

            //        for (int i = 1; i < ChartRawData.yC_ChartElementRawDataTimeStamp.RawData.Count; i++)
            //        {
            //            if (ChartRawData.yC_ChartElementRawDataDetector[0].RawData.Count > i)
            //            {
            //                float detY1Val = (195f - ChartRawData.yC_ChartElementRawDataDetector[nSelectedDetectorIndex].RawData[i] * fYUnitForDetector + fYUnitOffsetForDetector);
            //                float detY2Val = (195f - ChartRawData.yC_ChartElementRawDataDetector[nSelectedDetectorIndex].RawData[i - 1] * fYUnitForDetector + fYUnitOffsetForDetector);
            //                xStart = ChartRawData.yC_ChartElementRawDataTimeStamp.RawData[i] * fXUnit;
            //                xEnd = ChartRawData.yC_ChartElementRawDataTimeStamp.RawData[i - 1] * fXUnit;
            //                canvas.DrawLine(xStart,
            //                detY1Val,
            //                xEnd,
            //                detY2Val, detectorPaint);
            //            }

            //        }
            //    }
            //    //주황색 현재 시간 기준 세로 선
            //    canvas.DrawLine(xEnd,
            //        195 - 0,
            //        xEnd,
            //        195 - 195, currentTimeMarkerPaint);

            //}
        }

        private void DrawSignalData(SKCanvas canvas, SKRectI rect)
        {
            throw new NotImplementedException();
        }

        private void DrawOvenData(SKCanvas canvas, SKRectI rect)
        {
            using (SKPaint paint = new SKPaint())
            {
                SKColor colorStart = new SKColor(255, 100, 100, 100);
                SKColor colorEnd = new SKColor(100, 100, 255, 100);

                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Left, rect.Top),
                                    new SKPoint(rect.Left, rect.Bottom),
                                    new SKColor[] { colorStart, colorEnd },
                                    new float[] { 0.1f, 0.7f },
                                    SKShaderTileMode.Clamp);

                var programs = OvenProgramPoints;
                var path = new SKPath { FillType = SKPathFillType.EvenOdd };
                path.MoveTo(rect.Left, rect.Bottom);
                foreach (var pt in programs)
                {
                    path.LineTo(convertX(rect, pt.Item1), convertR(rect, pt.Item2));
                }
                path.LineTo(convertX(rect, TotalRunTime), convertR(rect, programs.Last().Item2));
                path.LineTo(rect.Right, rect.Bottom);
                path.Close();

                paint.Style = SKPaintStyle.StrokeAndFill;
                canvas.DrawPath(path, paint);
            }
        }

        private void DrawGridLines(SKCanvas canvas, SKRectI rect, List<float> tickers, List<float> signalGrids)
        {
            throw new NotImplementedException();
        }

        private int DrawTimeScale(SKCanvas canvas, SKRectI rect, List<float> tickers, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.LightGray;
                paint.TextSize = fontScale;

                if (measureOnly)
                    return (int)(2 * paint.FontSpacing + fontScale / 2);


                paint.StrokeWidth = 1;
                paint.Style = SKPaintStyle.Stroke;
                canvas.DrawRect(rect, paint);

            }
            return rect.Height;
        }

        private int DrawOvenScale(SKCanvas canvas, SKRectI rect, List<float> tickers, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.White;
                paint.TextSize = fontScale;
                if (measureOnly)
                {
                    int width = 0;
                    SKRect rcText = new SKRect();
                    foreach (var g in tickers)
                    {
                        paint.MeasureText($"{g:G}", ref rcText);
                        width = Math.Max((int)Math.Ceiling(rcText.Width) + 1, width);
                    }
                    return width + (int)(fontScale / 2);
                }

                paint.StrokeWidth = 1;
                paint.Style = SKPaintStyle.Stroke;
                canvas.DrawRect(rect, paint);




            }
            return rect.Width;
        }

        private int DrawSignalScale(SKCanvas canvas, SKRectI rect, List<float> tickers, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.White;
                paint.TextSize = fontScale;
                if (measureOnly)
                {
                    int width = 0;
                    SKRect rcText = new SKRect();
                    foreach (var g in tickers)
                    {
                        paint.MeasureText($"{g:G}", ref rcText);
                        width = Math.Max((int)Math.Ceiling(rcText.Width) + 1, width);
                    }
                    return width + (int)(fontScale / 2);
                }


                paint.StrokeWidth = 1;
                paint.Style = SKPaintStyle.Stroke;
                canvas.DrawRect(rect, paint);
            }
            return rect.Width;
        }

        private SKSizeI DrawTimeCaption(SKCanvas canvas, SKRectI rect, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.LightGray;
                paint.TextSize = fontScale;

                SKRect rcText = new SKRect();
                paint.MeasureText("Time (min)", ref rcText);

                if (measureOnly)
                    return new SKSizeI((int)Math.Ceiling(rcText.Width) + 1, (int)(paint.FontSpacing + fontScale / 2));

                canvas.DrawText("Time (min)", rect.Left, rect.Bottom, paint);
            }

            return rect.Size;
        }

        private SKSizeI DrawOvenCaption(SKCanvas canvas, SKRectI rect, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.LightGray;
                paint.TextSize = fontScale;

                SKRect rcText = new SKRect();
                paint.MeasureText("Temp", ref rcText);

                if (measureOnly)
                    return new SKSizeI((int)Math.Ceiling(rcText.Width) + 1, (int)(2 * paint.FontSpacing + fontScale / 2));

                canvas.DrawText("Temp", rect.Left, rect.Top + paint.FontSpacing, paint);
                paint.MeasureText("(℃)", ref rcText);
                canvas.DrawText("(℃)", rect.Left + (rect.Width - rcText.Width) / 2, rect.Top + 2 * paint.FontSpacing - fontScale / 5, paint);
            }
            return rect.Size;
        }

        private SKSizeI DrawSignalCaption(SKCanvas canvas, SKRectI rect, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.LightGray;
                paint.TextSize = fontScale;

                SKRect rcText = new SKRect();
                paint.MeasureText("Signal", ref rcText);

                if (measureOnly)
                    return new SKSizeI((int)Math.Ceiling(rcText.Width) + 1, (int)(2 * paint.FontSpacing + fontScale / 2));

                canvas.DrawText("Signal", rect.Left, rect.Top + paint.FontSpacing, paint);
                paint.MeasureText("(" + Units + ")", ref rcText);
                canvas.DrawText("(" + Units + ")", rect.Left + (rect.Width - rcText.Width) / 2, rect.Top + 2 * paint.FontSpacing - fontScale / 5, paint);
            }
            return rect.Size;
        }

        private void DrawBackground(SKCanvas canvas, SKRectI rect)
        {
            using (SKPaint paint = new SKPaint())
            {
                SKColor colorStart = ((Color)App.Current.Resources["CS_COLOR_ROOT_BACKGROUND"]).ToSKColor();
                SKColor colorEnd = ((Color)App.Current.Resources["CS_COLOR_KEYPAD_BUTTON_BACKGROUND"]).ToSKColor();

                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Left, rect.Top),
                                    new SKPoint(rect.Left, rect.Height),
                                    new SKColor[] { colorStart, colorEnd },
                                    null,
                                    SKShaderTileMode.Clamp);

                canvas.DrawPaint(paint);
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
            //Task.Factory.StartNew(() => UpdateChart());
            UpdateChart(); //20210426
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
            //Debug.WriteLine(string.Format("onVerticalDeltaChanged : VerticalDelta={0}", VerticalDelta));
        }

        private void Axis_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

            if (e.StatusType == GestureStatus.Running)
            {
                //VerticalDelta += e.TotalY * VerticalDelta / 400;
                //sKCanvasViewChart.InvalidateSurface();
                //sKCanvasViewGrid.InvalidateSurface();
                //EventManager.ChartDeltaChangedEvent(e.TotalX, (float)VerticalDelta);
            }
            //Debug.WriteLine(string.Format("Axis : Pan StatusType={0}, VerticalDelta={1}, TotalY={2}", e.StatusType.ToString(), VerticalDelta, e.TotalY));


        }

        private void Chart_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

            if (e.StatusType == GestureStatus.Running)
            {
                //VerticalOffset += (e.TotalY * VerticalDelta * 7);

                //sKCanvasViewChart.InvalidateSurface();
                //sKCanvasViewGrid.InvalidateSurface();
                //EventManager.ChartOffsetChangedEvent(e.TotalX, (float)VerticalOffset);
            }
            //Debug.WriteLine(string.Format("Chart : Pan StatusType={0}, VerticalOffset={1}, TotalY={2}", e.StatusType.ToString(), VerticalOffset, e.TotalY));


        }

        private void OnCanvasViewTapped(object sender, EventArgs e)
        {

        }
    }
}