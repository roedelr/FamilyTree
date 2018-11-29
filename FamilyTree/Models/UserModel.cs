using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FamilyTree.Models
{
    public class UserModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Enter a Username")]
        public string UserName { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Enter a Username")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Enter a Username")]
        public string UserPassword { get; set; }

        public UserModel()
        {
            UserName = "user1";
            UserEmail = "user@email.com";
            UserPassword = "password123";
        }

        public UserModel(string UserName, string UserEmail, string UserPassword)
        {
            this.UserName = UserName;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
        }
    }
}