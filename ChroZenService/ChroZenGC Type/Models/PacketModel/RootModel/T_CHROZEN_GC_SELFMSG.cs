using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{   
    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct T_CHROZEN_GC_SELFMSG
    {
        public enum E_SELF_MSG
        {
            STATUS=1,
            ERROR,
            METHOD_LOAD,
            EXT,
            START,
            STOP,
            UPDATE,
            SYSTEM_SLEEP,
            SYSTEM_WAKEUP
        }
       public byte btMessage;                             // Message
                                                          // (1:GC 상태 / 2 : 에러 / 3 : Method load
                                                          //	4 : 외부출력 / 5 : Start / 6 : Stop / 7 : update)
                                                          //	8: System Sleep / 9 : System Wake up
                                                          //enum { State = 1, Error, MethodLoad, ExtOut, Start, Stop, UpdateVersion, SystemSleep, SystemWakeup };
        public enum E_SELF_NEW_VALUE
        {
            EXT_START=0,
            REPEAT_START,
        }

        public byte btNewValue;                            // (0: 외부입력 Start , 스타트 버튼입력 , 스톱버튼 입력 /
                                                    // 1:반복분석자동시작, 분석완료(반복분석중이면 매번 전송)
        //enum { OutSignal, InSignal };
    }
    public static class T_CHROZEN_GC_SELFMSGManager
    {
        static T_CHROZEN_GC_SELFMSGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_SELFMSG InitiatedInstance;

        static T_CHROZEN_GC_SELFMSG GetInitializedInstance()
        {
            return new T_CHROZEN_GC_SELFMSG
            {

            };
        }
    }
}
