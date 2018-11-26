using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Backend;
using FamilyTree.Models;
using static FamilyTree.Models.PersonModelList;

namespace FamilyTree.Controllers
{
   
    public class FamilyController : Controller
    {

        public static PersonModelList data = new PersonModelList()
        {
            CurrentPerson = new PersonModel()
        };
        [HttpGet]
        public ActionResult Index()
        {
            if(MyFamily == null)
                MyFamily = new FamilyBackend();
         if(data ==null)
            {
                var person1 = new PersonModel();
                person1.FirstName = "Mike";

                data.PersonList.Add(person1);
            }
            
       
            return View(data);
        }

        // GET: /Service/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        public ActionResult Create([Bind(Include =
            "FirstName," +
            "LastName," +
            "DOB," +
            "IsToMe," +
            "")] PersonModel NextMember)
        {
            if (ModelState.IsValid)
            {

                data.PersonList.Add(NextMember);

                return RedirectToAction("Index");
               
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detail(string FirstName)
        {

            if (MyFamily == null)
                return View();

       
            

            return View();
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
           

            return View(NextMember);
        }

        public FamilyBackend MyFamily;
    }
}