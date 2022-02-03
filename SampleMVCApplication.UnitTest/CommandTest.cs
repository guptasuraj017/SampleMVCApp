using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVCApplication.UnitTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void CommandMethodTest()
        {
            //Arrange
            var psObject = new Command();

            //Act
            var outputPsObject= psObject.RunCmdlets("Get-Command","Add-AppPackage");

            //Assert
            Assert.AreEqual("Add-AppPackage", outputPsObject.BaseObject.ToString());
        }
    }
}
