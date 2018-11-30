using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree;
using FamilyTree.Backend;
using FamilyTree.Models;

namespace FamilyTree.Tests.Backend
{
    [TestClass]
    class FamilyBackendTest
    {
        [TestMethod]
        public void Backend_FamilyBackend_AddMember_ShouldPass()
        {
            // Arrange
            var expect = new PersonModel();
            var backend = new FamilyBackend();
            

            // Act
            backend.addMember(expect);
            PersonModel result = backend.MyFam.PersonList.First();

            // Reset

            // Assert
            Assert.AreEqual(expect, result, "person added");

        }
    }
}
