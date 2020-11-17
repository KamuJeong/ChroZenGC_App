using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_TEMP_READY
    {
        public ushort nTempReady;
        byte dummy1;
        byte dummy2;
        //    struct {

        //        unsigned bOven : 1;
        //    unsigned bInj1 : 1;
        //    unsigned bInj2 : 1;
        //    unsigned bInj3 : 1;
        //    unsigned bDet1 : 1;
        //    unsigned bDet2 : 1;
        //    unsigned bDet3 : 1;

        //    unsigned bAux1 : 1;
        //    unsigned bAux2 : 1;
        //    unsigned bAux3 : 1;

        //    unsigned bMeth : 1;

        //    unsigned bAux5 : 1;
        //    unsigned bMet6 : 1;
        //    unsigned bAux7 : 1;
        //    unsigned bAux8 : 1;

        //    unsigned unuse : 1;
        //};
    }
    public static class T_CHROZEN_GC_TEMP_READYManager
    {
        static T_CHROZEN_GC_TEMP_READYManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_TEMP_READY InitiatedInstance;

        static T_CHROZEN_GC_TEMP_READY GetInitializedInstance()
        {
            return new T_CHROZEN_GC_TEMP_READY
            {

            };
        }
    }
}
