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
            
            //Act
            var result=commandController.RunCommand() as ViewResult;

            //Assert
            Assert.AreEqual("RunCommand", result.ViewName);

        }
       
    }
}
