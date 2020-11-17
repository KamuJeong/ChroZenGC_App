using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public struct T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ : I_CHROZEN_GC_PACKET
    {
        public T_HEADER_PACKET header;
        public T_YL6700GC_APC_Calib_Read packet;
    }
    public static class T_PACKCODE_CHROZEN_LCD_APC_CALIB_READManager
    {
        static T_PACKCODE_CHROZEN_LCD_APC_CALIB_READManager()
        {
            InitiatedInstance = GetInitializedInstance();
        }
        public static T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ InitiatedInstance;

        static T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ GetInitializedInstance()
        {
            return new T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ
            {
                header = T_HEADER_PACKETManager.InitiatedInstance,
                packet = T_YL6700GC_APC_Calib_ReadManager.InitiatedInstance
            };
        }

        public static byte[] MakePACKCODE_REQ(uint position)
        {
            //요청 패킷
            T_HEADER_PACKET header = new T_HEADER_PACKET();
            header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ;
            header.nSlotSize = (uint)Marshal.SizeOf(T_YL6700GC_APC_Calib_ReadManager.InitiatedInstance);
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_YL9000HPLC_PACKETManager.InitiatedInstance)
            header.nPacketLength = (uint)Marshal.SizeOf(T_HEADER_PACKETManager.InitiatedInstance);

            byte[] byteArr = YC_Type_Util.StructToByte(header);
            return byteArr;
        }

        public static byte[] MakePACKCODE_SET(T_YL6700GC_APC_Calib_Read dataStruct)
        {
            //설정 패킷
            T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ packet = new T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ();
            packet.header.nPacketCode = (uint)YC_Const.E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ;
            packet.header.nSlotSize = (uint)Marshal.SizeOf(T_YL6700GC_APC_Calib_ReadManager.InitiatedInstance);
            //요청 패킷의 경우 nPacketLengt = SizeOf(T_PACKCODE)
            packet.header.nPacketLength = (uint)Marshal.SizeOf(T_PACKCODE_CHROZEN_LCD_APC_CALIB_READManager.InitiatedInstance);

            //요청 패킷의 경우 dataStruct를 채워서 전송
            packet.packet = dataStruct;

            byte[] byteArr = YC_Type_Util.StructToByte(packet);
            return byteArr;
        }
    }
}
