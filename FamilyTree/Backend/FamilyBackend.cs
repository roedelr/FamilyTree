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
                MyFam = new FamilyModel();
            }

            public bool setMe(string FirstName, string LastName, DateTime DOB)
            {
                foreach (PersonModel member in MyFam.FMem)
                {
                    if (member.IsToMe == RelationEnum.Self)
                        return false;
                }

                MyFam.FMem.AddLast(value: new PersonModel(FirstName, LastName, DOB, RelationEnum.Self));

                return true;
            }

            public bool addMember(PersonModel nextMember)
            {
                MyFam.FMem.AddLast(nextMember);

                return true;
            }
            public bool reMoveMember(PersonModel deleteMember)
            {
                MyFam.FMem.Remove(deleteMember);

                return true;
             }

        public bool updateMember(PersonModel updateMember)
        {
           

            return true;
        }
        public FamilyModel MyFam;
    }
}