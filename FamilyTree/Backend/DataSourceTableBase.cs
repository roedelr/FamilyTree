using System;
using System.Collections.Generic;

using FamilyTree.Models;
//using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System.Linq;

namespace FamilyTree.Backend
{
    /// <summary>
    /// Backend Table DataSource for AvatarItems, to manage them
    /// </summary>
    public class DataSourceTableBase<T>
    {
        private List<T> DataList = new List<T>();

        private string tableName;

        /// <summary>
        /// Partition Key used for data storage
        /// </summary>
        private string partitionKey;

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            LoadDataSet(DataSourceDataSetEnum.Default);
        }

        /// <summary>
        /// Clears the Data
        /// </summary>
        private void DataSetClear()
        {
            DataList.Clear();
        }

        /// <summary>
        /// The Defalt Data Set
        /// </summary>
        private void DataSetDefault()
        {
            DataSetClear();
            CreateDataSetDefaultData();
        }

        /// <summary>
        /// Load the data from the server, and then default data if needed.
        /// </summary>
        public void CreateDataSetDefaultData() {

            // Storage Load all rows
            //var DataSetList = LoadAll();

            //foreach (var item in DataSetList)
            //{
            //    DataList.Add(item);
            //}

            //// If Storage is Empty, then Create.
            //if (DataList.Count < 1)
            //{
                //CreateDataSetDefault();
           // }

            // Order the set by TimeStamp
//            DataList = DataList.OrderBy(x => x.TimeStamp).ToList();
        }


        /// <summary>
        /// Load all the records from the datasource
  
            /// <summary>
        /// Data set for demo
        /// </summary>
        private void DataSetDemo()
        {
            DataSetDefault();
        }

        /// <summary>
        /// Unit Test data set
        /// </summary>
        private void DataSetUnitTest()
        {
            DataSetDefault();
        }

        /// <summary>
        /// Set which data to load
        /// </summary>
        /// <param name="setEnum"></param>
        public void LoadDataSet(DataSourceDataSetEnum setEnum)
        {
            switch (setEnum)
            {
                case DataSourceDataSetEnum.Demo:
                    DataSetDemo();
                    break;

                case DataSourceDataSetEnum.UnitTest:
                    DataSetUnitTest();
                    break;

                case DataSourceDataSetEnum.Default:
                default:
                    DataSetDefault();
                    break;
            }
        }
        
    }
}