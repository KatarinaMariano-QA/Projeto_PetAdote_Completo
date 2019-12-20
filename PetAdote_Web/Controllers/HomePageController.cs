using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdote_Web.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }
    }
}