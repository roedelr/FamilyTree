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
    public class SettingsDataSourceTableUnitTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void Initialize()
        {
            DataSourceBackend.SetTestingMode(true);
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
        }

        [TestCleanup]
        public void Cleanup()
        {
            DataSourceBackend.SetTestingMode(false);
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);
        }

        #region Instantiate
        [TestMethod]
        public void Backend_SettingsDataSourceTable_Default_Instantiate_Should_Pass()
        {
            // Arrange

            // Act
            var result = SettingsDataSourceTable.Instance;

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion Instantiate

        #region read
        [TestMethod]
        public void Backend_SettingsDataSourceTable_Read_Invalid_ID_Null_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceTable.Instance;

            // Act
            var result = backend.Read(null);

            // Assert
            Assert.IsNull(result, TestContext.TestName);
        }

        //[TestMethod]
        //public void Backend_SettingsDataSourceTable_Read_valid_Data_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    var result = SettingsDataSourceTable.Instance.Read();

        //    //reset
        //    SettingsDataSourceTable.Instance.Reset();

        //    // Assert
        //    Assert.IsNotNull(result, TestContext.TestName);
        //}
        #endregion read

        #region update
        [TestMethod]
        public void Backend_SettingsDataSourceTable_Update_Invalid_ID_Null_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceTable.Instance;

            // Act
            var result = backend.Update(null);

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsDataSourceTable_Update_Invalid_Data_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceTable.Instance;
            var testModel = new SettingsModel();

            // Act
            var result = backend.Update(testModel);

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsNull(result, TestContext.TestName);
        }

        //[TestMethod]
        //public void Backend_SettingsDataSourceTable_Update_valid_Data_Should_Pass()
        //{
        //    // Arrange
        //    var backend = SettingsDataSourceTable.Instance;
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
        //    SettingsDataSourceTable.Instance.Reset();
        //    testSettingsDataSourceTable.Instance.Reset();

        //    // Assert
        //    Assert.IsNotNull(resultUpdate, TestContext.TestName);
        //    Assert.AreEqual(expectId, resultId, TestContext.TestName);
        //    Assert.AreEqual(expectPassword, resultPassword, TestContext.TestName);
        //}
        #endregion update

        #region delete
        [TestMethod]
        public void Backend_SettingsDataSourceTable_Delete_Invalid_ID_Null_Should_Fail()
        {
            // Arrange
            var backend = SettingsDataSourceTable.Instance;

            // Act
            var result = backend.Delete(null);

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsFalse(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsDataSourceTable_Delete_Valid_ID_Should_Pass()
        {
            // Arrange
            var backend = SettingsDataSourceTable.Instance;
            var testDefault = SettingsBackend.Instance.GetDefault();
            var expectId = testDefault.Id;

            // Act
            var result = backend.Delete(expectId);

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsTrue(result, TestContext.TestName);
        }
        #endregion delete

        #region DataSet
        [TestMethod]
        public void Backend_SettingsDataSourceTable_LoadDataSet_Demo_Data_Should_Pass()
        {
            // Arrange
            var backend = SettingsDataSourceTable.Instance;
            var expectEnum = FamilyTree.Models.DataSourceDataSetEnum.Demo;

            // Act
            backend.LoadDataSet(expectEnum);
            var result = backend;

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsDataSourceTable_LoadDataSet_UnitTest_Data_Should_Pass()
        {
            // Arrange
            var expectEnum = FamilyTree.Models.DataSourceDataSetEnum.UnitTest;

            // Act
            SettingsDataSourceTable.Instance.LoadDataSet(expectEnum);
            var result = SettingsDataSourceTable.Instance;

            //Reset
            SettingsDataSourceTable.Instance.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        //[TestMethod]
        //public void Backend_SettingsDataSourceTable_Delete_Invalid_ID_Bogus_Should_Fail()
        //{
        //    Arrange
        //   var expectStudent = DataSourceBackend.Instance
        //    var expect = false;

        //    Act
        //   var result = SettingsDataSourceTable.Instance.Delete("bogus");

        //    reset
        //    DataSourceBackend.Instance.Reset();

        //    Assert
        //    Assert.AreEqual(expect, result, TestContext.TestName);
        //}
        #endregion DataSet
    }
}
