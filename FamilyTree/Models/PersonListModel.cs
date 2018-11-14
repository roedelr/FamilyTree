using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FamilyTree.Models.Enums;

namespace FamilyTree.Models
{
    public class PersonModelList
    {

        public List<PersonModel> PersonList = new List<PersonModel>();

        public PersonModel CurrentPerson = new PersonModel();
        
    }
}