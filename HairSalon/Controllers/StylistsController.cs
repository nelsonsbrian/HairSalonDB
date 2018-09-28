using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
namespace HairSalon.Controllers
{
    public class StylistsController:Controller
    {
        //stylists
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

        //clients
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


        //specialties
        [HttpGet("/stylists/specialty/remove/{styleId}/{specId}")]
        public ActionResult SpecialtyDeleteInStylists(int styleId, int specId)
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
        public ActionResult SpecialtyDetails(int id)
        {
            return View("Specialty", Specialty.Find(id));
        }

        [HttpPost("/stylists/specialty/add/{styleId}")]
        public ActionResult ClientAddSpecialty(int styleId, string newSpecialty)
        {
            Stylist.Find(styleId).AddSpecialty(int.Parse(newSpecialty));
            return RedirectToAction("Index");
        }


        //master delete
        [HttpGet("/master")]
        public ActionResult Master()
        {
            return View("Master");
        }

        //deleteall
        [HttpGet("/master/client/delete")]
        public ActionResult MasterClientDelete()
        {
            Client.ClearAll();
            return RedirectToAction("Master");
        }
        [HttpGet("/master/stylists/delete")]
        public ActionResult MasterStylistDelete()
        {
            Stylist.ClearAll();
            return RedirectToAction("Master");
        }
        [HttpGet("/master/specialties/delete")]
        public ActionResult MasterSpecialtyDelete()
        {
            Specialty.ClearAll();
            return RedirectToAction("Master");
        }

        //single delete
        [HttpGet("/master/client/{id}/delete")]
        public ActionResult MasterClientIDDelete(int id)
        {
            Client.Delete(id);
            return RedirectToAction("Master");
        }
        [HttpGet("/master/stylists/{id}/delete")]
        public ActionResult MasterStylistIDDelete(int id)
        {
            Stylist.Delete(id);
            return RedirectToAction("Master");
        }
        [HttpGet("/master/specialties/{id}/delete")]
        public ActionResult MasterSpecialtyIDDelete(int id)
        {
            Specialty.Delete(id);
            return RedirectToAction("Master");
        }

        //updates
        [HttpGet("/master/client/{id}/update")]
        public ActionResult ClientUpdateForm(int id)
        {
            return View("EditClient", Client.Find(id));
        }
        [HttpPost("/master/client/{id}/update")]
        public ActionResult ClientUpdate(string newName, string newAddress, string newphone, int newStylistId, int id)
        {
            Client.Find(id).Update(newName, newAddress, newphone, newStylistId);
            return RedirectToAction("Master");
        }

        [HttpGet("/master/stylists/{id}/update")]
        public ActionResult StylistUpdateForm(int id)
        {
            return View("EditStylist", Stylist.Find(id));
        }
        [HttpPost("/master/stylists/{id}/update")]
        public ActionResult StylistUpdate(string newName, int newWage, int id)
        {
            Stylist.Find(id).Update(newName, newWage);      
            return RedirectToAction("Master");
        }

    }

}
