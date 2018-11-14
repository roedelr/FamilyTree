using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FamilyTree.Models
{
    public class FamilyModel
    {
        public FamilyModel()
        {
            FMem = null;
        }

        /// <summary>
        /// Family name for all members
        /// </summary>
        [DisplayName("My Family")]
        public LinkedList<PersonModel> FMem { get; set; }
    }
}