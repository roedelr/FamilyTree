using FamilyTree.Models;
using System;
using System.Web;

namespace FamilyTree.Backend
{
    /// <summary>
    /// Class that manages the overall data sources
    /// </summary>
    public class DataSourceBackend
    {
        /// <summary>
        /// Hold one of each of the DataSources as an instance to the datasource
        /// </summary>
        public SettingsBackend SettingsBackend = SettingsBackend.Instance;

        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile DataSourceBackend instance;
        private static object syncRoot = new Object();

        private static bool isTestingMode = false;

        private DataSourceBackend()
        {
            // Avatar must be before Student, because Student needs the default avatar
            SettingsBackend = SettingsBackend.Instance;
        }

        public static DataSourceBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DataSourceBackend();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Call for all data sources to reset
        /// </summary>
        public void Reset()
        {
            SettingsBackend.Reset();
            SetTestingMode(false);
        }

        /// <summary>
        /// Changes the data source, does not call for a reset, that allows for how swapping but keeping the original data in place
        /// </summary>
        public void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            // Set the Global DataSourceEnum Value
            SystemGlobalsModel.SetDataSourceEnum(dataSourceEnum);

            SettingsBackend.SetDataSource(SystemGlobalsModel.Instance.DataSourceValue);
        }

        /// <summary>
        /// Change between demo, default, and UT data sets
        /// </summary>
        /// <param name="SetEnum"></param>
        public void SetDataSourceDataSet(DataSourceDataSetEnum SetEnum)
        {
            SettingsBackend.SetDataSourceDataSet(SetEnum);
        }

        public static bool GetTestingMode()
        {
            return isTestingMode;
        }

        public static bool SetTestingMode(bool mode)
        {
            isTestingMode = mode;

            return isTestingMode;
        }

        //public bool IsUserNotInRole(string userID, FamilyTree.Models.UserRoleEnum role)
        //{
        //    if (isTestingMode)
        //    {
        //        return false; // all OK
        //    }

        //    if (IdentityBackend.UserHasClaimOfType(userID, role))
        //    {
        //        return false;
        //    }
        //    return true; // Not in role, so error
        //}

        public object CreateCookie(string testCookieName, string testCookieValue, HttpContextBase @object)
        {
            throw new NotImplementedException();
        }
    }
}