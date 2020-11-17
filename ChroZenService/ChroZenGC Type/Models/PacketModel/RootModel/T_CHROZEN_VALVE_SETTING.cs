using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_VALVE_SETTING
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bInitState;                          // 2 - Position Valve 초기상태(OFF : 0 / ON : 1) // default : OFF,      [CHROGEN_VALVE_COUNT] = 8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bState;                                           // [CHROGEN_VALVE_COUNT]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiInitState;            // Multi - Position Valve초기 위치(Position : 0~) // default : Pos1,      [CHROGEN_MULTI_VALVE_COUNT] = 2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiState;          // Valve Program : YL6700GC_VALVE_PROGRAM = 20,       [CHROGEN_MULTI_VALVE_COUNT] = 2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public T_VALVE_PRGM[] Prgm;            // [CHROGEN_VALVE_PROGRAM] = 20;       
    }
    public static class T_CHROZEN_VALVE_SETTINGManager
    {
        static T_CHROZEN_VALVE_SETTINGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_VALVE_SETTING InitiatedInstance;

        static T_CHROZEN_VALVE_SETTING GetInitializedInstance()
        {
            return new T_CHROZEN_VALVE_SETTING
            {
                bInitState = new byte[YC_Const.CHROGEN_VALVE_COUNT],
                bState = new byte[YC_Const.CHROGEN_VALVE_COUNT],
                btMultiInitState = new byte[YC_Const.CHROGEN_MULTI_VALVE_COUNT],
                btMultiState = new byte[YC_Const.CHROGEN_MULTI_VALVE_COUNT],
                Prgm = new T_VALVE_PRGM[]
                {
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,

                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                    T_VALVE_PRGMManager.InitiatedInstance,
                }
            };
        }
    }
}
