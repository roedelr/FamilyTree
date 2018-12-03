using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree.Models;
using FamilyTree.Backend;

namespace FamilyTree.Tests.Backend
{
    [TestClass]
    public class SettingsDataSourceMockUnitTests
    {
        public TestContext TestContext { get; set; }

        #region Instantiate
        [TestMethod]
        public void Backend_SettingsDataSourceMock_Default_Instantiate_Should_Pass()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;

            //var expect = backend;

            // Act
            var result = backend;

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion Instantiate

        #region read
        [TestMethod]
        public void Backend_SettingsDataSourceMock_Read_Invalid_ID_Null_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;

            // Act
            var result = backend.Read(null);

            // Assert
            Assert.IsNull(result, TestContext.TestName);
        }

        //[TestMethod]
        //public void Backend_SettingsDataSourceMock_Read_valid_Data_Should_Pass()
        //{
        //    // Arrange
        //    var backend = SettingsDataSourceMock.Instance;
        //    var tempBackend = SettingsBackend.Instance;

        //    // Act
        //    var result = backend.Read(tempBackend.GetDefault().Id);

        //    //reset
        //    backend.Reset();
        //    tempBackend.Reset();

        //    // Assert
        //    Assert.IsNotNull(result, TestContext.TestName);
        //}
        #endregion read

        #region update
        [TestMethod]
        public void Backend_SettingsDataSourceMock_Update_Invalid_ID_Null_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;

            // Act
            var result = backend.Update(null);

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsDataSourceMock_Update_Invalid_Data_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;
            var testModel = new SettingsModel();

            // Act
            var result = backend.Update(testModel);

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNull(result, TestContext.TestName);
        }

        //[TestMethod]
        //public void Backend_SettingsDataSourceMock_Update_valid_Data_Should_Pass()
        //{
        //    // Arrange
        //    var backend = SettingsDataSourceMock.Instance;
        //    var testBackend = SettingsBackend.Instance;
        //    var testDefault = testBackend.GetDefault();
        //    var expectId = "GoodID";
        //    var expectPassword = "passWORD23!";

        //    // Act
        //    testDefault.Id = expectId;
        //    testDefault.Password = expectPassword;

        //    var resultUpdate = backend.Update(testDefault);

        //    var resultId = testDefault.Id;
        //    var resultPassword = testDefault.Password;

        //    //Reset
        //    backend.Reset();
        //    testBackend.Reset();

        //    // Assert
        //    Assert.IsNotNull(resultUpdate, TestContext.TestName);
        //    Assert.AreEqual(expectId, resultId, TestContext.TestName);
        //    Assert.AreEqual(expectPassword, resultPassword, TestContext.TestName);
        //}
        #endregion update

        #region delete
        [TestMethod]
        public void Backend_SettingsDataSourceMock_Delete_Invalid_ID_Null_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;

            // Act
            var result = backend.Delete(null);

            //Reset
            backend.Reset();

            // Assert
            Assert.IsFalse(result, TestContext.TestName);
        }

        //[TestMethod]
        //public void Backend_SettingsDataSourceMock_Delete_Valid_ID_Should_Pass()
        //{
        //    // Arrange
        //    var backend = SettingsDataSourceMock.Instance;
        //    var mySettingsBackend = SettingsBackend.Instance;
        //    var testDefault = SettingsBackend.GetDefault();
        //    var expectId = testDefault.Id;

        //    // Act
        //    var result = backend.Delete(expectId);

        //    //Reset
        //    backend.Reset();
        //    SettingsBackend.Reset();

        //    // Assert
        //    Assert.IsTrue(result, TestContext.TestName);
        //}
        #endregion delete

        #region DataSet
        [TestMethod]
        public void Backend_SettingsDataSourceMock_LoadDataSet_Demo_Data_Should_Pass()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;
            var expectEnum = FamilyTree.Models.DataSourceDataSetEnum.Demo;

            // Act
            backend.LoadDataSet(expectEnum);
            var result = backend;

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsDataSourceMock_LoadDataSet_UnitTest_Data_Should_Pass()
        {
            // Arrange
            var backend = SettingsDataSourceMock.Instance;
            var expectEnum = FamilyTree.Models.DataSourceDataSetEnum.UnitTest;

            // Act
            backend.LoadDataSet(expectEnum);
            var result = backend;

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion DataSet
    }
}
