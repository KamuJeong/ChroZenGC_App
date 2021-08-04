using ChroZenGC.Core.Wrappers;
using ChroZenGC.Core.Packets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Tests
{
    [TestClass]
    public class ModelsTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ModelWrapperShouldNotifyChangedEvent()
        {
            StringBuilder callbackResult = new StringBuilder();
            var callback = new PropertyChangedEventHandler((s, e) => callbackResult.Append(e.PropertyName));

            var wrapper = new InformationWrapper();
            wrapper.PropertyChanged += callback;
            wrapper.Binary = new byte[Marshal.SizeOf<Information>()];

            Assert.AreEqual(callbackResult.ToString(), "Binary");
        }

        [TestMethod]
        public void CheckNetworkInformations()
        {
            const string base64 = "5QcHAAQAFgAQABwALAAAAMCoAFj///8AwKgAAQAAAAA0MjQyAAAAAAAAMjAxOC4wNy4wNgAxLjAuMTMwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEc2NzAwMTExMQAA";

            var wrapper = new InformationWrapper();
            wrapper.Binary = Convert.FromBase64String(base64);

            Assert.AreEqual("192.168.0.88", wrapper.IPAddress);
            Assert.AreEqual("255.255.255.0", wrapper.NetworkMask);
            Assert.AreEqual("192.168.0.1", wrapper.GateWay);
            Assert.AreEqual("4242", wrapper.SysConfig.cPortNo);
        }

        [TestMethod]
        public void ArrayWrapperShouldNotifyChangedEvent()
        {
            int[] arr = new int[] { 1, 2, 3 };

            StringBuilder callbackResult = new StringBuilder();
            var callback = new PropertyChangedEventHandler((s, e) => callbackResult.Append("changed"));

            ArrayWrapper<int> wrapper = new ArrayWrapper<int>(null, () => arr);
            wrapper.PropertyChanged += callback;

            wrapper[0] = 4;

            Assert.AreEqual("changed", callbackResult.ToString());
            Assert.AreEqual(4, arr[0]);
        }

        [TestMethod]
        public void CheckPropertyModifiedEventFromPacketWrapper()
        {
            StringBuilder callbackResult = new StringBuilder();
            var callback = new PropertyChangedEventHandler((s, e) => callbackResult.Append(e.PropertyName));

            var wrapper = new ConfigurationWrapper();
            wrapper.PropertyModified += callback;
            wrapper.Binary = new byte[Marshal.SizeOf<Configuration>()];
            wrapper.IsCryogenicInstalled = true;
            wrapper.IsAutosamplerInstalled = false;

            Assert.AreEqual("BinaryIsCryogenicInstalled", callbackResult.ToString());
        }

        [TestMethod]
        public void CheckPropertyModifiedEventFromSubPacketWrapper()
        {
            StringBuilder callbackResult = new StringBuilder();
            var callback = new PropertyChangedEventHandler((s, e) => callbackResult.Append(e.PropertyName));

            var wrapper = new ConfigurationWrapper();
            wrapper.PropertyModified += callback;
            wrapper.Binary = new byte[Marshal.SizeOf<Configuration>()];
            wrapper.ValveConfig.ValveCount = 4;

            Assert.AreEqual("Binary_ValveConfigWrapper>ValveCount", callbackResult.ToString());
        }

        [TestMethod]
        public void CheckPropertyModifiedEventFromArrayWrapper()
        {
            StringBuilder callbackResult = new StringBuilder();
            var callback = new PropertyChangedEventHandler((s, e) => callbackResult.Append(e.PropertyName));

            var wrapper = new ConfigurationWrapper();
            wrapper.PropertyModified += callback;
            wrapper.Binary = new byte[Marshal.SizeOf<Configuration>()];
            wrapper.ValveConfig.ValveType[0] = ValveTypes.LSV;

            Assert.AreEqual("Binary_ValveConfigWrapper>ArrayWrapper`1>", callbackResult.ToString());
        }

    }
}
