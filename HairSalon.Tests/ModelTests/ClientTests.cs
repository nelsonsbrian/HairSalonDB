using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using static HairSalon.Startup;


namespace HairSalon.Tests
  {
  [TestClass]
  public class ClientTests : IDisposable
  {

    public ClientTests ()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brian_nelson_test;";
    }

    public void Dispose()
    {
      Client.ClearAll();
    }

    [TestMethod] // test to see if database is cleared between tests
    public void GetAll_ClientsEmptyAtFirst_0()
    {
      Client.ClearAll();
      int result = Client.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    // [TestMethod] // test to see if .Create and is creating in DB
    // public void Create_ClientAddedCorrectly_True()
    // {
    //   Client.ClearAll();
    //   Client newClient = new Client ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
    //   newClient.Create();
    //
    //   Client test = Client.GetAll()[0];
    //   Assert.AreEqual("Jose", test.Name);
    // }
    //
    // [TestMethod] // test to see if getall returns all lines in DB
    // public void GetAll_GetAllCusines_Int ()
    // {
    //     Client.ClearAll();
    //     Client newClient1 = new Client ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
    //     newClient1.Create();
    //     Client newClient2 = new Client ("Maggie", 22,  Convert.ToDateTime("2015-02-02"));
    //     newClient2.Create();
    //     Client newClient3 = new Client ("Fred", 14,  Convert.ToDateTime("2013-02-02"));
    //     newClient3.Create();
    //     int result = Client.GetAll().Count;
    //     Assert.AreEqual(result, 3);
    // }
    //
    // [TestMethod] // test to see if delete removes the proper db item
    // public void Delete_DeleteCusines_Count ()
    // {
    //     Client.ClearAll();
    //     Client newClient1 = new Client ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
    //     newClient1.Create();
    //     Client newClient2 = new Client ("Maggie", 22,  Convert.ToDateTime("2015-02-02"));
    //     newClient2.Create();
    //     Client newClient3 = new Client ("Fred", 14,  Convert.ToDateTime("2013-02-02"));
    //     newClient3.Create();
    //     Client.Delete(newClient2.Id);
    //     int result = Client.GetAll().Count;
    //     Assert.AreEqual(result, 2);
    // }
    //
    // [TestMethod] // test to see if find function returns proper stylist
    // public void Find_FindClient_Name ()
    // {
    //     Client.ClearAll();
    //     Client newClient1 = new Client ("Jose", 30,  Convert.ToDateTime("2018-02-02"));
    //     Console.WriteLine(newClient1.Id);
    //     newClient1.Create();
    //     Console.WriteLine(newClient1.Id);
    //     Client test = Client.Find(newClient1.Id);
    //     Console.WriteLine(test.Id);
    //     Assert.AreEqual("Jose", test.Name);
    // }

    // [TestMethod]
    // public void Update_ChangeClientNameCorrectly_True()
    // {
    //     Client newFood = new Client("Mexican");
    //
    //     newFood.Create();
    //     Console.WriteLine(newFood.Id);
    //     newFood.Update("Fake Mexican");
    //
    //     Client result = Client.GetAll()[0];
    //
    //     Assert.AreEqual("Fake Mexican",newFood.FoodType);
    // }
  }
}
