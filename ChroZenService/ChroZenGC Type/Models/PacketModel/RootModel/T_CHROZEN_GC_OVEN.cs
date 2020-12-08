using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_CHROZEN_GC_OVEN
    {
        //fMaxTemp = 450.0f;
        //fEquibTime = 1.0f;
        //fTempSet = 50.0f;
        //fInitTime = 10.0f;		
        public float fMaxTemp;                             // 오븐 최대온도설정 (-80℃ ~ 450℃) // default : 450
        public float fEquibTime;                           // 평형시간 (0~9999min / default = 1.0min)

        public byte bCryogenic;                            // 극저온 Cryogenic 사용여부(0:사용하지 않음 / 1:사용) 	// default : OFF
        public byte btCoolant;                             // 냉각재(0:Liquid N2 / 1:Liquid CO2) 	// default : OFF
        public byte bFastCryo;                             // Fast mode 설정(0:OFF / 1:ON) 	// default : OFF   -> 6500GC에서는 사용 안함
        public byte __bCryoTimeout;                        //  -> 6500GC에서는 사용 안함
        public byte __bCryoFault;                          //  -> 6500GC에서는 사용 안함

        public float fTempSet;                             // 설정온도(-80℃ ~ fMaxTemp) // default : 50	
        public byte bTempOnoff;                            // 히터 ON / OFF(0:OFF / 1 : ON) // default : OFF        
        public float fInitTime;                            // 초기유지시간(0~9999min / default = 10min)
        public byte btMode;                                // 오븐작동모드(0:Iso-thermal(등온) / 1:Program Mode)
        public enum E_OVEN_MODE
        {
            ISO_THREMAL,
            PROGRAM_MODE
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        public T_OVEN_PRGM[] Prgm;                         // [OVEN_PRGM_CNT]
                                                           // OVEN_PRGM_CNT = 25

        public byte bAutoReadyrun;                         // 준비상태 자동복원 (0:OFF / 1:ON) // default : ON
        public float fTotalRunTime;                        // - 총 분석시간 // 계산하여 표시
                                                           // Isothermal Mode : fInitTime // Programmed Mode : fInitTime + 
                                                           //enum { Off = 0, On };							//		((finalTemp(현재행) - finalTemp(이전행))/Rate(현재행)) + finalTime(현재행)
        public T_CHROZEN_RUNSTART_FUNCTION Runstart;

        //CHROZEN_RUNSTART_FUNCTION_t Runstart;	
        // Run Start 정보 - 자동반복분석
        public T_POSTRUN_FUNCTION Postrun;

    }
    public static class T_CHROZEN_GC_OVENManager
    {
        static T_CHROZEN_GC_OVENManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_CHROZEN_GC_OVEN InitiatedInstance;

        static T_CHROZEN_GC_OVEN GetInitializedInstance()
        {
            T_CHROZEN_GC_OVEN Instance = new T_CHROZEN_GC_OVEN
            {
                fMaxTemp = 450.0f,
                fEquibTime = 1.0f,
                fTempSet = 50.0f,
                fInitTime = 10.0f,
                Prgm = new T_OVEN_PRGM[YC_Const.OVEN_PRGM_CNT],
                Runstart = T_CHROZEN_RUNSTART_FUNCTIONManager.InitiatedInstance,
                Postrun = T_POSTRUN_FUNCTIONManager.InitiatedInstance
            };
            for (int i = 0; i < Instance.Prgm.Length; i++)
            {
                Instance.Prgm[i] = T_OVEN_PRGMManager.InitiatedInstance;
            }
            return Instance;
        }
    }
}
