using ADFSDPhamaV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;

namespace UnitTestFSDPha
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestGoodLogin()
        {

            ADFSDPhamaV2.Admin_User usr = new ADFSDPhamaV2.Admin_User();
            Assert.AreEqual(true,("wu@gmail.com","123","Admin"),"should be a good user");

        }

    }
}
