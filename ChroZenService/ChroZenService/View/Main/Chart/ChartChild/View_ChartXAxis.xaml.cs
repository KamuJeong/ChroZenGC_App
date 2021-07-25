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
        List<YL_ChartTick> _AxisLabels = new List<YL_ChartTick>();
        public List<YL_ChartTick> AxisLabels
        {
            get { return _AxisLabels; }
            set { _AxisLabels = value; }
        }

        public View_ChartXAxis()
        {
            InitializeComponent();

            sKCanvasViewXAxis.PaintSurface += OnCanvasViewPaintSurface;
            EventManager.onMethodUpdated += MethodUpdatedEventHandler;
            EventManager.onTemperatureUpdated += TemperatureUpdatedEventHandler;
        }

        private void TemperatureUpdatedEventHandler()
        {
            //Task.Factory.StartNew(() => {
            sKCanvasViewXAxis.InvalidateSurface();
            //});

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

            float fChartWidth = 470;
            canvas.DrawLine(0, 0, fChartWidth, 0, paint);

            AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.X);

            float fXAxisMaxVal = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTotalRunTime;
            ChartHelper.TickInfo tickInfo = ChartHelper.GetTickInfo(ChartHelper.E_LABEL_TYPE.X, fXAxisMaxVal);
            //minor tick당 pixel 수
            float fXAxisUnit = fChartWidth / fXAxisMaxVal;
            float fXAxisMinTickValInterval = (tickInfo.fMajorTickInterval / ChroZenService_Const.MinorTicksPerMajorTick);
            float fXAxisTickCount = fXAxisMaxVal / fXAxisMinTickValInterval;
                        
            float fXMinorTickInterval = fChartWidth / fXAxisTickCount;

            //major tick당 pixel 수
            float fXMajotTickInterval = fXMinorTickInterval * ChroZenService_Const.MinorTicksPerMajorTick;

            float fMajorTickHeight = 10;
            float fMinorTickHeight = 5;
            float fStartY = -1;

            label0.IsVisible = false;
            label1.IsVisible = false;
            label2.IsVisible = false;
            label3.IsVisible = false;
            label4.IsVisible = false;
            label5.IsVisible = false;
            label6.IsVisible = false;
            label7.IsVisible = false;
            label8.IsVisible = false;

            float fTextXOffset = -10;
            float fTextYOffest = -2;

            for (int i = 0; i < AxisLabels.Count; i++)
            {
                //Draw Major Tick 
                if (i % ChroZenService_Const.MinorTicksPerMajorTick == 0)
                {
                    int nMajorTickIndex = i / ChroZenService_Const.MinorTicksPerMajorTick;
                    AxisLabels[i].startPoint.X = fXMajotTickInterval * nMajorTickIndex;
                    AxisLabels[i].startPoint.Y = fStartY;
                    AxisLabels[i].endPoint.X = fXMajotTickInterval * nMajorTickIndex;
                    AxisLabels[i].endPoint.Y = fStartY + fMajorTickHeight;
                    canvas.DrawLine(AxisLabels[i].startPoint, AxisLabels[i].endPoint, paint);

                    SKPoint textPoint = new SKPoint();
                    textPoint.X = AxisLabels[i].endPoint.X + fTextXOffset;
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
                    AxisLabels[i].startPoint.X = fXMinorTickInterval * i;
                    AxisLabels[i].startPoint.Y = fStartY;
                    AxisLabels[i].endPoint.X = fXMinorTickInterval * i;
                    AxisLabels[i].endPoint.Y = fStartY + fMinorTickHeight;
                    canvas.DrawLine(AxisLabels[i].startPoint, AxisLabels[i].endPoint, paint);
                }
            }

            //float fXAxisOffset = -1;
            //float fXAxisLengthForDraw = 470 + fXAxisOffset;
            //int nTotalTickCount = 45;
            //int nMajorTickInterval = 5;
            //float[] dMajorTicks = new float[nTotalTickCount / nMajorTickInterval];

            //for (int i = 0; i < nTotalTickCount; i++)
            //{
            //    //Major tick draw
            //    if (i % 5 == 0)
            //    {
            //        int nMajorTickIndex = i / 5;
            //        dMajorTicks[nMajorTickIndex] = (fXAxisLengthForDraw / (float)(dMajorTicks.Length - 1)) * nMajorTickIndex;
            //        canvas.DrawLine(dMajorTicks[nMajorTickIndex], 0, dMajorTicks[nMajorTickIndex], 10, paint);
            //    }
            //    //Major tick draw
            //    else if (i <= 40)
            //    {
            //        float fMinorTickX = (fXAxisLengthForDraw / (float)(40)) * i;
            //        canvas.DrawLine(fMinorTickX, 0, fMinorTickX, 5, paint);
            //    }
            //}
        }
    }
}