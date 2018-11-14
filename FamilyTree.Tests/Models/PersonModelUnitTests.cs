using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree;
using FamilyTree.Models;
using FamilyTree.Models.Enums;

namespace FamilyTree.Tests.Models
{
    [TestClass]
    public class PersonModelUnitTests
    {
        [TestMethod]
        public void Model_PersonModel_Constructors_Default_ShouldPass()
        {
            // Arrange
            var expect_FirstName = "Bob";

            // Act
            var result = new PersonModel();


            // Reset

            // Assert
            Assert.IsNotNull(result, "default constructor");
            Assert.AreEqual(expect_FirstName, result.FirstName, "constructors match");

        }

        [TestMethod]
        public void Model_PersonModel_Constructors_With_Data_ShouldPass()
        {
            // Arrange
            var expect_FirstName = "Mike";

            // Act
            var result = new PersonModel("Mike", "Roedel",
                                                 new DateTime(1960, 1, 1),
                                                 RelationEnum.Father);
            // Reset

            // Assert
            Assert.IsNotNull(result, "default constructor");
            Assert.AreEqual(expect_FirstName, result.FirstName, "constructors match");

        }


        [TestMethod]
        public void Model_PersonModel_Get_Set_ShouldPass()
        {
            // Arrange
            var expect_FirstName = "First";
            var expect_LastName = "Last";
            var expect_DOB = new DateTime(2018, 1, 1);
            var expect_IsToMe = RelationEnum.Mother;


            // Act
            var result = new PersonModel();
            result.FirstName = expect_FirstName;
            result.LastName = expect_LastName;
            result.IsToMe = expect_IsToMe;
            result.DOB = expect_DOB;

            // Reset

            // Assert
            Assert.AreEqual(expect_FirstName, result.FirstName, "");
            Assert.AreEqual(expect_LastName, result.LastName, "");
            Assert.AreEqual(expect_DOB, result.DOB, "");
            Assert.AreEqual(expect_IsToMe, result.IsToMe, "");

        }
    }
}
