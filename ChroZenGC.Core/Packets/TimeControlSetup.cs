using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Packets
{
    public enum TimeFunctions : byte
    {
        AllOff, TempOff, FlowOff, DetOff, Start = 5, SetOven, None = 9
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _TimeProgram
    {
        public byte bDaily;
        public _SystemTime SysTime;

        /// <summary>
        /// 실행 목록
        /// 0 : 모든 히팅, 유량, Electrometer, Filament, BeadPower Off
        /// 1 : 모든 히팅영역 Off
        /// 2 : 모든 유량 Off
        /// 3 : 모든 Detector( Electrometer, Filament, Bead Power Off)
        /// 4 : 저장된 Method 실행 -> 사용 안함 : 2020-12-22 정경훈 부장님 검토 사항
        /// 5 : Start 명령
        /// 6 : Oven 온도 설정 및 히터 가동
        /// 7 : 시스템 시작
        /// 8 : 시스템 슬립 모드
        /// 9 : Program End -> 프로그램의 끝은 반드시 Program End로 설정        /// 
        /// </summary>
        public TimeFunctions btFunction;

        public byte btPortNo;

        /// <summary>
        /// 설정값 (Oven 온도 설정 or Method No)
        /// </summary>
        public float fValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TimeControlSetup
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public _TimeProgram[] Prgm;
    }
}
