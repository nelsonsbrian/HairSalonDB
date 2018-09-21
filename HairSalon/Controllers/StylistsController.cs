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

        [HttpPost("/stylists/create")]
        public ActionResult StylistCreate(string newName, int newPay, string newStartDate)
        {
            Stylist newStylist = new Stylist(newName, newPay, Convert.ToDateTime(newStartDate));
            newStylist.Create();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/delete/{id}")]
        public ActionResult StylistDelete(int id)
        {
            Stylist.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/client/create")]
        public ActionResult ClientCreate(string newName, string newAddress, string newphone, int newStylistId)
        {
            Client newClient = new Client(newName, newAddress, newphone, newStylistId);
            newClient.Create();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/client/delete/{id}")]
        public ActionResult ClientDelete(int id)
        {
            Client.Delete(id);
            return RedirectToAction("Index");
        }

    }

}
