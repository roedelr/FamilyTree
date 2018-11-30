using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree;
using FamilyTree.Controllers;
using FamilyTree.Models;

namespace FamilyTree.Tests.Controllers
{
    [TestClass]
    public class UserControlerUnitTest
    {
        [TestMethod]
        public void Controller_UserController_Index_Default_Should_Pass()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Controller_UserController_SignIn_Default_Should_Pass()
        {
            // Arrange
            UserController controller = new UserController();

            // Act

            ViewResult result = controller.SignIn() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Controller_UserController_SignIn_Post_Default_Should_Pass()
        {
            // Arrange
            UserController controller = new UserController();

            var data = new UserModel();

            // Act
            ViewResult result = controller.SignIn(data) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
