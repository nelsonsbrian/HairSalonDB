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

        [HttpGet("/stylists/details/{id}")]
        public ActionResult StylistDetails(int id)
        {
            return View("Details", Stylist.Find(id));
        }

        [HttpGet("/stylists/client/schedule/{id}")]
        public ActionResult ClientSchedule(int id)
        {
            return View("Schedule", Client.Find(id));
        }

        [HttpGet("/stylists/specialty/remove/{styleId}/{specId}")]
        public ActionResult SpecialtyDelete(int styleId, int specId)
        {
            Stylist.Find(styleId).RemoveSpecialty(specId);
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/specialty/create")]
        public ActionResult ClientCreate(string newDesc)
        {
            Specialty newSpecialty = new Specialty(newDesc);
            newSpecialty.Create();
            return RedirectToAction("Index");
        }

        [HttpGet("/specialty/details/{id}")]
        public ActionResult ClientCreate(int id)
        {
            return View("Specialty", Specialty.Find(id));
        }

        [HttpPost("/stylists/specialty/add/{styleId}}")]
        public ActionResult ClientCreate(int styleId, int newSpecialty)
        {
            Stylist.Find(styleId).AddSpecialty(int.Parse(newSpecialty));
            return RedirectToAction("Index");
        }

    }

}
