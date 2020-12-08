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

        public static readonly BindableProperty AxisLabelsProperty =
        BindableProperty.Create("AxisLabels", typeof(ObservableCollection<YL_ChartTick>), typeof(View_ChartYAxis),
            defaultValue: new ObservableCollection<YL_ChartTick> { new YL_ChartTick() },
            propertyChanged: onAxisLabelsPropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        public ObservableCollection<YL_ChartTick> AxisLabels
        {
            get { return (ObservableCollection<YL_ChartTick>)GetValue(AxisLabelsProperty); }
            set { SetValue(AxisLabelsProperty, value); }
        }

        private static void onAxisLabelsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as View_ChartYAxis).AxisLabels = (ObservableCollection<YL_ChartTick>)newValue;
            }
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
            sKCanvasViewXAxis.InvalidateSurface();
            //});

        }

        private void onChartOffsetChangedEventHandler(double deltaX, float deltaY)
        {
            //Task.Factory.StartNew(() =>
            //{
            VerticalOffset = deltaY;
            sKCanvasViewXAxis.InvalidateSurface();
            //Debug.WriteLine(string.Format("View_ChartYAxis : YAxis Y Offset Changed To={0}", deltaY));
            //});

        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint temperaturePaint = new SKPaint();
            temperaturePaint.Color = new SKColor(0x00, 0xff, 0x00, 0xff);

            float fStartX = ChartAxisType == CHART_AXIS_TYPE.Y_SIGNAL ? 49 : 0;
            SKColor paintColor = ChartAxisType == CHART_AXIS_TYPE.Y_SIGNAL ? new SKColor(0xff, 0xff, 0xff, 0xff) : new SKColor(0x3c, 0xb0, 0x43, 0xff);
            temperaturePaint.Color = paintColor;

            float fChartHeight = 195;

            canvas.DrawLine(fStartX, 0, fStartX, fChartHeight, temperaturePaint);

            if (ChartAxisType == CHART_AXIS_TYPE.Y_TEMPERATURE)
            {
                AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.Y_TEMP);

                //Y축 최대 값은 가시성을 고려하여 Max온도의 2배로 설정
                float fYAxisMaxVal = ChartHelper.GetMaxTemperature() * 2 > 400 ? 400 : ChartHelper.GetMaxTemperature() * 2;

                //minor tick당 pixel 수
                float fYAxisUnit = fChartHeight / fYAxisMaxVal;

                //major tick당 pixel 수
                float fYMinorTickInterval = fYAxisMaxVal / AxisLabels.Count * fYAxisUnit;
                float fYMajotTickInterval = fYMinorTickInterval * ChroZenService_Const.MinorTicksPerMajorTick;

                float fMajorTickLength = 10;
                float fMinorTickLength = 5;

                SKPoint startPoint = new SKPoint();
                SKPoint endPoint = new SKPoint();

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
                        startPoint.X = fStartX;
                        startPoint.Y = (fChartHeight - fYMajotTickInterval * nMajorTickIndex);
                        endPoint.X = fStartX + fMajorTickLength;
                        endPoint.Y = (fChartHeight - fYMajotTickInterval * nMajorTickIndex);
                        canvas.DrawLine(startPoint, endPoint, temperaturePaint);

                        SKPoint textPoint = new SKPoint();
                        textPoint.X = endPoint.X;
                        textPoint.Y = endPoint.Y + fTextYOffest;
                        Thickness textMargin = new Thickness(textPoint.X, textPoint.Y, 0, 0);

                        //SKPaint textPaint = new SKPaint
                        //{
                        //    TextSize = 13,
                        //    FilterQuality = SKFilterQuality.High,
                        //    IsAntialias = true,
                        //    IsDither = true,
                        //    Color = new SKColor(0x3c, 0xb0, 0x43, 0xff),
                        //    StrokeJoin = SKStrokeJoin.Round,
                        //    SubpixelText = true
                        //};
                        //canvas.DrawText(AxisLabels[i].TickLabel, textPoint, textPaint);

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
                        canvas.DrawLine(fStartX,
                (fChartHeight - fYMinorTickInterval * i),
                fStartX + fMinorTickLength,
                (fChartHeight - fYMinorTickInterval * i), temperaturePaint);
                    }
                }
            }
            else if (ChartAxisType == CHART_AXIS_TYPE.Y_SIGNAL)
            {
                fStartX = 39;
                //Det Y축 시작 값
                float fTStartVal = ChartHelper.GetMaxSignal(VerticalDelta, VerticalOffset);
                float fValRange = fTStartVal - VerticalOffset;
                AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.Y_DET, fTStartVal, VerticalOffset);
                Debug.WriteLine(string.Format("fTStartVal = {0}", fTStartVal));

                //minor tick당 pixel 수
                //float fYAxisUnit = fChartHeight / fYAxisMaxVal;

                //major tick당 pixel 수
                //float fYMinorTickInterval = fYAxisMaxVal / AxisLabels.Count * fYAxisUnit;
                float fYMinorTickInterval = fChartHeight / (AxisLabels.Count - 1);
                float fYMajorTickInterval = fYMinorTickInterval * ChroZenService_Const.MinorTicksPerMajorTick;


                //Det Y축 시작 pixel Offset
                float fYMinorTickOffset = -fTStartVal % fYMinorTickInterval;
                Debug.WriteLine(string.Format("fYMinorTickOffset = {0}, fYMinorTickInterval = {1}", fYMinorTickOffset, fYMinorTickInterval));

                float fYMajorTickOffset = +fTStartVal % fYMajorTickInterval;
                Debug.WriteLine(string.Format("fYMajorTickOffset = {0}, fYMajorTickInterval = {1}", fYMajorTickOffset, fYMajorTickInterval));

                //Y축 Majortick 시작 index
                //int nYMajorTickStartOffset = (int)((fTStartVal % fYMajorTickOffset) / fYMinorTickInterval);
                float fYMajorTickSeed = (float)Math.Abs(AxisLabels.Count * VerticalOffset / fValRange);
                Debug.WriteLine(string.Format("Raw fYMajorTickSeed = {0}", fYMajorTickSeed));
                //if (fYMajorTickSeed < 0)
                //{
                //    fYMajorTickSeed = (float)Math.Ceiling(Math.Abs(fYMajorTickSeed));
                //    Debug.WriteLine(string.Format("Negative fYMajorTickSeed = {0}", fYMajorTickSeed));
                //}
                //else
                //{
                //    fYMajorTickSeed = (float)Math.Ceiling(Math.Abs(fYMajorTickSeed));
                //    Debug.WriteLine(string.Format("Positive fYMajorTickSeed = {0}", fYMajorTickSeed));
                //}
                int nYMajorTickStartOffset = (int)
                   fYMajorTickSeed
                     % ChroZenService_Const.MinorTicksPerMajorTick;

                float fMinVal = fTStartVal - fValRange;
                int nMajorTickVal = (int)(fValRange / (AxisLabels.Count / ChroZenService_Const.MinorTicksPerMajorTick));
                int nMinorTickVal = nMajorTickVal / ChroZenService_Const.MinorTicksPerMajorTick;
                float fSpareValForMinorTick = fMinVal % nMajorTickVal;
                fYMinorTickOffset = ((fMinVal % nMinorTickVal) / nMinorTickVal) * fYMinorTickInterval;
                if (fMinVal > 0)
                    fYMinorTickOffset = fYMinorTickOffset - fYMinorTickInterval;
                Debug.WriteLine(string.Format("fYMinorTickOffset = {0}, fMinVal={1}, nMinorTickVal = {2},  fYMinorTickInterval = {3}",
                    fYMinorTickOffset, fMinVal, nMinorTickVal, fYMinorTickInterval));
                nYMajorTickStartOffset = (int)Math.Abs(fSpareValForMinorTick / nMinorTickVal);
                if (fMinVal > 0)
                    nYMajorTickStartOffset = ChroZenService_Const.MinorTicksPerMajorTick - 1 -
                        nYMajorTickStartOffset;
                Debug.WriteLine(string.Format("fMinVal = {0}, nMajorTickVal={1}, fSpareValForMinorTick = {2},  nYMajorTickStartOffset = {3}",
                    fMinVal, nMajorTickVal, fSpareValForMinorTick, nYMajorTickStartOffset));

                AxisLabels = ChartHelper.GetLabels(ChartHelper.E_LABEL_TYPE.Y_DET, fTStartVal, VerticalOffset, nYMajorTickStartOffset);

                float fMajorTickLength = 10;
                float fMinorTickLength = 5;

                SKPoint startPoint = new SKPoint();
                SKPoint endPoint = new SKPoint();

                //label0.TextColor = Color.White;
                //label1.TextColor = Color.White;
                //label2.TextColor = Color.White;
                //label3.TextColor = Color.White;
                //label4.TextColor = Color.White;
                //label5.TextColor = Color.White;
                //label6.TextColor = Color.White;
                //label7.TextColor = Color.White;
                //label8.TextColor = Color.White;

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
                        fStartX = 39;
                        int nMajorTickIndex = i / ChroZenService_Const.MinorTicksPerMajorTick;
                        startPoint.X = fStartX;
                        startPoint.Y = (fChartHeight - fYMajorTickInterval * nMajorTickIndex) - (fYMinorTickInterval * nYMajorTickStartOffset) + fYMinorTickOffset;
                        //Debug.WriteLine(string.Format("nYMajorTickstartPoint = {0}", startPoint.Y));

                        endPoint.X = fStartX + fMajorTickLength;
                        endPoint.Y = (fChartHeight - fYMajorTickInterval * nMajorTickIndex) - (fYMinorTickInterval * nYMajorTickStartOffset) + fYMinorTickOffset;
                        canvas.DrawLine(startPoint, endPoint, temperaturePaint);

                        SKPoint textPoint = new SKPoint();
                        textPoint.X = endPoint.X + fTextXOffset;
                        textPoint.Y = endPoint.Y + fTextYOffest;
                        Thickness textMargin = new Thickness(textPoint.X, textPoint.Y, 0, 0);
                        SKPaint textPaint = new SKPaint
                        {
                            TextSize = 14,
                            Color = new SKColor(0xff, 0xff, 0xff, 0xff),
                            IsAntialias = true,
                            FilterQuality = SKFilterQuality.High
                        };
                        canvas.DrawText(AxisLabels[i].TickLabel, textPoint, textPaint);
                        //switch (nMajorTickIndex)
                        //{
                        //    case 0:
                        //        {
                        //            label0.IsVisible = true;
                        //            label0.Text = AxisLabels[i].TickLabel;
                        //            label0.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 1:
                        //        {
                        //            label1.IsVisible = true;
                        //            label1.Text = AxisLabels[i].TickLabel;
                        //            label1.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 2:
                        //        {
                        //            label2.IsVisible = true;
                        //            label2.Text = AxisLabels[i].TickLabel;
                        //            label2.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 3:
                        //        {
                        //            label3.IsVisible = true;
                        //            label3.Text = AxisLabels[i].TickLabel;
                        //            label3.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 4:
                        //        {
                        //            label4.IsVisible = true;
                        //            label4.Text = AxisLabels[i].TickLabel;
                        //            label4.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 5:
                        //        {
                        //            label5.IsVisible = true;
                        //            label5.Text = AxisLabels[i].TickLabel;
                        //            label5.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 6:
                        //        {
                        //            label6.IsVisible = true;
                        //            label6.Text = AxisLabels[i].TickLabel;
                        //            label6.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 7:
                        //        {
                        //            label7.IsVisible = true;
                        //            label7.Text = AxisLabels[i].TickLabel;
                        //            label7.Margin = textMargin;
                        //        }
                        //        break;
                        //    case 8:
                        //        {
                        //            label8.IsVisible = true;
                        //            label8.Text = AxisLabels[i].TickLabel;
                        //            label8.Margin = textMargin;
                        //        }
                        //        break;
                        //}
                    }
                    //Draw Minor Tick
                    else
                    {
                        fStartX = 44;
                        canvas.DrawLine(fStartX,
                (fChartHeight - fYMinorTickInterval * i) + fYMinorTickOffset,
                fStartX + fMinorTickLength,
                (fChartHeight - fYMinorTickInterval * i) + fYMinorTickOffset, temperaturePaint);
                    }
                }
            }
        }


        private void ChartDeltaChangedEventHandler(double deltaX, float deltaY)
        {

            VerticalDelta = deltaY;
            sKCanvasViewXAxis.InvalidateSurface();
            //Debug.WriteLine(string.Format("View_ChartYAxis : YAxis Y Delta Changed To={0}", deltaY));


        }
    }
}