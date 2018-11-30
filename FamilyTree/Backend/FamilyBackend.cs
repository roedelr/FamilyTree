using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Models;
using FamilyTree.Models.Enums;


namespace FamilyTree.Backend
{
    public class FamilyBackend
    {
        public FamilyBackend()
        {
            MyFam = new PersonModelList();
        }

        public bool addMember(PersonModel NextMember)
        {
            
            NextMember.ID = getID();

            MyFam.PersonList.Add(NextMember);

            return true;
        }

        public bool getMember(int ID)
        {
            MyFam.CurrentPerson = MyFam.PersonList.Find(model => model.ID == ID);

            return true;
        }

        public bool removeMember()
        {
            MyFam.PersonList.Remove(MyFam.CurrentPerson);

            return true;
        }

        public bool updateMember(PersonModel updateMember)
        {
            MyFam.CurrentPerson.FirstName = updateMember.FirstName;
            MyFam.CurrentPerson.LastName = updateMember.LastName;
            MyFam.CurrentPerson.DOB = updateMember.DOB;
            MyFam.CurrentPerson.IsToMe = updateMember.IsToMe;

            return true;
        }

        private int getID() { return MyFam.IDMaker++; }

        public PersonModelList MyFam;
    }
}