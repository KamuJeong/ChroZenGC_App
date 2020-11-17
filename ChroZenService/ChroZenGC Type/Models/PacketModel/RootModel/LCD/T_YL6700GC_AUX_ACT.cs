using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_AUX_ACT
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fAux;      //8, Aux Temp 8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fDisp_Aux1;        //3, Aux1 Flow 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fDisp_Aux2;        //3, Aux2 Flow 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fDisp_Aux3;		//3, Aux3 Flow 3
    }
    public static class T_YL6700GC_AUX_ACTManager
    {
        static T_YL6700GC_AUX_ACTManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_AUX_ACT InitiatedInstance;

        static T_YL6700GC_AUX_ACT GetInitializedInstance()
        {
            return new T_YL6700GC_AUX_ACT
            {
                fAux = new float[8],
                fDisp_Aux1 = new float[3],
                fDisp_Aux2 = new float[3],
                fDisp_Aux3 = new float[3],
            };
        }
    }
}
