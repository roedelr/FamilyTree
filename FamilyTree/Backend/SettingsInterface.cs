using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamilyTree.Models;

namespace FamilyTree.Backend
{

    /// <summary>
    /// Datasource Interface for Avatars
    /// </summary>
    public interface ISettingsInterface
    {
        SettingsModel Create(SettingsModel data, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown);
        SettingsModel Read(string id);
        SettingsModel Update(SettingsModel data);
        bool Delete(string id, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown);
        List<SettingsModel> Index();
        void Reset();
        void LoadDataSet(DataSourceDataSetEnum setEnum);

        bool BackupData(DataSourceEnum dataSourceSource, DataSourceEnum dataSourceDestination);
    }
}