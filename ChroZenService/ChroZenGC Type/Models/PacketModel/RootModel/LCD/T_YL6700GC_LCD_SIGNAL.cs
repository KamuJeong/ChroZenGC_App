using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_LCD_SIGNAL
    {
        public uint nIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public float[] fSignal;
    }
    public static class T_YL6700GC_LCD_SIGNALManager
    {
        static T_YL6700GC_LCD_SIGNALManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_LCD_SIGNAL InitiatedInstance;

        static T_YL6700GC_LCD_SIGNAL GetInitializedInstance()
        {
            return new T_YL6700GC_LCD_SIGNAL
            {
                fSignal = new float[12],
            };
        }
    }
}
