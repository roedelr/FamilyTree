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

   

    public class PersonModel
    {

        [DisplayName("First name")]
        [Required(ErrorMessage = "Enter Name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "Enter Date of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Relationship to You")]
        [Required(ErrorMessage = "Relationship to You")]
        public RelationEnum IsToMe { get; set; }


        public PersonModel()
        {
            FirstName = "Bob";
            LastName = "Roedel";
            DOB = new DateTime(1960, 1, 1);
            IsToMe = RelationEnum.Father;
        }

        public PersonModel(string FirstName, string LastName, DateTime DOB, RelationEnum Relation)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DOB = DOB;
            IsToMe = Relation;
        }

    }
}