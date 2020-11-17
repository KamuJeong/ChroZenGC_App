using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_PACKCODE_LCD_COMMAND_TYPE_INLET : I_CHROZEN_GC_PACKET
    {
        public T_HEADER_PACKET header;
        public T_YL6700GC_APC_INLET_Calib_Write inletPacket;
    }
    public static class T_PACKCODE_LCD_COMMAND_TYPE_INLETManager
    {
        static T_PACKCODE_LCD_COMMAND_TYPE_INLETManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_PACKCODE_LCD_COMMAND_TYPE_INLET InitiatedInstance;

        static T_PACKCODE_LCD_COMMAND_TYPE_INLET GetInitializedInstance()
        {
            return new T_PACKCODE_LCD_COMMAND_TYPE_INLET
            {
                header = T_HEADER_PACKETManager.InitiatedInstance,
                inletPacket = T_YL6700GC_APC_INLET_Calib_WriteManager.InitiatedInstance
            };
        }

        public static byte[] MakePACKCODE_REQ(uint position)
        {
            //요청 패킷
            T_HEADER_PACKET header = new T_HEADER_PACKET();
            header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET;
            header.nSlotSize = (uint)Marshal.SizeOf(T_YL6700GC_APC_INLET_Calib_WriteManager.InitiatedInstance);
            header.nEventIndex = position;
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_YL9000HPLC_PACKETManager.InitiatedInstance)
            header.nPacketLength = (uint)Marshal.SizeOf(T_HEADER_PACKETManager.InitiatedInstance);

            byte[] byteArr = YC_Type_Util.StructToByte(header);
            return byteArr;
        }

        public static byte[] MakePACKCODE_SET(T_YL6700GC_APC_INLET_Calib_Write inlet, uint nEventIndex)
        {
            //설정 패킷
            T_PACKCODE_LCD_COMMAND_TYPE_INLET packet = new T_PACKCODE_LCD_COMMAND_TYPE_INLET();
            packet.header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET;
            packet.header.nSlotSize = (uint)Marshal.SizeOf(T_YL6700GC_APC_INLET_Calib_WriteManager.InitiatedInstance);
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_PACKCODE)
            packet.header.nPacketLength = (uint)Marshal.SizeOf(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.InitiatedInstance);
            packet.header.nEventIndex = nEventIndex;
            //요청 패킷의 경우 dataStruct를 채워서 전송
            packet.inletPacket = inlet;

            byte[] byteArr = YC_Type_Util.StructToByte(packet);
            return byteArr;
        }
    }
}
