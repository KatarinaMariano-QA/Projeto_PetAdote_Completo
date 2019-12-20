using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdote_Mvc.Controllers
{
    public class ParceirosController : Controller
    {
        [Authorize]
        public ActionResult IndexParceiros()
        {
            return View();
        }
    }
}