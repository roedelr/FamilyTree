﻿using System;
using FamilyTree.Models.Enums;
//using Microsoft.WindowsAzure.Storage.Table;

namespace FamilyTree.Models
{
    public class TableEntity
    {
        public string PartitionKey;
        public string RowKey;

        public TableEntity(string pk, string rk)
        {
            PartitionKey = pk;
            RowKey = rk;
        }

        public TableEntity()
        {
            PartitionKey = null;
            RowKey = null;
        }
    }

    /// <summary>
    /// Data to Track Attendance. Contains info about who the student it, when he checked in and out, what his emotion status was. In and Out are in UTC
    /// </summary>
    public class DataSourceBackendTableEntity : TableEntity
    {

        /// <summary>
        /// data blob to store
        /// A Json format of the desired data package
        /// Needs to be converted to Json and passed in
        /// Results, need to be convered from TableEntity and parsed 
        /// </summary>
        public string Blob { get; set; }

        public DataSourceBackendTableEntity(string pk, string rk, string blob)
            : base(pk, rk)
        {
            Blob = blob;
        }

        public DataSourceBackendTableEntity(string pk, string rk)
            : base(pk, rk) { }

        public DataSourceBackendTableEntity() { }
    }
}