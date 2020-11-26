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
using static ChroZenService.ChroZenService_Const;

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


        public View_ChartYAxis()
        {
            InitializeComponent();

            sKCanvasViewXAxis.PaintSurface += OnCanvasViewPaintSurface;
            EventManager.onRawDataUpdated += ChartRawDataUpdated;
            EventManager.onChartDeltaChanged += ChartDeltaChangedEventHandler;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint = new SKPaint();

            float fStartX = ChartAxisType == CHART_AXIS_TYPE.Y_SIGNAL ? 49 : 0;
            SKColor paintColor= ChartAxisType == CHART_AXIS_TYPE.Y_SIGNAL ? new SKColor(0xff, 0xff, 0xff, 0xff) : new SKColor(0x3c, 0xb0, 0x43, 0xff);
            paint.Color = paintColor;
            
            canvas.DrawLine(fStartX, 0, fStartX, 195, paint);
           
        }

        private void ChartDeltaChangedEventHandler(ChroZenService_Const.CHART_DELTA_TYPE cHART_DELTA_TYPE, double deltaX, double deltaY)
        {
            Debug.WriteLine(string.Format("View_ChartYAxis : XAxis Y Delta Changed To={0}, DeltaType={1}", deltaY, cHART_DELTA_TYPE.ToString()));
        }

        public override void ChartRawDataUpdated()
        {
            //ChartRawData를 필터하여 
            //MajorTicksAndLables에 할당 후
            //전시 갱신
            Debug.WriteLine(string.Format("View_ChartYAxis : ChartRawData.RawDataTemperature.Count={0}", ChartRawData.yC_ChartElementRawDataTemperature.RawData.Count));
            Debug.WriteLine(string.Format("View_ChartYAxis : ChartRawData.RawDataDetector_Front.Count={0}", ChartRawData.yC_ChartElementRawDataDetector[0].RawData.Count));
            Debug.WriteLine(string.Format("View_ChartYAxis : ChartRawData.RawDataDetector_Center.Count={0}", ChartRawData.yC_ChartElementRawDataDetector[1].RawData.Count));
            Debug.WriteLine(string.Format("View_ChartYAxis : ChartRawData.RawDataDetector_Rear.Count={0}", ChartRawData.yC_ChartElementRawDataDetector[2].RawData.Count));
            Debug.WriteLine(string.Format("View_ChartYAxis : ChartRawData.RawDataTimeStamp.Count={0}", ChartRawData.yC_ChartElementRawDataTimeStamp.RawData.Count));
        }
    }
}