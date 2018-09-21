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
      Stylist.ClearAll();
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
      Stylist newfood = new Stylist ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
      newfood.Create();

      Stylist test = Stylist.GetAll()[0];
      Assert.AreEqual ("Jose", test.Name);
    }

    // [TestMethod]
    // public void ClearAll_DeleteAllCusines_Int ()
    // {
    //     Stylist newfood1 = new Stylist ("Mexican");
    //     newfood1.Create ();
    //     Stylist newfood2 = new Stylist ("American");
    //     newfood2.Create ();
    //     Stylist newfood3 = new Stylist ("Italian");
    //     newfood3.Create ();
    //     Stylist newfood4 = new Stylist ("Chinese");
    //     newfood4.Create ();
    //     Stylist.ClearAll();
    //     Stylist newfood5 = new Stylist ("Vietnamese");
    //     newfood5.Create ();
    //     int result = Stylist.GetAll().Count;
    //     Assert.AreEqual( result, 1);
    // }
    //
    // [TestMethod]
    // public void Update_ChangeStylistNameCorrectly_True()
    // {
    //     Stylist newFood = new Stylist("Mexican");
    //
    //     newFood.Create();
    //     Console.WriteLine(newFood.Id);
    //     newFood.Update("Fake Mexican");
    //
    //     Stylist result = Stylist.GetAll()[0];
    //
    //     Assert.AreEqual("Fake Mexican",newFood.FoodType);
    // }
  }
}
