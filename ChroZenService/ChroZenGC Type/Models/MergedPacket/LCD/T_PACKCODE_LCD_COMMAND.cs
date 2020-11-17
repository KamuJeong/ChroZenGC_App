using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_PACKCODE_LCD_COMMAND
    {
        public T_HEADER_PACKET header;
        public T_LCD_COMMAND commandPacket;
    }
    public static class T_PACKCODE_LCD_COMMANDManager
    {
        static T_PACKCODE_LCD_COMMANDManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_PACKCODE_LCD_COMMAND InitiatedInstance;

        static T_PACKCODE_LCD_COMMAND GetInitializedInstance()
        {
            return new T_PACKCODE_LCD_COMMAND
            {
                header = T_HEADER_PACKETManager.InitiatedInstance,
                commandPacket = T_LCD_COMMANDManager.InitiatedInstance,
            };
        }

        public static byte[] MakePACKCODE_REQ(uint position, YC_Const.E_PACKCODE e_PACKCODE)
        {
            //요청 패킷
            T_HEADER_PACKET header = new T_HEADER_PACKET();
            header.nPacketCode = (uint)e_PACKCODE;
            header.nSlotSize = (uint)Marshal.SizeOf(T_LCD_COMMANDManager.InitiatedInstance);
            header.nEventIndex = position;
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_YL9000HPLC_PACKETManager.InitiatedInstance)
            header.nPacketLength = (uint)Marshal.SizeOf(T_HEADER_PACKETManager.InitiatedInstance);

            byte[] byteArr = YC_Type_Util.StructToByte(header);
            return byteArr;
        }

        public static byte[] MakePACKCODE_SET(T_LCD_COMMAND command, YC_Const.E_PACKCODE e_PACKCODE)
        {
            //설정 패킷
            T_PACKCODE_LCD_COMMAND packet = new T_PACKCODE_LCD_COMMAND();
            packet.header.nPacketCode = (uint)e_PACKCODE;
            packet.header.nSlotSize = (uint)Marshal.SizeOf(T_LCD_COMMANDManager.InitiatedInstance);
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_PACKCODE)
            packet.header.nPacketLength = (uint)Marshal.SizeOf(T_PACKCODE_LCD_COMMANDManager.InitiatedInstance);

            //요청 패킷의 경우 dataStruct를 채워서 전송
            packet.commandPacket = command;
            byte[] byteArr = YC_Type_Util.StructToByte(packet);
            return byteArr;
        }
    }
}
