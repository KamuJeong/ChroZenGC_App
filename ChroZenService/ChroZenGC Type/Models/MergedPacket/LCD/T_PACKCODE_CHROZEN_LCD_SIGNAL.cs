using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public class T_PACKCODE_CHROZEN_LCD_SIGNAL
    {
        public T_HEADER_PACKET header;
        public T_LCD_SIGNAL_DATA packet;
    }
    public static class T_PACKCODE_CHROZEN_LCD_SIGNALManager
    {
        static T_PACKCODE_CHROZEN_LCD_SIGNALManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_PACKCODE_CHROZEN_LCD_SIGNAL InitiatedInstance;

        static T_PACKCODE_CHROZEN_LCD_SIGNAL GetInitializedInstance()
        {
            return new T_PACKCODE_CHROZEN_LCD_SIGNAL
            {
                header = T_HEADER_PACKETManager.InitiatedInstance,
                packet = T_LCD_SIGNAL_DATAManager.InitiatedInstance
            };
        }

        public static byte[] MakePACKCODE_REQ(uint position)
        {
            //요청 패킷
            T_HEADER_PACKET header = new T_HEADER_PACKET();
            header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_SIGNAL;
            header.nSlotSize = (uint)Marshal.SizeOf(T_LCD_SIGNAL_DATAManager.InitiatedInstance);
            header.nEventIndex = position;
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_YL9000HPLC_PACKETManager.InitiatedInstance)
            header.nPacketLength = (uint)Marshal.SizeOf(T_HEADER_PACKETManager.InitiatedInstance);

            byte[] byteArr = YC_Type_Util.StructToByte(header);
            return byteArr;
        }

        public static byte[] MakePACKCODE_SET(T_SYSTEM_LCD_Diag dataStruct)
        {
            //설정 패킷
            T_PACKCODE_CHROZEN_LCD_DIAG packet = new T_PACKCODE_CHROZEN_LCD_DIAG();
            packet.header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_SIGNAL;
            packet.header.nSlotSize = (uint)Marshal.SizeOf(T_LCD_SIGNAL_DATAManager.InitiatedInstance);
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_PACKCODE)
            packet.header.nPacketLength = (uint)Marshal.SizeOf(T_PACKCODE_CHROZEN_LCD_SIGNALManager.InitiatedInstance);

            //요청 패킷의 경우 dataStruct를 채워서 전송
            packet.packet = dataStruct;

            byte[] byteArr = YC_Type_Util.StructToByte(packet);
            return byteArr;
        }
    }
}
