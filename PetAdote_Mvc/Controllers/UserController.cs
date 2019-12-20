using PetAdote_Application.IServices;
using PetAdote_Infra.Context;
using System.Linq;
using System.Web.Mvc;

namespace PetAdote_Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IPetService _pet;
        public UserController(IPetService pet)
        {
            this._pet = pet;
        }

        private readonly PetAdoteDbContext context = new PetAdoteDbContext();
        [Authorize]
        public ActionResult IndexUser()
        {
            if (context.Pets == null)
            {
                return HttpNotFound();
            }
            return View(context.Pets.Where(p => p.Status.Equals("Adocao")));
        }
    }
}