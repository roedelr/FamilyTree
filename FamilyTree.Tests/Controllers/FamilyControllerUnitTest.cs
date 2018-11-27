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
    public class FamilyControllerUnitTests
    {
        [TestMethod]
        public void Controller_FamilyController_Index_Default_Should_Pass()
        {
            // Arrange
            FamilyController controller = new FamilyController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Controller_FamilyController_Update_Default_Should_Pass()
        {
            // Arrange
            FamilyController controller = new FamilyController();

            // Act
            ViewResult result = controller.Update() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Controller_FamilyController_Update_Post_Default_Should_Pass()
        {
            // Arrange
            FamilyController controller = new FamilyController();

            var data = new PersonModel();
           
            // Act
            ViewResult result = controller.Update(data) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Conroller_FamilyController_Create_Default_Should_Pass()
        {
            //Arrange
            FamilyController controller = new FamilyController();

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
