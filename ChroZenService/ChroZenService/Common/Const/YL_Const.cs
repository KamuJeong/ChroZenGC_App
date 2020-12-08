using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public static class ChroZenService_Const
    {
        public enum CHART_DELTA_TYPE
        {
            CHART_DELTA,
            AXIS_DELTA
        }

        public enum CHART_AXIS_TYPE
        {
            Y_SIGNAL,
            Y_TEMPERATURE,            
        }

        public enum MAIN_SIDE_BUTTON_TYPE
        {
            INLET,
            DET
        }
        public enum MAIN_SIDE_ELEMENT_TYPE
        {
            TOP,
            CENTER,
            BOTTOM
        }
        public enum APC_MODE
        {
            Const_Flow,
            Const_Press,
            Prog_Flow,
            Prog_Press
        }
        public enum DET_TYPE
        {

        }
        public enum CARRIER_GAS_TYPE
        {
            N2,
            He,
            H2,
            Ar,
            ArCh4
        }

        public static float fDetMaxVal = 10000;
        public static int MinorTicksPerMajorTick = 5;
        public static double dMainPageEnabledSideInfoHeight = 257;
    }
}
