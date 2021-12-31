using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Client;

namespace UTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Check_Test()
        {
            CheckMessage cm = new CheckMessage();
            Assert.Equal(1, cm.Check());
        }
    }

    [TestMethod]
    public void Main_Test()
    {
        Main m = new Main();
        Assert.Equal(1, m.Main());
    }
}
