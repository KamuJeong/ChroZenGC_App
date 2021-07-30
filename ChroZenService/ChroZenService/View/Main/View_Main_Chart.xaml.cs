﻿using System;
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
        public View_Main_Chart()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ActiveDetectorProperty = BindableProperty.Create("ActiveDetector", typeof(int), typeof(View_Main_Chart),
                                                                   defaultValue: 0, propertyChanged: ChartPropertyChanged);

        public int ActiveDetector
        {
            get => (int)GetValue(ActiveDetectorProperty);
            set => SetValue(ActiveDetectorProperty, value);
        }

        public static readonly BindableProperty UnitProperty = BindableProperty.Create("Unit", typeof(string), typeof(View_Main_Chart),
                                                                           defaultValue: "mV", propertyChanged: ChartPropertyChanged);

        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

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

        private static void ChartPropertyChanged(BindableObject bindable, object oldValue, object newValue) => (bindable as View_Main_Chart)?.Redraw();
        private static object CorceMaxValue(BindableObject bindable, object value) => (float)Math.Max((bindable as View_Main_Chart).Min + 1.0, (float)value);

        public static readonly BindableProperty PointsProperty = BindableProperty.Create("Points", typeof(List<ValueTuple<float, float, float, float>>), typeof(View_Main_Chart),
                                                                                         propertyChanged: ChartPropertyChanged);

        public List<ValueTuple<float, float, float, float>> Points
        {
            get => (List<ValueTuple<float, float, float, float>>)GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }

        public static readonly BindableProperty CounterProperty = BindableProperty.Create("Counter", typeof(int), typeof(View_Main_Chart),
                                                                                         propertyChanged: ChartPointsPropertyChanged);

        public int Counter
        {
            get => (int)GetValue(CounterProperty);
            set => SetValue(CounterProperty, value);
        }

        private int counterLastRedrawn = 0;

        private static void ChartPointsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is View_Main_Chart chart)
            {
                if (chart.counterLastRedrawn > chart.Points.Count || chart.Points.Count >= chart.counterLastRedrawn)
                    chart.Redraw();
            }
        }

        public static readonly BindableProperty MaxTempProperty = BindableProperty.Create("MaxTemp", typeof(float), typeof(View_Main_Chart),
                                                                   defaultValue: 450.0f, propertyChanged: ChartPropertyChanged);

        public float MaxTemp
        {
            get => (float)GetValue(MaxTempProperty);
            set => SetValue(MaxTempProperty, value);
        }

        public static readonly BindableProperty TimeProperty = BindableProperty.Create("Time", typeof(float), typeof(View_Main_Chart),
                                                                   defaultValue: 10.0f, propertyChanged: ChartPropertyChanged);

        public float Time
        {
            get => (float)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }

        public static readonly BindableProperty OvenPointsProperty = BindableProperty.Create("OvenPoints", typeof(List<ValueTuple<float, float>>), typeof(View_Main_Chart),
                                                                                                propertyChanged: ChartPropertyChanged);

        public List<ValueTuple<float, float>> OvenPoints
        {
            get => (List<ValueTuple<float, float>>)GetValue(OvenPointsProperty);
            set => SetValue(OvenPointsProperty, value);
        }


        public void Redraw()
        {
            counterLastRedrawn = Points?.Count ?? 0;
            Canvas.InvalidateSurface();
        }

        private float convertX(in SKRectI rect, float x) => x * rect.Width / Time + rect.Left;
        private float convertL(in SKRectI rect, float l) => (float)rect.Bottom - (l - Min) * rect.Height / (Max - Min);
        private float convertR(in SKRectI rect, float r) => (float)rect.Bottom - (r + 88) * rect.Height / (MaxTemp + 88);

        private (List<float> tick, double minor) prepareTickers(float min, float max)
        {
            var diff = max - min;
            var logDiff = Math.Log10(diff);
            var exp = Math.Floor(logDiff);

            double major = Math.Pow(10.0, exp); // (1, 0.2)
            double minor = major / 5;
            switch ((int)(diff / major))
            {
                case int n when n > 5: // (2, 1)
                    minor = major;
                    major *= 2;
                    break;

                case 1:
                    if ((5 * diff / major) > 5 && (2 * diff / major) > 3)   // (0.5, 0.1)
                    {
                        minor = major / 10;
                        major /= 2;
                    }
                    else
                    {
                        minor = major / 10;     // (0.2, 0.1)
                        major /= 5;
                    }
                    break;

                case 2:     // (0.5, 0.1)
                    minor = major / 10;
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
            var timeTick = prepareTickers(0, Time);
            var ovenTick = prepareTickers(-88, MaxTemp);

            DrawBackground(canvas, rect);

            int margin = (int)(ruler / 5);

            rect.Left += margin;
            rect.Right -= margin;
            //            rect.Top += margin;
            rect.Bottom -= margin;

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
            if (Points == null)
                return;

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                if (ActiveDetector != -1)
                {
                    paint.Color = SKColors.White;
                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = 2;

                    canvas.ClipRect(rect);
                    canvas.DrawPoints(SKPointMode.Lines,
                        Points.Select(pt => new SKPoint(convertX(rect, pt.Item1),
                                            convertL(rect, ActiveDetector switch { 0 => pt.Item2, 1 => pt.Item3, 2 => pt.Item4, _ => 0.0f, }))).ToArray(), paint);
                }

                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Orange;
                paint.StrokeWidth = 2;

                var x = convertX(rect, Points.LastOrDefault().Item1);

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
            var programs = OvenPoints;
            if (programs == null || programs.Count == 0)
                return;

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

                var path = new SKPath { FillType = SKPathFillType.EvenOdd };
                path.MoveTo(rect.Left, convertR(rect, programs[0].Item2));
                foreach (var pt in programs)
                {
                    path.LineTo(convertX(rect, pt.Item1), convertR(rect, pt.Item2));
                }
                path.LineTo(convertX(rect, Time), convertR(rect, programs.Last().Item2));

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
                paint.MeasureText("(" + Unit + ")", ref rcText);
                canvas.DrawText("(" + Unit + ")", rect.Left + (rect.Width - rcText.Width) / 2, rect.Top + 2 * paint.FontSpacing - ruler / 8, paint);
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

                Func<float, string> _Text = v => $"{v:F1}".TrimEnd('0').TrimEnd('.');

                if (measureOnly)
                {
                    int width = 0;
                    SKRect rcText = new SKRect();
                    foreach (float t in ticker.tick)
                    {
                        paint.MeasureText(_Text(t), ref rcText);
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

                        paint.MeasureText(_Text(t), ref rcText);
                        canvas.DrawText(_Text(t), rect.Right - ruler / 2 - rcText.Width, y + rcText.Height / 2, paint);
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

                Func<float, string> _Text = v => $"{v:F0}";

                if (measureOnly)
                {
                    int width = 0;
                    SKRect rcText = new SKRect();
                    foreach (var t in ticker.tick)
                    {
                        paint.MeasureText(_Text(t), ref rcText);
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

                        paint.MeasureText(_Text(t), ref rcText);
                        canvas.DrawText(_Text(t), rect.Left + ruler / 2, y + rcText.Height / 2, paint);
                    }

                    var bottom = Math.Floor(-88 / ticker.minor) * ticker.minor;
                    while (bottom <= MaxTemp)
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

                Func<float, string> _Text = v => $"{v:F0}";

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

                        paint.MeasureText(_Text(t), ref rcText);
                        canvas.DrawText(_Text(t), x - rcText.Width / 2, rect.Top + rcText.Height + ruler / 2, paint);
                    }

                    var bottom = 0.0;
                    while (bottom <= Time)
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
            if (Points == null || Points.Count == 0 || ActiveDetector < 0)
            {
                Min = 0.0f;
                Max = 1000.0f;
            }
            else
            {
                var pts = Points.Select(pt => ActiveDetector switch { 0 => pt.Item2, 1 => pt.Item3, 2 => pt.Item4, _ => 0.0f, }).DefaultIfEmpty().OrderBy(v => v).ToArray();
                var diff = Math.Max(1.0f, pts.Last() - pts.First());

                Min = pts.First() - diff * 0.03f;
                Max = pts.Last() + diff * 0.05f;
            }
        }

        int idPanDevice = -1;
        double originalMinValue = 0.0, originalMaxValue = 0.0;
        private void OnCanvasPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var view = sender as SKCanvasView;
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
                    else
                    {
                        idPanDevice = -1;
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
    }
}