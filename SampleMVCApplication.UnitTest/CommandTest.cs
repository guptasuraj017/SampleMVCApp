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
            var psObject = new CommandRepo();
            var commandObj = new Command();

            //Act
            var outputPsObjectCollection = psObject.RunCmdlets(commandObj);

            //Assert
            Assert.AreEqual("Add-AppPackage", outputPsObjectCollection[0].BaseObject.ToString());
        }
    }
}
