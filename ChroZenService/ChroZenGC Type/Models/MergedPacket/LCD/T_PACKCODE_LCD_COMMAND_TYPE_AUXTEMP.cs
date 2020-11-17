using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP : I_CHROZEN_GC_PACKET
    {
        public T_HEADER_PACKET header;
        public T_TEMP_CALIBRATION tempPacket;
    }
    public static class T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMPManager
    {
        static T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMPManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP InitiatedInstance;

        static T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP GetInitializedInstance()
        {
            return new T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP
            {
                header = T_HEADER_PACKETManager.InitiatedInstance,
                tempPacket = T_TEMP_CALIBRATIONManager.InitiatedInstance
            };
        }

        public static byte[] MakePACKCODE_REQ(uint position)
        {
            //요청 패킷
            T_HEADER_PACKET header = new T_HEADER_PACKET();
            header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP;
            header.nSlotSize = (uint)Marshal.SizeOf(T_TEMP_CALIBRATIONManager.InitiatedInstance);
            header.nEventIndex = position;
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_YL9000HPLC_PACKETManager.InitiatedInstance)
            header.nPacketLength = (uint)Marshal.SizeOf(T_HEADER_PACKETManager.InitiatedInstance);

            byte[] byteArr = YC_Type_Util.StructToByte(header);
            return byteArr;
        }

        public static byte[] MakePACKCODE_SET(T_TEMP_CALIBRATION temp)
        {
            //설정 패킷
            T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP packet = new T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP();
            packet.header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP;
            packet.header.nSlotSize = (uint)Marshal.SizeOf(T_TEMP_CALIBRATIONManager.InitiatedInstance);
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_PACKCODE)
            packet.header.nPacketLength = (uint)Marshal.SizeOf(T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMPManager.InitiatedInstance);

            //요청 패킷의 경우 dataStruct를 채워서 전송
            packet.tempPacket = temp;

            byte[] byteArr = YC_Type_Util.StructToByte(packet);
            return byteArr;
        }
    }
}
