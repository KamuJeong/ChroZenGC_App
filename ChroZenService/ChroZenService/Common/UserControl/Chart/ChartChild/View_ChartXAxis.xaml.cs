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

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_ChartXAxis : YL_ChartAxisBase
    {
        public View_ChartXAxis()
        {
            InitializeComponent();

            
            sKCanvasViewXAxis.PaintSurface += OnCanvasViewPaintSurface;
            EventManager.onRawDataUpdated += ChartRawDataUpdated;
            EventManager.onChartDeltaChanged += ChartDeltaChangedEventHandler;
            EventManager.onMethodUpdated += MethodUpdatedEventHandler;
        }

        private void MethodUpdatedEventHandler()
        {
            //Method의Oven프로그램을 업데이트 시 X Axis Label 업데이트
            //MajorTicksAndLabels = new ObservableCollection<Tuple<double, string>>(new List<Tuple<double, string>>
            //{
            //    new Tuple<double,string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    new Tuple<double, string>(),
            //    }
            //    );
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint = new SKPaint();

            paint.Color = new SKColor(0xff, 0xa5, 0x0, 0xff);
            canvas.DrawLine(0, 0, 470, 0, paint);

            float fXAxisOffset = -1;
            float fXAxisLengthForDraw = 470 + fXAxisOffset;
            int nTotalTickCount = 45;
            int nMajorTickInterval = 5;
            float[] dMajorTicks = new float[nTotalTickCount / nMajorTickInterval];

            for (int i = 0; i < nTotalTickCount; i++)
            {
                //Major tick draw
                if (i % 5 == 0)
                {
                    int nMajorTickIndex = i / 5;
                    dMajorTicks[nMajorTickIndex] = (fXAxisLengthForDraw / (float)(dMajorTicks.Length - 1)) * nMajorTickIndex;
                    canvas.DrawLine(dMajorTicks[nMajorTickIndex], 0, dMajorTicks[nMajorTickIndex], 10, paint);
                }
                //Major tick draw
                else if (i <= 40)
                {
                    float fMinorTickX = (fXAxisLengthForDraw / (float)(40)) * i;
                    canvas.DrawLine(fMinorTickX, 0, fMinorTickX, 5, paint);
                }
            }

            //canvas.DrawLine(0, 0, 0, 10, paint);
            //canvas.DrawLine(58.75f, 0, 58.75f, 10, paint);
            //canvas.DrawLine(117.5f, 0, 117.5f, 10, paint);
            //canvas.DrawLine(176.25f, 0, 176.25f, 10, paint);
            //canvas.DrawLine(235, 0, 235, 10, paint);
            //canvas.DrawLine(293.75f, 0, 293.75f, 10, paint);
            //canvas.DrawLine(352.5f, 0, 352.5f, 10, paint);
            //canvas.DrawLine(411.25f, 0, 411.25f, 10, paint);
            //canvas.DrawLine(469, 0, 469, 10, paint);
        }

        private void ChartDeltaChangedEventHandler(ChroZenService_Const.CHART_DELTA_TYPE cHART_DELTA_TYPE, double deltaX, double deltaY)
        {
            Debug.WriteLine(string.Format("View_ChartXAxis : XAxis Y Delta Changed To={0}, DeltaType={1}", deltaY, cHART_DELTA_TYPE.ToString()));
        }

        public override void ChartRawDataUpdated()
        {
            //ChartRawData를 필터하여 
            //MajorTicksAndLables에 할당 후
            //전시 갱신
            //X축 MajorTick 필터 조건
            //1 Runtime 취득 (unit : min) : OvenProgram이 있을 때 OvenProgram 종료 시, 없을 때 Oven 설정 시
            //2 Major tick count 취득 : 최대 8, 최소 3
            //2.1 Major tick count 결정 조건 : 

            

            Debug.WriteLine(string.Format("View_ChartXAxis : ChartRawData.RawDataTemperature.Count={0}", ChartRawData.yC_ChartElementRawDataTemperature.RawData.Count));
            Debug.WriteLine(string.Format("View_ChartXAxis : ChartRawData.RawDataDetector_Front.Count={0}", ChartRawData.yC_ChartElementRawDataDetector[0].RawData.Count));
            Debug.WriteLine(string.Format("View_ChartXAxis : ChartRawData.RawDataDetector_Center.Count={0}", ChartRawData.yC_ChartElementRawDataDetector[1].RawData.Count));
            Debug.WriteLine(string.Format("View_ChartXAxis : ChartRawData.RawDataDetector_Rear.Count={0}", ChartRawData.yC_ChartElementRawDataDetector[2].RawData.Count));
            Debug.WriteLine(string.Format("View_ChartXAxis : ChartRawData.RawDataTimeStamp.Count={0}", ChartRawData.yC_ChartElementRawDataTimeStamp.RawData.Count));
        }
    }
}