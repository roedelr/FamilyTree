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
    public class DataSourceBackendUnitTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DataSourceBackend.SetTestingMode(true);
        }

        #region Instantiate
        [TestMethod]
        public void Backend_DataSourceBackend_Default_Instantiate_Should_Pass()
        {
            // Arrange
            var backend = DataSourceBackend.Instance;

            // Act
            var result = backend;

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion Instantiate

        #region SetDataSource
        [TestMethod]
        public void Backend_DataSourceBackend_SetDataSource_Valid_Enum_Should_Pass()
        {
            // Arrange
            var backend = DataSourceBackend.Instance;
            var expectEnum = FamilyTree.Models.DataSourceEnum.Mock;

            // Act
            backend.SetDataSource(expectEnum);
            var result = backend;

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void Backend_DataSourceBackend_SetDataSourceDataSet_Valid_Enum_Should_Pass()
        {
            // Arrange
            var backend = DataSourceBackend.Instance;
            var expectEnum = FamilyTree.Models.DataSourceDataSetEnum.UnitTest;

            // Act
            backend.SetDataSourceDataSet(expectEnum);
            var result = backend;

            //Reset
            backend.Reset();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }
        #endregion SetDataSource
    }
}
