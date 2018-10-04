using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using static HairSalon.Startup;


namespace HairSalon.Tests
  {
  [TestClass]
  public class StylistTests : IDisposable
  {

    public StylistTests ()
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
    public void GetAll_StylistsEmptyAtFirst_0()
    {
      Stylist.ClearAll();
      int result = Stylist.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod] // test to see if .Create and is creating in DB
    public void Create_StylistAddedCorrectly_True()
    {
      Stylist.ClearAll();
      Stylist newStylist = new Stylist ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
      newStylist.Create();

      Stylist test = Stylist.GetAll()[0];
      Assert.AreEqual("Jose", test.Name);
    }

    [TestMethod] // test to see if getall returns all lines in DB
    public void GetAll_GetAllStylists_Int ()
    {
        Stylist.ClearAll();
        Stylist newStylist1 = new Stylist ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
        newStylist1.Create();
        Stylist newStylist2 = new Stylist ("Maggie", 22,  Convert.ToDateTime("2015-02-02"));
        newStylist2.Create();
        Stylist newStylist3 = new Stylist ("Fred", 14,  Convert.ToDateTime("2013-02-02"));
        newStylist3.Create();
        int result = Stylist.GetAll().Count;
        Assert.AreEqual(result, 3);
    }

    [TestMethod] // test to see if delete removes the proper db item
    public void Delete_DeleteStylists_Count ()
    {
        Stylist.ClearAll();
        Stylist newStylist1 = new Stylist ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
        newStylist1.Create();
        Stylist newStylist2 = new Stylist ("Maggie", 22,  Convert.ToDateTime("2015-02-02"));
        newStylist2.Create();
        Stylist newStylist3 = new Stylist ("Fred", 14,  Convert.ToDateTime("2013-02-02"));
        newStylist3.Create();
        Stylist.Delete(newStylist2.Id);
        int result = Stylist.GetAll().Count;
        Assert.AreEqual(result, 2);
    }

    [TestMethod] // test to see if find function returns proper stylist
    public void Find_FindStylist_Name ()
    {
        Stylist.ClearAll();
        Stylist newStylist1 = new Stylist ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
        newStylist1.Create();
        Stylist test = Stylist.Find(newStylist1.Id);
        Assert.AreEqual("Jose", test.Name);
    }

    [TestMethod]
    public void Update_ChangeStylistNameCorrectly_True()
    {
        Stylist newStylist = new Stylist ("Joes", 30,  Convert.ToDateTime("2018-02-02"));
        string testName = "Jose";
        newStylist.Create();
        newStylist.Update(testName, 20);
        Stylist result = Stylist.Find(newStylist.Id);
        Assert.AreEqual(20, result.Wage);
        Assert.AreEqual(testName, result.Name);
    }

    [TestMethod]
    public void SpecialtyADDGET_AddSpecialtyAndReturnThem_True()
    {
        Specialty.ClearAll();
        Stylist.ClearAll();
        Client.ClearAll();
        Stylist newStylist = new Stylist ("Joes", 30,  Convert.ToDateTime("2018-02-02"));
        newStylist.Create();
        Specialty newSpecialty1 = new Specialty("Mens");
        newSpecialty1.Create();
        Specialty newSpecialty2 = new Specialty("Womens");
        newSpecialty2.Create();

        Console.WriteLine(Specialty.GetAll().Count);

        Console.WriteLine("stylistid " + newStylist.Id);
        newStylist.AddSpecialty(newSpecialty1.Id);
        Console.WriteLine(newSpecialty1.Id + newSpecialty1.Description + newStylist.Id);
        newStylist.AddSpecialty(newSpecialty2.Id);
        Console.WriteLine(newSpecialty2.Id + newSpecialty2.Description + newStylist.Id);

        List<Specialty> testList = new List<Specialty> {};
        testList.Add(newSpecialty1);
        testList.Add(newSpecialty2);


        List<Specialty> resultList = newStylist.GetSpecialties();
        Assert.AreEqual(testList[0].Id, resultList[0].Id);
        Assert.AreEqual(testList[0].Description, resultList[0].Description);
        Assert.AreEqual(testList[1].Id, resultList[1].Id);
        Assert.AreEqual(testList[1].Description, resultList[1].Description);

    }
  }
}
