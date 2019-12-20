using PetAdote_Application.IServices;
using PetAdote_Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetAdote_Dominio.Entities;

namespace PetAdote_Mvc.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IPetService _pet;
        public HomePageController(IPetService pet)
        {
            this._pet = pet;
        }
        private readonly PetAdoteDbContext context = new PetAdoteDbContext();
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult PetsList()
        {
            if (context.Pets == null)
            {
                return HttpNotFound();
            }
            
            
            
            return View(context.Pets.Where(p => p.Status.Equals("Adocao")));
        }
    }
}