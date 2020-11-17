using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_APC_FLOW
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Press;                   // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public float[] Disp_InjFlow;                 // 3 X 4 = 12
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Velocity_Inj;            // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Setflow;                 // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Disp_Setpress;                // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Disp_DetFlow;                 // 3 X 3 = 9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Disp_AuxFlow;                 // 3 X 3 = 9
    }
    public static class T_CHROZEN_GC_APC_FLOWManager
    {
        static T_CHROZEN_GC_APC_FLOWManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_APC_FLOW InitiatedInstance;

        static T_CHROZEN_GC_APC_FLOW GetInitializedInstance()
        {
            return new T_CHROZEN_GC_APC_FLOW
            {
                Disp_Press = new float[3],
                Disp_InjFlow = new float[12],
                Disp_Velocity_Inj = new float[3],
                Disp_Setflow = new float[3],
                Disp_Setpress = new float[3],
                Disp_DetFlow = new float[9],
                Disp_AuxFlow = new float[9]
            };
        }
    }
}
