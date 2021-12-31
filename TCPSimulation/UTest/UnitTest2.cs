using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace UTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Add_Test()
        {
            DataProcessing dp = new DataProcessing();
            Assert.Equal(1, dp.addClients());
        }

        [TestMethod]
        public void Get_Test()
        {
            DataProcessing dp = new DataProcessing();
            Assert.Equal(1, dp.GetMessage());
        }

        [TestMethod]
        public void Broadcast_Test()
        {
            DataProcessing dp = new DataProcessing();
            Assert.Equal(1, dp.Broadcast());
        }
    }
}
