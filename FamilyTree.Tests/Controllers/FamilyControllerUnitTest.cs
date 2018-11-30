using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree;
using FamilyTree.Controllers;
using FamilyTree.Models;
using FamilyTree.Models.Enums;

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
        public void Conroller_FamilyController_Create_Default_Should_Pass()
        {
            //Arrange
            FamilyController controller = new FamilyController();

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Conroller_FamilyController_Create_Post_Default_Should_Pass()
        {
            //Arrange
            FamilyController controller = new FamilyController();

            var data = new PersonModel();

            var result = (RedirectToRouteResult)controller.Update(data);

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void Conroller_FamilyController_Create_Post_Invalid_Default_Should_Fail()
        {
            //Arrange
            FamilyController controller = new FamilyController();

            var data = new PersonModel();
            data.FirstName = null;

            var result = (RedirectToRouteResult)controller.Create(data);

            Assert.AreEqual("Error", result.RouteValues["action"]);

            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void Conroller_FamilyController_Create_Post_Invalid_Model_Should_Fail()
        {
            //Arrange
            FamilyController controller = new FamilyController();

            controller.ModelState.AddModelError("fakeError", "fakeError");

            var data = new PersonModel();

            data.FirstName = null;

            ViewResult result = controller.Create(data) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        //[TestMethod]
        //public void Controller_FamilyController_Update_Default_Should_Pass()
        //{
        //    // Arrange
        //    FamilyController controller = new FamilyController();

        //    // Act
        //    // FixME: parameter chosen at random for Update(int ID)
        //    ViewResult result = controller.Update(0) as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void Controller_FamilyController_Update_Post_Default_Should_Pass()
        {
            // Arrange
            FamilyController controller = new FamilyController();

            var data = new PersonModel();

            var result = (RedirectToRouteResult)controller.Update(data);

            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        
    }
}
