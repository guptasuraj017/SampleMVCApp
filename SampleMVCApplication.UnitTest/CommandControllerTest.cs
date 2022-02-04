using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleMVCApp.Controllers;
using System.Web.Mvc;

namespace SampleMVCApplication.UnitTest
{
    [TestClass]
    public class CommandControllerTest
    {
        [TestMethod]
        public void RunCommandTest()
        {
            //Arrange
            var commandController = new CommandController();
            var commandObj = new Command();
            //Act
            var result = commandController.RunCommand(commandObj) as JsonResult ;

            //Assert
            Assert.AreEqual("RunCommand", result.Data);

        }

    }
}
