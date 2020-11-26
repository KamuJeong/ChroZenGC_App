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

        public static readonly BindableProperty VerticalDeltaProperty = BindableProperty.Create("VerticalDelta", typeof(double), typeof(YL_Chart),
           propertyChanged: onVerticalDeltaPropertyChanged
           , defaultBindingMode: BindingMode.OneWay);

        public static readonly BindableProperty HorizontalDeltaProperty = BindableProperty.Create("HorizontalDelta", typeof(double), typeof(YL_Chart),
           propertyChanged: onHorizontalDeltaPropertyChanged
           , defaultBindingMode: BindingMode.OneWay);

        public YL_ChartElementRawData ChartRawData
        {
            get { return (YL_ChartElementRawData)GetValue(ChartRawDataProperty); }
            set { SetValue(ChartRawDataProperty, value); }
        }

        public double VerticalDelta
        {
            get { return (double)GetValue(VerticalDeltaProperty); }
            set { SetValue(VerticalDeltaProperty, value); }
        }
        public double HorizontalDelta
        {
            get { return (double)GetValue(HorizontalDeltaProperty); }
            set { SetValue(HorizontalDeltaProperty, value); }
        }

        private static void onYL_ChartElementRawDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as YL_Chart).ChartRawData = (newValue as YL_ChartElementRawData);
        }

        private static void onVerticalDeltaPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as YL_Chart).VerticalDelta = (double)newValue;
            (bindable as YL_Chart).onVerticalDeltaChanged();

            if (newValue != null)
            {
                EventManager.ChartDeltaChangedEvent(ChroZenService_Const.CHART_DELTA_TYPE.CHART_DELTA, 0, (double)newValue);
            }
        }

        private static void onHorizontalDeltaPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as YL_Chart).HorizontalDelta = (double)newValue;
            (bindable as YL_Chart).onHorizontalDeltaChanged();
        }

        public YL_Chart()
        {
            InitializeComponent();

            sKCanvasViewChart.PaintSurface += OnCanvasViewPaintSurface;
            EventManager.onRunStarted += onRunStartedEventHandler;
            EventManager.onRunStopped += onRunStoppedEventHandler;
            EventManager.onMethodUpdated += onMethodUpdatedEventHandler;
            EventManager.onChartDeltaChanged += ChartDeltaChangedEventHandler;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            //SKBitmap skb = new SKBitmap(470, 235, SKColorType.Bgra8888, SKAlphaType.Opaque);
            //canvas.DrawLine()

            //SKBitmap bitmap = new SKBitmap((int)r.Output.Width, (int)r.Output.Height);
            //var pixels = new SKColor[(int)r.Output.Width * (int)r.Output.Height];
            //for (int i = 0; i < pixels.Length; i++)
            //{
            //    for (int j = 0; j < r.Image.Length / 4; j++)
            //    {
            //        pixels[i] = new SKColor((byte)r.Image[j + 2], (byte)r.Image[j + 1], (byte)r.Image[j + 0], (byte)r.Image[j + 3]);
            //    }
            //}
            canvas.Clear();
        }

        private void ChartDeltaChangedEventHandler(ChroZenService_Const.CHART_DELTA_TYPE cHART_DELTA_TYPE, double deltaX, double deltaY)
        {
            Debug.WriteLine(string.Format("YL_Chart : YL_Chart Y Delta Changed To={0}, DeltaType={1}", deltaY, cHART_DELTA_TYPE.ToString()));
        }

        private void onRunStartedEventHandler()
        {
            if (!DataManager.RunState.IsDeviceRun)
            {
                Task.Factory.StartNew(() => StartDrawChartData());
            }
        }

        private void onRunStoppedEventHandler()
        {
            if (DataManager.RunState.IsDeviceRun)
            {
                Task.Factory.StartNew(() => StopDrawChartData());
            }
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

        private void onVerticalDeltaChanged()
        {
            Debug.WriteLine(string.Format("onVerticalDeltaChanged : VerticalDelta={0}", VerticalDelta));
        }

        private void onHorizontalDeltaChanged()
        {
            Debug.WriteLine(string.Format("onHorizontalDeltaChanged : HorizontalDelta={0}", HorizontalDelta));
        }

        private void Axis_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            EventManager.ChartDeltaChangedEvent(ChroZenService_Const.CHART_DELTA_TYPE.AXIS_DELTA, e.TotalX, e.TotalY);
            //Debug.WriteLine(string.Format("Axis : Pan StatusType={0}, TotalX={1}, TotalY={2}", e.StatusType.ToString(), e.TotalX, e.TotalY));
        }

        private void Chart_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            EventManager.ChartDeltaChangedEvent(ChroZenService_Const.CHART_DELTA_TYPE.CHART_DELTA, e.TotalX, e.TotalY);
            //Debug.WriteLine(string.Format("Chart : Pan StatusType={0}, TotalX={1}, TotalY={2}", e.StatusType.ToString(), e.TotalX, e.TotalY));
        }
    }
}