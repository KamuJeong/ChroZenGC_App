using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_SIGNAL_PRGM
    {
        //fTime = 0;
        //btDet = 3;
        public float fTime;
        public byte btDet;                                 // Detector (0:front / 1:center / 2:rear)
                                                           // 프로그램 의 마지막은 btDet = 3;
    }
    public static class T_SIGNAL_PRGMManager
    {
        static T_SIGNAL_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_SIGNAL_PRGM InitiatedInstance;

        static T_SIGNAL_PRGM GetInitializedInstance()
        {
            return new T_SIGNAL_PRGM
            {
                fTime = 0,
                btDet = 3,
            };
        }
    }
}
