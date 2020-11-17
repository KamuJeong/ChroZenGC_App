using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_YL6700GC_APC_Calib_Read
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] InjSenZeroState;//3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] DetSenZeroState;//3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] InjValCalState;//3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] DetValCalState;//3

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Disp_InjValcalib;//9,		// 밸브에 걸리는 전압값 / 0:Tot(pak,on) 1:Purge 2:Spl
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Disp_DetValcalib;//9,	// 밸브에 걸리는 전압값 / sen1~3

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] APC_InjErrorCode;//9,	// 각 센서별 ErrorCode
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] APC_DetErrorCode;//9,	// 에러가 없을 경우 Pass 디스플레이

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] AuxSenZeroState;//3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] AuxValCalState;//3

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] Disp_AuxValcalib;//9,	// 밸브에 걸리는 전압값 

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] APC_AuxErrorCode;//9,	// 각 센서별 ErrorCode

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] APC_InjSensorVolt;//9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] APC_DetSensorVolt;//9
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] APC_AuxSensorVolt;//9
    }
    public static class T_YL6700GC_APC_Calib_ReadManager
    {
        static T_YL6700GC_APC_Calib_ReadManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_YL6700GC_APC_Calib_Read InitiatedInstance;

        static T_YL6700GC_APC_Calib_Read GetInitializedInstance()
        {
            return new T_YL6700GC_APC_Calib_Read
            {
                InjSenZeroState = new byte[3],//3
                DetSenZeroState = new byte[3],//3
                InjValCalState = new byte[3],//3
                DetValCalState = new byte[3],//3
                Disp_InjValcalib = new float[9],//9,
                Disp_DetValcalib = new float[9],//9,

                APC_InjErrorCode = new byte[9],//9,	
                APC_DetErrorCode = new byte[9],//9,	

                AuxSenZeroState = new byte[3],//3
                AuxValCalState = new byte[3],//3
                Disp_AuxValcalib = new float[9],//9,
                APC_AuxErrorCode = new byte[9],//9,	
                APC_InjSensorVolt = new float[9],//9
                APC_DetSensorVolt = new float[9],//9
                APC_AuxSensorVolt = new float[9],//9            
            };
        }
    }
}
