using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree;
using FamilyTree.Models;
using FamilyTree.Models.Enums;

namespace FamilyTree.Tests.Enums
{
    [TestClass]
    public class RelationshipEnumUnitTests
    {
        [TestMethod]
        public void Enums_RelationshipEnum_Default_ShouldPass()
        {
            // Arrange

            // Act
  
            // Reset

            // Assert

            // Pin test, make sure the values are exactly what is expected
            Assert.AreEqual(1, (int)RelationEnum.Brother, "");
            Assert.AreEqual(2, (int)RelationEnum.Father, "");
            Assert.AreEqual(3, (int)RelationEnum.Mother, "");
            Assert.AreEqual(4, (int)RelationEnum.Self, "");
            Assert.AreEqual(5, (int)RelationEnum.Sister, "");
        }

        [TestMethod]
        public void Enum_RelationshipEnum_Number_ShouldPass()
        {
            // Arrange

            // Act

            // Reset

            // Assert

            // Pin the Number of Items in the Enum
            Assert.AreEqual(5, System.Enum.GetNames(typeof(RelationEnum)).Length, "");
            ;
        }
    }
}
