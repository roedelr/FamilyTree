using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Backend;
using FamilyTree.Models;


namespace FamilyTree.Controllers
{
    public class FamilyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if(MyFamily == null)
                MyFamily = new FamilyBackend();

            var person1 = new PersonModel();
            person1.FirstName = "Mike";

            var person2 = new PersonModel();
            person2.FirstName = "Doug";

            var data = new PersonModelList
            {
                CurrentPerson = new PersonModel()
            };

            data.PersonList.Add(person1);
            data.PersonList.Add(person2);
            data.PersonList.Add(data.CurrentPerson);

            return View(data);
        }

        [HttpGet]
        public ActionResult Update()
        {
            if (MyFamily == null)
                MyFamily = new FamilyBackend();

            var Rando = new PersonModel();

            return View(Rando);
        }

        [HttpPost]
        public ActionResult Update([Bind(Include =
            "FirstName," +
            "LastName," +
            "DOB," +
            "IsToMe," +
            "")] PersonModel NextMember)
        {
            PersonModel Update = NextMember;

            return View(Update);
        }

        public FamilyBackend MyFamily;
    }
}