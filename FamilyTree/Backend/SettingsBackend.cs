using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamilyTree.Models;


namespace FamilyTree.Backend
{
    public class SettingsBackend
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile SettingsBackend instance;
        private static object syncRoot = new Object();

        private SettingsBackend() { }

        public static SettingsBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SettingsBackend();
                            SetDataSource(SystemGlobalsModel.Instance.DataSourceValue);
                        }
                    }
                }

                return instance;
            }
        }

        // Get the Datasource to use
        private static ISettingsInterface DataSource;

        /// <summary>
        /// Switches between Live, and Mock Datasets
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            switch (dataSourceEnum)
            {
                case DataSourceEnum.SQL:
                    break;

                case DataSourceEnum.Local:
                case DataSourceEnum.ServerLive:
                case DataSourceEnum.ServerTest:
                    DataSourceBackendTable.Instance.SetDataSourceServerMode(dataSourceEnum);
                    DataSource = SettingsDataSourceTable.Instance;
                    break;

                case DataSourceEnum.Mock:
                default:
                    // Default is to use the Mock
                    DataSource = SettingsDataSourceMock.Instance;
                    break;
            }
        }

        /// <summary>
        /// Switch the data set between Demo, Default and Unit Test
        /// </summary>
        /// <param name="SetEnum"></param>
        public static void SetDataSourceDataSet(DataSourceDataSetEnum SetEnum)
        {
            DataSource.LoadDataSet(SetEnum);
        }

        /// <summary>
        /// Get all the records from the db
        /// </summary>
        public List<SettingsModel> Index()
        {
            return DataSource.Index();
        }


        /// <summary>
        /// Helper function that resets the DataSource, and rereads it.
        /// </summary>
        public void Reset()
        {
            DataSource.Reset();
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public SettingsModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = DataSource.Read(id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public SettingsModel Update(SettingsModel data)
        {
            if (data == null)
            {
                return null;
            }

            var myReturn = DataSource.Update(data);

            return myReturn;
        }

        /// <summary>
        /// Backup the Data from Source to Destination
        /// </summary>
        /// <param name="dataSourceSource"></param>
        /// <param name="dataSourceDestination"></param>
        /// <returns></returns>
        public bool BackupData(DataSourceEnum dataSourceSource, DataSourceEnum dataSourceDestination)
        {
            var result = DataSource.BackupData(dataSourceSource, dataSourceDestination);
            return result;
        }

        /// <summary>
        /// Returns the First record
        /// </summary>
        /// <returns>Null or valid data</returns>
        public SettingsModel GetDefault()
        {
            var myReturn = Index().First();
            return myReturn;
        }

        public DateTime GetLatestDate()
        {
            var myReturn = Index().First();
            return myReturn.LastProcessedDate;
        }

        public DateTime UpdateLatestDate(DateTime date)
        {
            var myReturn = Index().First();
            myReturn.LastProcessedDate = date;

            var result = Update(myReturn);

            return result.LastProcessedDate;
        }
    }
}