using ADFSDPhamaV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;

namespace UnitTestFSDPha
{
    [TestClass]
    public class UnitTest2
    {
        

        [TestMethod]
        public void EqualsTest()
        {
           int a = 1;
           int b = a+1;
            Assert.AreEqual(2, b);
        }

    }
}
