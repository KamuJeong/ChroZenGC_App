
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;

namespace ChroZenService
{
    public class ViewModel_MainChart : BindableNotifyBase
    {
        int _SelectedDetectorIndex;
        public int SelectedDetectorIndex { get { return _SelectedDetectorIndex; } set { if (_SelectedDetectorIndex != value) { _SelectedDetectorIndex = value; OnPropertyChanged("SelectedDetectorIndex"); } } }

        public static readonly BindableProperty ChartElementRawDataProperty =
        BindableProperty.Create("ChartElementRawData", typeof(YL_ChartElementRawData), typeof(ViewModel_MainChart),
            defaultValue: new YL_ChartElementRawData()
            , defaultBindingMode: BindingMode.OneWay);

        public YL_ChartElementRawData ChartElementRawData
        {
            get { return (YL_ChartElementRawData)GetValue(ChartElementRawDataProperty); }
            set { SetValue(ChartElementRawDataProperty, value); }
        }

        public ViewModel_MainChart()
        {

            EventManager.onPACKCODE_Receivce += onPACKCODE_ReceivceEventHandler;
        }

        public E_STATE prevE_STATE;
        private void onPACKCODE_ReceivceEventHandler(YC_Const.E_PACKCODE e_LC_PACK_CODE, int nIndex)
        {
            Task.Factory.StartNew(() => {
                switch (e_LC_PACK_CODE)
                {
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                        {
                            if ((E_STATE)(DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.btState) == E_STATE.Run)
                            {
                                if (prevE_STATE != E_STATE.Run)
                                {
                                    EventManager.RunStartedEvent();
                                    ChartElementRawData.yC_ChartElementRawDataDetector[0].RawData = new List<float>();
                                    ChartElementRawData.yC_ChartElementRawDataDetector[1].RawData = new List<float>();
                                    ChartElementRawData.yC_ChartElementRawDataDetector[2].RawData = new List<float>();
                                    //ChartElementRawData.yC_ChartElementRawDataTemperature.RawData = new float[470];
                                    ChartElementRawData.yC_ChartElementRawDataTimeStamp.RawData = new List<float>();
                                    prevE_STATE = E_STATE.Run;
                                }
                                float fXUnit = 470 / (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fTotalRunTime);

                                int nPixelXPosition = (int)(DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.fRunTime * fXUnit);

                                ChartElementRawData.yC_ChartElementRawDataDetector[0].RawData.Add(DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.fSignal[0]);
                                ChartElementRawData.yC_ChartElementRawDataDetector[1].RawData.Add(DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.fSignal[1]);
                                ChartElementRawData.yC_ChartElementRawDataDetector[2].RawData.Add(DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.fSignal[2]);
                                //ChartElementRawData.yC_ChartElementRawDataTemperature.RawData[i] = ((T_PACKCODE_CHROZEN_SYSTEM_STATE)packet).packet.ActTemp.fOven;
                                ChartElementRawData.yC_ChartElementRawDataTimeStamp.RawData.Add(DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.fRunTime);

                                Task.Factory.StartNew(() => EventManager.RawDataUpdatedEvent());
                            }
                            else if ((E_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.btState != E_STATE.Run)
                            {
                                if (prevE_STATE == E_STATE.Run)
                                {
                                    EventManager.RunStoppedEvent();
                                    prevE_STATE = (E_STATE)DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE.packet.btState;
                                }
                            }
                        }
                        break;
                    case YC_Const.E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING:
                        {
                            EventManager.TemperatureUpdatedEvent();
                        }
                        break;
                }
            });
            
        }

    }
}
