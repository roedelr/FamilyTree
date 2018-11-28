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
        // POST: /Family/Create

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
        public ActionResult Detail(string FirstName=null)
        {

            if (MyFamily == null)
                MyFamily = new FamilyBackend();
            PersonModel person = new PersonModel();
            person = data.PersonList.Find(model => model.FirstName == FirstName);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult Update(string FirstName=null)
        {
            if (MyFamily == null)
                MyFamily = new FamilyBackend();

            PersonModel person = new PersonModel();
            person = data.PersonList.Find(model=>model.FirstName==FirstName);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult Update([Bind(Include =
            "FirstName," +
            "LastName," +
            "DOB," +
            "IsToMe," +
            "")] PersonModel updateMember)
        {
            
            data.CurrentPerson= data.PersonList.Find(model => model.FirstName == updateMember.FirstName);
                
            data.CurrentPerson.FirstName = updateMember.FirstName;
            data.CurrentPerson.LastName = updateMember.LastName;
            data.CurrentPerson.DOB = updateMember.DOB;
            data.CurrentPerson.IsToMe = updateMember.IsToMe;

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string FirstName=null)
        {


            if (MyFamily == null)
                MyFamily = new FamilyBackend();
            PersonModel person = new PersonModel();
            person = data.PersonList.Single(model => model.FirstName == FirstName);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Family/Delete/

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteconFirm([Bind(Include =
            "FirstName," +
            "LastName," +
            "DOB," +
            "IsToMe," +
            "")] PersonModel deletePerson)
        {
            data.CurrentPerson = data.PersonList.Find(model => model.FirstName == deletePerson.FirstName);
            data.PersonList.Remove(data.CurrentPerson);
            
            return RedirectToAction("Index");
        }


        public FamilyBackend MyFamily;
    }
}