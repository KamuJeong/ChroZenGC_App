using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_FLOW_READY
    {
        public uint nFlowReady;
        //    struct {

        //    unsigned bColFlow1 : 1;
        //    unsigned bColFlow2 : 1;
        //    unsigned bColFlow3 : 1;
        //    unsigned bDetFlow11 : 1;
        //    unsigned bDetFlow12 : 1;
        //    unsigned bDetFlow13 : 1;
        //    unsigned bDetFlow21 : 1;
        //    unsigned bDetFlow22 : 1;
        //    unsigned bDetFlow23 : 1;
        //    unsigned bDetFlow31 : 1;
        //    unsigned bDetFlow32 : 1;
        //    unsigned bDetFlow33 : 1;
        //    unsigned bColPress1 : 1;
        //    unsigned bColPress2 : 1;
        //    unsigned bColPress3 : 1;

        //    unsigned bAuxFlow11 : 1;
        //    unsigned bAuxFlow12 : 1;
        //    unsigned bAuxFlow13 : 1;
        //    unsigned bAuxFlow21 : 1;
        //    unsigned bAuxFlow22 : 1;
        //    unsigned bAuxFlow23 : 1;
        //    unsigned bAuxFlow31 : 1;
        //    unsigned bAuxFlow32 : 1;
        //    unsigned bAuxFlow33 : 1;
        //    unsigned unuse : 8;
        //};
    }
    public static class T_CHROZEN_GC_FLOW_READYManager
    {
        static T_CHROZEN_GC_FLOW_READYManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_FLOW_READY InitiatedInstance;

        static T_CHROZEN_GC_FLOW_READY GetInitializedInstance()
        {
            return new T_CHROZEN_GC_FLOW_READY
            {

            };
        }
    }
}
