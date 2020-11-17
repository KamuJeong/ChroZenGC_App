using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_DEV_TEMP
    {
        public float fOven;
        public float fOvenSet;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fInj;            //3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fInjSet;         //3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] fDet;            //3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fAux;            //8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fExt;            //2
    }
    public static class T_CHROZEN_GC_DEV_TEMPManager
    {
        static T_CHROZEN_GC_DEV_TEMPManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_DEV_TEMP InitiatedInstance;

        static T_CHROZEN_GC_DEV_TEMP GetInitializedInstance()
        {
            return new T_CHROZEN_GC_DEV_TEMP
            {
                fInj = new float[3],
                fInjSet = new float[3],
                fDet = new float[3],
                fAux = new float[8],
                fExt = new float[2],
            };
        }
    }
}
