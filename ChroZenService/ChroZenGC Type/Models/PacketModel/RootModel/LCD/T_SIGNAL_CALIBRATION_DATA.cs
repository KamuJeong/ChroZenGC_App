using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_SIGNAL_CALIBRATION_DATA
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fSignalOffset;//3
    }
    public static class T_SIGNAL_CALIBRATION_DATAManager
    {
        static T_SIGNAL_CALIBRATION_DATAManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_SIGNAL_CALIBRATION_DATA InitiatedInstance;

        static T_SIGNAL_CALIBRATION_DATA GetInitializedInstance()
        {
            return new T_SIGNAL_CALIBRATION_DATA
            {
                fSignalOffset = new float[3]
            };
        }
    }
}
