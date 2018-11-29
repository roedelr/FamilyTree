using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Models;

namespace FamilyTree.Controllers
{
    public class UserController : Controller
    {
        public static UserModel user = new UserModel();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Service/SignIn
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        //
        // POST: /User/SignIn

        [HttpPost]
        public ActionResult SignIn([Bind(Include =
            "UserName," +
            "UserEmail," +
            "UserPassword," +
            "")] UserModel NextMember)
        {

            if (NextMember == user)
            {
                return RedirectToAction("Family/Index");
            }

            return View();
        }
    }
}