using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyTree.Models
{
    public class UserModel : Controller
    {
        // GET: UserModel
        public ActionResult Index()
        {
            return View();
        }
    }
}