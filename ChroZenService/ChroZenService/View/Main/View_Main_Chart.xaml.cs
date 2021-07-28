using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChroZenGC.Core.Packets;
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
    public partial class View_Main_Chart : ContentView
    {
        public static readonly BindableProperty ActiveDetectorProperty = BindableProperty.Create("ActiveDetector", typeof(int), typeof(View_Main_Chart),
                                                                           defaultValue: 0, propertyChanged: ChartPropertyChanged);

        public int ActiveDetector
        {
            get => (int)GetValue(ActiveDetectorProperty);
            set => SetValue(ActiveDetectorProperty, value);
        }

        public string Units => "mV";

        public static readonly BindableProperty MaxProperty = BindableProperty.Create("Max", typeof(float), typeof(View_Main_Chart),
                                                                           defaultValue: 1000.0f, propertyChanged: ChartPropertyChanged, coerceValue: CorceMaxValue);



        public float Max
        {
            get => (float)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        public static readonly BindableProperty MinProperty = BindableProperty.Create("Min", typeof(float), typeof(View_Main_Chart),
                                                                           defaultValue: 0.0f, propertyChanged: ChartPropertyChanged);
        public float Min
        {
            get => (float)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        private static void ChartPropertyChanged(BindableObject bindable, object oldValue, object newValue) => (bindable as View_Main_Chart).Redraw();
        private static object CorceMaxValue(BindableObject bindable, object value) => (float)Math.Max((bindable as View_Main_Chart).Min + 1.0, (float)value);

        private int counterStateReceived = 0;
        private int counterLastRedrawn = 0;
        public void Redraw()
        {
            counterLastRedrawn = counterStateReceived;

            Canvas.InvalidateSurface();
        }

        private List<ValueTuple<float, float, float, float>> SignalPoints = new List<ValueTuple<float, float, float, float>>();

        public float TotalRunTime => Model.Oven.TotalRunTime;
        public List<ValueTuple<float, float>> OvenProgramPoints => Model.Oven.ProgramPoints.ToList();

        private ChroZenGC.Core.Model Model { get;  }

        public View_Main_Chart()
        {
            InitializeComponent();

            Model = Resolver.Resolve<ChroZenGC.Core.Model>();

            Model.Oven.PropertyModified += (s, e) => Redraw();
            Model.Oven.PropertyChanged += (s, e) => { if (e.PropertyName == "Binary") Redraw(); };

            Model.State.PropertyChanged += OnStatePropertyChanged;
        }

        private void OnStatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ++counterStateReceived;

            if (e.PropertyName == "Binary")
            {
                var state = sender as StateWrapper;
                if (state.Mode == ChroZenGC.Core.Packets.Modes.Run)
                {
                    if (state.RunTime <= SignalPoints.LastOrDefault().Item1)
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


        private float convertX(in SKRectI rect, float x) => x * rect.Width / TotalRunTime + rect.Left;

        private float convertL(in SKRectI rect, float l) => (float)rect.Bottom - (l - Min) * rect.Height / (Max - Min);

        private float convertR(in SKRectI rect, float r) => (float)rect.Bottom - (r + 88) * rect.Height / (450 + 88);

        private (List<float> tick, double minor) prepareTickers(float min, float max)
        {
            var diff = max - min;
            var logDiff = Math.Log10(diff);
            var exp = Math.Floor(logDiff);

            double major = Math.Pow(10.0, exp);
            double minor = major / 5;
            switch ((int)(2 * diff / major))
            {
                case int n when n > 10:
                    minor = major;
                    major *= 2;
                    break;

                case 2:
                    minor = major / 10;
                    major /= 5;
                    break;

                case int n when n <= 4:
                    minor = major / 5;
                    major /= 2;
                    break;

            }

            var tick = new List<float>();
            double value = Math.Floor(min / major) * major;
            while (value <= max)
            {
                if (value >= min)
                {
                    tick.Add((float)value);
                }
                value += major;
            }

            return (tick, minor);
        }


        private float ruler = 24;
        private float fontScale = 24;
        private float fontCaption = 24;

        private SKRectI rcSignalMax = new SKRectI();
        private SKRectI rcSignalScale = new SKRectI();
        private SKRectI rcSignalMin = new SKRectI();
        private SKRectI rcSignalScreen = new SKRectI();

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var rect = info.Rect;
            ruler = (int)(rect.Height * 0.05);
            fontCaption = fontScale = (int)(ruler * 0.8f);

            var signalTick = prepareTickers(Min, Max);
            var timeTick = prepareTickers(0, TotalRunTime);
            var ovenTick = prepareTickers(-88, 450);

            DrawBackground(canvas, rect);

            int margin = (int)(ruler / 5);

            rect.Left += margin;
            rect.Right -= margin;
            rect.Top += margin;
            rect.Bottom -= margin * 2;

            SKSizeI signalCaptionSize = DrawSignalCaption(canvas, rect, true);
            SKSizeI ovenCaptionSize = DrawOvenCaption(canvas, rect, true);
            SKSizeI timeCaptionSize = DrawTimeCaption(canvas, rect, true);
            int timeScaleHeight = DrawTimeScale(canvas, rect, timeTick, true);
            int signalScaleWidth = DrawSignalScale(canvas, rect, signalTick, true);
            int ovenScaleWidth = DrawOvenScale(canvas, rect, ovenTick, true);

            var rectDraw = rect;
            rectDraw.Right = rect.Left + Math.Max(signalScaleWidth, signalCaptionSize.Width);
            rectDraw.Left = rectDraw.Right - signalCaptionSize.Width;
            rectDraw.Bottom = rectDraw.Top + signalCaptionSize.Height;
            rcSignalMax = rectDraw;
            DrawSignalCaption(canvas, rectDraw, false);

            rectDraw.Top = rectDraw.Bottom;
            rectDraw.Bottom = rect.Bottom - timeCaptionSize.Height - timeScaleHeight;
            rcSignalMin = rcSignalScale = rectDraw;
            DrawSignalScale(canvas, rectDraw, signalTick, false);

            rcSignalMin.Top = rcSignalMin.Bottom;
            rcSignalMin.Bottom = rect.Bottom;

            rectDraw.Left = rect.Right - Math.Max(ovenScaleWidth, ovenCaptionSize.Width);
            rectDraw.Right = rectDraw.Left + ovenCaptionSize.Width;
            rectDraw.Top = rect.Top;
            rectDraw.Bottom = rectDraw.Top + ovenCaptionSize.Height;
            DrawOvenCaption(canvas, rectDraw, false);

            rectDraw.Top = rectDraw.Bottom;
            rectDraw.Bottom = rect.Bottom - timeCaptionSize.Height - timeScaleHeight;
            DrawOvenScale(canvas, rectDraw, ovenTick, false);

            rectDraw.Right = rectDraw.Left - 1;
            rectDraw.Left = rectDraw.Right - timeCaptionSize.Width;
            rectDraw.Bottom = rect.Bottom;
            rectDraw.Top = rectDraw.Bottom - timeCaptionSize.Height;
            DrawTimeCaption(canvas, rectDraw, false);

            rectDraw.Bottom = rectDraw.Top;
            rectDraw.Top -= timeScaleHeight;
            rectDraw.Left = rect.Left + Math.Max(signalScaleWidth, signalCaptionSize.Width);
            rectDraw.Right = rect.Right - Math.Max(ovenScaleWidth, ovenCaptionSize.Width);
            DrawTimeScale(canvas, rectDraw, timeTick, false);

            rectDraw.Bottom = rectDraw.Top;
            rectDraw.Top = rect.Top + Math.Max(signalCaptionSize.Height, ovenCaptionSize.Height);

            rcSignalScreen = rectDraw;

            DrawOvenData(canvas, rectDraw);
            DrawGridLines(canvas, rectDraw, timeTick.tick, signalTick.tick);
            DrawSignalData(canvas, rectDraw);

        }

        private void DrawSignalData(SKCanvas canvas, SKRectI rect)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                if (Model.Configuration.DetectorType[ActiveDetector] != DetectorTypes.None)
                {
                    paint.Color = SKColors.White;
                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = 2;

                    canvas.ClipRect(rect);
                    canvas.DrawPoints(SKPointMode.Lines,
                        SignalPoints.Select(pt => new SKPoint(convertX(rect, pt.Item1),
                                            convertL(rect, ActiveDetector switch { 0 => pt.Item2, 1 => pt.Item3, 2 => pt.Item4, _ => 0.0f, }))).ToArray(), paint);
                }

                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Orange;
                paint.StrokeWidth = 2;

                var x = convertX(rect, SignalPoints.LastOrDefault().Item1);

                canvas.DrawLine(x, rect.Top, x, rect.Bottom, paint);
            }
        }

        private void DrawGridLines(SKCanvas canvas, SKRectI rect, List<float> timeTick, List<float> signalTick)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.DodgerBlue;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 1;

                foreach (var t in signalTick)
                {
                    var y = convertL(rect, t);
                    canvas.DrawLine(rect.Left, y, rect.Right, y, paint);
                }

                foreach (var t in timeTick)
                {
                    var x = convertX(rect, t);
                    canvas.DrawLine(x, rect.Top, x, rect.Bottom, paint);
                }
            }
        }

        private void DrawOvenData(SKCanvas canvas, SKRectI rect)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                SKColor colorStart = new SKColor(050, 205, 0, 125);
                SKColor colorEnd = new SKColor(050, 205, 0, 0);

                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Left, rect.Top),
                                    new SKPoint(rect.Left, rect.Bottom),
                                    new SKColor[] { colorStart, colorEnd },
                                    new float[] { 0.1f, 0.7f },
                                    SKShaderTileMode.Clamp);

                var programs = OvenProgramPoints;
                var path = new SKPath { FillType = SKPathFillType.EvenOdd };
                path.MoveTo(rect.Left, convertR(rect, programs[0].Item2));
                foreach (var pt in programs)
                {
                    path.LineTo(convertX(rect, pt.Item1), convertR(rect, pt.Item2));
                }
                path.LineTo(convertX(rect, TotalRunTime), convertR(rect, programs.Last().Item2));

                var pathLine = new SKPath(path);

                path.LineTo(rect.Right, rect.Bottom);
                path.LineTo(rect.Left, rect.Bottom);
                path.Close();

                paint.Style = SKPaintStyle.StrokeAndFill;
                canvas.DrawPath(path, paint);

                paint.Shader = null;
                paint.Color = SKColors.LimeGreen;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 2;

                canvas.DrawPath(pathLine, paint);
            }
        }

        private SKSizeI DrawSignalCaption(SKCanvas canvas, SKRectI rect, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.LightGray;
                paint.TextSize = fontCaption;

                SKRect rcText = new SKRect();
                paint.MeasureText("Signal", ref rcText);

                if (measureOnly)
                    return new SKSizeI((int)(Math.Ceiling(rcText.Width) + ruler / 2) + 1, (int)(2 * paint.FontSpacing + ruler));

                rect.Left = rect.Right - (int)Math.Ceiling(rcText.Width + ruler / 2);

                canvas.DrawText("Signal", rect.Left, rect.Top + paint.FontSpacing, paint);
                paint.MeasureText("(" + Units + ")", ref rcText);
                canvas.DrawText("(" + Units + ")", rect.Left + (rect.Width - rcText.Width) / 2, rect.Top + 2 * paint.FontSpacing - ruler / 8, paint);
            }
            return rect.Size;
        }

        private int DrawSignalScale(SKCanvas canvas, SKRectI rect, (List<float> tick, double minor) ticker, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.White;
                paint.TextSize = fontScale;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 1;

                if (measureOnly)
                {
                    int width = 0;
                    SKRect rcText = new SKRect();
                    foreach (var t in ticker.tick)
                    {
                        paint.MeasureText($"{t:G}", ref rcText);
                        width = Math.Max((int)Math.Ceiling(rcText.Width) + 1, width);
                    }
                    return width + (int)ruler;
                }
                else
                {
                    rect.Right -= (int)(ruler * 0.5);
                    canvas.DrawLine(rect.Right, rect.Top, rect.Right, rect.Bottom, paint);

                    SKRect rcText = new SKRect();
                    foreach (var t in ticker.tick)
                    {
                        var y = convertL(rect, t);
                        canvas.DrawLine(rect.Right, y, rect.Right - ruler / 2, y, paint);

                        paint.MeasureText($"{t:G}", ref rcText);
                        canvas.DrawText($"{t:G}", rect.Right - ruler / 2 - rcText.Width, y + rcText.Height / 2, paint);
                    }

                    var bottom = Math.Floor(Min / ticker.minor) * ticker.minor;
                    while (bottom <= Max)
                    {
                        if (bottom >= Min)
                        {
                            var y = convertL(rect, (float)bottom);
                            canvas.DrawLine(rect.Right, y, rect.Right - ruler / 3, y, paint);
                        }
                        bottom += ticker.minor;
                    }
                }
            }
            return rect.Width;
        }

        private SKSizeI DrawOvenCaption(SKCanvas canvas, SKRectI rect, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.LightGray;
                paint.TextSize = fontCaption;

                SKRect rcText = new SKRect();
                paint.MeasureText("Temp", ref rcText);

                if (measureOnly)
                    return new SKSizeI((int)(Math.Ceiling(rcText.Width) + ruler / 2) + 1, (int)(2 * paint.FontSpacing + ruler));

                rect.Left += (int)Math.Ceiling(ruler / 2);
                rect.Right = rect.Left + (int)Math.Ceiling(rcText.Width);

                canvas.DrawText("Temp", rect.Left, rect.Top + paint.FontSpacing, paint);
                paint.MeasureText("(℃)", ref rcText);
                canvas.DrawText("(℃)", rect.Left + (rect.Width - rcText.Width) / 2, rect.Top + 2 * paint.FontSpacing - ruler / 8, paint);
            }
            return rect.Size;
        }

        private int DrawOvenScale(SKCanvas canvas, SKRectI rect, (List<float> tick, double minor) ticker, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.LimeGreen;
                paint.TextSize = fontScale;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 1;

                if (measureOnly)
                {
                    int width = 0;
                    SKRect rcText = new SKRect();
                    foreach (var g in ticker.tick)
                    {
                        paint.MeasureText($"{g:G}", ref rcText);
                        width = Math.Max((int)Math.Ceiling(rcText.Width) + 1, width);
                    }
                    return width + (int)ruler;
                }
                else
                {
                    rect.Left += (int)(ruler * 0.5);
                    canvas.DrawLine(rect.Left, rect.Top, rect.Left, rect.Bottom, paint);

                    SKRect rcText = new SKRect();
                    foreach (var t in ticker.tick)
                    {
                        var y = convertR(rect, t);
                        canvas.DrawLine(rect.Left, y, rect.Left + ruler / 2, y, paint);

                        paint.MeasureText($"{t:G}", ref rcText);
                        canvas.DrawText($"{t:G}", rect.Left + ruler / 2, y + rcText.Height / 2, paint);
                    }

                    var bottom = Math.Floor(-88 / ticker.minor) * ticker.minor;
                    while (bottom <= 450)
                    {
                        if (bottom >= -88)
                        {
                            var y = convertR(rect, (float)bottom);
                            canvas.DrawLine(rect.Left, y, rect.Left + ruler / 3, y, paint);
                        }
                        bottom += ticker.minor;
                    }
                }
            }
            return rect.Width;
        }

        private SKSizeI DrawTimeCaption(SKCanvas canvas, SKRectI rect, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.LightGray;
                paint.TextSize = fontCaption;

                SKRect rcText = new SKRect();
                paint.MeasureText("Time (min)", ref rcText);

                if (measureOnly)
                    return new SKSizeI((int)Math.Ceiling(rcText.Width) + 1, (int)(paint.FontSpacing + ruler / 2));

                canvas.DrawText("Time (min)", rect.Left, rect.Bottom - ruler / 2, paint);
            }

            return rect.Size;
        }

        private int DrawTimeScale(SKCanvas canvas, SKRectI rect, (List<float> tick, double minor) ticker, bool measureOnly)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Color = SKColors.Orange;
                paint.TextSize = fontScale;
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 1;


                if (measureOnly)
                {
                    return (int)Math.Ceiling(paint.FontSpacing + ruler) + 1;
                }
                else
                {
                    rect.Top += (int)(ruler * 0.5);
                    canvas.DrawLine(rect.Left, rect.Top, rect.Right, rect.Top, paint);

                    SKRect rcText = new SKRect();
                    foreach (var t in ticker.tick)
                    {
                        var x = convertX(rect, t);
                        canvas.DrawLine(x, rect.Top, x, rect.Top + ruler / 2, paint);

                        paint.MeasureText($"{t:G}", ref rcText);
                        canvas.DrawText($"{t:G}", x - rcText.Width / 2, rect.Top + rcText.Height + ruler / 2, paint);
                    }

                    var bottom = 0.0;
                    while (bottom <= TotalRunTime)
                    {
                        if (bottom >= 0)
                        {
                            var x = convertX(rect, (float)bottom);
                            canvas.DrawLine(x, rect.Top, x, rect.Top + ruler / 3, paint);
                        }
                        bottom += ticker.minor;
                    }
                }
            }
            return rect.Height;
        }


        private void DrawBackground(SKCanvas canvas, SKRectI rect)
        {
            using (SKPaint paint = new SKPaint())
            {
                SKColor colorStart = ((Color)App.Current.Resources["CS_COLOR_ROOT_BACKGROUND"]).ToSKColor();
                SKColor colorEnd = ((Color)App.Current.Resources["CS_COLOR_BLACK_0"]).ToSKColor();

                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Left, rect.Top),
                                    new SKPoint(rect.Left, rect.Height),
                                    new SKColor[] { colorStart, colorEnd },
                                    null,
                                    SKShaderTileMode.Clamp);

                canvas.DrawPaint(paint);
            }
        }

        private void OnCanvasViewTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("tab");   
        }


        int idPanDevice = -1;
        double originalMinValue = 0.0, originalMaxValue = 0.0;
        private void OnCanvasPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var view = Content as SKCanvasView;
            double totalY = e.TotalY * view.CanvasSize.Height / Height;
            double diff = totalY * (originalMaxValue - originalMinValue) / rcSignalScreen.Height;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    if (idPanDevice < 0)
                    {
                        idPanDevice = e.GestureId;
                        originalMaxValue = Max;
                        originalMinValue = Min;
                    }
                    break;

                case GestureStatus.Running:
                    if (idPanDevice == e.GestureId)
                    {
                        Max = (float)(originalMaxValue + diff);
                        Min = (float)(originalMinValue + diff);
                    }
                    break;
                default:
                    idPanDevice = -1;
                    break;
            }
        }


        private void OnCanvasPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            float diff = Max - Min;
            diff = (float)(diff / e.Scale - diff) / 2;

            switch (e.Status)
            {
                case GestureStatus.Running:
                    Min -= diff;
                    Max += diff;
                    break;
            }
        }


























        //private void onRunStartedEventHandler()
        //{
        //    DataManager.RunState.e_CHART_DRAW_STATE = DataManager.RunState.E_CHART_DRAW_STATE.DRAW;
        //}

        //private void onRunStoppedEventHandler()
        //{
        //    DataManager.RunState.e_CHART_DRAW_STATE = DataManager.RunState.E_CHART_DRAW_STATE.STOP;
        //}

        //private void onMethodUpdatedEventHandler()
        //{
        //    //Task.Factory.StartNew(() => UpdateChart());
        //    UpdateChart(); //20210426
        //}

        //void DrawGridLine()
        //{

        //}

        //void StartDrawChartData()
        //{

        //}

        //void StopDrawChartData()
        //{

        //}

        //void UpdateChart()
        //{
        //    DrawGridLine();

        //}

        //private void onVerticalOffsetChanged()
        //{
        //    Debug.WriteLine(string.Format("onVerticalOffsetChanged : VerticalOffset={0}", VerticalOffset));
        //}

        //private void onVerticalDeltaChanged()
        //{
        //    //Debug.WriteLine(string.Format("onVerticalDeltaChanged : VerticalDelta={0}", VerticalDelta));
        //}

        //private void Axis_PanUpdated(object sender, PanUpdatedEventArgs e)
        //{

        //    if (e.StatusType == GestureStatus.Running)
        //    {
        //        //VerticalDelta += e.TotalY * VerticalDelta / 400;
        //        //sKCanvasViewChart.InvalidateSurface();
        //        //sKCanvasViewGrid.InvalidateSurface();
        //        //EventManager.ChartDeltaChangedEvent(e.TotalX, (float)VerticalDelta);
        //    }
        //    //Debug.WriteLine(string.Format("Axis : Pan StatusType={0}, VerticalDelta={1}, TotalY={2}", e.StatusType.ToString(), VerticalDelta, e.TotalY));


        //}

        //private void Chart_PanUpdated(object sender, PanUpdatedEventArgs e)
        //{

        //    if (e.StatusType == GestureStatus.Running)
        //    {
        //        //VerticalOffset += (e.TotalY * VerticalDelta * 7);

        //        //sKCanvasViewChart.InvalidateSurface();
        //        //sKCanvasViewGrid.InvalidateSurface();
        //        //EventManager.ChartOffsetChangedEvent(e.TotalX, (float)VerticalOffset);
        //    }
        //    //Debug.WriteLine(string.Format("Chart : Pan StatusType={0}, VerticalOffset={1}, TotalY={2}", e.StatusType.ToString(), VerticalOffset, e.TotalY));


        //}


    }
}