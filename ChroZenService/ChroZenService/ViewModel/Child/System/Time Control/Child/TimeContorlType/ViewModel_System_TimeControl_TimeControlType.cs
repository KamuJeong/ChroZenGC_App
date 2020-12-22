using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_TimeControl_TimeControlType : BindableNotifyBase
    {
        public byte bDaily;
        public DateTime SysTime;

        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction;
        public byte btPortNo;
        public float fValue;
    }
}
