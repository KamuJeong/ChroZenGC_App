using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class InformationWrapper : PacketWrapper<Information>
    {
        public const uint PacketCode = 0x67100;

        public override uint Code => PacketCode;


        public string Model => "ChroZen GC";

        public string Version
        {
            get => Packet.InstInfo.InstVersion;
            set => Packet.InstInfo.InstVersion = value;
        }

        public string SerialNumber
        {
            get => Packet.InstInfo.InstSerialNo;
            set => Packet.InstInfo.InstSerialNo = value;
        }

        public string InstallDate
        {
            get => Packet.InstInfo.InstDate;
            set => Packet.InstInfo.InstDate = value;
        }

        public TimeSpan TimeDiffernece { get; set; }

        public string Date { get; private set; }

        public string Time { get; private set; }

        public string IPAddress
        {
            get => string.Format("{0}.{1}.{2}.{3}",
                    Packet.SysConfig.cIPAddress[0], Packet.SysConfig.cIPAddress[1],
                    Packet.SysConfig.cIPAddress[2], Packet.SysConfig.cIPAddress[3]);
            set
            {
                var ip = value.Split('.');
                if (ip.Length != 4)
                    throw new ArgumentException("IPAddress");

                for (int i = 0; i < 4; ++i)
                {
                    int v = int.Parse(ip[i]);
                    if (v < 0 || v > 254)
                        throw new ArgumentException("IPAddress");

                    Packet.SysConfig.cIPAddress[i] = (byte)v;
                }

                if (Packet.SysConfig.cIPAddress[3] == 0)
                    throw new ArgumentException("IPAddress");
            }
        }

        public string NetworkMask
        {
            get => string.Format("{0}.{1}.{2}.{3}",
                    Packet.SysConfig.cIPAddress[4], Packet.SysConfig.cIPAddress[5],
                    Packet.SysConfig.cIPAddress[6], Packet.SysConfig.cIPAddress[7]);
            set
            {
                var ip = value.Split('.');
                if (ip.Length != 4)
                    throw new ArgumentException("NetworkMask");

                for (int i = 0; i < 4; ++i)
                {
                    int v = int.Parse(ip[i]);
                    if (v < 0 || v > 255)
                        throw new ArgumentException("NetworkMask");

                    Packet.SysConfig.cIPAddress[i + 4] = (byte)v;
                }

                bool zero = false;
                for (int j = 4; j < 8; ++j)
                    for (int i = 7; i >= 0; --i)
                    {
                        if ((Packet.SysConfig.cIPAddress[j] & (byte)(0x1 << i)) != 0)
                        {
                            if (zero)
                            {
                                throw new ArgumentException("NetworkMask");
                            }
                        }
                        else
                        {
                            zero = true;
                        }
                    }
            }
        }

        public string GateWay
        {
            get => Packet.SysConfig.cIPAddress[8] == 0 ? "" :
                    string.Format("{0}.{1}.{2}.{3}",
                    Packet.SysConfig.cIPAddress[8], Packet.SysConfig.cIPAddress[9],
                    Packet.SysConfig.cIPAddress[10], Packet.SysConfig.cIPAddress[11]);

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    for (int i = 8; i < 12; ++i)
                        Packet.SysConfig.cIPAddress[i] = 0;
                }

                var ip = value.Split('.');
                if (ip.Length != 4)
                    throw new ArgumentException("GateWay");

                for (int i = 0; i < 4; ++i)
                {
                    int v = int.Parse(ip[i]);
                    if (v < 0 || v > 254)
                        throw new ArgumentException("GateWay");

                    Packet.SysConfig.cIPAddress[i + 8] = (byte)v;
                }

                if (Packet.SysConfig.cIPAddress[3] == 0)
                    throw new ArgumentException("GateWay");
            }
        }

        public InformationWrapper()
        {
            Packet.SysConfig.cIPAddress = new byte[16];
            Packet.InstInfo.InstVersion = "1.0.0";
        }

        protected override void OnPrePropertyModified(object sender, PropertyModifiedEventArgs args)
        {
            base.OnPrePropertyModified(sender, args);

            if(args.PropertyName == "Binary")
            {
                DateTime dt = new DateTime(Packet.SysConfig.SysTime.wYear, Packet.SysConfig.SysTime.wMonth, Packet.SysConfig.SysTime.wDay,
                                            Packet.SysConfig.SysTime.wHour, Packet.SysConfig.SysTime.wMinute, Packet.SysConfig.SysTime.wSecond);
                TimeDiffernece = DateTime.Now - dt;
            }
        }

        public void UpdateDateTime()
        {
            var current = DateTime.Now - TimeDiffernece;
            Date = current.ToShortDateString();
            Time = current.ToString("T");
        }
    }
}
