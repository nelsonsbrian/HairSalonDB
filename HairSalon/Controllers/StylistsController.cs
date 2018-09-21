using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
namespace HairSalon.Controllers
{
    public class StylistsController:Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            return View("Index", Stylist.GetAll());
        }

        [HttpPost("/stylists/Create")]
        public ActionResult Create(string newName, int newPay, string newStartDate)
        {
            Stylist newStylist = new Stylist(newName, newPay, Convert.ToDateTime(newStartDate));
            newStylist.Create();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/delete/{id}")]
        public ActionResult Delete(int id)
        {
            Stylist.Delete(id);
            return RedirectToAction("Index");
        }

    }

}
