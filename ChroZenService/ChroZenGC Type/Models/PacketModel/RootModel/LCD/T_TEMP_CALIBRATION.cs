using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_TEMP_CALIBRATION
    {
        public float[] fSet;        //30
        public float[] fMeasure;    //30
        public float[] fFactor;     //30
    }

    public static class T_TEMP_CALIBRATIONManager
    {
        static T_TEMP_CALIBRATIONManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_TEMP_CALIBRATION InitiatedInstance;

        static T_TEMP_CALIBRATION GetInitializedInstance()
        {
            return new T_TEMP_CALIBRATION
            {
                fSet = new float[16],
                fMeasure = new float[16],
                fFactor = new float[16],
            };
        }
    }
}
