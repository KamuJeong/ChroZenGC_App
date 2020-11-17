using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_VALVE_PRGM
    {
        //fTime = 0;
        //btNumber = 10;
        //btState = 0;
        public float fTime;
        public byte btNumber;      // Valve Number (
                                   // 0 : 2 - Position Valve 1 /     1 : 2 - Position Valve 2
                                   // 2 : 2 - Position Valve 3 /     3 : 2 - Position Valve 4
                                   // 4 : 2 - Position Valve 5 /     5 : 2 - Position Valve 6
                                   // 6 : 2 - Position Valve 3 /     7 : 2 - Position Valve 8
                                   // 8 : Multi - Position Valve 1 / 9 : Multi - Position Valve 2
                                   // 10 : Program end)
                                   // 프로그램 끝에는 반드시[Program End]가 있어야 함

        public byte btState;       // Valve Position(0~)
    }
    public static class T_VALVE_PRGMManager
    {
        static T_VALVE_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_VALVE_PRGM InitiatedInstance;

        static T_VALVE_PRGM GetInitializedInstance()
        {
            return new T_VALVE_PRGM
            {
                fTime = 0,
                btNumber = 10,
                btState = 0
            };
        }
    }
}
