using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using static HairSalon.Startup;


namespace HairSalon.Tests
  {
      [TestClass]
      public class SpecialtyTests : IDisposable
      {

          public SpecialtyTests ()
          {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brian_nelson_test;";
          }

          public void Dispose()
          {
              Specialty.ClearAll();
              Stylist.ClearAll();
              Client.ClearAll();
          }

        [TestMethod] // test to see if database is cleared between tests
        public void GetAll_SpecialtysEmptyAtFirst_0()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();
            int result = Specialty.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod] // test to see if .Create and is creating in DB
        public void Create_SpecialtyAddedCorrectly_True()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();
            Specialty newSpecialty = new Specialty ("Mens");
            newSpecialty.Create();

            Specialty test = Specialty.GetAll()[0];
            Assert.AreEqual("Mens", test.Description);
        }

        [TestMethod] // test to see if getall returns all lines in DB
        public void GetAll_GetAllSpecialtys_Int ()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();
            Specialty newSpecialty1 = new Specialty ("Mens");
            newSpecialty1.Create();
            Specialty newSpecialty2 = new Specialty ("Kids");
            newSpecialty2.Create();
            Specialty newSpecialty3 = new Specialty ("Womens");
            newSpecialty3.Create();
            int result = Specialty.GetAll().Count;
            Assert.AreEqual(result, 3);
        }

        [TestMethod] // test to see if delete removes the proper db item
        public void Delete_DeleteSpecialtys_Count ()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();
            Specialty newSpecialty1 = new Specialty ("Mens");
            newSpecialty1.Create();
            Specialty newSpecialty2 = new Specialty ("Kids");
            newSpecialty2.Create();
            Specialty newSpecialty3 = new Specialty ("Womens");
            newSpecialty3.Create();
            Specialty.Delete(newSpecialty2.Id);
            int result = Specialty.GetAll().Count;
            Assert.AreEqual(result, 2);
        }

        [TestMethod] // test to see if find function returns proper stylist
        public void Find_FindSpecialty_Name ()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();
            Specialty newSpecialty1 = new Specialty ("Mens");
            newSpecialty1.Create();
            Specialty test = Specialty.Find(newSpecialty1.Id);
            Assert.AreEqual("Mens", test.Description);
        }

        [TestMethod]
        public void Update_ChangeSpecialtyNameCorrectly_True()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();

            Specialty newSpecialty1 = new Specialty ("Mnnes");
            newSpecialty1.Create();
            newSpecialty1.Update("Mens");
            Specialty testSpecialty = Specialty.Find(newSpecialty1.Id);

            Assert.AreEqual("Mens", testSpecialty.Description);
        }

        [TestMethod]
        public void StylistADDGET_AddSpecialtyAndReturnThem_True()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
            Client.ClearAll();
            Stylist newStylist1 = new Stylist ("Joes", 30,  Convert.ToDateTime("2018-02-02"));
            newStylist1.Create();
            Stylist newStylist2 = new Stylist ("Mandy", 30,  Convert.ToDateTime("2018-02-02"));
            newStylist2.Create();
            Specialty newSpecialty = new Specialty("Mens");
            newSpecialty.Create();

            newStylist1.AddSpecialty(newSpecialty.Id);
            newStylist2.AddSpecialty(newSpecialty.Id);

            List<Stylist> testList = new List<Stylist> {};
            testList.Add(newStylist1);
            testList.Add(newStylist2);

            List<Stylist> resultList = newSpecialty.GetStylists();
            Assert.AreEqual(testList[0].Id, resultList[0].Id);
            Assert.AreEqual(testList[0].Name, resultList[0].Name);
            Assert.AreEqual(testList[1].Id, resultList[1].Id);
            Assert.AreEqual(testList[1].Name, resultList[1].Name);
        }
    }
}
