using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct T_PACKCODE_CHROZEN_SLFEMSG : I_CHROZEN_GC_PACKET
    {
        public T_HEADER_PACKET header;
        public T_CHROZEN_GC_SELFMSG packet;
    }
    public static class T_PACKCODE_CHROZEN_SLFEMSGManager
    {
        static T_PACKCODE_CHROZEN_SLFEMSGManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_PACKCODE_CHROZEN_SLFEMSG InitiatedInstance;

        static T_PACKCODE_CHROZEN_SLFEMSG GetInitializedInstance()
        {
            return new T_PACKCODE_CHROZEN_SLFEMSG
            {
                header = T_HEADER_PACKETManager.InitiatedInstance,
                packet = T_CHROZEN_GC_SELFMSGManager.InitiatedInstance
            };
        }

        public static byte[] MakePACKCODE_REQ()
        {
            //요청 패킷
            T_HEADER_PACKET header = new T_HEADER_PACKET();
            header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_YL6200_SLFEMSG;
            header.nSlotSize = (uint)Marshal.SizeOf(T_CHROZEN_GC_SELFMSGManager.InitiatedInstance);

            //요청 패킷의 경우 nPacketLengt = SizeOf(T_YL9000HPLC_PACKETManager.InitiatedInstance)
            header.nPacketLength = (uint)Marshal.SizeOf(T_HEADER_PACKETManager.InitiatedInstance);

            byte[] byteArr = YC_Type_Util.StructToByte(header);
            return byteArr;
        }

        public static byte[] MakePACKCODE_SET(T_CHROZEN_GC_SELFMSG dataStruct)
        {
            //설정 패킷
            T_PACKCODE_CHROZEN_SLFEMSG packet = new T_PACKCODE_CHROZEN_SLFEMSG();
            packet.header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_YL6200_SLFEMSG;
            packet.header.nSlotSize = (uint)Marshal.SizeOf(T_CHROZEN_GC_SELFMSGManager.InitiatedInstance);

            //요청 패킷의 경우 nPacketLengt = SizeOf(T_PACKCODE)
            packet.header.nPacketLength = (uint)Marshal.SizeOf(T_PACKCODE_CHROZEN_SLFEMSGManager.InitiatedInstance);

            //요청 패킷의 경우 dataStruct를 채워서 전송
            packet.packet = dataStruct;

            byte[] byteArr = YC_Type_Util.StructToByte(packet);
            return byteArr;
        }
    }
}
