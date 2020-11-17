using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_APC_SENSOR_VOLTAGE
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Inj_Volt;//9,			// Inj 3*3 Voltage
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Det_Volt;//9,			// Det 3*3 Voltage
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Aux_Volt;//9,			// Aux 3*3 Voltage
    }
    public static class T_APC_SENSOR_VOLTAGEManager
    {
        static T_APC_SENSOR_VOLTAGEManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_APC_SENSOR_VOLTAGE InitiatedInstance;

        static T_APC_SENSOR_VOLTAGE GetInitializedInstance()
        {
            return new T_APC_SENSOR_VOLTAGE
            {
                Inj_Volt = new float[9],
                Det_Volt = new float[9],
                Aux_Volt = new float[9],
            };
        }
    }
}
