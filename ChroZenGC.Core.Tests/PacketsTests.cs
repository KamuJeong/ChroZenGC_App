using ChroZenGC.Core.Network;
using ChroZenGC.Core.Packets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace ChroZenGC.Core.Tests
{
    [TestClass]
    public class PacketsTests
    {
        static T Cast<T>(byte[] buffer) where T : struct
        {
            int nSize = Marshal.SizeOf(typeof(T));

            if (nSize != buffer.Length)
            {
                throw new ArgumentException(nameof(buffer));
            }

            IntPtr ptr = Marshal.AllocHGlobal(nSize);
            Marshal.Copy(buffer, 0, ptr, nSize);
            T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);

            return obj;
        }

        static byte[] ToBytes<T>(T t) where T : struct
        {
            int nSize = Marshal.SizeOf(typeof(T));
            byte[] arr = new byte[nSize];
            IntPtr ptr = Marshal.AllocHGlobal(nSize);

            Marshal.StructureToPtr(t, ptr, false);
            Marshal.Copy(ptr, arr, 0, nSize);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }


        [TestMethod]
        public void LengthOfInformationPacketShouldBe96Bytes()
        {
            int expected = 96;

            Assert.AreEqual(expected, Marshal.SizeOf<Information>());
        }

        [TestMethod]
        public void InformationShouldBeInterchangableWithBytes()
        {


            const string base64 = "5QcHAAQAFgAMABoAGgAAAAAAAAAAAAAAAAAAAAAAAAA0MjQyAAAAAAAAMjAxOC4wNy4wNgAxLjAuMTMwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEc2NzAwMTExMQAA";

            byte[] arr = Convert.FromBase64String(base64);
            Information packet = Cast<Information>(arr);

            Assert.AreEqual("1.0.130", packet.InstInfo.InstVersion);
            Assert.AreEqual("4242", packet.SysConfig.cPortNo);

            string expected = Convert.ToBase64String(ToBytes(packet));

            Assert.AreEqual(expected, base64);
        }

        [TestMethod]
        public void LengthOfConfigurationPacketShouldBe140Bytes()
        {
            int expected = 140;

            Assert.AreEqual(expected, Marshal.SizeOf<Configuration>());
        }

        [TestMethod]
        public void ConfigurationShouldBeInterchangableWithBytes()
        {
            const string base64 = "AAEAAQAAAQIAAQEBAAEBAQEBAQEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
            byte[] arr = Convert.FromBase64String(base64);
            Configuration packet = Cast<Configuration>(arr);

            Assert.AreEqual(InletTypes.Capillary, packet.btInlet[0]);
            Assert.AreEqual(DetectorTypes.FID, packet.btDet[0]);
            Assert.AreEqual(DetectorTypes.TCD, packet.btDet[1]);

            string expected = Convert.ToBase64String(ToBytes(packet));

            Assert.AreEqual(expected, base64);
        }

        [TestMethod]
        public void LengthOfStatePacketShouldBe320Bytes()
        {
            int expected = 320;

            Assert.AreEqual(expected, Marshal.SizeOf<State>());
        }

        [TestMethod]
        public void StateShouldBeInterchangableWithBytes()
        {
            const string base64 = "AQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgD8AAABAAABAQAAAgEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAEAAAAAAAAAAAAAAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABIAAAASAAAACQAAAAkAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";

            byte[] arr = Convert.FromBase64String(base64);
            State packet = Cast<State>(arr);

            Assert.AreEqual(Modes.Ready, packet.btState);
            Assert.AreEqual(TemperatureFlags.Inlet1 | TemperatureFlags.Detector1, packet.TempReady);
            Assert.AreEqual(TemperatureFlags.Inlet1 | TemperatureFlags.Detector1, packet.TempOnoff);
            Assert.AreEqual(FlowFlags.ColumnFlow1 | FlowFlags.FrontDetectorFlow1, packet.FlowReady);
            Assert.AreEqual(FlowFlags.ColumnFlow1 | FlowFlags.FrontDetectorFlow1, packet.FlowOnoff);
            Assert.AreEqual(1.0f, packet.ActFlow.Disp_FrontInjFlow[0]);
            Assert.AreEqual(2.0f, packet.ActFlow.Disp_FrontInjFlow[1]);
            Assert.AreEqual(3.0f, packet.ActFlow.Disp_FrontInjFlow[2]);
            Assert.AreEqual(4.0f, packet.ActFlow.Disp_FrontInjFlow[3]);

            string expected = Convert.ToBase64String(ToBytes(packet));

            Assert.AreEqual(expected, base64);
        }

    }
}
