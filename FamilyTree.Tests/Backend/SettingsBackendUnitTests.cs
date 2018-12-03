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
    public class SettingsBackendUnitTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DataSourceBackend.SetTestingMode(true);
        }

        #region Instantiate
        [TestMethod]
        public void Backend_SettingsBackend_Default_Instantiate_Should_Pass()
        {
            //arrange
            var backend = SettingsBackend.Instance;

            //act
            var result = backend;

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion Instantiate

        #region read
        [TestMethod]
        public void Backend_SettingsBackend_Read_Invalid_ID_Null_Should_Fail()
        {
            //arrange
            var backend = SettingsBackend.Instance;

            //act
            var result = backend.Read(null);

            //assert
            Assert.IsNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsBackend_Read_Valid_ID_Should_Pass()
        {
            //arrange
            var backend = SettingsBackend.Instance;
            var defaultValue = backend.GetDefault();

            //act
            var result = backend.Read(defaultValue.Id);

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion read

        #region update
        [TestMethod]
        public void Backend_SettingsBackend_Update_Invalid_Data_Null_Should_Fail()
        {
            //arrange
            var backend = SettingsBackend.Instance;

            //act
            var result = backend.Update(null);

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsBackend_Update_Valid_Data_Should_Pass()
        {
            //arrange
            var backend = SettingsBackend.Instance;
            var testModel = backend.GetDefault();
            var expectId = "goodId";
            var expectPassword = "passWORD23!";

            //act
            testModel.Id = expectId;
            testModel.Password = expectPassword;

            var updateResult = backend.Update(testModel);

            var resultId = testModel.Id;
            var resultPassword = testModel.Password;

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(updateResult, TestContext.TestName);
            Assert.AreEqual(expectId, resultId, TestContext.TestName);
            Assert.AreEqual(expectPassword, resultPassword, TestContext.TestName);
        }
        #endregion update

        #region SetDataSource
        [TestMethod]
        public void Backend_SettingsBackend_SetDataSource_Valid_Enum_Should_Pass()
        {
            //arrange
            var expectEnum = FamilyTree.Models.DataSourceEnum.SQL;
            var backend = SettingsBackend.Instance;

            //act
            SettingsBackend.SetDataSource(expectEnum);
            var result = backend;

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsBackend_SetDataSource_Local_Should_Pass()
        {
            //arrange
            var expectEnum = FamilyTree.Models.DataSourceEnum.Local;
            var backend = SettingsBackend.Instance;

            //act
            SettingsBackend.SetDataSource(expectEnum);
            var result = backend;

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_SettingsBackend_SetDataSourceDataSet_Valid_Enum_Should_Pass()
        {
            //arrange
            var expectEnum = FamilyTree.Models.DataSourceDataSetEnum.UnitTest;
            var backend = SettingsBackend.Instance;

            //act
            SettingsBackend.SetDataSourceDataSet(expectEnum);
            var result = backend;

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion SetDataSource


        #region GetLatestDate
        [TestMethod]
        public void Backend_SettingsBackend_GetLatestDate_Should_Pass()
        {
            //arrange

            //act
            var result = SettingsBackend.Instance.GetLatestDate();

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion GetLatestDate

        #region UpdateLatestDate
        [TestMethod]
        public void Backend_SettingsBackend_UpdateLatestDate_Should_Pass()
        {
            //arrange
            var date = DateTime.Parse("01/23/2018");

            //act
            SettingsBackend.Instance.UpdateLatestDate(date);
            var result = SettingsBackend.Instance.GetLatestDate();

            //reset
            DataSourceBackend.Instance.Reset();

            //assert
            Assert.AreEqual(date,result, TestContext.TestName);
        }
        #endregion UpdateLatestDate
    }
}
