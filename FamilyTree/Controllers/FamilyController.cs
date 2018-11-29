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

        public static FamilyBackend Family = new FamilyBackend();

        public static PersonModelList data = new PersonModelList()
        {
            CurrentPerson = new PersonModel()
        };

        [HttpGet]
        public ActionResult Index()
        {
            return View(Family.MyFam);
        }

        // GET: /Service/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
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
                Family.addMember(NextMember);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detail(int ID)
        {
            Family.getMember(ID);

            return View(Family.MyFam.CurrentPerson);
        }

        [HttpGet]
        public ActionResult Update(int ID)
        {
            Family.getMember(ID);
            
            return View(Family.MyFam.CurrentPerson);
        }

        [HttpPost]
        public ActionResult Update([Bind(Include =
            "FirstName," +
            "LastName," +
            "DOB," +
            "IsToMe," +
            "")] PersonModel UpdatedMember)
        {

            Family.updateMember(UpdatedMember);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Family.getMember(ID);

            return View(Family.MyFam.CurrentPerson);
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
            Family.removeMember();
            
            return RedirectToAction("Index");
        }
    }
}