using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_VALVE_CONFIG
    {
        public byte btMultiCount;                          // Multi Position Valve 수
        public byte btValveCount;                          // ?? 2-Position Valve 수 // (Air or Electronic Actuator)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btType1;                            // 2-Position Valve1~8의 밸브타입   [8] 
                                                          // #define TYPE_NONE		0 // 설치안됨
                                                          // #define TYPE_GSV			1
                                                          // #define TYPE_LSV			2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btType2;                            // #define TYPE_AIR			1		// Air Actuator [8]
                                                          // #define TYPE_ELE			2		// Electronic Actuator

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btPort;                             // 2-Position Valve1~Valve8의 포트수 [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fLoop1;                            // 2-Position Valve1~Valve8의 루프1 용량  [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public float[] fLoop2;                            // 2-Position Valve1~Valve8의 루프2 용량 [8]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] btInlet;                            // 2-Position Valve1~Valve8에 연결된 Inlet. port 번호 [8]

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiType;                        // Multi Position Valve1~2의 밸브타입 [2]
                                                          // #define TYPE_NONE			0  // 설치안됨
                                                          // #define TYPE_GSV			1
                                                          // #define TYPE_LSV			2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiPort;                        // Multi Position Valve1~2의 포트수 [2]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] fMultiLoop;                        // Multi Position Valve1~2의 루프용량 [2]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] btMultiInlet;                       // Multi Position Valve1~2 에 연결된 Inlet. port 번호 [2]
    }
    public static class T_VALVE_CONFIGManager
    {
        static T_VALVE_CONFIGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_VALVE_CONFIG InitiatedInstance;

        static T_VALVE_CONFIG GetInitializedInstance()
        {
            return new T_VALVE_CONFIG
            {
                btType1 = new byte[8],
                btType2 = new byte[8],
                btPort = new byte[8],
                fLoop1 = new float[8],
                fLoop2 = new float[8],
                btInlet = new byte[8],
                btMultiType = new byte[2],
                btMultiPort = new byte[2],
                fMultiLoop = new float[2],
                btMultiInlet = new byte[2]
            };
        }
    }
}
