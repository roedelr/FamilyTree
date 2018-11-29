﻿using System;
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
                Family.addMember(NextMember);

                data.PersonList.Add(NextMember);

                return RedirectToAction("Index");
               
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detail(string FirstName=null, int ID = -1)
        {
            Family.getMember(ID);

            return View(Family.MyFam.CurrentPerson);
        }

        [HttpGet]
        public ActionResult Update(string FirstName = null, int ID = -1)
        {
            Family.getMember(ID);

            PersonModel person = new PersonModel();

            person = data.PersonList.Find(model=>model.FirstName==FirstName);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(Family.MyFam.CurrentPerson);
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
        public ActionResult Delete(string FirstName = null, int ID = -1)
        {
            Family.getMember(ID);

            PersonModel person = new PersonModel();

            person = data.PersonList.Single(model => model.FirstName == FirstName);
            if (person == null)
            {
                return HttpNotFound();
            }
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
            data.CurrentPerson = data.PersonList.Find(model => model.FirstName == deletePerson.FirstName);
            data.PersonList.Remove(data.CurrentPerson);
            
            return RedirectToAction("Index");
        }
    }
}