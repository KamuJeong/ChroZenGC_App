using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_REMOTE_ACCESS_FUNCTION
    {
        public float fTime;            // Start signal 출력유지시간 (mSec) (100-5000)msec
        public byte bOnoff;
        public float fEventTime1;  // Start signal 출력시간 (min) (0-9999)
        public float fEventTime2;	//
    }
    public static class T_REMOTE_ACCESS_FUNCTIONManager
    {
        static T_REMOTE_ACCESS_FUNCTIONManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_REMOTE_ACCESS_FUNCTION InitiatedInstance;

        static T_REMOTE_ACCESS_FUNCTION GetInitializedInstance()
        {
            return new T_REMOTE_ACCESS_FUNCTION
            {

            };
        }
    }
}
