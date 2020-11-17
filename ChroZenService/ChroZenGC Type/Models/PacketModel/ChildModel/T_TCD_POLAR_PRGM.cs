using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_TCD_POLAR_PRGM
    {
        //fTime = 0.0f;
        //btPolarity = End;

        public float fTime;                  // 시간 default :0.0min

        public byte btPolarity;             // 극성(0:+ / 1:- / 2:Program End) // default : 2
                                            // 프로그램 끝에는 반드시[Program End]가 있어야 함.
    }
    public static class T_TCD_POLAR_PRGMManager
    {
        static T_TCD_POLAR_PRGMManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_TCD_POLAR_PRGM InitiatedInstance;

        static T_TCD_POLAR_PRGM GetInitializedInstance()
        {
            return new T_TCD_POLAR_PRGM
            {
                fTime = 0,
                btPolarity = 2
            };
        }
    }
}
