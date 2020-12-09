using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_OVEN;

namespace ChroZenService
{
    public static class ChartHelper
    {
        public class TickInfo
        {
            public int nTickCount;
            public float fMajorTickInterval;
            public float fTickOffsetToPlus;
        }

        public static float GetMaxSignal(float VerticalDelta, float VerticalOffset)
        {
            float fRetVal = (ChroZenService_Const.fDetMaxVal * VerticalDelta) + VerticalOffset;
            //if (fRetVal < 0.00001) return 0.00001f;
            //else
            return fRetVal;
        }

        public static float GetMaxTemperature()
        {
            float fYMaxVal = 0;
            switch ((E_OVEN_MODE)DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.btMode)
            {
                case E_OVEN_MODE.ISO_THREMAL:
                    {
                        fYMaxVal = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet;
                    }
                    break;
                case E_OVEN_MODE.PROGRAM_MODE:
                    {
                        float fTemp = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTempSet;

                        fYMaxVal = fTemp;

                        for (int i = 0; i < DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm.Length; i++)
                        {
                            if (DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fRate <= 0) continue;

                            if (fYMaxVal < DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp)
                            {
                                fYMaxVal = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.Prgm[i].fFinalTemp;
                            }
                        }
                    }
                    break;
            }
            return fYMaxVal;
        }

        public enum E_LABEL_TYPE
        {
            X,
            Y_DET,
            Y_TEMP
        }

        public static TickInfo GetTickInfo(E_LABEL_TYPE e_LABEL_TYPE, float fDetMaxVal = 0, float fDetOffset = 0, float fVerticalDelta = 1)
        {
            TickInfo tickInfo = new TickInfo();
            switch (e_LABEL_TYPE)
            {
                case E_LABEL_TYPE.X:
                    {
                        float fTotalRunTime = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received.packet.fTotalRunTime;
                        float fMaxRunTimeSeed = fTotalRunTime;

                        float majorTickSeed = 0;
                        int nPowToRecover = 0;
                        //fTotalRunTime에서 1~10사이의 seed값을 추출 후 TickCount 설정
                        while (fMaxRunTimeSeed < 1)
                        {
                            fMaxRunTimeSeed = fMaxRunTimeSeed * 10;
                            nPowToRecover -= 1;
                        }
                        while (fMaxRunTimeSeed > 10)
                        {
                            fMaxRunTimeSeed = fMaxRunTimeSeed / 10;
                            nPowToRecover += 1;
                        }
                        float fPowToRecover = (float)Math.Pow(10, nPowToRecover);
                        if (fMaxRunTimeSeed > 1 && fMaxRunTimeSeed <= 1.6)
                        {
                            majorTickSeed = 0.2f;
                        }
                        else if (fMaxRunTimeSeed > 1.6 && fMaxRunTimeSeed <= 4)
                        {
                            majorTickSeed = 0.5f;
                        }
                        else if (fMaxRunTimeSeed > 4 && fMaxRunTimeSeed <= 8)
                        {
                            majorTickSeed = 1;
                        }
                        else if (fMaxRunTimeSeed > 8 && fMaxRunTimeSeed <= 10)
                        {
                            majorTickSeed = 2;
                        }
                        tickInfo.nTickCount = (int)Math.Truncate(fMaxRunTimeSeed / (majorTickSeed / ChroZenService_Const.MinorTicksPerMajorTick));
                        tickInfo.fMajorTickInterval = majorTickSeed * fPowToRecover;
                        return tickInfo;
                    }
                case E_LABEL_TYPE.Y_DET:
                    {
                        float fValRange = (fDetMaxVal - fDetOffset);
                        float fMaxYValSeed = fValRange;

                        float majorTickSeed = 0;
                        int nPowToRecover = 0;
                        if (fDetOffset != 0)
                            Debug.WriteLine(string.Format("GetTickInfo : fValRange = {0}, fDetOffset = {1} ", fValRange, fDetOffset));
                        //fTotalRunTime에서 1~10사이의 seed값을 추출 후 TickCount 설정
                        while (fMaxYValSeed < 1)
                        {
                            fMaxYValSeed = fMaxYValSeed * 10;
                            nPowToRecover -= 1;

                        }
                        while (fMaxYValSeed > 10)
                        {
                            fMaxYValSeed = fMaxYValSeed / 10;
                            nPowToRecover += 1;
                        }
                        float fPowToRecover = (float)Math.Pow(10, nPowToRecover);
                        if (fMaxYValSeed >= 1 && fMaxYValSeed <= 1.6)
                        {
                            majorTickSeed = 0.2f;
                        }
                        else if (fMaxYValSeed > 1.6 && fMaxYValSeed <= 4)
                        {
                            majorTickSeed = 0.5f;
                        }
                        else if (fMaxYValSeed > 4 && fMaxYValSeed <= 8)
                        {
                            majorTickSeed = 1;
                        }
                        else if (fMaxYValSeed > 8 && fMaxYValSeed <= 10)
                        {
                            majorTickSeed = 2;
                        }
                        //if (majorTickSeed == 0)
                        //    Debug.WriteLine(string.Format("GetTickInfo : majorTickSeed==0"));
                        tickInfo.nTickCount = (int)Math.Truncate(fMaxYValSeed / (majorTickSeed / ChroZenService_Const.MinorTicksPerMajorTick));
                        tickInfo.fMajorTickInterval = majorTickSeed * fPowToRecover;
                        tickInfo.fTickOffsetToPlus = fDetOffset;
                        //Debug.WriteLine(string.Format("GetTickInfo Complete"));
                        return tickInfo;
                    }
                case E_LABEL_TYPE.Y_TEMP:
                    {
                        float fMaxYVal = ChartHelper.GetMaxTemperature() * 2 > 400 ? 400 : ChartHelper.GetMaxTemperature() * 2;
                        fMaxYVal = fMaxYVal > 400 ? 400 : fMaxYVal;
                        float fMaxYValSeed = fMaxYVal;

                        float majorTickSeed = 0;
                        int nPowToRecover = 0;
                        //fTotalRunTime에서 1~10사이의 seed값을 추출 후 TickCount 설정
                        while (fMaxYValSeed < 1)
                        {
                            fMaxYValSeed = fMaxYValSeed * 10;
                            nPowToRecover -= 1;
                        }
                        while (fMaxYValSeed > 10)
                        {
                            fMaxYValSeed = fMaxYValSeed / 10;
                            nPowToRecover += 1;
                        }
                        float fPowToRecover = (float)Math.Pow(10, nPowToRecover);
                        if (fMaxYValSeed > 1 && fMaxYValSeed <= 1.6)
                        {
                            majorTickSeed = 0.2f;
                        }
                        else if (fMaxYValSeed > 1.6 && fMaxYValSeed <= 4)
                        {
                            majorTickSeed = 0.5f;
                        }
                        else if (fMaxYValSeed > 4 && fMaxYValSeed <= 8)
                        {
                            majorTickSeed = 1;
                        }
                        else if (fMaxYValSeed > 8 && fMaxYValSeed <= 10)
                        {
                            majorTickSeed = 2;
                        }
                        tickInfo.nTickCount = (int)Math.Truncate(fMaxYValSeed / (majorTickSeed / ChroZenService_Const.MinorTicksPerMajorTick));
                        tickInfo.fMajorTickInterval = majorTickSeed * fPowToRecover;
                        return tickInfo;
                    }
                default:
                    {
                        return tickInfo;
                    }
            }

        }

        public static List<YL_ChartTick> GetLabels(E_LABEL_TYPE e_LABEL_TYPE, float fDetMaxVal = 0, float fDetOffset = 0, int nMajorTickOffset = 0, float fVerticalDelta = 1)
        {
            //Major Tick의 수를 아래의 경우로 가정한다.
            //4, 5, 6, 7, 8
            //이 때, 각 MajorTick의 끝자리의 우선 순위를 정한다.
            //0>5>2>1>0.5>0.2>0.1

            TickInfo tickInfo = GetTickInfo(e_LABEL_TYPE, fDetMaxVal, fDetOffset, fVerticalDelta);
            //Debug.WriteLine(string.Format("GetTickInfo : tickInfo.fMajorTickInterval = {0}, nMajorTickOffset={1} ", tickInfo.fMajorTickInterval, nMajorTickOffset));
            //+1 : Tick 구간 수에 시작점을 더한다
            int nTickCount = tickInfo.nTickCount + 1;

            int nMajorTickCount = nTickCount / ChroZenService_Const.MinorTicksPerMajorTick;

            List<YL_ChartTick> labelModel = new List<YL_ChartTick>();
            for (int i = 0; i < nTickCount; i++)
            {
                if (i % ChroZenService_Const.MinorTicksPerMajorTick == nMajorTickOffset)
                {
                    //if (tickInfo.fTickOffsetToPlus <= 0)
                    //    labelModel.Add(new YL_ChartTick { IsMajorTick = true, TickLabel = ((tickInfo.fMajorTickInterval * (i - nMajorTickOffset) / ChroZenService_Const.MinorTicksPerMajorTick) + (int)(tickInfo.fTickOffsetToPlus / tickInfo.fMajorTickInterval) * tickInfo.fMajorTickInterval).ToString() });
                    //else
                    //{
                    int nOffsetSeedToPlus = (int)Math.Abs(Math.Ceiling(tickInfo.fTickOffsetToPlus / tickInfo.fMajorTickInterval));
                    float fOffsetToPlus = 0;
                    //Debug.WriteLine(string.Format("nOffsetToPlus={0}", nOffsetToPlus));
                    if (tickInfo.fTickOffsetToPlus > 0)
                    {
                        fOffsetToPlus = (nOffsetSeedToPlus * tickInfo.fMajorTickInterval);
                    }
                    else
                    {
                        fOffsetToPlus = -(nOffsetSeedToPlus * tickInfo.fMajorTickInterval);
                    }
                    //if (i - nMajorTickOffset == 0)
                    //{
                    //    labelModel.Add(new YL_ChartTick { IsMajorTick = true, TickLabel = tickInfo.fMajorTickInterval.ToString() });
                    //}
                    ////else labelModel.Add(new YL_ChartTick { IsMajorTick = true, TickLabel = ((int)(i / nMajorTickCount) * tickInfo.fMajorTickInterval).ToString() });
                    //else
                    switch(e_LABEL_TYPE)
                    {
                        case E_LABEL_TYPE.Y_DET:
                            {
                                labelModel.Add(new YL_ChartTick { IsMajorTick = true, TickLabel = ((tickInfo.fMajorTickInterval * (i - nMajorTickOffset) / ChroZenService_Const.MinorTicksPerMajorTick) + fOffsetToPlus).ToString("0.####") });
                            }
                            break;
                        default:
                            {
                                labelModel.Add(new YL_ChartTick { IsMajorTick = true, TickLabel = ((tickInfo.fMajorTickInterval * (i - nMajorTickOffset) / ChroZenService_Const.MinorTicksPerMajorTick)).ToString("0.####") });
                            }
                            break;
                    }
                    
                    //}
                    //Debug.WriteLine(string.Format("tickInfo.fTickOffsetToPlus = {0}, (int)(tickInfo.fTickOffsetToPlus / tickInfo.fMajorTickInterval) * tickInfo.fMajorTickInterval = {1}", tickInfo.fTickOffsetToPlus, (int)(tickInfo.fTickOffsetToPlus / tickInfo.fMajorTickInterval) * tickInfo.fMajorTickInterval));
                    //if (nMajorTickOffset != 0)
                    //{
                    //    //Debug.WriteLine(string.Format("label fMajorTickInterval : {0},  tickInfo.fTickOffsetToPlus - tickInfo.fTickOffsetToPlus % tickInfo.fMajorTickInterval : {1}",
                    //    //    tickInfo.fMajorTickInterval * i, tickInfo.fTickOffsetToPlus - tickInfo.fTickOffsetToPlus % tickInfo.fMajorTickInterval));
                    //    Debug.WriteLine(string.Format("label nMajorTickOffset : {0}", nMajorTickOffset));
                    //    Debug.WriteLine(string.Format("label fTickOffsetToPlus : {0}", tickInfo.fTickOffsetToPlus));
                    //    Debug.WriteLine(string.Format("label offset : {0}", tickInfo.fTickOffsetToPlus % tickInfo.fMajorTickInterval));
                    //    Debug.WriteLine(string.Format("TickLabel : {0}", ((tickInfo.fMajorTickInterval * (i - nMajorTickOffset) / ChroZenService_Const.MinorTicksPerMajorTick) + (int)(tickInfo.fTickOffsetToPlus / tickInfo.fMajorTickInterval) * tickInfo.fMajorTickInterval).ToString()));
                    //}
                }
                else
                    labelModel.Add(new YL_ChartTick { IsMajorTick = false, TickLabel = "" });
            }
            return labelModel;
        }
    }
}
