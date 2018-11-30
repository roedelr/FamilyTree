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
    public class FamilyBackendTest
    {
        [TestMethod]
        public void Backend_FamilyBackend_Constructor_ShouldPass()
        {
            // Arrange
            var backend = new FamilyBackend();


            // Act
            
            // Reset

            // Assert
            Assert.IsNotNull(backend.MyFam, "constructor passed");
        }

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

        [TestMethod]
        public void Backend_FamilyBackend_GetMember_ShouldPass()
        {
            // Arrange
            var expect = new PersonModel();
            var backend = new FamilyBackend();
            backend.addMember(expect);

            // Act
            backend.getMember(0);
            PersonModel result = backend.MyFam.CurrentPerson;

            // Reset

            // Assert
            Assert.AreEqual(expect, result, "current person changed");
        }

        [TestMethod]
        public void Backend_FamilyBackend_UpdateMember_ShouldPass()
        {
            // Arrange
            var expect = new PersonModel();
            var backend = new FamilyBackend();
            backend.addMember(expect);
            expect.FirstName = "Joe"; // change expect to be updated

            // Act
            backend.getMember(0);
            backend.updateMember(expect);
            PersonModel result = backend.MyFam.CurrentPerson;

            // Reset

            // Assert
            Assert.AreEqual(expect, result, "person updated");
        }

        [TestMethod]
        public void Backend_FamilyBackend_RemoveMember_ShouldPass()
        {
            // Arrange
            var person = new PersonModel();
            var backend = new FamilyBackend();
            backend.addMember(person); // add first person
            person.FirstName = "Joe"; 
            backend.addMember(person); // add second
            var expect = person; // After removal, second will be first
                                 // which is what we'll test

            // Act
            backend.getMember(0);
            backend.removeMember();
            PersonModel result = backend.MyFam.PersonList.First();

            // Reset

            // Assert
            Assert.AreEqual(expect, result, "person removed");
        }
    }
}
